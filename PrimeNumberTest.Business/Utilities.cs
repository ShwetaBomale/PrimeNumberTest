
namespace PrimeNumberTest.Business
{
    /// <summary>
    /// Utilities class
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Verifies if the Number is sequential ascending order, if yes, returns true
        /// </summary>
        /// <param name="n">Input long number to be verified</param>
        /// <returns></returns>
        public static bool IsAcendinbgSequentialOrder(long n)
        {
            bool isSequencialAscending = true;

            long next = -1;

            while (n != 0)
            {
                if (next == -1)
                {
                    next = n % 10;
                    n = n / 10;
                    continue;
                }

                // Check is the next digit is smaller than previous
                if (next < n % 10)
                {
                    isSequencialAscending = false;
                    break;
                }

                // check if the next digit is equals or more than one of the previous digit
                if (next == n % 10 || next == (n % 10) + 1)
                {
                    next = n % 10;
                    n = n / 10;
                    continue;
                }
                else
                {
                    isSequencialAscending = false;
                    break;
                }
            }

            return isSequencialAscending;
        }
    }
}
