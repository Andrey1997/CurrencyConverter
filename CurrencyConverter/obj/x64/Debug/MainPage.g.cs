﻿#pragma checksum "C:\Users\gandr\OneDrive\Рабочий стол\TestProject\CurrencyConverter\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "88375EB0EC881E3959FC19BF00D6F92EA9AEC4C67AFC4BABB9A6DD19120A6A40"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CurrencyConverter
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 22
                {
                    this.firstTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.firstTextBox).TextChanged += this.ChangedText;
                }
                break;
            case 3: // MainPage.xaml line 24
                {
                    this.secondTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // MainPage.xaml line 27
                {
                    this.firstCurrency = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 28
                {
                    this.secondCurrency = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // MainPage.xaml line 30
                {
                    this.swapButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.swapButton).Click += this.ButtonClickSwap;
                }
                break;
            case 7: // MainPage.xaml line 31
                {
                    this.selectButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.selectButton).Click += this.ButtonClickSelectCurrency;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

