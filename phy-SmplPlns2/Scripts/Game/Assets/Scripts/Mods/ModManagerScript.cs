using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods.Events;
using Assets.Scripts.Settings;
using Assets.Scripts.Storage;
using Jundroo.Common.Platform;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Steam;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public class ModManagerScript : MonoBehaviour
	{
		private List<ModInfo> _apiVersionMismatchMods;

		private ModManager _modManager;

		public bool HasModSupport { get; private set; }

		public IModManager ModManager => _modManager;

		public static ModManagerScript Create(GameObject parent)
		{
			ModManagerScript modManagerScript = new GameObject("ModManager").AddComponent<ModManagerScript>();
			modManagerScript.transform.SetParent(parent.transform);
			return modManagerScript;
		}

		public void LoadExternalModFile(string modFilePath)
		{
			Assets.Scripts.Mods.ModManager.DecompressMod(CopyModFileToModDirectory(modFilePath).FullName);
			ModManager.ScanForMods(GameData.Mods.ModsPath, recursive: false, createIfNotFound: false);
			TodoException<ModManagerScript>.LogOnce("Immediately open the mods dialog");
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
					FileInfo fileInfo2 = new FileInfo(Path.Combine(GameData.Mods.ModsPath, fileInfo.Name));
					if (fileInfo.FullName == fileInfo2.FullName)
					{
						return fileInfo2;
					}
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
			ApplicationSettings settings = Game.Instance.Settings.App;
			_apiVersionMismatchMods = new List<ModInfo>();
			_modManager = (ModManager)Assets.Scripts.Mods.ModManager.Instance;
			HasModSupport = !Device.IsMobileBuild;
			if (!HasModSupport || !settings.ModSupportEnabled)
			{
				return;
			}
			_modManager.DecompressMods(GameData.Mods.ModsPath, recursive: true);
			_modManager.ScanForMods(GameData.Mods.ModsPath, recursive: true, createIfNotFound: true);
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
			_modManager.SaveModLoadLog(GameData.GetPath("ModLoadLog.txt"));
		}

		private void LoadModLevels(LoadedMod mod, ModManifestData manifestData)
		{
			foreach (ModLevelInfo level in manifestData.Levels)
			{
				if (level.SupportedPlatform == LevelSupportedPlatforms.All || ((level.SupportedPlatform != LevelSupportedPlatforms.Standalone || !Game.Instance.Device.IsMobileBuild) && (level.SupportedPlatform != LevelSupportedPlatforms.Mobile || Game.Instance.Device.IsMobileBuild)))
				{
					Game.Instance.LevelDatabase.ModLevels.Add(new LevelInfo
					{
						Id = manifestData.ModInfo.Name + " - " + level.Name,
						Name = level.Name,
						MapName = level.MapName,
						ModName = level.Mod.Name,
						Description = level.Description,
						Prefab = level.LevelTypeName,
						SkipDesigner = false
					});
				}
			}
		}

		private void LoadModMaps(LoadedMod mod, ModManifestData manifestData)
		{
			LevelInfo levelInfo = Game.Instance.LevelDatabase.Levels.Single((LevelInfo x) => x.Id == "LevelSandbox");
			foreach (MapInfo item in manifestData.Maps.Where((MapInfo x) => x.AllowSandbox))
			{
				Game.Instance.LevelDatabase.ModLevels.Add(new LevelInfo
				{
					Id = "LevelSandbox_" + manifestData.ModInfo.Name + " - " + item.Name,
					Name = item.Name,
					MapName = item.Name,
					ModName = item.Mod.Name,
					Description = (string.IsNullOrEmpty(item.Description) ? levelInfo.Description : item.Description),
					Prefab = levelInfo.Prefab,
					SkipDesigner = false
				});
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
			LoadPersistentObjects(e.Mod, e.ManifestData);
			LoadModMaps(e.Mod, e.ManifestData);
			LoadModLevels(e.Mod, e.ManifestData);
			Game.Instance.LevelDatabase.Rebuild();
		}

		private void LoadPersistentObjects(LoadedMod mod, ModManifestData manifestData)
		{
			foreach (PersistentObjectInfo persistentGameObject in manifestData.PersistentGameObjects)
			{
				GameObject gameObject = mod.ResourceLoader.LoadAsset<GameObject>(persistentGameObject.Path);
				if (gameObject == null)
				{
					Debug.LogError("Unable to load persistent object '" + persistentGameObject.Path + "' from mod '" + mod.ModInfo.Name + "'.");
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate(gameObject);
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
			}
		}
	}
}
