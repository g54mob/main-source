using System.Collections.Generic;
using System.Linq;

public class DictionaryTimer<TKey>
{
	private readonly Dictionary<TKey, float> _dictionary = new Dictionary<TKey, float>();

	private readonly List<TKey> _cache = new List<TKey>();

	public void Add(TKey key, float duration)
	{
		_dictionary[key] = duration;
	}

	public bool Contains(TKey key)
	{
		return _dictionary.ContainsKey(key);
	}

	public IEnumerable<TKey> AdvanceTime(float deltaTime)
	{
		_cache.Clear();
		foreach (TKey item in _dictionary.Keys.ToList())
		{
			float num = _dictionary[item] - deltaTime;
			if (num > 0f)
			{
				_dictionary[item] = num;
				continue;
			}
			_cache.Add(item);
			_dictionary.Remove(item);
		}
		return _cache;
	}

	public void Clear()
	{
		_dictionary.Clear();
	}

	public void Remove(TKey key)
	{
		_dictionary.Remove(key);
	}
}
