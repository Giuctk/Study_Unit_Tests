using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Customers
{
    public interface ICustomerService : IDisposable
    {
        IEnumerable<Customer> GetAllActive();
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        void Deactive(Customer customer);
    }
}
