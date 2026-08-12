// Thunderstore Mod Manager - Profile management for mod configurations
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ThunderstoreModManager.Models
{
    public class Profile
    {
        public string Name { get; set; } = "Default";
        public string GameId { get; set; } = "";
        public List<ModEntry> Mods { get; set; } = new();
        public string GamePath { get; set; } = "";
        public DateTime LastModified { get; set; } = DateTime.Now;
    }

    public class ModEntry
    {
        public string PackageName { get; set; } = "";
        public string Version { get; set; } = "";
        public bool Enabled { get; set; } = true;
        public DateTime InstalledAt { get; set; }
    }

    public class ProfileManager
    {
        private readonly string _profilesDir;
        public List<Profile> Profiles { get; } = new();

        public ProfileManager(string baseDir)
        {
            _profilesDir = Path.Combine(baseDir, "profiles");
            Directory.CreateDirectory(_profilesDir);
        }

        public void LoadAll()
        {
            Profiles.Clear();
            foreach (var file in Directory.GetFiles(_profilesDir, "*.json"))
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var profile = JsonSerializer.Deserialize<Profile>(json);
                    if (profile != null) Profiles.Add(profile);
                }
                catch { }
            }
        }

        public void Save(Profile profile)
        {
            profile.LastModified = DateTime.Now;
            var json = JsonSerializer.Serialize(profile, new JsonSerializerOptions { WriteIndented = true });
            var path = Path.Combine(_profilesDir, $"{profile.Name}.json");
            File.WriteAllText(path, json);
        }

        public void Delete(string name)
        {
            var path = Path.Combine(_profilesDir, $"{name}.json");
            if (File.Exists(path)) File.Delete(path);
            Profiles.RemoveAll(p => p.Name == name);
        }

        public Profile Create(string name, string gameId, string gamePath)
        {
            var profile = new Profile { Name = name, GameId = gameId, GamePath = gamePath };
            Profiles.Add(profile);
            Save(profile);
            return profile;
        }
    }
}
