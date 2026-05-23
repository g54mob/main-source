using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	internal struct LookupBuilder<TKey, TElement> where TKey : notnull where TElement : notnull
	{
		private const int MinimumSize = 16;

		private const double LoadFactor = 0.72;

		private readonly IEqualityComparer<TKey> comparer;

		private Grouping<TKey, TElement>[]? buckets;

		private int bucketsLength;

		private Grouping<TKey, TElement>? last;

		private int groupCount;

		public LookupBuilder(IEqualityComparer<TKey>? comparer)
		{
			this.comparer = null;
			buckets = null;
			bucketsLength = 0;
			last = null;
			groupCount = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(TKey key)
		{
			return 0u;
		}

		public void Add(TKey key, TElement value)
		{
		}

		public Lookup<TKey, TElement> BuildAndClear()
		{
			return null;
		}

		internal Grouping<TKey, TElement> GetRootGroupAndClear()
		{
			return null;
		}

		private void ResizeAndRehash()
		{
		}
	}
}
