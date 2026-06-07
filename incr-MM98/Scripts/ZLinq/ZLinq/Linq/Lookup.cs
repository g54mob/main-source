using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal static class Lookup
	{
		public static Lookup<TKey, TSource> CreateForJoin<TEnumerator, TSource, TKey>(ref TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			LookupBuilder<TKey, TSource> lookupBuilder = new LookupBuilder<TKey, TSource>(comparer ?? EqualityComparer<TKey>.Default);
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val = readOnlySpan[i];
					TKey val2 = keySelector(val);
					if (val2 != null)
					{
						lookupBuilder.Add(val2, val);
					}
				}
			}
			else
			{
				TSource current;
				while (source.TryGetNext(out current))
				{
					TKey val3 = keySelector(current);
					if (val3 != null)
					{
						lookupBuilder.Add(val3, current);
					}
				}
			}
			return lookupBuilder.BuildAndClear();
		}
	}
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(LookupDebugView<, >))]
	public sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>, IEnumerable<IGrouping<TKey, TElement>>, IEnumerable, ICollection<IGrouping<TKey, TElement>>, IReadOnlyCollection<IGrouping<TKey, TElement>>
	{
		internal static readonly Lookup<TKey, TElement> Empty = new Lookup<TKey, TElement>();

		private readonly Grouping<TKey, TElement>?[]? groups;

		private readonly Grouping<TKey, TElement>? last;

		private readonly int count;

		private readonly IEqualityComparer<TKey> comparer;

		public IEnumerable<TElement> this[TKey key]
		{
			get
			{
				Grouping<TKey, TElement> grouping = GetGroup(key);
				if (grouping != null)
				{
					return grouping;
				}
				return Array.Empty<TElement>();
			}
		}

		public int Count => count;

		bool ICollection<IGrouping<TKey, TElement>>.IsReadOnly => true;

		private Lookup()
		{
			groups = null;
			last = null;
			count = 0;
			comparer = null;
		}

		internal Lookup(Grouping<TKey, TElement>[]? groupings, Grouping<TKey, TElement>? last, int count, IEqualityComparer<TKey> comparer)
		{
			if (groupings == null)
			{
				groups = null;
				this.last = null;
				this.count = 0;
				this.comparer = comparer;
			}
			else
			{
				groups = groupings;
				this.count = count;
				this.last = last;
				this.comparer = comparer;
			}
		}

		public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
		{
			ArgumentNullException.ThrowIfNull(resultSelector, "resultSelector");
			if (last == null)
			{
				yield break;
			}
			Grouping<TKey, TElement> group = last.NextGroupInAddOrder;
			if (group != null)
			{
				Grouping<TKey, TElement> first = group;
				do
				{
					yield return resultSelector(group.Key, group);
					group = group.NextGroupInAddOrder;
				}
				while (group != null && group != first);
			}
		}

		public bool Contains(TKey key)
		{
			return GetGroup(key) != null;
		}

		internal Grouping<TKey, TElement>? GetGroup(TKey key)
		{
			if (groups == null)
			{
				return null;
			}
			uint hashCode = InternalGetHashCode(key);
			int bucketIndex = GetBucketIndex(hashCode);
			for (Grouping<TKey, TElement> grouping = groups[bucketIndex]; grouping != null; grouping = grouping.NextGroupInSameHashCode)
			{
				if (comparer.Equals(grouping.Key, key))
				{
					return grouping;
				}
			}
			return null;
		}

		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			if (last == null)
			{
				yield break;
			}
			Grouping<TKey, TElement> group = last.NextGroupInAddOrder;
			if (group != null)
			{
				Grouping<TKey, TElement> first = group;
				do
				{
					yield return group;
					group = group.NextGroupInAddOrder;
				}
				while (group != null && group != first);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			Grouping<TKey, TElement>[] array = groups;
			return (int)(hashCode & (array.Length - 1));
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

		void ICollection<IGrouping<TKey, TElement>>.Add(IGrouping<TKey, TElement> item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<IGrouping<TKey, TElement>>.Remove(IGrouping<TKey, TElement> item)
		{
			throw new NotSupportedException();
		}

		void ICollection<IGrouping<TKey, TElement>>.Clear()
		{
			throw new NotSupportedException();
		}

		bool ICollection<IGrouping<TKey, TElement>>.Contains(IGrouping<TKey, TElement> item)
		{
			Grouping<TKey, TElement> grouping = GetGroup(item.Key);
			if (grouping != null && grouping == item)
			{
				return true;
			}
			return false;
		}

		void ICollection<IGrouping<TKey, TElement>>.CopyTo(IGrouping<TKey, TElement>[] array, int arrayIndex)
		{
			ArgumentNullException.ThrowIfNull(array, "array");
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "Non-negative number required.");
			}
			if (arrayIndex > array.Length)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "Index was out of range. Must be non-negative and less than the size of the collection.");
			}
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "Destination array is not long enough to copy all the items in the collection. Check array index and length.");
			}
			if (last == null)
			{
				return;
			}
			Grouping<TKey, TElement> nextGroupInAddOrder = last.NextGroupInAddOrder;
			if (nextGroupInAddOrder != null)
			{
				Grouping<TKey, TElement> grouping = nextGroupInAddOrder;
				do
				{
					array[arrayIndex] = nextGroupInAddOrder;
					arrayIndex++;
					nextGroupInAddOrder = nextGroupInAddOrder.NextGroupInAddOrder;
				}
				while (nextGroupInAddOrder != null && nextGroupInAddOrder != grouping);
			}
		}
	}
}
