using Microsoft.EntityFrameworkCore;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SMECommerce.Repositories
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        SMECommerceDbContext db;
        public CategoryRepository(SMECommerceDbContext db):base(db)
        {
            this.db = db;
        }
        public override Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public override ICollection<Category> GetAll()
        {
            return db.Categories.Include(c => c.Items).ToList();
        }
        
        public ICollection<Category> GetTopCategories()
        {
            throw new System.NotImplementedException();
        }

       
    }
}
