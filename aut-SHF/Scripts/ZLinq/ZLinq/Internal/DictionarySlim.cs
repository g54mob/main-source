using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Internal
{
	internal sealed class DictionarySlim<TKey, TValue> : IDisposable where TKey : notnull where TValue : notnull
	{
		[StructLayout((LayoutKind)3)]
		[DebuggerDisplay("HashCode = {HashCode}, Key = {Key}, Value =  {Value}, Next = {Next}")]
		private struct Entry
		{
			public uint HashCode;

			public TKey Key;

			public TValue? Value;

			public int Next;
		}

		public struct Enumerator
		{
			private int index;

			public Enumerator(DictionarySlim<TKey, TValue> dictionary)
			{
				_003Cdictionary_003EP = null;
				index = 0;
			}

			public bool TryGetNext(out KeyValuePair<TKey, TValue> current)
			{
				current = default(KeyValuePair<TKey, TValue>);
				return false;
			}
		}

		private const int MinimumSize = 16;

		private const double LoadFactor = 0.72;

		private readonly IEqualityComparer<TKey> comparer;

		private Entry[] entries;

		private int[] buckets;

		private int bucketsLength;

		private int entryIndex;

		private int resizeThreshold;

		public DictionarySlim(IEqualityComparer<TKey>? comparer = null)
		{
		}

		public ref TValue GetValueRefOrAddDefault(TKey key, out bool exists)
		{
			throw null;
		}

		private void Resize()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(TKey key)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			return 0;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public void Dispose()
		{
		}
	}
}
