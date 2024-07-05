
namespace GradesApp
{
    public abstract class StudentBase : IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;

        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }

        public string Surname { get; private set; }
        public abstract void AddGrade(float grade);

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(int grade);

        public abstract void AddGrade(string grade);

        public abstract void ShowGrades();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var statistics = GetStatistics();
            if (statistics.Count != 0)
            {
                ShowGrades();
                Console.WriteLine($"Statystyki dla {Name} {Surname}:");
                Console.WriteLine($"Ilość ocen: {statistics.Count}");
                Console.WriteLine($"Najwyższa ocena: {statistics.Max:N2}");
                Console.WriteLine($"Najniższa ocena: {statistics.Min:N2}");
                Console.WriteLine($"Średnia ocen: {statistics.Average:N2}");
                Console.WriteLine();
            }
            else 
            {
                Console.WriteLine($"Nie można wyświetlić statystyk dla {Name} {Surname} ponieważ żadna ocena nie została dodana.");
            }
        }
    }
}