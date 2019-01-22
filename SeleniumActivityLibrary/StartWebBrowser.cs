using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumActivityLibrary
{
    [Designer(typeof(StartWebBrowserDesigner))]
    public sealed class StartWebBrowser : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public OutArgument<IWebDriver> Driver { get; set; }

        [RequiredArgument]
        [DefaultValue(BrowserEnum.Chrome)]
        public BrowserEnum Browser { get; set; }

        [DisplayName("Implicit Wait")]
        //[DefaultValue(10)]
        public int ImplicitWait { get; set; }

        public StartWebBrowser()
        {
            //DisplayName = SeleniumActivityLibrary.Properties.Resources.StartWebBrowser;
            ImplicitWait = 10;
        }

        // アクティビティが値を返す場合は、CodeActivity<TResult> から派生して、
        // Execute メソッドから値を返します。
        protected override void Execute(CodeActivityContext context)
        {
            IWebDriver driver = null;

            if (Browser == BrowserEnum.Chrome)
            {
                driver = new ChromeDriver();
            }
            else if (Browser == BrowserEnum.Firefox)
            {
                driver = new FirefoxDriver();
            }

            // TODO if (driver == null) { // throw exception

            // WinAppDriverのAppiumのSeleniumが古いため、こちらも合わせざるをえない
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ImplicitWait));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWait);

            Driver.Set(context, driver);
        }
    }
}
