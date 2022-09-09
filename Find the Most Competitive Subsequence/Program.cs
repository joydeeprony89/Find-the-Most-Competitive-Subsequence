using System;
using System.Collections.Generic;

namespace Find_the_Most_Competitive_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var nums = new int[] { 3, 5, 2, 6 };
            var answer = s.MostCompetitive(nums, 2);
            Console.WriteLine(string.Join(",", answer));
        }
    }

    public class Solution
    {
        public int[] MostCompetitive(int[] nums, int k)
        {
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int current = nums[i];
                while (stk.Count > 0 && current < nums[stk.Peek()] && stk.Count + (nums.Length - i) > k)
                {
                    stk.Pop();
                }

                // we will push only till stack size less than k
                if (stk.Count < k)
                {
                    stk.Push(i);
                }
            }

            var result = new int[k];
            // As stack is LIFO, will be adding in result from the end
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = nums[stk.Pop()];
            }

            return result;
        }
    }
}
