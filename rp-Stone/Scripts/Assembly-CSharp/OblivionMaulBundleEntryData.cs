using System.Collections.Generic;

public class OblivionMaulBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item hammer;

	public override bool CheckStartConditions()
	{
		return QuestController.singleton.IsAvailable("bronze_mine");
	}

	public override Item MakeInventoryItem()
	{
		InitHammer();
		return hammer;
	}

	public override List<Item> GetItems()
	{
		InitHammer();
		List<Item> list = new List<Item> { hammer };
		list.Add(TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_gold", null));
		_AddRes(list, "stone");
		_AddRes(list, "wood");
		_AddRes(list, "tar");
		_AddRes(list, "bronze");
		return list;
	}

	private void _AddRes(List<Item> items, string resId)
	{
		Item item = ItemFactory.singleton.MakeItem(resId);
		item.count = 3000;
		items.Add(item);
	}

	private void InitHammer()
	{
		if (!(hammer != null))
		{
			string nameTag = Te.xt("tid_shop_oblivion_0");
			string signature = Te.xt("tid_shop_indie_patron");
			int num = 7;
			string text = "socketed_hammer";
			ItemData.Element element = ItemData.Element.AEther;
			int num2 = 13;
			int selectedStatSeed = 6;
			ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num))
			{
				levelBonus = num,
				quality = ItemData.Rarity.GetQualityThreshold(num),
				isPerfect = ItemData.Rarity.IsBonusPerfect(num),
				selectedStatSeed = selectedStatSeed
			};
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(5f);
			hammer = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, element, num2, rarity);
			hammer.nameTag = nameTag;
			hammer.signature = signature;
			hammer.isShiny = true;
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
