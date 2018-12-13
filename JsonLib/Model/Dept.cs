using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLib.Model
{
    public class Dept
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Dept> SonDepts { get; set; }
    }
}
