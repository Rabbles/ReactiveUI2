using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReactiveUI;

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
                   disposables(this.Bind(ViewModel, x => x.Name, x => x.textBoxName.Text));
                   disposables(this.OneWayBind(ViewModel, x => x.Message, x => x.labelMessage.Text));
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
