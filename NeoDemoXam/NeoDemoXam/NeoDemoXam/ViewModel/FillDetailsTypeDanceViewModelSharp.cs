using NeoDemoXam.Constants;
using NeoDemoXam.Core.Template;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeoDemoXam.ViewModel
{
    public class FillDetailsTypeDanceViewModelSharp : BaseViewModel, INotifyPropertyChanged
    {
        public FillDetailsTypeDanceViewModelSharp()
        {
        }

        public void LoadData()
        {
            Task.Run(async () =>
            {
                await Task.Delay(2000); // api call and response delay
                PageTemplateInput = JsonConvert.DeserializeObject<PageTemplate>(SerializedJson);
                OnPropertyChanged("PageTemplateInput");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _serializedJson = CoreConstants.DefaultSerializedJsonDance;
        public string SerializedJson
        {
            get
            {
                return _serializedJson;
            }
            set { _serializedJson = value; }
        }


        public Command SubmitCommand => new Command(() =>
        {
            var submit = this.PageTemplateInput;
        });
    }
}
