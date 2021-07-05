using NUnit.Framework;
using UnitTestProject1.Keywords;
using static UnitTestProject1.TestData.TestData;
using static UnitTestProject1.Keywords.Browser;
using OpenQA.Selenium;

namespace UnitTestProject1.Tests
{
    class VerifyPopularSearchesList 
        
    {
        public static IWebElement PopularSearch1 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[1]/span"));
        public static IWebElement PopularSearch2 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[2]/span"));
        public static IWebElement PopularSearch3 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[3]/span"));
        public static IWebElement PopularSearch4 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[4]/span"));
        public static IWebElement PopularSearch5 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[5]/span"));
        public static IWebElement PopularSearch6 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[6]/span"));
        public static IWebElement PopularSearch7 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[7]/span"));
        public static IWebElement PopularSearch8 = _webDriver.FindElement(By.XPath("//*[@id='flyout']/div/div/div/div[1]/div/div[2]/div[8]/span"));

        //The objective of this test case is to check that the popular searches list is displayed
        //when the user clciks on the search text bar.

        [Test]
        public void TestScenario1()
        {
            LaunchBrowserAndNavigateToHomePage();
            ClickOnSearchBar();
            VerifyPopularSearchesAreDisplayed();
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

        public void ClickOnSearchBar()
        {
            IWebElement Searchbar = _webDriver.FindElement(By.Id("custom-css-outlined-input"));
            Searchbar.Click();
            
        }

        public void VerifyPopularSearchesAreDisplayed()
        {
          

            Assert.IsTrue(PopularSearch1.Displayed);
            Assert.AreEqual(PopularSearch1.Text,"fire pit");

            Assert.IsTrue(PopularSearch2.Displayed);
            Assert.AreEqual(PopularSearch2.Text, "stud finder");

            Assert.IsTrue(PopularSearch3.Displayed);
            Assert.AreEqual(PopularSearch3.Text, "security cameras");

            Assert.IsTrue(PopularSearch4.Displayed);
            Assert.AreEqual(PopularSearch4.Text, "pressure washers" );

            Assert.IsTrue(PopularSearch5.Displayed);
            Assert.AreEqual(PopularSearch5.Text, "scalex");

            Assert.IsTrue(PopularSearch6.Displayed);
            Assert.AreEqual(PopularSearch6.Text, "carpet cleaner hire");

            Assert.IsTrue(PopularSearch7.Displayed);
            Assert.AreEqual(PopularSearch7.Text, "clothes airer");

            Assert.IsTrue(PopularSearch8.Displayed);
            Assert.AreEqual(PopularSearch8.Text, "table saw");
        }
       
    }
}