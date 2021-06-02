using NeoDemoXam.Bootstrap;
using NeoDemoXam.Core.Template;
using NeoDemoXam.UI.Controls;
using NeoDemoXam.UI.Utils;
using NeoDemoXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NeoDemoXam.View
{
    public class FillDetailsTypeMusic : ContentPage
    {

        /// <summary>
        /// property is used to check for initial load; 
        /// 'True' = It's true by default signifying that initial load hasn't happened yet.
        /// 'False' = Signifies that initial load has taken place.
        /// </summary>
        private bool _isInitialLoad = true;

        /// <summary>
        /// This is a reference to a utility class which has the methods to create the "control" objects, it also maps the field data received from the API response to the created "controls" objects.
        /// </summary>
        public IUIUtility<FillDetailsTypeMusicViewModelSharp> viewUtility;

        /// <summary>
        /// This is model which holds the API response which has the data to build dynamic form of this page.
        /// </summary>
        public PageTemplate template;


        public FillDetailsTypeMusic()
        {
        }

        protected override void OnAppearing()
        {
            BindReferences();
            LoadPageSettings();
            base.OnAppearing();
        }


        public void BindReferences()
        {
            var _viewUtility = AppContainer.Resolve<IUIUtility<FillDetailsTypeMusicViewModelSharp>>();
            viewUtility = _viewUtility;
            BindingContext = viewUtility.ViewModel;
        }


        // <summary>
        /// It's used to check whether page's controls details has been received from the api.
        /// If not, it waits for it to arrive.
        /// Once received it call's InitializeView() to process the page's controls.
        /// </summary>
        public void LoadPageSettings()
        {

            if (_isInitialLoad)
            {
                (BindingContext as FillDetailsTypeMusicViewModelSharp).LoadData();
                while (template == null)
                {
                    template = viewUtility.ViewModel.PageTemplateInput;                   
                }

                InitializeView(template); // load controls based on the response from the api                               
            }

            _isInitialLoad = false;
        }



        /// <summary>
        /// This method takes the parsed json response from API which contains the structure of the controls to be rendered on this page, it iterates through the
        /// list of controls and render them accordingly.
        /// </summary>
        /// <param name="template">This parameters is the parsed version of API response which contains the page structure and list of controls to create a dynamic form.</param>
        public void InitializeView(PageTemplate template)
        {
            var parentLayout = new StackLayout
            {

            };

            parentLayout.Children.Add(new PageTitleControl() { Text = template.Title });

            foreach (var field in template.Fields)
            {
                switch (field.Type)
                {
                    case "textbox":
                        parentLayout.Children.Add(viewUtility.AddTextboxField(field));
                        break;

                    case "dropdown":
                        parentLayout.Children.Add(viewUtility.AddDropdownField(field));
                        break;

                    case "numericTextBox":
                        parentLayout.Children.Add(viewUtility.AddTextboxField(field, true));
                        break;
                }
            }

            parentLayout.Children.Add(new StackLayout()
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { new SubmitButton() { Command = viewUtility.ViewModel.SubmitCommand } }

            });

            Content = parentLayout;
        }
    }
}