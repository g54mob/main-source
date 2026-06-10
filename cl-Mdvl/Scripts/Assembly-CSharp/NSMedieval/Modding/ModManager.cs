using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Tools;
using NSMedieval.UI;
using Steamworks;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class ModManager : MonoSingleton<ModManager>
	{
		private readonly List<ModInstance> instanceCache = new List<ModInstance>();

		private List<ulong> workshopSubscribedIds = new List<ulong>();

		private bool isInitialized;

		[SerializeField]
		private float initDelay = 1f;

		private float delayTimer;

		public Dictionary<ModTag, Dictionary<string, ModInstance>> ModsByTag { get; } = new Dictionary<ModTag, Dictionary<string, ModInstance>>();

		public Dictionary<string, ModInstance> DisabledMods { get; } = new Dictionary<string, ModInstance>();

		public Dictionary<string, ModInstance> EnabledMods { get; } = new Dictionary<string, ModInstance>();

		public Dictionary<string, ScenarioModInstance> ScenarioMods { get; } = new Dictionary<string, ScenarioModInstance>();

		public Dictionary<string, LocalizationModInstance> LocalizationMods { get; } = new Dictionary<string, LocalizationModInstance>();

		public event Action ModsChangedEvent;

		private void OnEnable()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.OnWorkshopItemsUpdatedEvent += UpdateWorkshopItems;
			MonoSingleton<SteamWorkshopManager>.Instance.WorkshopAuthorCheckEvent += UpdateModAuthorshipInfo;
		}

		private void OnDisable()
		{
			if (MonoSingleton<SteamWorkshopManager>.IsInstantiated())
			{
				MonoSingleton<SteamWorkshopManager>.Instance.OnWorkshopItemsUpdatedEvent -= UpdateWorkshopItems;
				MonoSingleton<SteamWorkshopManager>.Instance.WorkshopAuthorCheckEvent -= UpdateModAuthorshipInfo;
			}
		}

		public IEnumerable<ModInstance> GetAllGeneralMods()
		{
			return DisabledMods.Values.Union(EnabledMods.Values);
		}

		private IEnumerable<ModInstance> GetAllMods()
		{
			return GetAllGeneralMods().Union(ScenarioMods.Values).Union(LocalizationMods.Values);
		}

		public IEnumerable<string> GetAllModNames()
		{
			List<string> list = new List<string>();
			foreach (string key in EnabledMods.Keys)
			{
				list.Add(key);
			}
			foreach (string key2 in DisabledMods.Keys)
			{
				list.Add(key2);
			}
			return list;
		}

		public ModInstance GetModInstance(string modId)
		{
			if (DisabledMods.TryGetValue(modId, out var value))
			{
				return value;
			}
			if (EnabledMods.TryGetValue(modId, out var value2))
			{
				return value2;
			}
			if (ScenarioMods.TryGetValue(modId, out var value3))
			{
				return value3;
			}
			if (LocalizationMods.TryGetValue(modId, out var value4))
			{
				return value4;
			}
			return null;
		}

		public void DeleteMod(string modID)
		{
			ModInstance modInstance = GetModInstance(modID);
			bool isEnabled;
			if (modInstance == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Mod Instance ");
					messageBuilder.AppendFormatted(modID);
					messageBuilder.AppendLiteral(" is null.");
				}
				Log.Error(messageBuilder);
				return;
			}
			string rootFolderPath = modInstance.RootFolderPath;
			if (!Directory.Exists(rootFolderPath))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error deleting mod \"");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(rootFolderPath));
					messageBuilder.AppendLiteral("\". Directory not found.");
				}
				Log.Error(messageBuilder);
				return;
			}
			RemoveFromList(modInstance);
			this.ModsChangedEvent?.Invoke();
			modInstance.Dispose();
			try
			{
				Directory.Delete(rootFolderPath, recursive: true);
			}
			catch (Exception ex)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error deleting mod \"");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(rootFolderPath));
					messageBuilder.AppendLiteral("\". Error message: ");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Error(messageBuilder);
			}
		}

		private void RemoveFromList(ModInstance instance)
		{
			if (instance.Tag.HasFlag(ModTag.Scenario))
			{
				ScenarioMods.Remove(instance.SystemId);
			}
			else if (instance.Tag.HasFlag(ModTag.Localization))
			{
				LocalizationMods.Remove(instance.SystemId);
			}
			else if (instance.IsEnabled)
			{
				EnabledMods.Remove(instance.SystemId);
			}
			else
			{
				DisabledMods.Remove(instance.SystemId);
			}
		}

		public bool GetScenarioModInstance(string scenarioID, out ScenarioModInstance scenarioModInstance)
		{
			scenarioModInstance = null;
			if (ScenarioMods.TryGetValue(scenarioID, out var value))
			{
				scenarioModInstance = value;
				return true;
			}
			using (IEnumerator<string> enumerator = ScenarioMods.Keys.Where((string key) => key.Contains(scenarioID.ToLower().TrimEnd().TrimStart())).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					scenarioModInstance = ScenarioMods[current];
					return true;
				}
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(81, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Mod instance not found for scenario: ");
				messageBuilder.AppendFormatted(scenarioID);
				messageBuilder.AppendLiteral(". Check if the mod exists and if id's match.");
			}
			Log.Error(messageBuilder);
			return false;
		}

		public bool IsWorkshopModEnabled(ulong publishedFileId)
		{
			foreach (ModInstance value in EnabledMods.Values)
			{
				if (value.WorkshopPublishedFileId == publishedFileId)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsModEnabled(string modId)
		{
			return EnabledMods.ContainsKey(modId);
		}

		public void SetModEnabled(string modId, bool enable)
		{
			bool isEnabled;
			ModInstance value2;
			if (enable)
			{
				if (!DisabledMods.Remove(modId, out var value))
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Something went wrong. Mod ");
						messageBuilder.AppendFormatted(modId);
						messageBuilder.AppendLiteral(" is not in the inactive mods list.");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					EnabledMods.Add(modId, value);
					value.SetEnabled(enabled: true);
					this.ModsChangedEvent?.Invoke();
				}
			}
			else if (!EnabledMods.Remove(modId, out value2))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Something went wrong. Mod ");
					messageBuilder.AppendFormatted(modId);
					messageBuilder.AppendLiteral(" is not in the active mods list.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				DisabledMods.Add(modId, value2);
				value2.SetEnabled(enabled: false);
				this.ModsChangedEvent?.Invoke();
			}
		}

		public void OnEditComplete()
		{
			MonoSingleton<OptionsController>.Instance.SaveModSettings(GetAllGeneralMods());
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(MonoSingleton<GlobalSaveController>.Instance.Serialize);
		}

		public void Initialize()
		{
			ModdingUtils.CheckScenariosConversion();
			InitLocal();
			isInitialized = true;
			Log.Trace("ModManager initialized.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
		}

		private void InitLocal()
		{
			if (!ModdingUtils.RootFolderAccessible())
			{
				return;
			}
			Log.Trace("InitLocal()", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
			string rootDirectoryPath = ModdingUtils.GetRootDirectoryPath();
			if (string.IsNullOrEmpty(rootDirectoryPath))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("error_create_directory");
				return;
			}
			string[] directories = Directory.GetDirectories(rootDirectoryPath);
			foreach (string dirPath in directories)
			{
				RegisterNewInstance(dirPath);
			}
		}

		public void RegisterNewInstance(string dirPath)
		{
			RegisterInstance(CreateInstance(dirPath, ModSource.Local));
		}

		private void RegisterInstance(ModInstance modInstance)
		{
			if (modInstance == null)
			{
				return;
			}
			bool isEnabled;
			if (modInstance is LocalizationModInstance localizationModInstance)
			{
				FVLogDebugInterpolationHandler messageBuilder;
				if (!LocalizationMods.TryAdd(localizationModInstance.SystemId, localizationModInstance))
				{
					messageBuilder = new FVLogDebugInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Mod ");
						messageBuilder.AppendFormatted(localizationModInstance.ModModel.Id);
						messageBuilder.AppendLiteral(" is already in the enabled mods list.");
					}
					Log.Debug(messageBuilder);
					return;
				}
				messageBuilder = new FVLogDebugInterpolationHandler(33, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Registered ModInstance (");
					messageBuilder.AppendFormatted(localizationModInstance.SystemId);
					messageBuilder.AppendLiteral("): ");
					messageBuilder.AppendFormatted(localizationModInstance.ModModel.Name);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(localizationModInstance.Source);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(localizationModInstance.ModModel.Tags);
				}
				Log.Debug(messageBuilder);
			}
			else if (modInstance is ScenarioModInstance scenarioModInstance)
			{
				FVLogDebugInterpolationHandler messageBuilder;
				if (!ScenarioMods.TryAdd(scenarioModInstance.SystemId, scenarioModInstance))
				{
					messageBuilder = new FVLogDebugInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Mod ");
						messageBuilder.AppendFormatted(scenarioModInstance.ModModel.Id);
						messageBuilder.AppendLiteral(" is already in the enabled mods list.");
					}
					Log.Debug(messageBuilder);
					return;
				}
				messageBuilder = new FVLogDebugInterpolationHandler(33, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Registered ModInstance (");
					messageBuilder.AppendFormatted(scenarioModInstance.SystemId);
					messageBuilder.AppendLiteral("): ");
					messageBuilder.AppendFormatted(scenarioModInstance.ModModel.Name);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(scenarioModInstance.Source);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(scenarioModInstance.ModModel.Tags);
				}
				Log.Debug(messageBuilder);
			}
			else if (modInstance.IsEnabled)
			{
				FVLogDebugInterpolationHandler messageBuilder;
				if (!EnabledMods.TryAdd(modInstance.SystemId, modInstance))
				{
					messageBuilder = new FVLogDebugInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Mod ");
						messageBuilder.AppendFormatted(modInstance.SystemId);
						messageBuilder.AppendLiteral(" is already in the enabled mods list.");
					}
					Log.Debug(messageBuilder);
					return;
				}
				messageBuilder = new FVLogDebugInterpolationHandler(33, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Registered ModInstance (");
					messageBuilder.AppendFormatted(modInstance.SystemId);
					messageBuilder.AppendLiteral("): ");
					messageBuilder.AppendFormatted(modInstance.ModModel.Name);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(modInstance.Source);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(modInstance.ModModel.Tags);
				}
				Log.Debug(messageBuilder);
			}
			else if (!DisabledMods.TryAdd(modInstance.SystemId, modInstance))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Mod ");
					messageBuilder.AppendFormatted(modInstance.SystemId);
					messageBuilder.AppendLiteral(" is already in the enabled mods list. Skipping");
				}
				Log.Debug(messageBuilder);
			}
			else
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(33, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Registered ModInstance (");
					messageBuilder.AppendFormatted(modInstance.SystemId);
					messageBuilder.AppendLiteral("): ");
					messageBuilder.AppendFormatted(modInstance.ModModel.Name);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(modInstance.Source);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(modInstance.ModModel.Tags);
				}
				Log.Debug(messageBuilder);
			}
		}

		private ModInstance CreateInstance(string dirPath, ModSource source)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating instance from directory: ");
				messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(dirPath));
			}
			Log.Debug(messageBuilder);
			string path = Path.Combine(dirPath, "ModInfo.json");
			if (!File.Exists(path))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("No ModInfo.json file at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Error(messageBuilder2);
				return null;
			}
			string text;
			try
			{
				text = FileUtils.SafeReadAllText(path);
			}
			catch (Exception ex)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Cannot read ModInfo.json file at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
					messageBuilder2.AppendLiteral(".\nException: ");
					messageBuilder2.AppendFormatted(ex.ToString());
				}
				Log.Error(messageBuilder2);
				return null;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("ModInfo.json is empty at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Error(messageBuilder2);
				return null;
			}
			ModModel modModel;
			try
			{
				modModel = JsonUtility.FromJson<ModModel>(text);
			}
			catch (Exception ex2)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(55, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("ModInfo.json could not be parsed at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
					messageBuilder2.AppendLiteral(".\nException: ");
					messageBuilder2.AppendFormatted(ex2.ToString());
				}
				Log.Error(messageBuilder2);
				return null;
			}
			string id;
			try
			{
				id = modModel.Id;
			}
			catch (Exception)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("id is not defined in ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Error(messageBuilder2);
				return null;
			}
			if (modModel == null)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("ModInfo.json could not be read as ModModel at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Error(messageBuilder2);
				return null;
			}
			if (modModel.IdIsNullOrEmpty)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("ModModel.Id is null or empty at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Error(messageBuilder2);
				return null;
			}
			if (ModExists(id, source))
			{
				return null;
			}
			string previewModImagePath = ModdingUtils.GetPreviewModImagePath(dirPath);
			Sprite spriteFromPath = ModdingUtils.GetSpriteFromPath(previewModImagePath);
			if (spriteFromPath == null)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("No file at path: ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(previewModImagePath));
				}
				Log.Error(messageBuilder2);
				return null;
			}
			ModInstance instance = new ModInstance(modModel, spriteFromPath, dirPath, source);
			if (modModel.GetTags().HasFlag(ModTag.Localization))
			{
				instance = new LocalizationModInstance(modModel, spriteFromPath, dirPath, source);
				SetWorkshopPublishedFileId();
				return instance;
			}
			if (modModel.GetTags().HasFlag(ModTag.Scenario))
			{
				instance = new ScenarioModInstance(modModel, spriteFromPath, dirPath, source);
				SetWorkshopPublishedFileId();
				return instance;
			}
			SetWorkshopPublishedFileId();
			ModSaveSetting modSaveSetting = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ModSaveSettings.Find((ModSaveSetting ms) => ms.Id.Equals(instance.SystemId));
			if (modSaveSetting != null)
			{
				instance.SetEnabled(modSaveSetting.Enabled);
			}
			return instance;
			void SetWorkshopPublishedFileId()
			{
				if (File.Exists(Path.Combine(dirPath, "WorkshopId.json")))
				{
					PublishedFileId_t publishedFileId_t = JsonUtility.FromJson<PublishedFileId_t>(File.ReadAllText(Path.Combine(dirPath, "WorkshopId.json")));
					if (publishedFileId_t.m_PublishedFileId != 0L)
					{
						instance.SetWorkshopPublishedFileId(publishedFileId_t.m_PublishedFileId);
					}
				}
			}
		}

		private bool ModExists(string modelId, ModSource source)
		{
			foreach (ModInstance allGeneralMod in GetAllGeneralMods())
			{
				if (allGeneralMod.ModModel.Id == modelId && allGeneralMod.Source == source)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(44, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Mod with id ");
						messageBuilder.AppendFormatted(modelId);
						messageBuilder.AppendLiteral(" from ");
						messageBuilder.AppendFormatted(source);
						messageBuilder.AppendLiteral(" already exists. Skipping.");
					}
					Log.Error(messageBuilder);
					isEnabled = true;
					return isEnabled;
				}
			}
			return false;
		}

		public List<string> GetJsonMods(string jsonPath)
		{
			List<string> list = new List<string>();
			foreach (ModInstance value2 in EnabledMods.Values)
			{
				if (value2.DataModels.TryGetValue(jsonPath, out var value))
				{
					list.Add(value);
				}
			}
			return list;
		}

		public bool TextureExists(string textureId)
		{
			foreach (ModInstance value in EnabledMods.Values)
			{
				if (value.Textures.ContainsKey(textureId))
				{
					return true;
				}
			}
			return false;
		}

		public Texture2D GetTexture(string textureId)
		{
			foreach (ModInstance value2 in EnabledMods.Values)
			{
				if (value2.Textures.TryGetValue(textureId, out var value))
				{
					return value;
				}
			}
			return null;
		}

		public bool TryGetSprite(string spriteId, out Sprite sprite)
		{
			sprite = null;
			foreach (ModInstance value2 in EnabledMods.Values)
			{
				if (value2.Sprites.TryGetValue(spriteId, out var value))
				{
					sprite = value;
					return true;
				}
			}
			return false;
		}

		public List<string> GetEnabledMods()
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, ModInstance> enabledMod in EnabledMods)
			{
				list.Add(enabledMod.Value.ModModel.Name);
			}
			return list;
		}

		private void UpdateWorkshopItems()
		{
			instanceCache.Clear();
			instanceCache.AddRange(GetAllMods());
			if (MonoSingleton<SteamWorkshopManager>.Instance.PublishedIdPathDictionary == null || MonoSingleton<SteamWorkshopManager>.Instance.PublishedIdPathDictionary.Count == 0)
			{
				workshopSubscribedIds.Clear();
				bool flag = false;
				foreach (ModInstance item in instanceCache)
				{
					if (item.Source == ModSource.Workshop)
					{
						flag = true;
						if (item.IsEnabled)
						{
							EnabledMods.Remove(item.SystemId);
						}
						else
						{
							DisabledMods.Remove(item.SystemId);
						}
					}
				}
				if (flag)
				{
					this.ModsChangedEvent?.Invoke();
				}
				return;
			}
			bool isEnabled;
			foreach (ulong workshopSubscribedId in workshopSubscribedIds)
			{
				if (MonoSingleton<SteamWorkshopManager>.Instance.PublishedIdPathDictionary.Keys.Contains(workshopSubscribedId))
				{
					continue;
				}
				foreach (ModInstance item2 in instanceCache)
				{
					if (item2.WorkshopPublishedFileId == workshopSubscribedId)
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(34, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Removing ModInstance (");
							messageBuilder.AppendFormatted(item2.SystemId);
							messageBuilder.AppendLiteral("): ");
							messageBuilder.AppendFormatted(item2.ModModel.Name);
							messageBuilder.AppendLiteral(" - ");
							messageBuilder.AppendFormatted(item2.Source);
							messageBuilder.AppendLiteral(" - ");
							messageBuilder.AppendFormatted(item2.ModModel.GameVersion);
							messageBuilder.AppendLiteral(" - ");
							messageBuilder.AppendFormatted(item2.ModModel.Author);
						}
						Log.Debug(messageBuilder);
						RemoveFromList(item2);
					}
				}
			}
			foreach (var (num2, text2) in MonoSingleton<SteamWorkshopManager>.Instance.PublishedIdPathDictionary)
			{
				if (workshopSubscribedIds.Contains(num2))
				{
					continue;
				}
				ModInstance modInstance = CreateInstance(text2, ModSource.Workshop);
				if (modInstance == null)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Could not create ModInstance from path: ");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(text2));
					}
					Log.Error(messageBuilder2);
				}
				else
				{
					modInstance.SetWorkshopPublishedFileId(num2);
					RegisterInstance(modInstance);
				}
			}
			workshopSubscribedIds = MonoSingleton<SteamWorkshopManager>.Instance.PublishedIdPathDictionary.Keys.ToList();
			this.ModsChangedEvent?.Invoke();
		}

		private void UpdateModAuthorshipInfo()
		{
			Log.Trace(" ==== Updating Mod Authorship Info", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ModManager.cs");
			PublishedFileId_t[] publisherFileIds = (from modInstance in GetAllMods()
				where modInstance.Source == ModSource.Local && modInstance.WorkshopPublishedFileId != 0
				select new PublishedFileId_t(modInstance.WorkshopPublishedFileId)).ToArray();
			MonoSingleton<SteamWorkshopManager>.Instance.RunWorkshopItemAuthorQuery(publisherFileIds);
		}
	}
}
