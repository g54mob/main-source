using System.Collections.Generic;

public class TitanicBundleEntryData : ShopData.LimitedTimeBundle
{
	private Item blade;

	public bool hasSeenTitanicBundle { get; set; }

	public override bool CheckStartConditions()
	{
		if (QuestController.singleton.IsAvailable("bronze_mine"))
		{
			return CosmeticController.singleton.GetOwnedCosmeticItemEntry("golden", "blade_of_god") == null;
		}
		return false;
	}

	public override Item MakeInventoryItem()
	{
		InitBlade();
		return blade;
	}

	public override List<Item> GetItems()
	{
		InitBlade();
		List<Item> list = new List<Item> { blade };
		blade.cosmeticId = "golden";
		blade.cosmetic = CosmeticController.singleton.GetCosmeticPrefab("golden");
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId(blade.id);
		if (firstItemWithId != null)
		{
			firstItemWithId.signature = blade.signature;
			firstItemWithId.cosmeticId = blade.cosmeticId;
			firstItemWithId.cosmetic = blade.cosmetic;
		}
		if (CosmeticController.singleton.FindInventoryCosmetic("golden", blade.id, ItemData.Element.Stone) == null)
		{
			CosmeticController.Collection collection = CosmeticController.singleton.GetCollection("golden");
			CosmeticController.singleton.DropFinalItemForCollection(collection).targetItem.appliedGroupId = blade.GetGroupId();
		}
		_AddRunestones(list, ItemData.Element.AEther);
		_AddRunestones(list, ItemData.Element.Fire);
		_AddRunestones(list, ItemData.Element.Ice);
		_AddRunestones(list, ItemData.Element.Poison);
		_AddRunestones(list, ItemData.Element.Vigor);
		_AddItems(list, "wand", ItemData.Element.Stone, 256);
		return list;
	}

	private void _AddRunestones(List<Item> items, ItemData.Element element)
	{
		_AddItems(items, "runestone", element, 256);
	}

	private void _AddItems(List<Item> items, string itemId, ItemData.Element element, int count)
	{
		Item item = ItemFactory.singleton.MakeItem(itemId);
		item.element = element;
		item.count = count;
		items.Add(item);
	}

	private void InitBlade()
	{
		if (!(blade != null))
		{
			string signature = Te.xt("tid_shop_indie_patron");
			string text = "blade_of_god";
			int level = ItemFactory.CalculateItemLevelFromDisplayLevel(6f);
			blade = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, level, ItemData.Element.Stone);
			blade.signature = signature;
		}
	}

	public override void ParseEntry(string sjson)
	{
		base.ParseEntry(sjson);
		hasSeenTitanicBundle = SlimJson.ParseBool(sjson, "hstb");
	}

	public override void SerializeEntry()
	{
		base.SerializeEntry();
		SlimJson.AddProperty("hstb", hasSeenTitanicBundle);
	}
}
