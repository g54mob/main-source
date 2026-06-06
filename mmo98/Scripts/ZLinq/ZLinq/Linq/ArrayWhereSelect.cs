using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ArrayWhereSelect<TSource, TResult> : IValueEnumerator<TResult>, IDisposable
	{
		private int index;

		private TSource[] source;

		internal Func<TSource, bool> Predicate => _003Cpredicate_003EP;

		internal Func<TSource, TResult> Selector => _003Cselector_003EP;

		public ArrayWhereSelect(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			_003Cpredicate_003EP = predicate;
			_003Cselector_003EP = selector;
			index = 0;
			this.source = source;
		}

		internal TSource[] GetSource()
		{
			return source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
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
			while ((uint)index < (uint)source.Length)
			{
				TSource arg = source[index];
				index++;
				if (_003Cpredicate_003EP(arg))
				{
					current = _003Cselector_003EP(arg);
					return true;
				}
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
