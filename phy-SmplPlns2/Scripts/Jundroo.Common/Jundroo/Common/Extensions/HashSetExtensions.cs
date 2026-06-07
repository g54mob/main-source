using System.Collections.Generic;

namespace Jundroo.Common.Extensions
{
	public static class HashSetExtensions
	{
		public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
		{
			if (items is IList<T> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					hashSet.Add(list[i]);
				}
				return;
			}
			foreach (T item in items)
			{
				hashSet.Add(item);
			}
		}
	}
}
