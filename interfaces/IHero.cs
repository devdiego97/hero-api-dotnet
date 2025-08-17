using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hero_api_dotnet.Enum;

namespace hero_api_dotnet.interfaces
{
    public interface IHero
    {
        int Id { get; set; }
       string Name { get; set; }
       HeroType Type{ get; set; }
       SexHero Sex { get; set; }
       string Abilities{ get; set; }
       string Superpower { get; set; }
    }
}