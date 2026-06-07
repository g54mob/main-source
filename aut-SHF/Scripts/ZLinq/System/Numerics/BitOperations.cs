using System.Runtime.CompilerServices;

namespace System.Numerics
{
	internal static class BitOperations
	{
		private static ReadOnlySpan<byte> Log2DeBruijn => default(ReadOnlySpan<byte>);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint RoundUpToPowerOf2(uint value)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Log2(uint value)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int Log2SoftwareFallback(uint value)
		{
			return 0;
		}
	}
}
