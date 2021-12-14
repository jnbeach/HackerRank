using System;

namespace NewYearChaos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static void minimumBribes(List<int> q)
        {
            int bribes = 0;
            bool isTooChaotic = false;
            //Set up the initial state of the Queue
            List<int> initialQueue = new List<int>();
            for (int i = 1; i <= q.Count; i++) initialQueue.Add(i);
            //Set up a dummyQueue to alter.
            List<int> dummyQueue = new List<int>(initialQueue.ToArray());

            int initialIndex;
            int currentIndex;
            int indexDiff;

            for (int personId = q.Count; personId >= 1; personId--)
            {
                initialIndex = initialQueue.IndexOf(personId);
                currentIndex = q.IndexOf(personId);
                indexDiff = initialIndex - currentIndex;
                if (indexDiff > 2)
                {
                    isTooChaotic = true;
                    break;
                }
                else if (indexDiff <= 2 && indexDiff > 0)
                {
                    for (int i = 1; i <= indexDiff; i++)
                    {
                        conductBribe(ref dummyQueue, personId);
                        bribes++;
                    }
                }
            }
            if (isTooChaotic) Console.WriteLine("Too chaotic");
            else Console.WriteLine($"{bribes}");

        }
        public static void conductBribe(ref List<int> queue, int briber)
        {
            int briberIndex = queue.IndexOf(briber);
            queue.Remove(briber);
            queue.Insert(briberIndex - 1, briber);
        }
    }
}
