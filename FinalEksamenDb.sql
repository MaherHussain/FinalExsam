USE [FinalEksamenDb]
GO
/****** Object:  Table [dbo].[Bestyrelse Tb]    Script Date: 11-10-2019 09:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bestyrelse Tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MedlemName] [nvarchar](150) NOT NULL,
	[MedlemBeskrivelse] [nvarchar](2500) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[MedlemImg] [nvarchar](150) NOT NULL,
	[Fk_MedlemRole] [int] NOT NULL,
 CONSTRAINT [PK_Bestyrelse Tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BestyrelseRole]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BestyrelseRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MedlemRole] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BestyrelseRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventsTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventTitle] [nvarchar](250) NOT NULL,
	[EventDato] [datetime] NOT NULL,
	[tid] [time](4) NOT NULL,
	[Rubrik] [nvarchar](2500) NOT NULL,
	[UnderBrik] [nvarchar](2500) NOT NULL,
	[Region] [nvarchar](150) NOT NULL,
	[Distance] [float] NOT NULL,
	[PladserAntal] [int] NULL,
	[Pris] [float] NOT NULL,
	[EventImg] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_EventsTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsLetterTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsLetterTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_NewsLetterTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_RoleTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SponsLevelTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SponsLevelTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SponsLevel] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_SponsLevelTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SponsorerTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SponsorerTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SponName] [nvarchar](150) NOT NULL,
	[sponLogo] [nvarchar](150) NOT NULL,
	[Fk_Level] [int] NOT NULL,
 CONSTRAINT [PK_SponsorerTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TilmedlingTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TilmedlingTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Fk_EventId] [int] NOT NULL,
 CONSTRAINT [PK_TilmedlingTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTb]    Script Date: 11-10-2019 09:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Salt] [nvarchar](500) NOT NULL,
	[Fk_Role] [int] NOT NULL,
 CONSTRAINT [PK_UserTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bestyrelse Tb] ON 

INSERT [dbo].[Bestyrelse Tb] ([Id], [MedlemName], [MedlemBeskrivelse], [Email], [MedlemImg], [Fk_MedlemRole]) VALUES (1, N'Jens Kr. Larsen', N'Hovedbestyrelsesmøder, Modtagelse/distribution af div. post, kataloger og blade,Annoncering/tilrettelæggelse af generalforsamling, Dagsorden til bestyrelsesmøder, Planlægning af møder', N'lksd@kd.ds', N'86750287-a079-41e4-b29d-4aefa4ee9427-christian.png', 1)
INSERT [dbo].[Bestyrelse Tb] ([Id], [MedlemName], [MedlemBeskrivelse], [Email], [MedlemImg], [Fk_MedlemRole]) VALUES (2, N'Claus Jensen', N'Formandens højre hånd “stand-in”', N'ssdv@dsd.ds', N'04e76002-05c1-4660-955e-428c89dd70a9-claus.png', 2)
INSERT [dbo].[Bestyrelse Tb] ([Id], [MedlemName], [MedlemBeskrivelse], [Email], [MedlemImg], [Fk_MedlemRole]) VALUES (3, N'Jens Nielsen', N'Skriver referat af alle møder og sørger for udsendelse inden 8 dage ,Protokolføring ,Ajourføring af adresseliste over instruktører/bestyrelsesmedlemmer ,Udsendelse af mødeindkaldelser 
', N'zcaca@sds.ds', N'9815e887-c7f3-4ebf-a52a-5a25be4d2f50-jens.png', 3)
INSERT [dbo].[Bestyrelse Tb] ([Id], [MedlemName], [MedlemBeskrivelse], [Email], [MedlemImg], [Fk_MedlemRole]) VALUES (4, N'Jørgen Svensen', N'Lønregnskab + udbetaling af løn Betaling af udgifter Bogføring af indtægter og udgifter Årsregnskab Revisorkontakt Løbende kontrol med økonomien Told og Skat
', N'sdvdv@ddc.ss', N'f6e74c7b-ae7c-4463-8a6e-564349a25b2f-joergen.png', 4)
INSERT [dbo].[Bestyrelse Tb] ([Id], [MedlemName], [MedlemBeskrivelse], [Email], [MedlemImg], [Fk_MedlemRole]) VALUES (5, N'Karen Karlsen', N'Bestyrelsesmedlem', N'asvsd@sds.ds', N'eb14d701-68ea-47d4-b1fe-2520200c45db-karen.png', 5)
INSERT [dbo].[Bestyrelse Tb] ([Id], [MedlemName], [MedlemBeskrivelse], [Email], [MedlemImg], [Fk_MedlemRole]) VALUES (6, N'Lene Johansen', N'Bestyrelsesmedlem
', N'svsaa@sdfs.ds', N'd19578f9-55b0-46c1-a33b-d1ad8e87a57b-lene.png', 5)
SET IDENTITY_INSERT [dbo].[Bestyrelse Tb] OFF
SET IDENTITY_INSERT [dbo].[BestyrelseRole] ON 

INSERT [dbo].[BestyrelseRole] ([Id], [MedlemRole]) VALUES (1, N'Formand')
INSERT [dbo].[BestyrelseRole] ([Id], [MedlemRole]) VALUES (2, N'Næste formand')
INSERT [dbo].[BestyrelseRole] ([Id], [MedlemRole]) VALUES (3, N'Sekretær')
INSERT [dbo].[BestyrelseRole] ([Id], [MedlemRole]) VALUES (4, N'Kasserer')
INSERT [dbo].[BestyrelseRole] ([Id], [MedlemRole]) VALUES (5, N'BestyrelseMedlem')
SET IDENTITY_INSERT [dbo].[BestyrelseRole] OFF
SET IDENTITY_INSERT [dbo].[EventsTb] ON 

INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (1, N'FOREST to THE BAY', CAST(N'2019-10-28T10:40:00.000' AS DateTime), CAST(N'10:40:00' AS Time), N'KOM med til det mest fantastiske løb i GateWay Blokhus i Påsken! Du kommer til at løbe i det smukkeste og mest afvekslende løbeterræn i vel nok Danmarks bedste GateWay ', N' - vi garanterer, at du kan boltre dig i skovområder, ad snoede stier og på den smukke hvide strand på de lange distancer! Ta´ gerne familien med ud og løbe! Lad børnene boltre sig på den store naturlegeplads når de har løbet og mens du selv løber. Naturlegepladsen ligger i forlængelse af stævneområdet i skovens kuperede terræn og under susende trækroner!', N'Nordjylland', 5.4, 68, 250, N'e2c093a5-6b1f-48d8-8de9-dee05f03b7a4-FOREST to THE BAY.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (2, N'Egå Engsø Løbet', CAST(N'2019-10-28T16:30:00.000' AS DateTime), CAST(N'16:30:00' AS Time), N'Løb rundt om den smukke Egå Engsø påskemandag 28. marts 2016. Motionsløb for hygge- og hurtigløbere mulighed for PR!', N' Familievenligt løb med påskeæg til de første 150 børn under 15 år over målstregen Elektronisk tidtagning Gratis buff tube til alle voksne tilmeldte', N'Midtjylland', 10, 30, 100, N'dec069e2-5967-4eb7-92a0-987d17acec07-Egå Engsø Løbet.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (3, N'Ultraløbet Fyr til Fyr', CAST(N'2019-10-09T09:00:00.000' AS DateTime), CAST(N'09:00:00' AS Time), N'Danmarks smukkeste ultraløb på langs af Bornholm går fra Dueodde Fyr i syd til målet ved Hammer Fyr på øens nordende.', N'Undervejs kommer løberne forbi Svaneke Fyr og Hammerodde Fyr samt de to depoter i Svaneke og Gudhjem. Ruten på 60 km følger den gamle redningssti langs med østkysten.', N'Fyn', 60, 50, 350, N'49450c17-8570-44c4-a2d2-39f504c14a59-Ultraløbet Fyr til Fyr.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (4, N'Skov løbet Skanderborg', CAST(N'2019-10-10T13:00:00.000' AS DateTime), CAST(N'13:00:00' AS Time), N'Igen i år indbyder Skanderborg Løbeklub til en smuk og varieret løbetur på 7,5 km i Vestermølleskoven og Skvæt skoven søndag 10. april.', N' En del af ruten løbes på smalle stier, skrappe stigninger og trapper og løberne kan blandt andet prøve kræfter med udfordringerne ', N'Midjylland', 7.5, 22, 80, N'b85eeeff-8294-4acc-a782-5b126ee506ab-Skov løbet Skanderborg.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (5, N'Smid tøjet løbet', CAST(N'2019-11-16T10:00:00.000' AS DateTime), CAST(N'10:00:00' AS Time), N'Nu kan du løbe og komme af med dit aflagte tøj ved at donere det til en god sag. Samtidig får du en dag fuld af god musik, ', N'forplejning og er omringet af andre glade Smid Tøjet Løbere. Smid Tøjet Løbet er et nyt koncept, som giver dig det sunde, det sjove og det meningsfulde på én gang. Vi skaber en festlig anledning til en helt ny måde at donere tøj på til Røde Kors. ', N'Midjylland', 5, 35, 250, N'4a7138e6-1fbf-490e-8bde-6576d9fe75ba-Smid tøjet løbet.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (6, N'Nike Marathontest 4', CAST(N'2019-11-17T09:30:00.000' AS DateTime), CAST(N'09:30:00' AS Time), N'Nike Marathontest 4 er det sidste af de fire testløb frem mod Telenor Copenhagen Marathon.', N' Det er samtidig et almindeligt motionsløb på 21,1 km for alle, der har lyst.', N'Sjælland', 21.1, 120, 180, N'9cc4da6d-2113-45b3-92c8-a69fd70cd1d7-Nike Marathontest 4.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (7, N'VUC Vesterskovsløbet', CAST(N'2019-11-05T12:45:00.000' AS DateTime), CAST(N'12:45:00' AS Time), N'VUC Vesterskovsløbet er et løb for alle. Ruterne ligger i skøn natur og by- og havnemiljø, ', N'og deltagernes udgangspunkt spænder lige fra personer som aldrig har løbet før, og til eliteløberen, børn og gamle. Samtidig er der masser af liv i målområdet, både før og efter løbet.', N'Sydjylland', 5.7, 20, 112, N'd620efba-550f-488d-954f-fb7db18c8482-VUC Vesterskovsløbet.JPG')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (8, N'Eventyrløbet', CAST(N'2019-12-05T16:00:00.000' AS DateTime), CAST(N'16:00:00' AS Time), N'I år afholder vi Eventyrløbet for 39. gang, og tilmeldingen til årets løb er nu åben Husk at du med et startnummer ', N'også er inviteret til stor dobbeltkoncert i Kastegården med Joey Moe og Michael Hardinger Band efter løbet.', N'Fyn', 21.1, 30, 115, N'4ddc010a-1893-4467-ad40-3617c6201b64-Eventyrløbet.jpg')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (9, N'Firkløver 50/50', CAST(N'2019-12-15T12:00:00.000' AS DateTime), CAST(N'12:00:00' AS Time), N'Trail i Kongernes Nordsjælland Ultraløb & Trail - Fra brostens pavéer fra renaissancen til fede singletrack i tæt skov over bølgende overdrev, ', N'søer og strand - du får ikke et flottere, hårdere og sammenhængende spor i den kommende Nationalpark Kongernes Nordsjælland. ', N'Sjælland', 50, 15, 500, N'c79f04d3-6fba-4e2e-9e83-9808e37ca292-Firkløver 50 50.JPG')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (10, N'BESTSELLER Aarhus City', CAST(N'2020-02-19T11:00:00.000' AS DateTime), CAST(N'11:00:00' AS Time), N'Mærk magien når Aarhus for en enkelt dag bliver forvandlet til et inferno af feststemte motionister,  glæde og underholdning.', N' Søndag d. 19 juni 2016, klæder Aarhus sig endnu engang på til fest. Datoen ligger nu fast, og for femte gang byder Aarhus Motion velkommen til 21,097 hæsblæsende kilometer, fyldt med underholdning og gode oplevelser.', N'Midtjylland', 21.1, 1200, 850, N'73b33e13-30a9-4cca-af25-add3994eb9e5-BESTSELLER Aarhus City Marathon.JPG')
INSERT [dbo].[EventsTb] ([Id], [EventTitle], [EventDato], [tid], [Rubrik], [UnderBrik], [Region], [Distance], [PladserAntal], [Pris], [EventImg]) VALUES (11, N'Aalborg Halvmarathon', CAST(N'2020-03-26T14:00:00.000' AS DateTime), CAST(N'14:00:00' AS Time), N'DGI Nordjylland og løbeklubberne AMOK, Aalborg Atletik & Motion og Aalborg Øst Road Runners,', N' har samlet kræfterne og al vores viden om løb for at skabe Nordjyllands største og bedste motionsløb Vi har nemlig fået lov til at åbne Limfjordstunellen op for første gang siden 1969 - og dermed er Aalborg Halvmarathon Danmarks eneste motionsløb, hvor du løber under vandet.', N'Nordjylland', 21.1, 560, 450, N'8efc460b-43cd-47ae-9cbf-725690c18beb-Aalborg Halvmarathon.jpg')
SET IDENTITY_INSERT [dbo].[EventsTb] OFF
SET IDENTITY_INSERT [dbo].[NewsLetterTb] ON 

INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (1, N'maherhssain6@gmail.com')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (2, N'masdas@kad.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (3, N'skjdk@lsd.ss')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (4, N'sjfkjf@lskdd.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (5, N'ljsnda@lkd.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (6, N'lkzdn@kdms.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (7, N'khascskd@lkdkl.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (8, N'kdkvs@ksd.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (9, N'ljsjflej@ksd.ds')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (10, N'kjdd@xn--ls-1ia.sd')
INSERT [dbo].[NewsLetterTb] ([Id], [Email]) VALUES (11, N'ma@videndjurs.dk')
SET IDENTITY_INSERT [dbo].[NewsLetterTb] OFF
SET IDENTITY_INSERT [dbo].[RoleTb] ON 

INSERT [dbo].[RoleTb] ([Id], [Role]) VALUES (1, N'Admin')
INSERT [dbo].[RoleTb] ([Id], [Role]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[RoleTb] OFF
SET IDENTITY_INSERT [dbo].[SponsLevelTb] ON 

INSERT [dbo].[SponsLevelTb] ([Id], [SponsLevel]) VALUES (1, N'GULD SPONSORE')
INSERT [dbo].[SponsLevelTb] ([Id], [SponsLevel]) VALUES (2, N'SØLV SPONSORE')
INSERT [dbo].[SponsLevelTb] ([Id], [SponsLevel]) VALUES (3, N'ALMENLIGE PARTNERE')
SET IDENTITY_INSERT [dbo].[SponsLevelTb] OFF
SET IDENTITY_INSERT [dbo].[SponsorerTb] ON 

INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (1, N'Hummel', N'e711e206-23d8-403a-9b4a-8bb3b399126e-hummel-logo.jpg', 1)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (2, N'Coca Cola', N'31311f3b-55ec-4074-b8b3-6363c3f948ab-coca-cola-logo.jpg', 1)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (3, N'Nike', N'056bd131-fc7a-4348-ab06-d861a5f4fc4f-Nike.png', 1)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (4, N'Smuk Fest', N'1ab8f24d-9a08-4a96-9cd5-279c2621fb2c-Smukfest.jpg', 1)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (5, N'Fanta', N'3cf3c94d-f01a-44b9-b4d4-8fb9ed626b2f-Fanta.png', 2)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (6, N'Intel', N'59a6c494-7835-437b-b1f5-cfa99a2c6c61-Intel.png', 2)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (7, N'Vikan', N'85e5d056-88b3-4079-9103-b4f016b0cc11-Vikan.jpg', 2)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (8, N'Adidas', N'50b5f150-b788-4fab-8612-20c2c5ed25fd-adidas-logo.jpg', 2)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (9, N'7 up', N'bc4c6adb-4eab-43ca-adbb-5f2981c86670-7up.png', 2)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (10, N'Pepsi', N'070b5c48-6f34-49ac-b4fb-1485a1dad8c2-Pepsi.jpg', 2)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (11, N'Circle', N'32749fd1-4dd4-4b5a-af31-baa590fc329f-Circle.jpg', 3)
INSERT [dbo].[SponsorerTb] ([Id], [SponName], [sponLogo], [Fk_Level]) VALUES (12, N'LG', N'54e140d2-cd28-4366-8b32-20026cabc26e-Lg.png', 3)
SET IDENTITY_INSERT [dbo].[SponsorerTb] OFF
SET IDENTITY_INSERT [dbo].[TilmedlingTb] ON 

INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (1002, N'lsdn@kds.ds', 1)
INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (1003, N'sdbccd@kjd.dk', 1)
INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (1004, N'kdsksd@lsds.dk', 1)
INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (1005, N'jkasj@lja.ds', 1)
INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (2002, N'ma@videndjurs.dk', 1)
INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (2003, N'maherhussain6@gmail.com', 1)
INSERT [dbo].[TilmedlingTb] ([Id], [Email], [Fk_EventId]) VALUES (2004, N'maherhussain6@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[TilmedlingTb] OFF
SET IDENTITY_INSERT [dbo].[UserTb] ON 

INSERT [dbo].[UserTb] ([Id], [UserName], [Password], [Salt], [Fk_Role]) VALUES (1, N'Maher', N'BZImkgGSoprtPH9OnBncLnvESCSKGjWFL4v0XHw0k3I=', N'iAEcXXlilfKX3ovh', 1)
INSERT [dbo].[UserTb] ([Id], [UserName], [Password], [Salt], [Fk_Role]) VALUES (2, N'hussain', N'8z7WKK2ns75dKhWb6Z0pe13KSLow3Ok0leG+jJ6U3yI=', N'iK1cU+PXT9K8FOyl', 1)
SET IDENTITY_INSERT [dbo].[UserTb] OFF
ALTER TABLE [dbo].[Bestyrelse Tb]  WITH CHECK ADD  CONSTRAINT [FK_Bestyrelse Tb_BestyrelseRole] FOREIGN KEY([Fk_MedlemRole])
REFERENCES [dbo].[BestyrelseRole] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bestyrelse Tb] CHECK CONSTRAINT [FK_Bestyrelse Tb_BestyrelseRole]
GO
ALTER TABLE [dbo].[SponsorerTb]  WITH CHECK ADD  CONSTRAINT [FK_SponsorerTb_SponsLevelTb] FOREIGN KEY([Fk_Level])
REFERENCES [dbo].[SponsLevelTb] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SponsorerTb] CHECK CONSTRAINT [FK_SponsorerTb_SponsLevelTb]
GO
ALTER TABLE [dbo].[TilmedlingTb]  WITH CHECK ADD  CONSTRAINT [FK_TilmedlingTb_EventsTb] FOREIGN KEY([Fk_EventId])
REFERENCES [dbo].[EventsTb] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TilmedlingTb] CHECK CONSTRAINT [FK_TilmedlingTb_EventsTb]
GO
ALTER TABLE [dbo].[UserTb]  WITH CHECK ADD  CONSTRAINT [FK_UserTb_RoleTb] FOREIGN KEY([Fk_Role])
REFERENCES [dbo].[RoleTb] ([Id])
GO
ALTER TABLE [dbo].[UserTb] CHECK CONSTRAINT [FK_UserTb_RoleTb]
GO
