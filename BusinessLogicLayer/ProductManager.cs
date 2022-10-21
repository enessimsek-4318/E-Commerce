using DataAccesLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ProductManager
    {
        Repository<Product> repProduct = new Repository<Product>();
        public List<Product> ProductList()
        {
            return repProduct.List();
        }
        public Product ProductFind(int Id)
        {
            return repProduct.Find(i => i.productId == Id);
        }
        public int ProductSave(Product product)
        {
            return repProduct.Insert(product);
        }
        public int ProductDelete(int Id)
        {
            var deleteProduct = repProduct.Find(i => i.productId == Id);
            if (deleteProduct != null)
            {
                return repProduct.Delete(deleteProduct);
            }
            return 0;
        }
        public int ProductEdit(Product editProduct)
        {
            var product=repProduct.Find(i => i.productId == editProduct.productId);
            if (product!=null)
            {
                product.productName = editProduct.productName;
                product.productDescription = editProduct.productDescription;
                product.price = editProduct.price;
                product.productBrand = editProduct.productBrand;
                product.productPhoto = editProduct.productPhoto;
                product.categoryId = editProduct.categoryId;
                product.stockNumber = editProduct.stockNumber;
            }
            return repProduct.Edit(product);
        }
    }
}
