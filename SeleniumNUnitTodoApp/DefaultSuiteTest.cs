
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Remote;

namespace SeleniumNUnitTodoApp
{
    [TestFixture]
    public class DefaultSuiteTest {
        private IWebDriver driver;
        public IDictionary<string, object> vars {get; private set;}
        private IJavaScriptExecutor js;
        
        [SetUp]
        public void SetUp()
        {
            String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            String accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            String buildName = Environment.GetEnvironmentVariable("JENKINS_LABEL");
            String buildNameJenkins = Environment.GetEnvironmentVariable("BROWSERSTACK_BUILD_NAME");

            ChromeOptions capabilities = new ChromeOptions
            {
                BrowserVersion = "100.0"
            };
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("sessionName", "BStack Build Name: " + buildName);
            browserstackOptions.Add("userName", username);
            browserstackOptions.Add("accessKey", accessKey);
            browserstackOptions.Add("seleniumVersion", "4.0.0");
            browserstackOptions.Add("buildName", buildNameJenkins);
            capabilities.AddAdditionalOption("build", buildNameJenkins);
            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            
            driver = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"), capabilities);
            
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown() {
            driver.Quit();
        }
        [Test]
        public void TestAddTodo() {
            driver.Navigate().GoToUrl("https://anjukshrestha.github.io/"); 
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("taskInput")).SendKeys("FirstTask");
            driver.FindElement(By.Id("addButton")).Click();
            var text = driver.FindElement(By.XPath("//*[@id=\"taskList\"]/li/span")).Text;
            
            Assert.AreEqual("FirstTask", text); 
             
        }
        
        [Test]
        public void TestVerifyAddIsWorking() {
            driver.Navigate().GoToUrl("https://anjukshrestha.github.io/"); 
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("taskInput")).SendKeys("FirstTask");
            driver.FindElement(By.Id("addButton")).Click();
            var text = driver.FindElement(By.XPath("//*[@id=\"taskList\"]/li/span")).Text;
            
            Assert.AreEqual("FirstTask", text); 
             
        }
    }
}