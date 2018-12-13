using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonLib
{
    public static class JsonSetting
    {
        public static readonly JsonSerializerSettings IgnoreNull = new JsonSerializerSettings
            {NullValueHandling = NullValueHandling.Ignore};

        public static readonly IsoDateTimeConverter DateTimeConverter = new IsoDateTimeConverter(){DateTimeFormat = "yyyyMMdd"};


        public static readonly JsonSerializerSettings ReferenceLoop = new JsonSerializerSettings
            {ReferenceLoopHandling = ReferenceLoopHandling.Serialize};
    }
}
