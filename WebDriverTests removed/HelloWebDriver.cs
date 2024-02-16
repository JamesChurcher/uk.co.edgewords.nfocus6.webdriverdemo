using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocus6.webdriverdemo.WebDriverTests
{
    internal class HelloWebDriver
    {
        [Test]
        public void FirstTest()
        {
            //Instantiate a browser
            ChromeOptions options = new ChromeOptions();
            options.BrowserVersion = "canary";
            IWebDriver driver = new ChromeDriver(options);
            //IWebDriver driver = new EdgeDriver();

            Console.WriteLine("Navigating to web page");

            //Navigate to a page
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/";

            //Find the login link and click it
            driver.FindElement(By.LinkText("Login To Restricted Area")).Click();

            string headingText = driver.FindElement(By.CssSelector("#right-column > h1:nth-child(1)")).Text;
            Console.WriteLine("Heading text is: " + headingText);

            //Now on next page
            //Fill in username and password
            driver.FindElement(By.CssSelector("#username")).Clear();
            driver.FindElement(By.CssSelector("#username")).SendKeys("edgewords");
            driver.FindElement(By.CssSelector("#username")).SendKeys(Keys.Control + "a");
            driver.FindElement(By.CssSelector("#username")).SendKeys(Keys.Backspace);
            driver.FindElement(By.CssSelector("#username")).SendKeys("edgewords");

            string usernameText = driver.FindElement(By.CssSelector("#username")).Text; //input element is "empty/void" no closing tag so no inner text to capture
            Console.WriteLine("The typed username text is " + usernameText);
            string usernameValue = driver.FindElement(By.CssSelector("#username")).GetAttribute("value"); //Use .getAttribute("value"); instead
            Console.WriteLine("The typed text is actually : " + usernameValue);

            IWebElement usernameField = driver.FindElement(By.CssSelector("#password"));
            usernameField.Clear();
            usernameField.SendKeys("edgewords123");

            //Provoking a stale element exception
            //driver.Navigate().Back();
            //driver.FindElement(By.LinkText("Login To Restricted Area")).Click();
            //usernameField = driver.FindElement(By.CssSelector("#password"));
            //usernameField.SendKeys("edgewords123");

            //Click Submit button
            driver.FindElement(By.LinkText("Submit")).Click();

            //Close/cleanup
            driver.Close();   //Close current tab
            driver.Quit();      //Quit browser and dispose of driver server

            Console.WriteLine("Test Complete!!!");

        }

        [Test]
        public void DragDropDemo()
        {
            EdgeOptions options = new EdgeOptions();
            //options.AddArgument("--start-maximized"); //Setting the window Maximized - browser specific
            IWebDriver driver = new EdgeDriver(options);
            //IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize(); //XBrowser way of maximising the window
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/docs/cssXPath.html";

            IWebElement gripper = driver.FindElement(By.CssSelector("#slider > a"));

            Actions action = new Actions(driver);
            IAction dragDropAction = action.ClickAndHold(gripper)
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .Pause(TimeSpan.FromSeconds(1))
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .MoveByOffset(10, 0)
                                            .Release()
                                            .Build();
            dragDropAction.Perform();

            driver.Close();
            driver.Quit();
        }

        [Test] 
        public void CrDebugTest()
        {
            ChromeOptions options = new ChromeOptions();
            //BrowserVersion used to be ignored when running locally - now used by SeleniumManager to fetch the browser
            options.BrowserVersion = "canary"; //stable/beta/dev/canary
            //options.AddArgument("--profile-directory=Default"); //Profile 1/Profile 2... - select a particular profile
            //options.AddArgument("--user-data-dir=d:\\ChromeProfile2\\Demo\\"); //Specify a custom directory for the profile
 
 
            //Instantiate the browser
            IWebDriver driver = new ChromeDriver(options);
            driver.Url = "chrome://version";
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
