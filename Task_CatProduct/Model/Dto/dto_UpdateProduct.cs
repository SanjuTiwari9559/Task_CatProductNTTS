using System.ComponentModel.DataAnnotations.Schema;
using Task_CatProduct.Model.Data;

namespace Task_CatProduct.Model.Dto
{
    public class dto_UpdateProduct
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
       
        public int CategoryId { get; set; }
       
    }
}
