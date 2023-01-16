using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebEShopFinal.Data;
using WebEShopFinal.Models;

namespace WebEShopFinal.Repositories
{
    public class CategoriesRepository : IGenericRepository<Category>
    {

        private ApplicationDbContext db;
        public CategoriesRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<Category> Add(Category category)
        {   
            category.Products = new List<Product>();
            db.Categories.Add(category);
            await db.SaveChangesAsync();            
            return category;            
        }

        public bool Delete(int? id)
        {
            
            bool result = false;
            if (db.Categories.Find(id) != null)
            {
                db.Categories.Remove(db.Categories.Find(id));
                db.SaveChanges();
                result = true;
            }
            return result;
        }        

        public async Task<Category> Get(int? id)
        {            
            return db.Categories.Find(id);
        }

        public async Task<ICollection<Category>> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool Update(Category entity)
        {
            
            bool result = false;
            
                db.Categories.Update(entity);
                //db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                result = true;
            
            return result;
        }
    }
}
