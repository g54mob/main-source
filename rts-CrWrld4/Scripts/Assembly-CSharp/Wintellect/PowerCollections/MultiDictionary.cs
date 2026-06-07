using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class MultiDictionary<TKey, TValue> : MultiDictionaryBase<TKey, TValue>, ICloneable
	{
		[Serializable]
		private struct KeyAndValues
		{
			public TKey Key;

			public int Count;

			public TValue[] Values;

			public KeyAndValues(TKey key)
			{
				Key = default(TKey);
				Count = 0;
				Values = null;
			}

			public static KeyAndValues Copy(KeyAndValues x)
			{
				return default(KeyAndValues);
			}
		}

		[Serializable]
		private class KeyAndValuesEqualityComparer : IEqualityComparer<KeyAndValues>
		{
			private readonly IEqualityComparer<TKey> keyEqualityComparer;

			public KeyAndValuesEqualityComparer(IEqualityComparer<TKey> keyEqualityComparer)
			{
			}

			public bool Equals(KeyAndValues x, KeyAndValues y)
			{
				return false;
			}

			public int GetHashCode(KeyAndValues obj)
			{
				return 0;
			}
		}

		private readonly IEqualityComparer<TKey> keyEqualityComparer;

		private readonly IEqualityComparer<TValue> valueEqualityComparer;

		private readonly IEqualityComparer<KeyAndValues> equalityComparer;

		private Hash<KeyAndValues> hash;

		private readonly bool allowDuplicateValues;

		public IEqualityComparer<TKey> KeyComparer => null;

		public IEqualityComparer<TValue> ValueComparer => null;

		public sealed override int Count => 0;

		public MultiDictionary(bool allowDuplicateValues)
		{
		}

		public MultiDictionary(bool allowDuplicateValues, IEqualityComparer<TKey> keyEqualityComparer)
		{
		}

		public MultiDictionary(bool allowDuplicateValues, IEqualityComparer<TKey> keyEqualityComparer, IEqualityComparer<TValue> valueEqualityComparer)
		{
		}

		private MultiDictionary(bool allowDuplicateValues, IEqualityComparer<TKey> keyEqualityComparer, IEqualityComparer<TValue> valueEqualityComparer, IEqualityComparer<KeyAndValues> equalityComparer, Hash<KeyAndValues> hash)
		{
		}

		public sealed override void Add(TKey key, TValue value)
		{
		}

		public sealed override bool Remove(TKey key, TValue value)
		{
			return false;
		}

		public sealed override bool Remove(TKey key)
		{
			return false;
		}

		public sealed override void Clear()
		{
		}

		protected sealed override bool EqualValues(TValue value1, TValue value2)
		{
			return false;
		}

		public sealed override bool Contains(TKey key, TValue value)
		{
			return false;
		}

		public sealed override bool ContainsKey(TKey key)
		{
			return false;
		}

		protected sealed override IEnumerator<TKey> EnumerateKeys()
		{
			return null;
		}

		private IEnumerator<TValue> EnumerateValues(KeyAndValues keyAndValues)
		{
			return null;
		}

		protected sealed override bool TryEnumerateValuesForKey(TKey key, out IEnumerator<TValue> values)
		{
			values = null;
			return false;
		}

		protected sealed override int CountValues(TKey key)
		{
			return 0;
		}

		public MultiDictionary<TKey, TValue> Clone()
		{
			return null;
		}

		object ICloneable.Clone()
		{
			return null;
		}

		private static void NonCloneableType(Type t)
		{
		}

		public MultiDictionary<TKey, TValue> CloneContents()
		{
			return null;
		}
	}
}
