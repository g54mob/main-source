using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zone", menuName = "Game/Zone")]
public class ZoneData : ScriptableObject
{
	public string zoneName;

	public Sprite zoneIcon;

	public double unlockCost;

	public bool isUnlocked;

	public GameObject zonePrefab;

	public int expeditionCount;

	[Header("Fishing Data")]
	public List<FishEncounterData> possibleCatches;

	[Header("Rarity Overrides")]
	public bool overrideGlobalRarity;

	public List<RarityChanceOverride> rarityOverrides;

	[Header("Leveling Data")]
	public int currentLevel = 1;

	public int currentXp;

	[Tooltip("The gold bonus percentage per level. 0.0025 = 0.25%")]
	public float goldBonusPerLevel = 0.025f;

	[Tooltip("The XP bonus percentage per level. 0.0025 = 0.25%")]
	public float xpBonusPerLevel = 0.025f;

	[Header("Passive Income")]
	[Tooltip("The amount of gold generated per second, per level.")]
	public float passiveIncomePerLevel;

	[Header("Sounds")]
	public AudioClip ambientSound;

	[Range(0f, 1f)]
	[Tooltip("Volume multiplier for this zone's ambient sound. 1 = full volume.")]
	public float ambientVolume = 1f;

	public int GetXpForNextLevel()
	{
		return Mathf.FloorToInt(100f * Mathf.Pow(1.2f, currentLevel - 1));
	}

	public int GetXpForNextLevel(int level)
	{
		return Mathf.FloorToInt(100f * Mathf.Pow(1.2f, level - 1));
	}

	public float GetLevelProgressCof()
	{
		return (float)currentXp / (float)GetXpForNextLevel();
	}

	public float GetCurrentGoldBonusPercent()
	{
		return (float)(currentLevel - 1) * goldBonusPerLevel;
	}

	public float GetCurrentXpBonusPercent()
	{
		return (float)(currentLevel - 1) * xpBonusPerLevel;
	}

	public float GetGoldBonusMultiplier()
	{
		return 1f + GetCurrentGoldBonusPercent();
	}

	public float GetXpBonusMultiplier()
	{
		return 1f + GetCurrentXpBonusPercent();
	}

	public float GetCurrentPassiveIncome()
	{
		if (!isUnlocked)
		{
			return 0f;
		}
		return (float)(currentLevel - 1) * passiveIncomePerLevel;
	}

	public float GetCurrentPassiveIncome(int level)
	{
		return (float)(level - 1) * passiveIncomePerLevel;
	}
}
