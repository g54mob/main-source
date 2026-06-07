using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods.Events;
using Jundroo.Common.Exceptions;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Unity.IO.Compression;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public class ModManager : ModManagerBase, IModManager, IModManagerBase
	{
		private class LoadedModData
		{
			public ModManifestData ManifestData { get; private set; }

			public LoadedMod Mod { get; private set; }

			public LoadedModData(LoadedMod mod, ModManifestData manifestData)
			{
				Mod = mod;
				ManifestData = manifestData;
			}
		}

		private static readonly ModManager _ModManager = new ModManager();

		private List<GameMod> _gameMods;

		private List<LoadedModData> _loadedMods;

		public static byte[] CompressedModByteHeader => Encoding.ASCII.GetBytes("SimplePlanes2".Replace(" ", string.Empty) + "CompressedModFileV001");

		public static IModManager Instance => _ModManager;

		public static string ModManifestSectionName => "GameData";

		public IReadOnlyList<MapInfo> AllMaps => _loadedMods.SelectMany((LoadedModData x) => x.ManifestData.Maps).ToList();

		public IReadOnlyList<GameMod> GameMods => _gameMods;

		public IReadOnlyList<ModLevelInfo> Levels => _loadedMods.SelectMany((LoadedModData x) => x.ManifestData.Levels).ToList();

		public IReadOnlyList<MapInfo> SandboxMaps => (from x in _loadedMods.SelectMany((LoadedModData x) => x.ManifestData.Maps)
			where x.AllowSandbox
			select x).ToList();

		public event EventHandler<ModLoadedEventArgs> ModLoaded;

		private ModManager()
		{
			_gameMods = new List<GameMod>();
			_loadedMods = new List<LoadedModData>();
		}

		public static void DecompressMod(string modPath)
		{
			byte[] compressedModByteHeader = CompressedModByteHeader;
			FileInfo fileInfo = new FileInfo(modPath);
			if (!fileInfo.Exists || fileInfo.Length <= compressedModByteHeader.Length)
			{
				return;
			}
			byte[] array = new byte[compressedModByteHeader.Length];
			using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
			{
				fileStream.Read(array, 0, array.Length);
			}
			if (!array.SequenceEqual(compressedModByteHeader))
			{
				return;
			}
			fileInfo.IsReadOnly = false;
			string text = fileInfo.FullName + ".temp";
			File.Copy(fileInfo.FullName, text, overwrite: true);
			using (FileStream fileStream2 = new FileStream(text, FileMode.Open, FileAccess.Read))
			{
				fileStream2.Position = compressedModByteHeader.Length;
				using GZipStream gZipStream = new GZipStream(fileStream2, CompressionMode.Decompress);
				using FileStream fileStream3 = new FileStream(fileInfo.FullName, FileMode.Create, FileAccess.Write);
				byte[] array2 = new byte[8096];
				int num = 0;
				while ((num = gZipStream.Read(array2, 0, array2.Length)) > 0)
				{
					fileStream3.Write(array2, 0, num);
				}
			}
			File.Delete(text);
		}

		public void DecompressMods(string directory, bool recursive)
		{
			if (Directory.Exists(directory))
			{
				string[] modFilePaths = GetModFilePaths(directory, recursive);
				for (int i = 0; i < modFilePaths.Length; i++)
				{
					DecompressMod(modFilePaths[i]);
				}
			}
		}

		public ModLevelInfo? GetModLevelInfo(string modName, string levelName)
		{
			return Levels.Cast<ModLevelInfo?>().FirstOrDefault((ModLevelInfo? x) => x.Value.Mod.Name == modName && x.Value.Name == levelName);
		}

		public MapInfo? GetModMapInfo(string modName, string mapName)
		{
			return AllMaps.Cast<MapInfo?>().FirstOrDefault((MapInfo? x) => x.Value.Mod.Name == modName && x.Value.Name == mapName);
		}

		public LevelBase LoadLevel(ModLevelInfo level)
		{
			if (_loadedMods.Where((LoadedModData x) => x.Mod.ModInfo.Path == level.Mod.Path).FirstOrDefault() == null)
			{
				throw new InvalidOperationException($"Could not load level '{level.Name}' from mod '{level.Mod.Name}' because the mod could not be found in the list of loaded mods");
			}
			Type type = Type.GetType(level.LevelTypeName);
			if (type == null)
			{
				throw new InvalidOperationException($"Could not load level '{level.Name}' from mod '{level.Mod.Name}' because the level type '{level.LevelTypeName}' could not be found");
			}
			return (LevelBase)Activator.CreateInstance(type);
		}

		public GameObject LoadMap(MapInfo map)
		{
			GameObject gameObject = (_loadedMods.Where((LoadedModData x) => x.Mod.ModInfo.Path == map.Mod.Path).FirstOrDefault() ?? throw new InvalidOperationException($"Could not load map '{map.Name}' from mod '{map.Mod.Name}' because the mod could not be found in the list of loaded mods")).Mod.ResourceLoader.LoadAsset<GameObject>(map.PrefabPath);
			if (gameObject == null)
			{
				throw new AssetNotFoundException($"Attempted to load map '{map.Name}' from mod '{map.Mod.Name}' but the map could not be found at path '{map.PrefabPath}' in the mod's assets.");
			}
			return gameObject;
		}

		protected override Type GetGameModObjectType()
		{
			return typeof(GameMod);
		}

		protected override string[] GetModFilePaths(string directory, bool recursive)
		{
			SearchOption searchOption = (recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			if (Device.IsWindowsBuild || Device.IsOsxBuild || Device.IsLinuxBuild)
			{
				return Directory.GetFiles(directory, "*.sp2-mod", searchOption);
			}
			if (Device.IsAndroidBuild)
			{
				return Directory.GetFiles(directory, "*.sp2-mod-android", searchOption);
			}
			return new string[0];
		}

		protected override void OnGameModObjectInitialized(GameModBase mod)
		{
			_gameMods.Add((GameMod)mod);
		}

		protected override void OnModLoaded(LoadedMod mod, ModManifest manifest)
		{
			base.OnModLoaded(mod, manifest);
			ModManifestData manifestData = ReadModManifest(mod, manifest);
			_loadedMods.Add(new LoadedModData(mod, manifestData));
			this.ModLoaded?.Invoke(this, new ModLoadedEventArgs(mod, manifestData));
			foreach (GameModBase gameMod in mod.GameMods)
			{
				gameMod.OnModLoaded();
			}
		}

		protected override void ScanLoadedAssembly(LoadedMod mod, Assembly assembly, IReadOnlyList<Type> types)
		{
			base.ScanLoadedAssembly(mod, assembly, types);
			RegisterModSettings(mod, types);
		}

		private ModManifestData ReadModManifest(LoadedMod mod, ModManifest manifest)
		{
			ModManifestData modManifestData = new ModManifestData(mod.ModInfo);
			XElement[] array = new XElement[0];
			foreach (XElement item in manifest.GetElement("PersistentObjects")?.Elements("PersistentObject") ?? array)
			{
				modManifestData.PersistentGameObjects.Add(new PersistentObjectInfo((string)item.Attribute("path")));
			}
			foreach (XElement item2 in manifest.GetElement("Maps")?.Elements("Map") ?? array)
			{
				modManifestData.Maps.Add(new MapInfo((string)item2.Attribute("name"), (string)item2.Attribute("description"), (string)item2.Attribute("path"), (bool)item2.Attribute("allowSandbox"), mod.ModInfo));
			}
			foreach (XElement item3 in manifest.GetElement("Levels")?.Elements("Level") ?? array)
			{
				modManifestData.Levels.Add(new ModLevelInfo((string)item3.Attribute("name"), (string)item3.Attribute("description"), (string)item3.Attribute("mapName"), (string)item3.Attribute("levelTypeName"), (LevelSupportedPlatforms)((int?)item3.Attribute("supportedPlatform")).GetValueOrDefault(), mod.ModInfo));
			}
			return modManifestData;
		}

		private void RegisterModSettings(LoadedMod mod, IReadOnlyList<Type> types)
		{
			try
			{
				foreach (Type item in types.Where((Type x) => typeof(SettingsCategory).IsAssignableFrom(x) && !x.IsAbstract).ToList())
				{
					RuntimeHelpers.RunClassConstructor(item.TypeHandle);
					SettingsCategory category = (SettingsCategory)Activator.CreateInstance(item);
					Game.Instance.Settings.Mods.RegisterCategory(category);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				LogLoadError(mod.ModInfo, "An error occurred registering mod settings in mod '" + mod.ModInfo.Name + "'.");
			}
		}
	}
}
