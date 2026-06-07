using System;

namespace Assets.Scripts.Mods
{
	[Serializable]
	public class ModInfo
	{
		public string Author { get; private set; }

		public ModBuildInfo BuildInfo { get; }

		public string Description { get; private set; }

		public bool Enabled { get; set; }

		public bool IsBundledMod { get; set; }

		public bool IsSteamWorkshopSubscription => SteamWorkshopItemId.HasValue;

		public DateTime LastUpdated { get; private set; }

		public int LoadPriority { get; private set; }

		public string Name { get; private set; }

		public string Path { get; private set; }

		public bool PendingDisable { get; set; }

		public ulong? SteamWorkshopItemId { get; set; }

		public Version Version { get; private set; }

		public ModInfo()
		{
		}

		public ModInfo(ModBuildInfo buildInfo, string name, string description, string author, Version version, DateTime lastUpdated, int loadPriority, string path, bool enabled)
		{
			BuildInfo = buildInfo;
			Name = name;
			Description = description;
			Author = author;
			Version = version;
			LastUpdated = lastUpdated;
			LoadPriority = loadPriority;
			Path = path;
			Enabled = enabled;
		}
	}
}
