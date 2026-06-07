using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public abstract class DictionaryBase<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, ISerializable, IDeserializationCallback
	{
		private readonly Dictionary<TKey, TValue> dictionary;

		public IEqualityComparer<TKey> Comparer
		{
			get
			{
				return dictionary.Comparer;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return dictionary[key];
			}
			set
			{
				SetItem(key, value);
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return dictionary.Keys;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				return dictionary.Values;
			}
		}

		public int Count
		{
			get
			{
				return dictionary.Count;
			}
		}

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)dictionary)[key];
			}
			set
			{
				VerifyKey(key);
				VerifyValueType(value);
				SetItem((TKey)key, (TValue)value);
			}
		}

		ICollection IDictionary.Keys
		{
			get
			{
				return ((IDictionary)dictionary).Keys;
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				return ((IDictionary)dictionary).Values;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IDictionary)dictionary).IsReadOnly;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return ((ICollection)dictionary).SyncRoot;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				return ((ICollection)dictionary).IsSynchronized;
			}
		}

		protected DictionaryBase()
		{
			dictionary = new Dictionary<TKey, TValue>();
		}

		protected DictionaryBase(IDictionary<TKey, TValue> dictionary)
		{
			this.dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		protected DictionaryBase(IEqualityComparer<TKey> comparer)
		{
			dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		protected DictionaryBase(int capacity)
		{
			dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		protected DictionaryBase(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			this.dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		protected DictionaryBase(int capacity, IEqualityComparer<TKey> comparer)
		{
			dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		protected DictionaryBase(SerializationInfo info, StreamingContext context)
		{
			ConstructorInfo constructor = typeof(Dictionary<TKey, TValue>).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, new Type[2]
			{
				typeof(SerializationInfo),
				typeof(StreamingContext)
			}, null);
			dictionary = (Dictionary<TKey, TValue>)constructor.Invoke(BindingFlags.NonPublic, null, new object[2] { info, context }, null);
		}

		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return dictionary.GetEnumerator();
		}

		protected virtual void AddItem(TKey key, TValue value)
		{
			dictionary.Add(key, value);
		}

		protected virtual void SetItem(TKey key, TValue value)
		{
			dictionary[key] = value;
		}

		protected virtual bool RemoveItem(TKey key)
		{
			return dictionary.Remove(key);
		}

		protected virtual void ClearItems()
		{
			dictionary.Clear();
		}

		private static void VerifyKey(object key)
		{
			Guard.ArgumentNotNull(key, "key");
			if (!(key is TKey))
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Keys is of type {0}.", typeof(TKey)), "key");
			}
		}

		private static void VerifyValueType(object value)
		{
			if (!(value is TValue) && (value != null || typeof(TValue).IsValueType))
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Value is of type {0}.", typeof(TValue)), "value");
			}
		}

		public bool ContainsKey(TKey key)
		{
			return dictionary.ContainsKey(key);
		}

		public void Add(TKey key, TValue value)
		{
			AddItem(key, value);
		}

		public bool Remove(TKey key)
		{
			return RemoveItem(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return dictionary.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			AddItem(keyValuePair.Key, keyValuePair.Value);
		}

		public void Clear()
		{
			ClearItems();
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			return ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Contains(keyValuePair);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)dictionary).CopyTo(array, arrayIndex);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			TValue value;
			if (TryGetValue(keyValuePair.Key, out value) && EqualityComparer<TValue>.Default.Equals(value, keyValuePair.Value))
			{
				RemoveItem(keyValuePair.Key);
				return true;
			}
			return false;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
		}

		void IDictionary.Add(object key, object value)
		{
			VerifyKey(key);
			VerifyValueType(value);
			AddItem((TKey)key, (TValue)value);
		}

		bool IDictionary.Contains(object key)
		{
			return ((IDictionary)dictionary).Contains(key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)dictionary).GetEnumerator();
		}

		void IDictionary.Remove(object key)
		{
			VerifyKey(key);
			Remove((TKey)key);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection)dictionary).CopyTo(array, index);
		}

		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			dictionary.GetObjectData(info, context);
		}

		public virtual void OnDeserialization(object sender)
		{
			dictionary.OnDeserialization(sender);
		}
	}
}
