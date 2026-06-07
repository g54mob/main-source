using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	public struct FromStack<T> : IValueEnumerator<T>, IDisposable where T : notnull
	{
		private bool isInit;

		private Stack<T>.Enumerator enumerator;

		public FromStack(Stack<T> source)
		{
			_003Csource_003EP = null;
			isInit = false;
			enumerator = default(Stack<T>.Enumerator);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out T current)
		{
			current = default(T);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
