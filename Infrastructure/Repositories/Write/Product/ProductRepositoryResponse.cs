﻿using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class ProductRepositoryResponse : IProductRepositoryResponse
    {
        private readonly WriteDbContext _DbContext;

        public ProductRepositoryResponse(WriteDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<ProductWriteModel> ResponseProduct(Guid ProductBarcode)
        {
            ProductWriteModel product= await _DbContext.Products.SingleOrDefaultAsync(x => x.Barcode == ProductBarcode);
            return product;
        }

    }
}
