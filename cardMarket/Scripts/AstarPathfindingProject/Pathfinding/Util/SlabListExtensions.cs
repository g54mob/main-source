using System;

namespace Pathfinding.Util
{
	public static class SlabListExtensions
	{
		public static void Remove<T>(this ref SlabAllocator<T>.List list, T value) where T : unmanaged, IEquatable<T>
		{
			int num = list.span.IndexOf(value);
			if (num != -1)
			{
				list.RemoveAt(num);
			}
		}
	}
}
