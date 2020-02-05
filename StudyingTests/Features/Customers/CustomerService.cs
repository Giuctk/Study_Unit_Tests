using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Features.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public CustomerService(ICustomerRepository customerRepository,
                              IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public IEnumerable<Customer> GetAllActive()
        {
            return _customerRepository.GetAll().Where(c => c.Active);
        }

        public void Add(Customer customer)
        {
            if (!customer.IsValid())
                return;

            _customerRepository.Add(customer);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", customer.Email, "Hello", "Welcome!"));
        }

        public void Update(Customer customer)
        {
            if (!customer.IsValid())
                return;

            _customerRepository.Update(customer);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", customer.Email, "Changes", "Take a look!"));
        }

        public void Deactive(Customer customer)
        {
            if (!customer.IsValid())
                return;

            customer.Deactivate();
            _customerRepository.Update(customer);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", customer.Email, "Bye", "See you later!"));
        }

        public void Remove(Customer customer)
        {
            _customerRepository.Remove(customer.Id);
            _mediator.Publish(new CustomerEmailNotification("admin@me.com", customer.Email, "Goodbye", "Have a good journey!"));
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
