using CommonServiceLocator;
using NeoDemoXam.UI.Utils;
using NeoDemoXam.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.ServiceLocation;

namespace NeoDemoXam.Bootstrap
{
    public class AppContainer
    {
        private static UnityContainer _unityContainer;
        public static void RegisterDependencies()
        {

            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<FillDetailsTypeMusicViewModelSharp>();
            _unityContainer.RegisterType<IUIUtility<FillDetailsTypeMusicViewModelSharp>, UIUtility<FillDetailsTypeMusicViewModelSharp>>();
            _unityContainer.RegisterType<IUIUtility<FillDetailsTypeDanceViewModelSharp>, UIUtility<FillDetailsTypeDanceViewModelSharp>>();
            _unityContainer.RegisterType<IUIUtility<FillDetailsTypeDramaViewModelSharp>, UIUtility<FillDetailsTypeDramaViewModelSharp>>();
            var unityServiceLocator = new UnityServiceLocator(_unityContainer);

            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);            
        }

        public static T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }
    }
}
