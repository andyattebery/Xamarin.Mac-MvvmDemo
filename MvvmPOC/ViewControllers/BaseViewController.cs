using System;
using AppKit;
using Foundation;
using Microsoft.Practices.ServiceLocation;
using ReactiveUI;

namespace MvvmPOC.ViewControllers
{
    public class BaseViewController<TViewModel> : NSViewController, IViewFor<TViewModel>
        where TViewModel : class
    {
        public TViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TViewModel)value;
        }

        // Called when created from unmanaged code
        public BaseViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public BaseViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public BaseViewController(string nibNameOrNull, NSBundle nibBundleOrNull) : base(nibNameOrNull, nibBundleOrNull)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
            ViewModel = ServiceLocator.Current.GetInstance<TViewModel>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }


    }
}
