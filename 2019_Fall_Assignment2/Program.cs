using System;
using System.Diagnostics;
using System.Linq;
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
            if (ValidPalindrome(s)) {
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
            string str1 = null, strx=null;
            int count = 0;

            //SKS Sep 27 2019: Pseudocode 1
            //"1. Read the input array and sort it ascending. Convert Array to string str1. Lets say str1=1112234477\n" +
            //    "2. Create a For loop to start reading from the end of the string str1.Substring(i,1), i = str1.Length its 11 in this case\n" +
            //    "3. Store three consecutive characters obtained in the for loop c.last, c.last-1, c.last-2\n" +
            //    "4. Check if c.last == c.last-1. If true, continue the for loop (number is repeating). If false,check if c.last-1==c.last-2 \n" +
            //    "4a. If c.last-1==c.last-2, then it is transition, but still new number is repeating. Continue the for loop\n" +
            //    "4b. If c.last-1!=c.last-2, then the number transitioned, but not repeating, break the for loop and report answer\n" +
            //    "5. Boundary conditions: C1:Empty array, C2:single element array, C3:array with all digits same (optimize this case by count before iteration), C4:array with all digits different  ";

            //SKS Sep 27 2019: Pseudocode 2 (This is optimized and more efficient code based on Case 3 (C3) mentioned in Pseudocode 1
            // "1. Read the input array and sort it ascending. Convert Array to string str1. Lets say str1=1112234477\n" +
            //    "2. Create a For loop to start reading from the end of the string str1.Substring(i,1), i = str1.Length its 11 in this case\n" +
            //    "3. Do a Regex search of the obtained character in the for loop in the full string. If the result is 1, break the for loop and report the answer.";

            //count=Regex.Matches(str1, "4").Count;
            //Debug.WriteLine(count);
            //count=Regex.Matches(str1, "3").Count;
            //Debug.WriteLine(count);

            try
            {
                // Write your code here
                Array.Sort(A);                      //Sort input array
                str1 = string.Join("", A);          //Convert array to string
                                                    //str1 = "1112234477";
                for (int i = str1.Length-1; i >= 0; i--)
                {
                    strx = str1.Substring(i, 1);
                    count = Regex.Matches(str1, strx).Count;
                    if (count == 1)
                    {
                        return Int32.Parse(strx);
                    }
                }
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
                //Srikrishna Krishnarao Srinivasan SKS Oct 4 2019
                //Pseudocode
                //1. Read input string. Proper cases: 'abcba', 'abcdcba'; Improper cases: 'abcxba', 'abcdxcba' 'x' can appear anywhere
                //2. Reverse the string. 'abcba' or 'abcdcba' becomes the same. If so, it is palindrome.
                //2a. String with extra 'x' or not as above: when reverse will not be the same. 'abcxba' will be 'abxcba' etc
                //2c. Before making the decision as not-palindrome, try to find 'x' and drop and repeat step 2
                //2d. Case 1: There is an 'x'. 1x23321, 12x3321, 123x321 or 12344321x, 1234432x1, 123443x21.
                //2d.i. Split string into two: If Even length, both are equal strings. If Odd length, first is longer.
                //2d.ii. Convert each string into string array https://stackoverflow.com/questions/11081549/how-to-convert-string-to-string
                //2d.iii. Do a set subraction of string characters. This will give only non matched characters. string [] c = a.Where(x=>!b.Contains(x)).ToArray(); or string [] c = a.Except(b).ToArray(); https://stackoverflow.com/questions/5058609/how-to-perform-set-subtraction-on-arrays-in-c
                //2d.iv. If there is only one character output from above, get it, find it in the string, remove and repeat steps 1 and 2
                //2e. Case 2: There is no 'x' just that it is not palindrome

                //Initialize
                string s_rev = null, s1 = null, s2 = null, snew=null, s_revnew;
                char c1;

                // Write your code here
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                s_rev = string.Join("", charArray);
                //s_rev = s.Reverse().ToArray();
                if (s == s_rev)
                {
                    return true; //String is a palindrome
                }
                else 
                {
                    if (s.Length % 2 == 0) //Even length
                    {
                        s1 = s.Substring(0,s.Length/2);
                        s2 = s.Substring(s.Length/2, s.Length/2);
                    }
                    else //Odd
                    {
                        s1 = s.Substring(0,(s.Length/2)+1);
                        s2 = s.Substring((s.Length/2), (s.Length/2)+1);
                    }
                    //Convert string to array
                    //string[] s1a= new string[]{s1};
                    //string[] s2a= new string[]{s2};
                    char[] s1a = s1.ToCharArray();
                    char[] s2a = s2.ToCharArray();
                    //string c1 = null;
                    //string [] c = s1a.Where(x=>!s2a.Contains(x)).ToArray();
                    char[] c = s1a.Where(x => !s2a.Contains(x)).ToArray();
                    //This will return all characters in s1a[] which don't have a matching value in s2a[].

                    if (c.Length == 0)
                    {
                        c = s2a.Where(x => !s1a.Contains(x)).ToArray();
                        //Reverse search
                    }


                    if (c.Length == 1) //We need to continue only if single character mismatch happens
                    {
                        //Find and drop this character in original string s
                        //reverse the string
                        //if reversed string is same as original string it is a palindrome
                        c1 = c[0];
                        int index1 = s.IndexOf(c1);
                        if (index1 != -1)
                        {
                            snew = s.Remove(index1, 1);
                            char[] charArray1 = snew.ToCharArray();
                            Array.Reverse(charArray1);
                            s_revnew = string.Join("", charArray1);
                            if (snew == s_revnew)
                            {
                                return true; //String is a palindrome
                            }
                            else
                            {
                                return false; //String is not a palindrome
                            }
                        }
                    }
                    else
                    {
                        return false;//More than one character mismatch, hence not a palindrome by dropping one character
                    }
                }

                    

                


            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
