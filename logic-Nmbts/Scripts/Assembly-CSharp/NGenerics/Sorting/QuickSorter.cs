using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class QuickSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			QuickSort(list, comparer, 0, list.Count - 1);
		}

		private static void QuickSort(IList<T> list, IComparer<T> comparer, int leftBoundary, int rightBoundary)
		{
			if (leftBoundary < rightBoundary)
			{
				int pivot = GetPivot(list, comparer, leftBoundary, rightBoundary);
				QuickSort(list, comparer, leftBoundary, pivot - 1);
				QuickSort(list, comparer, pivot + 1, rightBoundary);
			}
		}

		private static int GetPivot(IList<T> list, IComparer<T> comparer, int leftBoundary, int rightBoundary)
		{
			int num = (leftBoundary + rightBoundary) / 2;
			if (comparer.Compare(list[leftBoundary], list[rightBoundary]) < 0)
			{
				ComparisonSorter<T>.Swap(list, leftBoundary, rightBoundary);
			}
			if (comparer.Compare(list[num], list[rightBoundary]) < 0)
			{
				ComparisonSorter<T>.Swap(list, num, rightBoundary);
			}
			if (comparer.Compare(list[leftBoundary], list[num]) > 0)
			{
				ComparisonSorter<T>.Swap(list, leftBoundary, num);
			}
			int num2 = leftBoundary;
			T y = list[num2];
			for (int i = leftBoundary + 1; i <= rightBoundary; i++)
			{
				if (comparer.Compare(list[i], y) < 0)
				{
					num2++;
					ComparisonSorter<T>.Swap(list, num2, i);
				}
			}
			ComparisonSorter<T>.Swap(list, leftBoundary, num2);
			return num2;
		}
	}
}
