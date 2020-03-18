using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkout;

namespace CheckoutTest
{
    [TestClass]
    public class CheckoutTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AutoCheckout check = new AutoCheckout();

            // buy three packs of toothpaste, special offer should be used
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);

            // buy two packs of coffee, special offer should be used
            check.AddItem(4);
            check.AddItem(4);

            // buy 2.5kg Groud Beef
            check.AddItem(7, 2.5);

            // buy 2.7kg Apples, if other iterm > 150 kr, special offers should be used
            check.AddItem(5, 2.7);

            double s = check.Sum();
            double expectedS = 24.95 * 2 + 40 + 93 * 2.5 + 2.7 * 16.95;

            Assert.AreEqual(expectedS, s, 0.1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            AutoCheckout check = new AutoCheckout();

            // buy three packs of toothpaste, special offer should be used
            check.AddItem(1);
            check.AddItem(1);

            // buy 2.5kg Groud Beef
            check.AddItem(2, 3.5);
            check.AddItem(3, 3);

            // buy two packs of coffee, special offer should be used
            check.AddItem(4);
            check.AddItem(4);
            check.AddItem(4);

            // buy 2.7kg Apples, if other iterm > 150 kr, special offers should be used
            check.AddItem(5, 2.7);

            check.AddItem(6, 8);
            check.AddItem(8, 3);

            double s = check.Sum();
            double expectedS = 24.95 * 2 + 40 + 22.49 + 59 * 3.5 + 2.7 * 16.95 
                + 3 * 11.95 + 11.95 * 8 + 9.32 * 3;

            Assert.AreEqual(expectedS, s, 0.1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // in this test case, total price witout apple is 149.7 < 150
            // the price of apple should be original price : 32.95/kg

            AutoCheckout check = new AutoCheckout();

            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);

            check.AddItem(5, 2.5);

            double s = check.Sum();
            double expectedS = 24.95 * 6 + 2.5 * 32.95;

            Assert.AreEqual(expectedS, s);
        }
    }
}
