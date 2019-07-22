using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using Postgres_dapper_webapi_chartjs.Models;


namespace Postgres_dapper_webapi_chartjs.Repository
{
    public class MeasureRepo
    {
        private string _connectionString;

        public MeasureRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:dev");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }
        public IEnumerable<MValue> GetMValues(int device_id, DateTime startDate, DateTime endDate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<MValue>($"SELECT * FROM mvalues WHERE device_id = {device_id} AND mtimestamp BETWEEN '{startDate}' AND '{endDate}' ORDER BY id");
            }
        }

        public IEnumerable<TChartPoint> GetTChartPoints(int device_id, DateTime startDate, DateTime endDate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                IEnumerable<TChartPoint> result = dbConnection.Query<TChartPoint>($"SELECT mtimestamp AS t, mvalue AS y FROM mvalues WHERE device_id = {device_id} AND mtimestamp BETWEEN '{startDate}' AND '{endDate}' ORDER BY mtimestamp");
                return result;
            }
        }

    }
}
