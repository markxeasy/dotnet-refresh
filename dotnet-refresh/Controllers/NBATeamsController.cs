using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_refresh.Models;

namespace dotnet_refresh.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class NBATeamsController : ControllerBase
    {
        private readonly NBATeamContext _context;

        public NBATeamsController(NBATeamContext context)
        {
            _context = context;
        }

        // GET: api/NBATeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NBATeam>>> GetNBATeams()
        {
            _context.NBATeams.Where(t => t.IsGood == true);
            return await _context.NBATeams.ToListAsync();
        }

        // GET: api/NBATeams/good
        [HttpGet("good")]
        public async Task<ActionResult<IEnumerable<NBATeam>>> GetGoodNBATeams()
        {
            return await _context.NBATeams.Where(t => t.IsGood == true).ToListAsync();
        }

        // GET: api/NBATeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NBATeam>> GetNBATeam(long id)
        {
            var nBATeam = await _context.NBATeams.FindAsync(id);

            if (nBATeam == null)
            {
                return NotFound();
            }

            return nBATeam;
        }

        // PUT: api/NBATeams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNBATeam(long id, NBATeam nBATeam)
        {
            if (id != nBATeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(nBATeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NBATeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NBATeams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NBATeam>> PostNBATeam(NBATeam nBATeam)
        {
            _context.NBATeams.Add(nBATeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNBATeam", new { id = nBATeam.Id }, nBATeam);
        }

        // DELETE: api/NBATeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NBATeam>> DeleteNBATeam(long id)
        {
            var nBATeam = await _context.NBATeams.FindAsync(id);
            if (nBATeam == null)
            {
                return NotFound();
            }

            _context.NBATeams.Remove(nBATeam);
            await _context.SaveChangesAsync();

            return nBATeam;
        }

        private bool NBATeamExists(long id)
        {
            return _context.NBATeams.Any(e => e.Id == id);
        }
    }
}
