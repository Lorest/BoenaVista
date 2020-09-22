using BoenaVista.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoenaVista.Viewmodel
{
    class MachineViewmodel : BaseNotifyPropertyChanged
    {
        public class TechnicienItem
        {
            public TechnicienItem(Technicien t, Boolean b)
            {
                tech = t;
                IsSelected = b;
            }
            public Technicien tech {
                get; set;
            }

            public Boolean IsSelected { get; set; }
        }
        public Boolean? NewMachine
        {
            get => (Boolean?)GetProperty();
            set
            {
                SetProperty(value);
                OldMachine = !value;
            }
        }

        public Boolean? OldMachine
        {
            get => (Boolean?)GetProperty();
            set
            {
                SetProperty(value);
            }
        }

        public Machine SelectedMachine
        {
            get => (Machine)GetProperty();
            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<TechnicienItem> ListTechnicien
        {
            get => (ObservableCollection<TechnicienItem>)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Machine> ListMachine
        {
            get => (ObservableCollection<Machine>)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public string NewName
        {
            get; set;
        }

        BoenaVistaEntities context = new BoenaVistaEntities();
        public MachineViewmodel()
        {
            NewMachine = true;
            OldMachine = false;

            ListTechnicien = new ObservableCollection<TechnicienItem>();

            foreach (Technicien t in context.Technicien.ToList())
            {
                ListTechnicien.Add(new TechnicienItem(t, true));
            }

            ListMachine = new ObservableCollection<Machine>();

            foreach (Machine m in context.Machine.ToList())
            {
                ListMachine.Add(m);
            }

        }
    }
}
