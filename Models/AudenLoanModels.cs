using Auden.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Auden.Models
{
    [Binding]
    public class AudenLoanModels
    {
        IWebDriver _driver;

        public AudenLoanModels()

        {
            _driver = SpecFlowHooks._driver;
        }

        public void NavigateToURL(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public IWebElement Slider
        {
            get
            {
                return _driver.FindElement(By.CssSelector("[data-testid='loan-calculator-slider']"));
            }
        }

        public void MoveSlider()
        {
            Slider.SendKeys(Keys.ArrowRight);
        }
        public IWebElement AcceptCookieBtn
        {
            get
            {
                return _driver.FindElement(By.Id("consent_prompt_submit"));
            }
        }

    }
}
