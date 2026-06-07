using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace R3
{
	internal sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>, IEnumerable<IGrouping<TKey, TElement>>, IEnumerable where TKey : notnull
	{
		private sealed class Grouping : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable
		{
			public TKey Key => _003Ckvp_003EP.Key;

			public Grouping(KeyValuePair<TKey, List<TElement>> kvp)
			{
				_003Ckvp_003EP = kvp;
				base._002Ector();
			}

			public IEnumerator<TElement> GetEnumerator()
			{
				return _003Ckvp_003EP.Value.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public IEnumerable<TElement> this[TKey key]
		{
			get
			{
				if (_003Cdictionary_003EP.TryGetValue(key, out List<TElement> value))
				{
					return value;
				}
				return Enumerable.Empty<TElement>();
			}
		}

		public int Count => _003Cdictionary_003EP.Count;

		public Lookup(Dictionary<TKey, List<TElement>> dictionary)
		{
			_003Cdictionary_003EP = dictionary;
			base._002Ector();
		}

		public bool Contains(TKey key)
		{
			return _003Cdictionary_003EP.ContainsKey(key);
		}

		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			foreach (KeyValuePair<TKey, List<TElement>> item in _003Cdictionary_003EP)
			{
				yield return new Grouping(item);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
