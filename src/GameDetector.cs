// Thunderstore Mod Manager - Game detection for supported titles
using System;
using System.Collections.Generic;
using System.IO;

namespace ThunderstoreModManager
{
    public class GameDetector
    {
        private static readonly Dictionary<string, string[]> KnownGames = new()
        {
            ["peak"] = new[] { "PEAK", "PEAK/PEAK.exe" },
            ["lethal-company"] = new[] { "Lethal Company", "Lethal Company/Lethal Company.exe" },
            ["valheim"] = new[] { "Valheim", "Valheim/valheim.exe" },
            ["bonelab"] = new[] { "BONELAB", "BONELAB/BONELAB.exe" },
            ["content-warning"] = new[] { "Content Warning", "Content Warning/Content Warning.exe" },
            ["repo"] = new[] { "R.E.P.O.", "R.E.P.O./REPO.exe" },
            ["risk-of-rain-2"] = new[] { "Risk of Rain 2", "Risk of Rain 2/Risk of Rain 2.exe" }
        };

        public List<DetectedGame> ScanAll()
        {
            var found = new List<DetectedGame>();
            var steamPaths = GetSteamLibraryPaths();

            foreach (var lib in steamPaths)
            {
                foreach (var (gameId, paths) in KnownGames)
                {
                    foreach (var rel in paths)
                    {
                        var full = Path.Combine(lib, "steamapps", "common", rel);
                        if (File.Exists(full))
                        {
                            found.Add(new DetectedGame
                            {
                                GameId = gameId,
                                Name = gameId,
                                ExecutablePath = full,
                                InstallDir = Path.GetDirectoryName(full) ?? ""
                            });
                        }
                    }
                }
            }
            return found;
        }

        private List<string> GetSteamLibraryPaths()
        {
            var paths = new List<string>();
            var defaultSteam = @"C:\Program Files (x86)\Steam";
            if (Directory.Exists(defaultSteam))
            {
                paths.Add(defaultSteam);
                var vdf = Path.Combine(defaultSteam, "steamapps", "libraryfolders.vdf");
                if (File.Exists(vdf))
                {
                    foreach (var line in File.ReadLines(vdf))
                    {
                        if (line.Contains("\"path\""))
                        {
                            var parts = line.Split('"');
                            if (parts.Length >= 4 && Directory.Exists(parts[3]))
                                paths.Add(parts[3]);
                        }
                    }
                }
            }
            return paths;
        }
    }

    public class DetectedGame
    {
        public string GameId { get; set; } = "";
        public string Name { get; set; } = "";
        public string ExecutablePath { get; set; } = "";
        public string InstallDir { get; set; } = "";
    }
}
