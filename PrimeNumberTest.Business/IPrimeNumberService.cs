using System.Collections.Generic;

namespace PrimeNumberTest.Business
{
    /// <summary>
    /// IPrimeNumberService interface
    /// </summary>
    public interface IPrimeNumberService
    {
        IEnumerable<int> GetAllPrimeNumberWithinRange(int startNumber, int endNumber);
        void GetProductsOfFourPrimeNumbers(int startNumber, int endNumber);
        IList<int> Combinations(IList<int> list);
        IList<int> GetCombinations(int[] input, int arraySize, int combinationSize, int index, int[] combinations, int i);
    }
}
