using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class WriteDictionary : IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	public readonly string Name;

	private Dictionary<string, object> Values = new Dictionary<string, object>();

	public int Count
	{
		get
		{
			return Values.Count;
		}
	}

	public object this[string key]
	{
		get
		{
			object value;
			if (!Values.TryGetValue(key, out value))
			{
				return null;
			}
			return value;
		}
		set
		{
			Values[key] = value;
		}
	}

	public WriteDictionary()
	{
	}

	public WriteDictionary(string name)
	{
		Name = name;
	}

	public T Get<T>(string key, T defaultValue)
	{
		object obj = this[key];
		if (obj == null)
		{
			return defaultValue;
		}
		object obj2;
		if ((obj2 = obj) is T)
		{
			return (T)obj2;
		}
		return defaultValue;
	}

	public T Get<T>(string key)
	{
		object obj = this[key];
		if (obj == null)
		{
			throw new Exception("Entry " + key + " was not present in WriteDictionary");
		}
		object obj2 = obj;
		if (obj is T)
		{
			return (T)obj2;
		}
		throw new Exception("Entry " + key + " was not of type " + typeof(T).Name + " in WriteDictionary");
	}

	public bool TryGet<T>(string key, out T val)
	{
		object value;
		object obj;
		if (Values.TryGetValue(key, out value) && (obj = value) is T)
		{
			T val2 = (T)obj;
			val = val2;
			return true;
		}
		val = default(T);
		return false;
	}

	public bool Remove(string key)
	{
		return Values.Remove(key);
	}

	public bool Contains(string key)
	{
		return Values.ContainsKey(key);
	}

	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		return Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Values.GetEnumerator();
	}
}
