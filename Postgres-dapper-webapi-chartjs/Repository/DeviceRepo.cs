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
    public class DeviceRepo
    {
        private string _connectionString;

        public DeviceRepo(IConfiguration configuration)
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

        public IEnumerable<Device> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Device>("SELECT * FROM devices");
            }
        }

    }
}
