using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class KeyedGetSetValueStore<TKey> : IEnumerable, IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>
	{
		private readonly Dictionary<TKey, object> wfNwuYXbSnYYfKrLRFIImChAmjMJ;

		private readonly bool JZCNMgBNUdcIIlpxKwTKZfeQCBvi;

		public int Count => wfNwuYXbSnYYfKrLRFIImChAmjMJ.Count;

		public bool isReadOnlyCollection => JZCNMgBNUdcIIlpxKwTKZfeQCBvi;

		ICollection<TKey> IDictionary<TKey, object>.Keys => wfNwuYXbSnYYfKrLRFIImChAmjMJ.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => wfNwuYXbSnYYfKrLRFIImChAmjMJ.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return wfNwuYXbSnYYfKrLRFIImChAmjMJ[P_0];
			}
			set
			{
				QewHIOCTWValNSqewneyYoOrjOvAb();
				wfNwuYXbSnYYfKrLRFIImChAmjMJ[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => wfNwuYXbSnYYfKrLRFIImChAmjMJ.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => JZCNMgBNUdcIIlpxKwTKZfeQCBvi;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			wfNwuYXbSnYYfKrLRFIImChAmjMJ = P_0;
			JZCNMgBNUdcIIlpxKwTKZfeQCBvi = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			JZCNMgBNUdcIIlpxKwTKZfeQCBvi = P_0;
			wfNwuYXbSnYYfKrLRFIImChAmjMJ = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			QewHIOCTWValNSqewneyYoOrjOvAb();
			wfNwuYXbSnYYfKrLRFIImChAmjMJ.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!wfNwuYXbSnYYfKrLRFIImChAmjMJ.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				KxAFowcSfiMmutTCoqJFmOSrXWidA(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			QewHIOCTWValNSqewneyYoOrjOvAb();
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ.ContainsKey(key);
		}

		public void Clear()
		{
			QewHIOCTWValNSqewneyYoOrjOvAb();
			wfNwuYXbSnYYfKrLRFIImChAmjMJ.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (wfNwuYXbSnYYfKrLRFIImChAmjMJ.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				KxAFowcSfiMmutTCoqJFmOSrXWidA(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				KxAFowcSfiMmutTCoqJFmOSrXWidA(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!wfNwuYXbSnYYfKrLRFIImChAmjMJ.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(vDnpOMwrhaIriCMBUrcrXfncVTgE(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!wfNwuYXbSnYYfKrLRFIImChAmjMJ.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(vDnpOMwrhaIriCMBUrcrXfncVTgE(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void QewHIOCTWValNSqewneyYoOrjOvAb()
		{
			if (JZCNMgBNUdcIIlpxKwTKZfeQCBvi)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void KxAFowcSfiMmutTCoqJFmOSrXWidA(TKey P_0, Type P_1)
		{
			throw new Exception(vDnpOMwrhaIriCMBUrcrXfncVTgE(P_0, P_1));
		}

		private static string vDnpOMwrhaIriCMBUrcrXfncVTgE(TKey P_0, Type P_1)
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
			QewHIOCTWValNSqewneyYoOrjOvAb();
			wfNwuYXbSnYYfKrLRFIImChAmjMJ.Add(P_0, P_1);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			QewHIOCTWValNSqewneyYoOrjOvAb();
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ.Remove(P_0);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ.TryGetValue(P_0, out P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			QewHIOCTWValNSqewneyYoOrjOvAb();
			((ICollection<KeyValuePair<TKey, object>>)wfNwuYXbSnYYfKrLRFIImChAmjMJ).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			QewHIOCTWValNSqewneyYoOrjOvAb();
			((ICollection<KeyValuePair<TKey, object>>)wfNwuYXbSnYYfKrLRFIImChAmjMJ).Clear();
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)wfNwuYXbSnYYfKrLRFIImChAmjMJ).Contains(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)wfNwuYXbSnYYfKrLRFIImChAmjMJ).CopyTo(P_0, P_1);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			QewHIOCTWValNSqewneyYoOrjOvAb();
			return ((ICollection<KeyValuePair<TKey, object>>)wfNwuYXbSnYYfKrLRFIImChAmjMJ).Remove(P_0);
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ.GetEnumerator();
		}
	}
}
