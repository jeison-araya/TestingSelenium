using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestingSelenium
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
        
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://eaapp.somee.com");
        }

        [Test]
        public void TestLogin()
        {
            // Go to login page
            driver.FindElement(By.Id("loginLink")).Click();

            // Set username
            var UsernameInput = driver.FindElement(By.Id("UserName"));
            Assert.That(UsernameInput.Displayed, Is.True);
            UsernameInput.SendKeys("admin");

            // Set password
            var PasswordInput = driver.FindElement(By.Id("Password"));
            Assert.That(PasswordInput.Displayed, Is.True);
            PasswordInput.SendKeys("password");

            // Click login
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();

            // Check employee list
            var employeeListLink = driver.FindElement(By.LinkText("Employee Details"));
            Assert.That(employeeListLink.Displayed, Is.True);

            // Click log off
            driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[2]/a")).Click();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}