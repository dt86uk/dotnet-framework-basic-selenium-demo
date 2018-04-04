using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using SeleniumWebDrvier.Enum;

namespace SeleniumWebDrvier.Model
{
    public class WebBrowserModel
    {
        private BrowserTypeEnum Type { get; set; }
        public IWebDriver WebDriver { get; set; }

        // Ensure you download all of the browser drivers and keep them in one spot
        // Browser directories here - this is for a x64 bit machine!
        private const string DriverLocation = "C:\\BrowserDrivers";

        public WebBrowserModel(BrowserTypeEnum browserType)
        {
            try
            {
                Type = browserType;
                switch (browserType)
                {
                    case BrowserTypeEnum.Chrome:
                        WebDriver = new ChromeDriver(DriverLocation);
                        break;
                    case BrowserTypeEnum.Edge:
                        WebDriver = new EdgeDriver(DriverLocation);
                        break;
                    case BrowserTypeEnum.InternetExplorer:
                        WebDriver = new InternetExplorerDriver(DriverLocation);
                        break;
                    case BrowserTypeEnum.Firefox:
                        WebDriver = new FirefoxDriver(DriverLocation);
                        break;
                    case BrowserTypeEnum.Safari:
                        WebDriver = new SafariDriver(DriverLocation);
                        break;
                    case BrowserTypeEnum.Opera:
                        WebDriver = new OperaDriver(DriverLocation);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Browser not listed");
                }
            }
            catch 
            {
                Console.WriteLine("Driver not in specified location");
                throw;
            } 
        }
    }
}
