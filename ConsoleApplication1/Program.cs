using System;
using System.Collections.Generic;
using System.Diagnostics;

// https://codility.com/programmers/task//

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp = "54577";
            var s = new Solution();
            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();
            sw1.Start();
            var x1 = s.solution(inp);
            sw1.Stop();
            sw2.Start();
            var x2 = s.solution2(inp);
            sw2.Stop();
            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.WriteLine(sw1.Elapsed+"    "+sw2.Elapsed);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int solution(string S)
        {
            var len = S.Length;
            int count = 0;
            var oddDict = new Dictionary<char,int>();
            for (int k=0;k<10;k++)
                oddDict.Add(k.ToString()[0],-1);
            for (int i = 0; i < len; i++)
            {
                oddDict.Clear();
                for (int k = 0; k < 10; k++)
                    oddDict.Add(k.ToString()[0], -1);
                oddDict[S[i]] = 1;
                int res = 0;
                for (int j = i; j < len;)
                {
                    res += oddDict[S[j]] ;
                    if (res <= 1)
                    {
                        if (res == (j - i + 1)%2)
                        {
                            count++;
                        }
                    }
                    j++;
                    if(j<len) oddDict[S[j]] = -oddDict[S[j]];
                }
                oddDict[S[i]] = -oddDict[S[i]];
            }
            return count;
        }



        public int solution2(string S)
        {

            var len = S.Length;
            int count = 0;
            var oddDict = new Dictionary<char, int>();
            for (int k = 0; k < 10; k++)
                oddDict.Add(k.ToString()[0], -1);
            for (int i = 0; i < len; i++)
            {
                oddDict.Clear();
                for (int k = 0; k < 10; k++)
                    oddDict.Add(k.ToString()[0], -1);
                oddDict[S[i]] = 1;
                int res = 0;
                for (int j = i; j < len; )
                {
                    res += oddDict[S[j]];
                    if (res <= 1)
                    {
                        if (res == (j - i + 1) % 2)
                        {
                            count++;
                        }
                    }
                    j++;
                    if (j < len) oddDict[S[j]] = -oddDict[S[j]];
                }
                oddDict[S[i]] = -oddDict[S[i]];
            }
            return count;
        }

    }
 }