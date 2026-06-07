using System;
using System.Buffers;
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
			arrayToReturnToPool = null;
			chars = initialBuffer;
			currentPosition = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(char value)
		{
			int num = currentPosition;
			Span<char> span = chars;
			if (num >= span.Length)
			{
				ExpandAndAppend(value);
				return;
			}
			span[num] = value;
			currentPosition = num + 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ExpandAndAppend(char value)
		{
			Expand(1);
			chars[currentPosition] = value;
			currentPosition++;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(string? value)
		{
			if (value != null)
			{
				if (currentPosition > chars.Length - value.Length)
				{
					Expand(value.Length);
				}
				value.CopyTo(chars.Slice(currentPosition));
				currentPosition += value.Length;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(char separator, string? value)
		{
			if (value != null)
			{
				int num = currentPosition;
				Span<char> span = chars;
				if (num >= span.Length)
				{
					ExpandAndAppend(separator);
				}
				else
				{
					span[num] = separator;
					currentPosition = num + 1;
				}
				if (currentPosition > chars.Length - value.Length)
				{
					Expand(value.Length);
				}
				value.CopyTo(chars.Slice(currentPosition));
				currentPosition += value.Length;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append([ScopedRef] ReadOnlySpan<char> value)
		{
			while (!value.TryCopyTo(chars.Slice(currentPosition)))
			{
				Expand(value.Length);
			}
			currentPosition += value.Length;
		}

		public void Append<T>(T value)
		{
			if (typeof(T) == typeof(string))
			{
				Append(Unsafe.As<T, string>(ref value));
				return;
			}
			if (typeof(T) == typeof(byte))
			{
				int charsWritten;
				while (!Unsafe.As<T, byte>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten))
				{
					Expand(3);
				}
				currentPosition += charsWritten;
				return;
			}
			if (typeof(T) == typeof(sbyte))
			{
				int charsWritten2;
				while (!Unsafe.As<T, sbyte>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten2))
				{
					Expand(4);
				}
				currentPosition += charsWritten2;
				return;
			}
			if (typeof(T) == typeof(short))
			{
				int charsWritten3;
				while (!Unsafe.As<T, short>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten3))
				{
					Expand(6);
				}
				currentPosition += charsWritten3;
				return;
			}
			if (typeof(T) == typeof(ushort))
			{
				int charsWritten4;
				while (!Unsafe.As<T, ushort>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten4))
				{
					Expand(5);
				}
				currentPosition += charsWritten4;
				return;
			}
			if (typeof(T) == typeof(int))
			{
				int charsWritten5;
				while (!Unsafe.As<T, int>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten5))
				{
					Expand(11);
				}
				currentPosition += charsWritten5;
				return;
			}
			if (typeof(T) == typeof(uint))
			{
				int charsWritten6;
				while (!Unsafe.As<T, uint>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten6))
				{
					Expand(10);
				}
				currentPosition += charsWritten6;
				return;
			}
			if (typeof(T) == typeof(long))
			{
				int charsWritten7;
				while (!Unsafe.As<T, long>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten7))
				{
					Expand(20);
				}
				currentPosition += charsWritten7;
				return;
			}
			if (typeof(T) == typeof(ulong))
			{
				int charsWritten8;
				while (!Unsafe.As<T, ulong>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten8))
				{
					Expand(20);
				}
				currentPosition += charsWritten8;
				return;
			}
			if (typeof(T) == typeof(float))
			{
				int charsWritten9;
				while (!Unsafe.As<T, float>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten9))
				{
					Expand(128);
				}
				currentPosition += charsWritten9;
				return;
			}
			if (typeof(T) == typeof(double))
			{
				int charsWritten10;
				while (!Unsafe.As<T, double>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten10))
				{
					Expand(128);
				}
				currentPosition += charsWritten10;
				return;
			}
			if (typeof(T) == typeof(decimal))
			{
				int charsWritten11;
				while (!Unsafe.As<T, decimal>(ref value).TryFormat(chars.Slice(currentPosition), out charsWritten11))
				{
					Expand(128);
				}
				currentPosition += charsWritten11;
				return;
			}
			string text = ((!(value is IFormattable)) ? value?.ToString() : ((IFormattable)(object)value).ToString(null, null));
			if (text != null)
			{
				Append(text);
			}
		}

		public string ToStringAndClear()
		{
			string result = new string(chars.Slice(0, currentPosition));
			char[] array = arrayToReturnToPool;
			this = default(ValueStringBuilder);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Expand(int appendSize)
		{
			int minimumLength = (int)MathClamp(Math.Max((uint)(currentPosition + appendSize), Math.Min((uint)(chars.Length * 2), 1073741791u)), 256u, 2147483647u);
			char[] array = ArrayPool<char>.Shared.Rent(minimumLength);
			chars.Slice(0, currentPosition).CopyTo(array);
			if (arrayToReturnToPool != null)
			{
				ArrayPool<char>.Shared.Return(arrayToReturnToPool);
			}
			chars = (arrayToReturnToPool = array);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint MathClamp(uint value, uint min, uint max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		private static void ThrowMinMaxException<T>(T min, T max)
		{
			throw new ArgumentException();
		}
	}
}
