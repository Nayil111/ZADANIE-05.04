using System;

namespace ZADANIE_05._04
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public string FullName { get; set; }
        public int ID { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeBook
    {
        private List<Employee> employees;

        public EmployeeBook()
        {
            employees = new List<Employee>();
        }

        public void AddEmployee(string fullName, int id, decimal salary, string department)
        {
            Employee employee = new Employee
            {
                FullName = fullName,
                ID = id,
                Salary = salary,
                Department = department
            };

            employees.Add(employee);
        }

        public void RemoveEmployee(string fullNameOrId)
        {
            Employee employee = FindEmployee(fullNameOrId);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        public void UpdateSalary(string fullName, decimal newSalary)
        {
            Employee employee = FindEmployee(fullName);
            if (employee != null)
            {
                employee.Salary = newSalary;
            }
        }

        public void UpdateDepartment(string fullName, string newDepartment)
        {
            Employee employee = FindEmployee(fullName);
            if (employee != null)
            {
                employee.Department = newDepartment;
            }
        }

        public void PrintEmployeesByDepartments()
        {
            Dictionary<string, List<string>> departmentEmployees = new Dictionary<string, List<string>>();

            foreach (Employee employee in employees)
            {
                if (departmentEmployees.ContainsKey(employee.Department))
                {
                    departmentEmployees[employee.Department].Add(employee.FullName);
                }
                else
                {
                    departmentEmployees[employee.Department] = new List<string> { employee.FullName };
                }
            }

            foreach (var department in departmentEmployees)
            {
                Console.WriteLine($"Department: {department.Key}");
                foreach (string employee in department.Value)
                {
                    Console.WriteLine(employee);
                }
                Console.WriteLine();
            }
        }

        private Employee FindEmployee(string fullNameOrId)
        {
            return employees.Find(e => e.FullName == fullNameOrId || e.ID.ToString() == fullNameOrId);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeBook employeeBook = new EmployeeBook();

            employeeBook.AddEmployee("+Бебрович Виталий Андреевич", 1, 5000, "HR");
            employeeBook.AddEmployee("+Иванов Игорь Витальевич", 2, 6000, "Финансовий отдел");
            employeeBook.AddEmployee("+Османов Темраз Эльханович", 3, 5500, "Отдел IT");
            employeeBook.AddEmployee("+Османова Ольга Владимировна", 4, 5200, "Кадровый ");

            employeeBook.PrintEmployeesByDepartments();

            employeeBook.UpdateSalary("Бебрович Виталий Андреевич", 5500);
            employeeBook.UpdateDepartment("Османова Ольга Владимировна", "IT");

            employeeBook.PrintEmployeesByDepartments();

            employeeBook.RemoveEmployee("-Османов Темраз Эльханович");

            employeeBook.PrintEmployeesByDepartments();
        }
    }
}
