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
        public static Dictionary<int, GuideItem> GuideItems { get; set; } = new Dictionary<int, GuideItem>();

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

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(string), typeof(Guide), new PropertyMetadata("", AddGuide));

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.RegisterAttached("Index", typeof(int), typeof(Guide), new PropertyMetadata(0, AddGuide));

        private static void AddGuide(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ("Index".Equals(e.Property.ToString()))
            {
                var index = (int)e.NewValue;
                if (!GuideItems.ContainsKey(index))
                {
                    GuideItems[index] = new GuideItem();
                }
                GuideItems[index].Index = index;
                if (!string.IsNullOrEmpty(GetDescription(d)))
                {
                    GuideItems[index].Description = GetDescription(d);
                }
                GuideItems[index].Control = d as Control;
            }
            else if ("Description".Equals(e.Property.ToString()))
            {
                var des = e.NewValue.ToString();
                if (GetIndex(d) > -1)
                {
                    GuideItems[GetIndex(d)].Description = GetDescription(d);
                }
            }
        }
    }
}
