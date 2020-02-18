using LMS.PageObjects;

namespace AutomationPractise.Goto_Page
{
    internal static class Goto
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            return page;
        }

        public static NavBarPageObjects NavBarPageObjects => GetPage<NavBarPageObjects>();
    }
}
