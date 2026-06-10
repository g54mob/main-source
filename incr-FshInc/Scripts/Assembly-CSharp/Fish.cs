using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

[CreateAssetMenu(fileName = "New Fish Species", menuName = "Game/Fish Species")]
public class Fish : ScriptableObject
{
	public string speciesName;

	[TextArea(3, 5)]
	public string description;

	public List<FishPreference> preferences = new List<FishPreference>();

	public int currentLevel = 1;

	public int currentXp;

	[Tooltip("Multiplier for the XP curve. Higher values make this fish require more XP per level. Set to 1 for default.")]
	public float xpCurveMultiplier = 1f;

	public List<RarityData> availableRarities;

	[Header("Boss Fish")]
	[Tooltip("If true, this fish is a boss entry — shown with a special border in the fish log and excluded from zone fish lists.")]
	public bool isBossFish;

	public Sprite bossBorderSprite;

	public Material bossBorderMaterial;

	public Color bossAccentColor = Color.white;

	private string LocalizationKeyID => speciesName.ToLowerInvariant().Replace(" ", "_");

	public string LocalizedName
	{
		get
		{
			string key = "#fish." + LocalizationKeyID + ".name";
			StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
			if (stringTableEntry == null || string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
			{
				return speciesName;
			}
			return stringTableEntry.GetLocalizedString();
		}
	}

	public string LocalizedDescription
	{
		get
		{
			string key = "#fish." + LocalizationKeyID + ".desc";
			StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
			if (stringTableEntry == null || string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
			{
				return description;
			}
			return stringTableEntry.GetLocalizedString();
		}
	}

	public int GetXpForNextLevel()
	{
		return GetXpForNextLevel(currentLevel);
	}

	public int GetXpForNextLevel(int level)
	{
		return Mathf.FloorToInt((10f + Mathf.Pow(level, 1.8f)) * xpCurveMultiplier);
	}

	public Dictionary<FishRarity, float> GetLevelModifiedRarityWeights(int levelToCalculate)
	{
		Dictionary<FishRarity, float> globalRarityPercentagesWithBonuses = DropChanceManager.Instance.GetGlobalRarityPercentagesWithBonuses();
		return ApplyLevelShiftLogic(globalRarityPercentagesWithBonuses, levelToCalculate);
	}

	public Dictionary<FishRarity, float> GetLevelModifiedRarityWeights(Dictionary<FishRarity, float> startingChances, int levelToCalculate)
	{
		return ApplyLevelShiftLogic(startingChances, levelToCalculate);
	}

	private Dictionary<FishRarity, float> ApplyLevelShiftLogic(Dictionary<FishRarity, float> chances, int levelToCalculate)
	{
		Dictionary<FishRarity, float> dictionary = new Dictionary<FishRarity, float>(chances);
		DropChanceManager.Instance.GetGlobalRarityPercentagesWithBonuses();
		float num = Mathf.Clamp01(((float)levelToCalculate - 1f) / 6f) * 1f;
		float num2 = dictionary.GetValueOrDefault(FishRarity.Common) * num;
		dictionary[FishRarity.Common] -= num2;
		dictionary[FishRarity.Uncommon] += num2;
		float num3 = Mathf.Clamp01(((float)levelToCalculate - 2f) / 8f) * 0.98f;
		num2 = dictionary.GetValueOrDefault(FishRarity.Uncommon) * num3;
		dictionary[FishRarity.Uncommon] -= num2;
		dictionary[FishRarity.Rare] += num2;
		float num4 = Mathf.Clamp01(((float)levelToCalculate - 4f) / 10f) * 0.95f;
		num2 = dictionary.GetValueOrDefault(FishRarity.Rare) * num4;
		dictionary[FishRarity.Rare] -= num2;
		dictionary[FishRarity.Epic] += num2;
		float num5 = Mathf.Clamp01(((float)levelToCalculate - 6f) / 12f) * 0.9f;
		num2 = dictionary.GetValueOrDefault(FishRarity.Epic) * num5;
		dictionary[FishRarity.Epic] -= num2;
		dictionary[FishRarity.Legendary] += num2;
		return dictionary;
	}

	public float GetLevelModifiedRarityWeight(FishRarity rarity)
	{
		return GetLevelModifiedRarityWeights(currentLevel)[rarity];
	}

	public RarityData GetRarityData(FishRarity targetRarity)
	{
		foreach (RarityData availableRarity in availableRarities)
		{
			if (availableRarity.rarity == targetRarity)
			{
				return availableRarity;
			}
		}
		return (from data in availableRarities
			where data.rarity <= targetRarity
			orderby data.rarity descending
			select data).FirstOrDefault();
	}
}
