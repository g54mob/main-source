using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DG.Tweening;
using UnityEngine;

public class StartupManager : MonoBehaviour
{
	public GameObject prefabManager;

	public GameObject platformSteamPrefab;

	public GameObject platformStandalonePrefab;

	private GameUtility gameUtility;

	public string defaultFileToLoad;

	public string debugOverrideName;

	public string debugTradeItem;

	public string debugAutoAssignItem;

	public bool isItemDebugGlobal;

	public bool playtestMode;

	public bool fastRecipes;

	public bool autoClaimQuests;

	public bool useEditorLogs;

	public bool debugRewardMenu;

	public bool debugSkipTimeTokens;

	public bool debugMigration;

	public Camera uiCamera;

	public Camera mainCamera;

	public Camera renderTextureParticlesCamera;

	private static StartupManager _instance;

	private StartupPhase _startupPhase;

	public float waterPressure = 10f;

	private bool lastUseOldSellRates;

	private string lastDebugTradeItem;

	private string lastDebugAutoAssignItem;

	[NonSerialized]
	public ItemType debugTradeItemType;

	[NonSerialized]
	public ItemType debugAutoAssignItemType;

	public const bool IsInTrailerMode = false;

	public const bool IsDemo = true;

	public static StartupManager Instance => _instance;

	public StartupPhase startupPhase
	{
		get
		{
			return _startupPhase;
		}
		set
		{
			_startupPhase = value;
			Debug.Log("Startup phase: " + _startupPhase);
		}
	}

	private void Awake()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		foreach (string text in commandLineArgs)
		{
			string text2 = text.ToUpper();
			Debug.Log("Found launch arg:'" + text + "'");
			switch (text2)
			{
			case "WINDOWED":
			case "-WINDOWED":
				Preferences.SetValueForKey("PrefVideoKeyWindowMode", "PrefVideoOptionWindowModeWindowed");
				break;
			case "FULLSCREEN":
			case "-FULLSCREEN":
				Preferences.SetValueForKey("PrefVideoKeyWindowMode", "PrefVideoOptionWindowModeFullscreenExclusive");
				break;
			}
		}
		Debug.Log("Startup Manager Awake, version 1.3.6a");
		GameManager.GameState = GameState.Startup;
		_instance = this;
		startupPhase = StartupPhase.LoadManagers;
		if (!Application.isPlaying)
		{
			return;
		}
		DOTween.Init();
		LocalizationManager.Init();
		gameUtility = new GameUtility();
		TimeManager.debugSpeedMod = 1;
		UnityEngine.Object.Instantiate(prefabManager);
		GameManager.Init();
		TimeManager.timeMode = 0;
		UnityEngine.Object.Instantiate(PrefabManager.Instance.colorManagerPrefab);
		UnityEngine.Object.Instantiate(PrefabManager.Instance.iconManagerPrefab);
		UnityEngine.Object.Instantiate(PrefabManager.Instance.menuPrefab);
		UnityEngine.Object.Instantiate(PrefabManager.Instance.soundManagerPrefab).GetComponent<SoundManager>().Init();
		UnityEngine.Object.Instantiate(PrefabManager.Instance.userInputPrefab);
		UnityEngine.Object.Instantiate(PrefabManager.Instance.musicPlayerPrefab);
		startupPhase = StartupPhase.LoadPlatform;
		GameObject gameObject = null;
		bool flag;
		try
		{
			string fullPath = Path.GetFullPath(".");
			Path.Combine(fullPath, "steam_appid.txt");
			Path.Combine(fullPath, "gog.txt");
			Debug.Log("Startup Platform: Steam");
			Debug.Log("Startup Type: Demo");
			if (true)
			{
				Debug.Log("Attempt init Steam");
				gameObject = UnityEngine.Object.Instantiate(platformSteamPrefab);
			}
			else
			{
				Debug.Log("Attempt init Standalone");
				gameObject = UnityEngine.Object.Instantiate(platformStandalonePrefab);
			}
			Debug.Log("Platform init: " + gameObject);
			flag = Platform.Instance.Init();
			Debug.Log("Platform init result: " + flag + " ready? " + Platform.Instance.IsReady);
		}
		catch (Exception ex)
		{
			Debug.LogError("Error attempting to load platform: " + ex);
			flag = false;
		}
		if (!flag)
		{
			Debug.Log("Platform init failed - Editor is falling back to standalone platform");
			if (null != gameObject)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			gameObject = UnityEngine.Object.Instantiate(platformStandalonePrefab);
			Platform.Instance.Init();
			Platform.isOfflineMode = true;
		}
		Debug.Log("Startup Manager Awake Complete");
		_ = GameManager.Instance;
	}

	private void Update()
	{
		if (startupPhase == StartupPhase.LoadPlatform && null != Platform.Instance && Platform.Instance.IsReady)
		{
			startupPhase = StartupPhase.GameObjectsAwake;
		}
		if (startupPhase == StartupPhase.GameObjectsAwake && null != MenuManager.Instance)
		{
			startupPhase = StartupPhase.LoadPreferencesAndLanguage;
		}
		if (startupPhase == StartupPhase.LoadPreferencesAndLanguage)
		{
			Preferences.ApplyAll();
			CompleteStartupAndLaunchMainMenu();
		}
	}

	private void CompleteStartupAndLaunchMainMenu()
	{
		startupPhase = StartupPhase.Complete;
		new Data();
		Crafting.Init();
		GameObject obj = new GameObject();
		obj.AddComponent<TimeManager>();
		obj.name = "Time Manager";
		Crafting.LoadDefaults();
		MenuManager.Instance.CreatePanels();
		MenuManager.Instance.ReloadLabels();
		MenuManager.Instance.ShowWelcomeMenu();
	}

	public static void DebugNumberPrinting()
	{
		TextDisplay.debug = true;
		for (int i = 0; i < 15; i++)
		{
			TextDisplay.LocalizedNumber(GameUtility.ScaledTenValue(10.0, i) * 0.01);
		}
		TextDisplay.debug = false;
	}

	private void DebugTownPerkPoints()
	{
		double num = 0.0;
		for (int i = 1; i <= 50; i++)
		{
			float num2 = GameUtility.Poly(i, 1f, 1f, 0.05f, 0.01f);
			double num3 = Math.Round(num2);
			if (num2 >= 100f)
			{
				num3 = Math.Round(num2 * 0.1f);
				num3 *= 10.0;
			}
			else if (num2 >= 50f)
			{
				num3 = Math.Round(num2 * 0.2f);
				num3 *= 5.0;
			}
			else if (num2 >= 10f)
			{
				num3 = Math.Round(num2 * 0.5f);
				num3 *= 2.0;
			}
			num += num3;
		}
	}

	private void DebugXPValues()
	{
		foreach (KeyValuePair<ItemType, float> itemXpValue in Crafting.itemXpValues)
		{
			_ = itemXpValue;
		}
	}

	private void DebugPerkEffect()
	{
		PerkType[] array = Enum.GetValues(typeof(PerkType)) as PerkType[];
		foreach (PerkType key in array)
		{
			if (Crafting.perkDefCache.TryGetValue(key, out var value))
			{
				for (int j = 0; j < value.maxLevel; j++)
				{
				}
			}
		}
	}

	private void DebugPerkCost()
	{
		PerkType[] array = Enum.GetValues(typeof(PerkType)) as PerkType[];
		foreach (PerkType perkType in array)
		{
			if (Crafting.perkDefCache.TryGetValue(perkType, out var value))
			{
				for (int j = 0; j < value.maxLevel; j++)
				{
					int num = j;
					int num2 = 2;
					Mathf.Round(GameUtility.Poly(num, num2, 1f, 0.112f));
					Mathf.Ceil(GameUtility.ExponentGrowth(num2, num, 0.25f));
					int level = num + 1;
					GameManager.DebugMultiplierForPerk(perkType, level, GrowthRateType.Linear);
					GameManager.DebugMultiplierForPerk(perkType, level, GrowthRateType.Exponential);
				}
			}
		}
	}

	private void DebugCultureCodes()
	{
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
		for (int i = 0; i < cultures.Length; i++)
		{
			_ = cultures[i];
		}
	}

	private void DebugFloatSize()
	{
		float num = 1.234568E+09f;
		for (int i = 0; (float)i < 1000f; i++)
		{
			num += 10f;
		}
	}

	private void DebugPrestigePointCost()
	{
		for (int i = 0; i < 40; i++)
		{
		}
	}

	private void DebugClickLevelUpCost()
	{
		for (int i = 0; i < 40; i++)
		{
		}
	}

	private void DebugLevelUpCost()
	{
		for (int i = 0; i < 40; i++)
		{
		}
	}

	private void DebugHousePlots()
	{
		for (int i = 0; i < 20; i++)
		{
			Mathf.Pow(i, 2f);
		}
	}

	private void DebugLargeNumberSuffixes()
	{
		for (int i = 0; i < 10; i++)
		{
			Mathf.Pow(10f, i);
		}
	}

	private void DebugRoundedValues()
	{
		DebugRoundedValue(1.2345f);
		DebugRoundedValue(12.345f);
		DebugRoundedValue(123.567f);
		DebugRoundedValue(1237.99f);
		DebugRoundedValue(12375.22f);
		DebugRoundedValue(123756f);
		DebugRoundedValue(1237567f);
	}

	private void DebugRoundedValue(float d)
	{
	}

	public void DebugLevelBounds()
	{
		LevelStat levelStat = new LevelStat(ItemType.TownExperiencePoint, 100f, 0.3f, 100f);
		float num = 100f;
		for (int i = 0; i <= 20; i++)
		{
			levelStat.SetLevel(i);
			levelStat.CalcLevelBounds();
			Mathf.RoundToInt(Mathf.Log(levelStat.currentLevelCeil / num, 2.718f) / 0.3f);
		}
		for (float num2 = 90f; num2 < 500f; num2 += 1f)
		{
		}
	}

	private void DebugExp()
	{
		double num = 0.0;
		for (int i = 0; i < 50; i++)
		{
			double num2 = GameManager.ExperienceCostForProgressingFromLevel(i);
			num += num2;
			for (int j = 0; j < 50000 && !(GameManager.CostForEarningNextPrestigePoint(j) > num); j++)
			{
			}
		}
	}

	public static void DebugAllPerkCosts()
	{
		double num = 0.0;
		foreach (Perk value in Crafting.perkDefCache.Values)
		{
			if (value.perkType != PerkType.TownXPBoost && !value.isGlobal)
			{
				double num2 = 0.0;
				for (int i = 0; i < value.maxLevel; i++)
				{
					int num3 = value.costArray[i];
					num2 += (double)num3;
				}
				num += num2;
			}
		}
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		for (int j = 1; j <= 50; j++)
		{
			double num8 = Town.PerkPointsForReachingLevel(j);
			num5 += num8;
			double num9 = GameManager.ExperienceCostForProgressingFromLevel(j - 1);
			num6 += num9;
			num7 += num9;
			double num10 = 0.0;
			int num11 = 0;
			while (num7 >= GameManager.CostForEarningNextPrestigePoint(num4 + num10))
			{
				num10 += 1.0;
				num11++;
				if (num11 > 100000)
				{
					break;
				}
			}
			double num12 = num10;
			num4 += num12;
		}
	}
}
