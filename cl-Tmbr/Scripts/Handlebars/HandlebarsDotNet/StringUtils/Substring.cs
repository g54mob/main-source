using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.StringUtils
{
	public readonly struct Substring : IEquatable<Substring>, IEquatable<string>
	{
		public struct SubstringEnumerator : IEnumerator<char>, IEnumerator, IDisposable
		{
			private readonly Substring _substring;

			private int _index;

			public char Current => _substring[in _index];

			object IEnumerator.Current => Current;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public SubstringEnumerator(Substring substring)
			{
				_substring = substring;
				_index = -1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++_index < _substring.Length;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Reset()
			{
				_index = -1;
			}

			public void Dispose()
			{
			}
		}

		public struct SplitEnumerator : IEnumerator<Substring>, IEnumerator, IDisposable
		{
			private readonly Substring _substring;

			private readonly char _separator;

			private readonly StringSplitOptions _options;

			private Substring _current;

			private int _index;

			public Substring Current => _current;

			object IEnumerator.Current => Current;

			public SplitEnumerator(Substring substring, char separator, StringSplitOptions options = StringSplitOptions.None)
			{
				_substring = substring;
				_separator = separator;
				_options = options;
				_current = default(Substring);
				_index = 0;
			}

			public bool MoveNext()
			{
				int start = _index;
				int length = 0;
				while (_index < _substring.Length)
				{
					if (_substring[in _index] != _separator)
					{
						length++;
						_index++;
						continue;
					}
					Substring current = new Substring(in _substring, in start, in length);
					length = 0;
					start = ++_index;
					if (current.Length == 0 && _options == StringSplitOptions.RemoveEmptyEntries)
					{
						continue;
					}
					_current = current;
					return true;
				}
				if (length != 0)
				{
					_current = new Substring(in _substring, in start, in length);
					return true;
				}
				return false;
			}

			public void Reset()
			{
				_index = 0;
			}

			public void Dispose()
			{
			}
		}

		private static class Throw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void IndexOutOfRangeException(string message = null)
			{
				throw new IndexOutOfRangeException(message);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ArgumentNullException(string argument)
			{
				throw new ArgumentNullException(argument);
			}
		}

		public readonly string String;

		public readonly int Start;

		public readonly int Length;

		public char this[in int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index < 0 || index >= Length)
				{
					Throw.IndexOutOfRangeException();
				}
				return String[index + Start];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Substring(string str)
			: this(str, 0, str.Length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Substring(in Substring substring)
			: this(substring.String, in substring.Start, in substring.Length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Substring(in Substring substring, in int start)
			: this(substring.String, substring.Start + start, substring.Length - start)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Substring(in Substring substring, in int start, in int length)
			: this(substring.String, substring.Start + start, in length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Substring(string str, in int start)
			: this(str, in start, str.Length - start)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Substring(string str, in int start, in int length)
		{
			this = default(Substring);
			if (string.IsNullOrEmpty(str))
			{
				Throw.ArgumentNullException("str");
			}
			String = str;
			Start = start;
			Length = length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Substring other)
		{
			if (Length != other.Length)
			{
				return false;
			}
			return string.CompareOrdinal(String, Start, other.String, other.Start, Length) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string other)
		{
			if (Length != other?.Length)
			{
				return false;
			}
			return string.CompareOrdinal(String, Start, other, 0, Length) == 0;
		}

		public override bool Equals(object obj)
		{
			if (obj is Substring other)
			{
				return Equals(other);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (String.GetHashCode() * 397) ^ Length;
		}

		public override string ToString()
		{
			return String.Substring(Start, Length);
		}

		public static bool EqualsIgnoreCase(in Substring a, in Substring b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}
			for (int i = 0; i < a.Length; i++)
			{
				if (!char.ToLowerInvariant(a[in i]).Equals(char.ToLowerInvariant(b[in i])))
				{
					return false;
				}
			}
			return true;
		}

		public static SplitEnumerator Split(in Substring str, in char separator, in StringSplitOptions options = StringSplitOptions.None)
		{
			return new SplitEnumerator(str, separator, options);
		}

		public static Substring TrimStart(in Substring str, in char trimChar)
		{
			int index = 0;
			int length = str.Length;
			while (str[in index] == trimChar)
			{
				index++;
				length--;
			}
			return new Substring(in str, in index, in length);
		}

		public static Substring TrimEnd(in Substring str, in char trimChar)
		{
			int index = str.Length - 1;
			int length = str.Length;
			while (str[in index] == trimChar)
			{
				index--;
				length--;
			}
			return new Substring(in str, 0, in length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Substring Trim(in Substring str, in char trimChar)
		{
			return TrimEnd(TrimStart(in str, in trimChar), in trimChar);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool StartsWith(in Substring substring, in char c)
		{
			return substring[0] == c;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EndsWith(in Substring substring, in char c)
		{
			return substring[substring.Length - 1] == c;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SubstringEnumerator GetEnumerator()
		{
			return new SubstringEnumerator(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(in Substring a, in Substring b)
		{
			return a.Equals(b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(in Substring a, in Substring b)
		{
			return !a.Equals(b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(in Substring a, string b)
		{
			return a.Equals(b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(in Substring a, string b)
		{
			return !a.Equals(b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(string a, in Substring b)
		{
			return b.Equals(a);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(string a, in Substring b)
		{
			return !b.Equals(a);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Contains(in Substring substring, in char c)
		{
			return IndexOf(in substring, in c) != -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexOf(in Substring substring, in char c)
		{
			return IndexOf(in substring, in c, 0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexOf(in Substring substring, in char c, int startIndex)
		{
			if (!IndexOf(in substring, in c, in startIndex, out var index))
			{
				return -1;
			}
			return index;
		}

		public static bool IndexOf(in Substring substring, in char c, out int index)
		{
			return IndexOf(in substring, in c, 0, out index);
		}

		public static bool IndexOf(in Substring substring, in char c, in int startIndex, out int index)
		{
			for (index = startIndex; index < substring.Length; index++)
			{
				if (substring[in index] == c)
				{
					return true;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LastIndexOf(in Substring substring, in char c)
		{
			return LastIndexOf(in substring, in c, 0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LastIndexOf(in Substring substring, in char c, int startIndex)
		{
			if (!LastIndexOf(in substring, in c, startIndex, out var index))
			{
				return -1;
			}
			return index;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool LastIndexOf(in Substring substring, in char c, out int index)
		{
			return LastIndexOf(in substring, in c, 0, out index);
		}

		public static bool LastIndexOf(in Substring substring, in char c, int startIndex, out int index)
		{
			for (index = substring.Length - 1; index >= startIndex; index--)
			{
				if (substring[in index] == c)
				{
					return true;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Substring(string a)
		{
			return new Substring(a);
		}
	}
}
