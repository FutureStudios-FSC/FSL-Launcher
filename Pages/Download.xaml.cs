using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
using StarLight_Core.Downloader;
using StarLight_Core.Installer;
using StarLight_Core.Utilities;

namespace FSL.Pages
{
    /// <summary>
    /// Download.xaml 的交互逻辑
    /// </summary>
    public partial class Download : Page
    {
        Downloads.List list = new Downloads.List();
        Downloads.Confirm confirm = new Downloads.Confirm();

        public class util
        {
            public static void SWList(Download download_)
            {
                download_.content.Content = new Frame()
                {
                    Content = download_.list
                };

            }
            public static void SWConfirm(Download download_)
            {
                download_.content.Content = new Frame()
                {
                    Content = download_.confirm
                };
            }

            public static Download publicDownload { get; set; }
        }
        

        public Download()
        {
            InitializeComponent();
            util.publicDownload = this;
            util.SWList(this);
        }
    }
}
