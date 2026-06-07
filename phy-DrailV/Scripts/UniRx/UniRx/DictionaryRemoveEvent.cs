using System;
using System.Collections.Generic;

namespace UniRx
{
	public struct DictionaryRemoveEvent<TKey, TValue> : IEquatable<DictionaryRemoveEvent<TKey, TValue>>
	{
		public TKey Key { get; private set; }

		public TValue Value { get; private set; }

		public DictionaryRemoveEvent(TKey key, TValue value)
		{
			this = default(DictionaryRemoveEvent<TKey, TValue>);
			Key = key;
			Value = value;
		}

		public override string ToString()
		{
			return $"Key:{Key} Value:{Value}";
		}

		public override int GetHashCode()
		{
			return EqualityComparer<TKey>.Default.GetHashCode(Key) ^ (EqualityComparer<TValue>.Default.GetHashCode(Value) << 2);
		}

		public bool Equals(DictionaryRemoveEvent<TKey, TValue> other)
		{
			if (EqualityComparer<TKey>.Default.Equals(Key, other.Key))
			{
				return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
			}
			return false;
		}
	}
}
