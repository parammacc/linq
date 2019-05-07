using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video21
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeesByDepartment = Department.GetAllDepartments()
                                                  .GroupJoin(Employee.GetAllEmployees(),
                                                                d => d.ID,
                                                                e => e.DepartmentID,
                                                                (departamento, empleados) => new
                                                                {
                                                                    Department = departamento,
                                                                    Employees = empleados
                                                                });
            foreach (var d in employeesByDepartment)
            {
                Console.WriteLine(d.Department.Name);
                foreach (var e in d.Employees)
                {
                    Console.WriteLine(" " + e.Name);
                }
                Console.WriteLine();
            }
            
            //otra forma de hacer groupjoin 
            var employeesByDepartment2 = from d in Department.GetAllDepartments()
                                         join e in Employee.GetAllEmployees()
                                         on d.ID equals e.DepartmentID 
                                         into empleadosGroup
                                         select new
                                         {
                                             Department = d,
                                             Employee =  empleadosGroup
                                         };

            foreach (var depart in employeesByDepartment2)
            {
                Console.WriteLine(depart.Department.Name);
                foreach (var empl in depart.Employee)
                {
                    Console.WriteLine(" " + empl.Name);
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }
    }
}
