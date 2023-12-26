# EcommerceBlazor-Net8

Aplicación de Eccommerce utilizando .Net 8, Blazor y AspNetCore Web Api, todo se ha realizado en Visual Studio Code.

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

- Paquetes nugets version 8.0.0:
  - Microsoft.AspNetCore.Components.WebAssembly.Server
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.EntityFrameworkCore.SqlServer

- Migracion a la BD

```sh
dotnet ef migrations add {{migration_name}}
dotnet ef database update
```
