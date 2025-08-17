using hero_api_dotnet.Enum;

namespace hero_api_dotnet.Dto;

public record HeroDtoUpdate(
    string? Name,
    HeroType? Type,
    SexHero? Sex,
    string? Abilities,
    string? Superpower
);
