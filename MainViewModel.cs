using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace ReactiveUI2
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            this.WhenAnyValue(vm => vm.Name)
                .Select(this.GetMessage)
                .Do(message => this.Message = message)
                .Subscribe();
        }
 
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Message { get; set; }

        private string GetMessage(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Enter your name";
            }
            return $"Welcome to the future {name}, ReactiveUI with Winforms.";
        }
    }
}
