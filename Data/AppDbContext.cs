using System;
using epikGamesAPI.models;
using Microsoft.EntityFrameworkCore;

namespace epikGamesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users {get; set;}
    
        
}
