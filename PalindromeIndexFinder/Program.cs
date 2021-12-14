using System;

namespace PalindromeIndexFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Palindrome Index Finder");
            Console.WriteLine("Give me a string and I will give you the index of a character to remove that will make it a Palindrome. If it can't be made into a palindrome I will print -1");
            string userInput = Console.ReadLine();
            Console.WriteLine($"{palindromeIndex(userInput)}");
        }
        /*
 * Complete the 'palindromeIndex' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts STRING s as parameter.
 */

        public static int palindromeIndex(string s)
        {
            int length = s.Length;
            string sReverse = reverseString(s);
            if (s == sReverse) return -1;
            for (int i = 0; i < length; i++)
            {
                if (s[i] != s[length - 1 - i])
                {
                    string sModified1 = s.Remove(i, 1);
                    string sModified2 = s.Remove(length - 1 - i, 1);
                    if (sModified1[i] == sModified1[length - 2 - i])
                    {
                        return i;
                    }
                    else if (sModified2[i] == sModified2[length - 2 - i])
                    {
                        return length - 1 - i;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }
        public static string reverseString(string s)
        {
            char[] reverseStringArray = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                reverseStringArray[s.Length - 1 - i] = s[i];
            }
            return new string(reverseStringArray);
        }
    }
}
