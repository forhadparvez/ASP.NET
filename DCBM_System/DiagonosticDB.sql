USE [Diagnostic_DB]
GO
/****** Object:  Table [dbo].[TestTypeSetup]    Script Date: 01/26/2017 18:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypeSetup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_TestTypeSetup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TestTypeSetup] ON
INSERT [dbo].[TestTypeSetup] ([ID], [TypeName]) VALUES (1, N'Blood')
INSERT [dbo].[TestTypeSetup] ([ID], [TypeName]) VALUES (2, N'Urine')
INSERT [dbo].[TestTypeSetup] ([ID], [TypeName]) VALUES (3, N'ECG')
INSERT [dbo].[TestTypeSetup] ([ID], [TypeName]) VALUES (4, N'X-Ray')
SET IDENTITY_INSERT [dbo].[TestTypeSetup] OFF
/****** Object:  Table [dbo].[TestSetup]    Script Date: 01/26/2017 18:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestSetup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nvarchar](50) NULL,
	[Fee] [decimal](18, 2) NULL,
	[TestTypeID] [int] NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TestSetup] ON
INSERT [dbo].[TestSetup] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (1, N'abdomen', CAST(300.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[TestSetup] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (2, N'pregnancy profile', CAST(1000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[TestSetup] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (3, N'Urine C/S-200', CAST(500.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[TestSetup] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (4, N'X-Ray LS Spine', CAST(250.00 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[TestSetup] OFF
/****** Object:  Table [dbo].[TestRequestMst]    Script Date: 01/26/2017 18:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestRequestMst](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [nvarchar](10) NULL,
	[PatientName] [nvarchar](100) NULL,
	[DOB] [date] NULL,
	[Mobile] [nvarchar](15) NULL,
	[AddDate] [date] NULL,
 CONSTRAINT [PK_TestRequestMst] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TestRequestMst] ON
INSERT [dbo].[TestRequestMst] ([ID], [PatientID], [PatientName], [DOB], [Mobile], [AddDate]) VALUES (1, N'P-001', N'Rakibul hasan', CAST(0x4B3C0B00 AS Date), N'01671657952', CAST(0x623C0B00 AS Date))
INSERT [dbo].[TestRequestMst] ([ID], [PatientID], [PatientName], [DOB], [Mobile], [AddDate]) VALUES (3, N'P-002', N'Sonowar Hossain', CAST(0x523C0B00 AS Date), N'01874832', CAST(0x623C0B00 AS Date))
INSERT [dbo].[TestRequestMst] ([ID], [PatientID], [PatientName], [DOB], [Mobile], [AddDate]) VALUES (4, N'P-003', N'Sonowar Hossain', CAST(0x523C0B00 AS Date), N'01874832', CAST(0x623C0B00 AS Date))
INSERT [dbo].[TestRequestMst] ([ID], [PatientID], [PatientName], [DOB], [Mobile], [AddDate]) VALUES (5, N'P-004', N'Md.Sojol Shekh', CAST(0x603C0B00 AS Date), N'01737354456', CAST(0x623C0B00 AS Date))
INSERT [dbo].[TestRequestMst] ([ID], [PatientID], [PatientName], [DOB], [Mobile], [AddDate]) VALUES (6, N'P-005', N'Monowar Hossain', CAST(0x4B3C0B00 AS Date), N'01671657952', CAST(0x623C0B00 AS Date))
SET IDENTITY_INSERT [dbo].[TestRequestMst] OFF
/****** Object:  Table [dbo].[TestRequestDtls]    Script Date: 01/26/2017 18:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestRequestDtls](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MstID] [int] NULL,
	[TestID] [int] NULL,
	[Fee] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TestRequestDtls] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TestRequestDtls] ON
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (1, 1, 1, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (2, 1, 4, CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (5, 3, 1, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (6, 4, 1, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (7, 5, 4, CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (8, 5, 3, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (9, 6, 1, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[TestRequestDtls] ([ID], [MstID], [TestID], [Fee]) VALUES (10, 6, 3, CAST(500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TestRequestDtls] OFF
/****** Object:  Table [dbo].[Payment]    Script Date: 01/26/2017 18:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NULL,
	[PayAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Payment] ON
INSERT [dbo].[Payment] ([ID], [PatientID], [PayAmount]) VALUES (1, 1, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([ID], [PatientID], [PayAmount]) VALUES (2, 1, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([ID], [PatientID], [PayAmount]) VALUES (3, 5, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([ID], [PatientID], [PayAmount]) VALUES (4, 6, CAST(600.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Payment] OFF
