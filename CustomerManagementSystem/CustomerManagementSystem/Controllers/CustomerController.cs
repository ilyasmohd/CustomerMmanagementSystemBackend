using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementSystem.DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.DatabaseLayer.DbEntities;

namespace CustomerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IDatabaseService _dbService;

        public CustomerController(IDatabaseService pDbService)
        {
            _dbService = pDbService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var totalCustomers = _dbService.GetAllCustomers();
                return Ok(totalCustomers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Int64 id)
        {
            var customer = _dbService.GetSingleCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Customer value)
        {
            try
            {
                var isAdded = _dbService.AddCustomer(value);
                if (isAdded)
                {
                    return Created("api/customer/" + value.CustomerId, "");
                }
                else
                {
                    return StatusCode(503);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer value)
        {
            try
            {
                var isUpdated = _dbService.UpdateCustomer(id, value);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Int64 id)
        {
            try
            {
                var isUpdated = _dbService.DeleteCustomer(id);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
