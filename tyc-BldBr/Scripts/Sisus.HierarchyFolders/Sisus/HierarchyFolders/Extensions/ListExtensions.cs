using System.Collections.Generic;
using JetBrains.Annotations;

namespace Sisus.HierarchyFolders.Extensions
{
	public static class ListExtensions
	{
		public static void AddSorted<T>([NotNull] this List<T> sortedList, [CanBeNull] T item, [CanBeNull] IComparer<T> comparer)
		{
			int num = sortedList.BinarySearch(item, comparer);
			sortedList.Insert((num >= 0) ? num : (~num), item);
		}
	}
}
