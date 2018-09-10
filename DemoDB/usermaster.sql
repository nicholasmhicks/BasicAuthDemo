CREATE TABLE [dbo].[usermaster]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserName] nvarchar(50) not null,
	[Password] nvarchar(50) not null,
	[IsActive] int not null
)
