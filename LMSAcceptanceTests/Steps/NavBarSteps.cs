using AutomationPractise.Goto_Page;
using TechTalk.SpecFlow;

namespace LMS.Steps
{
    [Binding]
    class NavBarSteps
    {
        [Given(@"I am on LMS homepage")]
        public void GivenIAmOnLMSHomepage()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"I click on any navigation bar (.*)")]
        public void WhenIClickOnAnyNavigationBar(string link)
        {
            Goto.NavBarPageObjects.ClikckNavBarOption(link);
        }

        [Then(@"I should be taken to the selected navigation bar (.*)")]
        public void ThenIShouldBeTakenToTheSelectedNavigationBar(string linkPage)
        {
            Goto.NavBarPageObjects.AssertSelectedPageIsDisplayed(linkPage);
        }
    }
}
 