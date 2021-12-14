using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace _002_SeleniumWebDriver
{
    public class WebDriverTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver(Directory.GetCurrentDirectory());
        }
        
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void WebDriverPropertiesTest()
        {
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            driver.Url = "https://www.google.com";
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Minimize();
            driver.Manage().Window.Size = new System.Drawing.Size(1354, 794);
            var title = driver.Title;
            var pageSource = driver.PageSource;
            driver.Close();
        }


        
    }
}