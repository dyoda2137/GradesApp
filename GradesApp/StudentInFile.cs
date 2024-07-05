using GradesApp;
using System.Globalization;
using System.Text;

namespace GradesApp
{
    public class StudentInFile : StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;

        //private const string fileName = "_grades.txt";
        private string fullFileName;
        public StudentInFile(string name, string surname)
            : base(name, surname)
        {
            fullFileName = $"{name}_{surname}_grades.txt";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
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

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        public override void ShowGrades()
        {
            StringBuilder sb = new StringBuilder($"{this.Name} {this.Surname} oceny: ");

            using (var reader = File.OpenText(($"{fullFileName}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        private Statistics CountStatistics(List<float> grades)
        {

            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }

    }
}