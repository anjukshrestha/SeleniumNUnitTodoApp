
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitTodoApp
{
    [TestFixture]
    public class DefaultSuiteTest {
        private IWebDriver driver;
        public IDictionary<string, object> vars {get; private set;}
        private IJavaScriptExecutor js;
        
        [SetUp]
        public void SetUp() {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown() {
            driver.Quit();
        }
        [Test]
        public void TestAddTodo() {
            driver.Navigate().GoToUrl("https://anjushrestha.com/todo/");
            driver.Manage().Window.Size = new System.Drawing.Size(1512, 876); 
            
            driver.FindElement(By.Id("taskInput")).SendKeys("FirstTask");
            driver.FindElement(By.Id("addButton")).Click();
            var text = driver.FindElement(By.XPath("//*[@id=\"taskList\"]/li/span")).Text;
            
            Assert.AreEqual("FirstTask", text); 
             
        }
    }
}