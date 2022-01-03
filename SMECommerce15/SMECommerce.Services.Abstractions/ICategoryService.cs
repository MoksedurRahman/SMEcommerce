using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services.Abstractions
{
    public interface ICategoryService
    {
        bool Add(Category category);
        bool Update(Category category);
        bool Remove(Category category);
        ICollection<Category> GetAll();
        Category GetById(int id);
    }
}
