namespace MVVM_Base.Views.Base
{
    using ViewModels.Base;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public class PageBase : Page
    {
        private ViewModelBase _viewModelBase;
        private Frame _splitViewFrame;

        public Frame SplitViewFrame
        {
            get { return _splitViewFrame; }
            set
            {
                _splitViewFrame = value;
                if(_splitViewFrame == null)
                {
                    _viewModelBase = (ViewModelBase)this.DataContext;
                    _viewModelBase.SetSplitFrame(_splitViewFrame);
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _viewModelBase = (ViewModelBase)this.DataContext;
            _viewModelBase.SetRootFrame(this.Frame);
            _viewModelBase.OnNavigatedTo(e);

            //Active go back navigation and button visibility.
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += EntryPage_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _viewModelBase.OnNavigatedFrom(e);
        }

        private void EntryPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if(SplitViewFrame != null)
            {
                if (_splitViewFrame.CanGoBack)
                {
                    e.Handled = true;
                    _splitViewFrame.GoBack();
                }
            }
        }
    }
}
