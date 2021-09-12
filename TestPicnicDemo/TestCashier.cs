using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPicnicDemo
{
    [TestClass]
    public class TestCashier
    {
        [TestMethod]
        public void TestConvertCharToName()
        {
            // instantiation causes default values
            PicnicDemo.Cashier cashier = new PicnicDemo.Cashier();
            Assert.AreEqual("raffle ticket", cashier.ConvertCharToName('r'));
            
            Assert.AreEqual("soda", cashier.ConvertCharToName('s'));
            Assert.AreEqual("cotton candy", cashier.ConvertCharToName('c'));
            Assert.AreEqual("hot dog", cashier.ConvertCharToName('h'));
        }
    }
}