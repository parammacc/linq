using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_InnerJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var empleados = Employee.GetAllEmployees()
                                    .Join(Department.GetAllDepartments(),
                                    e => e.DepartmentID,
                                    d => d.ID,
                                    (empleado, departamento) => new
                                    {
                                        NombreEmpleado = empleado.Name,
                                        NombreDepartamento = departamento.Name
                                    });

            foreach (var e in empleados)
            {
                Console.WriteLine(e.NombreEmpleado + "\t" + e.NombreDepartamento);
            }

            //ahora con join
            var result = from e in Employee.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID
                         select new
                         {
                             NombreEmpleado = e.Name,
                             NombreDepartamento = d.Name
                         };

            foreach (var e in result)
            {
                Console.WriteLine(e.NombreEmpleado + "\t" + e.NombreDepartamento);
            }

            Console.ReadKey();
        }
    }
}
