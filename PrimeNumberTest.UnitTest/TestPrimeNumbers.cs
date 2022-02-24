using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PrimeNumberTest.Business;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace PrimeNumberTest.UnitTest
{
    [TestClass]
    public class TestPrimeNumbers
    {
        private readonly IPrimeNumberService _primeNumberService;
        [SetUp]
        public void Setup()
        {
        }
        public TestPrimeNumbers()
        {
            _primeNumberService = new PrimeNumberService();
        }

        /// <summary>
        /// Test to verify the count of prime numbers 
        /// </summary>
        [TestMethod]
        public void TestGetProductsOfFourPrimeNumbers()
        {
            IEnumerable<int> listOfPrimeNumbers = _primeNumberService.GetAllPrimeNumberWithinRange(1,1000);
            NUnit.Framework.Assert.AreEqual(listOfPrimeNumbers.Count(), 168);
        }

        /// <summary>
        /// Test to verify those four prime numbers whose multiplication is sequential ascending order
        /// </summary>
        [TestMethod]
        public void TestCombinations()
        {
            IEnumerable<int> listOfPrimeNumbers = _primeNumberService.GetAllPrimeNumberWithinRange(1, 1000);
            listOfPrimeNumbers = listOfPrimeNumbers.OrderByDescending((i) => i);
            
            listOfPrimeNumbers = from int item in listOfPrimeNumbers
                                 where Convert.ToString(item).ToCharArray().Count() == 3
                                 select item;
            IList<int> resultPrimeNumbers = _primeNumberService.Combinations(listOfPrimeNumbers.ToList());
            IList<int> expectedResultNummbers = new List<int>() { 863, 811, 563, 313 };

            List<int> notMatching = expectedResultNummbers.Where(x => !resultPrimeNumbers.Contains(x)).ToList();
            NUnit.Framework.Assert.IsTrue(notMatching.Count == 0);
            
        }

        /// <summary>
        /// Test to verify those four prime numbers whose multiplication is sequential ascending order
        /// </summary>
        [TestMethod]
        public void TestCombinationsNegative()
        {
            IEnumerable<int> listOfPrimeNumbers = _primeNumberService.GetAllPrimeNumberWithinRange(1, 1000);
            listOfPrimeNumbers = listOfPrimeNumbers.OrderByDescending((i) => i);

            listOfPrimeNumbers = from int item in listOfPrimeNumbers
                                 where Convert.ToString(item).ToCharArray().Count() == 3
                                 select item;
            IList<int> resultPrimeNumbers = _primeNumberService.Combinations(listOfPrimeNumbers.ToList());
            IList<int> expectedResultNummbers = new List<int>() { 863, 811, 563, 303 };

            List<int> notMatching = expectedResultNummbers.Where(x => !resultPrimeNumbers.Contains(x)).ToList();
            NUnit.Framework.Assert.IsFalse(notMatching.Count == 0);

        }

        [TestMethod]
        public void TestIsAcendingSequentialOrder()
        {
            NUnit.Framework.Assert.IsTrue(Utilities.IsAcendinbgSequentialOrder(123445678999));
            NUnit.Framework.Assert.IsFalse(Utilities.IsAcendinbgSequentialOrder(123445789997));
        }
    }
}
