//using Task_CatProduct.Model.Data;
using Task_CatProduct.Model.Data;
using Task_CatProduct.Model.Dto;

namespace Task_CatProduct.Services
{
    public interface ICategory
    {
        Task <IEnumerable<Model.Data.Category>> GetAllCategoriesAsync ( int pageNumber,int pageSize);
        Task <Model.Data.Category> GetByIdAsync (int id);
        Task AddCategory(dto_AddCategory addCategory);
        Task UpdateCategoryAsync(  int id ,dto_Update_Category  Updatecategory);
        Task DaleteCategoryAsyn(int id);
        Task DeactivateCategoryAsync(int id);
        Task ActivateCategoryAsync(int id);

    }
}
