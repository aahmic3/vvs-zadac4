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
            driver = new ChromeDriver();
            string urlStranice = "https://localhost:44389/Grupa2/Create/";
            driver.Navigate().GoToUrl(urlStranice);
        }
        [TestMethod]
        public void TestLokacijaOvisiOVremenu()
        {
            IWebElement lokacija = driver.FindElement(By.Id("lokacija"));
            lokacija.SendKeys("Bjela�nica");
            Thread.Sleep(500);
            //Ovo vjerotno nismo morali dodavati ali �isto radi prezantativnosti doga�aja
            IWebElement vrijeme = driver.FindElement(By.Id("trajanje"));
            vrijeme.SendKeys("");
            Thread.Sleep(500);

            IWebElement buttonProvjeri = driver.FindElement(By.Id("btnProvjeri"));
            buttonProvjeri.Click();
            Thread.Sleep(500);
            var expectedAlertText = "Za provjeru lokacije morate unijeti vrijeme trajanja...";
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);
            alert_win.Accept();
            Thread.Sleep(500);
        }

    }

}