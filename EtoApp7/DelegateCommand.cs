using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EtoApp7
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object _)
        {
            return (_canExecute != null) ? _canExecute() : true;
        }

        public void Execute(object _)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            OnRaiseCanExecuteChanged();
        }

        protected virtual void OnRaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Action _execute;
        private Func<bool> _canExecute;
    }

    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute != null) ? _canExecute((T)parameter) : true;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnRaiseCanExecuteChanged();
        }

        protected virtual void OnRaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Action<T> _execute;
        private Predicate<T> _canExecute;
    }
}
