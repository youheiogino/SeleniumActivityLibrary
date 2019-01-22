using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using OpenQA.Selenium;

namespace SeleniumActivityLibrary
{

    public sealed class QuitWebBrowser : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Web Driver")]
        [RequiredArgument]
        public InArgument<IWebDriver> Driver { get; set; }

        // アクティビティが値を返す場合は、CodeActivity<TResult> から派生して、
        // Execute メソッドから値を返します。
        protected override void Execute(CodeActivityContext context)
        {
            IWebDriver driver = context.GetValue(Driver);
            driver.Quit();
        }
    }
}
