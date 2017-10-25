using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFundamentals
{
    class ClassRepository
    {
        List<Class> list = new List<Class>()
        {
            new Class {Id=1, Name="Biology"},
            new Class {Id=2, Name="Chemistry"},
            new Class {Id=3, Name="Math"}
        };


        public List<Class> GetAll()
        {
            return list;
        }
    }
}
