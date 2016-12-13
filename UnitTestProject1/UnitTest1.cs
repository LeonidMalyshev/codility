using System;
using System.Diagnostics;
using System.Text;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = new Solution();
            var rnd = new Random();
            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                StringBuilder pat = new StringBuilder();
                for (int j = rnd.Next(200); j > 0; j--)
                    pat.Append(rnd.Next(0, 9));
                sw1.Start();
                var x1 = s.solution2(pat.ToString());
                sw1.Stop();
                sw2.Start();
                var x2 = s.solution(pat.ToString());
                sw2.Stop();
                Assert.AreEqual(x1,x2, pat.ToString());
            }
            Console.WriteLine(sw2.Elapsed+"    "+ sw1.Elapsed + "  "+sw1.ElapsedMilliseconds/sw2.ElapsedMilliseconds);
        }
        
    }

}