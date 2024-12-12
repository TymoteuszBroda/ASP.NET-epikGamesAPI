using System;

namespace epikGamesAPI.models;

public class User
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}
