using System;
using System.Collections.Generic;
using System.Diagnostics;
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

using HandyControl.Controls;
using StarLight_Core.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace FSL.Pages.Accounts
{
    /// <summary>
    /// Microsoft.xaml 的交互逻辑
    /// </summary>
    public partial class Microsoft : Page
    {
        public class userinfo
        {
            public static string asyncs { get; set; }
        }

        public Microsoft()
        {
            InitializeComponent();
            
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            var msAuth = new MicrosoftAuthentication("e1e383f9-59d9-4aa2-bf5e-73fe83b15ba0");
            var deviceCodeInfo = await msAuth.RetrieveDeviceCodeInfo();
            Process.Start(new ProcessStartInfo
            {
                FileName = deviceCodeInfo.VerificationUri,
                UseShellExecute = true
            });
            HandyControl.Controls.MessageBox.Show("你的验证地址为：" + deviceCodeInfo.VerificationUri + "，\n请输入下方的代码来完成验证，切勿泄露给他人。\n" + deviceCodeInfo.UserCode + "\n验证成功后，请关闭浏览器和弹窗，等待验证成功！", "Microsoft 正版登录");

            var tokenInfo = await msAuth.GetTokenResponse(deviceCodeInfo);
            dynamic userInfo = 1145;

            try
            {
                userInfo = await msAuth.MicrosoftAuthAsync(tokenInfo, x =>
                {
                    Console.WriteLine(x);
                });
                userinfo.asyncs = userInfo; 
                accInfo.Content = "你已经成功登录 Microsoft 账户！\n"+userInfo.Name + "（" + userInfo.Uuid + "）"+"\n";
                HandyControl.Controls.MessageBox.Show("你现在已经成功登录到你的Microsoft账户，可以继续。\n" + "你的账户名为：" + userInfo.Name, "验证成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show("Microsoft 登录失败，如果你还没有购买 Minecraft Java 版，请去 Minecraft 官网或 Microsoft Xbox 购买！\n" + ex.Message, "验证失败", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
