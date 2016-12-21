using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using winter_lights;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rnd = new Random();
            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();
            for (int i = 0; i < 2; i++)
            {
                StringBuilder b= new StringBuilder();
                for (int j = rnd.Next(1, 2000); j > 0; j--)
                    b.Append(rnd.Next(9).ToString());
                var sol = new Solution();
                int r1, r2;
                sw1.Restart();
                r1 = sol.solution(b.ToString());
                sw1.Stop();
                sw2.Restart();
                r2 = sol.solutionold(b.ToString());
                sw2.Stop();
                Assert.AreEqual(r1,r2,b.ToString());
            }
            Debug.WriteLine(string.Format("{0}  {1} {2}", sw1.Elapsed, sw2.Elapsed, (float)sw2.ElapsedMilliseconds/sw1.ElapsedMilliseconds));
        }
    }
}
