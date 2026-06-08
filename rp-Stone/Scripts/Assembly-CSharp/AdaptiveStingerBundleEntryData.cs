using System.Collections.Generic;

public class AdaptiveStingerBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item sword;

	public override bool CheckStartConditions()
	{
		return false;
	}

	public override Item MakeInventoryItem()
	{
		InitSword();
		return sword;
	}

	public override List<Item> GetItems()
	{
		InitSword();
		List<Item> obj = new List<Item> { sword };
		sword.cosmeticId = "prismatic";
		sword.cosmetic = CosmeticController.singleton.GetCosmeticPrefab("prismatic");
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId(sword.id);
		if (firstItemWithId != null)
		{
			firstItemWithId.signature = sword.signature;
			firstItemWithId.cosmeticId = sword.cosmeticId;
			firstItemWithId.cosmetic = sword.cosmetic;
		}
		if (CosmeticController.singleton.FindInventoryCosmetic("prismatic", sword.id, ItemData.Element.Stone) == null)
		{
			CosmeticController.Collection collection = CosmeticController.singleton.GetCollection("prismatic");
			CosmeticController.ItemEntry chosenItemEntry = new CosmeticController.ItemEntry(sword.id, ItemData.Element.Stone);
			CosmeticController.singleton.MakeCosmeticAndAddToInventory(chosenItemEntry, collection).targetItem.appliedGroupId = sword.GetGroupId();
		}
		obj.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "ki_treasure", null));
		Item item = ItemFactory.singleton.MakeItem("moonbloom");
		item.count = 1;
		obj.Add(item);
		return obj;
	}

	private void InitSword()
	{
		if (!(sword != null))
		{
			string signature = Te.xt("tid_shop_indie_patron");
			int num = 10;
			string text = "adaptive_stinger";
			int selectedStatSeed = 2;
			ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num))
			{
				levelBonus = num,
				quality = ItemData.Rarity.GetQualityThreshold(num),
				isPerfect = ItemData.Rarity.IsBonusPerfect(num),
				selectedStatSeed = selectedStatSeed
			};
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(6f);
			sword = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, ItemData.Element.Stone, selectedStatSeed, rarity);
			sword.signature = signature;
		}
	}

	public override void ParseEntry(string sjson)
	{
		base.ParseEntry(sjson);
	}

	public override void SerializeEntry()
	{
		base.SerializeEntry();
	}
}
