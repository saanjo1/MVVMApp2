using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.EF;
using WpfAppMVVM.Model;

namespace WpfAppMVVM.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        MyDbContext _context = new MyDbContext();
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == customerId);

            if(customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            return _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return _context.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if(!_context.Customers.Local.Any(c=>c.CustomerId == customer.CustomerId)){
                _context.Customers.Attach(customer);
            }

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
