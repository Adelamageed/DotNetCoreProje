using DotNetCoreProj.Interface;
using DotNetCoreProj.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreProj.Repository
{
    public class ProductRepository : IProduct
    {
        readonly DatabaseContext _dbContext = new();

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> ProductsList()
        {
            try
            {
                return _dbContext.Product.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Product ProductDetail(int id)
        {
            try
            {
                Product? product = _dbContext.Product.Find(id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void CreateProduct(Product product)
        {
            try
            {
                _dbContext.Product.Add(product);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProduct( Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Product DeleteProduct(int id)
        {
            try
            {
                Product? product = _dbContext.Product.Find(id);

                if (product != null)
                {
                    _dbContext.Product.Remove(product);
                    _dbContext.SaveChanges();
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckProduc(int id)
        {
            return _dbContext.Product.Any(e => e.ProductId == id);
        }
    }
}