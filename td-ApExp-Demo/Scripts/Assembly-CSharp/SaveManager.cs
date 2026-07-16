using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	private List<ISaveable> saveables;

	private SaveSerializer metaSaveSerializer;

	private SaveSerializer journeySaveSerializer;

	private SaveSerializer settingsSaveSerializer;

	private SaveDataContext saveDataContext;

	[NonSerialized]
	public bool ShouldSaveJourney;

	[NonSerialized]
	public bool JourneySavedOnLevelStart;

	[SerializeField]
	private string metaFilename = "meta.sav";

	[SerializeField]
	private string journeyFilename = "journey.sav";

	[SerializeField]
	private string settingsFilename = "settings.sav";

	[NonSerialized]
	public bool isReadyToSaveStats;

	public bool JourneySaveBlocked;

	public static SaveManager Instance { get; private set; }

	[field: NonSerialized]
	public MetaSavefile metaSavefile { get; private set; }

	[field: NonSerialized]
	public JourneySavefile journeySavefile { get; private set; }

	[field: NonSerialized]
	public SettingsSavefile settingsSavefile { get; private set; }

	public SaveDataContext SaveDataContext => saveDataContext;

	public bool IsInitialized { get; internal set; }

	public bool ShowRoofOnEmptyWagons => settingsSavefile.ShowRoofOnEmptyWagons;

	public bool IsDataTrackingEnabled => settingsSavefile.IsDataTrackingEnabled;

	public bool ShowResourcePickupText
	{
		get
		{
			return settingsSavefile.ShowResourcePickupText;
		}
		set
		{
			settingsSavefile.ShowResourcePickupText = value;
		}
	}

	public bool ShowHullDamageText
	{
		get
		{
			return settingsSavefile.ShowHullDamageText;
		}
		set
		{
			settingsSavefile.ShowHullDamageText = value;
		}
	}

	public bool IsTutorialComplete
	{
		get
		{
			if (metaSavefile != null)
			{
				return metaSavefile.isTutorialCompleted;
			}
			return false;
		}
		set
		{
			metaSavefile.isTutorialCompleted = value;
		}
	}

	public int TotalCores
	{
		get
		{
			if (metaSavefile != null)
			{
				return int.Parse(metaSavefile.totalCores.ToString("F0"));
			}
			return 0;
		}
	}

	public bool ColectedLevelReward
	{
		get
		{
			if (journeySavefile != null)
			{
				return journeySavefile.CollectedLevelReward;
			}
			return false;
		}
		set
		{
			if (journeySavefile != null)
			{
				journeySavefile.CollectedLevelReward = value;
				Save();
			}
		}
	}

	public int WorldSeed
	{
		get
		{
			if (journeySavefile != null)
			{
				return journeySavefile.Seed;
			}
			return 0;
		}
	}

	public void SetShowRoofOnEmptyWagons(bool isiEnabled)
	{
		settingsSavefile.ShowRoofOnEmptyWagons = isiEnabled;
	}

	public void SetDataTrackingEnabled(bool isEnabled)
	{
		if (GameManager.Instance.isDemo)
		{
			settingsSavefile.IsDataTrackingEnabled = false;
		}
		else
		{
			settingsSavefile.IsDataTrackingEnabled = isEnabled;
		}
	}

	public int GetTimesWorldDialoguesPlayed(int worldIndex)
	{
		if (worldIndex >= metaSavefile.timesDialoguesPlayed.Count)
		{
			return 0;
		}
		return metaSavefile.timesDialoguesPlayed[worldIndex];
	}

	public void SetTimesDialoguesPlayed(int worldIndex, int count)
	{
		if (worldIndex >= metaSavefile.timesDialoguesPlayed.Count)
		{
			for (int i = metaSavefile.timesDialoguesPlayed.Count; i <= worldIndex; i++)
			{
				metaSavefile.timesDialoguesPlayed.Insert(metaSavefile.timesDialoguesPlayed.Count, 0);
			}
		}
		metaSavefile.timesDialoguesPlayed[worldIndex] = count;
		Save();
	}

	public void IncrementTimesDialoguesPlayed(int worldIndex)
	{
		if (worldIndex >= metaSavefile.timesDialoguesPlayed.Count)
		{
			for (int i = metaSavefile.timesDialoguesPlayed.Count; i <= worldIndex; i++)
			{
				metaSavefile.timesDialoguesPlayed.Insert(metaSavefile.timesDialoguesPlayed.Count, 0);
			}
		}
		metaSavefile.timesDialoguesPlayed[worldIndex]++;
		Save();
	}

	public Color GetP1Color()
	{
		return ColorHelper.GetColorFromHexString(settingsSavefile.P1Color);
	}

	public Color GetP2Color()
	{
		return ColorHelper.GetColorFromHexString(settingsSavefile.P2Color);
	}

	public void SetP1Color(string hexColor)
	{
		settingsSavefile.P1Color = hexColor;
		Save();
	}

	public void SetP2Color(string hexColor)
	{
		settingsSavefile.P2Color = hexColor;
		Save();
	}

	public void SetP1Color(Color color)
	{
		settingsSavefile.P1Color = ColorHelper.GetHexStringFromColor(color);
		Save();
	}

	public void SetP2Color(Color color)
	{
		settingsSavefile.P2Color = ColorHelper.GetHexStringFromColor(color);
		Save();
	}

	public float GetTrainHull()
	{
		return journeySavefile.Hull;
	}

	public bool IsWagonBought(int index)
	{
		return journeySavefile.PurchasedWagonIndexes?.Any((int i) => i == index) ?? false;
	}

	private void Awake()
	{
		Debug.Log("SaveManager Awake");
		Instance = this;
		metaSaveSerializer = new SaveSerializer(Application.persistentDataPath, metaFilename);
		journeySaveSerializer = new SaveSerializer(Application.persistentDataPath, journeyFilename);
		settingsSaveSerializer = new SaveSerializer(Application.persistentDataPath, settingsFilename);
	}

	private void Start()
	{
		metaSavefile = LoadWithVersionCheck<MetaSavefile>(metaSaveSerializer, GameManager.Instance.MinVersionMeta);
		settingsSavefile = LoadWithVersionCheck<SettingsSavefile>(settingsSaveSerializer, GameManager.Instance.MinVersionSettings);
		journeySavefile = LoadWithVersionCheck<JourneySavefile>(journeySaveSerializer, GameManager.Instance.MinVersionJourney);
		saveDataContext = new SaveDataContext(metaSavefile, journeySavefile, settingsSavefile);
		saveables = FindAllSaveables();
		foreach (ISaveable saveable in saveables)
		{
			saveable.Load(saveDataContext, isNewJourney: true);
		}
		if ((bool)CameraController.Instance)
		{
			CameraController.Instance.IsCameraFree = settingsSavefile.IsFreeCameraEnabled;
		}
		IsInitialized = true;
	}

	public bool JourneyExists()
	{
		if (journeySavefile != null)
		{
			return journeySavefile.CanLoadJourney;
		}
		return journeySaveSerializer.Load<JourneySavefile>()?.CanLoadJourney ?? false;
	}

	public void Save(bool saveJourney = false)
	{
		if (saveables != null)
		{
			foreach (ISaveable saveable in saveables)
			{
				saveable?.Save(saveDataContext);
			}
		}
		SaveMeta();
		SaveSettings();
		if (saveJourney)
		{
			SaveJourney();
		}
		SaveStats();
		Debug.Log("Saved Everything");
	}

	public void SaveMeta()
	{
		metaSaveSerializer.Save(metaSavefile);
		SaveDebugLogger.LogMetaSave(metaSavefile);
	}

	public void SaveSettings()
	{
		settingsSaveSerializer.Save(settingsSavefile);
	}

	public void SaveStats()
	{
		if (isReadyToSaveStats)
		{
			float num = Train.Instance.GlobalDistance / 100f;
			if (metaSavefile.mostEnemiesKilled < GameManager.Instance.TotalKillsInRun)
			{
				metaSavefile.mostEnemiesKilled = GameManager.Instance.TotalKillsInRun;
			}
			if (metaSavefile.mostDamageDealt < GameManager.Instance.TotalDamageInRun)
			{
				metaSavefile.mostDamageDealt = GameManager.Instance.TotalDamageInRun;
			}
			metaSavefile.totalEnemiesKilled += GameManager.Instance.TotalKillsInRun;
			metaSavefile.totalKilometersTraveled += num;
			metaSavefile.totalJourneys += 1f;
			isReadyToSaveStats = false;
			Debug.Log("Saved Stats");
		}
	}

	private List<ISaveable> FindAllSaveables()
	{
		HashSet<ISaveable> hashSet = new HashSet<ISaveable>();
		MonoBehaviour[] array = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
		foreach (MonoBehaviour monoBehaviour in array)
		{
			if (monoBehaviour.GetType().GetInterfaces().Contains(typeof(ISaveable)) && monoBehaviour.gameObject.scene.isLoaded)
			{
				hashSet.Add((ISaveable)monoBehaviour);
			}
		}
		return hashSet.OrderBy((ISaveable s) => s.GetType().Name).ToList();
	}

	public void SaveJourney(bool forceLoadable = false, bool ignoreLevelStart = true, bool savedOnLevelStart = false)
	{
		if (!JourneySaveBlocked)
		{
			if (forceLoadable)
			{
				ShouldSaveJourney = true;
			}
			if (!ignoreLevelStart)
			{
				JourneySavedOnLevelStart = savedOnLevelStart;
			}
			journeySavefile.SaveJourney();
			journeySaveSerializer.Save(journeySavefile);
		}
	}

	public void NewJourney()
	{
		if (metaSavefile.isFirstLoad)
		{
			metaSavefile.isFirstLoad = false;
			metaSaveSerializer.Save(metaSavefile);
			UIManager.Instance.ShowFirstLoadPanel();
		}
		DataTrackingManager.Instance.InitializeRunData();
		journeySavefile = new JourneySavefile();
		journeySavefile.ResetJourney();
		journeySaveSerializer.Save(journeySavefile);
		saveDataContext = new SaveDataContext(metaSavefile, journeySavefile, settingsSavefile);
		foreach (ISaveable saveable in saveables)
		{
			saveable.Load(saveDataContext, isNewJourney: true);
		}
		Debug.Log("New journey created.");
	}

	public void LoadJourney()
	{
		JourneySavefile journeySavefile = journeySaveSerializer.Load<JourneySavefile>();
		if (journeySavefile != null)
		{
			this.journeySavefile = journeySavefile;
			saveDataContext = new SaveDataContext(metaSavefile, this.journeySavefile, settingsSavefile);
			if (saveables != null)
			{
				foreach (ISaveable saveable in saveables)
				{
					saveable?.Load(saveDataContext, isNewJourney: false);
				}
			}
			this.journeySavefile.LoadJourney();
			Debug.Log("Journey loaded.");
		}
		else
		{
			Debug.LogWarning("No journey save file found to load.");
		}
	}

	public void SaveLevels()
	{
		StartCoroutine(SaveLevelsAfterBuild());
		IEnumerator SaveLevelsAfterBuild()
		{
			yield return new WaitUntil(() => LevelManager.Instance.BuildingLevelsComplete);
			journeySavefile.SaveLevels();
			journeySaveSerializer.Save(journeySavefile);
		}
	}

	public List<LevelSaveData> GetLevelSaveData()
	{
		return journeySavefile.Levels;
	}

	public List<Enhancement> GetRewards()
	{
		return journeySavefile.LevelRewards;
	}

	public void AddReward(Enhancement reward)
	{
		journeySavefile.AddReward(reward);
		SaveJourney();
	}

	public void ClearRewards()
	{
		journeySavefile.ClearRewards();
		SaveJourney();
	}

	public Enhancement? GetPurchasedShopEnhancementAtIndex(int i)
	{
		if (journeySavefile.PurchasedItems == null)
		{
			return null;
		}
		return journeySavefile.PurchasedItems.FirstOrDefault((ShopCard item) => item.Index == i)?.Enhancement;
	}

	public bool HasPurchasedShopEnhancementAtIndex(int index)
	{
		return journeySavefile.PurchasedItems?.Any((ShopCard sc) => sc.Index == index) ?? false;
	}

	public Enhancement? GetShopEnhancementAtIndex(int i)
	{
		if (journeySavefile.AllShopItems == null)
		{
			return null;
		}
		return journeySavefile.AllShopItems.FirstOrDefault((ShopCard item) => item.Index == i)?.Enhancement;
	}

	public void AddShopEnhancementPurchase(int index, Enhancement upgrade)
	{
		if (!(upgrade == null) && journeySavefile != null)
		{
			if (journeySavefile.PurchasedItems == null)
			{
				journeySavefile.PurchasedItems = new List<ShopCard>();
			}
			journeySavefile.PurchasedItems.Add(new ShopCard(index, upgrade));
			SaveJourney();
		}
	}

	public void AddShopEnhancement(int index, Enhancement upgrade)
	{
		if (!(upgrade == null) && journeySavefile != null)
		{
			if (journeySavefile.AllShopItems == null)
			{
				journeySavefile.AllShopItems = new List<ShopCard>();
			}
			journeySavefile.AllShopItems.Add(new ShopCard(index, upgrade));
			SaveJourney();
		}
	}

	public void ClearShopEnhancements()
	{
		if (journeySavefile != null)
		{
			journeySavefile.PurchasedItems = new List<ShopCard>();
			journeySavefile.AllShopItems = new List<ShopCard>();
			SaveJourney();
		}
	}

	public bool HasPurchasedWagonAtIndex(int index)
	{
		return journeySavefile.PurchasedWagonIndexes?.Any((int i) => i == index) ?? false;
	}

	public void AddShopWagonPurchase(int index)
	{
		if (journeySavefile != null)
		{
			if (journeySavefile.PurchasedWagonIndexes == null)
			{
				journeySavefile.PurchasedWagonIndexes = new List<int>();
			}
			journeySavefile.PurchasedWagonIndexes.Add(index);
			SaveJourney();
		}
	}

	public void AddShopWagon(ShopWagon scw)
	{
		if (journeySavefile != null)
		{
			if (journeySavefile.ShopWagons == null)
			{
				journeySavefile.ShopWagons = new List<ShopWagon>();
			}
			journeySavefile.ShopWagons.Add(scw);
			SaveJourney();
		}
	}

	public List<ShopWagon>? GetShopWagons()
	{
		return journeySavefile.ShopWagons ?? null;
	}

	public ShopWagon? GetShopWagon(int index)
	{
		if (journeySavefile != null && journeySavefile.ShopWagons != null && journeySavefile.ShopWagons.Count >= index + 1)
		{
			return journeySavefile.ShopWagons.FirstOrDefault((ShopWagon sw) => sw.Index == index);
		}
		return null;
	}

	public void ClearWagonPurchases()
	{
		if (journeySavefile != null)
		{
			journeySavefile.PurchasedWagonIndexes = new List<int>();
			journeySavefile.ShopWagons = new List<ShopWagon>();
			SaveJourney();
		}
	}

	public void ClearShopSave()
	{
		ClearShopEnhancements();
		ClearWagonPurchases();
	}

	public Encounter? GetEncounter()
	{
		List<Encounter> encounter = journeySavefile.Encounter;
		if (encounter == null || encounter.Count <= 0)
		{
			return null;
		}
		return journeySavefile.Encounter[0];
	}

	public void SetEncounter(Encounter encounter)
	{
		journeySavefile.SetEncounter(encounter);
		SaveJourney();
	}

	public void ClearEncounter()
	{
		journeySavefile.ClearEncounter();
		SaveJourney();
	}

	private T LoadWithVersionCheck<T>(SaveSerializer serializer, string requiredVersion) where T : Savefile, new()
	{
		Debug.Log("Attempting to load " + typeof(T).Name + " from " + serializer.FilePath);
		T val = serializer.Load<T>();
		if (val == null)
		{
			Debug.LogWarning(typeof(T).Name + " not found. Creating new instance.");
			T val2 = new T();
			serializer.Save(val2);
			return val2;
		}
		Version arg = null;
		if (!VersionHelper.CompareVersions(val.version, requiredVersion))
		{
			Debug.LogWarning(typeof(T).Name + " version '" + val.version + "' is invalid or too old. Backing up and creating new instance.");
			if (File.Exists(serializer.FilePath))
			{
				string directoryName = Path.GetDirectoryName(serializer.FilePath);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(serializer.FilePath);
				int num = 1;
				string text;
				do
				{
					text = Path.Combine(directoryName, $"{fileNameWithoutExtension}.old{num}");
					num++;
				}
				while (File.Exists(text));
				File.Move(serializer.FilePath, text);
				Debug.Log("Backed up old save: " + serializer.FilePath + " → " + text);
			}
			T val3 = new T();
			serializer.Save(val3);
			return val3;
		}
		Debug.Log($"{typeof(T).Name} loaded successfully (version {arg})");
		return val;
	}

	public void HandleBossBeaten(bool isEnd)
	{
		journeySavefile.HandleBossBeaten(isEnd);
		journeySaveSerializer.Save(journeySavefile);
	}

	private void OnApplicationQuit()
	{
		Save();
	}
}
