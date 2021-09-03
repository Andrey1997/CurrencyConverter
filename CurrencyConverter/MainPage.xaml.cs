using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;



// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace CurrencyConverter
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CurrencyRate currencyRate;
        private IConverterCurrency converterCurrency;

        public MainPage()
        {
            this.InitializeComponent();
            CreateCurrencyRate();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                string nameCurrency = (string)e.Parameter;

                if (nameCurrency == "")
                {
                    return;
                }

                secondCurrency.Text = nameCurrency;

                ChangedText_();
            }
        }

        private async void CreateCurrencyRate()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            currencyRate = new CurrencyRate(json);
            converterCurrency = currencyRate;
        }

        private void ChangedText(object sender, RoutedEventArgs e)
        {
            ChangedText_();
        }

        private void ChangedText_()
        {
            try
            {
                double firstValue = Convert.ToDouble(firstTextBox.Text);
                secondTextBox.Text = Math.Round(converterCurrency.Convert(firstCurrency.Text, secondCurrency.Text, firstValue), 2).ToString();
            }
            catch (FormatException)
            {
                secondTextBox.Text = "0";
            }
        }

        private void ButtonClickSwap(object sender, RoutedEventArgs e)
        {
            string nameCurrency = firstCurrency.Text;
            firstCurrency.Text = secondCurrency.Text;
            secondCurrency.Text = nameCurrency;

            string valueCurrency = firstTextBox.Text;
            firstTextBox.Text = secondTextBox.Text;
            secondTextBox.Text = valueCurrency;
        }

        private void ButtonClickSelectCurrency(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectCurrencyPage), converterCurrency.GetNameCurrency());
        }
    }
}
