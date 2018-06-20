using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
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

        public  async Task<long> FindPrimesAsync(int n)
        {
            var task = await Task.Run(() => FindPrimeNumber(n));
            return task;
        }

        
    }
}
