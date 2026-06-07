using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromEmpty<T> : IValueEnumerator<T>, IDisposable
	{
		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return true;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			return true;
		}

		public bool TryGetNext(out T current)
		{
			Unsafe.SkipInit<T>(out current);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
