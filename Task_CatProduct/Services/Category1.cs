using Microsoft.EntityFrameworkCore;
using Task_CatProduct.Model.Data;

//using Task_CatProduct.Model.Data;
using Task_CatProduct.Model.Dto;

namespace Task_CatProduct.Services
{
    public class Category1 : ICategory

    {
        private readonly CatProcuctDbContext catProcuctDbContext;

        public Category1(CatProcuctDbContext catProcuctDbContext)
        {
            this.catProcuctDbContext = catProcuctDbContext;
        }
        public Task ActivateCategoryAsync(int id)
        {
            return Task.CompletedTask;
        }

        public async Task AddCategory(dto_AddCategory addCategory)
        {
            var category = new Category
            {
                IsActive = addCategory.IsActive,
                Name = addCategory.Name,
                Products = addCategory.Products,

            };
          await  catProcuctDbContext.Categories.AddAsync(category);

        }

        public async Task DaleteCategoryAsyn(int id)
        {
            var category = await catProcuctDbContext.Categories.FindAsync(id);
            if (category != null)
            {
                catProcuctDbContext.Categories.Remove(category);
                await catProcuctDbContext.SaveChangesAsync();
            }
        }

        public Task DeactivateCategoryAsync(int id)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Model.Data.Category>> GetAllCategoriesAsync(int pageNumber, int pageSize)
        {
            return await catProcuctDbContext.Categories.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
        }

        //public async Task<List<Model.Data.Category>> GetAllCategoriesAsync(int pageNumber, int pageSize)
        //{
        //   return await catProcuctDbContext.Categories
        // .Skip((pageNumber - 1) * pageSize)
        // .Take(pageSize)
        // .ToListAsync();
        //}

        public async Task<Model.Data.Category> GetByIdAsync(int id)
        {
            return await catProcuctDbContext.Categories.FindAsync(id);
        }

        public async Task UpdateCategoryAsync(int id, dto_Update_Category Updatecategory)
        {
            var category = await catProcuctDbContext.Categories.FindAsync(id);
            if (category != null)
            {


                category.Name = Updatecategory.Name;
                category.IsActive = Updatecategory.IsActive;
                category.Products = Updatecategory.Products;

                await catProcuctDbContext.SaveChangesAsync();




            }
        }
    }
}
