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
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver WebDriver => _driver.Value ??= InitDriver();

        private static IWebDriver InitDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(
                "--headless=new",
                "--no-sandbox",
                "--disable-dev-shm-usage",
                $"--user-data-dir=/tmp/chrome_{Guid.NewGuid()}",
                "--remote-allow-origins=*"
            );

            return new ChromeDriver(options);
        }

        public static void Quit()
        {
            if (_driver.IsValueCreated)
            {
                _driver.Value.Quit();
                _driver.Value = null;
            }
        }
    }

}
