using HW7_8.Models;

namespace HW7_8.Data.Repository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategoryById(int id);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(int id);
    }
}
