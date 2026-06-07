using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance.Helpers
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HashCode<T> where T : notnull
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Combine(ReadOnlySpan<T> span)
		{
			return HashCode.Combine(CombineValues(span));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int CombineValues(ReadOnlySpan<T> span)
		{
			ref T reference = ref MemoryMarshal.GetReference(span);
			if (System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>())
			{
				return SpanHelper.GetDjb2HashCode(ref reference, (nint)(uint)span.Length);
			}
			ref byte r = ref Unsafe.As<T, byte>(ref reference);
			nint length = (nint)(uint)(span.Length * Unsafe.SizeOf<T>());
			return SpanHelper.GetDjb2LikeByteHash(ref r, length);
		}
	}
}
