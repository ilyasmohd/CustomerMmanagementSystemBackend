using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementSystem.DatabaseLayer;
using CustomerManagementSystem.DatabaseLayer.DbEntities;
using Microsoft.AspNetCore.Mvc;


namespace CustomerManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private readonly IDatabaseService _dbService;

        public InvoiceController(IDatabaseService pDbService)
        {
            _dbService = pDbService;
        }

        /*
        [HttpGet]
        public string test()
        {
            return "tes";
        } */

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var totalInvoices = _dbService.GetAllInvoices();
                return Ok(totalInvoices);
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
            try
            {
                var invoice = _dbService.GetSingleInvoice(id);
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Invoice value)
        {
            try
            {
                var isSaved = _dbService.AddInvoice(value);
                return Ok(isSaved);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Int64 id, [FromBody]Invoice value)
        {
            try
            {
                var invoice = _dbService.UpdateInvoice(id, value);
                return Ok(invoice);
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
                var isDeleted = _dbService.DeleteInvoice(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
