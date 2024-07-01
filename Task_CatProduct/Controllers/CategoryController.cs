using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_CatProduct.Model.Data;
using Task_CatProduct.Services;

namespace Task_CatProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;
        private readonly IProduct product;

        public CategoryController(ICategory category,IProduct product)
        {
            this.category = category;
            this.product = product;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsyncCategory(int pageNumber = 1, int pageSize = 10)

        {
            var catgory = category.GetAllCategoriesAsync(pageNumber, pageSize);
            return Ok(catgory);
        }
    }
}
