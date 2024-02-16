using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocus6.webdriverdemo.POMClasses
{
    internal class HomePagePOM
    {
        private IWebDriver _driver; //Field that will hold a driver

        public HomePagePOM(IWebDriver driver)   //Constructor to get the driver from the test
        {
            this._driver = driver;  //Assigns passed driver in to private field in this class
        }

        //Locators - finding elements on the page
        private IWebElement loginLink => _driver.FindElement(By.PartialLinkText("Login"));

        //Service method - doing things with elements on the page
        public void GoLogin()
        {
            loginLink.Click();
        }
    }
}
