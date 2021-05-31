﻿using NeoDemoXam.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NeoDemoXam.UI.Controls
{
    public class DropdownControls : Picker
    {
        public string ControlResourceId { get; set; }
        public DropdownControls()
        {
            base.Margin = new Thickness(50, 0, 50, 0);
            base.FontSize = 14;
            this.ControlResourceId = Guid.NewGuid().ToString();
            base.TextColor = Color.FromHex(UIConstants.Theme_Control_Text_Color);
        }
    }
}
