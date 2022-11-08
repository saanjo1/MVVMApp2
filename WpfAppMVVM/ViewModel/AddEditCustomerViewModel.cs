using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.Helper;
using WpfAppMVVM.Model;
using WpfAppMVVM.Services;

namespace WpfAppMVVM.ViewModel
{
    class AddEditCustomerViewModel : BindableBase
    {
        private ICustomersRepository _repo;


        public AddEditCustomerViewModel(ICustomersRepository repo)
        {
            _repo = repo;
            CancelCommand = new MyICommand(OnCancel);
            SaveCommand = new MyICommand(OnSave, CanSave);
        }

        private bool _EditMode;

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableCustomer _Customer;

        public SimpleEditableCustomer Customer
        {
            get { return _Customer; }
            set { SetProperty(ref _Customer, value); }
        }

        private Customer _editingCustomer = null;

        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;

            if (Customer != null) Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(cust, Customer);
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.CustomerId;

            if (EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }

            private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public MyICommand CancelCommand { get; private set; }
        public MyICommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateCustomer(Customer, _editingCustomer);

            if (EditMode)
            {
                await _repo.UpdateCustomerAsync(_editingCustomer);
            }
            else
            {
                await _repo.AddCustomerAsync(_editingCustomer);
            }
            Done();
        }

        private bool CanSave()
        {
            return !Customer.HasErrors;
        }

        private void UpdateCustomer(SimpleEditableCustomer source, Customer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Phone = source.Phone;
            target.Email = source.Email;
        }
    }
}
