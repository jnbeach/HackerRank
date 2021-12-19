using System;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<List<int>> testPumps = new List<List<int>>();
            Random rnjesus = new Random();
            List<int> pumpi;
            int randomGas;
            int randomDistance;

            for (int i = 0; i < 1000; i++)
            {
                randomGas = rnjesus.Next(5000, 40000);
                randomDistance = rnjesus.Next(10000, 100000);
                pumpi = new List<int>(){
                randomGas, randomDistance
                };
                testPumps.Add(pumpi);
            }
            foreach (List<int> pump in testPumps)
            {
                foreach (int num in pump)
                {
                    Console.Write($"{num}\t");
                }
                Console.Write("\n");
            }
            Console.WriteLine($"The result is:");
            int result = truckTour(testPumps);
            Console.WriteLine($"{result}");
        }
        public static int truckTour(List<List<int>> petrolpumps)
        {
            long gas = 0;
            long distanceToNextPump;
            int answerPump = -1;

            //This loop changes the starting position of the pump.
            for (int startPump = 0; startPump < petrolpumps.Count; startPump++)
            {
                //This loop iterates through the list of pumps for each change in starting position.
                for (int j = 0; j < petrolpumps.Count; j++)
                {
                    gas += petrolpumps[(startPump + j) % petrolpumps.Count][0];
                    distanceToNextPump = petrolpumps[(startPump + j) % petrolpumps.Count][1];
                    //if gas is not enough to make it to the next pump,
                    //Reset gas to zero, break this loop, and move the starting position to the next pump.
                    if (gas < distanceToNextPump)
                    {
                        gas = 0;
                        break;
                    }
                    else if (j == petrolpumps.Count - 1)
                    {
                        answerPump = startPump;
                        return answerPump;
                    }
                    //Subtract the gas it takes to move to the next Pump before going to the next pump j.
                    gas -= distanceToNextPump;
                }
            }
            return answerPump;
        }
    }
}
