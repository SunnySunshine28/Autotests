using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        private By UsernameField => By.Id("username");
        private By PasswordField => By.Id("password");
        private By LoginButton => By.Id("submit");
        private By ErrorMessage => By.Id("error");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterUsername(string username)
        {
            _driver.FindElement(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public void ClickLogin()
        {
            _driver.FindElement(LoginButton).Click();
        }

        public string GetErrorMessage()
        {

                // Ждём появления элемента и его видимости
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                var errorElement = wait.Until(d =>
                {
                    var element = d.FindElement(By.XPath("//*[contains(text(),'invalid') or contains(@id,'error')]"));
                    return element.Displayed ? element : null;
                });

                return errorElement?.Text ?? string.Empty;

        }

        public bool IsPageLoaded()
        {
            return _driver.FindElement(LoginButton).Displayed;
        }
    }
}
