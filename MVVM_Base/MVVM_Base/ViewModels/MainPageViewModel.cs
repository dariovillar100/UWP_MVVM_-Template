namespace MVVM_Base.ViewModels
{
    using MVVM_Base.ViewModels.Base;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;

    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {

        }

        private string _helloText;

        public string HelloText
        {
            get { return _helloText; }
            set { _helloText = value; RaisePropertyChanged(); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            HelloText = "Hello MVVM from ViewModel";
            return null;
        }
    }
}
