using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Model
{
    public class Runner : Person
    {
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
