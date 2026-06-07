using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class DictionaryList<T1, T2> : IList<T2>, ICollection<T2>, IEnumerable<T2>, IEnumerable, IDictionary<T1, T2>, ICollection<KeyValuePair<T1, T2>>, IEnumerable<KeyValuePair<T1, T2>>
{
	public Dictionary<T1, int> Dictionary = new Dictionary<T1, int>();

	public List<T2> List = new List<T2>();

	private static List<T1> _removeCache = new List<T1>();

	public T2 this[T1 key]
	{
		get
		{
			return List[Dictionary[key]];
		}
		set
		{
			int value2;
			if (Dictionary.TryGetValue(key, out value2))
			{
				List[value2] = value;
			}
			else
			{
				Add(key, value);
			}
		}
	}

	public ICollection<T1> Keys
	{
		get
		{
			return Dictionary.Keys;
		}
	}

	public ICollection<T2> Values
	{
		get
		{
			return List;
		}
	}

	public int Count
	{
		get
		{
			return List.Count;
		}
	}

	public bool IsReadOnly { get; private set; }

	public T2 this[int index]
	{
		get
		{
			return List[index];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public DictionaryList()
	{
	}

	public DictionaryList(int capacity)
	{
		Dictionary = new Dictionary<T1, int>(capacity);
		List = new List<T2>(capacity);
	}

	public DictionaryList(Dictionary<T1, T2> dict)
	{
		foreach (KeyValuePair<T1, T2> item in dict)
		{
			List.Add(item.Value);
			Dictionary[item.Key] = List.Count - 1;
		}
	}

	public void Add(T1 key, T2 value)
	{
		if (Dictionary.ContainsKey(key))
		{
			throw new ArgumentException("Key already exists");
		}
		List.Add(value);
		Dictionary.Add(key, List.Count - 1);
	}

	public bool ContainsKey(T1 key)
	{
		return Dictionary.ContainsKey(key);
	}

	public bool Remove(T1 key)
	{
		int value;
		if (Dictionary.TryGetValue(key, out value))
		{
			List.RemoveAt(value);
			Dictionary.Remove(key);
			if (Dictionary.Count > 0)
			{
				lock (_removeCache)
				{
					_removeCache.Clear();
					foreach (KeyValuePair<T1, int> item in Dictionary)
					{
						if (item.Value > value)
						{
							_removeCache.Add(item.Key);
						}
					}
					for (int i = 0; i < _removeCache.Count; i++)
					{
						Dictionary[_removeCache[i]]--;
					}
				}
			}
			return true;
		}
		return false;
	}

	public bool TryGetValue(T1 key, out T2 value)
	{
		int value2 = 0;
		if (Dictionary.TryGetValue(key, out value2))
		{
			value = List[value2];
			return true;
		}
		value = default(T2);
		return false;
	}

	public IEnumerator<T2> GetEnumerator()
	{
		return List.GetEnumerator();
	}

	IEnumerator<KeyValuePair<T1, T2>> IEnumerable<KeyValuePair<T1, T2>>.GetEnumerator()
	{
		foreach (KeyValuePair<T1, int> item in Dictionary)
		{
			yield return new KeyValuePair<T1, T2>(item.Key, List[item.Value]);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(T2 item)
	{
		throw new NotImplementedException();
	}

	public void Add(KeyValuePair<T1, T2> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		List.Clear();
		Dictionary.Clear();
	}

	public bool Contains(KeyValuePair<T1, T2> item)
	{
		return Dictionary.ContainsKey(item.Key);
	}

	public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(KeyValuePair<T1, T2> item)
	{
		int value;
		if (Dictionary.TryGetValue(item.Key, out value))
		{
			List.RemoveAt(value);
			Dictionary.Remove(item.Key);
			return true;
		}
		return false;
	}

	public bool Contains(T2 item)
	{
		return List.Contains(item);
	}

	public void CopyTo(T2[] array, int arrayIndex)
	{
		List.CopyTo(array, arrayIndex);
	}

	public bool Remove(T2 item)
	{
		throw new NotImplementedException();
	}

	public int IndexOf(T2 item)
	{
		return List.IndexOf(item);
	}

	public void Insert(int index, T2 item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}
}
