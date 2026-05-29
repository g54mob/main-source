using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal sealed class KeyedGetSetValueStore<TKey> : IEnumerable, IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>
	{
		private readonly Dictionary<TKey, object> tCkUVslvkjTTTEIxYEGjEAbofDZ;

		private readonly bool KVbygKfLihWbcxiNRzjprbeyntu;

		public int Count => 0;

		public bool isReadOnlyCollection => false;

		ICollection<TKey> IDictionary<TKey, object>.Keys => null;

		ICollection<object> IDictionary<TKey, object>.Values => null;

		object IDictionary<TKey, object>.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => 0;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => false;

		public KeyedGetSetValueStore(Dictionary<TKey, object> valueDelegates, bool isReadOnlyCollection)
		{
		}

		public KeyedGetSetValueStore(bool isReadOnlyCollection)
		{
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			return null;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public void Clear()
		{
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			return default(TValue);
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			return false;
		}

		private void DhZBlglmsRvefaAMprzXOAEVrlo()
		{
		}

		private static void LZzBVWcENgjTWBwcnYXqyOYPjmx(TKey P_0, Type P_1)
		{
		}

		private static string wNODQsKYLovVPKCqPfmUJftWtcnj(TKey P_0, Type P_1)
		{
			return null;
		}

		void IDictionary<TKey, object>.Add(TKey key, object value)
		{
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey key)
		{
			return false;
		}

		bool IDictionary<TKey, object>.Remove(TKey key)
		{
			return false;
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey key, out object value)
		{
			value = null;
			return false;
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> item)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> item)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] array, int arrayIndex)
		{
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> item)
		{
			return false;
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
