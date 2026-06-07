using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class ItemFilterPersistentData
{
	private Dictionary<int, bool> _itemFilter;

	[OptionalField(VersionAdded = 2)]
	private int _categoryIndex;

	public int CategoryIndex => _categoryIndex;

	public ItemFilterPersistentData(Dictionary<ItemProperties, bool> itemFilter, int categoryIndex = 0)
	{
		Dictionary<ItemProperties, bool>.Enumerator enumerator = itemFilter.GetEnumerator();
		_itemFilter = new Dictionary<int, bool>(itemFilter.Count);
		_categoryIndex = categoryIndex;
		while (enumerator.MoveNext())
		{
			int num = GameManager.PersistenceManager.ReturnPropertiesIndex(enumerator.Current.Key);
			if (num != -1)
			{
				_itemFilter.Add(num, enumerator.Current.Value);
			}
		}
	}

	public void Restore(Dictionary<ItemProperties, bool> itemFilter)
	{
		if (_itemFilter == null)
		{
			return;
		}
		Dictionary<int, bool>.Enumerator enumerator = _itemFilter.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(enumerator.Current.Key, out var reference) && itemFilter.ContainsKey(reference))
			{
				itemFilter[reference] = enumerator.Current.Value;
			}
		}
	}
}
