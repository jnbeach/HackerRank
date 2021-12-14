using System;
using System.Collections.Generic;

namespace MaximizeQuadrant
{
    class Program
    {
        //Taken from the HackerRank exercise: "Flipping the Matrix"
        //The goal is to maximize the top left quadrant of a 2D Array. The catch is that only the rows and columns can be flipped. However, because of symmetry, this means that any value in the array can only have 3 other possible values (e.g. the top left corner can only be swapped with the other 3 corners.)
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Quadrant Maximizer");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("How big do you want the cubic matrix to be?");
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            List<List<int>> newMatrix = Generate2DArray(matrixSize);
            PrintCubeArray(newMatrix);

            MaximizeQuadrant(newMatrix);
            Console.WriteLine("The top left should now be maximized:");
            PrintCubeArray(newMatrix);
            Console.WriteLine($"The maximum possible sum is: {QuadrantMaxSum(newMatrix)}");
        }

        public static int QuadrantMaxSum(List<List<int>> matrix)
        {

            int size = matrix[0].Count;
            int quadrantSum = 0;
            List<int> possibleElements = new List<int>();

            //Because of symettry
            //Go through every element in the quadrant and replace it with the max possible value (without altering the other elements)
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size / 2; j++)
                {
                    possibleElements.Add(matrix[i][j]);
                    possibleElements.Add(matrix[i][size - j - 1]);
                    possibleElements.Add(matrix[size - i - 1][j]);
                    possibleElements.Add(matrix[size - i - 1][size - j - 1]);
                    possibleElements.Sort();
                    quadrantSum += possibleElements[possibleElements.Count - 1];
                    possibleElements.Clear();
                }
            }
            return quadrantSum;
        }
        public static List<List<int>> MaximizeQuadrant(List<List<int>> cubeArray)
        {

            int size = cubeArray[0].Count;
            int elementToReplace;

            //Go through every element in the quadrant and replace it with the max possible value (without altering the other elements)
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size / 2; j++)
                {
                    elementToReplace = cubeArray[i][j];
                    if (cubeArray[i][size - j - 1] > elementToReplace)
                    {
                        cubeArray[i][j] = cubeArray[i][size - j - 1];
                        cubeArray[i][size - j - 1] = elementToReplace;
                        elementToReplace = cubeArray[i][j];
                    }
                    if (cubeArray[size - i - 1][j] > elementToReplace)
                    {
                        cubeArray[i][j] = cubeArray[size - i - 1][j];
                        cubeArray[size - i - 1][j] = elementToReplace;
                        elementToReplace = cubeArray[i][j];
                    }
                    if (cubeArray[size - i - 1][size - j - 1] > elementToReplace)
                    {
                        cubeArray[i][j] = cubeArray[size - i - 1][size - j - 1];
                        cubeArray[size - i - 1][size - j - 1] = elementToReplace;
                        elementToReplace = cubeArray[i][j];
                    }
                }
            }
            return cubeArray;
        }
        public static List<List<int>> FlipRow(List<List<int>> cubeArray, int rowToFlip)
        {
            cubeArray[rowToFlip].Reverse();
            return cubeArray;
        }
        public static List<List<int>> FlipColumn(List<List<int>> cubeArray, int columnToFlip)
        {
            int size = cubeArray.Count;
            int tempNum;
            for (int i = 0; i < size / 2; i++)
            {
                tempNum = cubeArray[i][columnToFlip];
                cubeArray[i][columnToFlip] = cubeArray[size - 1 - i][columnToFlip];
                cubeArray[size - 1 - i][columnToFlip] = tempNum;
            }
            return cubeArray;
        }
        public static List<List<int>> Generate2DArray(int size)
        {
            var rnJesus = new Random();
            List<List<int>> cubeArray = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                List<int> newRow = new List<int>();
                for (int j = 0; j < size; j++)
                {
                    newRow.Add(rnJesus.Next(1, 10));
                }
                cubeArray.Add(newRow);
            }
            return cubeArray;
        }
        public static void PrintCubeArray(List<List<int>> arrayToPrint)
        {
            int size = arrayToPrint[0].Count;
            Console.WriteLine($"--------------------------");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"\n");
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{arrayToPrint[i][j]}\t");
                }
            }
            Console.WriteLine($"\n--------------------------");
        }
    }
}
