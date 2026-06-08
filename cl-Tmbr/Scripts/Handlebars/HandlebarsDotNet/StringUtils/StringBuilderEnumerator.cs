using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HandlebarsDotNet.StringUtils
{
	internal struct StringBuilderEnumerator : IEnumerator<char>, IEnumerator, IDisposable
	{
		private readonly StringBuilder _stringBuilder;

		private int _index;

		object IEnumerator.Current => Current;

		public char Current => _stringBuilder[_index];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public StringBuilderEnumerator(StringBuilder stringBuilder)
		{
			this = default(StringBuilderEnumerator);
			_stringBuilder = stringBuilder;
			_index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			return ++_index < _stringBuilder.Length;
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
