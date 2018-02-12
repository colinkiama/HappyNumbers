using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindHappyNumbers());
            Console.ReadLine();
        }

        private static string FindHappyNumbers()
        {
            Console.WriteLine("How many happy numbers do you want to find?");


            int NumbersToFind = int.Parse(Console.ReadLine());
            int[] NumbersFound = new int[NumbersToFind];
            int HappyNumbersFound = 0;
            int startingNum = 1;
            int num = 1;
            const int searchLoopLimit = 10;
            int searchLoops = 0;
            string numAsString = String.Empty;
            bool searchEnded = false;

            while (HappyNumbersFound < NumbersToFind)
            {
                if (searchLoops == searchLoopLimit)
                {
                    searchEnded = true;
                }

                if (searchEnded)
                {
                    ResetLoopWithNextNumber(ref startingNum, ref num, ref searchLoops, ref searchEnded);
                    
                }

                numAsString = num.ToString();
                int sum = 0;
                foreach (var digitChar in numAsString)
                {
                    int digit = int.Parse(digitChar.ToString());
                    sum += (int)Math.Pow(digit, 2);
                }

                if (sum == 1)
                {
                    NumbersFound[HappyNumbersFound] = startingNum;
                    HappyNumbersFound += 1;
                    searchEnded = true;
                }
                else
                {
                    num = sum;
                    searchLoops += 1;
                }
            }

            string FormattedArray = TurnArrayIntoWellFormattedString(NumbersFound);
            return FormattedArray;

        }

        private static void ResetLoopWithNextNumber(ref int startingNum, ref int num, ref int searchLoops, ref bool searchEnded)
        {
            startingNum += 1;
            num = startingNum;
            searchLoops = 0;
            searchEnded = false;
        }

        private static string TurnArrayIntoWellFormattedString(int[] numbersFound)
        {
            string StringToReturn = "";
            int length = numbersFound.Length;

            for (int i = 0; i < length; i++)
            {
                if (i < length - 1)
                {
                    StringToReturn += numbersFound[i] + ", ";
                }
                else
                {
                    StringToReturn += numbersFound[i];
                }
            }

            return StringToReturn;
        }
    }
}
