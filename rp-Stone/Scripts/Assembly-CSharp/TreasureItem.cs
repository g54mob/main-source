using System;
using System.Collections.Generic;
using System.IO;

public class TreasureItem : Item
{
	public enum Type
	{
		Humble = 0,
		Common = 1,
		Giant = 2,
		Rare = 3,
		Epic = 4,
		Bone = 5,
		Element = 6,
		Lost = 7,
		Ki = 8,
		Gold = 9,
		Skullnata = 10,
		Emerald = 11,
		Sapphire = 12,
		Ruby = 13,
		Prismatic = 14
	}

	public class Reward
	{
		public Item item;

		public int count;

		public bool isKiCrystal;

		public bool isDoubleKi;
	}

	public Type type = Type.Common;

	private string _randomSuffix;

	public Data.ItemInTreasure[] itemsInTreasure;

	private static List<Reward> rewardsWorkList = new List<Reward>();

	private List<Item> itemsGained = new List<Item>();

	private List<int> itemAmountsGained = new List<int>();

	private string randomSuffix
	{
		get
		{
			if (_randomSuffix == null)
			{
				_randomSuffix = Path.GetRandomFileName();
			}
			return _randomSuffix;
		}
		set
		{
			_randomSuffix = value;
		}
	}

	public static event Action<string, string, List<Item>, List<int>> OnTreasureOpened;

	public override string GetGroupId()
	{
		return "treasure_" + randomSuffix;
	}

	public override ItemData.Rarity.Type GetRarityType()
	{
		return FindBestRarityInItems(itemsInTreasure);
	}

	public static ItemData.Rarity.Type FindBestRarityInItems(Data.ItemInTreasure[] items)
	{
		ItemData.Rarity.Type type = ItemData.Rarity.Type.Common;
		foreach (Data.ItemInTreasure itemInTreasure in items)
		{
			if (itemInTreasure.showTreasureColor && itemInTreasure.rarityType > type)
			{
				type = itemInTreasure.rarityType;
			}
		}
		return type;
	}

	public List<Reward> MakeAllRewards()
	{
		rewardsWorkList.Clear();
		for (int i = 0; i < itemsInTreasure.Length; i++)
		{
			Reward item = MakeRewardAt(i);
			rewardsWorkList.Add(item);
		}
		return rewardsWorkList;
	}

	public Reward MakeRewardAt(int rewardIndex)
	{
		Data.ItemInTreasure itemInTreasure = itemsInTreasure[rewardIndex];
		if (type == Type.Gold)
		{
			return MakeCosmeticReward(rewardIndex);
		}
		if (type == Type.Prismatic)
		{
			return MakeCosmeticReward(rewardIndex, "prismatic");
		}
		Reward reward = new Reward();
		reward.item = Inventory.Singleton.MakeReward(itemInTreasure);
		reward.count = Utils.random.Next(itemInTreasure.countMin, itemInTreasure.countMax + 1);
		reward.isKiCrystal = reward.item.id == "ki_crystal";
		if (EventController.singleton.IsEventActive("2xKi") && (reward.isKiCrystal || reward.item.id == "ki"))
		{
			reward.isDoubleKi = true;
		}
		if (reward.isKiCrystal && reward.isDoubleKi && type == Type.Lost)
		{
			reward.count /= 2;
		}
		reward.item.isShiny = base.isShiny && reward.item.GetRarityBonus() > 0;
		if (base.isSigned && !reward.isKiCrystal)
		{
			reward.item.signature = base.signature;
		}
		return reward;
	}

	public void GrantRewards(List<Reward> rewardsToAdd)
	{
		itemsGained.Clear();
		itemAmountsGained.Clear();
		for (int i = 0; i < rewardsToAdd.Count; i++)
		{
			Reward reward = rewardsToAdd[i];
			if (reward.item.id == "ki")
			{
				InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, reward.count);
			}
			else if (!(reward.item is Cosmetic))
			{
				Item item = Inventory.Singleton.GainItem(reward.item, reward.count);
				itemsGained.Add(item);
				itemAmountsGained.Add(reward.count);
			}
		}
		rewardsToAdd.Clear();
		Inventory.Singleton.RemoveItem(this);
		GameStates.Singleton.itemScreen.NeedsRefresh();
		TreasureItem.OnTreasureOpened?.Invoke(id, GetGroupId(), itemsGained, itemAmountsGained);
	}

	private Reward MakeCosmeticReward(int rewardIndex, string collectionId = null)
	{
		Reward reward = new Reward();
		if (CosmeticController.singleton.HasCosmeticsToDrop(countFinalCollectionItems: true, collectionId))
		{
			reward.item = CosmeticController.singleton.AddRandomCosmeticToInventory(Utils.random, collectionId);
		}
		else if (Utils.random.Next(2) == 0)
		{
			reward.item = ItemFactory.singleton.MakeItem("name_tag");
		}
		else
		{
			reward.item = ItemFactory.singleton.MakeItem("shiny");
		}
		reward.count = 1;
		return reward;
	}

	public override void SerializeMore()
	{
		SlimJson.AddProperty("rS", randomSuffix);
		SlimJson.AddProperty("itms", itemsInTreasure);
	}

	public override void ParseMore(string sjson)
	{
		if (SlimJson.HasKey(sjson, "randomSuffix"))
		{
			randomSuffix = SlimJson.Parse(sjson, "randomSuffix");
			itemsInTreasure = SlimJson.ParseArray(sjson, "items_in_treasure", Data.ItemInTreasure.FromJson);
		}
		else
		{
			randomSuffix = SlimJson.Parse(sjson, "rS");
			itemsInTreasure = SlimJson.ParseArray(sjson, "itms", Data.ItemInTreasure.FromJson);
		}
	}
}
