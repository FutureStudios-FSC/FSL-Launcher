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

using HandyControl.Controls;

using StarLight_Core.Utilities;
using StarLight_Core.Authentication;
using StarLight_Core.Launch;
using StarLight_Core.Models.Launch;
using StarLight_Core.Enum;

namespace FSL.Pages
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        public class info
        {
            public static string javaPaths { get; set; }
            public static int memory1 { get; set; } = 100;
            public static int memory2 { get; set; } = 10000;
            public static string windowSizes { get; set; } = "854x480";
            public static bool windowFS { get; set; } = false;
            public static int accountType { get; set; }
        }

        string gcPath;
        public Home()
        {
            InitializeComponent();
            gcPath = ".minecraft";

            try
            {
                STARTdropdown.ItemsSource = GameCoreUtil.GetGameCores(gcPath);
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show("请检查目录是否正确、能否正常访问，并且尝试刷新或以管理员身份运行\n\n技术支持信息：\n"+ex.ToString(),"游戏核心获取失败！", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            STARTdropdown.DisplayMemberPath = "Id";
            STARTdropdown.SelectedValuePath = "Id";
        }

        private void STARTdropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gamecore.Text = STARTdropdown.SelectedValue.ToString();
        }

        private void gcInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            gcPath = gcInput.Text;
        }

        private void gcRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                STARTdropdown.ItemsSource = GameCoreUtil.GetGameCores(gcPath);
            }
            catch(Exception ex)
            {
                HandyControl.Controls.MessageBox.Show(ex.ToString(), "游戏核心获取失败！",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private async void START_Click(object sender, RoutedEventArgs e)
        {
            string gcp = gcInput.Text;
            if(gcInput.Text == string.Empty)
            {
                gcp = ".minecraft";
            }

            if(STARTdropdown.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                var core = GameCoreUtil.GetGameCore(STARTdropdown.SelectedValue.ToString(), gcp);
                dynamic account = null;
                string[] size = info.windowSizes.Split("x");

                switch (info.accountType)
                {
                    case 0:
                        account = new OfflineAuthentication(FSL.Pages.Accounts.Offline.userinfo.username).OfflineAuth();
                        break;
                    case 1:
                        account = new MicrosoftAuthentication(FSL.Pages.Accounts.Microsoft.userinfo.asyncs);
                        break;
                    case 2:
                        account = new YggdrasilAuthenticator(FSL.Pages.Accounts.AuthlibInjector.userinfo.url, FSL.Pages.Accounts.AuthlibInjector.userinfo.email, FSL.Pages.Accounts.AuthlibInjector.userinfo.password).YggdrasilAuthAsync();
                        break;
                }

                string[] arg = ["-XX:+UseG1GC -XX:-UseAdaptiveSizePolicy -XX:-OmitStackTraceInFastThrow -Dfml.ignoreInvalidMinecraftCertificates=True -Dfml.ignorePatchDiscrepancies=True -Dlog4j2.formatMsgNoLookups=true"];
                
                LaunchConfig args = new() // 配置启动参数
                {
                    Account = new()
                    {
                        BaseAccount = account // 账户
                    },
                    GameCoreConfig = new()
                    {
                        Root = gcInput.Text,
                        Version = core.Id,
                        IsVersionIsolation = false,
                        GameArguments = arg
                    },
                    GameWindowConfig = new()
                    {
                        Height = Convert.ToInt32(size[1]),
                        Width = Convert.ToInt32(size[0]),
                        IsFullScreen = info.windowFS
                    },
                    JavaConfig = new()
                    {
                        JavaPath = info.javaPaths, // Java 路径(绝对路径)
                        MaxMemory = Convert.ToInt32(info.memory2),
                        MinMemory = Convert.ToInt32(info.memory1),
               
                    }
                };

                void ReportProgress(ProgressReport report)
                {
                    progress.Value = report.Percentage;
                    progressText.Content = report.Description;
                }

                var launch = new MinecraftLauncher(args); // 实例化启动器

                var result = await launch.LaunchAsync(ReportProgress); // 启动

                if (result.Status == Status.Succeeded && progress.Value >= 90)
                {
                    HandyControl.Controls.MessageBox.Show("Minecraft启动成功！\n请耐心等待窗口出现...\n如果长时间未启动，请尝试将启动器放置在可以正常访问（非管理员）文件夹！","启动成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    HandyControl.Controls.MessageBox.Show("请检查游戏文件是否完整，信息是否填写完毕：\n" + result.Exception.Message,"启动失败", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show("发生了未经处理的异常，请检查信息填写无误，若无法解决请截图反馈：\n"+ex,"启动失败",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        
    }
}
