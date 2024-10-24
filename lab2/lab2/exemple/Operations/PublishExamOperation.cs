using lab2.exemple.Models;
using System;
using System.Text;

namespace lab2.exemple.Operations
{
    internal sealed class PublishExamOperation : ExamOperation
    {
        protected override Exam.IExam OnCalculated(Exam.CalculatedExam calculatedExam)
        {
            StringBuilder csv = new();
            calculatedExam.GradeList.Aggregate(csv, (export, grade) =>
                export.AppendLine(GenerateCsvLine(grade)));

            Exam.PublishedExam publishedExamGrades = new(calculatedExam.GradeList, csv.ToString(), DateTime.Now);
            return publishedExamGrades;
        }

        private static string GenerateCsvLine(CalculatedStudentGrade grade) =>
            $"{grade.StudentRegistrationNumber.Value}, {grade.ExamGrade}, {grade.ActivityGrade}, {grade.FinalGrade}";
    }
}