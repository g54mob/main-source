using System.Runtime.CompilerServices;

namespace Pathfinding.ECS
{
	public ref struct ComponentRef<T> where T : struct
	{
		private unsafe byte* ptr;

		public ref T value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				throw null;
			}
		}

		public unsafe ComponentRef(byte* ptr)
		{
			this.ptr = null;
		}
	}
}
