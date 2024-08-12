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

namespace FSL.Pages.Accounts
{
    /// <summary>
    /// Offline.xaml 的交互逻辑
    /// </summary>
    public partial class Offline : Page
    {
        public class userinfo
        {
            public static string username { get; set; }
        }
        public Offline()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userinfo.username = name.Text;
        }
    }
}
