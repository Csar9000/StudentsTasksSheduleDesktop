CREATE TABLE [dbo].[CurriculumComplex](
	[Group_2_GroupNum] [nvarchar](20) NOT NULL,
	[Subject_SubjectName] [nvarchar](20) NOT NULL,
	[MajorName] [nvarchar](20) NULL,
	[Year_2] [date] NULL,
	[TeachersFIO] [nvarchar](20) NULL,
	[Department] [nvarchar](50) NULL,
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
