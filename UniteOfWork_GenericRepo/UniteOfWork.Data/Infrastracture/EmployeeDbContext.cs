using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniteOfWork.Data.Models;

namespace UniteOfWork.Data.Infrastracture
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
            :base("name=DefaultConnection")
        {
           
        }

        public virtual DbSet<Employee> employee { get; set; }
    }

}
