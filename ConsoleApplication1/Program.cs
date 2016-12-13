using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            string inp = "bccab";//acdb
            var s = new Solution();
            var x1 = s.RemoveDuplicateLetters(inp);
            Console.WriteLine("Data: "+inp);
            Console.WriteLine("Result: "+x1);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string RemoveDuplicateLetters1(string s)
        {
            var ms = new StringBuilder();
            var len = s.Length;
            var ic = ' ';
            for (int i = 0; i < len; i++)
            {
                if (ic == ' ' || ic != s[i]) ms.Append(s[i]);
                ic = s[i];
            }
            s = ms.ToString();
            len = s.Length;
           // Console.WriteLine(s);
            var dict= new Dictionary<char,int>();
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
            int leftChars = dict.Values.Count;
            char candidate1=' ', candidate2=' ';
            int pos1 = 0, pos2=pos1+1;
            while (leftChars>0)
            {
                if (candidate1 == ' ')
                    for (; pos1 < len; pos1++)
                    {
                        candidate1 = s[pos1];
                        if (dict[candidate1]>0) break;
                    }

                if (dict[candidate1] == 1 )
                {
                    //Console.WriteLine(candidate1+" as 1");
                    result.Append(candidate1);
                    dict[candidate1]--;
                    leftChars--; 
                    candidate1 = ' ';
                    pos1++;
                    pos2 = pos1 + 1;
                    continue;
                }
                if (candidate2 == ' ')
                    for (; pos2 < len; pos2++)
                    {
                        candidate2 = s[pos2];
                        if (dict[candidate2] > 0) break;
                    }
                if (dict[candidate2] == 1) /////
                {
                    var c = (candidate1 < candidate2) ? candidate1 : candidate2;
                    result.Append(c);
                    //Console.WriteLine(c+" as 1 from "+candidate1+" and "+candidate2);
                    leftChars--;
                    dict[c]=0;
                    if (c == candidate1)
                    {
                        pos1++;
                        pos2 = pos1 + 1;
                        dict[candidate1]--;
                        candidate1 = ' ';
                        candidate2 = ' ';
                        continue;
                    }
                    pos1 = pos2 + 1;
                    pos2 = pos1 + 1;
                    dict[candidate1]--;
                    candidate1 = ' ';
                    candidate2 = ' ';
                }
                else
                {
                    var c = (candidate1 < candidate2) ? candidate1 : candidate2;
                    if (c == candidate1)
                    {
                        pos2++;
                        dict[candidate2]--;
                        candidate2 = ' ';
                    }
                    else
                    {
                        pos1 = pos2;
                        pos2 = pos1 + 1;
                        dict[candidate1]--;
                        candidate1 = c;
                        candidate2 = ' ';
                    }
                }
               // Console.WriteLine(pos1+"  "+pos2);
            }
            return result.ToString();

        }

        private int len;
        public string RemoveDuplicateLetters(string s)
        {
            var result = new StringBuilder();
            len = s.Length;
            var dict = new Dictionary<char,int>();
            for (int i = 0; i < len; i++)
            {
                char c = s[i];
                if (dict.ContainsKey(c)) dict[c]++;
                else dict.Add(c,1);
            }
            for (int i = 0; i < len; i++)
            {
                char orig = s[i];
                if (dict[orig]==0) continue;
                if (dict[orig] == 1)
                {
                    result.Append(orig);
                   // Console.WriteLine(orig+" as 1");
                    dict[orig]=0;
                    continue;
                }
                var pair = FindPair(orig, i, s, dict);
                if (!pair.HasValue)
                {
                    result.Append(orig);
                   // Console.WriteLine(orig + " as single");
                    dict[orig]=0;
                    continue;
                }
                if (/*dict[pair.Value] == 1 && */orig < pair.Value)
                {
                    result.Append(orig);
                    //Console.WriteLine(orig + " from "+orig+" and "+pair.Value);
                    dict[orig]=0;
                    continue;
                }
                dict[orig]--;
            }
            return result.ToString();
        }

        private char? FindPair(char orig, int origpos, string toScan, Dictionary<char, int> dictionary )
        {
            //var len = toScan.Length;
            if (origpos + 1 >= len) return null;
            var dic = new Dictionary<char,int>();
            for (int i = origpos + 1; i < len; i++)
            {
                char c = toScan[i];
                if (dic.ContainsKey(c)) dic[c]++;
                else dic.Add(c,1);
                if (dictionary[c] == 1) return c;  //single
                if (dictionary[c]==0) continue;
                if (c < orig) return c; //smaller
                if (i == len - 1 && c != orig) return c;
                if (dic[c] == dictionary[c]) return c;
            }
            return null;
        }
    }
}