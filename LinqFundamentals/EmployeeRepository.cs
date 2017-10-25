using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFundamentals
{
    class EmployeeRepository
    {
        List<Employees> list = new List<Employees>()
            {
                new Employees { Id = 1, Name = "Andrea"},
                new Employees {Id=2, Name="Scott"},
                new Employees {Id = 3, Name = "Anna"}
            };

        public List<Employees> GetAll()
        {
            return list;
        }

        public void Add(Employees e)
        {
            list.Add(e);
        }
    }
}
