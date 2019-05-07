using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video26
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //sobreescribo equals
        public override bool Equals(object obj)
        {
            return this.ID == ((Employee)obj).ID && this.Name == ((Employee)obj).Name;
        }

        //sobreescribo gethashcode
        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.Name.GetHashCode();
        }

    }
}
