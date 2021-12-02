using CustomerManagementSystem.DatabaseLayer.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DatabaseLayer
{
    public interface IDatabaseService
    {
        List<Customer> GetAllCustomers();
        Customer GetSingleCustomer(Int64 id);
        Invoice GetSingleInvoice(Int64 id);
        List<Invoice> GetAllInvoices();
        bool UpdateCustomer(Int64 id, Customer obj);
        bool DeleteCustomer(Int64 id);
        bool DeleteInvoice(Int64 id);
        bool UpdateInvoice(Int64 id, Invoice obj);
        bool AddCustomer(Customer customer);
        bool AddInvoice(Invoice invoice);
    }

    public class DatabaseService : IDatabaseService
    {
        private readonly CustomerManagementDbContext _dbContext;
        public DatabaseService(CustomerManagementDbContext pDbContext)
        {
            _dbContext = pDbContext;
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

        public Customer GetSingleCustomer(long id)
        {
            try
            {
                var customer = _dbContext.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Invoice GetSingleInvoice(long id)
        {
            try
            {
                var invoice = _dbContext.Invoices.Where(x => x.InvoiceId == id).FirstOrDefault();
                return invoice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            try
            {
                var invoices = _dbContext.Invoices.ToList();
                return invoices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCustomer(Int64 id, Customer obj)
        {
            try
            {
                var customer = GetSingleCustomer(id);
                customer.CustomerName = obj.CustomerName;
                customer.PhoneNumber = obj.PhoneNumber;
                var isSaved = _dbContext.SaveChanges() > 0;
                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCustomer(long id)
        {
            try
            {
                _dbContext.Customers.Remove(GetSingleCustomer(id));
                var isRemoved = _dbContext.SaveChanges() > 0;
                return isRemoved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteInvoice(long id)
        {
            try
            {
                _dbContext.Invoices.Remove(GetSingleInvoice(id));
                var isRemoved = _dbContext.SaveChanges() > 0;
                return isRemoved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateInvoice(Int64 id, Invoice obj)
        {
            try
            {
                var invoice = GetSingleInvoice(id);
                invoice.Value = obj.Value;
                invoice.InvoiceDate = obj.InvoiceDate;
                var isSaved = _dbContext.SaveChanges() > 0;
                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Add(customer);
                var isSaved = _dbContext.SaveChanges() > 0;
                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddInvoice(Invoice invoice)
        {
            try
            {
                _dbContext.Invoices.Add(invoice);
                var isSaved = _dbContext.SaveChanges() > 0;
                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
