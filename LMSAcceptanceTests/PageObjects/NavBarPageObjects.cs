using AutomationPractise.Common;
using FluentAssertions;
using OpenQA.Selenium;
using SharedLogic.Helpers;

namespace LMS.PageObjects
{
    class NavBarPageObjects
    {
        private readonly IWebDriver driver;

        public NavBarPageObjects()
        {
            driver = Setup.Driver;
        }

        public void ClikckNavBarOption(string link)
        {
            driver.Click(By.XPath($"//a[contains(text(),'{link}')]"));
        }

        public void AssertSelectedPageIsDisplayed(string linkPage)
        {
            var pageUrl = driver.Url;
            pageUrl.Should().ContainEquivalentOf($"{linkPage}/");
        }
    }
}
