using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace mattmc3.dotmore.Collections.Generic
{
	public class KeyedCollection2<TKey, TItem> : KeyedCollection<TKey, TItem>
	{
		private const string DelegateNullExceptionMessage = "Delegate passed cannot be null";

		private Func<TItem, TKey> _getKeyForItemFunction;

		public KeyedCollection2(Func<TItem, TKey> getKeyForItemFunction)
		{
		}

		public KeyedCollection2(Func<TItem, TKey> getKeyForItemDelegate, IEqualityComparer<TKey> comparer)
		{
		}

		protected override TKey GetKeyForItem(TItem item)
		{
			return default(TKey);
		}

		public void SortByKeys()
		{
		}

		public void SortByKeys(IComparer<TKey> keyComparer)
		{
		}

		public void SortByKeys(Comparison<TKey> keyComparison)
		{
		}

		public void Sort()
		{
		}

		public void Sort(Comparison<TItem> comparison)
		{
		}

		public void Sort(IComparer<TItem> comparer)
		{
		}
	}
}
