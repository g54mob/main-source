using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiscUtil.Extensions;

namespace MiscUtil.Linq
{
	public sealed class EditableLookup<TKey, TElement> : ILookup<TKey, TElement>, IEnumerable<IGrouping<TKey, TElement>>, IEnumerable
	{
		internal sealed class LookupGrouping : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable
		{
			private readonly TKey key;

			private List<TElement> items = new List<TElement>();

			public TKey Key => key;

			public int Count => items.Count;

			public LookupGrouping(TKey key)
			{
				this.key = key;
			}

			public void Add(TElement item)
			{
				items.Add(item);
			}

			public bool Contains(TElement item)
			{
				return items.Contains(item);
			}

			public bool Remove(TElement item)
			{
				return items.Remove(item);
			}

			public void TrimExcess()
			{
				items.TrimExcess();
			}

			public IEnumerator<TElement> GetEnumerator()
			{
				return items.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private readonly Dictionary<TKey, LookupGrouping> groups;

		private static readonly IEnumerable<TElement> Empty = new TElement[0];

		public int Count => groups.Count;

		public IEnumerable<TElement> this[TKey key]
		{
			get
			{
				if (groups.TryGetValue(key, out var value))
				{
					return value;
				}
				return Empty;
			}
		}

		public EditableLookup()
			: this((IEqualityComparer<TKey>)null)
		{
		}

		public EditableLookup(IEqualityComparer<TKey> keyComparer)
		{
			groups = new Dictionary<TKey, LookupGrouping>(keyComparer ?? EqualityComparer<TKey>.Default);
		}

		public bool Contains(TKey key)
		{
			if (!groups.TryGetValue(key, out var value))
			{
				return false;
			}
			return value.Count > 0;
		}

		public bool Contains(TKey key, TElement value)
		{
			if (!groups.TryGetValue(key, out var value2))
			{
				return false;
			}
			return value2.Contains(value);
		}

		public void Add(TKey key, TElement value)
		{
			if (!groups.TryGetValue(key, out var value2))
			{
				value2 = new LookupGrouping(key);
				groups.Add(key, value2);
			}
			value2.Add(value);
		}

		public void AddRange(TKey key, IEnumerable<TElement> values)
		{
			values.ThrowIfNull("values");
			if (!groups.TryGetValue(key, out var value))
			{
				value = new LookupGrouping(key);
				groups.Add(key, value);
			}
			foreach (TElement value2 in values)
			{
				value.Add(value2);
			}
			if (value.Count == 0)
			{
				groups.Remove(key);
			}
		}

		public void AddRange(ILookup<TKey, TElement> lookup)
		{
			lookup.ThrowIfNull("lookup");
			foreach (IGrouping<TKey, TElement> item in lookup)
			{
				AddRange(item.Key, item);
			}
		}

		public bool Remove(TKey key)
		{
			return groups.Remove(key);
		}

		public bool Remove(TKey key, TElement value)
		{
			if (groups.TryGetValue(key, out var value2))
			{
				bool flag = value2.Remove(value);
				if (flag && value2.Count == 0)
				{
					groups.Remove(key);
				}
				return flag;
			}
			return false;
		}

		public void TrimExcess()
		{
			foreach (LookupGrouping value in groups.Values)
			{
				value.TrimExcess();
			}
		}

		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			foreach (LookupGrouping value in groups.Values)
			{
				yield return value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
