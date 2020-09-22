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
    class PlanningViewmodel : BaseNotifyPropertyChanged
    {
        BoenaVistaEntities context = new BoenaVistaEntities();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Intervention> interventionByDay
        {
            get => (ObservableCollection<Intervention>)GetProperty();

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
                GetInterventionByDate(value);
            }
        }

        //public class InterventionItemview
        //{
        //    public Intervention Intervention { get; set; }
        //    public InterventionItemview(Intervention)
        //    {
        //        this.Intervention = 
        //    }
        //}

        public PlanningViewmodel()
        {
            SelectedDate = DateTime.Now;
        }

        public void GetInterventionByDate(DateTime? date)
        {
            interventionByDay = new ObservableCollection<Intervention>(context.Intervention.
                                                                        Where(x => x.Date.Value.Year == date.Value.Year &&
                                                                                    x.Date.Value.Month == date.Value.Month &&
                                                                                    x.Date.Value.Day == date.Value.Day).
                                                                                    ToList<Intervention>());
        }

    }
}
