using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1.Pages;
using TestProject1.Support;

namespace TestProject1;

[TestFixture]
public class LoginNUnitTests
{
    private IWebDriver _driver;
    private LoginPage _loginPage;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument($"--user-data-dir={Path.GetTempPath()}/chrome_{Guid.NewGuid()}");
        options.AddArgument("--remote-allow-origins=*");

        _driver = new ChromeDriver(options);

        _loginPage = new LoginPage(_driver);
        _driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
    }

    [Test]
    [Category("smoke")]
    public void Successful_Login()
    {
        // Act
        _loginPage.EnterUsername("student");
        _loginPage.EnterPassword("Password123");
        _loginPage.ClickLogin();
        // Assert
        Assert.AreEqual("https://practicetestautomation.com/logged-in-successfully/", _driver.Url);

    }

    [Test]
    public void UnSuccessful_Login()
    {
        // Act
        _loginPage.EnterUsername("wrongname");
        _loginPage.EnterPassword("Password123");
        _loginPage.ClickLogin();
        // Assert
        Assert.AreEqual("Your username is invalid!", _loginPage.GetErrorMessage());

    }

    [TearDown]
    public void Teardown()
    {
        _driver?.Quit();
        _driver.Dispose();
    }
}