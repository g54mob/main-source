using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Enumerables;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance
{
	public static class StringExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref char DangerousGetReference(this string text)
		{
			return ref MemoryMarshal.GetReference(text.AsSpan());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref char DangerousGetReferenceAt(this string text, int i)
		{
			return ref Unsafe.Add(ref MemoryMarshal.GetReference(text.AsSpan()), (nint)(uint)i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count(this string text, char c)
		{
			ref char r = ref text.DangerousGetReference();
			nint length = (nint)(uint)text.Length;
			return (int)SpanHelper.Count(ref r, length, c);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpanEnumerable<char> Enumerate(this string text)
		{
			return new ReadOnlySpanEnumerable<char>(text.AsSpan());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpanTokenizer<char> Tokenize(this string text, char separator)
		{
			return new ReadOnlySpanTokenizer<char>(text.AsSpan(), separator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDjb2HashCode(this string text)
		{
			ref char r = ref text.DangerousGetReference();
			nint length = (nint)(uint)text.Length;
			return SpanHelper.GetDjb2HashCode(ref r, length);
		}
	}
}
