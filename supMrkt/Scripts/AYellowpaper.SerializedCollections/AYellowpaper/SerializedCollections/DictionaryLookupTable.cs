using System.Collections;
using System.Collections.Generic;

namespace AYellowpaper.SerializedCollections
{
	internal class DictionaryLookupTable<TKey, TValue> : IKeyable
	{
		private SerializedDictionary<TKey, TValue> _dictionary;

		private Dictionary<TKey, List<int>> _occurences;

		private static readonly List<int> EmptyList;

		public IEnumerable Keys => null;

		public DictionaryLookupTable(SerializedDictionary<TKey, TValue> dictionary)
		{
		}

		public IReadOnlyList<int> GetOccurences(object key)
		{
			return null;
		}

		public void RecalculateOccurences()
		{
		}

		public void RemoveKey(object key)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public object GetKeyAt(int index)
		{
			return null;
		}

		public int GetCount()
		{
			return 0;
		}

		public void RemoveDuplicates()
		{
		}

		public void AddKey(object key)
		{
		}
	}
}
