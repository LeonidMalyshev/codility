using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winter_lights
{
        class Program
        {
            static void Main(string[] args)
            {
                var rnd = new Random();
                StringBuilder b = new StringBuilder();
                for (int j = rnd.Next(5000, 20000); j > 0; j--)
                    b.Append(rnd.Next(9).ToString());
                string inp = b.ToString();
                var s = new Solution();
                Console.WriteLine(s);
                Console.WriteLine(s.solution(inp));
                Console.WriteLine(s.solutionold(inp));
            }
        }

        //********* Start of code to submit to codility
        public class Solution
        {
            public int solution(string S)
            {
                var len = S.Length;
                if (len == 0) return 0;
                if (len == 1) return 1;
                int result = 1;
                var dic = new Dictionary<char, int>();
                for (int i = 0; i < len; i++)
                    if (dic.ContainsKey(S[i])) dic[S[i]]++;
                    else dic.Add(S[i], 1);
                for (int i = 0;i<len - 1;  i++)
                {
                    result += mefirst(S.Substring(i), dic);
                    dic[S[i]]--;
                } //
                return result;
            }

            private int mefirst(string s, Dictionary<char, int> dic)
            {

                int count = 0;
                int len = s.Length;
                var dicOddEven = new Dictionary<char, bool>();
                foreach (KeyValuePair<char, int> keyValuePair in dic)
                {
                    dicOddEven.Add(keyValuePair.Key,keyValuePair.Value%2==0);
                }
                int evenOdds = dicOddEven.Values.Count(x => !x);
                for (int j = len - 1; j >= 0; j--)
                {
                    if (evenOdds == (j + 1) % 2)
                    {
                        count++;
                    }
                    char c = s[j];
                    if (dicOddEven[c]) evenOdds++;
                    else evenOdds--;
                    dicOddEven[c] = !dicOddEven[c];
                }
                return count;
            }

            public int solutionold(string S)
            {
                var len = S.Length;
                if (len == 0) return 0;
                if (len == 1) return 1;
                int result = 1;
                for (int i = len-2 ; i >= 0; i--)
                    result += mefirstold(S.Substring(i));
                return result;
            }
            private int mefirstold(string s)
            {

                int count = 0;
                int len = s.Length;
                var dic = new Dictionary<char, int>();
                var dicOddEven = new Dictionary<char, bool>();
                for (int i = 0; i < len; i++)
                    if (dic.ContainsKey(s[i])) dic[s[i]]++;
                    else dic.Add(s[i], 1);
                foreach (KeyValuePair<char, int> keyValuePair in dic)
                {
                    dicOddEven.Add(keyValuePair.Key, keyValuePair.Value % 2 == 0);
                }
                int evenOdds = dicOddEven.Values.Count(x => !x);
                for (int j = len - 1; j >= 0; j--)
                {
                    if (evenOdds == (j + 1) % 2)
                    {
                        count++;
                    }
                    char c = s[j];
                    //dic[c]--;
                    if (dicOddEven[c]) evenOdds++;
                    else evenOdds--;
                    dicOddEven[c] = !dicOddEven[c];
                }
                return count;
            }
        }
    }