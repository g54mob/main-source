using System;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal ref struct ValueStringBuilder
	{
		private const int StringMaxLength = 1073741791;

		private const int MinimumArrayPoolLength = 256;

		private Span<char> chars;

		private int currentPosition;

		private char[]? arrayToReturnToPool;

		public ValueStringBuilder(Span<char> initialBuffer)
		{
			chars = default(Span<char>);
			currentPosition = 0;
			arrayToReturnToPool = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(char value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ExpandAndAppend(char value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(char separator, string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append([ScopedRef] ReadOnlySpan<char> value)
		{
		}

		public void Append<T>(T value) where T : notnull
		{
		}

		public string ToStringAndClear()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Expand(int appendSize)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint MathClamp(uint value, uint min, uint max)
		{
			return 0u;
		}

		private static void ThrowMinMaxException<T>(T min, T max) where T : notnull
		{
		}
	}
}
