﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public class MyContext: DbContext
    {
        public MyContext()
            :base("Connection")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
