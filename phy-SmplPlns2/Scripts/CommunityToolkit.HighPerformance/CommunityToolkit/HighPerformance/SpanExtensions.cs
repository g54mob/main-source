using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Enumerables;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance
{
	public static class SpanExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReference<T>(this Span<T> span)
		{
			return ref MemoryMarshal.GetReference(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this Span<T> span, int i)
		{
			return ref Unsafe.Add(ref MemoryMarshal.GetReference(span), (nint)(uint)i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this Span<T> span, nint i)
		{
			return ref Unsafe.Add(ref MemoryMarshal.GetReference(span), i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span2D<T> AsSpan2D<T>(this Span<T> span, int height, int width)
		{
			return new Span2D<T>(span, height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span2D<T> AsSpan2D<T>(this Span<T> span, int offset, int height, int width, int pitch)
		{
			return new Span2D<T>(span, offset, height, width, pitch);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<byte> AsBytes<T>(this Span<T> span) where T : unmanaged
		{
			return MemoryMarshal.AsBytes(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<TTo> Cast<TFrom, TTo>(this Span<TFrom> span) where TFrom : unmanaged where TTo : unmanaged
		{
			return MemoryMarshal.Cast<TFrom, TTo>(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexOf<T>(this Span<T> span, ref T value)
		{
			nint num = (nint)Unsafe.ByteOffset(ref MemoryMarshal.GetReference(span), ref value) / (nint)(uint)Unsafe.SizeOf<T>();
			if ((nuint)num >= (nuint)(uint)span.Length)
			{
				return -1;
			}
			return (int)num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<T>(this Span<T> span, T value) where T : IEquatable<T>
		{
			ref T reference = ref MemoryMarshal.GetReference(span);
			nint length = (nint)(uint)span.Length;
			return (int)SpanHelper.Count(ref reference, length, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanEnumerable<T> Enumerate<T>(this Span<T> span)
		{
			return new SpanEnumerable<T>(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanTokenizer<T> Tokenize<T>(this Span<T> span, T separator) where T : IEquatable<T>
		{
			return new SpanTokenizer<T>(span, separator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDjb2HashCode<T>(this Span<T> span) where T : notnull
		{
			ref T reference = ref MemoryMarshal.GetReference(span);
			nint length = (nint)(uint)span.Length;
			return SpanHelper.GetDjb2HashCode(ref reference, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CopyTo<T>(this Span<T> span, RefEnumerable<T> destination)
		{
			destination.CopyFrom(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryCopyTo<T>(this Span<T> span, RefEnumerable<T> destination)
		{
			return destination.TryCopyFrom(span);
		}
	}
}
