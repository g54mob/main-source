using System;
using System.Collections.Generic;

[Serializable]
public class LimitPersistentData
{
	private Dictionary<int, int> _limitDictionary = new Dictionary<int, int>();

	public LimitPersistentData()
	{
		foreach (KeyValuePair<ItemProperties, int> item in GameManager.ResourceManager.ReturnResourceLimits())
		{
			_limitDictionary.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(item.Key), item.Value);
		}
	}

	public void Restore()
	{
		Dictionary<ItemProperties, int> dictionary = new Dictionary<ItemProperties, int>();
		foreach (KeyValuePair<int, int> item in _limitDictionary)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(item.Key, out var reference))
			{
				dictionary.Add(reference, item.Value);
			}
		}
		GameManager.ResourceManager.RestoreResourceLimits(dictionary);
	}
}
