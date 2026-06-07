using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{
	public static class ListExtensions
	{
		public static void Sort<TElement>(this IList<TElement> list, ISorter<TElement> sorter)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			sorter.Sort(list);
		}

		public static void Sort<TElement>(this IList<TElement> list, ISorter<TElement> sorter, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			sorter.Sort(list, sortOrder);
		}

		public static void Sort<TElement>(this IList<TElement> list, IComparisonSorter<TElement> sorter, Comparison<TElement> comparison)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			sorter.Sort(list, comparison);
		}

		public static void Sort<TElement>(this IList<TElement> list, IComparisonSorter<TElement> sorter, IComparer<TElement> comparer)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			sorter.Sort(list, comparer);
		}
	}
}
