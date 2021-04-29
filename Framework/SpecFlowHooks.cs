using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Auden.Hooks

{
    [Binding]
    public class SpecFlowHooks
    {
       public static IWebDriver _driver;

        [BeforeScenario]

        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           _driver.Quit();
           _driver.Dispose();
        }
    }
}