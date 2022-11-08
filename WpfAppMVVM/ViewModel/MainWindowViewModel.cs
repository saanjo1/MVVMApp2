using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.Helper;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        public MyICommand<string> NavCommand { get; private set; }
        private CustomerListViewModel custListViewModel = new CustomerListViewModel();
        private OrderViewModel orderViewModel = new OrderViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "orders":
                    CurrentViewModel = orderViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = custListViewModel;
                    break;
            }
        }
    }
}