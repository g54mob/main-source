using System;
using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public interface ISortable<T>
	{
		void Sort(ISorter<T> sorter);

		void Sort(ISorter<T> sorter, SortOrder order);

		void Sort(IComparisonSorter<T> sorter, Comparison<T> comparison);

		void Sort(IComparisonSorter<T> sorter, IComparer<T> comparer);
	}
}
