using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AYellowpaper.SerializedCollections
{
	internal class DictionaryLookupTable<TKey, TValue> : IKeyable
	{
		private SerializedDictionary<TKey, TValue> _dictionary;

		private Dictionary<TKey, List<int>> _occurences = new Dictionary<TKey, List<int>>();

		private static readonly List<int> EmptyList = new List<int>();

		public IEnumerable Keys => _dictionary.Keys;

		public DictionaryLookupTable(SerializedDictionary<TKey, TValue> dictionary)
		{
			_dictionary = dictionary;
		}

		public IReadOnlyList<int> GetOccurences(object key)
		{
			if (key is TKey key2 && _occurences.TryGetValue(key2, out var value))
			{
				return value;
			}
			return EmptyList;
		}

		public void RecalculateOccurences()
		{
			_occurences.Clear();
			int count = _dictionary._serializedList.Count;
			for (int i = 0; i < count; i++)
			{
				SerializedKeyValuePair<TKey, TValue> serializedKeyValuePair = _dictionary._serializedList[i];
				if (SerializedCollectionsUtility.IsValidKey(serializedKeyValuePair.Key))
				{
					if (!_occurences.ContainsKey(serializedKeyValuePair.Key))
					{
						_occurences.Add(serializedKeyValuePair.Key, new List<int> { i });
					}
					else
					{
						_occurences[serializedKeyValuePair.Key].Add(i);
					}
				}
			}
		}

		public void RemoveKey(object key)
		{
			for (int num = _dictionary._serializedList.Count - 1; num >= 0; num--)
			{
				if (SerializedCollectionsUtility.KeysAreEqual(_dictionary._serializedList[num].Key, key))
				{
					_dictionary._serializedList.RemoveAt(num);
				}
			}
		}

		public void RemoveAt(int index)
		{
			_dictionary._serializedList.RemoveAt(index);
		}

		public object GetKeyAt(int index)
		{
			return _dictionary._serializedList[index];
		}

		public int GetCount()
		{
			return _dictionary._serializedList.Count;
		}

		public void RemoveDuplicates()
		{
			_dictionary._serializedList = (from x in _dictionary._serializedList
				group x by x.Key into x
				where SerializedCollectionsUtility.IsValidKey(x.Key)
				select x.First()).ToList();
		}

		public void AddKey(object key)
		{
			SerializedKeyValuePair<TKey, TValue> item = new SerializedKeyValuePair<TKey, TValue>
			{
				Key = (TKey)key
			};
			_dictionary._serializedList.Add(item);
		}
	}
}
