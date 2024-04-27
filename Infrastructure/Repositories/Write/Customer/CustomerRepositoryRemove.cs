﻿using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public  class CustomerRepositoryRemove: ICustomerRepositoryRemove
    {
        private readonly WriteDbContext _DbContext;
        private readonly ICustomerRepositoryResponse _Response;

        public CustomerRepositoryRemove(WriteDbContext dbContext_write, ICustomerRepositoryResponse customer_Repositoty_respons)
        {
            _DbContext = dbContext_write;
            _Response = customer_Repositoty_respons;
        }

        public async Task<CustomerWriteModel> RemoveCustomer(Guid CustomerPIN)
        {
            CustomerWriteModel customer = await _Response.ResponseCustomer(CustomerPIN);
            _DbContext.Customers.Remove(customer);
            return customer;
        }
    }
}
