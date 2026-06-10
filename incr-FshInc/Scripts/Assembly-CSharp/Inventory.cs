using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<CaughtFish> caughtFish = new List<CaughtFish>();

	public TMP_Text inventoryText;

	public static Inventory Instance { get; private set; }

	public static event Action<CaughtFish> OnFishAdded;

	private void Start()
	{
		UpdateInventoryDisplay();
	}

	public void AddFish(CaughtFish fish)
	{
		caughtFish.Add(fish);
		UpdateInventoryDisplay();
		Inventory.OnFishAdded?.Invoke(fish);
	}

	public List<CaughtFish> GetCaughtFishList()
	{
		return caughtFish;
	}

	public double CalculateTotalValue()
	{
		double num = 0.0;
		foreach (CaughtFish item in caughtFish)
		{
			num += item.value;
		}
		return num;
	}

	public void ClearInventory()
	{
		caughtFish.Clear();
		UpdateInventoryDisplay();
	}

	public Dictionary<string, (CaughtFish Fish, int Count)> GetFishCounts()
	{
		Dictionary<string, (CaughtFish, int)> dictionary = new Dictionary<string, (CaughtFish, int)>();
		foreach (CaughtFish item in caughtFish)
		{
			string key = item.fishName + " (" + item.rarityName + ")";
			if (dictionary.ContainsKey(key))
			{
				(CaughtFish, int) tuple = dictionary[key];
				dictionary[key] = (tuple.Item1, tuple.Item2 + 1);
			}
			else
			{
				dictionary.Add(key, (item, 1));
			}
		}
		return dictionary;
	}

	public int CalculateTotalXp()
	{
		float num = 0f;
		foreach (CaughtFish item in caughtFish)
		{
			num += (float)item.rarityData.xpValue;
		}
		if (PlayerStats.Instance != null)
		{
			num += PlayerStats.Instance.PondExperienceAdditive;
			num *= PlayerStats.Instance.PondExperienceMultiplier;
			num *= PlayerStats.Instance.ExperienceGainMultiplier;
		}
		return Mathf.RoundToInt(num);
	}

	public int CalculateTotalXp(float pondSkillScale = 1f)
	{
		float num = 0f;
		foreach (CaughtFish item in caughtFish)
		{
			num += (float)item.rarityData.xpValue;
		}
		if (PlayerStats.Instance != null)
		{
			pondSkillScale = Mathf.Clamp01(pondSkillScale);
			num += PlayerStats.Instance.PondExperienceAdditive * pondSkillScale;
			num *= PlayerStats.Instance.PondExperienceMultiplier;
			num *= PlayerStats.Instance.ExperienceGainMultiplier;
		}
		return Mathf.RoundToInt(num);
	}

	private void UpdateInventoryDisplay()
	{
		if (inventoryText == null)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("Caught Fish:\n");
		Dictionary<string, (CaughtFish, int)> fishCounts = GetFishCounts();
		if (fishCounts.Count == 0)
		{
			stringBuilder.Append("- Empty -");
		}
		else
		{
			foreach (KeyValuePair<string, (CaughtFish, int)> item in fishCounts)
			{
				stringBuilder.AppendLine($"- {item.Value.Item1.fishName} ({item.Value.Item1.rarityName}) x{item.Value.Item2}");
			}
		}
		inventoryText.text = stringBuilder.ToString();
	}
}
