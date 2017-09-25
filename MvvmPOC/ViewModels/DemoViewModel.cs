using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace MvvmPOC.ViewModels
{
    public class DemoViewModel : BaseViewModel, IDisposable
    {
        public ICommand Multiply { get; }

        private string _input1;
        public string Input1
        {
            get => _input1;
            set => SetProperty(ref _input1, value);
        }
        private string _input2;
        public string Input2
        {
            get => _input2;
            set => SetProperty(ref _input2, value);
        }

        private string _product;
        public string Product
        {
            get => _product;
            private set => SetProperty(ref _product, value);
        }


        public string MultiplyErrors { get; }

        private IDisposable _input1Subscription;

        public DemoViewModel()
        {
            _input1Subscription = Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                eh => eh.Invoke,
                ev => this.PropertyChanged += ev,
                ev => this.PropertyChanged -= ev)
            .Where(e => e.EventArgs.PropertyName == nameof(Input1))
            .Select(e => Input1)
            .Subscribe(x => Product = x);
        }

        public void Dispose()
        {
            _input1Subscription.Dispose();
        }
    }
}
