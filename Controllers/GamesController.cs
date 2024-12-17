using epikGamesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]/[Action]")]
[ApiController]
public class GamesController : ControllerBase
{
    public readonly AppDbContext _context;

    public GamesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        var games = await _context.Games.ToListAsync();
        return games;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game =await _context.Games.FindAsync(id);
        if (game!= null)
        {
            return game;
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<ActionResult<Game>> AddGames(Game game)
    {
        await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();
        return Created();
    }
}
