using System.Collections.Generic;

public class MultiDictionary<K, V> : Dictionary<K, HashSet<V>>
{
	public void Add(K key, V value)
	{
		HashSet<V> value2 = null;
		if (!TryGetValue(key, out value2))
		{
			value2 = new HashSet<V>();
			Add(key, value2);
		}
		value2.Add(value);
	}

	public bool ContainsValue(K key, V value)
	{
		HashSet<V> value2 = null;
		if (TryGetValue(key, out value2))
		{
			return value2.Contains(value);
		}
		return false;
	}

	public void Remove(K key, V value)
	{
		HashSet<V> value2 = null;
		if (TryGetValue(key, out value2))
		{
			value2.Remove(value);
			if (value2.Count <= 0)
			{
				Remove(key);
			}
		}
	}

	public HashSet<V> GetValues(K key)
	{
		HashSet<V> value = null;
		TryGetValue(key, out value);
		return value;
	}
}
