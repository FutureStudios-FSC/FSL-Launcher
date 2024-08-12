using StarLight_Core.Utilities;
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

namespace FSL.Pages.Downloads
{
    /// <summary>
    /// List.xaml 的交互逻辑
    /// </summary>
    public partial class List : Page
    {
        public class downloadInfo
        {
            public static string id { get; set; } = string.Empty;
        }
        public List()
        {
            InitializeComponent();
            refreshCore();
            versions.DisplayMemberPath = "Id";
            versions.SelectedValuePath = "Id";
        }
        private async void refreshCore()
        {
            versions.ItemsSource = await InstallUtil.GetGameCoresAsync();
        }

        private async void refresh_Click(object sender, RoutedEventArgs e)
        {
            refreshCore();
        }

        private void versions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            versinput.Text = versions.SelectedValue.ToString();
        }

        private void versinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            downloadInfo.id = versinput.Text;
        }

        private void download_Click(object sender, RoutedEventArgs e)
        {
            Downloads.Confirm.util.id = versinput.Text;
            Downloads.Confirm.util.refresh(Downloads.Confirm.util.publicDownloadConfirm);
            Download.util.SWConfirm(Download.util.publicDownload);
        }
    }
}
