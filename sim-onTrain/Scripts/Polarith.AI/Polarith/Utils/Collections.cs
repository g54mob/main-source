using System.Collections.Generic;

namespace Polarith.Utils
{
	public static class Collections
	{
		public static void CopyList<T>(IList<T> from, IList<T> to)
		{
			ResizeListDefault(to, from.Count);
			for (int i = 0; i < to.Count; i++)
			{
				to[i] = from[i];
			}
		}

		public static void ResizeList<T>(IList<T> list, int size) where T : new()
		{
			while (list.Count > size)
			{
				list.RemoveAt(list.Count - 1);
			}
			while (list.Count < size)
			{
				list.Add(new T());
			}
		}

		public static void ResizeListDefault<T>(IList<T> list, int size)
		{
			while (list.Count > size)
			{
				list.RemoveAt(list.Count - 1);
			}
			while (list.Count < size)
			{
				list.Add(default(T));
			}
		}
	}
}
