using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgres_dapper_webapi_chartjs.Models
{
    public class Device
    {
        public int id { get; set; }
        public string name { get; set; }
        public int apartment_id { get; set; }
    }
}
