using System.Numerics;

namespace FibonacciFinder
{
    internal class Program
    {
        static string GetNumberWithSuffix(BigInteger num)
        {
            string suffix = "";
            int lastDigit = (int)(num % 10);

            switch (lastDigit)
            {
                case 0: suffix = "th"; break;
                case 1: suffix = "st"; break;
                case 2: suffix = "nd"; break;
                case 3: suffix = "th"; break;
                case 4: suffix = "th"; break;
                case 5: suffix = "th"; break;
                case 6: suffix = "th"; break;
                case 7: suffix = "th"; break;
                case 8: suffix = "th"; break;
                case 9: suffix = "th"; break;
            }

            return num + suffix;
        }


        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a number to find, this is the index number not the total value (ex: \"the \"21\"st number in the sequence\") then press \"Enter\".");
            string input = Console.ReadLine();
            if (input != "")
            {
                int number = 0;
                int.TryParse(input, out number);
                if (number <= 0)
                {
                    Console.WriteLine("Unable to read number, was it perhaps to large or incorrectly formatted?");
                }
                else
                {
                    if (number >= 99999)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!WARNING!");
                        Console.WriteLine("This program is written to handle complex mathematics but this requires quite a lot of power, it specifically requires a lot of system memory to handle these large numbers.");
                        Console.WriteLine("Continuing with this may draw a significant amount of memory, continuing without this can cause issues and you and only you are responsible for the outcome.");
                        Console.WriteLine("This may also take some time to complete.");
                        Console.WriteLine("Would you like to contine? (\"Enter\" = Yes | Any Key = No)");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (Console.ReadKey().Key != ConsoleKey.Enter)
                        {
                            Start();
                        }
                    }
                    else if (number >= 9999)
                    {
                        Console.WriteLine("It may take some time to do these calculations.");
                        Console.WriteLine("Would you like to contine? (\"Enter\" = Yes | Any Key = No)");
                        if (Console.ReadKey().Key != ConsoleKey.Enter)
                        {
                            Start();
                        }
                    }

                    Console.WriteLine();
                    FindInSequence(number);
                }
                Start();
            }
        }

        static async void FindInSequence(BigInteger numToFind)
        {
            if (numToFind < 4)
            {
                if (numToFind == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("The 1st number is: 0");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("The " + GetNumberWithSuffix(numToFind) + " number is: 1");
                }
   
            }
            else
            {
                BigInteger number = numToFind - 1;

                List<BigInteger> Fib = new List<BigInteger>();
                Fib.Add(0);
                Console.WriteLine("Value 1: 0");
                Fib.Add(1);
                Console.WriteLine("Value 2: 1");
                Fib.Add(1);
                Console.WriteLine("Value 3: 1");

                for (BigInteger i = 2; i <= number; i++)
                {
                    BigInteger lastInt1 = Fib.Last();
                    BigInteger lastInt2 = Fib[Fib.Count - 2];
                    Fib.Add(lastInt1 + lastInt2);

                    if (Fib.Last().ToString().Length > 165) Console.WriteLine(String.Format("{0:n0}", i) + " / " + String.Format("{0:n0}", numToFind) + " : (too long to display *" + Fib.Last().ToString().Length + " chars*)");
                    else Console.WriteLine(String.Format("{0:n0}", i) + "/" + String.Format("{0:n0}", numToFind) + " : " + String.Format("{0:n0}", Fib.Last()));
                }

                Console.WriteLine();
                Console.WriteLine("The " + GetNumberWithSuffix(numToFind) + " number is: " + String.Format("{0:n0}", Fib.Last()));
            }
        }
    }
}