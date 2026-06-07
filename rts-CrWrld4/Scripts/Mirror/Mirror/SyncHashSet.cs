using System.Collections.Generic;

namespace Mirror
{
	public class SyncHashSet<T> : SyncSet<T>
	{
		public SyncHashSet()
			: base((ISet<T>)null)
		{
		}

		public SyncHashSet(IEqualityComparer<T> comparer)
			: base((ISet<T>)null)
		{
		}

		public new HashSet<T>.Enumerator GetEnumerator()
		{
			return default(HashSet<T>.Enumerator);
		}
	}
}
