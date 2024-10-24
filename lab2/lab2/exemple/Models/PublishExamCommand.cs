using System.Collections.Generic;

namespace lab2.exemple.Models
{
    public record PublishExamCommand
    {
            public PublishExamCommand(IReadOnlyCollection<UnvalidatedStudentGrade> inputExamGrades)
            {
                InputExamGrades = inputExamGrades;
            }

            public IReadOnlyCollection<UnvalidatedStudentGrade> InputExamGrades { get; }
    }
}