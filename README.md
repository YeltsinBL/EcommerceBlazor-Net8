# EcommerceBlazor-Net8

Aplicación de Ecommerce utilizando .Net 8, Blazor y AspNetCore Web Api, todo se ha realizado en Visual Studio Code.

## Creación de Proyecto

- Server

```sh
dotnet new webapi --use-controllers -o EcommerceServer
```

- Client

```sh
dotnet new blazorwasm -o EcommerceClient
```

- Shared Library

```sh
dotnet new classlib -o EcommerceSharedLibrary
```

## Server

- Paquetes nugets versión 8.0.0:
  - Microsoft.AspNetCore.Components.WebAssembly.Server
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.EntityFrameworkCore.SqlServer

- Migración a la BD

```sh
dotnet ef migrations add {{migration_name}}
dotnet ef database update
```

- Controllers
  - ProductController: GetAllProducts y AddProduct.
- Repositories
  - ProductRepository: implementación del IProduct.

## SharedLibrary

- Models
  - Product
- Responses
  - ServiceResponse: True/False y mensaje.
- Interfaces
  - IProduct: AddProduct y GetAllProducts.

## Client

- Se instalo LibMan para obtener Librerias

```sh
# Instalar la CLS de LibMan
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
# Inicializar LibMan para crear el archivo, por defecto el provider es cdnjs
libman init
# Agregamos la Libreria a utilizar 
libman install font-awesome@6.5.1 --provider cdnjs --destination wwwroot/font-awesome
```

> Nota: Agregamos el CSS y Js en el archivo index que esta dentro de wwwroot.

- Pages:
  - AddOrUpdateProductComponent: Creacion del formulario para registrar un producto.
  - BusyButtonComponent: boton de cargando cuando se realice una accion.
- _Imports: agregar las referencias que se utilizaran en todo el proyecto
