using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics();

            Console.ReadLine();
        }

        static void Statistics()
        {
            int[] values = { 6, 3, 9, 1, 2, 2, 5, 6, 3, 8, 3, 9, 4, 1, 9 };

            Console.Write("Data: ");

            for (int i = 0; i < values.Length; i++)
            {
                if (i < values.Length-1)
                {
                    Console.Write($" {values[i]},");
                }
                else
                {
                    Console.Write($" {values[i]}");
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Mean: {Mean(values)}");
            Console.WriteLine($"Median: {Median(values)}");
            Console.Write("Mode: ");

            List<int> results = Mode(values);

            for (int i = 0; i < results.Count; i++)
            {
                if (i != results.Count - 1)
                {
                    Console.Write($"{results[i]}, ");
                }
                else
                {
                    Console.WriteLine(results[i]);
                }

            }

            Console.WriteLine();

        }

        static double Mean(int[] values)
        {
            if (values.Length == 0 || values == null)
            {
                return 0;
            }

            int sum = 0;

            foreach (var num in values)
            {
                sum += num;
            }

            return sum / values.Length;
        }

        static double Median(int[] values)
        {
            int[] sorted = new int[values.Length];
            values.CopyTo(sorted, 0);
            Array.Sort(sorted);            //if odd
            if (sorted.Length % 2 != 0)
            {
                int mIndex = sorted.Length / 2;
                return sorted[mIndex];
            }
            //even
            else
            {
                int midNum = sorted.Length / 2;
                return (sorted[midNum] + sorted[midNum + 1]) / 2;
            }
        }

        static List<int> Mode(int[] values)
        {
            int max = 0;
            int[] sorted = new int[values.Length];
            values.CopyTo(sorted, 0);
            Array.Sort(sorted);            List<int> results = new List<int>();            var counts = new Dictionary<int, int>();
            foreach (var key in sorted)
            {
                int count = 1;

                if (counts.ContainsKey(key))
                {
                    count += counts[key];                    if (count > max)
                    {
                        max = count;
                    }
                    counts[key] = count;
                }
                else
                {
                    counts.Add(key, count);
                }
            }

            foreach (var key in counts.Keys)
            {
                if (counts[key] == max)
                {
                    results.Add(key);
                }
            }
            return results;
        }

    }
}
