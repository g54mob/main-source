using System.Collections.Generic;

public class SaveKeyValueList
{
	public static Dictionary<string, int> ToDictionary(List<SaveKeyValueItem> items)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (SaveKeyValueItem item in items)
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	public static List<SaveKeyValueItem> FromDictionary(Dictionary<string, int> items)
	{
		List<SaveKeyValueItem> list = new List<SaveKeyValueItem>();
		foreach (string key in items.Keys)
		{
			SaveKeyValueItem saveKeyValueItem = new SaveKeyValueItem();
			saveKeyValueItem.Key = key;
			saveKeyValueItem.Value = items[key];
			list.Add(saveKeyValueItem);
		}
		return list;
	}
}
