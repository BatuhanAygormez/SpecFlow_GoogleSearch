using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlow_App.StepDefinitions
{
    [Binding]
    public class GoogleSteps
    {
        private IWebDriver driver;

        [Given(@"I am on the Google search page")]
        public void GivenIAmOnTheGoogleSearchPage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string keyword)
        {
            OpenQA.Selenium.IWebElement searchInput = driver.FindElement(By.Name("q")); 
            searchInput.SendKeys(keyword);
            searchInput.Submit();
            OpenQA.Selenium.IWebElement firstResultLink = driver.FindElement(By.CssSelector("div#search a"));
            firstResultLink.Click();
        }

        [Then(@"I should see search results")]
        public void ThenIShouldSeeSearchResults()
        {
            Assert.True(driver.Title.Contains("Batuhan Aygörmez - Software Test Engineer - Bimser Çözüm"));
            driver.Quit();
        }
    }
}