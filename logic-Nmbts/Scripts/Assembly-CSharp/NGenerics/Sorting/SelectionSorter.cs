using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class SelectionSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num = i;
				for (int j = i + 1; j < list.Count; j++)
				{
					if (comparer.Compare(list[j], list[num]) < 0)
					{
						num = j;
					}
				}
				ComparisonSorter<T>.Swap(list, i, num);
			}
		}
	}
}
