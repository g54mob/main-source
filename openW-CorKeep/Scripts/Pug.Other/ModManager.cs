using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using I2.Loc;
using ModIO;
using Pug.RP;
using Pug.UnityExtensions;
using PugMod;
using PugMods;
using Sentry;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ModManager : ManagerBase
{
	[Tooltip("Contains all official customization")]
	[SerializeField]
	private LanguageSourceAsset i2DefaultSource;

	[Tooltip("Empty source asset which is filled with custom localization during runtime")]
	[SerializeField]
	private LanguageSourceAsset i2CustomSource;

	[SerializeField]
	private FactionsLookUp factionsLookUp;

	[SerializeField]
	private LootTableBank lootTableBank;

	[SerializeField]
	private FishingTable fishingTable;

	[SerializeField]
	private EnvironmentSpawnObjectsTable spawnTable;

	[SerializeField]
	private SkillTalentsTable skillTalentsTable;

	[SerializeField]
	private AssetReferenceGameObject modioBrowserPrefab;

	public ObjectIDCategory ModObjectsCategory;

	public List<IModPlatform> ModPlatforms = new List<IModPlatform>();

	private bool _pendingQuit;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("ModManager.Init");

	public BooleanMatrix FactionsLookupMatrix { get; private set; }

	public List<LootTable> LootTable { get; private set; }

	public FishingTable FishingTable { get; private set; }

	public EnvironmentSpawnObjectsTable SpawnTable { get; private set; }

	public SkillTalentsTable SkillTalentsTable { get; private set; }

	public List<MonoBehaviour> ExtraAuthoring => Authoring.ExtraAuthoring;

	public ModAPIRendering Rendering { get; private set; }

	public ModAPIClient Client { get; private set; }

	public ModAPIServer Server { get; private set; }

	public ModAPIAuthoring Authoring { get; private set; }

	public static void EarlyInit()
	{
		Integration.Instance.AssetProcessor += delegate(object asset)
		{
			if (asset is GameObject gameObject && gameObject.GetComponent(typeof(IEntityMonoBehaviourData)) != null)
			{
				API.Authoring.RegisterAuthoringGameObject(gameObject);
			}
			else if (asset is ObjectIDCategory objectIDCategory)
			{
				ObjectIDCategoryManager.Add(objectIDCategory);
			}
		};
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			Addressables.InstantiateAsync(modioBrowserPrefab, base.transform);
			API.Effects = Manager.effects;
			API.Audio = Manager.audio;
			API.Input = Manager.input;
			Rendering = API.Rendering as ModAPIRendering;
			Client = API.Client as ModAPIClient;
			Server = API.Server as ModAPIServer;
			Authoring = API.Authoring as ModAPIAuthoring;
			Manager.wantsToQuit += WantsToQuitHandler;
			SentrySdk.ConfigureScope(delegate(Scope scope)
			{
				scope.SetTag("PugMod.UsingMods", Integration.Instance.LoadedMods.Any() ? "true" : "false");
			});
			foreach (LoadedMod loadedMod in Integration.Instance.LoadedMods)
			{
				string directory = Loader.Instance.GetDirectory(loadedMod.ModId);
				if (!string.IsNullOrEmpty(directory))
				{
					Debug.Log($"Loading mod with ID {loadedMod.ModId}");
					string text = Path.Combine(directory, "Conf");
					if (Directory.Exists(text))
					{
						Config.ConfFolders.Add(text);
					}
					string text2 = Path.Combine(directory, "Localization");
					if (Directory.Exists(text2))
					{
						Config.LocalizationFolders.Add(text2);
					}
				}
			}
			foreach (string item in CommandLineArgs.EnumerateParams("-confdir"))
			{
				Config.ConfFolders.Add(item);
			}
			if (CommandLineArgs.Has("-extralog"))
			{
				Config.ExtraLog = true;
			}
			bool num = CommandLineArgs.Has("-safemode");
			if (num)
			{
				Config.ConfFolders.Clear();
			}
			if (!num)
			{
				LocalizationManager.InitializeIfNeeded();
				if (LocalizationManager.Sources.Count < 2)
				{
					Debug.LogError("I2 sources not loaded");
					return false;
				}
				string text3 = Application.streamingAssetsPath + "/Textures/ColorGrading.png";
				if (File.Exists(text3))
				{
					try
					{
						Texture2D texture2D = new Texture2D(1024, 32, TextureFormat.ARGB32, mipChain: false, linear: true);
						if (texture2D.LoadImage(File.ReadAllBytes(text3)))
						{
							if (texture2D.width == 1024 && texture2D.height == 32)
							{
								Manager.camera.gameCamera.GetComponent<PugCamera>().outputColorLookup = texture2D;
								Debug.Log("using color lookup at " + text3);
							}
							else
							{
								Debug.LogError($"{text3} has wrong size, should be {1024}x{32}");
							}
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				LanguageSourceData languageSourceData = LocalizationManager.Sources[0];
				LanguageSourceData defaultLanguageSource = LocalizationManager.Sources[1];
				languageSourceData.ClearAllData();
				Localization.ImportAndUpdateCustomCsv(languageSourceData, Localization.CustomCsvFilePath);
				foreach (string localizationFolder in Config.LocalizationFolders)
				{
					string text4 = Path.Combine(localizationFolder, "Localization.csv");
					if (File.Exists(text4))
					{
						Localization.ImportAndUpdateExtraCustomCsv(languageSourceData, text4);
					}
				}
				if (Localization.PostInit(languageSourceData, defaultLanguageSource))
				{
					Localization.CreateCsv(languageSourceData, Localization.CustomCsvFilePath);
				}
			}
			FactionsLookupMatrix = new BooleanMatrix(factionsLookUp.factionMatrix.Length);
			for (int num2 = 0; num2 < FactionsLookupMatrix.Length; num2++)
			{
				for (int num3 = 0; num3 < FactionsLookupMatrix.Length; num3++)
				{
					FactionsLookupMatrix[num3, num2] = factionsLookUp.factionMatrix[num3, num2];
				}
			}
			Factions.Init(FactionsLookupMatrix);
			LootTableBank lootTableBank = ScriptableObject.CreateInstance<LootTableBank>();
			JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(this.lootTableBank), lootTableBank);
			PugMods.LootTable.Init(lootTableBank);
			LootTable = lootTableBank.biomeLootTables[0].lootTables;
			UnityEngine.Object.Destroy(lootTableBank);
			FishingTable = ScriptableObject.CreateInstance<FishingTable>();
			JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(fishingTable), FishingTable);
			Fishing.Init(FishingTable);
			FishingTable.Init();
			SpawnTable = ScriptableObject.CreateInstance<EnvironmentSpawnObjectsTable>();
			JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(spawnTable), SpawnTable);
			PugMods.SpawnTable.Init(SpawnTable);
			SkillTalentsTable = ScriptableObject.CreateInstance<SkillTalentsTable>();
			JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(skillTalentsTable), SkillTalentsTable);
			Talents.Init(SkillTalentsTable);
			if (ModObjectsCategory != null)
			{
				foreach (MonoBehaviour item2 in ExtraAuthoring)
				{
					if (item2 is IEntityMonoBehaviourData entityMonoBehaviourData)
					{
						ModObjectsCategory.Add(entityMonoBehaviourData.ObjectInfo.objectID);
					}
				}
			}
			return true;
		}
	}

	public bool CheckForModChanges(bool restartIfNeeded, bool forceRestart)
	{
		HashSet<long> hashSet = new HashSet<long>();
		HashSet<long> hashSet2 = new HashSet<long>();
		foreach (Loader.Mod mod in Loader.Instance.Mods)
		{
			if (mod.ModId > 0)
			{
				hashSet.Add(mod.ModId);
			}
		}
		Result result;
		SubscribedMod[] subscribedMods = ModIOUnity.GetSubscribedMods(out result);
		if (!result.Succeeded())
		{
			return false;
		}
		bool flag = false;
		hashSet2.Clear();
		SubscribedMod[] array = subscribedMods;
		for (int i = 0; i < array.Length; i++)
		{
			SubscribedMod subscribedMod = array[i];
			if (!subscribedMod.enabled || subscribedMod.status != SubscribedModStatus.Installed)
			{
				continue;
			}
			if (!hashSet.Contains(subscribedMod.modProfile.id))
			{
				flag = true;
				string[] tags = subscribedMod.modProfile.tags;
				for (int j = 0; j < tags.Length; j++)
				{
					if (tags[j].Equals("Script (Elevated Access)"))
					{
						hashSet2.Add(subscribedMod.modProfile.id);
						break;
					}
				}
			}
			hashSet.Remove(subscribedMod.modProfile.id);
		}
		flag |= hashSet.Count != 0;
		if (restartIfNeeded && hashSet2.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (long item in hashSet2)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(' ');
					stringBuilder.Append('|');
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(item);
			}
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ModsAddedWithEnhancedAccess", new string[1] { stringBuilder.ToString() }, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
				Invoke("RestartToApplyModChanges", 0.1f);
			}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
		}
		else if ((restartIfNeeded && flag) || forceRestart)
		{
			RestartToApplyModChanges(forceRestart);
		}
		return flag;
	}

	private void RestartToApplyModChanges()
	{
		RestartToApplyModChanges(disableUserChoice: false);
	}

	private void RestartToApplyModChanges(bool disableUserChoice)
	{
		string text = (disableUserChoice ? "Menu/RestartPendingModChanges" : "Menu/RestartToApplyModChanges");
		Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
		{
			if (disableUserChoice || response.IsConfirm)
			{
				Debug.Log("Restarting to update mod list");
				Manager.platform.Restart();
			}
		}, new List<string> { "cancelDialogue", "yes" }, 10f, 0.8f, 0, 20f);
	}

	private bool WantsToQuitHandler()
	{
		if (ModIOUnity.IsInitialized())
		{
			Debug.Log("waiting for ModIO shutdown");
			ModIOUnity.Shutdown(delegate
			{
				_pendingQuit = true;
			});
			return false;
		}
		return true;
	}

	private void Update()
	{
		if (_pendingQuit)
		{
			_pendingQuit = false;
			Manager.QuitGame();
		}
		Integration.Instance.Update();
	}
}
