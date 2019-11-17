using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismRefrenceApp.Infrastructure;
using PrismRefrenceApp.Toolbar.Views;

namespace PrismRefrenceApp.Toolbar.ViewModels
{
    public class ToolbarViewModel : ViewModelBase, IToolbarViewModel
    {
        public ToolbarViewModel(IToolbarView view)
            : base(view)
        {

        }
    }
}
