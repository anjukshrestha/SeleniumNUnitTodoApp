using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumNUnitTodoApp
{
    [TestFixture]
    public class DefaultSuiteTest : BaseTest 
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars {get; private set;}
        private IJavaScriptExecutor js;
        
        [Test]
        public void TestAddTodo() 
        {
            GetDriver().FindElement(By.Id("taskInput")).SendKeys("FirstTask");
            GetDriver().FindElement(By.Id("addButton")).Click();
            var text = GetDriver().FindElement(By.XPath("//*[@id=\"taskList\"]/li/span")).Text;
            
            Assert.AreEqual("FirstTask", text); 
             
        }
        
        [Test]
        public void TestVerifyAddIsWorking() 
        {
            GetDriver().FindElement(By.Id("taskInput")).SendKeys("FirstTask");
            GetDriver().FindElement(By.Id("addButton")).Click();
            var text = GetDriver().FindElement(By.XPath("//*[@id=\"taskList\"]/li/span")).Text;
            
            Assert.AreEqual("FirstTask", text); 
             
        }
        
        [Test]
        public void TestVerifytest() 
        {
            GetDriver().FindElement(By.Id("taskInput")).SendKeys("FirstTask");
            GetDriver().FindElement(By.Id("addButton")).Click();
            var text = GetDriver().FindElement(By.XPath("//*[@id=\"taskList\"]/li/span")).Text;
            
            Assert.AreEqual("FirstTask", text); 
             
        }
    }
}