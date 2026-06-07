using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class CocktailSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			int num = 0;
			int num2 = list.Count - 1;
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = num; i < num2; i++)
				{
					if (comparer.Compare(list[i], list[i + 1]) > 0)
					{
						ComparisonSorter<T>.Swap(list, i, i + 1);
						flag = true;
					}
				}
				num2--;
				for (int num3 = num2; num3 > num; num3--)
				{
					if (comparer.Compare(list[num3], list[num3 - 1]) < 0)
					{
						ComparisonSorter<T>.Swap(list, num3, num3 - 1);
						flag = true;
					}
				}
				num++;
			}
		}
	}
}
