using System;
using System.Collections.Generic;
using System.Linq;

namespace _2015Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = ReadDataFile();

            SolveDay1Part1(lines);

            SolveDay1Part2(lines);

            SolveDay1Part2Optimisedv1(lines);

            SolveDay1Part2Optimisedv2(lines);

            Console.ReadLine();
        }

        private static void SolveDay1Part1(List<string> input)
        {
            string openBrackets = input[0].Replace(")", "");
            string closeBrackets = input[0].Replace("(", "");

            Int32 finalFloorNumber = openBrackets.Length - closeBrackets.Length;

            Console.WriteLine($"Part 1");

            DisplayAnswer(finalFloorNumber);
        }

        private static void SolveDay1Part2(List<string> input)
        {
            // using other input results
            // 00:00:00.2484571 without optimisation
            // 00:00:00.0108546 with optimisation

            DateTime start = DateTime.Now;

            Int32 intoBasement = 0;

            for (int i = 0; i < input[0].Length; i++)
            {
                string partString = input[0].Substring(0, i);

                if (partString.Replace(")", "").Length < partString.Replace("(", "").Length)
                {
                    intoBasement = i;
                    break;
                }
            }

            TimeSpan duration = DateTime.Now.Subtract(start);

            Console.WriteLine($"Part 2");

            Console.WriteLine($"time to run: {duration}");

            DisplayAnswer(intoBasement);
        }
        
        /// <summary>
        /// Optimised solution which does not check at all points in input string 
        /// </summary>
        /// <param name="input"></param>
        /// <remarks>
        /// If Santa is above the ground floor we can skip ahead in the loop because
        /// the minimum next possible solution will be current floor + 1 steps forward.
        /// eg - Santa is on floor 2 so the fastest route to the basement is 3 down moves 
        /// which is current floor + 1.
        /// Remember the for loop iterates the counter so only increment the counter by the current floor.
        /// </remarks>
        private static void SolveDay1Part2Optimisedv1(List<string> input)
        {
            DateTime start = DateTime.Now;

            Int32 intoBasement = 0;

            for (int i = 0; i < input[0].Length; i++)
            {
                string partString = input[0].Substring(0, i);

                Int32 floorDifference = partString.Replace(")", "").Length - partString.Replace("(", "").Length;

                if (floorDifference > 0)
                {
                    i += floorDifference;
                    continue;
                }

                if (floorDifference < 0)
                {
                    intoBasement = i;
                    break;
                }
            }

            TimeSpan duration = DateTime.Now.Subtract(start);

            Console.WriteLine($"Part 2 optimised v1");

            Console.WriteLine($"time to run: {duration}");

            DisplayAnswer(intoBasement);
        }
        
        private static void SolveDay1Part2Optimisedv2(List<string> input)
        {
            DateTime start = DateTime.Now;

            Int32 intoBasement = 0;

            for (int i = 0; i < input[0].Length; i++)
            {
                string partString = input[0].Substring(0, i);

                Int32 floorDifference = partString.Replace(")", "").Length - partString.Replace("(", "").Length;

                if (floorDifference > 2)
                {
                    i += floorDifference;
                    continue;
                }

                if (floorDifference < 0)
                {
                    intoBasement = i;
                    break;
                }
            }

            TimeSpan duration = DateTime.Now.Subtract(start);

            Console.WriteLine($"Part 2 optimised v2");

            Console.WriteLine($"time to run: {duration}");

            DisplayAnswer(intoBasement);
        }        
        
        static List<string> ReadDataFile()
        {
            string filePath = @"D:\Users\U.5226074\source\Advent of code\Day2\Part1\input.txt";

            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            return lines;
        }

        static void DisplayAnswer(Int32 number)
        {
            Console.WriteLine($"Answer = {number}");
            Console.WriteLine("");
        }
    }
}
