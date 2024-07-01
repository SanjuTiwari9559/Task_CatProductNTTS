using Task_CatProduct.Model.Data;
using Task_CatProduct.Model.Dto;

namespace Task_CatProduct.Services
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(dto_addProduct  addproduct);
        Task UpdateAsync(dto_UpdateProduct product,int id);
        Task DeleteAsync(int id);
    }
}
