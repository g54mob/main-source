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
		private readonly Dictionary<TKey, object> NcVtbHdbgpPzNzjvietqfHGVBgGy;

		private readonly bool qwQzOvfNijMVkEqDvgOyfMTDAMftA;

		public int Count => NcVtbHdbgpPzNzjvietqfHGVBgGy.Count;

		public bool isReadOnlyCollection => qwQzOvfNijMVkEqDvgOyfMTDAMftA;

		ICollection<TKey> IDictionary<TKey, object>.Keys => NcVtbHdbgpPzNzjvietqfHGVBgGy.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => NcVtbHdbgpPzNzjvietqfHGVBgGy.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return NcVtbHdbgpPzNzjvietqfHGVBgGy[P_0];
			}
			set
			{
				jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
				NcVtbHdbgpPzNzjvietqfHGVBgGy[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => NcVtbHdbgpPzNzjvietqfHGVBgGy.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => qwQzOvfNijMVkEqDvgOyfMTDAMftA;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			NcVtbHdbgpPzNzjvietqfHGVBgGy = P_0;
			qwQzOvfNijMVkEqDvgOyfMTDAMftA = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			qwQzOvfNijMVkEqDvgOyfMTDAMftA = P_0;
			NcVtbHdbgpPzNzjvietqfHGVBgGy = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			NcVtbHdbgpPzNzjvietqfHGVBgGy.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!NcVtbHdbgpPzNzjvietqfHGVBgGy.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				raEdftgNXgGJIeVaLbflXwbkmSqy(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			return NcVtbHdbgpPzNzjvietqfHGVBgGy.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return NcVtbHdbgpPzNzjvietqfHGVBgGy.ContainsKey(key);
		}

		public void Clear()
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			NcVtbHdbgpPzNzjvietqfHGVBgGy.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (NcVtbHdbgpPzNzjvietqfHGVBgGy.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				raEdftgNXgGJIeVaLbflXwbkmSqy(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				raEdftgNXgGJIeVaLbflXwbkmSqy(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!NcVtbHdbgpPzNzjvietqfHGVBgGy.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(QnxEwBItXoxILrXohTwPUgWbVTah(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!NcVtbHdbgpPzNzjvietqfHGVBgGy.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(QnxEwBItXoxILrXohTwPUgWbVTah(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void jHgdLFzMmLjYvBcEPnGErfbqaMhjA()
		{
			if (qwQzOvfNijMVkEqDvgOyfMTDAMftA)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void raEdftgNXgGJIeVaLbflXwbkmSqy(TKey P_0, Type P_1)
		{
			throw new Exception(QnxEwBItXoxILrXohTwPUgWbVTah(P_0, P_1));
		}

		private static string QnxEwBItXoxILrXohTwPUgWbVTah(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			NcVtbHdbgpPzNzjvietqfHGVBgGy.Add(P_0, P_1);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			return NcVtbHdbgpPzNzjvietqfHGVBgGy.Remove(P_0);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			return NcVtbHdbgpPzNzjvietqfHGVBgGy.TryGetValue(P_0, out P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			((ICollection<KeyValuePair<TKey, object>>)NcVtbHdbgpPzNzjvietqfHGVBgGy).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			((ICollection<KeyValuePair<TKey, object>>)NcVtbHdbgpPzNzjvietqfHGVBgGy).Clear();
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)NcVtbHdbgpPzNzjvietqfHGVBgGy).Contains(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)NcVtbHdbgpPzNzjvietqfHGVBgGy).CopyTo(P_0, P_1);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			return ((ICollection<KeyValuePair<TKey, object>>)NcVtbHdbgpPzNzjvietqfHGVBgGy).Remove(P_0);
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			return NcVtbHdbgpPzNzjvietqfHGVBgGy.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return NcVtbHdbgpPzNzjvietqfHGVBgGy.GetEnumerator();
		}
	}
}
