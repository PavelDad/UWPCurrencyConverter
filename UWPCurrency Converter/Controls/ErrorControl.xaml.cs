using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Окно для отображения ошибки
    /// </summary>
    public sealed partial class ErrorControl : UserControl
    {
        public string TextError { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="textError">Текст ошибки</param>
        public ErrorControl(string textError)
        {
            if (string.IsNullOrWhiteSpace(textError))
            {
                TextError = "Непредвиденная ошибка, перезапустите программу.";
            }
            this.InitializeComponent();
            TextError = textError;
        }
    }
}
