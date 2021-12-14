using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;

namespace _002_SeleniumWebDriver
{
    [TestFixture]
    public class GoogleExample
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ExampleTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            By searchBtnLocator = By.Name("q");
            IWebElement btn = driver.FindElement(searchBtnLocator);
            btn.Click();
        }
       
    }

}
