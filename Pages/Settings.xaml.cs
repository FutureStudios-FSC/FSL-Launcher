using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using StarLight_Core.Utilities;

namespace FSL.Pages
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            
            javaCombo.ItemsSource = JavaUtil.GetJavas();
            javaCombo.DisplayMemberPath = "JavaVersion";
            javaCombo.SelectedValuePath = "JavaPath";
        }

        private void memorySlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<HandyControl.Data.DoubleRange> e)
        {
            memorySlide.ValueStart = Math.Floor(memorySlide.ValueStart);
            memorySlide.ValueEnd = Math.Floor(memorySlide.ValueEnd);
            memoryText.Text = "内存限制：" + memorySlide.ValueStart +  "~" + memorySlide.ValueEnd;
        }

        private void javaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            javaPath.Text = javaCombo.SelectedValue.ToString();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            FSL.Pages.Home.info.windowFS = (bool)windowFullscreen.IsChecked;
            FSL.Pages.Home.info.javaPaths = javaPath.Text;
            FSL.Pages.Home.info.memory1 = (int) memorySlide.ValueStart;
            FSL.Pages.Home.info.memory2 = (int) memorySlide.ValueEnd;
            FSL.Pages.Home.info.windowSizes = windowSize.Text;
        }
    }
}
