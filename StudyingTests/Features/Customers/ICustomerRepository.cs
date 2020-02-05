using Features.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
