using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Postgres_dapper_webapi_chartjs.Models;
using Postgres_dapper_webapi_chartjs.Repository;

namespace Postgres_dapper_webapi_chartjs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceRepo _deviceRepo;

        public DeviceController(IConfiguration configuration)
        {
            _deviceRepo = new DeviceRepo(configuration);
        }


        // GET api/device/action
        [HttpGet]
        public IEnumerable<Device> GetDeviceList()
        {
            return _deviceRepo.FindAll();
        }

        // GET api/device/get/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


    }
}