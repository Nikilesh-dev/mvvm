using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class HelperMvvm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnChanged([CallerMemberName] string parameter = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));
        }
}
}
