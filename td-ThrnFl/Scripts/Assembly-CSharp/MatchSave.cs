using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MatchSave
{
	[Serializable]
	private class SerializableDictionaryValue<T>
	{
		public string key;

		public T value;

		public SerializableDictionaryValue(string _key, T _value)
		{
			key = _key;
			value = _value;
		}
	}

	public int etSeed;

	public int highestScoreThisRun;

	public bool runComplete;

	public bool hadRestarts;

	private Dictionary<string, object> savedEntities = new Dictionary<string, object>();

	public List<Equippable> currentLoadout = new List<Equippable>();

	[SerializeField]
	private List<SerializableDictionaryValue<string>> stringsToSerialize = new List<SerializableDictionaryValue<string>>();

	[SerializeField]
	private List<SerializableDictionaryValue<int>> intsToSerialize = new List<SerializableDictionaryValue<int>>();

	[SerializeField]
	private List<SerializableDictionaryValue<bool>> boolsToSerialize = new List<SerializableDictionaryValue<bool>>();

	[SerializeField]
	private List<SerializableDictionaryValue<float>> floatsToSerialize = new List<SerializableDictionaryValue<float>>();

	[SerializeField]
	private List<SerializableDictionaryValue<int[]>> intArraysToSerialize = new List<SerializableDictionaryValue<int[]>>();

	[SerializeField]
	private List<SerializableDictionaryValue<TagManager.ETag[]>> tagArraysToSerialize = new List<SerializableDictionaryValue<TagManager.ETag[]>>();

	[SerializeField]
	private List<string> currentLoadoutAsString;

	public bool TryLoadValue<T>(string identifier, ref T value)
	{
		if (savedEntities.TryGetValue(identifier, out var value2))
		{
			if (value2 is T)
			{
				value = (T)value2;
				return true;
			}
			return false;
		}
		return false;
	}

	public void AddValue<T>(string identifier, T value)
	{
		if (savedEntities.ContainsKey(identifier))
		{
			savedEntities[identifier] = value;
		}
		else
		{
			savedEntities.Add(identifier, value);
		}
	}

	public void ConvertObjectDataToStrings()
	{
		FetchLoadout();
		stringsToSerialize.Clear();
		boolsToSerialize.Clear();
		intsToSerialize.Clear();
		floatsToSerialize.Clear();
		intArraysToSerialize.Clear();
		tagArraysToSerialize.Clear();
		foreach (KeyValuePair<string, object> savedEntity in savedEntities)
		{
			if (savedEntity.Value is string)
			{
				stringsToSerialize.Add(new SerializableDictionaryValue<string>(savedEntity.Key, (string)savedEntity.Value));
			}
			else if (savedEntity.Value is int)
			{
				intsToSerialize.Add(new SerializableDictionaryValue<int>(savedEntity.Key, (int)savedEntity.Value));
			}
			else if (savedEntity.Value is bool)
			{
				boolsToSerialize.Add(new SerializableDictionaryValue<bool>(savedEntity.Key, (bool)savedEntity.Value));
			}
			else if (savedEntity.Value is float)
			{
				floatsToSerialize.Add(new SerializableDictionaryValue<float>(savedEntity.Key, (float)savedEntity.Value));
			}
			else if (savedEntity.Value is int[])
			{
				intArraysToSerialize.Add(new SerializableDictionaryValue<int[]>(savedEntity.Key, (int[])savedEntity.Value));
			}
			else if (savedEntity.Value is TagManager.ETag[])
			{
				tagArraysToSerialize.Add(new SerializableDictionaryValue<TagManager.ETag[]>(savedEntity.Key, (TagManager.ETag[])savedEntity.Value));
			}
		}
		currentLoadoutAsString = new List<string>();
		foreach (Equippable item in currentLoadout)
		{
			currentLoadoutAsString.Add(item.displayName);
		}
	}

	public void ConvertStringsToObjectData()
	{
		savedEntities.Clear();
		foreach (SerializableDictionaryValue<string> item in stringsToSerialize)
		{
			savedEntities.Add(item.key, item.value);
		}
		foreach (SerializableDictionaryValue<int> item2 in intsToSerialize)
		{
			savedEntities.Add(item2.key, item2.value);
		}
		foreach (SerializableDictionaryValue<float> item3 in floatsToSerialize)
		{
			savedEntities.Add(item3.key, item3.value);
		}
		foreach (SerializableDictionaryValue<bool> item4 in boolsToSerialize)
		{
			savedEntities.Add(item4.key, item4.value);
		}
		foreach (SerializableDictionaryValue<int[]> item5 in intArraysToSerialize)
		{
			savedEntities.Add(item5.key, item5.value);
		}
		foreach (SerializableDictionaryValue<TagManager.ETag[]> item6 in tagArraysToSerialize)
		{
			savedEntities.Add(item6.key, item6.value);
		}
		currentLoadout = new List<Equippable>();
		foreach (string item7 in currentLoadoutAsString)
		{
			foreach (Equippable allEquippable in PerkManager.instance.allEquippables)
			{
				if (allEquippable != null && allEquippable.displayName == item7)
				{
					currentLoadout.Add(allEquippable);
					break;
				}
			}
		}
		ApplyLoadout();
	}

	public void ApplyLoadout()
	{
		PerkManager.ClearAllEquipped();
		foreach (Equippable item in currentLoadout)
		{
			PerkManager.SetEquipped(item, _equipped: true);
		}
	}

	public void FetchLoadout()
	{
		currentLoadout = new List<Equippable>();
		currentLoadout.AddRange(PerkManager.instance.CurrentlyEquipped);
	}
}
