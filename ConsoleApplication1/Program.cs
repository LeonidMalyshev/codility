using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

//https://leetcode.com/problems/remove-duplicate-letters/
using System.Text;

//leetcode.com/problems/remove-duplicate-letters/

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp = "cbacdcbc";//acdb
            var s = new Solution();
            var x1 = s.RemoveDuplicateLetters(inp);
            Console.WriteLine(x1);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string RemoveDuplicateLetters(string s)
        {
            var dict= new Dictionary<char,int>();
            var len = s.Length;
            StringBuilder result= new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var c = s[i];
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c,1);
                }
                else
                {
                    dict[c]++;
                }
            }
            dict.OrderBy(x=>x.Value).ThenBy(y=>y.Key).ToList().ForEach(item=>result.Append(item.Key));
            return result.ToString();

        }
    }
}