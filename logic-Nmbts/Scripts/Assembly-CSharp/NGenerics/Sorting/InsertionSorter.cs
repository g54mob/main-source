using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public sealed class InsertionSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			Sort(list, comparer, 0, list.Count - 1);
		}

		private static void Insert(IList<T> list, int sortedSequenceLength, T val, IComparer<T> comparer)
		{
			int num = sortedSequenceLength - 1;
			while (num >= 0 && comparer.Compare(list[num], val) > 0)
			{
				list[num + 1] = list[num];
				num--;
			}
			list[num + 1] = val;
		}

		private void Sort(IList<T> list, IComparer<T> comparer, int start, int end)
		{
			if (end - start + 1 > 1)
			{
				for (int i = start; i < end + 1; i++)
				{
					Insert(list, i, list[i], comparer);
				}
			}
		}
	}
}
