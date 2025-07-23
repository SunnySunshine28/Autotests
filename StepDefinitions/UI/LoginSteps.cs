using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProject1.Pages;
using TestProject1.Support;

namespace TestProject1.StepDefinitions.UI
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;

        [Given(@"Я открываю страницу логина ""(.*)""")]
        public void GivenOpenLoginPage(string url)
        {
            Driver.Initialize();
            Driver.WebDriver.Navigate().GoToUrl(url);
            _loginPage = new LoginPage(Driver.WebDriver);
            Assert.IsTrue(_loginPage.IsPageLoaded());
        }

        [When(@"Я ввожу логин ""(.*)"" и пароль ""(.*)""")]
        public void WhenEnterCredentials(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [When(@"Я нажимаю кнопку входа")]
        public void WhenClickLoginButton()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"Я должен быть перенаправлен на главную страницу")]
        public void ThenShouldBeRedirectedToDashboard()
        {
            Assert.AreEqual("https://practicetestautomation.com/logged-in-successfully/",
                Driver.WebDriver.Url);
            Driver.Quit();
        }

        [Then(@"Должно отображаться сообщение об ошибке ""(.*)""")]
        public void ThenShouldSeeErrorMessage(string expectedError)
        {
            Assert.AreEqual(expectedError, _loginPage.GetErrorMessage());
            Driver.Quit();
        }
    }
}
