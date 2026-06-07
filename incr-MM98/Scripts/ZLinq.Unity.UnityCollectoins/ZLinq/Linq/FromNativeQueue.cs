using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Unity.Collections;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromNativeQueue<T> : IValueEnumerator<T>, IDisposable where T : unmanaged
	{
		private NativeQueue<T>.ReadOnly source;

		private NativeQueue<T>.Enumerator enumerator;

		public FromNativeQueue(NativeQueue<T>.ReadOnly source)
		{
			this.source = source;
			enumerator = source.GetEnumerator();
		}

		public void Dispose()
		{
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out T current)
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				return true;
			}
			current = default(T);
			return false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = source.Count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}
	}
}
