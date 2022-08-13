using DotNetCoreProj.Interface;
using DotNetCoreProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreProj.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Productcontroller : ControllerBase
    {
     private readonly IProduct _IProduct;

    public Productcontroller(IProduct IProduct)
    {
        _IProduct = IProduct;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> ProductsList()
    {
        return await Task.FromResult(_IProduct.ProductsList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var products = await Task.FromResult(_IProduct.ProductDetail(id));
        if (products == null)
        {
            return NotFound();
        }
        return products;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
            _IProduct.CreateProduct(product);
        return await Task.FromResult(product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        try
        {
                _IProduct.UpdateProduct(product);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProducteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
            return await Task.FromResult(product);
        }

        [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var employee = _IProduct.DeleteProduct(id);
        return await Task.FromResult(employee);
    }

    private bool ProducteExists(int id)
    {
        return _IProduct.CheckProduc(id);
    }
}
}