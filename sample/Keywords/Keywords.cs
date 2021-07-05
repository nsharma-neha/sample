using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1.Keywords
{
    class Browser
    {
        public static IWebDriver _webDriver;

        public static void LaunchBrowser()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void NavigateTo(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public static void Close()
        {
            _webDriver.Quit();
        }

    }
}