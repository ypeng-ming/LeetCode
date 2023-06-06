using System;
using System.Collections.Generic;

namespace MaxArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
            MaxArea(x);
        }

        //double pointer
        public static  int MaxArea(int[] height)
        {
                 int max = 0;
                 int size = height.Length;
                 int left = 0, right = size - 1;
                 while (left<right)
                 {
                     max = Math.Max(max, (right - left) * Math.Min(height[left], height[right]));
                     if (height[left]>height[right])
                     {
                         --right;
                     }
                     else
                     {
                         ++left;
                     }
                 }

                 return max;
        }

        private static bool Pass(Dictionary<int, int> temp, int height, int width)
        {
            if (temp.ContainsKey(height)&& temp[height]==width||
                temp.ContainsKey(width)&&temp[width]==height)
            {
                return true;
            }

            return false;
        }
    }

}
