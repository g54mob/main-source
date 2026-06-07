using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Enumerables;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance
{
	public static class ReadOnlySpanExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReference<T>(this ReadOnlySpan<T> span)
		{
			return ref MemoryMarshal.GetReference(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this ReadOnlySpan<T> span, int i)
		{
			return ref Unsafe.Add(ref MemoryMarshal.GetReference(span), (nint)(uint)i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this ReadOnlySpan<T> span, nint i)
		{
			return ref Unsafe.Add(ref MemoryMarshal.GetReference(span), i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref readonly T DangerousGetLookupReferenceAt<T>(this ReadOnlySpan<T> span, int i)
		{
			bool flag = (uint)i < (uint)span.Length;
			uint num = (uint)(~((flag ? 1 : 0) - 1));
			uint num2 = (uint)i & num;
			return ref Unsafe.Add(ref MemoryMarshal.GetReference(span), (nint)num2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan2D<T> AsSpan2D<T>(this ReadOnlySpan<T> span, int height, int width)
		{
			return new ReadOnlySpan2D<T>(span, height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan2D<T> AsSpan2D<T>(this ReadOnlySpan<T> span, int offset, int height, int width, int pitch)
		{
			return new ReadOnlySpan2D<T>(span, offset, height, width, pitch);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexOf<T>(this ReadOnlySpan<T> span, in T value)
		{
			nint num = (nint)Unsafe.ByteOffset(ref MemoryMarshal.GetReference(span), ref Unsafe.AsRef(in value)) / (nint)(uint)Unsafe.SizeOf<T>();
			if ((nuint)num >= (nuint)(uint)span.Length)
			{
				return -1;
			}
			return (int)num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<T>(this ReadOnlySpan<T> span, T value) where T : IEquatable<T>
		{
			ref T reference = ref MemoryMarshal.GetReference(span);
			nint length = (nint)(uint)span.Length;
			return (int)SpanHelper.Count(ref reference, length, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<byte> AsBytes<T>(this ReadOnlySpan<T> span) where T : unmanaged
		{
			return MemoryMarshal.AsBytes(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<TTo> Cast<TFrom, TTo>(this ReadOnlySpan<TFrom> span) where TFrom : unmanaged where TTo : unmanaged
		{
			return MemoryMarshal.Cast<TFrom, TTo>(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpanEnumerable<T> Enumerate<T>(this ReadOnlySpan<T> span)
		{
			return new ReadOnlySpanEnumerable<T>(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpanTokenizer<T> Tokenize<T>(this ReadOnlySpan<T> span, T separator) where T : IEquatable<T>
		{
			return new ReadOnlySpanTokenizer<T>(span, separator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDjb2HashCode<T>(this ReadOnlySpan<T> span) where T : notnull
		{
			ref T reference = ref MemoryMarshal.GetReference(span);
			nint length = (nint)(uint)span.Length;
			return SpanHelper.GetDjb2HashCode(ref reference, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CopyTo<T>(this ReadOnlySpan<T> span, RefEnumerable<T> destination)
		{
			destination.CopyFrom(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryCopyTo<T>(this ReadOnlySpan<T> span, RefEnumerable<T> destination)
		{
			return destination.TryCopyFrom(span);
		}
	}
}
