using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using OpenQA.Selenium;

namespace SeleniumActivityLibrary
{
    [Designer(typeof(SendKeysDesigner))]
    public sealed class SendKeys : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> Keys { get; set; }

        [Category("Input")]
        [DisplayName("DOM Element")]
        [RequiredArgument]
        public InArgument<IWebElement> Element { get; set; }

        // アクティビティが値を返す場合は、CodeActivity<TResult> から派生して、
        // Execute メソッドから値を返します。
        protected override void Execute(CodeActivityContext context)
        {
            // テキスト型の入力引数のランタイム値を取得します
            //string text = context.GetValue(this.Text);

            IWebElement element = context.GetValue(this.Element);

            element.Clear(); // TODO ClearElement Activity

            //string keys = this.Keys.Get(context);
            string keys = context.GetValue(this.Keys);

            element.SendKeys(keys);
        }
    }
}
