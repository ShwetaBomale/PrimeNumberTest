using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrimeNumberTest.Business;
namespace PrimeNumberTest
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            // Use of dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPrimeNumberService, PrimeNumberService>()
                .BuildServiceProvider();

            Console.WriteLine("============= Welcome to Qrious Test =============");
            // Start and End numbers can be configured in app.config
            int startNumber = Convert.ToInt32(ConfigurationSettings.AppSettings["StartNumber"].ToString());
            int endNumber = Convert.ToInt32(ConfigurationSettings.AppSettings["EndNumber"].ToString());

            var primeNumberService = serviceProvider.GetService<IPrimeNumberService>();
            
            primeNumberService.GetProductsOfFourPrimeNumbers(startNumber, endNumber);
            

            Console.ReadKey();
        }
    }
}