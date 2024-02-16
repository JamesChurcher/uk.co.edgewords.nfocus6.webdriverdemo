using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace uk.co.edgewords.nfocus6.webdriverdemo.Utils
{
    internal class TestBaseClass
    {
        protected IWebDriver driver;

        [SetUp]
        public void setup()
        {
            // Create driver
            driver = new FirefoxDriver(); //Chrome driver isn't working for me

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void teardown()
        {
            // Close and quit browser
            driver.Close();
            driver.Quit();
        }
    }
}
