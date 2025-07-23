using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Pages;

namespace TestProject1
{

    [TestFixture]
    public class ParametrizedLoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }

        [TestCase("student", "Password123", true, TestName = "Valid credentials")]
        [TestCase("wrong", "wrong", false, TestName = "Invalid credentials")]
        [TestCase("", "12345", false, TestName = "Empty username")]
        public void LoginTestCases(string username, string password, bool shouldSucceed)
        {
            // Act
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();

            // Assert
            if (shouldSucceed)
            {
                Assert.AreEqual("https://practicetestautomation.com/logged-in-successfully/", _driver.Url);
            }
            else
            {
                Assert.AreEqual("Your username is invalid!", _loginPage.GetErrorMessage());
            }
        }


        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver.Dispose();
        }
    }
}
