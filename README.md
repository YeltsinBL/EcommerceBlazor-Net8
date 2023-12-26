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
