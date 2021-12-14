using System;
using System.Collections.Generic;

namespace FindTheMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Find the Median of a List of Numbers");
            Console.WriteLine("--------------------------------------\n");

            Console.WriteLine("How many numbers would you like to input?");
            int totalNums = Convert.ToInt32(Console.ReadLine());
            List<int> listOfNums = new List<int>();
            for (int i = 0; i < totalNums; i++)
            {
                Console.WriteLine($"Please give me integer #{i + 1}:");
                listOfNums.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Your list of numbers was:");
            Console.Write("\n[ ");
            foreach (int num in listOfNums)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n\n");
            double listMedian = findMedian(listOfNums);
            Console.WriteLine($"The median of this list is: {listMedian}\n"); Console.WriteLine("Your sorted list was:");
            listOfNums.Sort();
            Console.Write("\n[ ");
            foreach (int num in listOfNums)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n\n");

        }
        static double findMedian(List<int> numList)
        {
            numList.Sort();
            double median;
            if (numList.Count % 2 == 1)
            {
                int medianIndex = numList.Count / 2;
                median = numList[medianIndex];
            }
            else
            {
                int medianIndex1 = numList.Count / 2 - 1;
                int medianIndex2 = numList.Count / 2;
                median = (numList[medianIndex1] + numList[medianIndex2]) / 2.0;
            }
            return median;
        }
    }
}
