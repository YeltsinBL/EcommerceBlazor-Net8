using EcommerceSharedLibrary.Models;
using EcommerceSharedLibrary.Responses;

namespace EcommerceSharedLibrary.Interfaces;

public interface IProduct
{
    Task<ServiceResponse> AddProduct(Product product);
    Task<List<Product>> GetAllProducts(bool featuredProducts);
}
