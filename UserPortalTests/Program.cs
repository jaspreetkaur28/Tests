using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;


namespace UserPortalTests
{

    class Program
    {
        //static void Main(string[] args)
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    driver.Url = "https://www.bbc.co.uk/";
        //    Thread.Sleep(2000);
        //    driver.Close(); // closes one window
        //    driver.Quit(); // closes all windows
        //}
    }
    class Selenium_Tests
    {
        IWebDriver driver;
        IWebElement element;

        [SetUp]

        public void Initialise()
        {
            driver = new ChromeDriver();

        }
        [Test]
        public void TestLogin()
        {
            driver.Url = "http://spartaportal.azurewebsites.net/login"; 

            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://spartaportal.azurewebsites.net/Users");
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://spartaportal.azurewebsites.net/Roles");
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://spartaportal.azurewebsites.net/Cohorts");
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://spartaportal.azurewebsites.net/Specialisations");  
            Thread.Sleep(1500); 
        }

        [Test]
        public void TestLoginUser()
        {
            driver.Url = "http://spartaportal.azurewebsites.net/login";

            //select an individual web element on the page
            element = driver.FindElement(By.Name("email"));
            //add text to Email Textbox
            element.SendKeys("admin@spartaglobal.com");
            Thread.Sleep(1500);

            //add text to Email Textbox
            element = driver.FindElement(By.Name("password"));
            element.SendKeys("Admin123");

            //find the submit button
            //click to log in

            element = driver.FindElement(By.CssSelector(".btn-primary"));
            //OR       element = driver.FindElement(By.ClassName("btn-primary"));
            element.Click();

            //   < input class="btn btn-primary btn-md btn-block" type="submit" value="Submit">


            //element to look at users without log in
            element = driver.FindElement(By.LinkText("Users")); // Users is unique on the page so can find like this
            element.Click(); // gives error as we are not logged in. this is what we want to acheive in our test. 
            Thread.Sleep(4000);

        }


        [TearDown]
        public void Cleanup()
        {
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
        }
    }
}