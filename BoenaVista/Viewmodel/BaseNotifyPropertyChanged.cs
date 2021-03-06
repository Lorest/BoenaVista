﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoenaVista.Viewmodel
{
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> _propertyValues = new Dictionary<string, object>();

        protected object GetProperty([CallerMemberName] string propertyName = null)
        {
            if (_propertyValues.ContainsKey(propertyName)) return _propertyValues[propertyName];
            return null;
        }

        protected bool SetProperty<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            T current = (T)GetProperty(propertyName);
            if (!EqualityComparer<T>.Default.Equals(current, newValue))
            {
                _propertyValues[propertyName] = newValue;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                return true;
            }
            return false;
        }

        protected void RaisePropertyChange(Object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(sender, e);
        }

    }
}
