using NUnit.Framework;
using OpenQA.Selenium;
using UnitTestProject1.Keywords;
using static UnitTestProject1.TestData.TestData;
using static UnitTestProject1.Keywords.Browser;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using System.Threading;

namespace UnitTestProject1.Tests
{
    class VerifySearchHistory
    {
        public static IWebElement SearchHeader = _webDriver.FindElement(By.XPath("//*[@id='__next']/main/div/div[3]/div/div[1]/div[2]/div[1]/h2/span"));
        public static IWebElement SearchCategory = _webDriver.FindElement(By.XPath("//*[@id='search-categories']/div[1]/h2"));
        public static IWebElement SearchResult1 = _webDriver.FindElement(By.XPath("//*[@id='__next']/main/div/div[3]/div/div[4]/article[1]/a/div[2]/div[2]/a/p"));
        public static IWebElement SearchResult2 = _webDriver.FindElement(By.XPath("//*[@id='__next']/main/div/div[3]/div/div[4]/article[2]/a/div[2]/div[2]/a/p"));
        public static IWebElement RecentSearchesLabel = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[1]/p"));
        public static IWebElement RecentSearch1 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div/span"));
        public static IWebElement ClearRecentSearch = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/button/p"));

        //objective of the test is to check the search history and check that user can clear the search history successfully.

        [Test]
        public void VerifySearchResultsHomePage()
        {

            LaunchBrowserAndNavigateToHomePage();
            EnterSearchKeyword();
            ClickOnSerachButton();
            VerifySearchHist();
            ClearSearchHist();

        }

        [TearDown]
        public void close_Browser()
        {
            Browser.Close();
        }

        public void LaunchBrowserAndNavigateToHomePage()
        {
            Browser.LaunchBrowser();
            Browser.NavigateTo(BaseUrl);
        }

        public void EnterSearchKeyword()
        {
            IWebElement Searchbar = _webDriver.FindElement(By.Id("custom-css-outlined-input"));
            Searchbar.Click();
            Searchbar.SendKeys(searchKey);
        }

        public void ClickOnSerachButton()
        {
            IWebElement Searchbar = _webDriver.FindElement(By.Id("custom-css-outlined-input"));
            Searchbar.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }

        public void VerifySearchHist()
        {
            IWebElement Searchbar = _webDriver.FindElement(By.Id("custom-css-outlined-input"));
            IWebElement MainHeader = _webDriver.FindElement(By.XPath("//*[@id='main-header']/div[1]/div[1]/div[1]/div[2]"));
            MainHeader.Click();
            Searchbar.Click();
            Assert.AreEqual("Recent searches", RecentSearchesLabel.Text);
            Assert.AreEqual(searchKey, RecentSearch1.Text);
        }

        public void ClearSearchHist()
        {
            ClearRecentSearch.Click();
            Assert.AreNotEqual(_webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div/span")).Text, searchKey);
        }
    }
}