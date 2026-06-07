namespace Assets.Scripts.Mods
{
	public struct ModLevelInfo
	{
		public string Description { get; set; }

		public string LevelTypeName { get; set; }

		public string MapName { get; set; }

		public ModInfo Mod { get; set; }

		public string Name { get; set; }

		public LevelSupportedPlatforms SupportedPlatform { get; set; }

		public ModLevelInfo(string name, string description, string mapName, string levelTypeName, LevelSupportedPlatforms supportedPlatform)
		{
			this = default(ModLevelInfo);
			Name = name;
			Description = description;
			MapName = mapName;
			LevelTypeName = levelTypeName;
			SupportedPlatform = supportedPlatform;
		}

		public ModLevelInfo(string name, string description, string mapName, string levelTypeName, LevelSupportedPlatforms supportedPlatform, ModInfo mod)
		{
			this = default(ModLevelInfo);
			Name = name;
			Description = description;
			MapName = mapName;
			LevelTypeName = levelTypeName;
			SupportedPlatform = supportedPlatform;
			Mod = mod;
		}
	}
}
