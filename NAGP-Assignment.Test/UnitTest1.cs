using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAGP_Assignment;


namespace NAGP_Assignment.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestData()
        {
            Assert.AreEqual("Hello World", "Hello World");
            Assert.AreEqual("1", "1");
            Assert.AreEqual("Hello World1", "Hello World1");
        }
    }
}
