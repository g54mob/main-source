using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	internal struct LookupBuilder<TKey, TElement>
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
			buckets = null;
			bucketsLength = 0;
			last = null;
			groupCount = 0;
			this.comparer = comparer ?? EqualityComparer<TKey>.Default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			return (int)(hashCode & (bucketsLength - 1));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(TKey key)
		{
			if (key != null)
			{
				return (uint)(comparer.GetHashCode(key) & 0x7FFFFFFF);
			}
			return 0u;
		}

		public void Add(TKey key, TElement value)
		{
			if (buckets == null)
			{
				buckets = ArrayPool<Grouping<TKey, TElement>>.Shared.Rent(16);
				bucketsLength = 16;
			}
			uint hashCode = InternalGetHashCode(key);
			int bucketIndex = GetBucketIndex(hashCode);
			ref Grouping<TKey, TElement> reference = ref buckets[bucketIndex];
			if (reference == null)
			{
				if (groupCount != 0 && (double)groupCount / (double)bucketsLength > 0.72)
				{
					ResizeAndRehash();
					reference = ref buckets[GetBucketIndex(hashCode)];
				}
				reference = new Grouping<TKey, TElement>(key, hashCode, value);
				groupCount++;
				if (last != null)
				{
					reference.NextGroupInAddOrder = last.NextGroupInAddOrder;
					last.NextGroupInAddOrder = reference;
				}
				else
				{
					reference.NextGroupInAddOrder = reference;
				}
				last = reference;
				return;
			}
			if (comparer.Equals(reference.Key, key))
			{
				reference.Add(value);
				return;
			}
			Grouping<TKey, TElement> grouping = reference;
			for (Grouping<TKey, TElement> nextGroupInSameHashCode = reference.NextGroupInSameHashCode; nextGroupInSameHashCode != null; nextGroupInSameHashCode = nextGroupInSameHashCode.NextGroupInSameHashCode)
			{
				if (comparer.Equals(nextGroupInSameHashCode.Key, key))
				{
					nextGroupInSameHashCode.Add(value);
					return;
				}
				grouping = nextGroupInSameHashCode;
			}
			Grouping<TKey, TElement> grouping2 = (grouping.NextGroupInSameHashCode = new Grouping<TKey, TElement>(key, hashCode, value));
			groupCount++;
			if (last != null)
			{
				grouping2.NextGroupInAddOrder = last.NextGroupInAddOrder;
				last.NextGroupInAddOrder = grouping2;
			}
			else
			{
				grouping2.NextGroupInAddOrder = grouping2;
			}
			last = grouping2;
		}

		public Lookup<TKey, TElement> BuildAndClear()
		{
			if (groupCount == 0 || buckets == null)
			{
				return Lookup<TKey, TElement>.Empty;
			}
			Grouping<TKey, TElement>[] groupings = buckets.AsSpan(0, bucketsLength).ToArray();
			ArrayPool<Grouping<TKey, TElement>>.Shared.Return(buckets, clearArray: true);
			return new Lookup<TKey, TElement>(groupings, last, groupCount, comparer);
		}

		internal Grouping<TKey, TElement>? GetRootGroupAndClear()
		{
			if (groupCount == 0 || buckets == null)
			{
				return null;
			}
			ArrayPool<Grouping<TKey, TElement>>.Shared.Return(buckets, clearArray: true);
			return last?.NextGroupInAddOrder;
		}

		private void ResizeAndRehash()
		{
			if (last == null)
			{
				return;
			}
			Grouping<TKey, TElement> nextGroupInAddOrder = last.NextGroupInAddOrder;
			if (nextGroupInAddOrder == null)
			{
				return;
			}
			uint minimumLength = BitOperations.RoundUpToPowerOf2((uint)(bucketsLength * 2));
			ArrayPool<Grouping<TKey, TElement>>.Shared.Return(buckets, clearArray: true);
			Grouping<TKey, TElement>[] array = (buckets = ArrayPool<Grouping<TKey, TElement>>.Shared.Rent((int)minimumLength));
			bucketsLength = (int)minimumLength;
			Grouping<TKey, TElement> grouping = nextGroupInAddOrder;
			do
			{
				nextGroupInAddOrder.NextGroupInSameHashCode = null;
				ref Grouping<TKey, TElement> reference = ref array[GetBucketIndex(nextGroupInAddOrder.HashCode)];
				if (reference == null)
				{
					reference = nextGroupInAddOrder;
				}
				else
				{
					Grouping<TKey, TElement> grouping2 = reference;
					while (grouping2.NextGroupInSameHashCode != null)
					{
						grouping2 = grouping2.NextGroupInSameHashCode;
					}
					grouping2.NextGroupInSameHashCode = nextGroupInAddOrder;
				}
				nextGroupInAddOrder = nextGroupInAddOrder.NextGroupInAddOrder;
			}
			while (nextGroupInAddOrder != null && nextGroupInAddOrder != grouping);
			buckets = array;
		}
	}
}
