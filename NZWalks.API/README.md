# Project NZWalks(WebAPI)

## 環境(Environment)
> ASP.NET Core C# 5.0
> SQLServer
> git

## 架構(Struct)
```
	+NZWalks.API					//API主層
		+BaseHelp					//共用方法
		+Controllers				//Controllers(控制層)
		+Extensions					//Startup設定層
		+ServiceModels				//資料輸出層(DTO)
		+ViewModels					//資料輸入層

	+NZWalks.Repository				//資料層
		+Migrations					//資料庫搬移
		+Models						//EntityFramework ORM, Dbcontext
		+Repository					//邏輯層
```

## NuGet安裝套件
> NZWalks.API  
> 1.microsoft.entityframeworkcore.design

> NZWalks.Repository  
> 1.microsoft.entityframeworkcore.sqlserver
> 2.microsoft.entityframeworkcore.tools

## SQL
> Create Table  
```sql
--Regions
CREATE TABLE [Information].[Regions](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Area] [float] NOT NULL,
	[Lat] [float] NOT NULL,
	[Long] [float] NOT NULL,
	[Population] [float] NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--WalkDifficulty
CREATE TABLE [Information].[WalkDifficulty](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_WalkDifficulty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--Walks
CREATE TABLE [Information].[Walks](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Length] [float] NOT NULL,
	[WalkDifficultyId] [uniqueidentifier] NOT NULL,
	[RegionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Walks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Information].[Walks]  WITH CHECK ADD  CONSTRAINT [FK_Walks_Regions] FOREIGN KEY([RegionId])
REFERENCES [Information].[Regions] ([Id])
GO

ALTER TABLE [Information].[Walks] CHECK CONSTRAINT [FK_Walks_Regions]
GO

ALTER TABLE [Information].[Walks]  WITH CHECK ADD  CONSTRAINT [FK_Walks_WalkDifficulty] FOREIGN KEY([WalkDifficultyId])
REFERENCES [Information].[WalkDifficulty] ([Id])
GO

ALTER TABLE [Information].[Walks] CHECK CONSTRAINT [FK_Walks_WalkDifficulty]
GO
```

> Datas  
```sql
INSERT INTO Information.Regions (Id, Code, Name, Area, Lat, Long, Population) 
VALUES ('b950ddf5-e9ad-47ff-9d2a-57259014fae6', 'NRTHL', 'Northland Region', 13789, -35.3708304, 172.5717825, 194600);
INSERT INTO Information.Regions (Id, Code, Name, Area, Lat, Long, Population) 
VALUES ('907f54ba-2142-4719-aef9-6230c23bd7de', 'AUCK', 'Auckland Region', 4894, -36.5253207, 173.7785704, 1718982);
INSERT INTO Information.Regions (Id, Code, Name, Area, Lat, Long, Population) 
VALUES ('79e9872d-5a2f-413e-ac36-511036ccd3d4', 'WAIK', 'Waikato Region', 8970, -37.5144584, 174.5405128, 496700);
INSERT INTO Information.Regions (Id, Code, Name, Area, Lat, Long, Population) 
VALUES ('68c2ab66-c5eb-40b6-81e0-954456d06bba', 'BAYP', 'Bay Of Plenty Region', 12230, -37.5328259, 175.7642701, 345400);



INSERT INTO Information.WalkDifficulty (Id, Code)
VALUES ('4c2b95e0-2022-4a8f-b537-eb3a32786b06', 'Easy');
INSERT INTO Information.WalkDifficulty (Id, Code)
VALUES ('a1066e97-c7c8-4aee-905b-61bb31d82bfb', 'Medium');
INSERT INTO Information.WalkDifficulty (Id, Code)
VALUES ('30f96ef9-7b45-42f7-9fab-05a70e7fc394', 'Hard');



INSERT INTO Information.Walks (Id, Name, Length, WalkDifficultyId, RegionId)
VALUES ('b950ddf5-e9ad-47ff-9d2a-57259014fae6', 'Waiotemarama Loop Track', 1.5 , 'a1066e97-c7c8-4aee-905b-61bb31d82bfb', 'b950ddf5-e9ad-47ff-9d2a-57259014fae6');
INSERT INTO Information.Walks (Id, Name, Length, WalkDifficultyId, RegionId)
VALUES ('907f54ba-2142-4719-aef9-6230c23bd7de', 'Mt Eden Volcano Walk', 2 , '4c2b95e0-2022-4a8f-b537-eb3a32786b06', '907f54ba-2142-4719-aef9-6230c23bd7de');
INSERT INTO Information.Walks (Id, Name, Length, WalkDifficultyId, RegionId)
VALUES ('79e9872d-5a2f-413e-ac36-511036ccd3d4', 'One Tree Hill Walk', 3.5 , '4c2b95e0-2022-4a8f-b537-eb3a32786b06', '907f54ba-2142-4719-aef9-6230c23bd7de');
INSERT INTO Information.Walks (Id, Name, Length, WalkDifficultyId, RegionId)
VALUES ('68c2ab66-c5eb-40b6-81e0-954456d06bba', 'Lonely Bay', 1.2 , '4c2b95e0-2022-4a8f-b537-eb3a32786b06', '79e9872d-5a2f-413e-ac36-511036ccd3d4');
INSERT INTO Information.Walks (Id, Name, Length, WalkDifficultyId, RegionId)
VALUES ('4c2b95e0-2022-4a8f-b537-eb3a32786b06', 'Mt Te Aroha To Wharawhara Track Walk', 32 , '30f96ef9-7b45-42f7-9fab-05a70e7fc394', '68c2ab66-c5eb-40b6-81e0-954456d06bba');
INSERT INTO Information.Walks (Id, Name, Length, WalkDifficultyId, RegionId)
VALUES ('a1066e97-c7c8-4aee-905b-61bb31d82bfb', 'Rainbow Mountain Reserve Walk', 3.5 , 'a1066e97-c7c8-4aee-905b-61bb31d82bfb', '68c2ab66-c5eb-40b6-81e0-954456d06bba');

```

## 參考
[DTO](https://www.telerik.com/blogs/dotnet-basics-dto-data-transfer-object)
[Migration](https://docs.microsoft.com/zh-tw/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
[Async Programming](https://docs.microsoft.com/zh-tw/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

## 使用工具
[Visual Studio 2022](https://visualstudio.microsoft.com/zh-hant/vs/)
[SourceTree](https://docs.microsoft.com/zh-tw/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
[GitHub](https://github.com/)