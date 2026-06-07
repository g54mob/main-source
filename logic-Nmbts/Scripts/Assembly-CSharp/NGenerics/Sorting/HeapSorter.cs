using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Sorting
{
	public sealed class HeapSorter<T> : ComparisonSorter<T>
	{
		protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			Heap<T> heap = new Heap<T>(HeapType.Minimum, list.Count, comparer);
			for (int i = 0; i < list.Count; i++)
			{
				heap.Add(list[i]);
			}
			for (int j = 0; j < list.Count; j++)
			{
				list[j] = heap.RemoveRoot();
			}
		}
	}
}
