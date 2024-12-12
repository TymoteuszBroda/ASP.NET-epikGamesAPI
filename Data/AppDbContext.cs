using System;
using epikGamesAPI.models;
using Microsoft.EntityFrameworkCore;

namespace epikGamesAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users {get; set;}
    
        
}
