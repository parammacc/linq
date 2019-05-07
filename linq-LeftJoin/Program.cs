using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_LeftJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from e in Employee.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID
                         into eGroup
                         from d in eGroup.DefaultIfEmpty()
                         select new
                         {
                             NombreEmpleado = e.Name,
                             NombreDepartamento = d == null ? "No Department" : d.Name
                         };

            foreach (var r in result)
            {
                Console.WriteLine(r.NombreEmpleado + "\t" + r.NombreDepartamento);
            }

            //sin usar join
            var result2 = Employee.GetAllEmployees()
                          .GroupJoin(Department.GetAllDepartments(),
                                e => e.DepartmentID,
                                d => d.ID,
                                (emp, depts) => new
                                {
                                    emp,
                                    depts
                                })
                            .SelectMany(z => z.depts.DefaultIfEmpty(),
                                    (a, b) => new
                                    {
                                        NombreEmpleado = a.emp.Name,
                                        NombreDepartamento = b == null ? "Sin Departamento" : b.Name
                                    });
            foreach (var r in result)
            {
                Console.WriteLine(r.NombreEmpleado + "\t" + r.NombreDepartamento);
            }

            Console.ReadKey();
        }
    }
}
