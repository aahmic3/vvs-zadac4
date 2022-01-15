using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BlackBoxTestiranje
{

    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;
        [ClassInitialize]
        public static void Inicijalizacija(TestContext context)
        {
            IWebDriver driver = new ChromeDriver();
            string urlStranice = "https://localhost:44389/Grupa2";
            driver.Navigate().GoToUrl(urlStranice);
        }

        [TestMethod]
        public void TestProvjereLokacije()
        {
           
        }

    }

}