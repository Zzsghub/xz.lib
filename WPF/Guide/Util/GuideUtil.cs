using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using xz.lib.WPF.AttachDependency;
using xz.lib.WPF.Interface;
using xz.lib.WPF.Pages;

namespace xz.lib.WPF.Util
{
    public static class GuideUtil
    {
        public static void GuideProcess<T>(Window mainWindow) where T : Window, IGuide, new()
        {
            var list = Guide.GuideItems.Keys.ToList();
            list.Sort();
            GuideBackWindow navigate = new GuideBackWindow();

            foreach (var item in list)
            {
                var guideItem = Guide.GuideItems[item];
                Window window = Window.GetWindow(guideItem.Control);
                //该控件相对于Window的坐标
                var point = guideItem.Control.TransformToAncestor(window).Transform(new Point(0, 0));

                navigate.SetWindowLocation(mainWindow.Left, mainWindow.Top, mainWindow.ActualWidth, mainWindow.ActualHeight);
                navigate.SetNavigateBorderLocation(point.X, point.Y, guideItem.Control.ActualWidth, guideItem.Control.ActualHeight);
                navigate.Opacity = 0.4;
                navigate.Show();

                T t = new T();
                var guidePoint = CalculatePoint(guideItem, t);
                t.SetGuideInfo(item, guideItem.Description, list.Count);
                t.Left = guidePoint.X;
                t.Top = guidePoint.Y;
                t.ShowDialog();

                if (t.GetDialogResult() == System.Windows.Forms.DialogResult.Cancel)
                {
                    break;
                }
            }
            navigate.Close();
        }

        private static Point CalculatePoint(lib.WPF.Entity.GuideItem guideItem, Window guide)
        {
            //该控件相对于整个屏幕的坐标
            var pointOfScreen = guideItem.Control.PointToScreen(new Point(guideItem.Control.ActualWidth + 10, guideItem.Control.ActualHeight + 10));

            //屏幕的分辨率
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;


            //右下角
            if ((pointOfScreen.X + guide.Width + 10 > screenWidth) && (pointOfScreen.Y + guide.Height + 10 > screenHeight))
            {
                return new Point(pointOfScreen.X - guideItem.Control.ActualWidth - 20 - guide.Width
                    , pointOfScreen.Y - guide.Height - 20 - guideItem.Control.ActualHeight);
            }

            //屏幕底部
            if (pointOfScreen.Y + guide.Height + 10 > screenHeight)
            {
                return new Point(pointOfScreen.X, pointOfScreen.Y - guide.Height - 20 - guideItem.Control.ActualHeight);
            }

            //右上角
            if (pointOfScreen.X + guide.Width + 10 > screenWidth)
            {
                return new Point(pointOfScreen.X - guideItem.Control.ActualWidth - 20 - guide.Width, pointOfScreen.Y);
            }

            return pointOfScreen;
        }
    }
}
