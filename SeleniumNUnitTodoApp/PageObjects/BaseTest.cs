using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnitTodoApp;

public class BaseTest
{
    private IWebDriver driver;

    protected IWebDriver GetDriver()
    {
        
        return driver;
    }
    //This is common for all the tests before test is run

    protected IWebDriver BrowserStackDriver()
    {
        String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
        String accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
        String buildNameJenkins = Environment.GetEnvironmentVariable("BROWSERSTACK_BUILD_NAME");

        ChromeOptions capabilities = new ChromeOptions
        {
            BrowserVersion = "100.0"
        };
        Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
        browserstackOptions.Add("os", "Windows");
        browserstackOptions.Add("osVersion", "10");
        browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.Name);
        browserstackOptions.Add("userName", username);
        browserstackOptions.Add("accessKey", accessKey);
        browserstackOptions.Add("seleniumVersion", "4.0.0");
        browserstackOptions.Add("buildName", buildNameJenkins);
        capabilities.AddAdditionalOption("build", buildNameJenkins);
        capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            
        driver = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"), capabilities);
        return driver;
    }
    [SetUp]
    public void SetUp()
    {
        TestContext.Progress.WriteLine("SetUp");
        driver = createDriver("chrome");
        driver.Manage().Window.Size = new Size(1920, 1200);
        driver.Navigate().GoToUrl("https://anjukshrestha.github.io//");

    }

    //This is common for all the tests after test has run
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    private IWebDriver createDriver(string browserName)
    {
        switch (browserName.ToLowerInvariant())
        {
            case "chrome":
                return new ChromeDriver();
            case "firefox":
                return new FirefoxDriver();
            case "edge":
                return new EdgeDriver();
            case "browserstack":
                return BrowserStackDriver();
            default:
                throw new Exception("Provided browser is  not supported");

        }
    }
}