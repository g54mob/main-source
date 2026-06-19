using System.Collections.Generic;

public class TwoWayDictionary<TKey, TValue>
{
	private readonly Dictionary<TKey, TValue> keyToValue = new Dictionary<TKey, TValue>();

	private readonly Dictionary<TValue, TKey> valueToKey = new Dictionary<TValue, TKey>();

	public Dictionary<TKey, TValue> Values => keyToValue;

	public void Add(TKey key, TValue value)
	{
		keyToValue[key] = value;
		valueToKey[value] = key;
	}

	public bool TryGetByKey(TKey key, out TValue value)
	{
		return keyToValue.TryGetValue(key, out value);
	}

	public bool TryGetByValue(TValue value, out TKey key)
	{
		return valueToKey.TryGetValue(value, out key);
	}

	public void Clear()
	{
		keyToValue.Clear();
		valueToKey.Clear();
	}

	public void Remove(TKey key)
	{
		if (keyToValue.ContainsKey(key))
		{
			TValue key2 = keyToValue[key];
			keyToValue.Remove(key);
			valueToKey.Remove(key2);
		}
	}

	public void Remove(TValue value)
	{
		if (valueToKey.ContainsKey(value))
		{
			TKey key = valueToKey[value];
			valueToKey.Remove(value);
			keyToValue.Remove(key);
		}
	}
}
