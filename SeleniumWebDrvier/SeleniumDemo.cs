using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDrvier.Enum;
using SeleniumWebDrvier.Model;
using SeleniumWebDrvier.Service;

namespace SeleniumWebDrvier
{
    public class SeleniumDemo
    {
        private List<WebBrowserModel> _listWebBrowserDrivers;
        private SeleniumOperationService _service;
        private IWebElement _element;
        
        //XPath specific to the website navigation
        private const string ExperienceLinkXPath = "//nav[@id='nav']//ul//li/a[text()='EXPERIENCE']";
        private const string SkillsLinkXPath = "//nav[@id='nav']//ul//li/a[text()='SKILLS']";
        private const string ContactLinkXPath = "//nav[@id='nav']//ul//li/a[text()='CONTACT']";
        
        [SetUp]
        public void StartBrowser()
        {
            _listWebBrowserDrivers = new List<WebBrowserModel>()
            {
                new WebBrowserModel(BrowserTypeEnum.Edge),
                //new WebBrowserModel(BrowserTypeEnum.Chrome) ////etc
            };

            _service = new SeleniumOperationService();
        }

        /// <summary>
        /// Tests URL 
        /// </summary>
        [Test]
        public void UrlTest()
        {
            foreach (var model in _listWebBrowserDrivers)
            {
                _service.AssignWebsiteToModel(model);
            }
        }

        /// <summary>
        /// Attempts to navigate to a specified HTML element
        /// </summary>
        [Test]
        public void CssTest()
        {
            foreach (var model in _listWebBrowserDrivers)
            {
                _service.AssignWebsiteToModel(model);

                _element = _service.FindElementByXPath(model, ExperienceLinkXPath);
                _element.Click();

                _element = _service.FindElementByXPath(model, SkillsLinkXPath);
                _element.Click();

                _element = _service.FindElementByXPath(model, ContactLinkXPath);
                _element.Click();
            }
        }

        /// <summary>
        /// Tests a basic data entry (input data to elements and click the submit button)
        /// </summary>
        [Test]
        public void ValidTestLoginInput()
        {
            foreach (var model in _listWebBrowserDrivers)
            {
                _service.AssignWebsiteToModel(model);
                model.WebDriver.Navigate().GoToUrl(model.WebDriver.Url + _service.GetSeleniumUiTestPageName());

                _element = _service.FindElementByID(model, "txtEmail");
                _element.SendKeys(_service.GetValidEmailAddress());

                _element = _service.FindElementByID(model, "txtPassword");
                _element.SendKeys(_service.GetValidPassword());

                _element = _service.FindElementByID(model, "btnFire");
                _service.ClickElement(_element);

                _element = _service.FindElementByID(model, "result");

                if (!_element.Displayed)
                {
                    Assert.Fail("result is not displaying (has btnFire fired correctly?)");
                }

                if (!_element.Text.Contains("Success"))
                {
                    Assert.Fail("Result message is not displaying");
                }
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            foreach (var model in _listWebBrowserDrivers)
            {
                model.WebDriver.Dispose();
            }
        }
    }
}
