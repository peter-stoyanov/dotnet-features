
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class LocalFunctionCommand : BaseCommand
    {
        protected override bool isActive => false;
        public LocalFunctionCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            LocalVoidFunctions();

            PrintStudentMarks(
            101,
            new Subject
            {
                SubjectName = "Math",
                Marks = 96
            }, new Subject
            {
                SubjectName = "physics",
                Marks = 88
            }, new Subject
            {
                SubjectName = "Chem",
                Marks = 91
            });

            return CommandResult.Success;
        }

        private void LocalVoidFunctions()
        {
            void Add(int x, int y)
            {
                UI.WriteMessage($"Sum of {x} and {y} is : {x + y}");
            }

            void Multiply(int x, int y)
            {
                UI.WriteMessage($"Multiply of {x} and {y} is : {x * y}");
                Add(30, 10);
            }

            Add(20, 50);
            Multiply(20, 50);
        }

        public void PrintStudentMarks(int studentId, params Subject[] subjects)
        {
            UI.WriteMessage($"Student Id {studentId} Total Marks: {CalculateMarks()}");
            UI.WriteMessage($"Subject wise marks");

            foreach (var subject in subjects)
            {
                UI.WriteMessage($"Subject Name: {subject.SubjectName} \t Marks: {subject.Marks}");
            }

            decimal CalculateMarks()
            {
                decimal totalMarks = 0;
                foreach (var subject in subjects)
                {
                    totalMarks += subject.Marks;
                }
                return totalMarks;
            }
        }
        public class Subject
        {
            public string SubjectName
            {
                get;
                set;
            }
            public decimal Marks
            {
                get;
                set;
            }
        }
    }
}