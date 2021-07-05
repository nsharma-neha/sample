using NUnit.Framework;
using OpenQA.Selenium;
using UnitTestProject1.Keywords;
using static UnitTestProject1.TestData.TestData;
using static UnitTestProject1.Keywords.Browser;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;


namespace UnitTestProject1.Tests
{
    class VerifySearchResults 
    {
        public static IWebElement SearchHeader = _webDriver.FindElement(By.XPath("//*[@id='__next']/main/div/div[3]/div/div[1]/div[2]/div[1]/h2/span"));
        public static IWebElement SearchCategory = _webDriver.FindElement(By.XPath("//*[@id='search-categories']/div[1]/h2"));
        public static IWebElement SearchResult1 = _webDriver.FindElement(By.XPath("//*[@id='__next']/main/div/div[3]/div/div[4]/article[1]/a/div[2]/div[2]/a/p"));
        public static IWebElement SearchResult2 = _webDriver.FindElement(By.XPath("//*[@id='__next']/main/div/div[3]/div/div[4]/article[2]/a/div[2]/div[2]/a/p"));

        //The objective of this test is to verify that the search results are displayed
        [Test]
        public void VerifySearchResultsHomePage()
        {
            
            LaunchBrowserAndNavigateToHomePage();
            EnterSearchKeyword();
            ClickOnSerachButton();
            VerifySearchHeaders();
            VerifySearchResult();
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
        }

        public void VerifySearchHeaders()
        {
            
             Assert.IsTrue(SearchHeader.Text.Contains(searchKey));
             Assert.AreEqual(SearchCategory.Text, "Products");
        }

        public void VerifySearchResult()
        { 
           
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(SearchResult1);
            actions.Perform();
            Assert.AreEqual(SearchResult1.Text, "Nelson AC Voltage Tester");
           
           
            actions.MoveToElement(SearchResult2);
            actions.Perform();
            Assert.AreEqual(SearchResult2.Text, "Klein Tools 6-24V AC/DC Voltage Tester");

        }
    }
}