using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMExample.Utilities
{
    public class RelayCommand : ICommand
    {
        #region Private Fields
        private readonly Action<object> _executeHandler;
        private readonly Predicate<object> _canExecuteHandler;
        #endregion

        #region Constructors
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Execute cannot be 'null'!");
            _executeHandler = execute;
            _canExecuteHandler = canExecute;
        }
        #endregion

        #region public Methods
        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null) return true;
            return _canExecuteHandler(parameter);
        }
        #endregion

        #region Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

    }
}
