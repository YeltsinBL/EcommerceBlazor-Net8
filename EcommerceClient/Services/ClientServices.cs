using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using EcommerceSharedLibrary.Interfaces;
using EcommerceSharedLibrary.Models;
using EcommerceSharedLibrary.Responses;

namespace EcommerceClient;

public class ClientServices(HttpClient httpClient) : IProduct
{
    private const string BaseUrl = "api/product";

    # region Configuraciones para Serializar y Deserializar modelos/string

    // Para serializar el modelo, el parametro es generico para no limitarlo y devuelve un string.
    private static string serializedObj(object modelObject) 
                => JsonSerializer.Serialize(modelObject,JsonOptions());
    // Para deserializar un string, pasamos el json y devolvemos un objeto generico
    private static T DeserializeJsonString<T>(string jsonString)
                => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
    private static StringContent GenerateStringContext(string serializedObj) 
                => new(serializedObj, Encoding.UTF8,"application/jason");
    // Para deserializar un string, pasamos el json y devolvemos un objeto generico en lista
    private static IList<T> DeserializeJsonStringList<T>(string jsonString)
                => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
    private static JsonSerializerOptions JsonOptions()
    {
        return new JsonSerializerOptions{
            AllowTrailingCommas = true,//omitir comas al final del json
            PropertyNameCaseInsensitive = true, // no distinguir entre mayusculas y minuscula
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // los nombres de las politicas de propiedad en CamelCase
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip // omitir el manejo de los miembros del mapeo
        };
    }
    #endregion

    public async Task<ServiceResponse> AddProduct(Product product)
    {
        var response = await httpClient.PostAsync(BaseUrl, GenerateStringContext(serializedObj(product)));
        if (!response.IsSuccessStatusCode)
            return new ServiceResponse(false, "Ocurrio un error. Intenttelo mas tarde...");
        var apiResponse = await response.Content.ReadAsStringAsync();
        return DeserializeJsonString<ServiceResponse>(apiResponse);
    }

    public async Task<List<Product>> GetAllProducts(bool featuredProducts)
    {
        var response = await httpClient.GetAsync($"{BaseUrl}?featured={featuredProducts}");
        if(!response.IsSuccessStatusCode) return null!;
        var result = await response.Content.ReadAsStringAsync();
        return [.. DeserializeJsonStringList<Product>(result)];
    }
}
