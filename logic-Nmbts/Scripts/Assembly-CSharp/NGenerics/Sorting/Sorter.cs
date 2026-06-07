using System;
using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public abstract class Sorter<T> : ISorter<T>
	{
		public void Sort(IList<T> list)
		{
			Sort(list, SortOrder.Ascending);
		}

		public abstract void Sort(IList<T> list, SortOrder order);

		public static void ValidateSortOrder(SortOrder sortOrder)
		{
			if (sortOrder != SortOrder.Ascending && sortOrder != SortOrder.Descending)
			{
				throw new ArgumentOutOfRangeException("sortOrder");
			}
		}
	}
}
