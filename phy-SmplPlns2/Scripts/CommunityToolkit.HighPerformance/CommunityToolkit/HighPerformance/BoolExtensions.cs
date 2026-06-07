using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance
{
	public static class BoolExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte ToByte(this bool flag)
		{
			bool flag2 = flag;
			return flag2 ? ((byte)1) : ((byte)0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ToBitwiseMask32(this bool flag)
		{
			bool flag2 = flag;
			return ~((flag2 ? 1 : 0) - 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long ToBitwiseMask64(this bool flag)
		{
			bool flag2 = flag;
			return ~((flag2 ? 1L : 0L) - 1L);
		}
	}
}
