using lab2.exemple.Models;
using lab2.exemple.Operations;
using System;
using static lab2.exemple.Models.ExamPublishedEvent;

namespace Examples.Domain.Workflows
{
    public class PublishExamWorkflow
    {
        public IExamPublishedEvent Execute(PublishExamCommand command, Func<StudentRegistrationNumber, bool> checkStudentExists)
        {
            Exam.UnvalidatedExam unvalidatedGrades = new(command.InputExamGrades);

            Exam.IExam exam = new ValidateExamOperation(checkStudentExists).Transform(unvalidatedGrades);
            exam = new CalculateExamOperation().Transform(exam);
            exam = new PublishExamOperation().Transform(exam);

            return exam.ToEvent();
        }
    }
}