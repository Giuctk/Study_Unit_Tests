using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Person
    {
        public string Name { get; protected set; }
        public string NickName { get; set; }
    }

    public class Employee : Person
    {
        public double Salary { get; private set; }
        public EProfessionalLevel ProfessionalLevel { get; private set; }
        public IList<string> Skills { get; private set; }

        public Employee(string name, double salary)
        {
            Name = string.IsNullOrEmpty(name) ? "Someone" : name;
            SetSalary(salary);
            SetSkills();
        }

        public void SetSalary(double salary)
        {
            if (salary < 500) throw new Exception("Less than allowed salary");

            Salary = salary;
            if (salary < 2000) ProfessionalLevel = EProfessionalLevel.Jr;
            else if (salary >= 2000 && salary < 8000) ProfessionalLevel = EProfessionalLevel.Pl;
            else if (salary >= 2000) ProfessionalLevel = EProfessionalLevel.Sr;
        }

        public void SetSkills()
        {
            var basicSkills = new List<string>()
            {
                "Programming Logic",
                "Object Oriented Programming"
            };

            Skills = basicSkills;

            switch (ProfessionalLevel)
            {
                case EProfessionalLevel.Pl:
                    Skills.Add("Tests");
                    break;
                case EProfessionalLevel.Sr:
                    Skills.Add("Tests");
                    Skills.Add("Microservices");
                    break;
            }
        }
    }

    public enum EProfessionalLevel
    {
        Jr,
        Pl,
        Sr
    }

    public class EmployeeFactory
    {
        public static Employee Create(string name, double salary)
        {
            return new Employee(name, salary);
        }
    }
}
