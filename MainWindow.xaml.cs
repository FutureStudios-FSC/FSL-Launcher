using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Models by StarLight.Core - Examples by ZhiFeng - Coded by FSC Team
// Copyright 2024 FSC Team. All rights Reserved.

namespace FSL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : HandyControl.Controls.Window
    {
        Pages.Home Home = new Pages.Home();
        Frame HomeF;

        Pages.About About = new Pages.About();
        Frame AboutF;

        Pages.Download Download = new Pages.Download();
        Frame DownloadF;

        Pages.Settings Settings = new Pages.Settings();
        Frame SettingsF;

        Pages.Account Account = new Pages.Account();
        Frame AccountF;

        public MainWindow()
        {
            InitializeComponent();

            // 定义页面
            HomeF = new Frame()
            {
                Content = Home
            };
            AboutF = new Frame()
            {
                Content = About
            };
            DownloadF = new Frame()
            {
                Content = Download
            };
            SettingsF = new Frame()
            {
                Content = Settings
            };
            AccountF = new Frame()
            {
                Content = Account
            };
        }

        private void HomepageSEL_Selected(object sender, RoutedEventArgs e)
        {
            Content.Content = HomeF;
        }

        private void AboutSEL_Selected(object sender, RoutedEventArgs e)
        {
            Content.Content = AboutF;
        }

        private void DownloadSEL_Selected(object sender, RoutedEventArgs e)
        {
            Content.Content = DownloadF;
        }

        private void SettingsSEL_Selected(object sender, RoutedEventArgs e)
        {
            Content.Content = SettingsF;
        }

        private void AccountSEL_Selected(object sender, RoutedEventArgs e)
        {
            Content.Content = AccountF;
        }

    }
}

// ↑ 早期人类违反 Don't Repeat Yourself (DRY) 原则珍贵影像

// 你找谁？？？（疑惑）
// 这里已经到底了，没必要翻了
// 找页面的代码？请问你有没有看见名为Pages的文件夹

/* 内幕和留言 */
// 说实话这个“Team”就只有我一个人（FSC小黄菌）
// 如果你倒腾文件把工程玩炸了，我只能说不关我的事