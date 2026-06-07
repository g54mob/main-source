using System.Collections.Generic;
using Jundroo.ModTools;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Core
{
	public class ModManifestData
	{
		public ModInfo ModInfo { get; set; }

		public List<DesignerPartCategory> PartCategories { get; set; }

		public List<ModPartModifiersInfo> PartModifiers { get; set; }

		public List<ModPartInfo> Parts { get; set; }

		public TextAsset PartStyleExtensions { get; set; }

		public TextAsset PartTextureStyles { get; set; }

		public List<PersistentObjectInfo> PersistentGameObjects { get; set; }

		public List<ModPlanetModifiersInfo> PlanetModifiers { get; set; }

		public TextAsset PropulsionData { get; set; }

		public List<(string AssetPath, int AssetCount, bool IsOverride)> UIResourceDatabases { get; set; }

		public ModManifestData(ModInfo modInfo)
		{
			ModInfo = modInfo;
			Parts = new List<ModPartInfo>();
			PartCategories = new List<DesignerPartCategory>();
			PersistentGameObjects = new List<PersistentObjectInfo>();
			PartModifiers = new List<ModPartModifiersInfo>();
			PlanetModifiers = new List<ModPlanetModifiersInfo>();
			UIResourceDatabases = new List<(string, int, bool)>();
		}
	}
}
