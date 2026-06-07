namespace Assets.Scripts.Mods
{
	public struct MapInfo
	{
		public bool AllowSandbox { get; set; }

		public string Description { get; set; }

		public ModInfo Mod { get; set; }

		public string Name { get; set; }

		public string PrefabPath { get; set; }

		public MapInfo(string name, string description, string prefabPath, bool allowSandbox)
		{
			this = default(MapInfo);
			Name = name;
			Description = description;
			PrefabPath = prefabPath;
			AllowSandbox = allowSandbox;
		}

		public MapInfo(string name, string description, string prefabPath, bool allowSandbox, ModInfo mod)
		{
			this = default(MapInfo);
			Name = name;
			Description = description;
			PrefabPath = prefabPath;
			AllowSandbox = allowSandbox;
			Mod = mod;
		}
	}
}
