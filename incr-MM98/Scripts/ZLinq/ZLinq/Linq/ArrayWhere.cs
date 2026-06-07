using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ArrayWhere<TSource> : IValueEnumerator<TSource>, IDisposable
	{
		private TSource[] source;

		private int index;

		internal Func<TSource, bool> Predicate => _003Cpredicate_003EP;

		public ArrayWhere(FromArray<TSource> source, Func<TSource, bool> predicate)
		{
			_003Cpredicate_003EP = predicate;
			index = 0;
			this.source = source.GetSource();
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

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo(Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			while ((uint)index < (uint)source.Length)
			{
				TSource val = source[index];
				index++;
				if (_003Cpredicate_003EP(val))
				{
					current = val;
					return true;
				}
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
		}

		public ArrayWhereSelect<TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			return new ArrayWhereSelect<TSource, TResult>(source, _003Cpredicate_003EP, selector);
		}
	}
}
