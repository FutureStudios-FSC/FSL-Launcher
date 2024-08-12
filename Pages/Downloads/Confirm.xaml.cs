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

using StarLight_Core.Downloader;
using StarLight_Core.Installer;

using StarLight_Core.Utilities;

using HandyControl.Controls;
using StarLight_Core.Models.Utilities;
using System.Security.Cryptography.X509Certificates;

namespace FSL.Pages.Downloads
{
    /// <summary>
    /// Confirm.xaml 的交互逻辑
    /// </summary>
    public partial class Confirm : Page
    {
        public class util
        {
            public static string id { get; set; } = "无信息";
            public static Downloads.Confirm publicDownloadConfirm { get; set; }
            public static void refresh(Downloads.Confirm confirm_)
            {
                confirm_.label.Content = "确认安装 " + util.id;
            }
        }

        public Confirm()
        {
            InitializeComponent();

            util.publicDownloadConfirm = this;
            label.Content = "确认安装 " + util.id;

            try
            {
                var info = InstallUtil.GetGameCoreAsync(util.id);
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show("无法获取游戏核心信息，请确认输入是否有误！\n"+ex.Message,"核心信息获取失败",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Download.util.SWList(Download.util.publicDownload);
        }
    }
}
