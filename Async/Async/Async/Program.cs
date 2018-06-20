using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        public class FindPrime
        {
            public long FindPrimeNumber(int n)
            {
                int count = 0;
                long a = 2;
                while (count < n)
                {
                    long b = 2;
                    int prime = 1;

                    while (b * b <= a)
                    {
                        if (a % b == 0)
                        {
                            prime = 0;
                            break;
                        }
                        b++;
                    }
                    if (prime > 0)
                    {
                        count++;
                    }
                    a++;
                }
                return (--a);
            }

            public async Task<long> FindPrimesAsync(int n)
            {
                var task = await Task.Run(() => FindPrimeNumber(n));
                return task;
            }

            public void FindPrimes(FindPrime fp, int n, int c)
            {
                Console.WriteLine(DateTime.Now);
                var a = fp.FindPrimesAsync(n);
                Console.WriteLine(DateTime.Now);
                var b = fp.FindPrimesAsync(c);
                Console.WriteLine(DateTime.Now);

                Console.WriteLine(a.Result);
                Console.WriteLine(b.Result);
                Console.WriteLine(DateTime.Now);
            }
        }
        public static void CallToChildThread()
        {
            var fp = new FindPrime();
            Console.WriteLine("Child Thread starts " + DateTime.Now);
            Console.WriteLine(fp.FindPrimeNumber(250000).ToString());
            Console.WriteLine("Child Thread ends " + DateTime.Now);
        }

        public static void CallToChildThread2()
        {
            var fp = new FindPrime();
            Console.WriteLine("Child Thread2 starts " + DateTime.Now);
            Console.WriteLine(fp.FindPrimeNumber(400000).ToString());
            Console.WriteLine("Child Thread2 ends " + DateTime.Now);
        }

        static void Main(string[] args)
        {
            FindPrime fp = new FindPrime();
            //ThreadStart childref = new ThreadStart(CallToChildThread);
            //Thread childThread = new Thread(childref);
            //ThreadStart childref2 = new ThreadStart(CallToChildThread2);
            //Thread childThread2 = new Thread(childref2);

            //childThread.Start();
            //childThread2.Start();
            fp.FindPrimes(fp, 250000, 400000);
            


            Console.ReadKey();
        }
    }
}
