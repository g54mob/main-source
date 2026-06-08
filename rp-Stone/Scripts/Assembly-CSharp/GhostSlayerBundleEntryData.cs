using System.Collections.Generic;

public class GhostSlayerBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item staff;

	public bool hasSeenGhostSlayer { get; set; }

	public bool HasSeenReminder { get; set; }

	public override bool CheckStartConditions()
	{
		return QuestController.singleton.GetStarDifficultyForQuest("fungus_forest") >= 3;
	}

	public override string GetPurchaseId()
	{
		if (base.percentOff == 20)
		{
			return "iap_ghost_slayer_20off";
		}
		if (base.percentOff == 30)
		{
			return "iap_ghost_slayer_30off";
		}
		return base.GetPurchaseId();
	}

	public override Item MakeInventoryItem()
	{
		InitStaff();
		return staff;
	}

	public override List<Item> GetItems()
	{
		InitStaff();
		List<Item> list = new List<Item> { staff };
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		for (int i = 0; i < 5; i++)
		{
			list.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_4", possibleElements));
		}
		for (int j = 0; j < 5; j++)
		{
			list.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_3", possibleElements));
		}
		for (int k = 0; k < 5; k++)
		{
			list.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_2", possibleElements));
		}
		Item item = ItemFactory.singleton.MakeItem("ki");
		item.count = 555;
		list.Add(item);
		return list;
	}

	private void InitStaff()
	{
		if (!(staff != null))
		{
			string nameTag = Te.xt("tid_shop_ghost_slayer_0");
			string signature = Te.xt("tid_shop_indie_patron");
			int num = 11;
			string text = "socketed_staff";
			ItemData.Element element = ItemData.Element.Vigor;
			int num2 = 83;
			int selectedStatSeed = 3;
			ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num))
			{
				levelBonus = num,
				quality = ItemData.Rarity.GetQualityThreshold(num),
				isPerfect = ItemData.Rarity.IsBonusPerfect(num),
				selectedStatSeed = selectedStatSeed
			};
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(6f);
			staff = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, element, num2, rarity);
			staff.nameTag = nameTag;
			staff.signature = signature;
			staff.isShiny = true;
		}
	}

	public override void ParseEntry(string sjson)
	{
		base.ParseEntry(sjson);
		hasSeenGhostSlayer = SlimJson.ParseBool(sjson, "hsgs");
		HasSeenReminder = SlimJson.ParseBool(sjson, "hsr");
	}

	public override void SerializeEntry()
	{
		base.SerializeEntry();
		SlimJson.AddProperty("hsgs", hasSeenGhostSlayer);
		SlimJson.AddProperty("hsr", HasSeenReminder);
	}
}
