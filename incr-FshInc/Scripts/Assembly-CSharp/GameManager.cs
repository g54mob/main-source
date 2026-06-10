using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public double totalMoney;

	public ZoneData currentZone;

	public List<ZoneData> allZones;

	public Action<double> OnMoneyChanged;

	private double uncollectedPassiveIncome;

	private const string DayCountKey = "CurrentDay";

	public const int CurrentSaveVersion = 1;

	private const string SaveVersionKey = "SaveVersion";

	[Header("UI Settings")]
	[Tooltip("How often (in seconds) the money display should update from passive income. (0.1 = 10 times/sec)")]
	public float moneyDisplayUpdateFrequency = 0.1f;

	private float moneyDisplayUpdateTimer;

	private double lastMoneyValueDisplayed = -1.0;

	[Header("Stats Tracking")]
	public float totalPlayTime;

	private const string PlayTimeKey = "TotalPlayTime";

	public DialogueSequenceSO goalRevealSO;

	public bool isPassiveIncomePaused;

	[HideInInspector]
	public bool isNewGamePending;

	public static GameManager Instance { get; private set; }

	public int CurrentDay { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadGameData();
		isPassiveIncomePaused = false;
	}

	private void Update()
	{
		totalPlayTime += Time.unscaledDeltaTime;
		HandlePassiveIncome();
		moneyDisplayUpdateTimer += Time.deltaTime;
		if (moneyDisplayUpdateTimer >= moneyDisplayUpdateFrequency)
		{
			moneyDisplayUpdateTimer -= moneyDisplayUpdateFrequency;
			if (totalMoney != lastMoneyValueDisplayed)
			{
				OnMoneyChanged?.Invoke(totalMoney);
				lastMoneyValueDisplayed = totalMoney;
			}
		}
	}

	public void ResetData()
	{
		totalMoney = 0.0;
		uncollectedPassiveIncome = 0.0;
		isPassiveIncomePaused = true;
		isNewGamePending = true;
		CurrentDay = 0;
		totalPlayTime = 0f;
		foreach (ZoneData allZone in allZones)
		{
			allZone.isUnlocked = allZone.unlockCost == 0.0;
			allZone.currentLevel = 1;
			allZone.currentXp = 0;
			allZone.expeditionCount = 0;
		}
		OnMoneyChanged?.Invoke(totalMoney);
	}

	public static bool IsSaveOutdated()
	{
		if (!PlayerPrefs.HasKey("HasSavedGame"))
		{
			return false;
		}
		return PlayerPrefs.GetInt("SaveVersion", 0) < 1;
	}

	public void FinalizeNewGame()
	{
		totalMoney = 0.0;
		uncollectedPassiveIncome = 0.0;
		isPassiveIncomePaused = false;
		isNewGamePending = false;
		OnMoneyChanged?.Invoke(totalMoney);
	}

	private void HandlePassiveIncome()
	{
		if (isPassiveIncomePaused)
		{
			return;
		}
		double num = 0.0;
		foreach (ZoneData allZone in allZones)
		{
			num += (double)allZone.GetCurrentPassiveIncome();
		}
		if (PlayerStats.Instance != null)
		{
			num *= (double)PlayerStats.Instance.PassiveIncomeMultiplier;
			num += (double)PlayerStats.Instance.PassiveIncomeAdditive;
		}
		uncollectedPassiveIncome += num * (double)Time.deltaTime;
		if (uncollectedPassiveIncome >= 1.0)
		{
			double num2 = Math.Floor(uncollectedPassiveIncome);
			uncollectedPassiveIncome -= num2;
			if (num2 > 0.0)
			{
				totalMoney += num2;
				AchievementManager.Instance?.NotifyPassiveIncomeEarned((int)num2);
			}
		}
	}

	public void AddMoney(double amount)
	{
		totalMoney += amount;
		OnMoneyChanged?.Invoke(totalMoney);
	}

	public void SelectZone(ZoneData zone)
	{
		if (zone.isUnlocked)
		{
			currentZone = zone;
			if (AnalyticsLogger.Instance != null)
			{
				AnalyticsLogger.Instance.LogZoneEntered(zone.zoneName, totalMoney);
			}
			SaveGameData();
			SceneTransitionManager.Instance.TransitionToScene("FishingScene");
			SoundManager.SetZoneAudio(zone);
		}
	}

	public void AddEarnings(double amount, string reason)
	{
		totalMoney += amount;
		OnMoneyChanged?.Invoke(totalMoney);
		if (amount > 0.0)
		{
			AchievementManager.Instance?.NotifyMoneyEarned(amount);
		}
	}

	public bool SpendMoney(double amount, string reason)
	{
		if (totalMoney >= amount)
		{
			totalMoney -= amount;
			OnMoneyChanged?.Invoke(totalMoney);
			return true;
		}
		OnMoneyChanged?.Invoke(totalMoney);
		return false;
	}

	public int AddXpToCurrentZone(int xpAmount)
	{
		if (currentZone == null)
		{
			return 0;
		}
		currentZone.currentXp += xpAmount;
		int num = 0;
		int num2 = 0;
		while (currentZone.currentXp >= currentZone.GetXpForNextLevel() && num2 < 1000)
		{
			currentZone.currentXp -= currentZone.GetXpForNextLevel();
			currentZone.currentLevel++;
			num++;
			num2++;
		}
		return num;
	}

	public bool UnlockZone(ZoneData zone)
	{
		double effectiveZoneUnlockCost = GetEffectiveZoneUnlockCost(zone);
		if (SpendMoney(effectiveZoneUnlockCost, "UnlockZone" + zone.zoneName))
		{
			if (AnalyticsLogger.Instance != null)
			{
				AnalyticsLogger.Instance.LogZoneBought(zone.zoneName, effectiveZoneUnlockCost, totalMoney);
			}
			zone.isUnlocked = true;
			_ = zone.zoneName == "Forest Lake";
			SaveGameData();
			return true;
		}
		return false;
	}

	public double GetEffectiveZoneUnlockCost(ZoneData zone)
	{
		double num = zone.unlockCost;
		if (PlayerStats.Instance != null)
		{
			float num2 = Mathf.Clamp(PlayerStats.Instance.PondUnlockCostMultiplier, 0.01f, 1f);
			num *= (double)num2;
		}
		return Math.Round(num);
	}

	public void SaveGameData()
	{
		PlayerPrefs.SetString("TotalMoneyDouble", totalMoney.ToString("R"));
		foreach (ZoneData allZone in allZones)
		{
			PlayerPrefs.SetInt(allZone.zoneName + "_unlocked", allZone.isUnlocked ? 1 : 0);
			PlayerPrefs.SetInt("Zone_" + allZone.zoneName + "_Level", allZone.currentLevel);
			PlayerPrefs.SetInt("Zone_" + allZone.zoneName + "_XP", allZone.currentXp);
		}
		PlayerPrefs.SetInt("HasSavedGame", 1);
		PlayerPrefs.SetInt("SaveVersion", 1);
		if (SkillManager.Instance != null)
		{
			SkillManager.Instance.SaveSkillData();
		}
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.SaveAchievementData();
		}
		PlayerPrefs.SetFloat("TotalPlayTime", totalPlayTime);
		PlayerPrefs.Save();
		Debug.Log("All game data saved!");
	}

	public void LoadGameData()
	{
		if (PlayerPrefs.HasKey("TotalMoneyDouble"))
		{
			double.TryParse(PlayerPrefs.GetString("TotalMoneyDouble", "0"), out totalMoney);
		}
		else
		{
			totalMoney = PlayerPrefs.GetInt("TotalMoney", 0);
		}
		LoadZoneUnlockData();
		LoadDayCount();
		totalPlayTime = PlayerPrefs.GetFloat("TotalPlayTime", 0f);
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.LoadAchievementData();
		}
	}

	private void LoadDayCount()
	{
		CurrentDay = PlayerPrefs.GetInt("CurrentDay", 0);
	}

	public void IncrementDayAndSave()
	{
		CurrentDay++;
		PlayerPrefs.SetInt("CurrentDay", CurrentDay);
		PlayerPrefs.Save();
		Debug.Log($"--- DAY {CurrentDay} STARTED ---");
	}

	public void LoadZoneUnlockData()
	{
		foreach (ZoneData allZone in allZones)
		{
			int num = PlayerPrefs.GetInt(allZone.zoneName + "_unlocked", 0);
			allZone.isUnlocked = num == 1;
			if (allZone.unlockCost == 0.0)
			{
				allZone.isUnlocked = true;
			}
			allZone.currentLevel = PlayerPrefs.GetInt("Zone_" + allZone.zoneName + "_Level", 1);
			allZone.currentXp = PlayerPrefs.GetInt("Zone_" + allZone.zoneName + "_XP", 0);
		}
	}
}
