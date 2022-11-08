using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.Helper;
using WpfAppMVVM.Services;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM
{
    public class MainWindowViewModel : BindableBase
    {
        private ICustomersRepository _repo;
        public MainWindowViewModel(ICustomersRepository repo)
        {
            NavCommand = new MyICommand<string>(OnNav);
            _repo = repo;
        }

        public MyICommand<string> NavCommand { get; private set; }
        private CustomerListViewModel custListViewModel = new CustomerListViewModel();
        private OrderViewModel orderViewModel = new OrderViewModel();
        private AddEditCustomerViewModel addEditCustomerViewModel = new AddEditCustomerViewModel(_repo);

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
                case
                    "addcustomer":
                        CurrentViewModel = addEditCustomerViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = custListViewModel;
                    break;
            }
        }
    }
}