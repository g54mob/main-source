using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class MergeSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			MergeSort(0, list.Count - 1, list, comparer);
		}

		private static void MergeSort(int leftBoundary, int rightBoundary, IList<T> list, IComparer<T> comparer)
		{
			if (leftBoundary >= rightBoundary)
			{
				return;
			}
			int num = (leftBoundary + rightBoundary) / 2;
			MergeSort(leftBoundary, num, list, comparer);
			MergeSort(num + 1, rightBoundary, list, comparer);
			while (num + 1 <= rightBoundary && leftBoundary <= num)
			{
				if (comparer.Compare(list[leftBoundary], list[num + 1]) < 0)
				{
					leftBoundary++;
					continue;
				}
				T value = list[num + 1];
				for (int num2 = num; num2 >= leftBoundary; num2--)
				{
					list[num2 + 1] = list[num2];
				}
				list[leftBoundary] = value;
				leftBoundary++;
				num++;
			}
		}
	}
}
