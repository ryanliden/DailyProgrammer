using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommonUtils;

namespace RyansLibrary
{
    public class StringFunctions
    {
        /// <summary>
        /// Swaps 2 strings letter by letter
        /// </summary>
        /// <param name="oldString"></param>
        /// <param name="newString"></param>
        public static void SwapStrings(string oldString, string newString)
        {
            // Create a char array for each of the string
            char[] oldStringArray = oldString.ToCharArray();

            char[] newStringArray = newString.ToCharArray();

            for (int i = 0; i <= oldStringArray.Length; i++)
            {
                // Output the current string
                for (int j = 0; j < oldStringArray.Length; j++)
                {
                    Console.Write(oldStringArray[j]);
                }
                Console.WriteLine();

                if (i < oldStringArray.Length)
                {
                    // Replace the letter at position i
                    oldStringArray[i] = newStringArray[i];
                }
            }
        }

        
    }
}
