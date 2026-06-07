using System.Collections.Generic;

namespace Mirror
{
	public class SyncSortedSet<T> : SyncSet<T>
	{
		public SyncSortedSet()
			: base((ISet<T>)null)
		{
		}

		public SyncSortedSet(IComparer<T> comparer)
			: base((ISet<T>)null)
		{
		}

		public new SortedSet<T>.Enumerator GetEnumerator()
		{
			return default(SortedSet<T>.Enumerator);
		}
	}
}
