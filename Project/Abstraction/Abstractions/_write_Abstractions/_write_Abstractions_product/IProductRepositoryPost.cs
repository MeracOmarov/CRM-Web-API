﻿using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_product
{
    public interface IProductRepositoryPost
    {
        Task PostProduct(ProductWriteModel product_model_write);
    }
}
