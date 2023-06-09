using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class Relaycommand : ICommand
    {
            public event EventHandler? CanExecuteChanged;
            private Action execute;

            public Relaycommand(Action excute1)
            {
                this.execute = excute1;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                execute.Invoke();
            }
    }
}
