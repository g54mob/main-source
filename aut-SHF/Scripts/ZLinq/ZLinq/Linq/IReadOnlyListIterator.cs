using System.Collections.Generic;

namespace ZLinq.Linq
{
	internal sealed class IReadOnlyListIterator<T> : CollectionIterator<T> where T : notnull
	{
		public static readonly IReadOnlyListIterator<T> Instance;

		private IReadOnlyListIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			count = default(int);
			return false;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			current = default(T);
			return false;
		}
	}
}
