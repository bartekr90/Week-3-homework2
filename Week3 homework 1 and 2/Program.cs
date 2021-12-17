using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_homework_1_and_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now}");
            GetAppInfo();
            Console.WriteLine();
            try
            {
                Person person = new Person();
                Console.Clear();
                person.PersonIntro();

                Random ranNum = new Random();
                int correctnumber = ranNum.Next(1, 100);
                bool correctAnswer = false;
                int testCounter = 0;
                Console.WriteLine("Podaj liczbę z zakresu od 1 do 100: ");

                while (!correctAnswer)
                {
                    string input = Console.ReadLine();
                    int guess;
                    bool isNmber = int.TryParse(input, out guess);
                    if (!isNmber)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "proszę wprowadzić liczbę");
                        continue;
                    }
                    if (guess < 1 || guess > 100)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, $"proszę wprowadzić liczbę od 1 do 100");
                        continue;
                    }
                    if (guess < correctnumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź, wylosowana liczba jest większa ");
                    }
                    else if (guess > correctnumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "błędna odpowiedź, wylosowana liczba jest mniejsza ");
                    }
                    else
                    {
                        correctAnswer = true;
                        PrintColorMessage(ConsoleColor.Green, "Brawo, prawidłowa odpowiedź");
                    }
                    testCounter++;

                }
                Console.WriteLine($"Odgadłeś w {testCounter} próbie.");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Wystąpił błąd danych: " + ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie liczby";
            int appVersion = 1;
            string appAutor = "Bartosz Rachwał";
            PrintColorMessage(ConsoleColor.Magenta, $"[{appName}] Werjsa 0.0.{appVersion}, Autor: {appAutor}");
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
