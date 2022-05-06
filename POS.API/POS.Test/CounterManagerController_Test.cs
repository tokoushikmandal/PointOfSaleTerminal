using NUnit.Framework;
using POS.Application.Business;
using POS.Application.Services;
using POS.Infrastructure.Base;

namespace POS.Test
{
    public class CounterManagerController_Test
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CounterManager_CalculateTotal_TestCase()
        {
            ////Arrange
            CartService cart = new CartService();
            ProductRepository repo = new ProductRepository();
            Calculator calc = new Calculator(repo);

            CounterManager counterManager = new CounterManager(cart, calc, repo);

            //ACT          
            double result = counterManager.ProcessAndCalculateTotal("ABCDABA");
            double result2 = counterManager.ProcessAndCalculateTotal("CCCCCCC");
            double result3 = counterManager.ProcessAndCalculateTotal("ABCD");

            ////ASSERT
            Assert.AreEqual(13.25, result);
            Assert.AreEqual(6, result2);
            Assert.AreEqual(7.25, result3);
        }
    }
}