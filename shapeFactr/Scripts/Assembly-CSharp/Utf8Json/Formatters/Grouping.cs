using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Utf8Json.Formatters
{
	internal class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable
	{
		private readonly TKey key;

		private readonly IEnumerable<TElement> elements;

		public TKey Key => default(TKey);

		public Grouping(TKey key, IEnumerable<TElement> elements)
		{
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
