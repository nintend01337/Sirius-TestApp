CREATE DATABASE employee;

USE employee;

CREATE TABLE [dbo].[STATUS](
	[id] [INT] IDENTITY(1,1) NOT NULL,
	[NAME] [VARCHAR](100) NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[posts](
	[id] [INT] IDENTITY(1,1) NOT NULL,
	[NAME] [VARCHAR](100) NOT NULL,
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[deps](
	[id] [INT] IDENTITY(1,1) NOT NULL,
	[NAME] [VARCHAR](100) NOT NULL,
 CONSTRAINT [PK_deps] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[persons](
	[id] [INT] IDENTITY(1,1) NOT NULL,
	[first_name] [VARCHAR](100) NOT NULL,
	[second_name] [VARCHAR](100) NOT NULL,
	[last_name] [VARCHAR](100) NOT NULL,
	[date_employ] [DATETIME] NULL,
	[date_uneploy] [DATETIME] NULL,
	[STATUS] [INT] NOT NULL,
	[id_dep] [INT] NOT NULL,
	[id_post] [INT] NOT NULL,
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]