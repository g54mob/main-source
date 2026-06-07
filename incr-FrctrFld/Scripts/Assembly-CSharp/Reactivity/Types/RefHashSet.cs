using System.Collections.Generic;

namespace Reactivity.Types
{
	public class RefHashSet<T> : HashSet<T>
	{
		private RHashSet<T> _rHashSet;

		public RefHashSet()
		{
		}

		public RefHashSet(HashSet<T> hashSet)
		{
		}

		public void SetRef(RHashSet<T> rHashSet)
		{
		}

		public new void Add(T item)
		{
		}

		public new bool Remove(T item)
		{
			return false;
		}

		public new void Clear()
		{
		}
	}
}
