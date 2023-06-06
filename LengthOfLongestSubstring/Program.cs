using System;
using System.Collections.Generic;

namespace LengthOfLongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcabcbb";//"";//dvdf
            LengthOfLongestSubstring(s);
        }
        public static int LengthOfLongestSubstring(string s)
        {
            #region answer1

            //HashSet<char> set = new HashSet<char>();
            //int max = 0;
            //int size = s.Length;
            //int left = 0;
            //int right = 0;
            //while (right < size)
            //{
            //    if (!set.Contains(s[right]))
            //    {
            //        set.Add(s[right]);
            //        right++;
            //    }
            //    else
            //    {
            //        set.Remove(s[left]);
            //        left++;
            //    }

            //    max = Math.Max(max, set.Count);
            //}

            //return max;

            #endregion
            int [] last = new int[256];
            //for (int i = 0; i < 256; i++)
            //{
            //    last[i] = -1;
            //}

            int max = 0;
            int start = 0;
            int size = s.Length;

            for (int i = 0; i < size; i++)
            {
                int index = s[i];//get ascii code
                start = Math.Max(start, last[index] );
                max = Math.Max(max, i - start + 1);
                last[index] = i+1;
            }

            return max;
        }
    }
}
