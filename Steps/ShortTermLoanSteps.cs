﻿using Auden.Framework;
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

        [When(@"I select loan amount")]
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
            var min = _audenLoanModels.Slider.GetAttribute("min");
            Assert.AreEqual(minAmount, min);
        }


        //[Then(@"I can select repayment date of (.*)nd")]
        //public void ThenICanSelectRepaymentDateOfNd(int p0)
        //{
        //    //ScenarioContext.Current.Pending();
        //}

    }
}
