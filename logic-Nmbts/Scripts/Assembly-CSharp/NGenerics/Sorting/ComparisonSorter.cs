using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.Util;

namespace NGenerics.Sorting
{
	public abstract class ComparisonSorter<T> : Sorter<T>, IComparisonSorter<T>, ISorter<T>
	{
		public void Sort(IList<T> list, IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparer, "comparer");
			if (list.Count > 1)
			{
				SortItems(list, comparer);
			}
		}

		public void Sort(IList<T> list, Comparison<T> comparison)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparison, "comparison");
			Sort(list, new ComparisonComparer<T>(comparison));
		}

		public void Sort(IList<T> list, Comparison<T> comparison, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparison, "comparison");
			Sorter<T>.ValidateSortOrder(sortOrder);
			switch (sortOrder)
			{
			case SortOrder.Ascending:
				Sort(list, new ComparisonComparer<T>(comparison));
				break;
			case SortOrder.Descending:
				Sort(list, new ReverseComparisonComparer<T>(comparison));
				break;
			}
		}

		public override void Sort(IList<T> list, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(list, "list");
			Sorter<T>.ValidateSortOrder(sortOrder);
			switch (sortOrder)
			{
			case SortOrder.Ascending:
				Sort(list, Comparer<T>.Default);
				break;
			case SortOrder.Descending:
				Sort(list, new ReverseComparer<T>(Comparer<T>.Default));
				break;
			}
		}

		protected abstract void SortItems(IList<T> list, IComparer<T> comparer);

		protected static void Swap(IList<T> list, int pos1, int pos2)
		{
			Swapper.Swap(list, pos1, pos2);
		}
	}
}
