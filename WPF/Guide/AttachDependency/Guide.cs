using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using xz.lib.WPF.Entity;
using xz.lib.WPF.Pages;

namespace xz.lib.WPF.AttachDependency
{
    public class Guide : DependencyObject
    {
        public static List<GuideItem> GuideItems { get; set; } = new List<GuideItem>();

        public static int GetIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(IndexProperty);
        }

        public static void SetIndex(DependencyObject obj, int value)
        {
            obj.SetValue(IndexProperty, value);
        }

        public static string GetDescription(DependencyObject obj)
        {
            return (string)obj.GetValue(DescriptionProperty);
        }

        public static void SetDescription(DependencyObject obj, string value)
        {
            obj.SetValue(DescriptionProperty, value);
        }



        public static string GetPageName(DependencyObject obj)
        {
            return (string)obj.GetValue(PageNameProperty);
        }

        public static void SetPageName(DependencyObject obj, string value)
        {
            obj.SetValue(PageNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for PageName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageNameProperty =
            DependencyProperty.RegisterAttached("PageName", typeof(string), typeof(Guide), new PropertyMetadata("", AddGuide));



        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(string), typeof(Guide), new PropertyMetadata("", AddGuide));

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.RegisterAttached("Index", typeof(int), typeof(Guide), new PropertyMetadata(-1, AddGuide));

        private static void AddGuide(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = GuideItems.FirstOrDefault(it => d.GetHashCode().Equals(it.ControlHashCode));
            if (item == null)
            {
                item = new GuideItem();
                item.Control = d as Control;
                item.ControlHashCode = d.GetHashCode();
                item.BelongPageName = GetPageName(d);
                GuideItems.Add(item);
            }
            switch (e.Property.ToString())
            {
                case "PageName":
                    item.BelongPageName = (string)e.NewValue;
                    break;
                case "Description":
                    item.Description = (string)e.NewValue;
                    break;
                case "Index":
                    item.Index = (int)e.NewValue;
                    break;
                default:
                    break;
            }

            //如果相同的条件下获取到两条记录
            if (item.Index != -1)
            {
                var list = GuideItems.Where(it => it.Index.Equals(GetIndex(d)) && it.BelongPageName.Equals(GetPageName(d))).ToList();
                if (list.Count > 2)
                {
                    var last = list.FirstOrDefault(it => !d.GetHashCode().Equals(it.ControlHashCode));
                    GuideItems.Remove(last);
                }
            }

        }
    }
}
