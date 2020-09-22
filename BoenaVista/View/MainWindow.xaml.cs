using BoenaVista.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoenaVista.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewmodel viewModel = new MainViewmodel();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.DataContext = this.viewModel;
                viewModel.CloseAction = new Action(() => this.Close());
            };
        }
    }
}
