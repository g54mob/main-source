using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.StringUtils
{
	internal struct StringEnumerator : IEnumerator<char>, IEnumerator, IDisposable
	{
		private readonly string _text;

		private readonly int _length;

		private int _index;

		public char Current => _text[_index];

		object IEnumerator.Current => Current;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public StringEnumerator(string text)
		{
			_text = text;
			_length = _text.Length;
			_index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			return ++_index < _length;
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
}
