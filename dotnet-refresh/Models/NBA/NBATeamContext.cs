using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_refresh.Models
{
    public class NBATeamContext : DbContext
    {
        public NBATeamContext(DbContextOptions<NBATeamContext> options)
            : base(options)
        {
        }

        public DbSet<NBATeam> NBATeams { get; set; }
    }
}
