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
        public IWebElement PaymentDate
        {
            get
            {
                return _driver.FindElement(By.XPath("//*[@value='23']"));
            }
            
        }
        public IWebElement RepaymentDate
        {
            get
            {
                return _driver.FindElement(By.XPath("//*[@class='loan-schedule__tab__panel__detail__tag__text']"));
            }
        }
        public IWebElement SliderAmount
        {
            get
            {
                return _driver.FindElement(By.XPath("//*[@data-testid='loan-amount-value']"));
            }
        }
        public IWebElement Min
        {
            get
            {
                return _driver.FindElement(By.XPath("//*[@min='200']"));
            }
        }
        public IWebElement AcceptCookieBtn
        {
            get
            {
                return _driver.FindElement(By.Id("consent_prompt_submit"));
            }
        }
        public IWebElement LoanSummaryAmount
        {
            get
            {
                return _driver.FindElement(By.XPath("(//*[@class='loan-summary__column__amount__value'])[1]"));
            }
        }
    }
}
