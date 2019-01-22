using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using OpenQA.Selenium;

namespace SeleniumActivityLibrary
{
    [Designer(typeof(FindElementDesigner))]
    public sealed class FindElement : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> Target { get; set; }

        [Category("Input")]
        [DisplayName("Web Driver")]
        [RequiredArgument]
        public InArgument<IWebDriver> Driver { get; set; }

        [Category("Output")]
        [DisplayName("DOM Element")]
        [RequiredArgument]
        public OutArgument<IWebElement> Element { get; set; }

        [RequiredArgument]
        public ElementByEnum By { get; set; }

        // アクティビティが値を返す場合は、CodeActivity<TResult> から派生して、
        // Execute メソッドから値を返します。
        protected override void Execute(CodeActivityContext context)
        {
            string hint = context.GetValue(this.Target);

            IWebDriver driver = context.GetValue(this.Driver);

            IWebElement element = null;

            if (By == ElementByEnum.Id)
                element = driver.FindElement(OpenQA.Selenium.By.Id(hint));
            else if (By == ElementByEnum.Name)
                element = driver.FindElement(OpenQA.Selenium.By.Name(hint));
            else if (By == ElementByEnum.ClassName)
                element = driver.FindElement(OpenQA.Selenium.By.ClassName(hint));
            else if (By == ElementByEnum.XPath)
                element = driver.FindElement(OpenQA.Selenium.By.XPath(hint));

            // TODO if (element == null) { // throw exception

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style='border: 5px solid red !important;'", element);

            context.SetValue(Element, element);
        }
    }
}
