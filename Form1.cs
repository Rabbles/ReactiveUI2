using System.Windows.Forms;
using ReactiveUI;
using System.Reactive.Disposables;

namespace ReactiveUI2
{
    public partial class Form1 : Form, IViewFor<MainViewModel>
    {
        public Form1()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();

            this.WhenActivated(
                disposables =>
                {
                this.Bind(ViewModel, vm => vm.Name, v => v.textBoxName.Text)
                 .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.Message, v => v.labelMessage.Text)
                .DisposeWith(disposables);
                });


        }

        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }
    }
}
