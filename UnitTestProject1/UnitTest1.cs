using System;
using System.Activities;
using System.Activities.Statements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumActivityLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Variable<IWebDriver> driver = new Variable<IWebDriver>
            {
                Name = "driver"
            };

            Variable<IWebElement> element = new Variable<IWebElement>
            {
                Name = "element"
            };

            Activity wf = new Sequence
            {
                Variables = { driver, element },
                Activities =
                {
                    new StartWebBrowser
                    {
                        Driver = driver,
                        Browser = BrowserEnum.Chrome,
                    },
                    new GoToURL
                    {
                        Driver = driver,
                        Url = "https://www.google.com/",
                    },
                    new FindElement
                    {
                        Driver = driver,
                        Element = element,
                        By = ElementByEnum.Name,
                        Target = "q",
                    },
                    new Delay
                    {
                        Duration = new TimeSpan(0, 0, 3),
                    },
                    new SendKeys
                    {
                        Element = element,
                        Keys = "Hacker News",
                    },
                    new SubmitElement
                    {
                        Element = element,
                    },
                    new Delay
                    {
                        Duration = new TimeSpan(0, 0, 3),
                    },
                    new QuitWebBrowser
                    {
                        Driver = driver,
                    }
                },
            };

            WorkflowInvoker.Invoke(wf);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Activity wf = new Activity1();
            WorkflowInvoker.Invoke(wf);
        }
    }
}
