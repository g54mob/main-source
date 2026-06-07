using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Internal
{
	internal sealed class HashSetSlim<T> : IDisposable where T : notnull
	{
		[StructLayout((LayoutKind)3)]
		[DebuggerDisplay("HashCode = {HashCode}, Value = {Value}, Next = {Next}")]
		private struct Entry
		{
			public uint HashCode;

			public T Value;

			public int Next;
		}

		private const int MinimumSize = 16;

		private const double LoadFactor = 0.72;

		private readonly IEqualityComparer<T> comparer;

		private Entry[] entries;

		private int[] buckets;

		private int bucketsLength;

		private int entryIndex;

		private int resizeThreshold;

		public HashSetSlim(IEqualityComparer<T>? comparer)
		{
		}

		public HashSetSlim(int capacity, IEqualityComparer<T>? comparer)
		{
		}

		public bool Add(T item)
		{
			return false;
		}

		private void Resize()
		{
		}

		public bool Remove(T item)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(T key)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
