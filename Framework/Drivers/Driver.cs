using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Driver
{
    public class Driver
    {
       public static IWebDriver Instance;

        public static void Initialize()
        {
            Instance = new ChromeDriver(@"C:\");
        }

        public static void Close()
        {
            Instance.Quit();
        }
    }
}