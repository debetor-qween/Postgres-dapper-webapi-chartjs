using System;
using System.Collections.Generic;

namespace Postgres_dapper_webapi_chartjs.Models
{
    public class MValue
    {
        public int id { get; set; }
        public DateTime mtimestamp { get; set; }
        public double mvalue { get; set; }
        public int device_id { get; set; }
    }

    public class TChartPoint
    {
        public DateTime t { get; set; }
        public double y { get; set; }
    }
}
