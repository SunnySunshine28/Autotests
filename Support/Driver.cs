using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Support
{
    public static class Driver
    {
        public static IWebDriver WebDriver { get; private set; }

        public static void Initialize()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void Quit()
        {
            WebDriver?.Quit();
        }
    }
}
