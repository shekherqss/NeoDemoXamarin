using NeoDemoXam.Core.Template;
using NeoDemoXam.UI.Controls;
using NeoDemoXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NeoDemoXam.UI.Utils
{
    public interface IUIUtility<TViewModel> where TViewModel : BaseViewModel
    {
        TViewModel ViewModel { get; set; }

        StackLayout AddTextboxField(Field field, bool isNumeric = false);     
        StackLayout AddDropdownField(Field field);
        void Picker_SelectedIndexChanged(object sender, EventArgs e);
        void Textbox_UnFocused(object sender, EventArgs e);
    }
}
