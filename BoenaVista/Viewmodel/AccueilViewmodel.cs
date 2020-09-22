using BoenaVista.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoenaVista.Viewmodel
{
    class AccueilViewmodel : BaseNotifyPropertyChanged
    {
        BoenaVistaEntities context = new BoenaVistaEntities();
        public class MachineListItem
        {
            public Machine Machine { get; set; }
            public Intervention LastIntervention { get; set; }
            public Intervention NextIntervention { get; set; }

            public MachineListItem(Machine m1, Intervention i = null, Intervention i2 = null)
            {
                this.Machine = m1;
                this.LastIntervention = i;
                this.NextIntervention = i2;
            }
        }

        public ObservableCollection<MachineListItem> listMachineWithInt
        {
            get => (ObservableCollection<MachineListItem>)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Machine> AllMachines
        {
            get => (ObservableCollection<Machine>)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public AccueilViewmodel()
        {
            listMachineWithInt = new ObservableCollection<MachineListItem>();
            List<Machine> listMachine = context.Machine.ToList<Machine>();
            AllMachines = new ObservableCollection<Machine>(listMachine);
            foreach(Machine machine in AllMachines)
            {
                Intervention lastIntervention = machine.Intervention.Where(x => x.Date < DateTime.Now).OrderByDescending(x => x.Date).FirstOrDefault();
                Intervention nextIntervention = machine.Intervention.Where(x => x.Date > DateTime.Now).OrderByDescending(x => x.Date).FirstOrDefault();
                MachineListItem machineItem = new MachineListItem(machine, lastIntervention, nextIntervention);
                listMachineWithInt.Add(machineItem);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
