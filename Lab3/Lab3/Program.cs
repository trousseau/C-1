using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = string.Empty;

            while (choice != "q" && choice != "Q")
            {
                Console.WriteLine();
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine(" A. Making change");
                Console.WriteLine(" B. Counting letters");
                Console.WriteLine(" C. Number guessing game");
                Console.WriteLine(" Q. Quit");
                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "A":
                    case "a":
                        MakingChange();
                        break;
                    case "B":
                    case "b":
                        CountingLetters();
                        break;
                    case "C":
                    case "c":
                        NumberGuessingGame();
                        break;
                    default:
                        break;
                }
            }
        }

        #region MakingChange
        private static void MakingChange()
        {
            decimal due = 0;
            decimal paid = 0;
            bool isPaidCorrect = false;
            bool isDueCorrect = false;

            while (isPaidCorrect != true && isDueCorrect != true)
            {
                Console.Write("Enter amount due: ");
                string dueInput = Console.ReadLine();
                isDueCorrect = Decimal.TryParse(dueInput, out due);

                if (isDueCorrect != true)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                Console.Write("Enter amount paid: ");
                string paidInput = Console.ReadLine();
                isPaidCorrect = Decimal.TryParse(paidInput, out paid);

                if (isPaidCorrect != true)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                else if (paid < due)
                {
                    Console.WriteLine("You paid less than what is due");
                    break;
                }
                else if (paid == due)
                {
                    Console.WriteLine("There is no change due");
                    break;
                }
                else if (paid > due)
                {
                    decimal change = paid - due;
                    decimal[] denominations = { 100M, 50M, 20M, 10M, 5M, 1M, 0.50M, 0.25M, 0.10M, 0.05M, 0.01M };
                    decimal[] counts = new decimal[11];
                    int index = 0;

                    Console.WriteLine($"The following change is due: {change:C}");

                    while (change > 0)
                    {
                        if (change >= denominations[index])
                        {
                            counts[index]++;
                            change = change - denominations[index];
                        }
                        else
                        {
                            index++;
                        }
                    }

                    for (int i = 0; i < counts.Length; i++)
                    {
                        if (counts[i] > 0)
                        {
                            Console.WriteLine($"{denominations[i],8:C}:{counts[i],3}");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        #endregion

        #region CountingLetters
        private static void CountingLetters()
        {
            string input = string.Empty;
            string[] charTypes = { "Vowels", "Consonants", "Digits", "Whitespace", "Punctuation", "Symbols", "Other" };
            int[] typeCounts = new int[7];
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            Console.Write("Please enter a string: ");
            input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (char.IsLetter(ch))
                {
                    if (vowels.Contains(ch))
                    {
                        typeCounts[0]++;
                    }
                    else
                    {
                        typeCounts[1]++;
                    }
                }
                else if (char.IsDigit(ch))
                {
                    typeCounts[2]++;
                }

                else if (ch == ' ')
                {
                    typeCounts[3]++;
                }
                else if (char.IsPunctuation(ch))
                {
                    typeCounts[4]++;
                }
                else if (char.IsSymbol(ch))
                {
                    typeCounts[5]++;
                }
                else
                {
                    typeCounts[6]++;
                }
            }

            Console.WriteLine($"The text contains {input.Length} characters with the following characteristics:");

            for (int i = 0; i < typeCounts.Length; i++)
            {
                Console.WriteLine($"{typeCounts[i],4} {charTypes[i]}");
            }
        }
        #endregion

        #region NumberGuessingGame
        private static void NumberGuessingGame()
        {
            Random rnd = new Random();
            int target = rnd.Next(100) + 1;

            int guess = 0;
            int count = 0;

            do
            {
                string inputGuess = string.Empty;
                Console.Write("Enter a number between 1 and 100: ");

                inputGuess = Console.ReadLine();

                if (int.TryParse(inputGuess,out guess))
                {
                    count++;
                    if (guess > target)
                    {
                        Console.WriteLine("Too high");
                    }
                    else if (guess < target)
                    {
                        Console.WriteLine("Too low");
                    }
                }
            } while (guess != target);

            Console.WriteLine($"You got it in {count} guesses!");
        }
        #endregion
    }
}
