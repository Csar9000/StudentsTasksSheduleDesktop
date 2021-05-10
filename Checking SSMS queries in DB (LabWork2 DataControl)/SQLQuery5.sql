-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TaskOne] 
@GroupNum int,
@StudentsFromGroup varchar(20),
@IdTasks int,
@Subjects varchar(20),
@CountOfTasks int
AS
set @StudentsFromGroup = (Select Group_2_GroupNum,NumberOfCreditBook  FROM Student  WHERE Group_2_GroupNum = @GroupNum)
Set @IdTasks = (SELECT Tasks_idTaskNumber FROM Student_has_Tasks where Student_NumberOfCreditBook = @StudentsFromGroup)
Set @Subjects = (SELECT Subject_SubjectName FROM Tasks Where idTaskNumber = @IdTasks)
Set @CountOfTasks = (SELECT COUNT(Tasks_idTaskNumber) FROM Student_has_Tasks where Student_NumberOfCreditBook = @StudentsFromGroup)

Select @StudentsFromGroup, @IdTasks,@Subjects,@CountOfTasks
GO
