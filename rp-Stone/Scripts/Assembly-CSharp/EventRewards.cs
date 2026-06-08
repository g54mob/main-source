using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class EventRewards
{
	private SafeInt _rps;

	public int claimedFreeIndex = -1;

	public int claimedPremiumIndex = -1;

	private static List<ItemData.Element> possibleElements;

	public static int debugFakeRewardPoints = -1;

	public Data.EventRewardCollection data { get; set; }

	public int previousPoints { get; private set; }

	public int rewardPoints
	{
		get
		{
			return _rps.GetValue();
		}
		private set
		{
			_rps = new SafeInt(value);
		}
	}

	public int maxRewardPoints => Mathf.Min(data.free.Length, data.premium.Length);

	public int treasureRarityBonus
	{
		get
		{
			for (int num = Mathf.Min(rewardPoints, data.free.Length) - 1; num >= 0; num--)
			{
				if (data.free[num].IsSpecialEventTreasure())
				{
					return data.free[num].rarityBonus;
				}
			}
			return 0;
		}
	}

	public int treasureStarLevel
	{
		get
		{
			for (int num = Mathf.Min(rewardPoints, data.free.Length) - 1; num >= 0; num--)
			{
				if (data.free[num].IsSpecialEventTreasure())
				{
					return data.free[num].level;
				}
			}
			return 0;
		}
	}

	public DateTime eventStartDate { get; set; }

	public void AddRewardPoints(int amount)
	{
		previousPoints = rewardPoints;
		rewardPoints += amount;
	}

	public List<Item> GetEarnedPremiumItems(bool groupTreasures = false)
	{
		List<Item> list = new List<Item>();
		Dictionary<string, Item> dict = new Dictionary<string, Item>();
		possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		_Collect(list, dict, data.premium, claimedPremiumIndex, groupTreasures);
		return list;
	}

	public List<Item> CollectRewards(bool includePremium)
	{
		List<Item> list = new List<Item>();
		Dictionary<string, Item> dict = new Dictionary<string, Item>();
		possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		_Collect(list, dict, data.free, claimedFreeIndex);
		if (includePremium)
		{
			_Collect(list, dict, data.premium, claimedPremiumIndex);
		}
		int num = Mathf.Clamp(treasureRarityBonus, 1, 16);
		int num2 = Mathf.Clamp(treasureStarLevel, 1, 11);
		EventTreasureItem eventTreasureItem = TreasureFactory.singleton.MakeShinyTreasure(num, num2, "treasure_event") as EventTreasureItem;
		eventTreasureItem.signature = data.GetSignature(eventStartDate);
		eventTreasureItem.maxEnchantmentBonus = num;
		eventTreasureItem.maxTreasureLevel = num2;
		list.Add(eventTreasureItem);
		return list;
	}

	private void _Collect(List<Item> rewards, Dictionary<string, Item> dict, Data.EventReward[] rewardSet, int claimedIndex, bool groupTreasures = false)
	{
		for (int i = 0; i < rewardSet.Length; i++)
		{
			if (debugFakeRewardPoints >= 1)
			{
				if (i >= debugFakeRewardPoints)
				{
					break;
				}
			}
			else if (i >= rewardPoints)
			{
				break;
			}
			Data.EventReward eventReward = rewardSet[i];
			if (!eventReward.IsSpecialEventTreasure() && i > claimedIndex)
			{
				string text = eventReward.itemId;
				if (eventReward.IsTreasure() && !groupTreasures)
				{
					text = text + "_" + rewards.Count;
				}
				if (eventReward.rarityBonus > 0)
				{
					text = text + "r" + eventReward.rarityBonus;
				}
				if (eventReward.level > 1)
				{
					text = text + "L" + eventReward.level;
				}
				if (eventReward.element != ItemData.Element.Stone)
				{
					text = text + "e" + eventReward.element;
				}
				if (dict.ContainsKey(text))
				{
					dict[text].count += eventReward.count;
					continue;
				}
				Item item = InstantiateItem(eventReward, eventStartDate);
				item.count = eventReward.count;
				rewards.Add(item);
				dict.Add(text, item);
			}
		}
	}

	public static Item InstantiateItem(Data.EventReward entryData, DateTime eventStartDate)
	{
		if (entryData.IsTreasure())
		{
			return InstantiateTreasure(entryData);
		}
		if (entryData.cosmeticId != null)
		{
			if (CosmeticController.singleton.FindInventoryCosmetic(entryData.cosmeticId, entryData.itemId, entryData.element) != null)
			{
				return TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_gold", null);
			}
			CosmeticController.Collection collection = CosmeticController.singleton.GetCollection(entryData.cosmeticId);
			CosmeticController.ItemEntry itemEntry = new CosmeticController.ItemEntry(entryData.itemId, entryData.element);
			Cosmetic result = CosmeticController.singleton.InstantiateCosmeticItem(itemEntry, collection);
			CosmeticController.singleton.MarkAsCollected(itemEntry, collection);
			return result;
		}
		ItemData.Rarity rarity = null;
		if (entryData.rarityBonus > 0)
		{
			rarity = new ItemData.Rarity();
			rarity.levelBonus = entryData.rarityBonus;
			rarity.type = ItemData.Rarity.GetTypeForBonus(entryData.rarityBonus);
			rarity.quality = ItemData.Rarity.GetQualityThreshold(entryData.rarityBonus);
			rarity.isPerfect = ItemData.Rarity.IsBonusPerfect(entryData.rarityBonus);
		}
		int level = ItemFactory.CalculateItemLevelFromDisplayLevel(entryData.level);
		Item item = ItemFactory.singleton.MakeItemWithLevelAndAbilities(entryData.itemId, level, entryData.element, -1, rarity);
		item.count = entryData.count;
		item.signature = entryData.GetSignature(eventStartDate);
		return item;
	}

	private static TreasureItem InstantiateTreasure(Data.EventReward entryData)
	{
		return TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", entryData.itemId, possibleElements, entryData.treasureItems);
	}

	public void ClearProgress()
	{
		previousPoints = 0;
		rewardPoints = 0;
		claimedFreeIndex = -1;
		claimedPremiumIndex = -1;
		eventStartDate = DateTime.Now;
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		rewardPoints = SlimJson.ParseInt(sjson, "rp");
		previousPoints = rewardPoints;
		claimedFreeIndex = SlimJson.ParseInt(sjson, "cfi", -1);
		claimedPremiumIndex = SlimJson.ParseInt(sjson, "cpi", -1);
		eventStartDate = SlimJson.ParseDateTime(sjson, "esd", DateTime.Now);
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("rp", rewardPoints);
		if (claimedFreeIndex >= 0)
		{
			SlimJson.AddProperty("cfi", claimedFreeIndex);
		}
		if (claimedPremiumIndex >= 0)
		{
			SlimJson.AddProperty("cpi", claimedPremiumIndex);
		}
		SlimJson.AddProperty("esd", eventStartDate);
		return SlimJson.EndSerialization();
	}
}
