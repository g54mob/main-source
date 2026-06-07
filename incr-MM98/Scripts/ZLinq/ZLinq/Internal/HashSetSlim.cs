using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Internal
{
	internal sealed class HashSetSlim<T> : IDisposable
	{
		[StructLayout(LayoutKind.Auto)]
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
			: this(16, comparer)
		{
		}

		public HashSetSlim(int capacity, IEqualityComparer<T>? comparer)
		{
			capacity = Math.Max((int)BitOperations.RoundUpToPowerOf2((uint)capacity), 16);
			this.comparer = comparer ?? EqualityComparer<T>.Default;
			buckets = ArrayPool<int>.Shared.Rent(capacity);
			entries = ArrayPool<Entry>.Shared.Rent(capacity);
			bucketsLength = capacity;
			resizeThreshold = (int)((double)bucketsLength * 0.72);
			buckets.AsSpan().Clear();
		}

		public bool Add(T item)
		{
			uint num = InternalGetHashCode(item);
			ref int reference = ref buckets[GetBucketIndex(num)];
			int num2 = reference - 1;
			while (num2 != -1)
			{
				ref Entry reference2 = ref entries[num2];
				if (reference2.HashCode == num && comparer.Equals(reference2.Value, item))
				{
					return false;
				}
				num2 = reference2.Next;
			}
			if (entryIndex > resizeThreshold)
			{
				Resize();
				reference = ref buckets[GetBucketIndex(num)];
			}
			ref Entry reference3 = ref entries[entryIndex];
			reference3.HashCode = num;
			reference3.Value = item;
			reference3.Next = reference - 1;
			reference = entryIndex + 1;
			entryIndex++;
			return true;
		}

		private void Resize()
		{
			uint minimumLength = BitOperations.RoundUpToPowerOf2((uint)(entries.Length * 2));
			Entry[] array = ArrayPool<Entry>.Shared.Rent((int)minimumLength);
			int[] array2 = ArrayPool<int>.Shared.Rent((int)minimumLength);
			bucketsLength = (int)minimumLength;
			resizeThreshold = (int)((double)bucketsLength * 0.72);
			array2.AsSpan().Clear();
			Array.Copy(entries, array, entryIndex);
			for (int i = 0; i < entryIndex; i++)
			{
				ref Entry reference = ref array[i];
				int bucketIndex = GetBucketIndex(reference.HashCode);
				ref int reference2 = ref array2[bucketIndex];
				reference.Next = reference2 - 1;
				reference2 = i + 1;
			}
			ArrayPool<int>.Shared.Return(buckets);
			ArrayPool<Entry>.Shared.Return(entries, RuntimeHelpers.IsReferenceOrContainsReferences<Entry>());
			entries = array;
			buckets = array2;
		}

		public bool Remove(T item)
		{
			uint num = InternalGetHashCode(item);
			ref int reference = ref buckets[GetBucketIndex(num)];
			int num2 = reference - 1;
			int num3 = -1;
			while (num2 != -1)
			{
				ref Entry reference2 = ref entries[num2];
				if (reference2.HashCode == num && comparer.Equals(reference2.Value, item))
				{
					if (num3 == -1)
					{
						reference = reference2.Next + 1;
					}
					else
					{
						entries[num3].Next = reference2.Next;
					}
					if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
					{
						reference2.Value = default(T);
					}
					return true;
				}
				num3 = num2;
				num2 = reference2.Next;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(T key)
		{
			if (key != null)
			{
				return (uint)(comparer.GetHashCode(key) & 0x7FFFFFFF);
			}
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			return (int)(hashCode & (bucketsLength - 1));
		}

		public void Dispose()
		{
			if (buckets != null)
			{
				ArrayPool<int>.Shared.Return(buckets);
				buckets = null;
			}
			if (entries != null)
			{
				ArrayPool<Entry>.Shared.Return(entries, RuntimeHelpers.IsReferenceOrContainsReferences<Entry>());
				entries = null;
			}
		}
	}
}
