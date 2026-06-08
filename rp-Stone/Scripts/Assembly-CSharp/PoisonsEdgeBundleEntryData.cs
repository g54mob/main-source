using System.Collections.Generic;

public class PoisonsEdgeBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item sword;

	public override bool CheckStartConditions()
	{
		return true;
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
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		obj.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_4", possibleElements));
		Item item = ItemFactory.singleton.MakeItem("ki");
		item.count = 10000;
		obj.Add(item);
		return obj;
	}

	private void InitSword()
	{
		if (!(sword != null))
		{
			string nameTag = Te.xt("tid_shop_poisons_edge_0");
			string signature = Te.xt("tid_shop_indie_patron");
			int num = 5;
			string text = "socketed_long_sword";
			ItemData.Element element = ItemData.Element.Poison;
			int num2 = 0;
			int selectedStatSeed = 4;
			ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num))
			{
				levelBonus = num,
				quality = ItemData.Rarity.GetQualityThreshold(num),
				isPerfect = ItemData.Rarity.IsBonusPerfect(num),
				selectedStatSeed = selectedStatSeed
			};
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(4f);
			sword = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, element, num2, rarity);
			sword.nameTag = nameTag;
			sword.signature = signature;
			sword.isShiny = true;
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
