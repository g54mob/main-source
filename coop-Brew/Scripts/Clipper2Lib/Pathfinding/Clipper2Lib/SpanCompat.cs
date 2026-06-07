using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	internal readonly struct SpanCompat<T> where T : struct
	{
		internal unsafe readonly T* ptr;

		internal readonly uint length;

		public int Length => 0;

		public ref T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe SpanCompat(void* ptr, int length)
		{
			this.ptr = null;
			this.length = 0u;
		}
	}
}
