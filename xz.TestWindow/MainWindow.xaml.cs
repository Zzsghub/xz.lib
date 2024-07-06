﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xz.lib.WPF.AttachDependency;
using xz.lib.WPF.Pages;
using xz.lib.WPF.Util;

namespace xz.TestWindow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GuideUtil.GuideProcess<WindowTest>(this);

            MainWindow2 mainWindow2 = new MainWindow2();
            mainWindow2.Show();
        }


    }
}
