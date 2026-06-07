using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Coherence.Cloud
{
	internal sealed class StorageObjectMutation : ICollection<StorageItem>, IEnumerable<StorageItem>, IEnumerable
	{
		internal readonly StorageObject storageObject;

		public StorageObjectMutationType Type { get; }

		public StorageObjectId ObjectId => default(StorageObjectId);

		public int Count => 0;

		public Dictionary<Key, Value>.KeyCollection Keys => null;

		public Dictionary<Key, Value>.ValueCollection Values => null;

		public Value this[Key key]
		{
			get
			{
				return default(Value);
			}
			set
			{
			}
		}

		bool ICollection<StorageItem>.IsReadOnly => false;

		public StorageObjectMutation(StorageObjectId objectId, StorageObjectMutationType type)
		{
		}

		public StorageObjectMutation(StorageObject storageObject, StorageObjectMutationType type = StorageObjectMutationType.Full)
		{
		}

		public bool ContainsKey(Key key)
		{
			return false;
		}

		public bool Contains(StorageItem item)
		{
			return false;
		}

		public bool TryGetValue(Key key, out Value value)
		{
			value = default(Value);
			return false;
		}

		public bool TryGetValue(Key key, out bool value)
		{
			value = default(bool);
			return false;
		}

		public bool TryGetValue(Key key, out int value)
		{
			value = default(int);
			return false;
		}

		public bool TryGetValue<TValue>(Key key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool TryGetValue(Key key, out string value)
		{
			value = null;
			return false;
		}

		public bool TryGetValue(Key key, out float value)
		{
			value = default(float);
			return false;
		}

		public bool TryGetValue(Key key, out double value)
		{
			value = default(double);
			return false;
		}

		public bool TryGetValue(Key key, out short value)
		{
			value = default(short);
			return false;
		}

		public bool TryGetValue(Key key, out byte value)
		{
			value = default(byte);
			return false;
		}

		public bool TryGetValue(Key key, out Enum value)
		{
			value = null;
			return false;
		}

		public void Clear()
		{
		}

		public bool Remove(Key key)
		{
			return false;
		}

		public bool Remove(StorageItem item)
		{
			return false;
		}

		public int RemoveItems([DisallowNull] IEnumerable<Key> keys)
		{
			return 0;
		}

		public int RemoveItems([DisallowNull] IEnumerable<StorageItem> items)
		{
			return 0;
		}

		public int RemoveItems([DisallowNull] params Key[] keys)
		{
			return 0;
		}

		public int RemoveItems([DisallowNull] params StorageItem[] items)
		{
			return 0;
		}

		public void SetItems([DisallowNull] IEnumerable<StorageItem> items)
		{
		}

		public void SetItems([DisallowNull] IEnumerable<KeyValuePair<Key, Value>> items)
		{
		}

		public void SetItems([DisallowNull] IEnumerable<KeyValuePair<string, string>> items)
		{
		}

		public void SetItems([DisallowNull] params StorageItem[] items)
		{
		}

		public void Set(StorageItem item)
		{
		}

		public void Set(Key key, Value value)
		{
		}

		void ICollection<StorageItem>.Add(StorageItem item)
		{
		}

		void ICollection<StorageItem>.CopyTo(StorageItem[] array, int arrayIndex)
		{
		}

		IEnumerator<StorageItem> IEnumerable<StorageItem>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
