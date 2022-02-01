using System.Collections.Generic;

Console.WriteLine("Dynamic Arrays");
Console.WriteLine("----------------------");

//First Test
int n = 2;
List<List<int>> queries = new List<List<int>>(5);
List<int> query1 = new List<int> { 1, 0, 5 };
List<int> query2 = new List<int> { 1, 1, 7 };
List<int> query3 = new List<int> { 1, 0, 3 };
List<int> query4 = new List<int> { 2, 1, 0 };
List<int> query5 = new List<int> { 2, 1, 1 };
queries.Add(query1);
queries.Add(query2);
queries.Add(query3);
queries.Add(query4);
queries.Add(query5);

List<int> answerList = dynamicArray(n, queries);
foreach (int answer in answerList)
{
    Console.WriteLine($"{answer}");
}
//The test should return 7 and 3.

/*
Complete the dynamicArray function below.

dynamicArray has the following parameters:
- int n: the number of empty arrays to initialize in 
- string queries[q]: query strings that contain 3 space-separated integers

There are 2 types of queries, given as an array of strings for you to parse:
(The type of query is indicated by the first integer)
*/

static List<int> dynamicArray(int n, List<List<int>> queries)
{
    List<List<int>> arr = new List<List<int>>();
    for (int i = 0; i < n; i++)
    {
        arr.Add(new List<int>());
    }
    int lastAnswer = 0;
    List<int> answers = new List<int>();

    // The first element of queries contains a list. This list has n (the size of array to create) and q (the total number of queries)
    int numberOfQueries = queries.Count;
    for (int i = 0; i < numberOfQueries; i++)
    {
        int queryType = queries[i][0];
        int x = queries[i][1];
        int y = queries[i][2];
        int index = (x ^ lastAnswer) % n;
        if (queryType == 1)
        {
            arr[index].Add(y);
        }
        else
        {
            lastAnswer = arr[index][y % arr[index].Count];
            answers.Add(lastAnswer);
            // Console.WriteLine($"{lastAnswer}");
        }
    }
    return answers;
}