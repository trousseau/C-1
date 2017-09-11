using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string dobInput = string.Empty;
            string idInput = string.Empty;
            string isEmployedInput = string.Empty;
            string salaryInput = string.Empty;

            int id = 0;
            double salary = 0;
            bool isEmployed = false;

            DateTime dob = DateTime.MinValue;
            //name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please enter your name: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello, " + name);

            //dob
            Console.Write("Please enter your date of birth: ");
            dobInput = Console.ReadLine();

            if (DateTime.TryParse(dobInput, out dob))
            {
                Console.WriteLine("Your birthday is " + dob.ToShortDateString() +
                " which was a " + dob.DayOfWeek);
            }            else
            {
                Console.WriteLine("That is an invalid birthday!");
            }

            //empid
            Console.Write("Please enter your employee id: ");
            idInput = Console.ReadLine();

            if (Int32.TryParse(idInput, out id))
            {
                Console.WriteLine("Your ID # is " + id.ToString());
            }            else
            {
                Console.WriteLine("That is an invalid ID #!");
            }

            //salary
            Console.Write("Please enter your salary: ");
            salaryInput = Console.ReadLine();

            if (Double.TryParse(salaryInput, out salary))
            {
                Console.WriteLine("Your salary is " + salary.ToString());
            }            else
            {
                Console.WriteLine("That is an invalid salary!");
            }

            //isEmployed
            Console.Write("Please enter if you are employed (true/false): ");
            isEmployedInput = Console.ReadLine();

            if (Boolean.TryParse(isEmployedInput, out isEmployed))
            {
                Console.WriteLine("Your are employed: " + isEmployed.ToString());
            }            else
            {
                Console.WriteLine("That is an invalid value!");
            }

            Console.WriteLine();

            //area of rectangle
            double width = 6.5;
            int height = 3;
            Console.WriteLine("#1: " + (width * height));

            //area of circle
            double radius = 7.1;
            Console.WriteLine("#2: " + Math.PI *(radius * radius));

            //distance between two points
            //3A. (2, 5) and(-3, 7)
            //3B. (-5, 4) and(1, 0)
            //3C. (6, -2) and(-4, -6)
            double x1 = 2;
            double x2 = 5;
            double y1 = -3;
            double y2 = 7;

            double solution = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine("#3A: " + solution);

            x1 = -5;
            x2 = 4;
            y1 = 1;
            y2 = 0;

            solution = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine("#3B: " + solution);

            x1 = 6;
            x2 = 2;
            y1 = -4;
            y2 = -6;

            solution = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine("#3C: " + solution);


            Console.Write("Press <ENTER> to quit...");
            Console.ReadLine();
        }
    }
}
