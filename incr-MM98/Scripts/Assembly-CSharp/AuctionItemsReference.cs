using System;
using System.Collections.Generic;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using ZLinq;

public static class AuctionItemsReference
{
	private readonly struct ItemKey : IEquatable<ItemKey>
	{
		private readonly LootItemCategory _category;

		private readonly LootItemQuality _quality;

		public ItemKey(LootItemCategory category, LootItemQuality quality)
		{
			_category = category;
			_quality = quality;
		}

		public bool Equals(ItemKey other)
		{
			if (_category == other._category)
			{
				return _quality == other._quality;
			}
			return false;
		}
	}

	private static readonly Dictionary<ItemKey, List<LocalizedString>> categorized = new Dictionary<ItemKey, List<LocalizedString>>();

	public static async UniTaskVoid Initialize()
	{
		categorized.Clear();
		foreach (KeyValuePair<long, StringTableEntry> item in await LocalizationSettings.StringDatabase.GetTableAsync(LocTable.Loot.Value()).ToUniTask())
		{
			item.Deconstruct(out var _, out var value);
			StringTableEntry stringTableEntry = value;
			string[] array = stringTableEntry.SharedEntry.Key.Split("_");
			if (array.Length != 4)
			{
				Debug.LogError("Loot table entry '" + stringTableEntry.SharedEntry.Key + "' has malformed format. Expecting 'loot_CATEGORY_QUALITY_INDEX' as format.");
				break;
			}
			if (!Enum.TryParse<LootItemCategory>(array[1].ToPascalCase(), out var result))
			{
				Debug.LogError("Loot table entry '" + stringTableEntry.SharedEntry.Key + "' has unexpected category value: " + array[1] + ".");
				break;
			}
			if (!Enum.TryParse<LootItemQuality>(array[2].ToPascalCase(), out var result2))
			{
				Debug.LogError("Loot table entry '" + stringTableEntry.SharedEntry.Key + "' has unexpected quality value: " + array[2] + ".");
				break;
			}
			ItemKey key2 = new ItemKey(result, result2);
			if (!categorized.ContainsKey(key2))
			{
				categorized[key2] = new List<LocalizedString>();
			}
			categorized[key2].Add(new LocalizedString(stringTableEntry.Table.SharedData.TableCollectionNameGuid, stringTableEntry.KeyId));
		}
	}

	public static string GetRandomName(LootItemCategory category, LootItemQuality quality)
	{
		List<LocalizedString> value;
		LocalizedString localizedString = (categorized.TryGetValue(new ItemKey(category, quality), out value) ? value.AsValueEnumerable().Random() : new LocalizedString());
		string arg = ((quality == LootItemQuality.Legendary) ? "<wave>" : string.Empty);
		string arg2 = ColorUtility.ToHtmlStringRGB(quality.Value());
		return ZString.Format("{0}<color=#{1}>{2}", arg, arg2, localizedString.GetLocalizedString());
	}
}
