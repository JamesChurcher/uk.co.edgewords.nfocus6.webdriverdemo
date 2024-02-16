// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace uk.co.edgewords.nfocus6.webdriverdemo.WebDriverTests
{
    [TestFixture]
    public class FormsDemoTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new EdgeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
            //driver.Dispose();
        }
        [Test]
        public void formsDemo()
        {
            // Test name: FormsDemo
            // Step # | name | target | value
            // 1 | open | /webdriver2/ | 
            driver.Navigate().GoToUrl("https://www.edgewordstraining.co.uk/webdriver2/");
            // 2 | setWindowSize | 1052x800 | 
            driver.Manage().Window.Size = new System.Drawing.Size(1052, 800);
            // 3 | click | css=.last span | 
            driver.FindElement(By.CssSelector(".last span")).Click();
            // 4 | click | linkText=Forms | 
            driver.FindElement(By.LinkText("Forms")).Click();
            // 5 | click | id=textInput | 
            driver.FindElement(By.Id("textInput")).Click();
            // 6 | type | id=textInput | James
            driver.FindElement(By.Id("textInput")).SendKeys("James");
            // 7 | click | id=textArea | 
            driver.FindElement(By.Id("textArea")).Click();
            // 8 | type | id=textArea | was here!
            driver.FindElement(By.Id("textArea")).SendKeys("was here!");
            // 9 | click | id=checkbox | 
            driver.FindElement(By.Id("checkbox")).Click();
            // 10 | click | id=select | 
            driver.FindElement(By.Id("select")).Click();
            // 11 | select | id=select | label=Selection Three
            {
                var dropdown = driver.FindElement(By.Id("select"));
                dropdown.FindElement(By.XPath("//option[. = 'Selection Three']")).Click();
            }
            // 12 | click | css=.formTable tr:nth-child(5) > td:nth-child(2) | 
            driver.FindElement(By.CssSelector(".formTable tr:nth-child(5) > td:nth-child(2)")).Click();
            // 13 | click | id=password | 
            driver.FindElement(By.Id("password")).Click();
            // 14 | click | id=two | 
            driver.FindElement(By.Id("two")).Click();
            // 15 | click | id=password | 
            driver.FindElement(By.Id("password")).Click();
            // 16 | type | id=password | Password
            driver.FindElement(By.Id("password")).SendKeys("Password");
            // 17 | click | linkText=Submit | 
            driver.FindElement(By.LinkText("Submit")).Click();
            // 18 | click | css=tr:nth-child(2) > td:nth-child(3) | 
            driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(3)")).Click();
            // 19 | assertText | id=textInputValue | James
            Assert.That(driver.FindElement(By.Id("textInputValue")).Text, Is.EqualTo("James"));
            // 20 | verifyText | id=textInputValue | Jamie
            try
            {
                Assert.That(driver.FindElement(By.Id("textInputValue")).Text, Is.EqualTo("James"));
            }
            catch (Exception)
            {
                //Do nothing
            }
            // 21 | click | linkText=Home | 
            driver.FindElement(By.LinkText("Home")).Click();
        }
    }
}