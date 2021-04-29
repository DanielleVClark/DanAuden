using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

using System;

using TechTalk.SpecFlow;



namespace Auden.Framework

{

    [Binding]

    public static class WebDriverExtensions

    {

        public static WebDriverWait WebDriverWait(this IWebDriver driver)

        {

            return new WebDriverWait(driver, new TimeSpan(0, 0, 25));

        }



        public static void WaitUntilElementIsClickable(IWebDriver driver, IWebElement element)

        {

            var wait = WebDriverWait(driver);

            wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }



        public static void ScrollIntoView(this IWebElement element, IWebDriver driver, bool alignToTop = true)

        {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView(" + alignToTop.ToString().ToLower() + ");", element);

        }

    }

}
