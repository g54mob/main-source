using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class ShellSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			int num = list.Count;
			do
			{
				num = 1 + num / 3;
				for (int i = 0; i < num; i++)
				{
					for (int j = num + i; j < list.Count; j += num)
					{
						int num2 = j;
						T val = list[num2];
						while (num2 != i && comparer.Compare(list[num2 - num], val) > 0)
						{
							list[num2] = list[num2 - num];
							num2 -= num;
						}
						list[num2] = val;
					}
				}
			}
			while (num > 1);
		}
	}
}
