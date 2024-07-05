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
using System.Windows.Navigation;
using System.Windows.Shapes;
using xz.lib.WPF.Interface;

namespace xz.lib.WPF.Pages
{
    /// <summary>
    /// GuidePattern.xaml 的交互逻辑
    /// </summary>
    public partial class GuideWindow : Window, IGuide
    {
        protected static DialogResult dialogResult = System.Windows.Forms.DialogResult.OK;

        public GuideWindow()
        {
            InitializeComponent();
        }

        public void SetGuideInfo(int index, string desc, int total)
        {
            tbox_title.Text = string.Format("您正在进行软件使用指引({0}/{1})", index, total);
            tbox_desc.Text = desc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            dialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public System.Windows.Forms.DialogResult GetDialogResult()
        {
            var res = dialogResult;
            dialogResult = System.Windows.Forms.DialogResult.OK;
            return res;
        }
    }
}
