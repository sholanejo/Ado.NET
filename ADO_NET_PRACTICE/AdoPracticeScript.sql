CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Publisher] [nvarchar](50) NULL,
	[Isbn] [nvarchar](20) NOT NULL,
	[ReleaseDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (1, N'Professional C# 6 and .NET Core 1.0', N'Wrox Press', N'978-1-119-09660-3', CAST(N'2016-04-11' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (2, N'Professional C# 5.0 and .NET 4.5.1', N'Wrox Press', N'978-1-118-83303-2', CAST(N'2014-02-09' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (3, N'Enterprisee Services with the .NET Framework', N'Addison Wesley', N'978-0321246738', CAST(N'2005-06-03' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (4, N'Beginning Visual C# 2012 Programming', N'Wrox Press', N'978-1118314418', CAST(N'2012-12-04' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (5, N'Real World .NET, C#, and Silverlight', N'Wrox Press', N'978-1118021965 ', CAST(N'2011-11-22' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (6, N'Professional C# 3rd Edition', N'Wrox Press', N'978-0764557590', CAST(N'2004-06-02' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (7, N'Beginning Visual C# 2010', N'Wrox Press', N'978-0470502266', CAST(N'2010-04-05' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (8, N'Professional C# 2008', N'Wrox Press', N'978-0470191378', CAST(N'2008-05-24' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (9, N'Professional C# 4 and .NET 4', N'Wrox Press', N'978-0470502259', CAST(N'2010-03-08' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (10, N'Professional C# 2nd Edition', N'Wrox Press', N'978-1861007049', CAST(N'2002-03-28' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (11, N'Professional C# 2012 and .NET 4.5', N'Wrox Press', N'978-1118314425', CAST(N'2012-10-18' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (12, N'Professional C# 2005', N'Wrox Press', N'978-0764575341', CAST(N'2005-11-07' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (13, N'Beginning Visual C# 2005', N'Wrox Press', N'978-0764578472', CAST(N'2005-11-07' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (14, N'Pro .NET 1.1 Network Programming', N'APress', N'978-1590593455', CAST(N'2004-09-30' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (15, N'Beginning Visual C# 2008', N'Wrox Press', N'978-0470191354', CAST(N'2008-05-05' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (16, N'Beginning C#', N'Wrox Press', N'978-1861004987', CAST(N'2001-09-15' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (17, N'Beginning Visual C#', N'Wrox Press', N'978-0764543821', CAST(N'2002-08-20' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (18, N'Professional C# 2005 with .NET 3.0', N'Wrox Press', N'978-0470124727', CAST(N'2007-06-12' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (19, N'ASP to ASP.NET Migration Handbook', N'Wrox Press', N'978-1861008466', CAST(N'2003-02-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (1010, N'Professional C# Web Services', N'Wrox Press', N'978-1861004390', CAST(N'2001-12-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (1012, N'Professional C# (Beta 2 Edition)', N'Wrox Press', N'978-1861004994', CAST(N'2001-06-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (1014, N'Professional .NET Network Programming', N'Wrox Press', N'978-1861007353', CAST(N'2002-10-01' AS Date))
INSERT [dbo].[Books] ([Id], [Title], [Publisher], [Isbn], [ReleaseDate]) VALUES (1015, N'Professional C# 7 and .NET Core 2.0', N'Wrox Press', N'978-1119449270', CAST(N'2018-04-02' AS Date))
SET IDENTITY_INSERT [dbo].[Books] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Books_Isbn]    Script Date: 10/3/2017 10:00:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Books_Isbn] ON [dbo].[Books]
(
	[Isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetBooksByPublisher]    Script Date: 10/3/2017 10:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBooksByPublisher]
	@publisher nvarchar(50)
AS
	SELECT [Id], [Title], [Publisher], [ReleaseDate] FROM [dbo].[Books] WHERE [Publisher] = @publisher ORDER BY [ReleaseDate]
GO
USE [master]
GO
ALTER DATABASE [Books] SET  READ_WRITE 
GO