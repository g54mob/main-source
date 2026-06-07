using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Unity.Collections;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromFixedString128Bytes : IValueEnumerator<Unicode.Rune>, IDisposable
	{
		private FixedString128Bytes.Enumerator enumerator;

		public FromFixedString128Bytes(FixedString128Bytes source)
		{
			enumerator = source.GetEnumerator();
		}

		public void Dispose()
		{
		}

		public bool TryCopyTo(Span<Unicode.Rune> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out Unicode.Rune current)
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				return true;
			}
			current = default(Unicode.Rune);
			return false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<Unicode.Rune> span)
		{
			span = default(ReadOnlySpan<Unicode.Rune>);
			return false;
		}
	}
}
