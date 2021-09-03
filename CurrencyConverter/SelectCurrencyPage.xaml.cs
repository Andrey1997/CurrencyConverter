using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CurrencyConverter
{
    public sealed partial class SelectCurrencyPage : Page
    {
        public SelectCurrencyPage()
        {
            this.InitializeComponent();
        }

        private void ButtonClickBack(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            string[] tokens = content.Split(' ');
            this.Frame.Navigate(typeof(MainPage), tokens[0]);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                List<string> currencys = (List<string>)e.Parameter;
                foreach(string currency in currencys)
                {
                    Button button = new Button
                    {
                        Content = currency

                    };

                    button.Click += ButtonClickBack;
                    button.Width = scrollViewer.Width;

                    stackPanel.Children.Add(button);
                }
            }
        }
    }
}
