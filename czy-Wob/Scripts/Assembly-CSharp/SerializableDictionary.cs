using System;
using System.Collections.Generic;

[Serializable]
public class SerializableDictionary<T, T2>
{
	public List<T> keys = new List<T>();

	public List<T2> values = new List<T2>();

	public SerializableDictionary(Dictionary<T, T2> dict)
	{
		Save(dict);
	}

	public void Save(Dictionary<T, T2> dict)
	{
		keys.AddRange(dict.Keys);
		for (int i = 0; i < keys.Count; i++)
		{
			values.Add(dict[keys[i]]);
		}
	}

	public void Load(Dictionary<T, T2> dict)
	{
		dict.Clear();
		for (int i = 0; i < keys.Count; i++)
		{
			dict[keys[i]] = values[i];
		}
	}

	public SerializableDictionary<T, T2> GetCopy()
	{
		Dictionary<T, T2> dict = new Dictionary<T, T2>();
		Load(dict);
		return new SerializableDictionary<T, T2>(dict);
	}
}
