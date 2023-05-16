
using HW7_8.Models;

namespace HW7_8.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = dbContext.categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = dbContext.categories.SingleOrDefault(c => c.Id == id);
            
            return category;
        }

        public void Add(Category category)
        {
            dbContext.categories.Add(category);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.categories.Remove(GetCategoryById(id));
            dbContext.SaveChanges();
        }
        public void Update(Category category)
        {
            dbContext.categories.Update(category); 
            dbContext.SaveChanges();
        }
    }
}
