using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace xz.lib.WPF.Entity
{
    public class GuideItem
    {
        public int Index { get; set; }

        public string Description { get; set; }

        public Control Control { get; set; }

        public int ControlHashCode { get; set; }

        public string BelongPageName { get; set; }

    }
}
