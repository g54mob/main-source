using System.Collections.Generic;
using UnityEngine;

public class SSItemStatic : StonescriptObject
{
	public SSItemStatic()
		: base("Item")
	{
		DeclareFunction(New);
	}

	public static object New(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("Item.New requires at least an item id.");
		}
		int num = 0;
		string itemId = parameters[num++] as string;
		Item item = null;
		if (parameters.Count == 2 && parameters[0] is string && parameters[1] is string)
		{
			itemId = parameters[0] as string;
			string sjson = parameters[1] as string;
			item = ItemFactory.singleton.MakeItem(itemId);
			item.ParseData(sjson);
			item.LoadAbilities();
			return item.ssObject;
		}
		ItemData.Element element = ItemData.Element.Stone;
		int num2 = 1;
		int num3 = 1;
		int num4 = 0;
		ItemData.Rarity rarity = null;
		if (parameters.Count > num && parameters[num] is string)
		{
			element = ItemData.ParseElement(parameters[num++] as string, ignoreCase: true);
		}
		num2 = ((parameters.Count <= num || !(parameters[num] is int)) ? 1 : ((int)parameters[num++]));
		num4 = ((parameters.Count > num && parameters[num] is int) ? ((int)parameters[num++]) : 0);
		num3 = ((parameters.Count <= num || !(parameters[num] is int)) ? 1 : ((int)parameters[num++]));
		if (num4 >= 1)
		{
			rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(num4));
			rarity.levelBonus = num4;
			rarity.quality = ItemData.Rarity.GetQualityThreshold(num4);
			rarity.isPerfect = ItemData.Rarity.IsBonusPerfect(num4);
		}
		item = ItemFactory.singleton.MakeItemWithLevelAndAbilities(itemId, num2, element, Random.Range(0, 50), rarity);
		item.count = num3;
		item.LoadAbilities();
		if (item is TreasureItem)
		{
			List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
			TreasureItem treasureItem = item as TreasureItem;
			treasureItem.itemsInTreasure = TreasureFactory.singleton.MakeShopTreasureData("mushroom_shop", treasureItem.type, possibleElements);
		}
		return item.ssObject;
	}
}
