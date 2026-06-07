using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Utf8Json.Formatters
{
	internal class Lookup<TKey, TElement> : ILookup<TKey, TElement>, IEnumerable<IGrouping<TKey, TElement>>, IEnumerable
	{
		private readonly Dictionary<TKey, IGrouping<TKey, TElement>> groupings;

		public IEnumerable<TElement> this[TKey key] => null;

		public int Count => 0;

		public Lookup(Dictionary<TKey, IGrouping<TKey, TElement>> groupings)
		{
		}

		public bool Contains(TKey key)
		{
			return false;
		}

		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
