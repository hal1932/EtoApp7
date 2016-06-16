using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtoApp7
{
    class MainFormViewModel : BindableBase
    {
        private string _test;
        public string Test
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
        }

        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        private DelegateCommand _testCommand;
        public DelegateCommand TestCommand
        {
            get { return _testCommand = _testCommand ?? new DelegateCommand(F); }
        }

        public MainFormViewModel()
        {
            Test = true.ToString();
            Enabled = true;
        }

        public void F()
        {
            Test = (!bool.Parse(Test)).ToString();
            Enabled = false;
        }
    }
}
