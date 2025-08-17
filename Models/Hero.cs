using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using hero_api_dotnet.Enum;
using hero_api_dotnet.interfaces;

namespace hero_api_dotnet.Models
{
    public class Hero:IHero
    {
        public int Id { get; set; }
         [Column("name")]
        public string Name { get; set; } = string.Empty;
        
         [Column("type")]
        public HeroType Type { get; set; }
         [Column("sex")]
        public SexHero Sex { get; set; }
         [Column("abilities")]
        public string Abilities { get; set; } = string.Empty;
         [Column("superpower")]
        public string Superpower { get; set; } = string.Empty;
    
    }
}