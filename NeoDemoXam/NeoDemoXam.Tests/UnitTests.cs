using NeoDemoXam.Constants;
using NeoDemoXam.Core.Template;
using NeoDemoXam.UI.Controls;
using NeoDemoXam.UI.Utils;
using NeoDemoXam.View;
using NeoDemoXam.ViewModel;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeoDemoXam.Tests
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
        }

        [Test]
        public void ADD_TEXTBOX_CUSTOM_CONTROL_METHOD_IS_ADDING_CORRECT_CONTROL()
        {
            //Arrange
            var resourceId = Guid.NewGuid().ToString();
            var inputField = new Field() { Label = "FirstName", FieldResourceId = resourceId, SelectedValue = string.Empty, Type = "textbox", Values = null };
            var uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(new FillDetailsTypeOneViewModelSharp());

            //Act
            var controlLayout = uIUtilities.AddTextboxField(inputField);
            var generatedControl = ((controlLayout.Children[1])).GetType();

            //Assert
            Assert.AreSame(generatedControl, typeof(TextboxControl));
        }


        [Test]
        public void ADD_TEXTBOX_CUSTOM_CONTROL_METHOD_MUST_ADD_TEXTBOX_LABEL_TOO()
        {
            //Arrange
            var resourceId = Guid.NewGuid().ToString();
            var inputField = new Field() { Label = "FirstName", FieldResourceId = resourceId, SelectedValue = string.Empty, Type = "textbox", Values = null };
            var uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(new FillDetailsTypeOneViewModelSharp());

            //Act
            var controlLayout = uIUtilities.AddTextboxField(inputField);
            var generatedControl = ((controlLayout.Children[0])).GetType();

            //Assert
            Assert.AreSame(generatedControl, typeof(LabelControl));
        }


        [Test]
        public void ADD_TEXTBOX_CUSTOM_CONTROL_METHOD_MUST_ADD_ALL_PROPERTIES_CORRECTLY()
        {
            //Arrange
            var resourceId = Guid.NewGuid().ToString();
            var inputField = new Field() { Label = "FirstName", FieldResourceId = resourceId, SelectedValue = string.Empty, Type = "textbox", Values = null };
            var uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(new FillDetailsTypeOneViewModelSharp());

            //Act
            var controlLayout = uIUtilities.AddTextboxField(inputField);
            (controlLayout.Children[1] as TextboxControl).Text = "dummy name";
            (controlLayout.Children[1] as TextboxControl).Unfocus();


            //Assert
            Assert.AreEqual((controlLayout.Children[0] as LabelControl).Text, inputField.Label);
            Assert.AreEqual((controlLayout.Children[1] as TextboxControl).Placeholder, string.Format("{0} {1}", "Enter", inputField.Label));
        }




        [Test]
        public void ADD_DROPDOWN_CUSTOM_CONTROL_METHOD_IS_ADDING_CORRECT_CONTROL()
        {
            //Arrange
            var resourceId = Guid.NewGuid().ToString();
            var inputField = new Field() { Label = "Numbers", FieldResourceId = resourceId, SelectedValue = string.Empty, Type = "dropdown", Values = new string[] { "ONE", "TWO" } };
            var uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(new FillDetailsTypeOneViewModelSharp());

            //Act
            var controlLayout = uIUtilities.AddDropdownField(inputField);
            var generatedControl = ((controlLayout.Children[1])).GetType();

            //Assert
            Assert.AreSame(generatedControl, typeof(DropdownControls));
        }


        [Test]
        public void ADD_DROPDOWN_CUSTOM_CONTROL_METHOD_MUST_ADD_DROPDOWN_LABEL_TOO()
        {
            //Arrange
            var resourceId = Guid.NewGuid().ToString();
            var inputField = new Field() { Label = "Numbers", FieldResourceId = resourceId, SelectedValue = string.Empty, Type = "dropdown", Values = new string[] { "ONE", "TWO" } };
            var uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(new FillDetailsTypeOneViewModelSharp());

            //Act
            var controlLayout = uIUtilities.AddDropdownField(inputField);
            var generatedControl = ((controlLayout.Children[0])).GetType();

            //Assert
            Assert.AreSame(generatedControl, typeof(LabelControl));
        }


        [Test]
        public void ADD_DROPDOWN_CUSTOM_CONTROL_METHOD_MUST_ADD_ALL_PROPERTIES_CORRECTLY()
        {
            //Arrange
            var resourceId = Guid.NewGuid().ToString();
            var inputField = new Field() { Label = "Numbers", FieldResourceId = resourceId, SelectedValue = string.Empty, Type = "dropdown", Values = new string[] { "ONE", "TWO" } };
            var uIUtilities = new UIUtilities<FillDetailsTypeOneViewModelSharp>(new FillDetailsTypeOneViewModelSharp());

            //Act
            var controlLayout = uIUtilities.AddDropdownField(inputField);

            //Assert
            Assert.AreEqual((controlLayout.Children[0] as LabelControl).Text, inputField.Label);
            Assert.AreEqual((controlLayout.Children[1] as DropdownControls).Title, string.Format("{0} {1}", "Select", inputField.Label));
            Assert.AreEqual((controlLayout.Children[1] as DropdownControls).Items.Count, inputField.Values.Length);
            Assert.AreEqual((controlLayout.Children[1] as DropdownControls).Items[0], inputField.Values[0]);
            Assert.AreEqual((controlLayout.Children[1] as DropdownControls).Items[1], inputField.Values[1]);
            Assert.AreNotEqual((controlLayout.Children[1] as DropdownControls).Items[0], inputField.Values[1]);
        }

        [Test]
        public void CHECK_PAGE_HAS_CORRECT_PAGE_TITLE_AND_HAS_A_SUBMIT_BUTTON()
        {
            //Arrange
            FillDetailsTypeOne page = new FillDetailsTypeOne();
            page.LoadPageSettings();

            //Action
            var deserilzedResp = JsonConvert.DeserializeObject<PageTemplate>(CoreConstants.DefaultSerializedJson);
            var content = page.Content as StackLayout;
            var chCount = content.Children.Count;
            var btnValue = (((content.Children[chCount - 1]) as StackLayout).Children[0] as SubmitButton).Text;

            //Assert
            Assert.AreEqual(page.template.Title, deserilzedResp.Title);
            Assert.AreEqual(btnValue, "Submit");
            Assert.AreNotEqual(btnValue, "");
            Assert.AreNotEqual(btnValue, null);
            Assert.AreNotEqual(btnValue, "abcd");
        }

        [Test]
        public void CHECK_PAGE_HAS_CORRECT_FORM_LAYOUT_BASED_ON_API_RESPONSE()
        {
            //Arrange
            FillDetailsTypeOne page = new FillDetailsTypeOne();
            page.LoadPageSettings();

            //Action
            var deserilzedResp = JsonConvert.DeserializeObject<PageTemplate>(CoreConstants.DefaultSerializedJson);
            var content = page.Content as StackLayout;
            var chCount = content.Children.Count;


            //Assert
            Assert.AreEqual(((content.Children[1] as StackLayout).Children[1]).GetType(), typeof(TextboxControl));
            Assert.AreEqual(((content.Children[1] as StackLayout).Children[1] as TextboxControl).ControlResourceId, page.ViewModel.PageTemplateInput.Fields[0].FieldResourceId);

            Assert.AreEqual(((content.Children[2] as StackLayout).Children[1]).GetType(), typeof(DropdownControls));
            Assert.AreEqual(((content.Children[2] as StackLayout).Children[1] as DropdownControls).ControlResourceId, page.ViewModel.PageTemplateInput.Fields[1].FieldResourceId);

            Assert.AreEqual(((content.Children[3] as StackLayout).Children[1]).GetType(), typeof(DropdownControls));
            Assert.AreEqual(((content.Children[3] as StackLayout).Children[1] as DropdownControls).ControlResourceId, page.ViewModel.PageTemplateInput.Fields[2].FieldResourceId);

            Assert.AreEqual(((content.Children[4] as StackLayout).Children[1]).GetType(), typeof(TextboxControl));
            Assert.AreEqual(((content.Children[4] as StackLayout).Children[1] as TextboxControl).ControlResourceId, page.ViewModel.PageTemplateInput.Fields[3].FieldResourceId);
        }

        [Test]
        public void CHECK_ENTERED_TEXTBOX_VALUE_IS_MAPPED_CORRECTLY()
        {

            //Arrange
            FillDetailsTypeOne page = new FillDetailsTypeOne();
            page.LoadPageSettings();
            var content = page.Content as StackLayout;
            var control = ((content.Children[1] as StackLayout).Children[1] as TextboxControl);

            //Act
            control.Text = "dummy";
            page.uIUtilities.Textbox_UnFocused(control, null);
            var value = page.ViewModel.PageTemplateInput.Fields.Where(x => x.FieldResourceId == control.ControlResourceId).FirstOrDefault().SelectedValue;

            //Assert
            Assert.AreEqual("dummy", value);

        }


        [Test]
        public void CHECK_SELECTED_DROPDOWN_VALUE_IS_MAPPED_CORRECTLY()
        {

            //Arrange
            FillDetailsTypeOne page = new FillDetailsTypeOne();
            page.LoadPageSettings();
            var content = page.Content as StackLayout;
            var control = ((content.Children[2] as StackLayout).Children[1] as DropdownControls);

            //Act
            control.SelectedItem = "Jazz";
            page.uIUtilities.Picker_SelectedIndexChanged(control, null);
            var value = page.ViewModel.PageTemplateInput.Fields.Where(x => x.FieldResourceId == control.ControlResourceId).FirstOrDefault().SelectedValue;

            //Assert
            Assert.AreEqual("Jazz", value);
        }
    }
}