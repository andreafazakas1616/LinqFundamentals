﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFundamentals
{
    class Employees
    {
        
        string name;

        public int Id { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }

        }
    }
}
