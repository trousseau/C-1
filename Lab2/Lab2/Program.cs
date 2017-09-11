using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayTest();
            ListTest();
            StringFormatting();
            Console.Write("Press <Enter> to quit...");
            Console.ReadLine();
        }

        #region ArrayTest
        static void ArrayTest()
        {
            string input = String.Empty;

            Console.WriteLine("ArrayTest()");            Console.Write("Please enter 5 numbers separated by commas: ");            input = Console.ReadLine();

            string[] inputs = new string[5];            inputs = input.Split(',');            double[] values = new double[5];            for (int i = 0; i < values.Length; i++)
            {
                values[i] = double.Parse(inputs[i]);
            }            Array.Sort(values);            double min, max, sum, average = 0;            min = values.Min();            max = values.Max();            sum = values.Sum();            average = values.Average();

            Console.Write("Values: ");
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write($"{values[i]} ");
            }            Console.WriteLine();            Console.WriteLine($"Min: {min}");            Console.WriteLine($"Max: {max}");            Console.WriteLine($"Sum: {sum}");            Console.WriteLine($"Average: {average}");            Console.WriteLine();
        }
        #endregion

        #region ListTest
        static void ListTest()
        {
            Console.WriteLine("ListTest()");
            List<string> words = new List<string>();
            Console.Write("Continue entering one word at a time at the prompt. ");
            Console.WriteLine("Enter 'q' to quit.");
            while (true)
            {
                // TODO: Add word reading code here...

                Console.Write("Word: ");

                string word = String.Empty;
                word = Console.ReadLine();

                if (word.ToUpper() == "Q")
                {
                    break;
                }
                else
                {
                    words.Add(word);
                }
            }
            // TODO: Add string join code here...

            string join = String.Empty;
            join = String.Join(" ",words);

            Console.WriteLine(join);

            Console.WriteLine();
        }
        #endregion

        #region StringFormatting
        private static void StringFormatting()
        {
            int partNumber;
            string partName;
            decimal price;
            long servicePhone;
            DateTime mfgDate;

            Console.WriteLine("StringFormatting()");

            Console.WriteLine("{0,-10} {1,-19} {2,15} {3,-12} {4,9}", "Part#", "Part Name", "Price", "Phone", "MFG Date");
            string seperator = new string('=', 71);
            Console.WriteLine(seperator);

            partNumber = 475849372;
            partName = "HyperDrive";
            price = 7439234.99M;
            servicePhone = 8605559203;
            mfgDate = DateTime.Parse("5/25/1977");

            Console.WriteLine($"{partNumber,-9:00-0000000} {partName,-19} {price,15:C} {servicePhone,-13:(###)###-####} {mfgDate,9:yyyy-MM-dd}");

            partNumber = 475849372;
            partName = "HAL 9000 AI Unit";
            price = 192344553.99M;
            servicePhone = 4135554321;
            mfgDate = DateTime.Parse("4/3/1968");

            Console.WriteLine($"{partNumber,-9:00-0000000} {partName,-19} {price,15:C} {servicePhone,-13:(###)###-####} {mfgDate,9:yyyy-MM-dd}");

            partNumber = 208475848;
            partName = "Matrix RAM";
            price = 34.99M;
            servicePhone = 7605550901;
            mfgDate = DateTime.Parse("3/31/1999");

            Console.WriteLine($"{partNumber,-9:00-0000000} {partName,-19} {price,15:C} {servicePhone,-13:(###)###-####} {mfgDate,9:yyyy-MM-dd}");

            partNumber = 9202920;
            partName = "T-1000 Chip";
            price = 94547637.99M;
            servicePhone = 2235552211;
            mfgDate = DateTime.Parse("6/3/1991");

            Console.WriteLine($"{partNumber,-9:00-0000000} {partName,-19} {price,15:C} {servicePhone,-13:(###)###-####} {mfgDate,9:yyyy-MM-dd}");

            partNumber = 11111;
            partName = "Wall-E Tire Treads";
            price = 59.99M;
            servicePhone = 1115555623;
            mfgDate = DateTime.Parse("6/28/2008");

            Console.WriteLine($"{partNumber,-9:00-0000000} {partName,-19} {price,15:C} {servicePhone,-13:(###)###-####} {mfgDate,9:yyyy-MM-dd}");

            Console.WriteLine();
        }
        #endregion
    }
}
