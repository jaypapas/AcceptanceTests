using JetBrains.Annotations;
using OpenQA.Selenium;
using SharedLogic.Helpers;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractise.Common
{
    [Binding]
    public class Setup
    {
        public static readonly string RootUrl = "https://corporate.lms.com/";
        private const int DefaultTimeOut = 1;
        private const int PageLoadTimeout = 10;
        public static string OriginalHandle;
        private readonly FeatureInfo _featureInfo;
        private readonly ScenarioInfo _scenarioInfo;
        private readonly ScenarioContext _scenarioContext;

        public static IWebDriver Driver;

        public Setup(FeatureInfo featureInfo, ScenarioInfo scenarioInfo, ScenarioContext scenarioContext)
        {
            _featureInfo = featureInfo;
            _scenarioInfo = scenarioInfo;
            _scenarioContext = scenarioContext;
        }

        [UsedImplicitly]
        [BeforeTestRun]
        public static void SetUp()
        {
            HelperMethods.DeleteDirectory();
            Driver = HelperMethods.LaunchChromeDriver();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeout);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultTimeOut);
            HelperMethods.SetScreenSizeToThatOfTeamCity(Driver);
        }

        [UsedImplicitly]
        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.Write($"Feature: {_featureInfo.Title} | Scenario: {_scenarioInfo.Title}");
            Driver.Navigate().GoToUrl(RootUrl);
            OriginalHandle = Driver.CurrentWindowHandle;
        }
         
        [UsedImplicitly]
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null) 
                {
                    WebDriverExtensions.TakeScreenshot(Driver);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"Unable to execute AfterScenario step due to {e.Message}");
            }

            finally
            {
                WebDriverExtensions.CloseHangingWindows(Driver, OriginalHandle);
                Driver.Manage().Cookies.DeleteAllCookies();
            }
        }

        [UsedImplicitly]
        [AfterTestRun]
        public static void CleanUp() => Driver.Quit();
    }
}