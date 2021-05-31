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
    public class FillDetailsTypeOne : ContentPage
    {
        /// <summary>
        /// This is model which holds the API response which has the data to build dynamic form of this page.
        /// </summary>
        public PageTemplate template;
        public FillDetailsTypeOneViewModelSharp ViewModel;

        /// <summary>
        /// This is a reference to a utility class which has the methods to create the "control" objects, it also maps the field data received from the API response to the created "controls" objects.
        /// </summary>
        public UIUtilities<FillDetailsTypeOneViewModelSharp> uIUtilities;


        /// <summary>
        /// property is used to check for initial load; 
        /// 'True' = It's true by default signifying that initial load hasn't happened yet.
        /// 'False' = Signifies that initial load has taken place.
        /// </summary>
        private bool _isInitialLoad = true;

        public FillDetailsTypeOne()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            template = null; //resetting the page template;
            //BindingContext = new  FillDetailsTypeOneViewModelSharp(); // binding the viewmodel's context
            ViewModel = new FillDetailsTypeOneViewModelSharp();
        }

        protected override void OnAppearing()
        {
            LoadPageSettings();
            base.OnAppearing();
        }

        /// <summary>
        /// It's used to check whether page's controls details has been received from the api.
        /// If not, it waits for it to arrive.
        /// Once received it call's InitializeView() to process the page's controls.
        /// </summary>
        public void LoadPageSettings()
        {
            if (_isInitialLoad)
            {
                while (template == null) // wait till the data from api is getting loaded.
                {
                    template = ViewModel.PageTemplateInput; // show loader till data is getting loaded    
                    uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(ViewModel); // passing
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
                        parentLayout.Children.Add(uIUtilities.AddTextboxField(field));
                        break;

                    case "dropdown":
                        parentLayout.Children.Add(uIUtilities.AddDropdownField(field));
                        break;

                    case "numericTextBox":
                        parentLayout.Children.Add(uIUtilities.AddTextboxField(field, true));
                        break;
                }
            }

            parentLayout.Children.Add(new StackLayout()
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { new SubmitButton() { Command = ViewModel.SubmitCommand } }

            });

            Content = parentLayout;
        }
    }
}