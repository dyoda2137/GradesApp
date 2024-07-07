using System;

namespace GradesApp
{
    public abstract class StudentBase : IStudent
    {
        public delegate void GradeAddedUnder2Delegate(object sender, EventArgs args);

        public event GradeAddedUnder2Delegate GradeUnder2;

        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }

        public string Surname { get; private set; }
        public abstract void AddGrade(float grade);

        public void AddGrade(double grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }

        public void AddGrade(int grade)
        {
            float value = (float)grade;
            this.AddGrade(value);
        }

        public void AddGrade(string grade)
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

        protected void CheckEventGradeUnder2()
        {
            if (GradeUnder2  != null)
            {
                GradeUnder2(this, new EventArgs());
            }
        }
    }
}