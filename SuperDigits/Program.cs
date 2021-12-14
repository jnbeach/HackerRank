/*We define super digit of an integer  using the following rules:

Given an integer, we need to find the super digit of the integer.

If  has only  digit, then its super digit is .
Otherwise, the super digit of  is equal to the super digit of the sum of the digits of .
For example, the super digit of  will be calculated as:

	super_digit(9875)   9 + 8 + 7 + 5 = 29

    super_digit(29)     2 + 9 = 11

    super_digit(11)     1 + 1 = 2

    super_digit(2) = 2
*/
Console.WriteLine("----------------------");
Console.WriteLine("Super Digits");
Console.WriteLine("----------------------");
Console.WriteLine("Enter a number to compute:");
string inputN = Console.ReadLine();
string concatInputN = "";
Console.WriteLine("Enter how many times to concatenate this number:");
int inputK = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < inputK; i++)
{
    concatInputN += inputN;
}
Console.WriteLine($"The super digit of {concatInputN} is: {superDigit(inputN, inputK)}");
Console.WriteLine($"END");
/*
 * Complete the 'superDigit' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts following parameters:
 *  1. STRING n (string representation of int n)
 *  2. INTEGER k (how many times to concatenate)
 */
static int superDigit(string n, int k)
{
    var tempSum = 0; // Sum each number
    foreach (char ch in n) //Iterate through the string.
    {
        tempSum += (int)ch - 48; //Add each char to the temp sum. 
    }
    tempSum *= k; //Multiply by k (# of times the string is concatenated.)
    if (tempSum < 10) return (int)tempSum; //If a single digit, return the number.
    else
    {
        n = Convert.ToString(tempSum); //Convert to a string and then
        return superDigit(n, 1); // recursively call superDigit.
    }
}