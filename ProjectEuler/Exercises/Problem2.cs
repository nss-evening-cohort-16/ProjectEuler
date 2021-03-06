using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Exercises
{
    internal class Problem2
    {
        //Each new term in the Fibonacci sequence is generated by adding the previous two terms.
        //By starting with 1 and 2, the first 10 terms will be:
        //   1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        //By considering the terms in the Fibonacci sequence whose values do not exceed n, find the sum of the even-valued terms.
        private List<int> _sequence;
        private int _sum = 0;

        public void FiboEvenSum(int num)
        {

            //get fibonacci sequence values less than 'num'
            GetSequence(num);

            //sum up even numbers
            GetEvenSum();

            Console.WriteLine(_sum);
        }

        private void GetEvenSum()
        {
            _sum = 0;

            foreach (var num in _sequence)
            {
                if (num % 2 == 0)
                {
                    _sum += num;
                }
            }
        }

        private void GetSequence(int num)
        {
            _sequence = new List<int>() { 1, 2 };
            var currentNumber = 2;
            var previousNumber = 1;

            //for loop is generally less readable than a while in this case,
            //while useful when waiting for a certain condition to be met
            
            //for (int i = currentNumber + previousNumber; i <= num; i += previousNumber)   
            //{
            //    _sequence.Add(i);
            //    previousNumber = currentNumber;
            //    currentNumber = i;
            //}


            //currentNumber + previousNumber = newNumber
            while (currentNumber + previousNumber <= num)
            {

                //var currentNumber = _sequence[_sequence.Count - 1];
                //var previousNumber = _sequence[_sequence.Count - 2];

                var newNumber = currentNumber + previousNumber;
                _sequence.Add(newNumber);

                previousNumber = currentNumber;
                currentNumber = newNumber;

            }

        }

        public void Execute()
        {

            FiboEvenSum(10); //10
            FiboEvenSum(34); //44
            FiboEvenSum(60); //44
            FiboEvenSum(1000); //798
            FiboEvenSum(100000); //60696
            FiboEvenSum(4000000); //4613732

        }


    }
}
