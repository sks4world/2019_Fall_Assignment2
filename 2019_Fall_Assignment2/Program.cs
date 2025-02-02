﻿/*
 Authors: Srikrishna Krishnarao Srinivasan
          Pragati Shukla
          Avinash Narra
 Project: Assignment 2 Fall 2019
*/
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 2;
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

            //FlipAndInvertImage
            int[,] a = { { 1, 1, 0, 0 }, { 1, 0, 0, 1 }, { 0, 1, 1, 1 }, { 1, 0, 1, 0 } };
            int[,] b = new int[a.GetLength(0), a.GetLength(1)];
            b=FlipAndInvertImage(a);

            for (int i=0;i<b.GetLength(0);i++)
            {
             for(int j=0;j<b.GetLength(1);j++)
                {
                    Console.Write(b[i,j]);
                }
                Console.WriteLine();
            }

            //Minimummeetingrooms
            int[,] intervals = { { 40, 30 }, { 20, 10 }, { 15, 20 } };
            Console.WriteLine(MinMeetingRooms(intervals));

            int[] input = { -4, -1, 0, 3, 10 };
            int[] o = new int[input.Length];
            o = SortedSquares(input);
            for(int j=0;j<o.Length;j++)
            {
                Console.Write(o[j]+" ");
            }

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
                /*
                 Pragati Shukla
                 Pseudocode:
                 As the array is sorted, can check if the Target is less than the first element,
                 I it is, can simply insert it on the 1st postion.
                 If greater than that then compare with current and next element.
                 As the array is sorted, if value is greater than current element and less than next, must be inserted in between those two
                 Return that indexx value.
                 If the target is greater than Last element, return last index+1.
                 */
                int start = 0;
                int end = nums.Length - 1;
                if (target<=nums[start] )
                    return start;
                if (target > nums[end])
                    return end + 1;        
                for (int i=0;i<end;i++)
                 {
                 if(target==nums[i])
                 return i;
                 if(target>nums[i] && target <nums[i+1])
                 return i+1;

                 }
                return -1;
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
                /*Pragati Shukla
                 Pseudocode:
                 Sort both the Arrays.
                 Keep comparing the values for each element using a loop.
                 If the first value of array 1 matches with the first one of Array2, Add this vlaue to a list.
                 Else There would be two cases, 
                 Case1.The value of current element from Array1 is less than Array2--in this case move to next element in array 1.
                 Case2.The value of current element from Array1 is greater than Array2--in this case move to next element in array 2.
 */
                Array.Sort(nums1);
                Array.Sort(nums2);
                var mylist = new List<int>();
                int i = 0;
                int j = 0;

                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] == nums2[j])
                    {
                        mylist.Add(nums1[i]);
                        i++;
                        j++;
                    }
                    else if (nums1[i] < nums2[j])
                    {
                        i++;
                    }
                    else if (nums1[i] > nums2[j])
                    {
                        j++;
                    }

                }
                return mylist.ToArray();



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
            //SKS: Srikrishna Krishnarao Srinivasan Oct 6 2019
            // Pseudocode
            //1. Read input keyboard and word, say "abcdef" (0 to 5) and "face" (5 0 2 4), movements (0 to 5), (5 to 0), (0 to 2) and (2 to 4)
            //2. Store the keyboard in a Dictionary - Key = character, value = digit 0 to length of string
            //3. Read second string, first and second character and find their values. 
            //3a. Read difference between the two. Store the difference in a sum variable.
            //3b. Hold the second number and read the third character value. Find the difference and add to sum.
            //3c. Repeat until end of the string 2 is reached and report the answer.
            //4. Boundary conditions: i. single character ii. All characters same iii. very long string iv. repeating pattern string

            try
            {
                // Write your code here
                //Initialize
                int sum = 0, v = 0, v1 = 0, v2=0 ;
                string c=null, w1=null, w2=null;

                Dictionary<string, int> chrval = new Dictionary<string, int>();
                for (int i = 0; i < keyboard.Length; i++)
                {
                    c = keyboard.Substring(i, 1);
                    v = i;
                    chrval.Add(c, v); //Store in dictionary
                }
                
                for (int i=0; i< word.Length; i++)
                {
                    if (i==0)
                    {
                        w1 = word.Substring(i, 1);
                        v1 = chrval[w1]; //Lookup value from dictionary
                        sum = v1;
                    }
                    else // i>0
                    {
                        //w1 = word.Substring(i - 1, 1);
                        w2 = word.Substring(i, 1);
                        v2 = chrval[w2];
                        sum += Math.Abs(v1 - v2); //Keep a running sum of (charx-1, charx)

                        w1 = w2; //After looking up the val, set current char as previous char
                        v1 = v2;
                    }
                }
                return (sum);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            int[,] b = new int[A.GetLength(0), A.GetLength(1)];
            try
            {
                
               for (int i = 0; i < A.GetLength(0); i++)
                {
                int k = 0;
                  for (int j = A.GetLength(1) - 1; j >= 0; j--)
                  {

                    b[i, k] = A[i, j];
                    k++;
                  }
                }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (b[i, j] == 0)
                    {
                        b[i, j] = 1;
                    }
                    else
                    {
                        b[i, j] = 0;
                    }


                }
            }
                
            
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }
            return b;


        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                int[] d = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int j = 0, k = 0, t = 0;
                if (intervals[i, j] > intervals[i, j + 1])
                {

                    t = intervals[i, j];
                    intervals[i, j] = intervals[i, j + 1];
                    intervals[i, j + 1] = t;

                    k = intervals[i, j + 1] - intervals[i, j];
                    d[i] = k;
                }
                else
                {
                    k = intervals[i, j + 1] - intervals[i, j];
                    d[i] = k;
                }

            }
            Array.Sort(d);
            return d[0];
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
               for (int i = 0; i < A.Length; i++)
            {
                A[i] = A[i] * A[i];

            }
            Array.Sort(A);
            return A;
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
