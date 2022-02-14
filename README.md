# sample001-dotnet-func-ef

**Prerequisites**
- **Create this table in your Sql Server DB first**
```
CREATE TABLE [dbo].[AddressBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Phone] [varchar](15) NULL,
	[Address] [varchar](200) NULL,
 CONSTRAINT [PK_AddressBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

- **Edit local.settings.json to match your db connection**
- **Azure Function Core Tools 3**
- **Dotnet Core 3.1**