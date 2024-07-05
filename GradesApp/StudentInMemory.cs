
using GradesApp;
using System.Text;

namespace GradesApp
{
    public class StudentInMemory : StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;

        private List<float> grades = new List<float>();
        public StudentInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else if (grade < 1)
            {
                throw new Exception("Ocena nie może być mniejsza od 1");
            }
            else if (grade > 6)
            {
                throw new Exception("Ocena nie może być większa od 6");
            }
        }

        public override void AddGrade(double grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }

        public override void AddGrade(int grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }

        

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else if (char.TryParse(grade, out char charResult))
            {
                this.AddGrade(charResult);
            }
            else
            {
                throw new Exception($"Ocena: {grade} jest nieprawidłowa");
            }
        }

        public override void ShowGrades()
        {
            StringBuilder sb = new StringBuilder($"{this.Name} {this.Surname} oceny: ");
            for (int i = 0; i < grades.Count; i++)
            {
                if (i == grades.Count - 1)
                {
                    sb.Append($"{grades[i]}.");
                }
                else
                {
                    sb.Append($"{grades[i]}; ");
                }
            }
            Console.WriteLine($"\n{sb}");
        }


        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}
