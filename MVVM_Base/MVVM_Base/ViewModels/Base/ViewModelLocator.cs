namespace MVVM_Base.ViewModels.Base
{
    using Microsoft.Practices.Unity;

    public class ViewModelLocator
    {
        readonly IUnityContainer container;

        public ViewModelLocator()
        {
            container = new UnityContainer();

            container.RegisterType<MainPageViewModel>();
        }

        public MainPageViewModel MainPageViewModel => container.Resolve<MainPageViewModel>();
    }
}
