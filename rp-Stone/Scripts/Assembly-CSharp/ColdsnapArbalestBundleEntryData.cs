using System.Collections.Generic;

public class ColdsnapArbalestBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item crossbow;

	public override bool CheckStartConditions()
	{
		return QuestController.singleton.IsAvailable("temple");
	}

	public override Item MakeInventoryItem()
	{
		InitCrossbow();
		return crossbow;
	}

	public override List<Item> GetItems()
	{
		InitCrossbow();
		List<Item> obj = new List<Item>
		{
			crossbow,
			TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "lost", null),
			TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "lost", null)
		};
		Item item = ItemFactory.singleton.MakeItem("name_tag");
		item.count = 1;
		obj.Add(item);
		return obj;
	}

	private void InitCrossbow()
	{
		if (!(crossbow != null))
		{
			string nameTag = Te.xt("tid_shop_coldsnap_0");
			string signature = Te.xt("tid_shop_indie_patron");
			int num = 8;
			string text = "socketed_crossbow";
			ItemData.Element element = ItemData.Element.Ice;
			int num2 = 1;
			int selectedStatSeed = 3;
			ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num))
			{
				levelBonus = num,
				quality = ItemData.Rarity.GetQualityThreshold(num),
				isPerfect = ItemData.Rarity.IsBonusPerfect(num),
				selectedStatSeed = selectedStatSeed
			};
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(5f);
			crossbow = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, element, num2, rarity);
			crossbow.nameTag = nameTag;
			crossbow.signature = signature;
			crossbow.isShiny = true;
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
