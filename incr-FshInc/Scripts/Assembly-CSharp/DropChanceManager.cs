using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropChanceManager : MonoBehaviour
{
	public static DropChanceManager Instance;

	private Dictionary<FishRarity, float> baseRarityChances = new Dictionary<FishRarity, float>
	{
		{
			FishRarity.Common,
			1000f
		},
		{
			FishRarity.Uncommon,
			150f
		},
		{
			FishRarity.Rare,
			25f
		},
		{
			FishRarity.Epic,
			5f
		},
		{
			FishRarity.Legendary,
			1f
		}
	};

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public CaughtFish RollForFish(ZoneData zone, Tile tile)
	{
		if (zone == null || zone.possibleCatches == null || zone.possibleCatches.Count == 0)
		{
			return null;
		}
		Fish fish = RollForSpecies(zone);
		if (fish == null)
		{
			return null;
		}
		Dictionary<FishRarity, float> modifiedRarityChances = GetModifiedRarityChances(zone);
		modifiedRarityChances = fish.GetLevelModifiedRarityWeights(modifiedRarityChances, fish.currentLevel);
		Debug.Log("Rarity chances for fish '" + fish.speciesName + "' in zone '" + zone.zoneName + "': " + string.Join(", ", modifiedRarityChances.Select((KeyValuePair<FishRarity, float> kv) => $"{kv.Key}: {kv.Value}")));
		FishRarity fishRarity = RollForRarity(modifiedRarityChances);
		RarityData rarityData = fish.GetRarityData(fishRarity);
		if (rarityData == null)
		{
			Debug.LogError($"Fish '{fish.speciesName}' has no data for rarity '{fishRarity}'.");
			return null;
		}
		return new CaughtFish(fish, rarityData);
	}

	private Fish RollForSpecies(ZoneData zone)
	{
		float num = zone.possibleCatches.Sum((FishEncounterData s) => s.encounterWeight);
		if (num <= 0f)
		{
			Debug.LogError("Total encounter weight for zone '" + zone.zoneName + "' is zero. No fish can be selected.");
			return null;
		}
		float num2 = Random.Range(0f, num);
		float num3 = 0f;
		foreach (FishEncounterData possibleCatch in zone.possibleCatches)
		{
			num3 += possibleCatch.encounterWeight;
			if (num2 <= num3)
			{
				return possibleCatch.fishSpecies;
			}
		}
		return null;
	}

	private FishRarity RollForRarity(Dictionary<FishRarity, float> chances)
	{
		float num = chances.Values.Sum();
		if (num <= 0f)
		{
			return FishRarity.Common;
		}
		float num2 = Random.Range(0f, num);
		float num3 = 0f;
		foreach (KeyValuePair<FishRarity, float> chance in chances)
		{
			num3 += chance.Value;
			if (num2 <= num3)
			{
				return chance.Key;
			}
		}
		return FishRarity.Common;
	}

	private Dictionary<FishRarity, float> GetModifiedRarityChances(ZoneData zone)
	{
		Dictionary<FishRarity, float> dictionary = new Dictionary<FishRarity, float>();
		if (zone.overrideGlobalRarity && zone.rarityOverrides != null && zone.rarityOverrides.Count > 0)
		{
			foreach (RarityChanceOverride rarityOverride in zone.rarityOverrides)
			{
				dictionary[rarityOverride.rarity] = rarityOverride.chanceWeight;
			}
		}
		else
		{
			dictionary = new Dictionary<FishRarity, float>(baseRarityChances);
		}
		return dictionary;
	}

	public Dictionary<FishRarity, float> GetRarityPercentagesForZone(ZoneData zone)
	{
		Dictionary<FishRarity, float> modifiedRarityChances = GetModifiedRarityChances(zone);
		float num = modifiedRarityChances.Values.Sum();
		Dictionary<FishRarity, float> dictionary = new Dictionary<FishRarity, float>();
		if (num <= 0f)
		{
			return dictionary;
		}
		foreach (KeyValuePair<FishRarity, float> item in modifiedRarityChances)
		{
			dictionary[item.Key] = item.Value / num * 100f;
		}
		return dictionary;
	}

	public Dictionary<FishRarity, float> GetRarityPercentagesForSpeciesInZone(Fish species, ZoneData zone)
	{
		Dictionary<FishRarity, float> dictionary = new Dictionary<FishRarity, float>();
		Dictionary<FishRarity, float> modifiedRarityChances = GetModifiedRarityChances(zone);
		Dictionary<FishRarity, float> dictionary2 = new Dictionary<FishRarity, float>();
		foreach (RarityData availableRarity in species.availableRarities)
		{
			if (modifiedRarityChances.ContainsKey(availableRarity.rarity))
			{
				dictionary2[availableRarity.rarity] = modifiedRarityChances[availableRarity.rarity];
			}
		}
		float num = dictionary2.Values.Sum();
		if (num <= 0f)
		{
			return dictionary;
		}
		foreach (KeyValuePair<FishRarity, float> item in dictionary2)
		{
			dictionary[item.Key] = item.Value / num * 100f;
		}
		return dictionary;
	}

	public Dictionary<FishRarity, float> GetGlobalRarityPercentagesWithBonuses(int zoneLevel = -1)
	{
		Dictionary<FishRarity, float> dictionary = new Dictionary<FishRarity, float>(baseRarityChances);
		float rareFishChanceMultiplier = PlayerStats.Instance.RareFishChanceMultiplier;
		if (dictionary.ContainsKey(FishRarity.Uncommon))
		{
			dictionary[FishRarity.Uncommon] *= rareFishChanceMultiplier;
		}
		if (dictionary.ContainsKey(FishRarity.Rare))
		{
			dictionary[FishRarity.Rare] *= Mathf.Pow(rareFishChanceMultiplier, 2f);
		}
		if (dictionary.ContainsKey(FishRarity.Epic))
		{
			dictionary[FishRarity.Epic] *= Mathf.Pow(rareFishChanceMultiplier, 1.5f);
		}
		if (dictionary.ContainsKey(FishRarity.Legendary))
		{
			dictionary[FishRarity.Legendary] *= rareFishChanceMultiplier;
		}
		if (zoneLevel > 0)
		{
			float rareChanceZoneSynergyMultiplier = PlayerStats.Instance.GetRareChanceZoneSynergyMultiplier(zoneLevel);
			foreach (FishRarity item in dictionary.Keys.ToList())
			{
				if (item != FishRarity.Common)
				{
					dictionary[item] *= rareChanceZoneSynergyMultiplier;
				}
			}
		}
		float num = dictionary.Values.Sum();
		Dictionary<FishRarity, float> dictionary2 = new Dictionary<FishRarity, float>();
		if (num <= 0f)
		{
			return dictionary2;
		}
		foreach (KeyValuePair<FishRarity, float> item2 in dictionary)
		{
			dictionary2[item2.Key] = item2.Value / num * 100f;
		}
		return dictionary2;
	}
}
