using System.Collections.Generic;
using UnityEngine;

public static class LootItemCategoryDataExtension
{
	private static readonly Dictionary<LootItemCategory, Sprite[]> data;

	static LootItemCategoryDataExtension()
	{
		data = new Dictionary<LootItemCategory, Sprite[]>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/Loot/LootItemCategory");
		data.Add(LootItemCategory.Sword, (Sprite[])scriptableAssetEnum.Data[0].Value);
		data.Add(LootItemCategory.Bow, (Sprite[])scriptableAssetEnum.Data[1].Value);
	}

	public static Sprite[] Value(this LootItemCategory key)
	{
		return data[key];
	}
}
