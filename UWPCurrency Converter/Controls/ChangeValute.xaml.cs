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
    /// <summary>
    /// Элемент для отображения списка и выбора вылют
    /// </summary>
    public sealed partial class ChangeValute : UserControl
    {
        private readonly Main _main;
        private readonly int _changingValute;
        List<Valute> _valutes;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="main">Ссылка на вызывающий элемент</param>
        /// <param name="changingValute">Номер валюты для выбора: 1 - левая, 2 - правая валюта</param>
        public ChangeValute(Main main, int changingValute)
        {
            this.InitializeComponent();
            _valutes = main.MainPage.Valutes;
            main.MainPage.SetTitle("Выбор валют");
            _main = main;
            _changingValute = changingValute;
        }
        /// <summary>
        /// Выбор элемента списка (валюты) и передача выбранной валюты в вызвавшее окно
        /// </summary>
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
