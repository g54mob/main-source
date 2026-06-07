using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal struct InlineArray16<T> where T : notnull
	{
		private T item0;

		private T item1;

		private T item2;

		private T item3;

		private T item4;

		private T item5;

		private T item6;

		private T item7;

		private T item8;

		private T item9;

		private T item10;

		private T item11;

		private T item12;

		private T item13;

		private T item14;

		private T item15;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[UnscopedRef]
		internal Span<T> AsSpan()
		{
			return default(Span<T>);
		}
	}
}
