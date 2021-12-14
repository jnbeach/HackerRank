using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This will Caesar Cipher your message:");
            Console.WriteLine("Input a message:");
            string userInput = Console.ReadLine();
            Console.WriteLine(caesarCipher(userInput, 3));

        }
        /*
 * Complete the 'caesarCipher' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. STRING s
 *  2. INTEGER k
 */

        public static string caesarCipher(string s, int k)
        {
            int newKey = k % 26;
            // s = s.ToLower();
            char[] sArray = s.ToCharArray();
            int[] sArrayInts = new int[s.Length];
            for (int i = 0; i < sArray.Length; i++)
            {
                sArrayInts[i] = (int)sArray[i];
                //Handle Uppercase Letters
                if (sArrayInts[i] >= 65 && sArrayInts[i] <= 90)
                {
                    //A = 65 Z = 90 (subtract 65 to have A=0 and Z = 25)
                    sArrayInts[i] = sArrayInts[i] - 65 + newKey;
                    sArrayInts[i] %= 26; // Cycle letters 'above z' back to a
                    sArrayInts[i] += 65; // Convert it back to unicode numbers
                    sArray[i] = (char)sArrayInts[i];
                }
                //Handle Lowercase Letters
                else if (sArrayInts[i] >= 97 && sArrayInts[i] <= 122)
                {
                    //a = 97 z = 122 (subtract 97 to go to have a = 0 z = 25 )
                    sArrayInts[i] = (int)sArray[i] - 97 + newKey;
                    sArrayInts[i] %= 26; // Cycle letters 'above z' back to a
                    sArrayInts[i] += 97; // Convert it back to unicode numbers
                    sArray[i] = (char)sArrayInts[i];
                }
                //Handle all other characters by putting them back as is.
                else
                {
                    sArray[i] = (char)sArrayInts[i];
                }
            }
            return new string(sArray);
        }
    }
}
