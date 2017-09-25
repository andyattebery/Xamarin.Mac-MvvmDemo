using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using MvvmPOC.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive.Disposables;
using System.ComponentModel;

namespace MvvmPOC.ViewControllers
{
    public partial class DemoController : BaseViewController<DemoViewModel>
    {
        #region Constructors

        // Called when created from unmanaged code
        public DemoController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public DemoController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public DemoController() : base("Demo", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //this.WhenActivated(disposable =>
            //{
            //this.Bind(ViewModel,
            //vm => vm.Input1 ?? string.Empty,
            //vc => vc.input1TextField.StringValue);
            //.DisposeWith(disposable);

            //this.OneWayBind(ViewModel,
            //vm => vm.Product ?? string.Empty,
            //vc => vc.productTextField.StringValue);
            //.DisposeWith(disposable);
            //});

            Observable.FromEventPattern<EventHandler, EventArgs>(
                ev => input1TextField.Changed += ev,
                ev => input1TextField.Changed -= ev)
            .Select(e => input1TextField.StringValue)
            .Subscribe(x => ViewModel.Input1 = x);

            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                eh => eh.Invoke,
                ev => ViewModel.PropertyChanged += ev,
                ev => ViewModel.PropertyChanged -= ev)
            .Where(e => e.EventArgs.PropertyName == nameof(DemoViewModel.Product))
            .Select(e => ViewModel.Product)
            .Subscribe(x => productTextField.StringValue = x);
        }

        #endregion

        //strongly typed view accessor
        public new Demo View
        {
            get
            {
                return (Demo)base.View;
            }
        }
    }
}
