using System.Collections.Generic;

namespace FluffyUnderware.DevTools
{
	internal class SimplePool<T> where T : new()
	{
		private readonly List<T> freeItemsBackfield;

		public SimplePool(int preCreatedElementsCount)
		{
		}

		public T GetItem()
		{
			return default(T);
		}

		public void ReleaseItem(T item)
		{
		}
	}
}
