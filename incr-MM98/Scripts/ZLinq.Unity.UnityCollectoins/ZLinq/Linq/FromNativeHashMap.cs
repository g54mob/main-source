using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Unity.Collections;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromNativeHashMap<TKey, TValue> : IValueEnumerator<KVPair<TKey, TValue>>, IDisposable where TKey : unmanaged, IEquatable<TKey> where TValue : unmanaged
	{
		private NativeHashMap<TKey, TValue>.ReadOnly source;

		private NativeHashMap<TKey, TValue>.Enumerator enumerator;

		public FromNativeHashMap(NativeHashMap<TKey, TValue>.ReadOnly source)
		{
			this.source = source;
			enumerator = source.GetEnumerator();
		}

		public void Dispose()
		{
		}

		public bool TryCopyTo(Span<KVPair<TKey, TValue>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out KVPair<TKey, TValue> current)
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				return true;
			}
			current = default(KVPair<TKey, TValue>);
			return false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = source.Count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<KVPair<TKey, TValue>> span)
		{
			span = default(ReadOnlySpan<KVPair<TKey, TValue>>);
			return false;
		}
	}
}
