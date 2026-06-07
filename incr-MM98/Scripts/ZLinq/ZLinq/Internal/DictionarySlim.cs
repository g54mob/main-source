using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Internal
{
	internal sealed class DictionarySlim<TKey, TValue> : IDisposable
	{
		[StructLayout(LayoutKind.Auto)]
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
				_003Cdictionary_003EP = dictionary;
				index = 0;
			}

			public bool TryGetNext(out KeyValuePair<TKey, TValue> current)
			{
				if (index < _003Cdictionary_003EP.entryIndex)
				{
					ref Entry reference = ref _003Cdictionary_003EP.entries[index];
					index++;
					current = new KeyValuePair<TKey, TValue>(reference.Key, reference.Value);
					return true;
				}
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
			this.comparer = comparer ?? EqualityComparer<TKey>.Default;
			buckets = ArrayPool<int>.Shared.Rent(16);
			entries = ArrayPool<Entry>.Shared.Rent(16);
			bucketsLength = 16;
			resizeThreshold = (int)((double)bucketsLength * 0.72);
			buckets.AsSpan().Clear();
		}

		public ref TValue? GetValueRefOrAddDefault(TKey key, out bool exists)
		{
			uint num = InternalGetHashCode(key);
			ref int reference = ref buckets[GetBucketIndex(num)];
			int num2 = reference - 1;
			while (num2 != -1)
			{
				ref Entry reference2 = ref entries[num2];
				if (reference2.HashCode == num && comparer.Equals(reference2.Key, key))
				{
					exists = true;
					return ref reference2.Value;
				}
				num2 = reference2.Next;
			}
			exists = false;
			if (entryIndex > resizeThreshold)
			{
				Resize();
				reference = ref buckets[GetBucketIndex(num)];
			}
			ref Entry reference3 = ref entries[entryIndex];
			reference3.HashCode = num;
			reference3.Key = key;
			reference3.Value = default(TValue);
			reference3.Next = reference - 1;
			reference = entryIndex + 1;
			entryIndex++;
			return ref reference3.Value;
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(TKey key)
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

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
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
