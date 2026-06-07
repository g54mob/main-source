using System;

namespace Pathfinding.Collections
{
	public static class SlabListExtensions
	{
		public static void Remove<T>(this ref SlabAllocator<T>.List list, T value) where T : struct, IEquatable<T>
		{
		}
	}
}
