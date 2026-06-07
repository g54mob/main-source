using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Zip<TEnumerator, TEnumerator2, TFirst, TSecond> : IValueEnumerator<(TFirst First, TSecond Second)>, IDisposable where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		public Zip(TEnumerator source, TEnumerator2 second)
		{
			this.source = source;
			this.second = second;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out var count2) && second.TryGetNonEnumeratedCount(out var count3))
			{
				count = Math.Min(count2, count3);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<(TFirst First, TSecond Second)> span)
		{
			span = default(ReadOnlySpan<(TFirst, TSecond)>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<(TFirst First, TSecond Second)> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out (TFirst First, TSecond Second) current)
		{
			if (source.TryGetNext(out TFirst current2) && second.TryGetNext(out TSecond current3))
			{
				current = (First: current2, Second: current3);
				return true;
			}
			current = default((TFirst, TSecond));
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
			second.Dispose();
		}
	}
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird> : IValueEnumerator<(TFirst First, TSecond Second, TThird Third)>, IDisposable where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond> where TEnumerator3 : struct, IValueEnumerator<TThird>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		private TEnumerator3 third;

		public Zip(TEnumerator source, TEnumerator2 second, TEnumerator3 third)
		{
			this.source = source;
			this.second = second;
			this.third = third;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out var count2) && second.TryGetNonEnumeratedCount(out var count3) && third.TryGetNonEnumeratedCount(out var count4))
			{
				count = Math.Min(Math.Min(count2, count3), count4);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<(TFirst First, TSecond Second, TThird Third)> span)
		{
			span = default(ReadOnlySpan<(TFirst, TSecond, TThird)>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<(TFirst First, TSecond Second, TThird Third)> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out (TFirst First, TSecond Second, TThird Third) current)
		{
			if (source.TryGetNext(out TFirst current2) && second.TryGetNext(out TSecond current3) && third.TryGetNext(out TThird current4))
			{
				current = (First: current2, Second: current3, Third: current4);
				return true;
			}
			current = default((TFirst, TSecond, TThird));
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
			second.Dispose();
			third.Dispose();
		}
	}
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		public Zip(TEnumerator source, TEnumerator2 second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			_003CresultSelector_003EP = resultSelector;
			this.source = source;
			this.second = second;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out var count2) && second.TryGetNonEnumeratedCount(out var count3))
			{
				count = Math.Min(count2, count3);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			if (source.TryGetNext(out TFirst current2) && second.TryGetNext(out TSecond current3))
			{
				current = _003CresultSelector_003EP(current2, current3);
				return true;
			}
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
			second.Dispose();
		}
	}
}
