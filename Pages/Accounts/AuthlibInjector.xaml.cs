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
    /// AuthlibInjector.xaml 的交互逻辑
    /// </summary>
    public partial class AuthlibInjector : Page
    {
        public class userinfo
        {
            public static string url { get; set; } = string.Empty;
            public static string email { get; set; } = string.Empty;
            public static string password { get; set; } = string.Empty;
        }

        public AuthlibInjector()
        {
            InitializeComponent();
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            userinfo.email = email.Text;
        }

        private void url_TextChanged(object sender, TextChangedEventArgs e)
        {
            userinfo.url = url.Text;
        }

        private void password_Changed(object sender, KeyEventArgs e)
        {
            userinfo.password = password.Password;
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            if (FSL.Pages.Account.miscAcc.aliUrl != string.Empty)
            {
                url.Text = FSL.Pages.Account.miscAcc.aliUrl;
            }
        }
    }
}
