using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using EcommerceServer.Data;
using EcommerceSharedLibrary.Interfaces;
using EcommerceSharedLibrary.Models;
using EcommerceSharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;

namespace EcommerceServer;

public class ProductRepository : IProduct
{
    private readonly AppDbContext _appDbContext;
    public ProductRepository(AppDbContext appDbContext){
        _appDbContext = appDbContext;
    }
    public async Task<ServiceResponse> AddProduct(Product product)
    {
        if(product is null) return new ServiceResponse(false,"El modelo es nulo");
        var (flag, message) = await CheckName(product.Name!);
        if (flag){
            _appDbContext.Products.Add(product);
            await Commit();
            return new ServiceResponse(true, "Producto Guardado");
        }
        return new ServiceResponse(flag, message);
    }

    public async Task<List<Product>> GetAllProducts(bool featuredProducts)
    {
        if (featuredProducts)
            return await _appDbContext.Products.Where(_ => _.Featured).ToListAsync();
        else
            return await _appDbContext.Products.ToListAsync();
    }


    /// <summary>
    /// Verificar si el nombre del producto existe en la BD
    /// </summary>
    /// <param name="name">Nombre del Producto</param>
    /// <returns>Verdadero o falso, dependiendo de la evaluación</returns>
    private async Task<ServiceResponse> CheckName(string name){
        var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "El producto ya existe");
    }
    private async Task Commit()=> await _appDbContext.SaveChangesAsync();

}
