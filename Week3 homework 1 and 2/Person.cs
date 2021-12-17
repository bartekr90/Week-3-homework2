using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_homework_1_and_2
{
    class Person
    {
        private DateTime ageOfPerson;
        private string nameOfPerson;
        private string placeOfbirth;

        /// <summary>
        /// Creates new user.
        /// </summary>
        public Person()
        {
            this.PersonSetup();
        }
        private void PersonSetup()
        {
            Console.WriteLine(@"Podaj swoje imię (nie więcej niż 25 znaków, nie używaj następujących znaków: '*', ' ', '\'' oraz cyfr): ");
            string name = NameValidation(InputLimitation());

            Console.WriteLine(@"Podaj miejsce urodzenia(nie więcej niż 25 znaków, nie używaj następujących znaków: '*', ' ', '\''): ");
            string place = NameValidation(InputLimitation());

            Console.WriteLine("Podaj miesiąc swoich urodzin (wartości z przedziału 1-12): ");
            int month = DateValidation(Console.ReadLine(), 1, 12);

            var currentYear = DateTime.Now.Year;
            Console.WriteLine("Podaj rok swoich urodzin (dopuszczalny wiek od 4 do 120 lat): ");
            int year = DateValidation(Console.ReadLine(), (currentYear - 120), (currentYear - 4));

            Console.WriteLine($"Podaj dzień miesiąca swoich urodzin (wartości od 1 do {DateTime.DaysInMonth(year, month)}: ");
            int day = DateValidation(Console.ReadLine(), 1, DateTime.DaysInMonth(year, month));

            this.nameOfPerson = name;
            this.placeOfbirth = place;
            this.ageOfPerson = new DateTime(year, month, day);
        }
        public void PersonIntro()
        {
            var age = DateTime.Now.Year - this.ageOfPerson.Year;
            if (DateTime.Now.DayOfYear < this.ageOfPerson.DayOfYear)
                age--;

            Console.Write("Cześć ");
            PrintColorMessage(ConsoleColor.Blue, this.nameOfPerson);
            Console.Write(", urodziłeś się w ");
            PrintColorMessage(ConsoleColor.DarkGreen, this.placeOfbirth);
            Console.Write(", Twoja data urodzin: ");
            PrintColorMessage(ConsoleColor.DarkRed, $"{ageOfPerson.Date}");
            Console.Write(", a Twój wiek to: ");
            PrintColorMessage(ConsoleColor.DarkYellow, $"{age}");
            Console.WriteLine();
        }
        private static int DateValidation(string value, int min, int max)
        {
            while (true)
            {
                if (!int.TryParse(value, out int nr))
                {
                    Console.WriteLine("błędna data urodzenia, podana wartość prawdopodobnie nie jest liczbą");
                    value = Console.ReadLine();
                    continue;
                }
                if (!((nr >= min) && (nr <= max)))
                {
                    Console.WriteLine("Wiek nie spełnia wymagań, wartości są spoza zakresu");
                    value = Console.ReadLine();
                    continue;
                }
                return nr;
            }
        }
        private static string NameValidation(string str)
        {
            char[] charsToTrim = { '*', ' ', '\'', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            string name = str.Trim(charsToTrim);

            if (String.IsNullOrEmpty(name))
                throw new Exception("Nie podano imienia!");

            return name;
        }

        private static string InputLimitation()
        {
            StringBuilder sb = new StringBuilder();
            bool loop = true;
            while (loop)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // won't show up in console
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            loop = false;
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            if (sb.Length < 25)
                            {
                                sb.Append(keyInfo.KeyChar);
                                Console.Write(keyInfo.KeyChar);
                            }
                            break;
                        }
                }
            }
            return sb.ToString();
        }

        private static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
