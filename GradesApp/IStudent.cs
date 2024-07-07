using static GradesApp.StudentBase;

namespace GradesApp
{
    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }

        void AddGrade(float grade);
        void AddGrade(double grade);
        void AddGrade(int grade);
        void AddGrade(string grade);

        event GradeAddedUnder2Delegate GradeUnder2;

        Statistics GetStatistics();

        void ShowGrades();

        void ShowStatistics();
    }
}