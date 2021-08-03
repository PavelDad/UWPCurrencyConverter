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

namespace UWPCurrency_Converter.Controls
{
    public sealed partial class ChangeValute : UserControl
    {
        private readonly Main _main;
        private readonly int _changingValute;
        List<Valute> _valutes;
        public ChangeValute(Main main, int changingValute)
        {
            this.InitializeComponent();
            _valutes = main.MainPage.Valutes;
            main.MainPage.SetTitle("Выбор валют");
            _main = main;
            _changingValute = changingValute;
        }

        private void ValuteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (_changingValute)
            {
                case 2: _main.valute2 = (Valute)ValuteList.SelectedItem;
                    break;
                default:
                    _main.valute1 = (Valute)ValuteList.SelectedItem;
                    break;
            }
            _main.ReloadValutes();
            _main.MainPage.MainGrid.Children.Remove(this);
        }
    }
}
