using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromReadOnlySequence<T> : IValueEnumerator<T>, IDisposable
	{
		private bool isInit;

		private ReadOnlySequence<T>.Enumerator sequenceEnumerator;

		private FromMemory<T> enumerator;

		public FromReadOnlySequence(ReadOnlySequence<T> source)
		{
			_003Csource_003EP = source;
			sequenceEnumerator = default(ReadOnlySequence<T>.Enumerator);
			enumerator = default(FromMemory<T>);
			isInit = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (_003Csource_003EP.Length <= 2147483591)
			{
				count = checked((int)_003Csource_003EP.Length);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			if (_003Csource_003EP.IsSingleSegment)
			{
				span = _003Csource_003EP.First.Span;
				return true;
			}
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<T> destination, Index offset)
		{
			int start;
			int count;
			if (_003Csource_003EP.IsSingleSegment)
			{
				if (EnumeratorHelper.TryGetSlice(_003Csource_003EP.First.Span, offset, destination.Length, out var slice))
				{
					slice.CopyTo(destination);
					return true;
				}
			}
			else if (EnumeratorHelper.TryGetSliceRange(checked((int)_003Csource_003EP.Length), offset, destination.Length, out start, out count))
			{
				_003Csource_003EP.Slice(start, count).CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out T current)
		{
			if (!isInit)
			{
				isInit = true;
				sequenceEnumerator = _003Csource_003EP.GetEnumerator();
			}
			while (true)
			{
				if (enumerator.TryGetNext(out current))
				{
					return true;
				}
				if (!sequenceEnumerator.MoveNext())
				{
					break;
				}
				enumerator = sequenceEnumerator.Current.AsValueEnumerable().Enumerator;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
