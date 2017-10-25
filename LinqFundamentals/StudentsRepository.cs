using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFundamentals
{
    class StudentsRepository
    {
        List<Student> list = new List<Student>()
        {
            new Student {Id=1, Name = "Anna", ClassId=1},
            new Student {Id=2, Name = "Bob", ClassId=1},
            new Student {Id=3, Name = "Tom", ClassId=2},
            new Student {Id=4, Name = "Dorel", ClassId=3},
            new Student {Id=5, Name = "Steve", ClassId=3},
        };


        public List<Student> GetAll()
        {
            return list;
        }
    }
}
