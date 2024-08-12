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
using System.Diagnostics;

using HandyControl.Controls;
using StarLight_Core.Authentication;
using System.Security.Policy;
using StarLight_Core.Utilities;
using FSL.Pages.Accounts;

namespace FSL.Pages
{
    /// <summary>
    /// Account.xaml 的交互逻辑
    /// </summary>
    public partial class Account : Page
    {
        public class miscAcc
        {
            public static string aliUrl { get; set; } = string.Empty;
        }
        Accounts.Offline Offline = new Accounts.Offline();
        Accounts.Microsoft Microsoft = new Accounts.Microsoft();
        Accounts.AuthlibInjector AuthlibInjector = new Accounts.AuthlibInjector();

        public Account()
        {
            InitializeComponent();
        }

        private async void accountCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FSL.Pages.Home.info.accountType = accountCombo.SelectedIndex;
            switch(accountCombo.SelectedIndex)
            {
                case 0:
                    content.Content = new Frame()
                    {
                        Content = Offline
                    };
                    break;
                case 1:
                    content.Content = new Frame()
                    {
                        Content = Microsoft
                    };
                    break;
                case 2:
                    content.Content = new Frame()
                    {
                        Content = AuthlibInjector
                    };
                    break;
            }
        }

        /*
        private void checkAuth(object sender, DragEventArgs e)
        {
                string[] data = e.Data.GetData(DataFormats.UnicodeText) as string[];
                HandyControl.Controls.MessageBox.Show(data[0]);
                if (data != null && data.Length > 0)
                {
                    string dataString = data[0];
                    if (dataString.Contains("authlib-injector:yggdrasil-server:"))
                    {
                        var confirm = HandyControl.Controls.MessageBox.Show("是否要以" + dataString.Split("authlib-injector:yggdrasil-server:")[1] + "\n来加载你的 Authlib Injector？", "确认加载 Authlib Injector", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (confirm == MessageBoxResult.Yes)
                        {
                            miscAcc.aliUrl = dataString.Split("authlib-injector:yggdrasil-server:")[1];
                        }
                        accountCombo.SelectedIndex = 2;
                    }
                }
                else
                {
                    // Handle the case when no data is available.
                    var confirm = HandyControl.Controls.MessageBox.Show("无法识别拖拽的信息", "无法加载 Authlib Injector", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
        */
    }
}
