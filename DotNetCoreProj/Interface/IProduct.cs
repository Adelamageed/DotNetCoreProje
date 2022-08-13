using DotNetCoreProj.Models;

namespace DotNetCoreProj.Interface
{
    public interface IProduct
    {
        public List<Product> ProductsList();
        public Product ProductDetail(int id);
        public void CreateProduct(Product product);
        public void UpdateProduct( Product product);
        public Product DeleteProduct(int id);
        public bool CheckProduc(int id);
    }
}
