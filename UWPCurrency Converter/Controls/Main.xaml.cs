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
    /// <summary>
    /// Основное окно программы
    /// </summary>
    public sealed partial class Main : UserControl
    {
        public Valute valute1, valute2;
        public int ChangingValute;
        public MainPage MainPage;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mainPage">Ссылка на страницу, на которой отображается Control</param>
        public Main(MainPage mainPage)
        {
            this.InitializeComponent();
            valute1 = mainPage.Valutes[0];
            valute2 = mainPage.Valutes[1];
            MainPage = mainPage;
        }

        /// <summary>
        /// Нажатие клавиши левого поля для ввода
        /// </summary>
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

        /// <summary>
        /// Нажатие клавиши правого поля для ввода
        /// </summary>
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

        /// <summary>
        /// Выбор левой валюты
        /// </summary>
        private void HyperlinkButtonFirst_Click(object sender, RoutedEventArgs e)
        {
            ChangingValute = 1;
            ChangeValute changeValute = new ChangeValute(this, ChangingValute);
            Grid.SetRow(changeValute, 1);
            MainPage.MainGrid.Children.Add(changeValute);
            this.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Выбор правой валюты
        /// </summary>
        private void HyperlinkButtonSecond_Click(object sender, RoutedEventArgs e)
        {
            ChangingValute = 2;
            ChangeValute changeValute = new ChangeValute(this, ChangingValute);
            Grid.SetRow(changeValute, 1);
            MainPage.MainGrid.Children.Add(changeValute);
            this.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Загрузка компонента (заполнение начальными значениями)
        /// </summary>
        private void UserControl_Loading(FrameworkElement sender, object args)
        {
            valute1Count.Text = "1";
            var valute2ValueCalculate = (valute1.Value / valute1.Nominal) / (valute2.Value / valute2.Nominal) * decimal.Parse(valute1Count.Text);
            valute2Count.Text = $"{valute2ValueCalculate:0.####}";
            valute1CharCode.Text = valute1.CharCode;
            valute2CharCode.Text = valute2.CharCode;
        }

        /// <summary>
        /// Обновление сумм и надписей при выборе валюты
        /// </summary>
        public void ReloadValutes()
        {
            MainPage.SetTitle("Конвертер валют");
            valute1CharCode.Text = valute1.CharCode;
            valute2CharCode.Text = valute2.CharCode;
            if (ChangingValute == 1)
            {
                valute1Count_KeyUp(valute1Count, null);
            }
            else
            {
                valute2Count_KeyUp(valute2Count, null);
            }
            this.Visibility = Visibility.Visible;
        }
    }
}
