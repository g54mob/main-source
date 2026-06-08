using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Internal
{
	public static class BufferPool
	{
		public const int MinPooledSize = 512;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ShouldBePooled(int length)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static byte[] Rent(int size, bool zero)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] Alloc(int size, bool zero = false)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPooled(byte[] buffer)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Free(byte[]? buffer)
		{
		}
	}
}
