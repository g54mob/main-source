using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using Jundroo.ModTools;
using Jundroo.ModTools.Core;
using ModApi.Core.Events;
using ModApi.Craft.Parts;
using ModApi.Mods;
using ModApi.Settings.Core;
using Unity.IO.Compression;
using UnityEngine;

namespace ModApi.Core
{
	public class ModManager : ModManagerBase, IModManager, IModManagerBase, ModApi.Mods.IModManager
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

		public static byte[] CompressedModByteHeader => Encoding.ASCII.GetBytes("SimpleRockets 2".Replace(" ", string.Empty) + "CompressedModFileV001");

		public static IModManager Instance => _ModManager;

		public static string ModManifestSectionName => "GameData";

		public IReadOnlyList<GameMod> GameMods => _gameMods;

		public ReadOnlyCollection<ModPartInfo> Parts => new ReadOnlyCollection<ModPartInfo>(_loadedMods.SelectMany((LoadedModData x) => x.ManifestData.Parts).ToList());

		bool ModApi.Mods.IModManager.SupportsCodeExecution => base.SupportsCodeExecution;

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

		protected override Assembly AssemblyResolve(object sender, ResolveEventArgs args)
		{
			Assembly assembly = base.AssemblyResolve(sender, args);
			if (assembly == null && args.Name.StartsWith("ModApi,"))
			{
				assembly = typeof(GameMod).Assembly;
			}
			return assembly;
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
				return Directory.GetFiles(directory, "*.sr2-mod", searchOption);
			}
			if (Device.IsAndroidBuild)
			{
				return Directory.GetFiles(directory, "*.sr2-mod-android", searchOption);
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

		protected override bool VerifyApiVersions(ModInfo mod, ModManifest modManifest)
		{
			bool flag = base.VerifyApiVersions(mod, modManifest);
			if (!flag)
			{
				return flag;
			}
			Version version = typeof(Project).Assembly.GetName().Version;
			Version apiVersion = modManifest.GetApiVersion();
			if (version != apiVersion)
			{
				RaiseApiVersionMismatch(mod, version, apiVersion, "ModApi");
				return false;
			}
			return true;
		}

		private ModManifestData ReadModManifest(LoadedMod mod, ModManifest manifest)
		{
			ModManifestData modManifestData = new ModManifestData(mod.ModInfo);
			XElement[] array = new XElement[0];
			foreach (XElement item in manifest.GetElement("PersistentObjects")?.Elements("PersistentObject") ?? array)
			{
				modManifestData.PersistentGameObjects.Add(new PersistentObjectInfo((string)item.Attribute("path")));
			}
			foreach (XElement item2 in manifest.GetElement("Parts")?.Elements("Part") ?? array)
			{
				string id = (string)item2.Attribute("id");
				string xmlPath = (string)item2.Attribute("xmlPath");
				string prefabPath = (string)item2.Attribute("prefabPath");
				modManifestData.Parts.Add(new ModPartInfo(id, prefabPath, xmlPath));
			}
			foreach (XElement item3 in manifest.GetElement("PartCategories")?.Elements("PartCategory") ?? array)
			{
				string text = (string)item3.Attribute("path");
				DesignerPartCategory designerPartCategory = (string.IsNullOrWhiteSpace(text) ? null : mod.ResourceLoader.LoadAsset<DesignerPartCategory>(text));
				if (designerPartCategory == null)
				{
					Debug.LogError("Unable to load category from mod '" + mod.ModInfo.Name + "' at path '" + (text ?? string.Empty) + "'.");
				}
				else
				{
					modManifestData.PartCategories.Add(designerPartCategory);
				}
			}
			XElement element = manifest.GetElement("PartTextureStyles");
			if (element != null && ((int?)element.Attribute("count")).GetValueOrDefault() > 0)
			{
				string path = (string)element.Attribute("path");
				try
				{
					modManifestData.PartTextureStyles = mod.ResourceLoader.LoadAsset<TextAsset>(path);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			XElement element2 = manifest.GetElement("PartStyleExtensions");
			if (element2 != null && ((int?)element2.Attribute("count")).GetValueOrDefault() > 0)
			{
				string path2 = (string)element2.Attribute("path");
				try
				{
					modManifestData.PartStyleExtensions = mod.ResourceLoader.LoadAsset<TextAsset>(path2);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
			}
			modManifestData.PropulsionData = mod.ResourceLoader.LoadAsset<TextAsset>("Assets/Content/Craft/Parts/RocketEngines/Propulsion.xml");
			foreach (XElement item4 in manifest.GetElement("PartModifiers")?.Elements("Assembly") ?? array)
			{
				modManifestData.PartModifiers.Add(new ModPartModifiersInfo((string)item4.Attribute("name"), from x in item4.Elements("Modifier")
					select (string)x.Attribute("type")));
			}
			foreach (XElement item5 in manifest.GetElement("PlanetModifiers")?.Elements("Assembly") ?? array)
			{
				modManifestData.PlanetModifiers.Add(new ModPlanetModifiersInfo((string)item5.Attribute("name"), from x in item5.Elements("Modifier")
					select (string)x.Attribute("type")));
			}
			foreach (XElement item6 in manifest.GetElement("UIResourceDatabases")?.Elements("UIResourceDatabase") ?? array)
			{
				modManifestData.UIResourceDatabases.Add(((string)item6.Attribute("path"), (int)item6.Attribute("assetCount"), (bool)item6.Attribute("isOverride")));
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
					Game.Instance.Settings.ModSettings.RegisterCategory(category);
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
