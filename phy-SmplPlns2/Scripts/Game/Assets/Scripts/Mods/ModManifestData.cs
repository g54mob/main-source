using System.Collections.Generic;

namespace Assets.Scripts.Mods
{
	public class ModManifestData
	{
		public List<ModLevelInfo> Levels { get; set; }

		public List<MapInfo> Maps { get; set; }

		public ModInfo ModInfo { get; set; }

		public List<PersistentObjectInfo> PersistentGameObjects { get; set; }

		public ModManifestData(ModInfo modInfo)
		{
			ModInfo = modInfo;
			PersistentGameObjects = new List<PersistentObjectInfo>();
			Maps = new List<MapInfo>();
			Levels = new List<ModLevelInfo>();
		}
	}
}
