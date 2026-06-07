using System;
using System.Collections.Generic;

namespace Coherence.Cloud
{
	internal readonly struct StorageItem : IEquatable<StorageItem>
	{
		public Key Key { get; }

		public Value Value { get; }

		public StorageItem(Key key, Value value)
		{
			Key = default(Key);
			Value = default(Value);
		}

		public StorageItem(Key key, object value)
		{
			Key = default(Key);
			Value = default(Value);
		}

		public void Deconstruct(out Key key, out Value value)
		{
			key = default(Key);
			value = default(Value);
		}

		public bool Equals(StorageItem other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(StorageItem left, StorageItem right)
		{
			return false;
		}

		public static bool operator !=(StorageItem left, StorageItem right)
		{
			return false;
		}

		public static implicit operator StorageItem(KeyValuePair<Key, Value> item)
		{
			return default(StorageItem);
		}

		public static implicit operator StorageItem((Key key, Value value) item)
		{
			return default(StorageItem);
		}

		public static implicit operator KeyValuePair<Key, Value>(StorageItem item)
		{
			return default(KeyValuePair<Key, Value>);
		}

		public static implicit operator Value(StorageItem item)
		{
			return default(Value);
		}
	}
}
