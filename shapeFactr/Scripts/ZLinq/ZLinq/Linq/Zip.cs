using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Zip<TEnumerator, TEnumerator2, TFirst, TSecond> : IValueEnumerator<(TFirst, TSecond)>, IDisposable where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		public Zip(TEnumerator source, TEnumerator2 second)
		{
			this.source = default(TEnumerator);
			this.second = default(TEnumerator2);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<(TFirst First, TSecond Second)> span)
		{
			span = default(ReadOnlySpan<(TFirst, TSecond)>);
			return false;
		}

		public bool TryCopyTo(Span<(TFirst First, TSecond Second)> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out (TFirst First, TSecond Second) current)
		{
			current = default((TFirst, TSecond));
			return false;
		}

		public void Dispose()
		{
		}
	}
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird> : IValueEnumerator<(TFirst, TSecond, TThird)>, IDisposable where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond> where TEnumerator3 : struct, IValueEnumerator<TThird>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		private TEnumerator3 third;

		public Zip(TEnumerator source, TEnumerator2 second, TEnumerator3 third)
		{
			this.source = default(TEnumerator);
			this.second = default(TEnumerator2);
			this.third = default(TEnumerator3);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<(TFirst First, TSecond Second, TThird Third)> span)
		{
			span = default(ReadOnlySpan<(TFirst, TSecond, TThird)>);
			return false;
		}

		public bool TryCopyTo(Span<(TFirst First, TSecond Second, TThird Third)> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out (TFirst First, TSecond Second, TThird Third) current)
		{
			current = default((TFirst, TSecond, TThird));
			return false;
		}

		public void Dispose()
		{
		}
	}
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		public Zip(TEnumerator source, TEnumerator2 second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			_003CresultSelector_003EP = null;
			this.source = default(TEnumerator);
			this.second = default(TEnumerator2);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo(Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
