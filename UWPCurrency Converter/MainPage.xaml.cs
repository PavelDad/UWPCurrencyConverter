using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPCurrency_Converter.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPCurrency_Converter.Model;
using System.Text.Json;

namespace UWPCurrency_Converter
{
    public sealed partial class MainPage : Page
    {
        public List<Valute> Valutes { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            Load load = new Load();
            Grid.SetRow(load, 1);
            Grid.Children.Add(load);
                        
            var valute = JsonSerializer.Deserialize<DataSerialize>(await GetjsonStream());
            Valutes = valute.Valute.Select(x => x.Value).ToList();

            Grid.Children.Remove(load);

        }

        public async Task<string> GetjsonStream()
        {
            HttpClient client = new HttpClient();
            string url = "https://www.cbr-xml-daily.ru/daily_json.js";
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
