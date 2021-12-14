using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace _002_SeleniumWebDriver
{
    [TestFixture]
    public class DemoTestClass
    {
        private IWebDriver driver;
        private const string LOGIN = "standard_user";
        private const string PASSWORD = "secret_sauce";

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        [Test]
        public void OpenProductsPageTest()
        {
            IWebElement userNameElement = driver.FindElement(By.Id("user-name"));
            IWebElement passwordElement = driver.FindElement(By.Id("password"));
            IWebElement loginBtn = driver.FindElement(By.Id("login-button"));
            
            userNameElement.SendKeys(LOGIN);
            passwordElement.SendKeys(PASSWORD);
            loginBtn.Click();

            IWebElement productsText = driver.FindElement(By.ClassName("title"));
            
            var productsTxt = productsText.Text;
            Assert.That(productsTxt.ToLower().Contains("Products".ToLower()));
        
        }

        [Test]
        public void CheckErrorWhenInvalidUserName()
        {
            driver.FindElement(By.Id("user-name")).SendKeys("username");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.CssSelector("*[data-test='login-button']")).Click();
            Assert.That(driver.FindElement(By.CssSelector("*[data-test='error']")).Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }
    }
}
