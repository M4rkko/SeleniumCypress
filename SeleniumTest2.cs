using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.Threading;

namespace TestProjectTest
{
    public class SwagLabs
    {
        private IWebDriver driver;
        string Test_URL = "https://www.saucedemo.com";
        private readonly Random _random = new();

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_URL);
        }

        [Test]
        public void Test1()
        {
            IWebElement Username = driver.FindElement(By.Id("user-name"));
            Username.SendKeys("standard_user");
            IWebElement Password = driver.FindElement(By.Id("password"));
            Password.SendKeys("secret_sauce");
            IWebElement Login = driver.FindElement(By.Id("login-button"));
            Login.Click();

            IWebElement AddToCartRed = driver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)"));
            AddToCartRed.Click();
            IWebElement AddToCartBag = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            AddToCartBag.Click();
            Thread.Sleep(500);
            IWebElement RemoveRed = driver.FindElement(By.Id("remove-test.allthethings()-t-shirt-(red)"));
            RemoveRed.Click();
            IWebElement Cart = driver.FindElement(By.Id("shopping_cart_container"));
            Cart.Click();
            Thread.Sleep(500);
            IWebElement ContinueShopping = driver.FindElement(By.Id("continue-shopping"));
            ContinueShopping.Click();
            Thread.Sleep(500);
            IWebElement Cart1 = driver.FindElement(By.Id("shopping_cart_container"));
            Cart1.Click();
            IWebElement checkout = driver.FindElement(By.Id("checkout"));
            checkout.Click();
            IWebElement FirstName = driver.FindElement(By.Id("first-name"));
            FirstName.SendKeys("Mina");
            IWebElement LastName = driver.FindElement(By.Id("last-name"));
            LastName.SendKeys("Sina");
            IWebElement Zip = driver.FindElement(By.Id("postal-code"));
            Zip.SendKeys("7707");
            Thread.Sleep(500);
            IWebElement Pay = driver.FindElement(By.Id("continue"));
            Pay.Click();
            IWebElement Finish = driver.FindElement(By.Id("finish"));
            Finish.Click();
            IWebElement Menu = driver.FindElement(By.Id("react-burger-menu-btn"));
            Menu.Click();
            // IWebElement AllItems = driver.FindElement(By.Id("inventory_sidebar_link"));
           // AllItems.Click();  // Element not interactable
            Thread.Sleep(2000);

        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();

            }
        }

    }
}