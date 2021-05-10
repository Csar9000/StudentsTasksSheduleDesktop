CREATE TABLE [dbo].[Group_2](
	[GroupNum] [nvarchar](20) NOT NULL,
	[MajorName] [nvarchar](20) NULL,
	[Year_2] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Curriculum](
	[Group_2_GroupNum] [nvarchar](20) NOT NULL,
	[Subject_SubjectName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Group_2_GroupNum] ASC,
	[Subject_SubjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Curriculum]  WITH CHECK ADD FOREIGN KEY([Group_2_GroupNum])
REFERENCES [dbo].[Group_2] ([GroupNum])
GO

ALTER TABLE [dbo].[Curriculum]  WITH CHECK ADD FOREIGN KEY([Group_2_GroupNum])
REFERENCES [dbo].[Group_2] ([GroupNum])
GO

ALTER TABLE [dbo].[Curriculum]  WITH CHECK ADD FOREIGN KEY([Subject_SubjectName])
REFERENCES [dbo].[Subject] ([SubjectName])
GO

ALTER TABLE [dbo].[Curriculum]  WITH CHECK ADD FOREIGN KEY([Subject_SubjectName])
REFERENCES [dbo].[Subject] ([SubjectName])
GO


CREATE TABLE [dbo].[Student](
	[NumberOfCreditBook] [int] NOT NULL,
	[Group_2_GroupNum] [nvarchar](20) NOT NULL,
	[FIO] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumberOfCreditBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([Group_2_GroupNum])
REFERENCES [dbo].[Group_2] ([GroupNum])
GO

CREATE TABLE [dbo].[Student_has_Tasks](
	[Student_NumberOfCreditBook] [int] NOT NULL,
	[Tasks_idTaskNumber] [int] NOT NULL,
	[TaskPassDate] [date] NULL,
	[TaskGetDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Student_NumberOfCreditBook] ASC,
	[Tasks_idTaskNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student_has_Tasks]  WITH CHECK ADD FOREIGN KEY([Student_NumberOfCreditBook])
REFERENCES [dbo].[Student] ([NumberOfCreditBook])
GO

ALTER TABLE [dbo].[Student_has_Tasks]  WITH CHECK ADD FOREIGN KEY([Tasks_idTaskNumber])
REFERENCES [dbo].[Tasks] ([idTaskNumber])
GO

CREATE TABLE [dbo].[Subject](
	[SubjectName] [nvarchar](20) NOT NULL,
	[TeachersFIO] [nvarchar](20) NULL,
	[Department] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Tasks](
	[idTaskNumber] [int] NOT NULL,
	[TaskNumber] [smallint] NOT NULL,
	[Subject_SubjectName] [nvarchar](20) NOT NULL,
	[Summary] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTaskNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD FOREIGN KEY([Subject_SubjectName])
REFERENCES [dbo].[Subject] ([SubjectName])
GO