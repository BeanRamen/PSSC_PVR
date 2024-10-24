using lab2.exemple.Models;
using System.Collections.Generic;
using System.Linq;

namespace lab2.exemple.Operations
{
    internal sealed class CalculateExamOperation : ExamOperation
    {
        internal CalculateExamOperation()
        {
        }
        protected override Exam.IExam OnValid(Exam.ValidatedExam validExamGrades)
        {
            IEnumerable<CalculatedStudentGrade> calculatedGrade = validExamGrades.GradeList
                .Select(validGrade =>
                    new CalculatedStudentGrade(
                        validGrade.StudentRegistrationNumber,
                        validGrade.ExamGrade,
                        validGrade.ActivityGrade,
                        CalculateFinalGrade(validGrade)));
            return new Exam.CalculatedExam(calculatedGrade.ToList().AsReadOnly());
        }

        private static Grade? CalculateFinalGrade(ValidatedStudentGrade validGrade)
        {
            return validGrade.ExamGrade is not null
                   && validGrade.ExamGrade.Value >= 5
                   && validGrade.ActivityGrade is not null
                   && validGrade.ActivityGrade.Value >= 5
                ? validGrade.ExamGrade + validGrade.ActivityGrade
                : null;
        }
    }
}