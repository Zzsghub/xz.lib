using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xz.lib.WPF.Interface
{
    public interface IGuide
    {
        void SetGuideInfo(int index, string desc, int total);

        System.Windows.Forms.DialogResult GetDialogResult();
    }
}
