using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Assets.Packages.SocialPlatforms;
using Assets.Packages.SocialPlatforms.Steam;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Menu;
using Assets.Scripts.OperatingSystem;
using Assets.Scripts.Settings;
using Assets.Scripts.Tools;
using Jundroo.ModTools;
using Jundroo.ModTools.Core;
using Jundroo.ModTools.Core.Events;
using ModApi;
using ModApi.Core;
using ModApi.Core.Events;
using ModApi.Craft.Parts;
using ModApi.Planet.Modifiers;
using ModApi.Settings;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public class ModManagerScript : MonoBehaviour
	{
		private List<ModInfo> _apiVersionMismatchMods;

		private ModManager _modManager;

		public bool HasModSupport { get; private set; }

		public IModManager ModManager { get; private set; }

		public static ModManagerScript Create(GameObject parent)
		{
			ModManagerScript modManagerScript = new GameObject("ModManager").AddComponent<ModManagerScript>();
			modManagerScript.transform.SetParent(parent.transform);
			return modManagerScript;
		}

		public void LoadExternalModFile(string modFilePath)
		{
			ModApi.Core.ModManager.DecompressMod(CopyModFileToModDirectory(modFilePath).FullName);
			ModManager.ScanForMods(GameData.ModsPath, recursive: false, createIfNotFound: false);
			MenuScript.SkipMainMenu = true;
			GameMenuScript.ShowModsMenu = true;
		}

		protected virtual void Awake()
		{
			InitializeModManager();
		}

		private FileInfo CopyModFileToModDirectory(string modFilePath)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(SystemUtils.GetLongPathName(modFilePath));
				if (fileInfo.Exists)
				{
					FileInfo fileInfo2 = new FileInfo(Path.Combine(GameData.ModsPath, fileInfo.Name));
					if (!fileInfo2.Directory.Exists)
					{
						fileInfo2.Directory.Create();
					}
					fileInfo.CopyTo(fileInfo2.FullName, overwrite: true);
					return fileInfo2;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return null;
		}

		private void InitializeModManager()
		{
			ApplicationSettings settings = Game.Instance.Settings;
			_apiVersionMismatchMods = new List<ModInfo>();
			ModManager = ModApi.Core.ModManager.Instance;
			_modManager = (ModManager)ModManager;
			HasModSupport = !Device.IsMobileBuild;
			if (!HasModSupport || !settings.ModSupportEnabled)
			{
				return;
			}
			_modManager.DecompressMods(GameData.ModsPath, recursive: true);
			_modManager.ScanForMods(GameData.ModsPath, recursive: true, createIfNotFound: true);
			if (SocialExt.IsSteam)
			{
				List<SubscribedWorkshopItemInfo> subscribedWorkshopItems = ((SteamPlatform)SocialExt.Active).GetSubscribedWorkshopItems();
				foreach (SubscribedWorkshopItemInfo item in subscribedWorkshopItems.Where((SubscribedWorkshopItemInfo x) => x.Installed))
				{
					foreach (ModInfo item2 in _modManager.ScanForMods(item.FolderPath, recursive: true, createIfNotFound: false))
					{
						if (_modManager.KnownMods.Contains(item2))
						{
							item2.SteamWorkshopItemId = item.Id;
						}
					}
				}
				settings.UpdateWorkshopTimestamps(subscribedWorkshopItems);
			}
			foreach (ModInfo knownMod in _modManager.KnownMods)
			{
				knownMod.Enabled = settings.EnabledMods.Any((EnabledMod x) => x.IsExactMatch(knownMod, settings.IgnoreModVersionMismatches));
			}
			if (settings.UpdateEnabledMods(_modManager.KnownMods.Where((ModInfo x) => x.Enabled).ToList()))
			{
				Debug.Log("List of enabled mods changed. Saving settings...");
				settings.Save();
			}
			_modManager.ModLoaded += ModLoaded;
			_modManager.ApiVersionMismatch += ModApiVersionMismatch;
			_modManager.LoadEnabledMods(allowApiVersionMismatch: true);
			_modManager.SaveModLoadLog(Path.Combine(Game.PersistentDataPath, "ModLoadLog.txt"));
		}

		private void LoadModPartCategories(List<DesignerPartCategory> categories)
		{
			foreach (DesignerPartCategory category in categories)
			{
				try
				{
					DesignerPartCategories.Register(category);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occured trying to register part category '" + (category.Id ?? string.Empty) + "'.");
				}
			}
		}

		private void LoadModPartModifiers(LoadedMod mod, ModManifestData manifestData)
		{
			List<Assembly> modAssemblies = ModManager.GetModAssemblies();
			foreach (ModPartModifiersInfo partModifierAssembly in manifestData.PartModifiers)
			{
				Assembly assembly = modAssemblies.FirstOrDefault((Assembly x) => x.FullName == partModifierAssembly.AssemblyName);
				if (assembly == null)
				{
					Debug.LogError("Mod '" + mod.ModInfo.Name + "' contains part modifiers in assembly '" + partModifierAssembly.AssemblyName + "' but the loaded assembly could not be found.");
				}
				else
				{
					PartModifierData.Register(assembly, mod);
				}
			}
		}

		private void LoadModPlanetModifiers(LoadedMod mod, ModManifestData manifestData)
		{
			List<Assembly> modAssemblies = ModManager.GetModAssemblies();
			foreach (ModPlanetModifiersInfo planetModifierAssembly in manifestData.PlanetModifiers)
			{
				Assembly assembly = modAssemblies.FirstOrDefault((Assembly x) => x.FullName == planetModifierAssembly.AssemblyName);
				if (assembly == null)
				{
					Debug.LogError("Mod '" + mod.ModInfo.Name + "' contains planet modifiers in assembly '" + planetModifierAssembly.AssemblyName + "' but the loaded assembly could not be found.");
				}
				else
				{
					PlanetModifier.Register(assembly, mod);
				}
			}
		}

		private void LoadModParts(LoadedMod mod, List<ModPartInfo> parts)
		{
			List<string> list = new List<string>();
			foreach (ModPartInfo part in parts)
			{
				try
				{
					TextAsset textAsset = mod.ResourceLoader.LoadAsset<TextAsset>(part.XmlPath);
					if (textAsset == null)
					{
						Debug.LogErrorFormat("Unable to load XML for mod part '{0}' from mod '{1}", part.Id, mod.ModInfo.Name);
					}
					else
					{
						list.Add(textAsset.text);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred loading part '" + (part.Id ?? string.Empty) + "' from mod '" + mod.ModInfo.Name + "'.");
				}
			}
			try
			{
				PartLoader.LoadParts(list, mod);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				Debug.LogError("An error occurred loading parts from mod '" + mod.ModInfo.Name + "'.");
			}
			if (list.Count > 0)
			{
				PartViewerScript.RegeneratePartIcons = true;
			}
		}

		private void LoadModPartStyleExtensions(LoadedMod mod, TextAsset partStyleExtensions)
		{
			if (partStyleExtensions == null)
			{
				return;
			}
			string text = partStyleExtensions.text;
			try
			{
				Game.Instance.PartStyleManager.LoadPartStyleExtensions(text);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("An error occurred loading part style extensions from mod '" + mod.ModInfo.Name + "'.");
			}
		}

		private void LoadModPartTextureStyles(LoadedMod mod, TextAsset partTextureStyles)
		{
			if (partTextureStyles == null)
			{
				return;
			}
			string text = partTextureStyles.text;
			try
			{
				Game.Instance.PartStyleManager.LoadTextureStyles(text, mod);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("An error occurred loading part texture styles from mod '" + mod.ModInfo.Name + "'.");
			}
		}

		private void LoadModPropulsionData(ILoadedMod mod, TextAsset propulsionDataXml)
		{
			if (propulsionDataXml == null)
			{
				return;
			}
			try
			{
				Game.Instance.PropulsionData.LoadXml(propulsionDataXml.text, mod);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("An error occurred loading propulsion data XML from mod '" + mod.ModInfo.Name + "'.");
			}
		}

		private void LoadModUIResourceDatabases(LoadedMod mod, ModManifestData manifestData)
		{
			XmlLayoutResourceDatabase instance = XmlLayoutResourceDatabase.instance;
			foreach (var uIResourceDatabase in manifestData.UIResourceDatabases)
			{
				try
				{
					XmlLayoutCustomResourceDatabase xmlLayoutCustomResourceDatabase = mod.ResourceLoader.LoadAsset<XmlLayoutCustomResourceDatabase>(uIResourceDatabase.AssetPath);
					if (xmlLayoutCustomResourceDatabase == null)
					{
						Debug.LogError("Unable to find UI resource database '" + (uIResourceDatabase.AssetPath ?? string.Empty) + "' in mod '" + mod.ModInfo.Name + "'.");
					}
					else
					{
						xmlLayoutCustomResourceDatabase.AutomaticallyRemoveEntries = false;
						xmlLayoutCustomResourceDatabase.MonitorContainingFolder = false;
						xmlLayoutCustomResourceDatabase.folders.Clear();
						if (uIResourceDatabase.IsOverride)
						{
							instance.ApplyOverrideDatabase(mod.ModInfo.Name, xmlLayoutCustomResourceDatabase);
						}
						else
						{
							instance.RegisterCustomResourceDatabase(xmlLayoutCustomResourceDatabase);
						}
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred loading UI resource database '" + (uIResourceDatabase.AssetPath ?? string.Empty) + "' from mod '" + mod.ModInfo.Name + "'.");
				}
			}
		}

		private void ModApiVersionMismatch(object sender, ApiVersionMismatchEventArgs e)
		{
			string message = $"API version mismatch detected for mod '{e.Mod.Name}'. The '{e.ApiName}' API current version is '{e.CurrentApiVersion}' but the mod was built with version '{e.ModApiVersion}'.";
			ModManager.ModLoadWarnings.Add(new ModLoadMessage(e.Mod, message));
			_apiVersionMismatchMods.Add(e.Mod);
		}

		private void ModLoaded(object sender, ModLoadedEventArgs e)
		{
			foreach (PersistentObjectInfo persistentGameObject in e.ManifestData.PersistentGameObjects)
			{
				GameObject gameObject = e.Mod.ResourceLoader.LoadAsset<GameObject>(persistentGameObject.Path);
				if (gameObject == null)
				{
					Debug.LogError("Unable to load persistent object '" + persistentGameObject.Path + "' from mod '" + e.Mod.ModInfo.Name + "'.");
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate(gameObject);
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
			}
			LoadModPropulsionData(e.Mod, e.ManifestData.PropulsionData);
			LoadModPartCategories(e.ManifestData.PartCategories);
			LoadModPartTextureStyles(e.Mod, e.ManifestData.PartTextureStyles);
			LoadModPartStyleExtensions(e.Mod, e.ManifestData.PartStyleExtensions);
			LoadModPartModifiers(e.Mod, e.ManifestData);
			LoadModPlanetModifiers(e.Mod, e.ManifestData);
			LoadModParts(e.Mod, e.ManifestData.Parts);
			LoadModUIResourceDatabases(e.Mod, e.ManifestData);
		}
	}
}
