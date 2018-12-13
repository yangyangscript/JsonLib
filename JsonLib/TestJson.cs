using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLib.Model;
using Newtonsoft.Json;
using Xunit;

namespace JsonLib
{
    public class TestJson
    {
        private List<Model.Student> students;
        private Xunit.Abstractions.ITestOutputHelper _outputHelper;

        public TestJson(Xunit.Abstractions.ITestOutputHelper iTestOutputHelper)
        {
            _outputHelper = iTestOutputHelper;
            students =new List<Student>();
            for (int i = 1; i < 11; i++)
            {
                students.Add(new Student()
                {
                    Id = i,
                    CreateDateTime = DateTime.Now.AddDays(i),
                    Name = $"Name_{i}",
                    Remark = null,
                    IgnoreStr = "IgnoreIgnoreIgnoreIgnoreIgnoreIgnoreIgnore",
                    SClass = new StuClass()
                    {
                        CId = i,
                        CName = $"CName_{i}",
                        CRemark = $"remark_remark{i}remark_remark_",
                    }
                });
            }
        }


        [Fact]
        public void JsonString()
        {
            _outputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(students));
        }

        /// <summary>
        /// 整齐的
        /// </summary>
        [Fact]
        public void FormatString()
        {
            _outputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(students, Formatting.Indented));
        }

        [Fact]
        public void JsonClass()
        {
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(students);
            var newstudents = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(str);
            _outputHelper.WriteLine($"{newstudents[8].Name}///{newstudents[8].IgnoreStr}");
        }


        /// <summary>
        /// 不要null
        /// </summary>
        [Fact]
        public void NullString()
        {
            var student = students.FirstOrDefault(s => s.Id == 5);
            student.SClass = null;
            _outputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(student,JsonSetting.IgnoreNull));
        }


        /// <summary>
        /// 格式化时间
        /// </summary>
        [Fact]
        public void TimeString()
        {
            _outputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(students, JsonSetting.DateTimeConverter));
        }

        /// <summary>
        /// 循环引用 貌似高版本不会出问题了不用加都行JsonSetting.ReferenceLoop
        /// </summary>
        [Fact]
        public void SonDeptsString()
        {
            var dept  =new Dept()
            {
                Id = 1,
                Name = "Father",
                SonDepts = new List<Dept>()
                {
                    new Dept()
                    {
                        Id = 2,
                        Name = "Son1",
                        SonDepts = new List<Dept>()
                        {
                            new Dept()
                            {
                                Id = 11,
                                Name = "SonSon11"
                            },
                            new Dept()
                            {
                                Id = 22,
                                Name = "SonSon22"
                            },
                        }
                    },
                    new Dept()
                    {
                        Id = 3,
                        Name = "Son2"
                    },
                    new Dept()
                    {
                        Id = 4,
                        Name = "Son3"
                    },
                }
            };
            var firStr = Newtonsoft.Json.JsonConvert.SerializeObject(dept);
            _outputHelper.WriteLine(firStr);

            
            var newDept = Newtonsoft.Json.JsonConvert.DeserializeObject<Dept>(firStr,JsonSetting.ReferenceLoop);
            _outputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(newDept,Formatting.Indented));
        }


    }
}
