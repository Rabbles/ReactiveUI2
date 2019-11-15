using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace ReactiveUI2
{
    public class MainViewModel : ReactiveObject
    {
        private string name;
        private string message;

        public MainViewModel()
        {
            this.WhenAny(x => x.name, x => x.Value)
                .Select(this.GetMessage)
                .Do(message => this.Message = message)
                .Subscribe();
        }
 
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public string Message
        {
            get => message;
            set => this.RaiseAndSetIfChanged(ref message, value);
        }

        private string GetMessage(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return $"Enter your name";
            }
            return $"Welcome to the dinosuar book {name}";
        }
    }
}
