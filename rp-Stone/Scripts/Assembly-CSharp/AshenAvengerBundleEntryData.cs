using System.Collections.Generic;

public class AshenAvengerBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item shield;

	public override bool CheckStartConditions()
	{
		return QuestController.singleton.IsAvailable("icy_ridge");
	}

	public override Item MakeInventoryItem()
	{
		InitShield();
		return shield;
	}

	public override List<Item> GetItems()
	{
		InitShield();
		List<Item> list = new List<Item> { shield };
		list.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "lost", null));
		_AddItem(list, "sword");
		_AddItem(list, "shield");
		_AddItem(list, "crossbow");
		_AddItem(list, "quarterstaff");
		_AddItem(list, "wand");
		return list;
	}

	private void _AddItem(List<Item> items, string itemId)
	{
		Item item = ItemFactory.singleton.MakeItem(itemId);
		item.count = 64;
		items.Add(item);
	}

	private void InitShield()
	{
		if (!(shield != null))
		{
			string nameTag = Te.xt("tid_shop_ashen_0");
			string signature = Te.xt("tid_shop_indie_patron");
			int num = 8;
			string text = "socketed_shield";
			ItemData.Element element = ItemData.Element.Fire;
			int num2 = 1;
			int selectedStatSeed = 0;
			ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num))
			{
				levelBonus = num,
				quality = ItemData.Rarity.GetQualityThreshold(num),
				isPerfect = ItemData.Rarity.IsBonusPerfect(num),
				selectedStatSeed = selectedStatSeed
			};
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(4f);
			shield = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, element, num2, rarity);
			shield.nameTag = nameTag;
			shield.signature = signature;
			shield.isShiny = true;
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
