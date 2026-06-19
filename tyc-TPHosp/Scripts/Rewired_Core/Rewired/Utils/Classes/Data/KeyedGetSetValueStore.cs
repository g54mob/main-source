using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class KeyedGetSetValueStore<TKey> : IEnumerable, IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>
	{
		private readonly Dictionary<TKey, object> EdLPtGxmOIZgSaXhrGGPAdQsDsye;

		private readonly bool bbGVIcleECRMtBTTaRdZthZiDKH;

		public int Count => EdLPtGxmOIZgSaXhrGGPAdQsDsye.Count;

		public bool isReadOnlyCollection => bbGVIcleECRMtBTTaRdZthZiDKH;

		ICollection<TKey> IDictionary<TKey, object>.Keys => EdLPtGxmOIZgSaXhrGGPAdQsDsye.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => EdLPtGxmOIZgSaXhrGGPAdQsDsye.Values;

		object IDictionary<TKey, object>.this[TKey key]
		{
			get
			{
				return EdLPtGxmOIZgSaXhrGGPAdQsDsye[key];
			}
			set
			{
				ohyTIAlaQmeVsCoAMdthUJtHfMZ();
				EdLPtGxmOIZgSaXhrGGPAdQsDsye[key] = value;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => EdLPtGxmOIZgSaXhrGGPAdQsDsye.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => bbGVIcleECRMtBTTaRdZthZiDKH;

		public KeyedGetSetValueStore(Dictionary<TKey, object> valueDelegates, bool isReadOnlyCollection)
		{
			EdLPtGxmOIZgSaXhrGGPAdQsDsye = valueDelegates;
			bbGVIcleECRMtBTTaRdZthZiDKH = isReadOnlyCollection;
		}

		public KeyedGetSetValueStore(bool isReadOnlyCollection)
		{
			bbGVIcleECRMtBTTaRdZthZiDKH = isReadOnlyCollection;
			EdLPtGxmOIZgSaXhrGGPAdQsDsye = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			EdLPtGxmOIZgSaXhrGGPAdQsDsye.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!EdLPtGxmOIZgSaXhrGGPAdQsDsye.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				afWnIacEhJGMNdXgSCrGqidVjQY(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye.ContainsKey(key);
		}

		public void Clear()
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			EdLPtGxmOIZgSaXhrGGPAdQsDsye.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (EdLPtGxmOIZgSaXhrGGPAdQsDsye.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				afWnIacEhJGMNdXgSCrGqidVjQY(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				afWnIacEhJGMNdXgSCrGqidVjQY(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!EdLPtGxmOIZgSaXhrGGPAdQsDsye.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(TTjgoMYnpTaaIiyyoYgmgxWMdBAO(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!EdLPtGxmOIZgSaXhrGGPAdQsDsye.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(TTjgoMYnpTaaIiyyoYgmgxWMdBAO(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void ohyTIAlaQmeVsCoAMdthUJtHfMZ()
		{
			if (bbGVIcleECRMtBTTaRdZthZiDKH)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void afWnIacEhJGMNdXgSCrGqidVjQY(TKey P_0, Type P_1)
		{
			throw new Exception(TTjgoMYnpTaaIiyyoYgmgxWMdBAO(P_0, P_1));
		}

		private static string TTjgoMYnpTaaIiyyoYgmgxWMdBAO(TKey P_0, Type P_1)
		{
			return string.Concat("Value with key ", P_0, " of type ", P_1, " not found.");
		}

		void IDictionary<TKey, object>.Add(TKey key, object value)
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			EdLPtGxmOIZgSaXhrGGPAdQsDsye.Add(key, value);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey key)
		{
			return ContainsKey(key);
		}

		bool IDictionary<TKey, object>.Remove(TKey key)
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye.Remove(key);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey key, out object value)
		{
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> item)
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			((ICollection<KeyValuePair<TKey, object>>)EdLPtGxmOIZgSaXhrGGPAdQsDsye).Add(item);
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			((ICollection<KeyValuePair<TKey, object>>)EdLPtGxmOIZgSaXhrGGPAdQsDsye).Clear();
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> item)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)EdLPtGxmOIZgSaXhrGGPAdQsDsye).Contains(item);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, object>>)EdLPtGxmOIZgSaXhrGGPAdQsDsye).CopyTo(array, arrayIndex);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> item)
		{
			ohyTIAlaQmeVsCoAMdthUJtHfMZ();
			return ((ICollection<KeyValuePair<TKey, object>>)EdLPtGxmOIZgSaXhrGGPAdQsDsye).Remove(item);
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye.GetEnumerator();
		}
	}
}
