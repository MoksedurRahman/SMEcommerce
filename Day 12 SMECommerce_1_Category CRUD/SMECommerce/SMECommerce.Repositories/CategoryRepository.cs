using Microsoft.EntityFrameworkCore;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Models.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace SMECommerce.Repositories
{
    public class CategoryRepository
    {
        SMECommerceDbContext db;
        public CategoryRepository()
        {
            db = new SMECommerceDbContext();
        }
        public Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Category> GetAll()
        {
            return db.Categories.Include(c => c.Items).ToList();
        }

        public bool Add(Category category)
        {
            db.Categories.Add(category);

            int successCount = db.SaveChanges();

            return successCount > 0;

        }

        public bool Update(Category category)
        {
            db.Categories.Update(category);
            return db.SaveChanges() > 0;
        }

        public bool Remove(Category category)
        {
            db.Categories.Remove(category);
            return db.SaveChanges() > 0;
        }


    }
}
