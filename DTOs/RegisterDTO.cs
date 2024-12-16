using System;
using System.ComponentModel.DataAnnotations;

namespace epikGamesAPI.DTOs;

public class RegisterDTO
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string password {get; set;  }
}
