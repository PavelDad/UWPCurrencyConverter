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
    public sealed partial class Load : UserControl
    {
        //Timer timer = new Timer(10);
        public Load()
        {
            this.InitializeComponent();
            MyStoryBoard.Begin();
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();
        }

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    if (SpinerRotate.Rotation == 360)
        //    {
        //        SpinerRotate.Rotation = 1;
        //    }
        //    else
        //    {
        //        SpinerRotate.Rotation++;
        //    }
        //}

        private void Grid_Loading(FrameworkElement sender, object args)
        {

        }
    }
}
