using Features.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthday { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }

        protected Customer()
        {
        }

        public Customer(Guid id,string name, string lastName, DateTime birthday, DateTime registerDate, string email, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Birthday = birthday;
            RegisterDate = registerDate;
            Email = email;
            Active = active;
        }

        public string FullName()
        {
            return $"{Name} {LastName}";
        }

        public bool IsSpecial()
        {
            return RegisterDate < DateTime.Now.AddYears(-3) && Active;
        }

        public void Deactivate()
        {
            Active = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Make sure you have entered the name")
                .Length(2, 150).WithMessage("Name should have between 2 and 150 characters");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Make sure you have entered the last name")
                .Length(2, 150).WithMessage("Last Name should have between 2 and 150 characters");

            RuleFor(c => c.Birthday)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer should have at least 18 years old");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
