using CustomerManagementSystem.DatabaseLayer.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DatabaseLayer
{
    public interface IDatabaseService
    {
        string GetWelcomeMessage();

        List<Customer> GetAllCustomers();

    }

    public class DatabaseService : IDatabaseService
    {
        private readonly CustomerManagementDbContext _dbContext;
        public DatabaseService(CustomerManagementDbContext pDbContext)
        {
            _dbContext = pDbContext;
        }
        public string GetWelcomeMessage()
        {
            return "working 123";
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                var customers = _dbContext.Customers.ToList();
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
