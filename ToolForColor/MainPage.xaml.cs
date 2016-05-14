using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ToolForColor.SourceCShare;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ToolForColor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Show> ColorItem = new ObservableCollection<Show>();

        public MainPage()
        {
            this.InitializeComponent();

            opacityColorNum.Value = 255;
            redColorNum.Value    = 0;
            greenColorNum.Value  = 0;
            blueColorNum.Value   = 0;
            ColorListBox.ItemsSource = ColorItem;
        }

        private void selectColorNum(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color clr = Color.FromArgb((byte)opacityColorNum.Value, (byte)redColorNum.Value, (byte)greenColorNum.Value, (byte)blueColorNum.Value);

            ShowIt.Fill = new SolidColorBrush(clr);
            ShowNum.Text = clr.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColorItem.Add(new Show { colorItem = ShowNum.Text });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ColorListBox.SelectedItem != null)
            {
                Show showOne = ColorListBox.SelectedItem as Show;

                if (ColorItem.Contains(showOne))
                {
                    ColorItem.Remove(showOne);
                }
            }
        }
    }
}
