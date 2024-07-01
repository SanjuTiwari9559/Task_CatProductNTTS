
using Microsoft.EntityFrameworkCore;
using Task_CatProduct.Model.Data;
using Task_CatProduct.Model.Dto;

namespace Task_CatProduct.Services
{
    public class Product1 : IProduct
    {
       
        private readonly CatProcuctDbContext catProcuctDbContext;

        public Product1(CatProcuctDbContext catProcuctDbContext )
        {
            
            this.catProcuctDbContext = catProcuctDbContext;
        }
        public async Task AddAsync(dto_addProduct addproduct)
        {
            var product = new Product
            {
                Name = addproduct.Name,
                IsActive = addproduct.IsActive,
                CategoryId = addproduct.CategoryId
            };
            await catProcuctDbContext.AddAsync(product);
            await catProcuctDbContext.SaveChangesAsync();
        }

        //public async Task AddAsync(dto_addProduct addproduct)
        //{
        //    var product = new Product
        //    {
        //        Name = addproduct.Name,
        //        IsActive = addproduct.IsActive,
        //        CategoryId = addproduct.CategoryId
        //    };
        //    await  catProcuctDbContext.Products.AddAsync(product);
        //    await catProcuctDbContext.SaveChangesAsync();
        //}

        //public Task AddAsync(dto_AddCategory addproduct)
        //{
        //    var product = new Product
        //  {
        //        Name = addproduct.Name,
        //        IsActive = addproduct.IsActive,
        //        CategoryId = addproduct.Cat
        //    };
        //    await catProcuctDbContext.Products.AddAsync(product);
        //    await catProcuctDbContext.SaveChangesAsync();
        //}

        public async Task DeleteAsync(int id)
        {
            var products= await catProcuctDbContext.Products.FindAsync(id);
            if(products != null)
            {
                 catProcuctDbContext.Products.Remove(products);
                 await catProcuctDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await catProcuctDbContext.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
          return await catProcuctDbContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(dto_UpdateProduct product ,int id)
        {
          var existingproduct=  await catProcuctDbContext.Products.FindAsync(id);
            if(existingproduct != null)
            {
                existingproduct.Name = product.Name;
                existingproduct.IsActive = product.IsActive;
                existingproduct.CategoryId= product.CategoryId;
                await catProcuctDbContext.SaveChangesAsync();
            }
        }
    }
}
