using System;

namespace Utf8Json.Internal
{
	internal class ThreadsafeTypeKeyHashTable<TValue>
	{
		private class Entry
		{
			public Type Key;

			public TValue Value;

			public int Hash;

			public Entry Next;

			public override string ToString()
			{
				return null;
			}

			private int Count()
			{
				return 0;
			}
		}

		private Entry[] buckets;

		private int size;

		private readonly object writerLock;

		private readonly float loadFactor;

		public ThreadsafeTypeKeyHashTable(int capacity = 4, float loadFactor = 0.75f)
		{
		}

		public bool TryAdd(Type key, TValue value)
		{
			return false;
		}

		public bool TryAdd(Type key, Func<Type, TValue> valueFactory)
		{
			return false;
		}

		private bool TryAddInternal(Type key, Func<Type, TValue> valueFactory, out TValue resultingValue)
		{
			resultingValue = default(TValue);
			return false;
		}

		private bool AddToBuckets(Entry[] buckets, Type newKey, Entry newEntryOrNull, Func<Type, TValue> valueFactory, out TValue resultingValue)
		{
			resultingValue = default(TValue);
			return false;
		}

		public bool TryGetValue(Type key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public TValue GetOrAdd(Type key, Func<Type, TValue> valueFactory)
		{
			return default(TValue);
		}

		private static int CalculateCapacity(int collectionSize, float loadFactor)
		{
			return 0;
		}

		private static void VolatileWrite(ref Entry location, Entry value)
		{
		}

		private static void VolatileWrite(ref Entry[] location, Entry[] value)
		{
		}
	}
}
