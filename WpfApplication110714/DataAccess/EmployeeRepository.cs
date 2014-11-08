using System.Collections.Generic;
using WpfApplication110714.Model;


namespace WpfApplication110714.DataAccess
{
    public class EmployeeRepository
    {
        readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>();
            }
            _employees.Add(Employee.CreateEmployee("John", "Smith"));
            _employees.Add(Employee.CreateEmployee("Jill", "Jones")); 
            _employees.Add(Employee.CreateEmployee("Kathy", "Morts"));
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(_employees);
        }
    }
}
