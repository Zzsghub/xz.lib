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

namespace xz.lib.WPF.Pages
{
    /// <summary>
    /// NavigateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GuideBackWindow : Window
    {
        #region 依赖属性
        public double BorderX
        {
            get
            {
                return (double)base.GetValue(GuideBackWindow.BorderXProperty);
            }
            set
            {
                base.SetValue(GuideBackWindow.BorderXProperty, value);
            }
        }

        public double BorderY
        {
            get
            {
                return (double)base.GetValue(GuideBackWindow.BorderYProperty);
            }
            set
            {
                base.SetValue(GuideBackWindow.BorderYProperty, value);
            }
        }

        public double BorderWidth
        {
            get
            {
                return (double)base.GetValue(GuideBackWindow.BorderWidthProperty);
            }
            set
            {
                base.SetValue(GuideBackWindow.BorderWidthProperty, value);
            }
        }

        public double BorderHeight
        {
            get
            {
                return (double)base.GetValue(GuideBackWindow.BorderHeightProperty);
            }
            set
            {
                base.SetValue(GuideBackWindow.BorderHeightProperty, value);
            }
        }

        public static readonly DependencyProperty BorderXProperty = DependencyProperty.Register("BorderX", typeof(double), typeof(GuideBackWindow), new PropertyMetadata(0d));

        public static readonly DependencyProperty BorderYProperty = DependencyProperty.Register("BorderY", typeof(double), typeof(GuideBackWindow), new PropertyMetadata(0d));

        public static readonly DependencyProperty BorderWidthProperty = DependencyProperty.Register("BorderWidth", typeof(double), typeof(GuideBackWindow), new PropertyMetadata(0d));

        public static readonly DependencyProperty BorderHeightProperty = DependencyProperty.Register("BorderHeight", typeof(double), typeof(GuideBackWindow), new PropertyMetadata(0d));
        #endregion

        public GuideBackWindow()
        {
            InitializeComponent();
            this.canvas.DataContext = this;
        }

        public void SetWindowLocation(double left, double top, double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.Left = left;
            this.Top = top;
        }

        public void SetNavigateBorderLocation(double x, double y, double width, double height)
        {
            BorderX = x + 2;
            BorderY = y + 25;
            BorderWidth = width + 10;
            BorderHeight = height + 10;
        }
    }
}
