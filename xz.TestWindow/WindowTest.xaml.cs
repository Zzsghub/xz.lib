using System;
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
using System.Windows.Shapes;
using xz.lib.WPF.Interface;
using xz.lib.WPF.Pages;

namespace xz.TestWindow
{
    /// <summary>
    /// WindowTest.xaml 的交互逻辑
    /// </summary>
    public partial class WindowTest : Window, IGuide
    {
        public WindowTest()
        {
            InitializeComponent();
        }

        public DialogResult GetDialogResult()
        {
            return System.Windows.Forms.DialogResult.OK;
        }

        public void SetGuideInfo(int index, string desc, int total)
        {

        }
    }
}
