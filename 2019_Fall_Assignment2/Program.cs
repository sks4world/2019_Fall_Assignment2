using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if(ValidPalindrome(s)) {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach(int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            //SKS: Srikrishna Krishnarao Srinivasan Sep 27 2019
            //Initialize
            string p=null, str1=null;
            int count = 0;

            //SKS Sep 27 2019: Pseudocode 1
            p = "1. Read the input array and sort it ascending. Convert Array to string str1. Lets say str1=1112234477\n" +
                "2. Create a For loop to start reading from the end of the string str1.Substring(i,1), i = str1.Length its 11 in this case\n" +
                "3. Store three consecutive characters obtained in the for loop c.last, c.last-1, c.last-2\n" +
                "4. Check if c.last == c.last-1. If true, continue the for loop (number is repeating). If false,check if c.last-1==c.last-2 \n" +
                "4a. If c.last-1==c.last-2, then it is transition, but still new number is repeating. Continue the for loop\n" +
                "4b. If c.last-1!=c.last-2, then the number transitioned, but not repeating, break the for loop and report answer\n" +
                "5. Boundary conditions: C1:Empty array, C2:single element array, C3:array with all digits same (optimize this case by count before iteration), C4:array with all digits different  ";
            Debug.WriteLine(p);

            //SKS Sep 27 2019: Pseudocode 2 (This is optimized and more efficient code based on Case 3 (C3) mentioned in Pseudocode 1
            p = "1. Read the input array and sort it ascending. Convert Array to string str1. Lets say str1=1112234477\n" +
                "2. Create a For loop to start reading from the end of the string str1.Substring(i,1), i = str1.Length its 11 in this case\n" +
                "3. Do a Regex search of the obtained character in the for loop in the full string. If the result is 1, break the for loop and report the answer.";


            str1 = "1112234477";
            count=Regex.Matches(str1, "4").Count;
            Debug.WriteLine(count);
            count=Regex.Matches(str1, "3").Count;
            Debug.WriteLine(count);

            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
