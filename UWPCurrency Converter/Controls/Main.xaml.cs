using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPCurrency_Converter.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPCurrency_Converter.Controls
{
    public sealed partial class Main : UserControl
    {
        Valute valute1, valute2;
        public List<Valute> Valutes { get; }


        public Main(List<Valute> valutes)
        {
            this.InitializeComponent();
            Valutes = valutes;
            valute1 = valutes[0];
            valute2 = valutes[1];//.Find(x=>x.CharCode == "USD");
        }

        private void valute1Count_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            decimal valute1CountParse;
            try
            {
                valute1CountParse = decimal.Parse(valute1Count.Text);
            }
            catch (Exception)
            {
                valute1CountParse = 0;
            }
            var valute2ValueCalculate = (valute1.Value / valute1.Nominal) / (valute2.Value / valute2.Nominal) * valute1CountParse;
            valute2Count.Text = $"{valute2ValueCalculate:0.####}";
        }

        private void valute2Count_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            decimal valute2CountParse;
            try
            {
                valute2CountParse = decimal.Parse(valute2Count.Text);
            }
            catch (Exception)
            {
                valute2CountParse = 0;
            }
            var valute2ValueCalculate = (valute2.Value / valute2.Nominal) / (valute1.Value / valute1.Nominal) * valute2CountParse;
            valute1Count.Text = $"{valute2ValueCalculate:0.####}";
        }

        private void UserControl_Loading(FrameworkElement sender, object args)
        {
            valute1Count.Text = "73";
            var valute2ValueCalculate = (valute1.Value / valute1.Nominal) / (valute2.Value / valute2.Nominal) * decimal.Parse(valute1Count.Text);
            valute2Count.Text = $"{valute2ValueCalculate:0.####}";
            valute1CharCode.Text = valute1.CharCode;
            valute2CharCode.Text = valute2.CharCode;
        }

    }
}
