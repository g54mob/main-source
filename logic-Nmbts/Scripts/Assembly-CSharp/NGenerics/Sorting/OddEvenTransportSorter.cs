using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class OddEvenTransportSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			for (int i = 0; i < list.Count / 2; i++)
			{
				for (int j = 0; j + 1 < list.Count; j += 2)
				{
					if (comparer.Compare(list[j], list[j + 1]) > 0)
					{
						ComparisonSorter<T>.Swap(list, j, j + 1);
					}
				}
				for (int k = 1; k + 1 < list.Count; k += 2)
				{
					if (comparer.Compare(list[k], list[k + 1]) > 0)
					{
						ComparisonSorter<T>.Swap(list, k, k + 1);
					}
				}
			}
		}
	}
}
