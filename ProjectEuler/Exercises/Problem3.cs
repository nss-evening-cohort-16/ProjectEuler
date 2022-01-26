using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Exercises
{
    internal class Problem3
    {
        public void Execute()
        {

            Console.WriteLine(LargestPrimeFactor(2)); //should return a number.
            Console.WriteLine(LargestPrimeFactor(2)); //should return 2.
            Console.WriteLine(LargestPrimeFactor(3)); //should return 3.
            Console.WriteLine(LargestPrimeFactor(5)); //should return 5.
            Console.WriteLine(LargestPrimeFactor(7)); //should return 7.
            Console.WriteLine(LargestPrimeFactor(8)); //should return 2.
            Console.WriteLine(LargestPrimeFactor(13195)); //should return 29.
            Console.WriteLine(LargestPrimeFactor(600851475143)); //should return 6857.
        }

        public long LargestPrimeFactor(long number)
        {
            long largestPrime = 0;
            Dictionary<int, bool?> factors = new Dictionary<int, bool?>();
            
            // ? indicates a nullable type
            //bool can only be `true` or `false`
            //bool? can be `true` `false` or `null`
            //int? example = null; //value types need a `?` to be nullable
            //Dictionary<string, string> otherExample = null; //reference types can be null by default

            //find the factors

            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i, null);
                }
            }

            /*
             * {
             *  3, null
             *  9, null
             * }
             */

            //find the prime factors
            //factors.ForEach();
            foreach (var item in factors) //3, null
            {
                List<int> tempFac = new List<int>();

                for (int i = 2; i < item.Key; i++)
                {
                    if (item.Key % i == 0)
                    {
                        tempFac.Add(i);
                    }
                }

                //if a factor is prime, set its value from null to true
                //if it isn't prime, set its value from null to false
                if (item.Key == 2)
                {
                    factors[item.Key] = true;
                }
                else if (item.Key % 2 == 0 || tempFac.Count > 0)
                {
                    factors[item.Key] = false;
                }
                else
                {
                    factors[item.Key] = true;
                }
            }

            /*
             * {
             *  3, true
             *  9, false
             * }
             */

            var primeFactors = factors.Where(f => f.Value == true).Select(kvp => kvp.Key);

            //find the largest prime factor
            largestPrime = primeFactors.Max();

            return largestPrime;
        }


    }
}
