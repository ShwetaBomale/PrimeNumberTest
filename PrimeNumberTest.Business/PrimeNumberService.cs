using System;
using System.Collections.Generic;
using System.Linq;


namespace PrimeNumberTest.Business
{
    /// <summary>
    /// PrimeNumberService class
    /// </summary>
    public class PrimeNumberService : IPrimeNumberService
    {
        public PrimeNumberService()
        {
        }
        /// <summary>
        /// This method return collection of prime numbers within the given range
        /// </summary>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <returns>List of int of all prime numbers</returns>
        public IEnumerable<int> GetAllPrimeNumberWithinRange(int startNumber, int endNumber)
        {
            List<int> _listOfPrimeNumbers = new List<int>();
            //Here I look only for odd numbers as even number cannot be prime except 2
            for (int i = startNumber + 2; i < endNumber; i += 2)
            {
                double squreRoot = Math.Sqrt(i);
                bool isNotPrimeNumber = false;
                for (int j = 0; j < _listOfPrimeNumbers.Count; j++)
                {
                    int loopingNumber = _listOfPrimeNumbers[j];
                    if (loopingNumber > squreRoot)
                    {
                        break;
                    }
                    else if ((i % loopingNumber) == 0)
                    {
                        isNotPrimeNumber = true;
                        break;
                    }
                }
                if (isNotPrimeNumber == false)
                {
                    _listOfPrimeNumbers.Add(i);
                }
            }
            _listOfPrimeNumbers.Add(2);
            return _listOfPrimeNumbers;
        }

        /// <summary>
        /// This method is to loop through to get all possible combinations of four numbers
        /// </summary>
        /// <param name="list"></param>
        public IList<int> Combinations(IList<int> list)
        {
            IList<int> _listOfFourNumbers = new List<int>();
            for (int i = 0; i < list.Count; i++)
                for (int j = i + 1; j < list.Count; j++)
                    for (int k = j + 1; k < list.Count; k++)
                        for (int l = k + 1; l < list.Count; l++)
                        {
                            long multiplicationOfFour = (list[i]) * (list[j]) * (list[k]);
                            multiplicationOfFour = multiplicationOfFour * (list[l]);

                            if (Utilities.IsAcendinbgSequentialOrder(multiplicationOfFour))
                            {
                                _listOfFourNumbers.Add(list[i]);
                                _listOfFourNumbers.Add(list[j]);
                                _listOfFourNumbers.Add(list[k]);
                                _listOfFourNumbers.Add(list[l]);
                                Console.WriteLine("Method 1 - Four numbers whose multiplication is in sequential ascending order are ---------- :");
                                Console.Write(list[i] + " " + list[j] + " " + list[k] + " " + list[l] + " ");
                                Console.WriteLine("");
                                Console.WriteLine($"Multiplication of 4 prime munbers which is in ascending order: {multiplicationOfFour}");                         
                            }
                        }
            return _listOfFourNumbers;
        }

        /// <summary>
        /// This method calls multiple ways to find out four prime number multiplication with 12 digit ascending order
        /// </summary>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        public void GetProductsOfFourPrimeNumbers(int startNumber, int endNumber)
        {
            IEnumerable<int> listOfPrimeNumbers = GetAllPrimeNumberWithinRange(startNumber, endNumber);
            listOfPrimeNumbers = listOfPrimeNumbers.OrderByDescending((i) => i);
            int sizeOfCombination = 4;

            // Consider only three digits prime numbers as four 3 digits numbers can ONLY create a 12 digit multiplication
            listOfPrimeNumbers = from int item in listOfPrimeNumbers
                                 where Convert.ToString(item).ToCharArray().Count() == 3
                                 select item;
            int arraySize = listOfPrimeNumbers.Count();
            
            var watchCombinationTwo = System.Diagnostics.Stopwatch.StartNew();
            Combinations(listOfPrimeNumbers.ToList());
            Console.WriteLine($"time = {watchCombinationTwo.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("==============================================================================================");

            var watchCombinationOne = System.Diagnostics.Stopwatch.StartNew();
            ShowCombinationsOfPrimeNumbers(listOfPrimeNumbers.ToArray(), arraySize, sizeOfCombination);
            Console.WriteLine($"time = {watchCombinationOne.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("==============================================================================================");

        }

        /// <summary>
        /// Get all possible combination of four prime numbers
        /// </summary>
        /// <param name="input">input array</param>
        /// <param name="arraySize">size of array</param>
        /// <param name="combinationSize">size of combination</param>
        /// <param name="index"></param>
        /// <param name="combinations">temp array to store combinations</param>
        /// <param name="i"></param>
        public IList<int> GetCombinations(int[] input, int arraySize, int combinationSize, int index, int[] combinations, int i)
        {
            IList<int> _listOfFourNumbers = new List<int>();
            // Current combination is ready to show
            if (index == combinationSize)
            {
                long multiplicationOfFour = 1;
                for (int j = 0; j < combinationSize; j++)
                {
                    // Get the multiplication of all prime numbers in a given combination combinations[]
                    multiplicationOfFour = multiplicationOfFour * combinations[j];
                }
                // If the multiplication is sequential ascending order number, print it
                if (Utilities.IsAcendinbgSequentialOrder(multiplicationOfFour))
                {
                    Console.WriteLine("Method 2 - Four numbers whose multiplication is in sequential ascending order are ---------- :");
                    for (int j = 0; j < combinationSize; j++)
                    {
                        Console.Write(combinations[j] + " ");
                        _listOfFourNumbers.Add(combinations[j]);                        
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Multiplication of 4 prime munbers which is in ascending order: {multiplicationOfFour}");                    
                }
                return _listOfFourNumbers;
            }

            // When no more elements in combinations[]
            if (i >= arraySize)
                return null;

            // current is included
            combinations[index] = input[i];
            GetCombinations(input, arraySize, combinationSize, index + 1, combinations, i + 1);

            // current is excluded
            GetCombinations(input, arraySize, combinationSize, index,
                            combinations, i + 1);
            return null;
        }

        /// <summary>
        /// The main function that prints all combinations of size combinationSize in input[] of size arraySize
        /// </summary>
        /// <param name="input">input array</param>
        /// <param name="arraySize">size of array</param>
        /// <param name="combinationSize">Number of combination</param>
        public void ShowCombinationsOfPrimeNumbers(int[] input, int arraySize, int combinationSize)
        {
            int[] combinations = new int[combinationSize];

            GetCombinations(input, arraySize, combinationSize, 0, combinations, 0);
        }
    }
}
