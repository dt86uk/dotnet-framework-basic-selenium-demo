using OpenQA.Selenium;
using SeleniumWebDrvier.Data;
using SeleniumWebDrvier.Model;

namespace SeleniumWebDrvier.Service
{
    public class SeleniumOperationService
    {
        private readonly TestData _testData;

        public SeleniumOperationService()
        {
            _testData = new TestData();
        }

        public void AssignWebsiteToModel(WebBrowserModel model)
        {
            model.WebDriver.Url = _testData.WebsiteUrl;
        }

        public IWebElement FindElementByXPath(WebBrowserModel model, string xPath)
        {
            return model.WebDriver.FindElement(By.XPath(xPath));
        }

        public IWebElement FindElementByID(WebBrowserModel model, string elementId)
        {
            return model.WebDriver.FindElement(By.Id(elementId));
        } 

        public string GetSeleniumUiTestPageName()
        {
            return _testData.SeleniumUiTestPage;
        }

        public string GetValidEmailAddress()
        {
            return _testData.ValidEmailAddress;
        }

        public string GetValidPassword()
        {
            return _testData.ValidPassword;
        }
    }
}
