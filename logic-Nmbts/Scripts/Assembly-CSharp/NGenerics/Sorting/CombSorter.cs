using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class CombSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			int num = list.Count;
			while (num != 1)
			{
				if (num > 1)
				{
					num = (int)((double)num / 1.3);
					if (num == 10 || num == 9)
					{
						num = 11;
					}
				}
				for (int i = 0; i + num != list.Count; i++)
				{
					if (comparer.Compare(list[i], list[i + num]) > 0)
					{
						ComparisonSorter<T>.Swap(list, i, i + num);
					}
				}
			}
		}
	}
}
