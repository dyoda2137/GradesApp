using System.Text;

namespace GradesApp
{
    public class StudentInMemory : StudentBase
    {
        
        private List<float> grades = new List<float>();
        public StudentInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade > 0 && grade <= 6)
            {
                grades.Add(grade);
                if (grade < 2)
                {
                    CheckEventGradeUnder2();
                }
            }
            else 
            {
                throw new Exception("BŁĄD : Ocena musi byc w przedziale 1 do 6");
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
