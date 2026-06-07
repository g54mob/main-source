using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class GnomeSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			int num = 1;
			while (num < list.Count)
			{
				if (comparer.Compare(list[num - 1], list[num]) <= 0)
				{
					num++;
					continue;
				}
				ComparisonSorter<T>.Swap(list, num - 1, num);
				if (num > 1)
				{
					num--;
				}
			}
		}
	}
}
