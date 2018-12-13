using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonLib.Model
{
    public class Student
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "StudentName")]
        public string Name { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string Remark { get; set; }

        [JsonProperty]//private
        private int Pid
        {
            get { return this.Id + 10000;}
            set { }
        }

        [JsonIgnore]
        public string IgnoreStr { get; set; }

        public StuClass SClass { get; set; }
    }
}
