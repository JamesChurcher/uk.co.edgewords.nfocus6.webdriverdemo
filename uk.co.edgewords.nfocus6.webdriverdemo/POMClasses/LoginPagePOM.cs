using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.edgewords.nfocus6.webdriverdemo.Utils.StaticHelperLib;

namespace uk.co.edgewords.nfocus6.webdriverdemo.POMClasses
{
    internal class LoginPagePOM
    {
        private IWebDriver _driver; //Field that will hold a driver

        public LoginPagePOM(IWebDriver driver)   //Constructor to get the driver from the test
        {
            this._driver = driver;  //Assigns passed driver in to private field in this class
            Assert.That(_driver.FindElement(
                   By.TagName("h1")).Text, 
                   Does.Contain("Access and Authentication"), "Must be wrong page");
            Assert.That(_driver.Url, Does.Contain("auth.php"), "Must be wrong page");
        }

        //Locators
        //private IWebElement usernameField => _driver.FindElement(By.Id("username"));
        private IWebElement usernameField => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("username")));

        //private IWebElement passwordField => _driver.FindElement(By.Id("password"));
        private IWebElement passwordField
        {
            get
            {
                StaticWaitForElement(_driver, By.Id("password"), 1);
                return _driver.FindElement(By.Id("password"));
            }
        }

        private IWebElement submitFormButton => _driver.FindElement(By.LinkText("Submit"));


        //Service methods
        public LoginPagePOM setUsername(string username)
        {
            usernameField.SendKeys(username);
            return this;
        }

        public LoginPagePOM setPassword(string password)
        {
            passwordField.SendKeys(password);
            return this;
        }

        public void submitForm()
        {
            submitFormButton.Click();
        }

        //Higher level helpers
        public bool LoginExpectSuccess(string username, string password)
        {
            setUsername(username);
            setPassword(password);
            submitForm();

            try
            {
                _driver.SwitchTo().Alert();
                return false;   //Failed log
            } 
            catch (NoAlertPresentException e)
            {
                return true;    //Login success
            }
        }
    }
}
