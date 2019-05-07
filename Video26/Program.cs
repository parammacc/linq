using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video26
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = { "USA", "usa", "INDIA", "UK", "UK" };
            var result = countries.Distinct();
            foreach (var r in result)
            {
                Console.WriteLine(r);   //USA, usa, INDIA, UK
            }
            Console.WriteLine();
            //para que no aparezca USA y usa a la vez, es decir, que aparezca una vez:
            var result2 = countries.Distinct(StringComparer.OrdinalIgnoreCase);
            foreach (var r in result2)
            {
                Console.WriteLine(r);   //USA, INDIA, UK
            }
            Console.WriteLine();
            //ahora viene el caso en el que hay que usar objetos en vez un array de string
            List<Employee> list = new List<Employee>()
            {
                new Employee{ ID = 101, Name = "Mike"},
                new Employee{ID=101, Name="Mike"},
                new Employee{ID=102, Name="Mary"}
            };
            var result3 = list.Distinct();
            foreach (var r in result3)
            {
                Console.WriteLine(r.ID + "\t" + r.Name);    //aparece 2 veces 101 Mike
            }
            //para hacer que no aparezca 2 veces repetido 101 Mike, voy a sobreescribir en la clase Employee 
            //  las funciones Equals y GetHashCode
            //  HE EJECUTADO EL PROGRAMA HACIENDO LOS CAMBIOS EN Employee.cs Y USANDO EL foreach DE ARRIBA 
            //  YA MUESTRA 1 ÚNICA VEZ 101 Mike
            Console.ReadKey();
        }
    }
}
