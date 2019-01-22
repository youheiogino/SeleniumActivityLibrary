using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using OpenQA.Selenium;

namespace SeleniumActivityLibrary
{

    public sealed class SubmitElement : CodeActivity
    {
        [Category("Input")]
        [DisplayName("DOM Element")]
        [RequiredArgument]
        public InArgument<IWebElement> Element { get; set; }

        // アクティビティが値を返す場合は、CodeActivity<TResult> から派生して、
        // Execute メソッドから値を返します。
        protected override void Execute(CodeActivityContext context)
        {
            IWebElement element = context.GetValue(this.Element);

            element.Submit();
        }
    }
}
