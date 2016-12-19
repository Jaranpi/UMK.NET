using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace KoloryWPF.ViewModel
{
    public class ResetujCommand : ICommand
    {
        private EdycjaKoloru modelWidoku;

        public ResetujCommand(EdycjaKoloru modelWidoku)
        {
            this.modelWidoku = modelWidoku;
        }

        public bool CanExecute(object parameter)
        {
            return (
                modelWidoku.R != 0 || 
                modelWidoku.G != 0 || 
                modelWidoku.B != 0);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {            
            if(modelWidoku!=null)
            {
                modelWidoku.R = 0;
                modelWidoku.G = 0;
                modelWidoku.B = 0;
            }
        }
    }

    public class MvvmCommand : ICommand
    {
        readonly Func<object, bool> canExecute;
        readonly Action<object> execute;

        public MvvmCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentException("Parametr 'execute' nie może być pusty (null)");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (canExecute == null) ? true : canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
