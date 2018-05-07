using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CS20180227B
{
    class Program
    {
        static Thread threadA, threadB;
        static Random RN = new Random();
        static byte A, B ,Nth;
        static int SleepTime;
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Continue？Press Y(y) for yes or else for No? Press Nth? Press SleepTime(ms)?");

                    string [] YN = Console.ReadLine().Split(' ');
                    Nth = byte.Parse(YN[1]);
                    SleepTime = int.Parse(YN[2]);
                    if (YN[0] == "Y" || YN[0] == "y")
                    {
                        A = 0;
                        B = 0;
                        Start();
                        Console.ReadKey();
                    }
                    
                    else return;
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        private static void IMA()
        {
                while (true)
                {

                    System.Threading.Thread.Sleep(RN.Next(0,SleepTime));
                    A++;
                    Console.WriteLine("資一甲(" + A + "):" + System.DateTime.Now); Console.WriteLine();
                if (A == Nth)
                {
                    threadB.Abort();
                    Console.WriteLine("資一甲 : Winner");
                    Console.WriteLine("Press Enter To Continue");
                    threadA.Abort();
                }
                }
        }
        private static void IMB()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(RN.Next(0,SleepTime));
                B++;
                Console.WriteLine("資一乙(" + B + "):" + System.DateTime.Now); Console.WriteLine();
                if (B == Nth)
                {
                    threadA.Abort();
                    Console.WriteLine("資一乙 : Winner");
                    Console.WriteLine("Press Enter To Continue");
                    threadB.Abort();
                }
            }
        }
        private static void Start()
        {
            threadA = new Thread(new ThreadStart(IMA));
            threadB = new Thread(new ThreadStart(IMB));

            threadA.Start();
            threadB.Start();

        }
    }

}
