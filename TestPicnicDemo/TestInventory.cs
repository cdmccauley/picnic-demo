using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPicnicDemo
{
    [TestClass]
    public class TestInventory
    {
        [TestMethod]
        public void TestGetCategoryNames()
        {
            // categories are displayed
            PicnicDemo.Inventory inventory = new PicnicDemo.Inventory();
            string expected = "What are you buying, ticket (t) or food (f)?:";
            Assert.AreEqual(expected, $"What are you buying, {string.Join(" or ", inventory.GetCategoryNames())}?:");
        }
    }
}