using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Reverse<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private RentedArrayBox<TSource>? buffer;

		private int index;

		public Reverse(TEnumerator source)
		{
			this.source = default(TEnumerator);
			buffer = null;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
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
			current = default(TSource);
			return false;
		}

		public void Dispose()
		{
		}

		[MemberNotNull("buffer")]
		private void InitBuffer()
		{
		}
	}
}
