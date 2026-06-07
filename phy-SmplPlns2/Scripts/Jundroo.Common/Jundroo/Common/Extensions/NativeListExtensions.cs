using Unity.Collections;

namespace Jundroo.Common.Extensions
{
	public static class NativeListExtensions
	{
		public static void EnsureCapacity<T>(this NativeList<T> list, int capacity) where T : unmanaged
		{
			if (list.Capacity < capacity)
			{
				list.SetCapacity(capacity);
			}
		}

		public static void EnsureFreeCapacity<T>(this NativeList<T> list, int capacity) where T : unmanaged
		{
			capacity += list.Length;
			if (list.Capacity < capacity)
			{
				list.SetCapacity(capacity);
			}
		}
	}
}
