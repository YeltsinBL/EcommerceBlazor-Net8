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

- Paquetes nugets:
  - Microsoft.AspNetCore.Components.WebAssembly.Server
