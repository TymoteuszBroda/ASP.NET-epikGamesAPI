using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace epikGamesAPI.models;

public class User
{
    [Key]
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}
