using System;
namespace dotnet_refresh.Models
{
    public class NBATeam
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Conference { get; set; }
        public bool IsGood { get; set; }
    }
}
