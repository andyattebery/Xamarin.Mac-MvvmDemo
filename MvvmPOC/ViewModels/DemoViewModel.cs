using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace MvvmPOC.ViewModels
{
    public class DemoViewModel : BaseViewModel
    {
        public ReactiveCommand<Unit, Unit> Concatenate { get; private set; }

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

        private string _result;
        public string Result
        {
            //get => _resultObservableHelper.Value;
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public DemoViewModel()
        {
            Concatenate = ReactiveCommand.CreateFromTask(async () =>
            {
                await Task.Run(() =>
                {
                    Result = ConcatenateString(Input1, Input2);
                });
            });
        }

        private string ConcatenateString(string input1, string input2)
        {
            return $"{input1}{input2}";
        }

    }
}
