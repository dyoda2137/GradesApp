namespace GradesApp
{

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("===========================================================");
            Console.WriteLine("||             Witaj w dzienniczku ocen ucznia           ||");
            Console.WriteLine("===========================================================");

            bool CloseApp = false;


            while (!CloseApp)
            {
                Console.WriteLine(
                    "1 - Dodaj oceny ucznia do pamięci programu\n" +
                    "2 - Dodaj oceny ucznia do pliku .txt\n" +
                    "Q - zamknij aplikację\n");

                var type = Console.ReadLine().ToUpper();
                switch (type)
                {
                    case "Q":
                        {
                            CloseApp = true;
                        }
                        break;
                    case "1":
                        {
                            AddGradesToStudent(true);
                        }
                        break;
                    case "2":
                        {
                            AddGradesToStudent(false);
                        }
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa operacja");
                        continue;
                }
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby wyjść");
            Console.ReadKey();
        }

        private static void AddGradesToStudent(bool isInMemory)
        {

            string name = UserInput("Podaj imię ucznia : ");
            string surname = UserInput("Podaj nazwisko ucznia : ");
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                IStudent student = isInMemory ? new StudentInMemory(name, surname) : new StudentInFile(name, surname);
                EnterGrade(student);
                student.ShowStatistics();
            }
            else
            {
                Console.WriteLine("Imię i nazwisko nie może być puste");
            }
        }

        private static string UserInput(string input)
        {
            Console.WriteLine(input);
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Podaj ocenę od 1 do 6 dla : {student.Name} {student.Surname} ");
                var userInput = Console.ReadLine();
                if (userInput == "q" || userInput == "Q")
                {
                    break;
                }
                try
                {
                    student.AddGrade(userInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine($"Aby wyjść i pokazać statystyki {student.Name} {student.Surname} wpisz 'q'.");
                }
            }

        }
    }
}