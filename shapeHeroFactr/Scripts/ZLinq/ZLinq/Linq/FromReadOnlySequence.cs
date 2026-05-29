using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	public struct FromReadOnlySequence<T> : IValueEnumerator<T>, IDisposable
	{
		private bool isInit;

		private ReadOnlySequence<T>.Enumerator sequenceEnumerator;

		private FromMemory<T> enumerator;

		public FromReadOnlySequence(ReadOnlySequence<T> source)
		{
			_003Csource_003EP = default(ReadOnlySequence<T>);
			isInit = false;
			sequenceEnumerator = default(ReadOnlySequence<T>.Enumerator);
			enumerator = default(FromMemory<T>);
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
