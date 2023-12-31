using EcommerceSharedLibrary.Interfaces;
using EcommerceSharedLibrary.Models;
using EcommerceSharedLibrary.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceServer.Controllers;

[Route("api/[controller]")]
[ApiController]
// Inyectamos como un constructor primario
public class ProductController(IProduct _product) : Controller
{

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts(bool featured){
        var products = await _product.GetAllProducts(featured); return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse>> AddProduct(Product product){
        if (product is null) return BadRequest("El modelo es nulo");
        var response = await _product.AddProduct(product);
        return Ok(response);
    }
}
