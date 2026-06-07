using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class BubbleSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				for (int i = 0; i < num; i++)
				{
					if (comparer.Compare(list[i], list[i + 1]) > 0)
					{
						ComparisonSorter<T>.Swap(list, i, i + 1);
					}
				}
			}
		}
	}
}
