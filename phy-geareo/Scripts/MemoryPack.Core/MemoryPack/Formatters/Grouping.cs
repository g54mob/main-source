using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	internal sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable where TKey : notnull where TElement : notnull
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
