using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace ADO_NET_PRACTICE
{
    class Program
    {
        public static string GetConnectionString()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Integrated Security=SSPI; Initial Catalog=AdoPracticeTest";
            return connectionString;
        }

        public static void OpenConnection()
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Integrated Security=SSPI; Initial Catalog=AdoPracticeTest";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection Opened");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void CreateCommand()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = "SELECT [Title], [Publisher], [ReleaseDate] FROM [dbo].[Books]";
                    var command = new SqlCommand(sql, connection);
                    connection.Open();
                    object count = command.Connection;
                    Console.WriteLine(count);
                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                
            }
        }

        public static void ExecuteNonQuery(string title, string publisher, string isbn, DateTime releaseDate)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string sql = "INSERT INTO [dbo].[Books] ([Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (@Title, @Publisher, @Isbn, @ReleaseDate)";
                    var command = new SqlCommand(sql, connection);
                    SqlParameter parameter = new SqlParameter
                    {
                        ParameterName = "@Title",
                        Value = title,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50
                    };
                    command.Parameters.Add(parameter);
                    parameter = new SqlParameter
                    {
                        ParameterName = "@Publisher",
                        Value = publisher,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50
                    };
                    command.Parameters.Add(parameter);
                    parameter = new SqlParameter
                    {
                        ParameterName = "@Isbn",
                        Value = isbn,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 20
                    };
                    command.Parameters.Add(parameter);
                    parameter = new SqlParameter
                    {
                        ParameterName = "@ReleaseDate",
                        Value = releaseDate,
                        SqlDbType = SqlDbType.DateTime,
                        Size = 50
                    };
                    command.Parameters.Add(parameter);
                    int records = command.ExecuteNonQuery();
                    Console.WriteLine("{0} record(s) has been inserted", records);
                   
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExecuteScalar()
        {
            try
            {
                using(var connection = new SqlConnection(GetConnectionString()))
                {
                    string sql = "SELECT COUNT(*) FROM [dbo].[Books]";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql;
                    connection.Open();
                    object count = command.ExecuteScalar();
                    Console.WriteLine("The total number of book records is {0}", count);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExecuteReader(string title)
        {
            try
            {
                string GetBookQuery() => "SELECT [Id], [Title], [Publisher], [ReleaseDate] FROM [dbo] . [Books] WHERE lower([Title]) LIKE @Title ORDER BY [ReleaseDate] DESC";
                var connection = new SqlConnection(GetConnectionString());
                var command = new SqlCommand(GetBookQuery(), connection);
                var parameter = new SqlParameter("Title", SqlDbType.NVarChar, 50)
                {
                    Value = $"{title}%"
                };
                command.Parameters.Add(parameter);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string bookTitle = reader.GetString(1);
                        string publisher = reader.GetString(2);
                        DateTime from = reader.GetDateTime(3);
                        Console.WriteLine($"{id, 5}. {bookTitle, -40} {publisher,-15} {from:d}");
                    }
            }   }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void StoredProcedure(string publisher)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "[dbo].[GetBooksByPublisher]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = command.CreateParameter();
                    p1.SqlDbType = SqlDbType.NVarChar;
                    p1.ParameterName = "@Publisher";
                    p1.Value = publisher;
                    command.Parameters.Add(p1);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int recursionLevel = (int)reader["Id"];
                            string title = (string)reader["Title"];
                            string pub = (string)reader["Publisher"];
                            DateTime releaseDate = (DateTime)reader["ReleaseDate"];
                            Console.WriteLine($"{title} - {pub}; {releaseDate:d}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task ReadAsync(int productId)
        {
            var connection = new SqlConnection(GetConnectionString());
            string sql = "SELECT [Title], [Publisher], [ReleaseDate] FROM [dbo].[Books] WHERE lower([Title]) LIKE @Title ORDER BY [ReleaseDate]";
            var command = new SqlCommand(sql, connection);
            var titleParameter = new SqlParameter("Title", SqlDbType.NVarChar, 50);
            titleParameter.Value = $"{productId}";
            
            command.Parameters.Add(titleParameter);
            await connection.OpenAsync();
            using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
            {
                while(await reader.ReadAsync())
                {
                    int id = reader.GetInt32(0);
                    string bookTitle = reader.GetString(1);
                    string publisher = reader[2].ToString();
                    DateTime? releaseDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                    Console.WriteLine($"{id, 5} {bookTitle, -40} {publisher, -15} {releaseDate:d}");
                }
            }
        }
        public static async Task TransactionSample()
        {
            using(var connection = new SqlConnection(GetConnectionString()))
            {
                await connection.OpenAsync();
                SqlTransaction tx = connection.BeginTransaction();
                try
                {
                    string sql = "INSERT INTO [dbo].[Books] ([Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (@Title, @Publisher, @Isbn, @ReleaseDate); SELECT SCOPE_IDENTITY()";
                    var command = new SqlCommand
                    {
                        CommandText = sql,
                        Connection = connection,
                        Transaction = tx
                    };
                    var p1 = new SqlParameter("Title", SqlDbType.NVarChar, 50);
                    var p2 = new SqlParameter("Publisher", SqlDbType.NVarChar, 50);
                    var p3 = new SqlParameter("Isbn", SqlDbType.NVarChar, 20);
                    var p4 = new SqlParameter("ReleaseDate", SqlDbType.DateTime);
                    command.Parameters.AddRange(new SqlParameter[] { p1, p2, p3, p4 });

                    command.Parameters["Title"].Value = "New Shola";
                    command.Parameters["Publisher"].Value = "Nejo Press";
                    command.Parameters["Isbn"].Value = "123-456789123";
                    command.Parameters["ReleaseDate"].Value = DateTime.Now;
                    object id = await command.ExecuteScalarAsync();
                    Console.WriteLine($"Record added with id:{id}");

                    command.Parameters["Title"].Value = "New Shola 1";
                    command.Parameters["Publisher"].Value = "Nejo Press";
                    command.Parameters["Isbn"].Value = "123-456789123";
                    command.Parameters["ReleaseDate"].Value = DateTime.Now;
                    id = await command.ExecuteScalarAsync();
                    Console.WriteLine($"Record added with id:{id}");

                    tx.Commit();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    tx.Rollback();
                }
            }
        }


        public static async Task Main(string[] args)
        {
            //await TransactionSample();
            //await ReadAsync(1015);
            //OpenConnection();
            //CreateCommand();
            //ExecuteNonQuery("Test Insert", "Shola Nejo", "123-123456789", DateTime.Now);
            //ExecuteNonQuery("Another One", "Shola Nejo", "123-1234567890", new DateTime(1995,05,12));
            //ExecuteScalar();
            //ExecuteReader("");

        }
    }
}
