#region using directives
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using Framework.Configuration;
using System;
#endregion

namespace Framework.Driver
{
    public class Driver
    {
        public static IWebDriver Instance;
        

        public static void Initialize()
        {
            switch (TestConfig.Browser())
            {
                case "Chrome":
                    {
                        Instance = new ChromeDriver(TestConfig.LocalDriverPath());
                        break;
                    }
                case "InternetExplorer":
                    {
                        Instance = new InternetExplorerDriver(TestConfig.LocalDriverPath());
                        break;
                    }
                case "Firefox":
                    {
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                        service.FirefoxBinaryPath = @"C:\:";
                        Instance = new FirefoxDriver(service);
                        break;
                    }
                case "Remote":
                    {
                        DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                        capabilities.SetCapability("browserstack.user", "USERNAME");
                        capabilities.SetCapability("browserstack.key", "ACCESS_KEY");
                        Instance = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities);
                        break;
                    }
                default:
                    {
                        throw new WebDriverException("Please check Browser configuaration");
                    }
            }
        }

        public static void Close()
        {
            Instance.Quit();
        }
    }
}