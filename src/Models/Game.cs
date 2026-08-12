using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Thunderstore.Models
{
    /// <summary>
    /// Represents a Thunderstore game entry and supported mod community.
    /// thunderstore mod manager lethal company, valheim, peak, ultrakill game model.
    /// </summary>
    public class Game
    {
        public string Id { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string CommunitySlug { get; set; } = string.Empty;
        public string InstallPath { get; set; } = string.Empty;
        public string BepInExVersion { get; set; } = string.Empty;
        public bool Is64Bit { get; set; } = true;
    }

    public static class GameRegistry
    {
        public static readonly List<Game> KnownGames = new()
        {
            new Game { Id = "lethal-company", DisplayName = "Lethal Company", CommunitySlug = "lethal-company" },
            new Game { Id = "risk-of-rain-2", DisplayName = "Risk of Rain 2", CommunitySlug = "riskofrain2" },
            new Game { Id = "valheim", DisplayName = "Valheim", CommunitySlug = "valheim" },
            new Game { Id = "ultrakill", DisplayName = "ULTRAKILL", CommunitySlug = "ultrakill" },
            new Game { Id = "peak", DisplayName = "Peak", CommunitySlug = "peak" },
            new Game { Id = "risk-of-rain-returns", DisplayName = "Risk of Rain Returns", CommunitySlug = "returnsofrain" },
            new Game { Id = "outward", DisplayName = "Outward", CommunitySlug = "outward" },
        };
    }
}
