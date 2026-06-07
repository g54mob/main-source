using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Jundroo.Common.DataTypes;

namespace Jundroo.Common.Utils
{
	public static class StringUtility
	{
		public delegate T SpanSplitEntryValueDelegate<T>(ReadOnlySpan<char> span);

		public readonly ref struct StringSplitEntry
		{
			public int Index { get; }

			public ReadOnlySpan<char> Span { get; }

			public StringSplitEntry(ReadOnlySpan<char> span, int index)
			{
				Span = span;
				Index = index;
			}

			public static implicit operator ReadOnlySpan<char>(StringSplitEntry entry)
			{
				return entry.Span;
			}

			public static implicit operator string(StringSplitEntry entry)
			{
				return new string(entry.Span);
			}

			public void Deconstruct(out ReadOnlySpan<char> span, out int index)
			{
				span = Span;
				index = Index;
			}

			public override string ToString()
			{
				return new string(Span);
			}
		}

		public readonly ref struct StringSplitEntry<T>
		{
			public int Index { get; }

			public ReadOnlySpan<char> Span { get; }

			public T Value { get; }

			public StringSplitEntry(ReadOnlySpan<char> span, int index, T value)
			{
				Span = span;
				Index = index;
				Value = value;
			}

			public static implicit operator ReadOnlySpan<char>(StringSplitEntry<T> entry)
			{
				return entry.Span;
			}

			public static implicit operator string(StringSplitEntry<T> entry)
			{
				return new string(entry.Span);
			}

			public static implicit operator T(StringSplitEntry<T> entry)
			{
				return entry.Value;
			}

			public void Deconstruct(out ReadOnlySpan<char> span, out T value, out int index)
			{
				span = Span;
				value = Value;
				index = Index;
			}

			public override string ToString()
			{
				return new string(Span);
			}
		}

		public ref struct StringSplitEnumerator
		{
			private readonly char _split;

			private StringSplitEntry _current;

			private bool _removeEmptyEntries;

			private int _resultIndex;

			private ReadOnlySpan<char> _span;

			public readonly StringSplitEntry Current => _current;

			internal StringSplitEnumerator(ReadOnlySpan<char> span, char split, bool removeEmptyEntries)
			{
				_span = span;
				_split = split;
				_removeEmptyEntries = removeEmptyEntries;
				_resultIndex = 0;
				_current = new StringSplitEntry(default(ReadOnlySpan<char>), -1);
			}

			public readonly StringSplitEnumerator GetEnumerator()
			{
				return this;
			}

			public bool MoveNext()
			{
				if (_span.Length == 0)
				{
					return false;
				}
				int num = _span.IndexOf(_split);
				ReadOnlySpan<char> span;
				if (num < 0)
				{
					_current = new StringSplitEntry(_span, _resultIndex);
					_span = default(ReadOnlySpan<char>);
				}
				else
				{
					span = _span;
					_current = new StringSplitEntry(span.Slice(0, num), _resultIndex);
					span = _span;
					int num2 = num + 1;
					_span = span.Slice(num2, span.Length - num2);
				}
				if (_removeEmptyEntries)
				{
					span = _current.Span;
					if (span.Length == 0)
					{
						return MoveNext();
					}
				}
				_resultIndex++;
				return true;
			}
		}

		public ref struct StringSplitEnumerator<T>
		{
			private readonly char _split;

			private StringSplitEntry<T> _current;

			private bool _removeEmptyEntries;

			private int _resultIndex;

			private ReadOnlySpan<char> _span;

			private SpanSplitEntryValueDelegate<T> _valueFunction;

			public readonly StringSplitEntry<T> Current => _current;

			internal StringSplitEnumerator(ReadOnlySpan<char> span, char split, bool removeEmptyEntries, SpanSplitEntryValueDelegate<T> valueFunction)
			{
				_span = span;
				_split = split;
				_removeEmptyEntries = removeEmptyEntries;
				_valueFunction = valueFunction;
				_resultIndex = 0;
				_current = new StringSplitEntry<T>(default(ReadOnlySpan<char>), -1, default(T));
			}

			public readonly StringSplitEnumerator<T> GetEnumerator()
			{
				return this;
			}

			public bool MoveNext()
			{
				if (_span.Length == 0)
				{
					return false;
				}
				int num = _span.IndexOf(_split);
				ReadOnlySpan<char> span;
				if (num < 0)
				{
					_current = new StringSplitEntry<T>(_span, _resultIndex, _valueFunction(_span));
					_span = default(ReadOnlySpan<char>);
				}
				else
				{
					span = _span;
					ReadOnlySpan<char> span2 = span.Slice(0, num);
					_current = new StringSplitEntry<T>(span2, _resultIndex, _valueFunction(span2));
					span = _span;
					int num2 = num + 1;
					_span = span.Slice(num2, span.Length - num2);
				}
				if (_removeEmptyEntries)
				{
					span = _current.Span;
					if (span.Length == 0)
					{
						return MoveNext();
					}
				}
				_resultIndex++;
				return true;
			}
		}

		internal static readonly SpanSplitEntryValueDelegate<double?> _spanSplitValueToDouble = (ReadOnlySpan<char> span) => (!DataIO.TryParseDouble(span, out var value)) ? ((double?)null) : new double?(value);

		internal static readonly SpanSplitEntryValueDelegate<float?> _spanSplitValueToFloat = (ReadOnlySpan<char> span) => (!DataIO.TryParseFloat(span, out var value)) ? ((float?)null) : new float?(value);

		internal static readonly SpanSplitEntryValueDelegate<int?> _spanSplitValueToInteger = (ReadOnlySpan<char> span) => (!DataIO.TryParseInt(span, out var value)) ? ((int?)null) : new int?(value);

		public static string ClampString(string input, int maxLength)
		{
			if (string.IsNullOrEmpty(input) || maxLength < 0)
			{
				return string.Empty;
			}
			if (input.Length <= maxLength)
			{
				return input;
			}
			return input.Substring(0, maxLength);
		}

		public static int GetStableHashCode(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}
			Encoding uTF = Encoding.UTF8;
			int num = text.Length * 4;
			uint num2 = 2166136261u;
			if (num <= 1024)
			{
				Span<byte> bytes = stackalloc byte[num];
				int bytes2 = uTF.GetBytes(text.AsSpan(), bytes);
				for (int i = 0; i < bytes2; i++)
				{
					num2 ^= bytes[i];
					num2 *= 16777619;
				}
			}
			else
			{
				ArrayPool<byte> shared = ArrayPool<byte>.Shared;
				byte[] array = shared.Rent(num);
				try
				{
					Span<byte> bytes3 = array.AsSpan();
					int bytes4 = uTF.GetBytes(text.AsSpan(), bytes3);
					for (int j = 0; j < bytes4; j++)
					{
						num2 ^= bytes3[j];
						num2 *= 16777619;
					}
				}
				finally
				{
					shared.Return(array);
				}
			}
			return (int)num2;
		}

		public static string PascalCaseToDisplay(this string value, bool isAscii = true)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			int length = value.Length;
			SpanStringBuilder spanStringBuilder;
			if (length <= 512)
			{
				Span<char> span = stackalloc char[length * 2];
				spanStringBuilder = new SpanStringBuilder(span);
			}
			else
			{
				spanStringBuilder = new SpanStringBuilder(new StringBuilder(length + length / 4));
			}
			SpanStringBuilder spanStringBuilder2 = spanStringBuilder;
			ReadOnlySpan<char> readOnlySpan = value.AsSpan();
			char c = readOnlySpan[0];
			if (IsLower(c, isAscii))
			{
				c = ToUpper(c, isAscii);
			}
			spanStringBuilder2.Append(c);
			bool flag = IsDigit(c, isAscii);
			bool flag2 = IsUpper(c, isAscii);
			bool flag3 = false;
			bool flag4 = false;
			for (int i = 1; i < readOnlySpan.Length; i++)
			{
				c = readOnlySpan[i];
				bool flag5 = IsDigit(c, isAscii);
				bool flag6 = IsUpper(c, isAscii);
				bool flag7 = IsLower(c, isAscii);
				if ((flag6 && (flag3 || flag)) || (flag5 && (flag3 || flag2)))
				{
					spanStringBuilder2.Append(' ');
				}
				else if (flag7 && flag4)
				{
					spanStringBuilder2.Remove(spanStringBuilder2.Length - 1);
					spanStringBuilder2.Append(' ');
					spanStringBuilder2.Append(readOnlySpan[i - 1]);
				}
				spanStringBuilder2.Append(c);
				flag4 = flag2 && flag6;
				flag = flag5;
				flag2 = flag6;
				flag3 = flag7;
			}
			return spanStringBuilder2.ToString();
		}

		public static StringSplitEnumerator SpanSplit(string value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator(value.AsSpan(), split, removeEmptyEntries);
		}

		public static StringSplitEnumerator SpanSplit(ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator(value, split, removeEmptyEntries);
		}

		public static StringSplitEnumerator<T> SpanSplit<T>(string value, char split, bool removeEmptyEntries, SpanSplitEntryValueDelegate<T> valueFunction)
		{
			return new StringSplitEnumerator<T>(value.AsSpan(), split, removeEmptyEntries, valueFunction);
		}

		public static StringSplitEnumerator<T> SpanSplit<T>(ReadOnlySpan<char> value, char split, bool removeEmptyEntries, SpanSplitEntryValueDelegate<T> valueFunction)
		{
			return new StringSplitEnumerator<T>(value, split, removeEmptyEntries, valueFunction);
		}

		public static StringSplitEnumerator<double?> SpanSplitAsDoubles(string value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator<double?>(value.AsSpan(), split, removeEmptyEntries, _spanSplitValueToDouble);
		}

		public static StringSplitEnumerator<double?> SpanSplitAsDoubles(ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator<double?>(value, split, removeEmptyEntries, _spanSplitValueToDouble);
		}

		public static StringSplitEnumerator<float?> SpanSplitAsFloats(string value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator<float?>(value.AsSpan(), split, removeEmptyEntries, _spanSplitValueToFloat);
		}

		public static StringSplitEnumerator<float?> SpanSplitAsFloats(ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator<float?>(value, split, removeEmptyEntries, _spanSplitValueToFloat);
		}

		public static StringSplitEnumerator<int?> SpanSplitAsIntegers(string value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator<int?>(value.AsSpan(), split, removeEmptyEntries, _spanSplitValueToInteger);
		}

		public static StringSplitEnumerator<int?> SpanSplitAsIntegers(ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringSplitEnumerator<int?>(value, split, removeEmptyEntries, _spanSplitValueToInteger);
		}

		public static string StripRichText(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}
			string pattern = "<(?:\\/?[A-Za-z]|#)[^>]*>";
			return Regex.Replace(input, pattern, string.Empty);
		}

		public unsafe static bool TryParseBase16ToInt(char* base16, int* results, int count)
		{
			for (int i = 0; i < count; i++)
			{
				char c = base16[i];
				if (c >= '0' && c <= '9')
				{
					results[i] = c - 48;
					continue;
				}
				if (c >= 'A' && c <= 'F')
				{
					results[i] = c - 65 + 10;
					continue;
				}
				if (c >= 'a' && c <= 'f')
				{
					results[i] = c - 97 + 10;
					continue;
				}
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsDigit(char c, bool ascii)
		{
			if (!ascii)
			{
				return char.IsDigit(c);
			}
			if (c >= '0')
			{
				return c <= '9';
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsLower(char c, bool ascii)
		{
			if (!ascii)
			{
				return char.IsLower(c);
			}
			if (c >= 'a')
			{
				return c <= 'z';
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsUpper(char c, bool ascii)
		{
			if (!ascii)
			{
				return char.IsUpper(c);
			}
			if (c >= 'A')
			{
				return c <= 'Z';
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static char ToUpper(char c, bool ascii)
		{
			if (!ascii)
			{
				return char.ToUpper(c);
			}
			return (char)(c & -33);
		}
	}
}
