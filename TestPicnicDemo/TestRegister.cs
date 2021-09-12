using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPicnicDemo
{
    [TestClass]
    public class TestRegister
    {
        [TestInitialize()]
        public void TestInit()
        {
            PicnicDemo.Register.ResetGrandTotal();
        }

        [TestMethod]
        public void TestConstructor()
        {
            // instantiation causes default values
            PicnicDemo.Register register = new PicnicDemo.Register();
            Assert.AreEqual(0.00M, register.Total);
            Assert.AreEqual(0.00M, PicnicDemo.Register.GrandTotal);
        }

        [TestMethod]
        public void TestMultipleInstantiations()
        {
            // instantiation after sale does not reset grand total
            // multiple register sales increment grand total
            PicnicDemo.Register register1 = new PicnicDemo.Register();
            register1.Sale(1.00M);
            PicnicDemo.Register register2 = new PicnicDemo.Register();
            register2.Sale(1.00M);
            Assert.AreEqual(2.00M, PicnicDemo.Register.GrandTotal);
        }

        [TestMethod]
        public void TestResetGrandTotal()
        {
            // resetgrandtotal sets grandtotal to 0
            PicnicDemo.Register register1 = new PicnicDemo.Register();
            PicnicDemo.Register register2 = new PicnicDemo.Register();
            register1.Sale(1.00M);
            register2.Sale(1.00M);
            PicnicDemo.Register.ResetGrandTotal();
            Assert.AreEqual(0.00M, PicnicDemo.Register.GrandTotal);
        }

        [TestMethod]
        public void TestSale()
        {
            // sale increments total and grandtotal
            PicnicDemo.Register register = new PicnicDemo.Register();
            register.Sale(1.00M);
            Assert.AreEqual(1.00M, register.Total);
            Assert.AreEqual(1.00M, PicnicDemo.Register.GrandTotal);
        }
    }
}
