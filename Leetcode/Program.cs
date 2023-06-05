using System;
using System.Collections.Generic;


/*给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。

 

示例:

给定 nums = [2, 7, 11, 15], target = 9

因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/two-sum
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。*/
namespace Leetcode
{
    class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            /*
            //method 1
            int[] results = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int x = target - nums[i];
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]+nums[j]==target)
                    {
                        results[0] = i;
                        results[1] = j;
                    }
                }
            }

            return results;*/

            //method 2
            Dictionary<int,int> kvs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (kvs.ContainsKey(nums[i]))
                {
                    if (nums[i]*2==target)
                    {
                        return new int[] { i, kvs[nums[i]] };
                    }
                    else
                    {
                        kvs.Add(nums[i],i);//保存值和下标
                    }
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (kvs.ContainsKey(complement)&&kvs[complement]!=i)
                {
                    return new int[]{i,kvs[complement]};
                }
            }

            return new int[] {0, 0};
        }

        public static int[] TwoSum1(int[] nums, int target)
        {
            Dictionary<int, int> numdicDictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]*2==target)
                {
                    return new[] {i, numdicDictionary[nums[i]]};
                }
                else
                {
                    numdicDictionary.Add(nums[i], i);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numdicDictionary.ContainsKey(complement)&&numdicDictionary[nums[i]]!=i)
                {
                    return new[] {numdicDictionary[complement], i};
                }
            }

            return new []{0,0};
        }
        static void Main(string[] args)
        {
            int[] nums = new[] {1,2, 7, 5, 11,4,9};
            int[] result = TwoSum(nums, 20);
            foreach (var VARIABLE in result)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
