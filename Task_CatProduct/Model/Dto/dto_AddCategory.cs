﻿using Task_CatProduct.Model.Data;

namespace Task_CatProduct.Model.Dto
{
    public class dto_AddCategory
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Product> Products { get; set; }
    }
}