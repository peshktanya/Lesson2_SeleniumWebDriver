using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace _002_SeleniumWebDriver
{
    public class WebElementTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var pathDriver = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(pathDriver);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void WebElementsPropertiesTest()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

            IWebElement loginBtn = driver.FindElement(By.Id("login-button"));

            bool isDisplayed = loginBtn.Displayed;
            bool isEnabled = loginBtn.Enabled;
            string text = loginBtn.Text;
            string tag = loginBtn.TagName;
            var css = loginBtn.GetCssValue("color");

            IWebElement userNameBtn = driver.FindElement(By.Id("user-name"));
            IWebElement passwordBtn = driver.FindElement(By.Id("password"));

            userNameBtn.SendKeys("someUserName");
            userNameBtn.Clear();
            userNameBtn.SendKeys("SuperName");
            userNameBtn.SendKeys(Keys.Backspace);
            userNameBtn.Submit();

            passwordBtn.SendKeys("qwerty");
            passwordBtn.SendKeys(Keys.Enter);

            loginBtn.Click();

            //Asert
            Assert.That(driver.FindElement(By.CssSelector("*[data-test='error']")).Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }
    }
}
