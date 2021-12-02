using CustomerManagementSystem.DatabaseLayer.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CustomerManagementSystem.DatabaseLayer
{
    public class CustomerManagementDbContext : DbContext
    {
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : base(options)
        {
            //Database.SetInitializer<BannerDbContext>(null);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
    }

    public class GenerateDefaultData
    {
        public static void InitializeDatabase(CustomerManagementDbContext dbContext)
        {

            if (dbContext.Customers.Any())
            {
                return;   // Data was already seeded
            }

            dbContext.Customers.AddRange(
                new Customer
                {
                    CustomerName = "first customer",
                    PhoneNumber = "12345",
                },
                new Customer
                {
                    CustomerName = "second customer",
                    PhoneNumber = "23456",
                },
                new Customer
                {
                    CustomerName = "third customer",
                    PhoneNumber = "345566",
                }
                );

            dbContext.Invoices.AddRange(
                new Invoice
                {
                    State = 1,
                    Value = 100,
                    InvoiceDate = DateTime.Now,
                    CustomerId = 1
                },
                new Invoice
                {
                    State = 2,
                    Value = 20,
                    InvoiceDate = DateTime.Now,
                    CustomerId = 2
                });

            dbContext.SaveChanges();
        }
    }
}
