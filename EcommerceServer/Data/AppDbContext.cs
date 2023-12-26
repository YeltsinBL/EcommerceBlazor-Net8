﻿using EcommerceSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceServer.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base (options){

    }
    public DbSet<Product> Products { get; set; } = default!;
}
