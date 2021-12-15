using System;
using System.Collections.Generic;

namespace NewYearChaos
{
    class Program
    {
        //It is New Year's Day and people are in line for the Wonderland rollercoaster ride. Each person wears a sticker indicating their initial position in the queue from 1 to n. Any person can bribe the person directly in front of them to swap positions, but they still wear their original sticker. One person can bribe at most two others.

        // Determine the minimum number of bribes that took place to get to a given queue order.Print the number of bribes, or, if anyone has bribed more than two people, print Too chaotic.

        static void Main(string[] args)
        {
            Console.WriteLine("New Year Chaos");
            List<int> queueTest = new List<int>(){
                2, 1, 5, 3, 4
            };
            minimumBribes(queueTest);
        }
        public static void minimumBribes(List<int> q)
        {
            int bribes = 0;
            bool isTooChaotic = false;
            int personId;
            int expectedPersonId;
            int queueDiff = 0;
            //Changed to a list with only the next 3 elements to keep track of expected positions.
            //In previous iterations, I used an array the size of the queue, but this was unneccessary and bogged down the processing for larger queues.
            List<int> next3Expected = new List<int>(){
                1, 2, 3
            };

            for (int index = 0; index < q.Count; index++)
            {
                expectedPersonId = next3Expected[0];
                personId = q[index];
                if (next3Expected.Contains(personId))
                {
                    queueDiff = next3Expected.IndexOf(personId);
                    if (queueDiff >= 0)
                    {
                        next3Expected.Add(next3Expected[2] + 1);
                        next3Expected.Remove(personId);
                        bribes += queueDiff;
                    }
                }
                else
                {
                    isTooChaotic = true;
                    break;
                }
            }
            if (isTooChaotic) Console.WriteLine("Too chaotic");
            else Console.WriteLine($"{bribes}");
        }
    }
}
