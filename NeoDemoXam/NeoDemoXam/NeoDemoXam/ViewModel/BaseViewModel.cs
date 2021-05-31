using NeoDemoXam.Core.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeoDemoXam.ViewModel
{
    public class BaseViewModel
    {
        private PageTemplate _pageTemplateInput = default;
        public PageTemplate PageTemplateInput
        {
            get
            {
                return _pageTemplateInput;
            }
            set 
            {
                _pageTemplateInput = value;
            }
        }
    }
}
