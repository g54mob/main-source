using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Jundroo.Common.DataTypes
{
	public ref struct SpanStringBuilder
	{
		private Span<char> _span;

		private int _spanIndex;

		private StringBuilder _stringBuilder;

		private bool _usesStringBuilder;

		public int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (!_usesStringBuilder)
				{
					return _span.Length;
				}
				return _stringBuilder.Capacity;
			}
		}

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (!_usesStringBuilder)
				{
					return _spanIndex;
				}
				return _stringBuilder.Length;
			}
		}

		public bool UsesCharacterSpan => !_usesStringBuilder;

		public bool UsesStringBuilder => _usesStringBuilder;

		public SpanStringBuilder(Span<char> span)
		{
			_stringBuilder = null;
			_span = span;
			_spanIndex = 0;
			_usesStringBuilder = false;
		}

		public SpanStringBuilder(StringBuilder stringBuilder)
		{
			_stringBuilder = stringBuilder;
			_span = null;
			_spanIndex = 0;
			_usesStringBuilder = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(char c)
		{
			if (_usesStringBuilder)
			{
				_stringBuilder.Append(c);
			}
			else
			{
				_span[_spanIndex++] = c;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Remove(int startIndex)
		{
			if (_usesStringBuilder)
			{
				_stringBuilder.Remove(startIndex, _stringBuilder.Length - startIndex);
			}
			else
			{
				_spanIndex = startIndex;
			}
		}

		public override string ToString()
		{
			if (!_usesStringBuilder)
			{
				return new string(_span.Slice(0, _spanIndex));
			}
			return _stringBuilder.ToString();
		}
	}
}
