using BoenaVista.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoenaVista.Viewmodel
{
    class InterventionViewmodel : BaseNotifyPropertyChanged
    {
        BoenaVistaEntities context = new BoenaVistaEntities();

        public Intervention Intervention
        {
            get => (Intervention)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public DateTime? SelectedDate
        {
            get => (DateTime?)GetProperty();

            set
            {
                SetProperty(value);
                Intervention.Date = value;
                GetAviableTechnicienAndMachine();
            }
        }

        public DateTime? SelectedDateFin
        {
            get => (DateTime?)GetProperty();

            set
            {
                SetProperty(value);
                Intervention.DateFin = value;
                GetAviableTechnicienAndMachine();
            }
        }

        public Machine SelectedMachine
        {
            get => (Machine)GetProperty();

            set
            {
                SetProperty(value);
                Intervention.Id_Machine = value.Id;
                GetLinkedTechnicien();
            }
        }

        public Technicien SelectedTechnicien
        {
            get => (Technicien)GetProperty();

            set
            {
                SetProperty(value);
                Intervention.Id_Technicien = value.Id;
                GetLinkedMachine();
            }
        }

        public ObservableCollection<Technicien> ListTechnicienDisponible
        {
            get => (ObservableCollection<Technicien>)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Machine> ListMachineDisponible
        {
            get => (ObservableCollection<Machine>)GetProperty();

            set
            {
                SetProperty(value);
            }
        }

        public InterventionViewmodel()
        {
            Intervention = new Intervention();
            SelectedDate = DateTime.Now;
        }

        public void GetAviableTechnicienAndMachine()
        {
            if (SelectedDate != null && SelectedDateFin != null)
            {
                List<Intervention> interventionByDateTime = context.Intervention.
                                                                        Where(x => (SelectedDate.Value >= x.Date.Value
                                                                            && SelectedDate.Value <= x.DateFin.Value) ||
                                                                            (SelectedDateFin.Value >= x.Date.Value && SelectedDateFin.Value <= x.DateFin.Value) ||
                                                                            (SelectedDateFin.Value <= x.DateFin.Value && SelectedDate.Value >= x.Date.Value)).
                                                                                    ToList<Intervention>();

                List<int> idTechs = new List<int>();
                List<int> idMachine = new List<int>();
                foreach (Intervention i in interventionByDateTime)
                {
                    idTechs.Add(i.Id_Technicien.Value);
                    idMachine.Add(i.Id_Machine.Value);
                }

                
                ListMachineDisponible = new ObservableCollection<Machine>(context.Machine.Where(x => !idMachine.Contains(x.Id)).ToList<Machine>());
                ListTechnicienDisponible = new ObservableCollection<Technicien>(context.Technicien.Where(x => !idTechs.Contains(x.Id)).ToList<Technicien>());
            }
        }

        public void GetLinkedTechnicien()
        {
            ListTechnicienDisponible = new ObservableCollection<Technicien>(ListTechnicienDisponible.Where(x => SelectedMachine.Technicien.Contains(x)).ToList<Technicien>());
        }

        public void GetLinkedMachine()
        {
            ListMachineDisponible = new ObservableCollection<Machine>(ListMachineDisponible.Where(x => SelectedTechnicien.Machine.Contains(x)).ToList<Machine>());
        }

        public Commandes.BaseCommand SaveNewIntervention => new Commandes.BaseCommand(saveNewIntervention);

        public void saveNewIntervention()
        {
            context.Intervention.Add(Intervention);
            context.SaveChanges();
        }
    }
}
