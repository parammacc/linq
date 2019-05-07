using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24_LeftJoin;

namespace _25_CrossJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            //así sale el mismo nombre para los distintos departamentos
            var result = from e in Employee.GetAllEmployees()
                         from d in Department.GetAllDepartments()
                         select new { e, d };

            foreach (var r in result)
            {
                Console.WriteLine(r.e.Name + "\t" + r.d.Name);
            }
            Console.WriteLine();
            //así sale todos los empleados para cada departamento
            var result2 = from d in Department.GetAllDepartments()
                         from e in Employee.GetAllEmployees()
                         select new { e, d };

            foreach (var r in result2)
            {
                Console.WriteLine(r.e.Name + "\t" + r.d.Name);
            }
            Console.WriteLine();
            //sin usar join
            var result3 = Employee.GetAllEmployees().SelectMany(e => Department.GetAllDepartments(),
                                                                (e, d) => new { e, d });

            foreach (var r in result3)
            {
                Console.WriteLine(r.e.Name + "\t" + r.d.Name);
            }

            Console.WriteLine();
            //usando join
            var result4 = Employee.GetAllEmployees().Join(Department.GetAllDepartments(),
                                                            e => true,
                                                            d => true,
                                                            (e, d) => new { e, d });

            foreach (var r in result4)
            {
                Console.WriteLine(r.e.Name + "\t" + r.d.Name);
            }

            Console.ReadKey();
        }
    }
}
