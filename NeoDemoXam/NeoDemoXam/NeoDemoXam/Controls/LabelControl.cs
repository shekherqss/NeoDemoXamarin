﻿using NeoDemoXam.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NeoDemoXam.UI.Controls
{
    //TextColor="#333333"  FontFamily="{StaticResource RegularFont}" FontSize="16"  Margin="50,20,50,0"
    public class LabelControl : Label
    {
        public LabelControl()
        {
            base.TextColor = Color.FromHex(UIConstants.Theme_Control_Text_Color);
            base.FontSize = 16;
            base.Margin = new Thickness(50, 20, 50, 0);
        }
    }
}
