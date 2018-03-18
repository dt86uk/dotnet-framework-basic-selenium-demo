using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDrvier.Enum;
using SeleniumWebDrvier.Model;

namespace SeleniumWebDrvier
{
    public class SeleniumDemo
    {
        private List<WebBrowserModel> _listWebBrowserDrivers;
        private IWebElement _link;
        
        //XPath specific to the website navigation
        private const string WebsiteUrl = "http://www.danielthornton.net";
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
        }

        [Test]
        public void UrlTest()
        {
            foreach (var model in _listWebBrowserDrivers)
            {
                AssignWebsiteToModel(model);
            }
        }

        [Test]
        public void CssTest()
        {
            foreach (var model in _listWebBrowserDrivers)
            {
                AssignWebsiteToModel(model);

                FindLinkAndClick(model, ExperienceLinkXPath);
                FindLinkAndClick(model, SkillsLinkXPath);
                FindLinkAndClick(model, ContactLinkXPath);
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
        
        private void FindLinkAndClick(WebBrowserModel model, string xPath)
        {
            _link = model.WebDriver.FindElement(By.XPath(xPath));
            _link.Click();
        }

        private static void AssignWebsiteToModel(WebBrowserModel model)
        {
            model.WebDriver.Url = WebsiteUrl;
        }
    }
}
