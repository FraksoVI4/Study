using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Model;

namespace WpfApp4
{
    public class Context : DbContext
    {
        public Context() : base("dbConnection")
        {

        }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Runner> Runners { get; set; }
        public virtual DbSet<Admin>  Admins { get; set; }
        
    }
}
