using Auden.Framework;
using Auden.Hooks;
using Auden.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace Auden
{
    [Binding]
    public sealed class ShortTermLoanSteps
    {
        IWebDriver _driver;
        private readonly AudenLoanModels _audenLoanModels;

        public ShortTermLoanSteps(AudenLoanModels audenLoanModels)
        {
            _audenLoanModels = audenLoanModels;
            _driver = SpecFlowHooks._driver;
        }

        [Given(@"I have navigated to '(.*)'")]
        public void GivenIHaveNavigatedTo(string URL)
        {
            _driver.Navigate().GoToUrl(URL);

        }

        [When(@"I select loan amount of £210")]
        public void WhenISelectLoanAmount()
        {
            var wait = WebDriverExtensions.WebDriverWait(_driver);
            WebDriverExtensions.WaitUntilElementIsClickable(_driver, _audenLoanModels.AcceptCookieBtn);
            _audenLoanModels.AcceptCookieBtn.Click();
            WebDriverExtensions.WaitUntilElementIsClickable(_driver, _audenLoanModels.Slider);
            _audenLoanModels.MoveSlider();
        }

        [Then(@"The min loan amount is £(.*)")]
        public void ThenTheMinLoanAmountIs(int minAmount)
        {
            WebDriverExtensions.WaitUntilElementIsClickable(_driver, _audenLoanModels.AcceptCookieBtn);
            _audenLoanModels.AcceptCookieBtn.Click();
            WebDriverExtensions.WaitUntilElementIsClickable(_driver, _audenLoanModels.Min);
            var min = _audenLoanModels.Slider.GetAttribute("min");
            Assert.AreEqual($"{minAmount}", min);
        }

        [Then(@"The max loan amount is £(.*)")]
        public void ThenTheMaxLoanAmountIs(int maxAmount)
        {
            var max = _audenLoanModels.Slider.GetAttribute("max");
            Assert.AreEqual($"{maxAmount}", max);
        }

        [Then(@"Slider amount is the same as loan amount displayed")]
        public void ThenSliderAmountIsTheSameAsLoanAmountDisplayed()
        {
            var slideramount = _audenLoanModels.SliderAmount.Text;
            var loanAmount = _audenLoanModels.LoanSummaryAmount.Text;
            Assert.AreEqual(slideramount + ".", loanAmount);
        }

        [When(@"I select a payment date 23rd")]
        public void WhenISelectAPaymentDate()
        {
            WebDriverExtensions.WaitUntilElementIsClickable(_driver, _audenLoanModels.AcceptCookieBtn);
            _audenLoanModels.AcceptCookieBtn.Click();
            WebDriverExtensions.WaitUntilElementIsClickable(_driver, _audenLoanModels.PaymentDate);
            _audenLoanModels.PaymentDate.Click();
        }

        [Then(@"the first repayment date will be Friday 21st May 2021")]
        public void ThenTheFirstRepaymentDateWillBeFridayMay()
        {
            var repaymentDate = _audenLoanModels.RepaymentDate.Text;
            Assert.AreEqual("Friday 21 May 2021", repaymentDate);
        }





    }
}
