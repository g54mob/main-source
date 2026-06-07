using System;
using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public interface IComparisonSorter<T> : ISorter<T>
	{
		void Sort(IList<T> list, IComparer<T> comparer);

		void Sort(IList<T> list, Comparison<T> comparison);
	}
}
