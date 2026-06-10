using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishLogManager : MonoBehaviour
{
	public struct LevelPrediction
	{
		public int newLevel;

		public float newIncome;

		public float xpFillAmount;
	}

	public static FishLogManager Instance;

	public List<Fish> allFish = new List<Fish>();

	private Dictionary<string, int> catchCounts = new Dictionary<string, int>();

	private const string TotalFishKey = "TotalGlobalFishCaught";

	public int TotalGlobalFishCaught { get; private set; }

	public event Action OnLogUpdated;

	public static event Action<CaughtFish> OnFishLoggedWithData;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			LoadLog();
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void LogFish(CaughtFish fish)
	{
		string key = fish.fishName + "_" + fish.rarityName;
		bool num = !HasCaughtSpecies(fish.fishName);
		int num2 = (fish.isTripleCatch ? 3 : ((!fish.isDoubleCatch) ? 1 : 2));
		catchCounts[key] = GetCatchCount(fish.fishName, fish.rarityName) + num2;
		TotalGlobalFishCaught += num2;
		if (num)
		{
			SetFishAsNew(fish.fishName, isNew: true);
		}
		Fish fish2 = allFish.FirstOrDefault((Fish f) => f.speciesName == fish.fishName);
		if (fish2 != null)
		{
			float num3 = fish.xpValue;
			if (fish.isTripleCatch)
			{
				num3 *= 3f;
			}
			else if (fish.isDoubleCatch)
			{
				num3 *= 2f;
			}
			if (PlayerStats.Instance != null)
			{
				num3 += PlayerStats.Instance.FishCatchExperienceAdditive;
				num3 *= PlayerStats.Instance.FishCatchExperienceMultiplier;
				num3 *= PlayerStats.Instance.ExperienceGainMultiplier;
			}
			int num4 = Mathf.RoundToInt(num3);
			fish2.currentXp += num4;
			while (fish2.currentXp >= fish2.GetXpForNextLevel())
			{
				fish2.currentXp -= fish2.GetXpForNextLevel();
				fish2.currentLevel++;
				Debug.Log($"{fish2.speciesName} leveled up to Level {fish2.currentLevel}!");
			}
		}
		SaveLog();
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.OnFishCaught(fish);
		}
		this.OnLogUpdated?.Invoke();
		FishLogManager.OnFishLoggedWithData?.Invoke(fish);
	}

	public bool IsFishNew(string speciesName)
	{
		return PlayerPrefs.GetInt("FishNew_" + speciesName, 0) == 1;
	}

	private void SetFishAsNew(string speciesName, bool isNew, bool notify = true)
	{
		PlayerPrefs.SetInt("FishNew_" + speciesName, isNew ? 1 : 0);
		PlayerPrefs.Save();
		if (notify)
		{
			this.OnLogUpdated?.Invoke();
		}
	}

	public void MarkFishAsSeen(string speciesName, bool notify = true)
	{
		if (IsFishNew(speciesName))
		{
			SetFishAsNew(speciesName, isNew: false, notify);
		}
	}

	public void RefreshLogEvents()
	{
		this.OnLogUpdated?.Invoke();
	}

	public bool HasAnyNewFish()
	{
		foreach (Fish item in allFish)
		{
			if (IsFishNew(item.speciesName))
			{
				return true;
			}
		}
		return false;
	}

	[ContextMenu("Unlock All Fish")]
	public void UnlockAllFish()
	{
		foreach (Fish item in allFish)
		{
			if (item.availableRarities != null && item.availableRarities.Count > 0)
			{
				string key = item.speciesName + "_" + item.availableRarities[0].rarity;
				if (!catchCounts.ContainsKey(key))
				{
					catchCounts[key] = 1;
					TotalGlobalFishCaught++;
				}
			}
			SetFishAsNew(item.speciesName, isNew: true, notify: false);
		}
		SaveLog();
		RefreshLogEvents();
		Debug.Log("Unlocked all fish (Base Rarity)!");
	}

	[ContextMenu("Unlock All Fish (All Rarities)")]
	public void Debug_UnlockAllFishAllRarities()
	{
		foreach (Fish item in allFish)
		{
			foreach (RarityData availableRarity in item.availableRarities)
			{
				string key = item.speciesName + "_" + availableRarity.rarity;
				if (!catchCounts.ContainsKey(key))
				{
					catchCounts[key] = 1;
					TotalGlobalFishCaught++;
				}
			}
			SetFishAsNew(item.speciesName, isNew: true, notify: false);
		}
		SaveLog();
		RefreshLogEvents();
		Debug.Log("Unlocked EVERYTHING in the Fish Log!");
	}

	[ContextMenu("Reset Log")]
	public void ResetLog()
	{
		catchCounts.Clear();
		TotalGlobalFishCaught = 0;
		foreach (Fish item in allFish)
		{
			item.currentLevel = 1;
			item.currentXp = 0;
		}
		SaveLog();
		Debug.Log("FishLog data reset.");
	}

	public int GetFinalXPGain(CaughtFish fish)
	{
		float num = fish.xpValue;
		if (PlayerStats.Instance != null)
		{
			num += PlayerStats.Instance.FishCatchExperienceAdditive;
			num *= PlayerStats.Instance.FishCatchExperienceMultiplier;
			num *= PlayerStats.Instance.ExperienceGainMultiplier;
		}
		return Mathf.RoundToInt(num);
	}

	public int GetCatchCount(string speciesName, string rarityName)
	{
		string key = speciesName + "_" + rarityName;
		if (catchCounts.ContainsKey(key))
		{
			return catchCounts[key];
		}
		return 0;
	}

	private Fish GetFishData(string speciesName)
	{
		return allFish.FirstOrDefault((Fish f) => f.speciesName == speciesName);
	}

	public int GetFishLevel(string speciesName)
	{
		Fish fishData = GetFishData(speciesName);
		if (fishData != null)
		{
			return fishData.currentLevel;
		}
		return 1;
	}

	public int GetFishXP(string speciesName)
	{
		Fish fishData = GetFishData(speciesName);
		if (fishData != null)
		{
			return fishData.currentXp;
		}
		return 0;
	}

	public int GetTotalCatchCountForSpecies(string speciesName)
	{
		int num = 0;
		foreach (KeyValuePair<string, int> catchCount in catchCounts)
		{
			if (catchCount.Key.StartsWith(speciesName + "_"))
			{
				num += catchCount.Value;
			}
		}
		return num;
	}

	private void SaveLog()
	{
		foreach (KeyValuePair<string, int> catchCount in catchCounts)
		{
			PlayerPrefs.SetInt("FishLog_" + catchCount.Key, catchCount.Value);
		}
		foreach (Fish item in allFish)
		{
			PlayerPrefs.SetInt("FishLevel_" + item.speciesName, item.currentLevel);
			PlayerPrefs.SetInt("FishXP_" + item.speciesName, item.currentXp);
		}
		PlayerPrefs.SetInt("TotalGlobalFishCaught", TotalGlobalFishCaught);
		PlayerPrefs.Save();
	}

	public LevelPrediction PredictLevelUp(string speciesName, float xpToAdd)
	{
		Fish fishData = GetFishData(speciesName);
		if (fishData == null)
		{
			return default(LevelPrediction);
		}
		int currentLevel = fishData.currentLevel;
		int currentXp = fishData.currentXp;
		int num = Mathf.RoundToInt(xpToAdd);
		fishData.currentXp += num;
		while (fishData.currentXp >= fishData.GetXpForNextLevel())
		{
			fishData.currentXp -= fishData.GetXpForNextLevel();
			fishData.currentLevel++;
		}
		LevelPrediction result = new LevelPrediction
		{
			newLevel = fishData.currentLevel,
			xpFillAmount = (float)fishData.currentXp / (float)fishData.GetXpForNextLevel()
		};
		fishData.currentLevel = currentLevel;
		fishData.currentXp = currentXp;
		return result;
	}

	public void LoadLog()
	{
		foreach (Fish item in allFish)
		{
			foreach (RarityData availableRarity in item.availableRarities)
			{
				string text = item.speciesName + "_" + availableRarity.rarity;
				int num = PlayerPrefs.GetInt("FishLog_" + text, 0);
				if (num > 0)
				{
					catchCounts[text] = num;
				}
			}
			item.currentLevel = PlayerPrefs.GetInt("FishLevel_" + item.speciesName, 1);
			item.currentXp = PlayerPrefs.GetInt("FishXP_" + item.speciesName, 0);
		}
		TotalGlobalFishCaught = PlayerPrefs.GetInt("TotalGlobalFishCaught", 0);
	}

	public bool HasCaughtSpecies(string speciesName)
	{
		return GetTotalCatchCountForSpecies(speciesName) > 0;
	}
}
