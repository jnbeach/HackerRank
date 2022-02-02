using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<string> testStrings = new List<string>{
    "aba",
    "baba",
    "aba",
    "xzxb"
};
List<string> testQueries = new List<string>{
    "aba",
    "xzxb",
    "ab",
};

List<int> answer = matchingStrings(testStrings, testQueries);
foreach (int number in answer)
{
    Console.WriteLine($"{number}");
}

//This is the 1st solution submitted to HackerRank. This one passes all of the tests, but BigO is n^2 since it iterates through every single element in both arrays.

static List<int> matchingStrings(List<string> strings, List<string> queries)
{
    List<int> results = new List<int>();
    int counter = 0;
    List<string> originalQueries = new List<string>(queries);
    foreach (string query in queries)
    {
        foreach (string str in strings)
        {
            if (str == query) counter++;
        }
        results.Add(counter);
        counter = 0;
    }
    return results;
}

//This solution only works for the first few tests on HackerRank, but it is more efficent as it only searches the strings array where it needs to. It also only compares the 1st letter of each string until it runs into a string with the same character, and then it starts comparing the full strings with each other.

//There is definitely still something wrong with the overall algorithm though.
// static List<int> matchingStrings(List<string> strings, List<string> queries)
// {
//     List<int> results = new List<int>(new int[queries.Count]);
//     int counter = 0;
//     int stringsIndex = 0;
//     int startingIndex = 0;
//     strings.Sort();
//     List<string> originalQueries = new List<string>(queries);
//     queries.Sort();
//     foreach (string query in queries)
//     {
//         while (query[0] < strings[stringsIndex][0])
//         {
//             startingIndex++;
//             if (stringsIndex < strings.Count - 1) stringsIndex++;
//             else break;
//         }
//         while (query != strings[stringsIndex])
//         {
//             if (stringsIndex < strings.Count - 1) stringsIndex++;
//             else break;
//         }
//         while (query == strings[stringsIndex])
//         {
//             counter++;
//             if (stringsIndex < strings.Count - 1) stringsIndex++;
//             else break;
//         }
//         results[originalQueries.IndexOf(query)] = counter;
//         counter = 0;
//         stringsIndex = startingIndex;
//     }
//     return results;
// }