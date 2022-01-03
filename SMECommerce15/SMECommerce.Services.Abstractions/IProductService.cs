using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services.Abstractions
{
    public interface IProductService
    {
        bool Add(Item product);
        bool Update(Item product);
        bool Remove(Item product);
        ICollection<Item> GetAll();
        Item GetById(int id);
    }
}
