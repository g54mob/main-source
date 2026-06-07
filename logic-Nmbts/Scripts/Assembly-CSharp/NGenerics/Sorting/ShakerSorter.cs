using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class ShakerSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			int num = 0;
			int num2 = list.Count - 1;
			while (num < num2)
			{
				int num3 = num;
				int num4 = num;
				for (int i = num + 1; i <= num2; i++)
				{
					if (comparer.Compare(list[i], list[num3]) < 0)
					{
						num3 = i;
					}
					if (comparer.Compare(list[i], list[num4]) > 0)
					{
						num4 = i;
					}
				}
				ComparisonSorter<T>.Swap(list, num3, num);
				if (num4 == num)
				{
					ComparisonSorter<T>.Swap(list, num3, num2);
				}
				else
				{
					ComparisonSorter<T>.Swap(list, num4, num2);
				}
				num++;
				num2--;
			}
		}
	}
}
