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
        public void TestProvjereLokacije()
        {
            IWebElement lokacija = driver.FindElement(By.Id("lokacija"));
            lokacija.Clear();
            lokacija.SendKeys("Vlašić");
            Thread.Sleep(500);

            IWebElement buttonProvjeri = driver.FindElement(By.Id("btnProvjeri"));
            buttonProvjeri.Click();
            Thread.Sleep(500);

            var expectedAlertText = "Podržane su samo lokacije izleta na okolnim sarajevskim planinama!";
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);
            alert_win.Accept();

            lokacija.Clear();
            Thread.Sleep(1000);


            buttonProvjeri.Click();
            Thread.Sleep(1000);

            var alert_win2 = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win2.Text);
            alert_win.Accept();
        }
        [TestMethod]
        public void TestLokacijaOvisiOVremenu()
        {
            IWebElement lokacija = driver.FindElement(By.Id("lokacija"));
            lokacija.SendKeys("Bjelašnica");
            Thread.Sleep(500);
            //Ovo vjerotno nismo morali dodavati ali èisto radi prezantativnosti dogaðaja
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

        [TestMethod]
        public void TestProvjeriVrijemeTrajanja()
        {

            IWebElement lokacija = driver.FindElement(By.Id("lokacija"));
            lokacija.SendKeys("Igman");
            Thread.Sleep(500);

            IWebElement vrijeme = driver.FindElement(By.Id("trajanje"));
            vrijeme.SendKeys("0.001");
            Thread.Sleep(500);

            IWebElement buttonProvjeri = driver.FindElement(By.Id("btnProvjeri"));
            buttonProvjeri.Click();
            Thread.Sleep(500);

            var expectedAlertText = "Na Igmanu se mora provesti više od dvije minute!";
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);
            alert_win.Accept();
            Thread.Sleep(500);

        }


    }

}