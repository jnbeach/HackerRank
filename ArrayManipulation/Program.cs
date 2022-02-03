// See https://aka.ms/new-console-template for more information
Console.WriteLine("Array Manipulation");
int n = 10;
var queries = new List<List<int>>();
var query1 = new List<int> { 1, 5, 3 };
var query2 = new List<int> { 4, 8, 7 };
var query3 = new List<int> { 6, 9, 1 };
queries.Add(query1);
queries.Add(query2);
queries.Add(query3);

long answer = arrayManipulation(n, queries);
Console.WriteLine($"{answer}");

static long arrayManipulation(int n, List<List<int>> queries)
{
    // This was my first attempt at this problem.
    // This passes for the first 6 cases, but it takes too long for the bigger test cases.
    #region firstSolution
    // long[] longArray = new long[n];
    // int startIndex;
    // int endIndex;
    // long valueToAdd;
    // long maxValue = 0;
    // foreach (List<int> query in queries) {
    //     startIndex = query[0]-1;
    //     endIndex = query[1]-1;
    //     valueToAdd = query[2];
    //     for (int i = startIndex; i <= endIndex; i++) {
    //         longArray[i] += valueToAdd;
    //         if (longArray[i] > maxValue) maxValue = longArray[i];
    //     }            
    // }
    // return maxValue;
    #endregion

    // This was Blake's idea. It passes for the longer tests. Instead of calculating and assingning a value to each element of the array, it just keeps track of the biggest value that the array could hold. It does this by only adding the value to the starting index and subtracting the value from everything after the end index.
    #region secondSolution
    long[] longArray = new long[n];
    int startIndex;
    int endIndex;
    int valueToAdd;
    long maxValue = 0;
    long sum = 0;

    foreach (List<int> query in queries)
    {
        startIndex = query[0] - 1;
        endIndex = query[1] - 1;
        valueToAdd = query[2];

        longArray[startIndex] += valueToAdd;
        if (endIndex + 1 < n)
        {
            longArray[endIndex + 1] -= valueToAdd;
        }
    }

    for (int i = 0; i < n; i++)
    {
        sum += longArray[i];
        maxValue = Math.Max(maxValue, sum);
    }

    return maxValue;
    #endregion
}