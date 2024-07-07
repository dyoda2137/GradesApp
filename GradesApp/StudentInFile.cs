using System.Text;

namespace GradesApp
{
    public class StudentInFile : StudentBase
    {        
        private const string fileName = "_grades.txt";
        private string fullFileName;

        public StudentInFile(string name, string surname)
            : base(name, surname)
        {
            fullFileName = $"{name}_{surname}{fileName}";
        }

        public override void AddGrade(float grade)
        {
            if (grade > 0 && grade <= 6)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(grade);
                    if (grade < 2)
                    {
                        CheckEventGradeUnder2();
                    }
                }
            }
            else
            {
                throw new Exception("Ocena musi byc w przedziale 1 do 6");
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