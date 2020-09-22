using BoenaVista.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoenaVista.Viewmodel
{
    public class MainViewmodel : BaseNotifyPropertyChanged
    {
        BoenaVistaEntities context = new BoenaVistaEntities();
        public string Test
        {
            get => (string)GetProperty();

            set
            {
                SetProperty(value);
            }
        }
        public MainViewmodel()
        {
            changePage("Accueil");
            Test = "NoBDD";
            Test = (context.Machine.Find(0)!=null)?context.Machine.Find(0).Name:null;
            HideMenuButton = false;
            ShowMenuButton = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Test = context.Machine.Find(0).Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Action CloseAction { get; set; }


        //Menu Button -------------------
        public void changeShowMenuButton()
        {
            HideMenuButton = !HideMenuButton;
            ShowMenuButton = !ShowMenuButton;
        }

        public bool? ShowMenuButton
        {
            get
            {
                return (bool?)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public bool? HideMenuButton
        {
            get
            {
                return (bool?)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public Commandes.BaseCommand ChangeShowMenuButton => new Commandes.BaseCommand(changeShowMenuButton);

        //--------------------------

        public string PageView
        {
            get
            {
                return (string)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public Commandes.BaseCommand<string> ChangePage => new Commandes.BaseCommand<string>(changePage);

        public void changePage(string page)
        {
            switch (page)
            {
                case "Accueil":
                    PageView = "Accueil.xaml";
                    break;
                case "Planning":
                    PageView = "Planning.xaml";
                    break;
                case "Intervention":
                    PageView = "Intervention.xaml";
                    break;
                case "Technicien":
                    PageView = "Technicien.xaml";
                    break;
                case "ListMachine":
                    PageView = "ListMachine.xaml";
                    break;
                case "Machine":
                    PageView = "Machine.xaml";
                    break;
            }
        }

    }
}
