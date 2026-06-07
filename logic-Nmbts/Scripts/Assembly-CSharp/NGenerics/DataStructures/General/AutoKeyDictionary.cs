using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	[ComVisible(false)]
	[DebuggerDisplay("Count = {Count}")]
	public class AutoKeyDictionary<TKey, TItem> : ICollection<TItem>, IEnumerable<TItem>, IEnumerable, ISerializable, IDeserializationCallback
	{
		private readonly Dictionary<TKey, TItem> dictionary;

		public virtual Func<TItem, TKey> GetKeyForItem { get; private set; }

		public virtual IEqualityComparer<TKey> Comparer
		{
			get
			{
				return dictionary.Comparer;
			}
		}

		public virtual TItem this[TKey key]
		{
			get
			{
				return dictionary[key];
			}
		}

		public virtual Dictionary<TKey, TItem>.KeyCollection Keys
		{
			get
			{
				return dictionary.Keys;
			}
		}

		public virtual Dictionary<TKey, TItem>.ValueCollection Values
		{
			get
			{
				return dictionary.Values;
			}
		}

		public virtual int Count
		{
			get
			{
				return dictionary.Count;
			}
		}

		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem)
			: this(getKeyForItem, (IEqualityComparer<TKey>)null, 0)
		{
		}

		public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem, IEqualityComparer<TKey> comparer)
			: this(getKeyForItem, comparer, 0)
		{
		}

		public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem, int capacity)
		{
			Guard.ArgumentNotNull(getKeyForItem, "getKeyForItem");
			GetKeyForItem = getKeyForItem;
			dictionary = new Dictionary<TKey, TItem>(capacity);
		}

		public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem, IEqualityComparer<TKey> comparer, int capacity)
		{
			Guard.ArgumentNotNull(getKeyForItem, "getKeyForItem");
			GetKeyForItem = getKeyForItem;
			dictionary = new Dictionary<TKey, TItem>(capacity, comparer);
		}

		protected AutoKeyDictionary(SerializationInfo info, StreamingContext context)
		{
			ConstructorInfo constructor = typeof(Dictionary<TKey, TItem>).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, new Type[2]
			{
				typeof(SerializationInfo),
				typeof(StreamingContext)
			}, null);
			dictionary = (Dictionary<TKey, TItem>)constructor.Invoke(BindingFlags.NonPublic, null, new object[2] { info, context }, null);
		}

		public virtual bool TryAdd(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			TKey key = GetKeyForItem(item);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, item);
				return true;
			}
			return false;
		}

		public virtual bool TryRemove(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			TKey key = GetKeyForItem(item);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Remove(key);
				return true;
			}
			return false;
		}

		public virtual void Add(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			dictionary.Add(GetKeyForItem(item), item);
		}

		public void Clear()
		{
			dictionary.Clear();
		}

		public virtual bool Contains(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			TKey key = GetKeyForItem(item);
			return dictionary.ContainsKey(key);
		}

		public virtual void CopyTo(TItem[] array, int arrayIndex)
		{
			dictionary.Values.CopyTo(array, arrayIndex);
		}

		public virtual bool Remove(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			TKey key = GetKeyForItem(item);
			return dictionary.Remove(key);
		}

		public virtual IEnumerator<TItem> GetEnumerator()
		{
			return dictionary.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return dictionary.Values.GetEnumerator();
		}

		internal void InternalAdd(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			dictionary.Add(GetKeyForItem(item), item);
		}

		public virtual bool ContainsKey(TKey key)
		{
			return dictionary.ContainsKey(key);
		}

		public virtual bool RemoveKey(TKey key)
		{
			return dictionary.Remove(key);
		}

		internal bool InternalRemove(TKey key)
		{
			return dictionary.Remove(key);
		}

		internal bool InternalRemove(TItem item)
		{
			Guard.ArgumentNotNull(item, "item");
			TKey key = GetKeyForItem(item);
			return dictionary.Remove(key);
		}

		public virtual bool TryGetValue(TKey key, out TItem item)
		{
			return dictionary.TryGetValue(key, out item);
		}

		public virtual void OnDeserialization(object sender)
		{
			dictionary.OnDeserialization(sender);
		}

		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			dictionary.GetObjectData(info, context);
		}
	}
}
