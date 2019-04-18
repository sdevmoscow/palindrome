using Palindrome;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

#if TEST
            string len = "3";
            string ignore = "y";
            string text = "Шла Анна и слушала музыку по дороге и думала: но не реч, а черен он.";
            //string text = "А роза упала на лапу Азора";
#else
            Console.Write("Минимальная длина (>3):");
            string len = Console.ReadLine();

            Console.Write("Игнорировать регистр (y/n)?");
            string ignore = Console.ReadLine();

            Console.Write("Напишите текст:");
            string text = Console.ReadLine();
#endif

            string[] palindroms = new Detection().Find(
                    text, new SearchOptions
                    {
                        FirstOnly = false,
                        MinimumLength = Int32.Parse(len),
                        IgnoreCase = ignore.ToLower() == "y"
                    });

            if (palindroms.Length > 0)
            {
                Console.WriteLine("Найдены палиндромы:");

                foreach (string palindrom in palindroms)
                {
                    Console.WriteLine(String.Format("'{0}'", palindrom));
                }
            }
            else
            {
                Console.WriteLine("Палиндромы не обнаружены");
            }

            Console.ReadKey();
        }
    }
}
