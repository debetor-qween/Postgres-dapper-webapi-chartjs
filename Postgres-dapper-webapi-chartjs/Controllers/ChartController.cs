using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postgres_dapper_webapi_chartjs.Models;
using Postgres_dapper_webapi_chartjs.Repository;


namespace Postgres_dapper_webapi_chartjs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly MeasureRepo _measureRepo;

        public ChartController(IConfiguration configuration)
        {
            _measureRepo = new MeasureRepo(configuration);
        }


        // GET api/device/action
        [HttpGet]
        public IEnumerable<MValue> GetMValues(int device_id, long startDate, long endDate)
        {
            DateTime epoch = new DateTime(1970,1,1,0,0,0,0, DateTimeKind.Utc);
            DateTime sDate = epoch.AddSeconds((double)startDate).ToLocalTime();
            DateTime eDate = epoch.AddSeconds((double)endDate).ToLocalTime();

            return _measureRepo.GetMValues(device_id, sDate, eDate);
        }

    }
}