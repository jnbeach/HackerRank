Console.WriteLine("Grid Challenge");
Console.WriteLine("-------------------------");
List<string> test = new List<string>();
test.Add("abc");
test.Add("bcd");
test.Add("cde");
Console.WriteLine($"{gridChallenge(test)}");
Console.WriteLine($"Test Complete!");


/*
 * Complete the 'gridChallenge' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts STRING_ARRAY grid as parameter.
 */

static string gridChallenge(List<string> grid)
{
    //1st turn the strings into char arrays, sort them, and replace each string in the grid with the sorted string.
    List<char> CharList;
    int len = grid[0].Length; // Length of each string.
    for (int i = 0; i < grid.Count; i++)
    {
        CharList = new List<char>(grid[i].ToCharArray());
        CharList.Sort();
        grid[i] = new string(CharList.ToArray());
    }
    //Go through every letter in each string and compare to the one below to ensure it occurs alphabetically before the next.
    //i represents which string in the list is being accessed (row.)
    //j represents the position within each string (column), 
    for (int i = 0; i < grid.Count - 1; i++)
    {
        // If the last character in a string (row) occurs before the first character in the next string (row), then it is guranteed that all of the chars in the string occur before all of the chars in the next string. Skip to the next row automatically.
        if (grid[i][len - 1] < grid[i + 1][0]) continue;
        //Start from the end of the string and work to the beginning.
        //If at any point, the char in the string is greater than the one below, return "NO".
        for (int j = len - 1; j >= 0; j--)
        {
            if (grid[i][j] > grid[i + 1][j]) return "NO";
        }
    }
    return "YES";
}