using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class KeyedGetSetValueStore<TKey> : IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>, IEnumerable
	{
		private readonly Dictionary<TKey, object> hVOGxnMsGfLhtGNSZqhbasQUPQzd;

		private readonly bool yfPMvafshRiZOhULBHskBzzGnlqK;

		public int Count => hVOGxnMsGfLhtGNSZqhbasQUPQzd.Count;

		public bool isReadOnlyCollection => yfPMvafshRiZOhULBHskBzzGnlqK;

		ICollection<TKey> IDictionary<TKey, object>.Keys => hVOGxnMsGfLhtGNSZqhbasQUPQzd.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => hVOGxnMsGfLhtGNSZqhbasQUPQzd.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return hVOGxnMsGfLhtGNSZqhbasQUPQzd[P_0];
			}
			set
			{
				rleRuqamxQlfUyRpHWRfXdcHpNy();
				hVOGxnMsGfLhtGNSZqhbasQUPQzd[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => hVOGxnMsGfLhtGNSZqhbasQUPQzd.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => yfPMvafshRiZOhULBHskBzzGnlqK;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			hVOGxnMsGfLhtGNSZqhbasQUPQzd = P_0;
			yfPMvafshRiZOhULBHskBzzGnlqK = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			yfPMvafshRiZOhULBHskBzzGnlqK = P_0;
			hVOGxnMsGfLhtGNSZqhbasQUPQzd = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			hVOGxnMsGfLhtGNSZqhbasQUPQzd.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!hVOGxnMsGfLhtGNSZqhbasQUPQzd.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				NBBgOxftbTVWQHDupHMyfbTCdBJo(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			return hVOGxnMsGfLhtGNSZqhbasQUPQzd.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return hVOGxnMsGfLhtGNSZqhbasQUPQzd.ContainsKey(key);
		}

		public void Clear()
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			hVOGxnMsGfLhtGNSZqhbasQUPQzd.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (hVOGxnMsGfLhtGNSZqhbasQUPQzd.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				NBBgOxftbTVWQHDupHMyfbTCdBJo(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				NBBgOxftbTVWQHDupHMyfbTCdBJo(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!hVOGxnMsGfLhtGNSZqhbasQUPQzd.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(CONHOXXlFVocGHqwLalNUSaLsgFx(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!hVOGxnMsGfLhtGNSZqhbasQUPQzd.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(CONHOXXlFVocGHqwLalNUSaLsgFx(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void rleRuqamxQlfUyRpHWRfXdcHpNy()
		{
			if (yfPMvafshRiZOhULBHskBzzGnlqK)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void NBBgOxftbTVWQHDupHMyfbTCdBJo(TKey P_0, Type P_1)
		{
			throw new Exception(CONHOXXlFVocGHqwLalNUSaLsgFx(P_0, P_1));
		}

		private static string CONHOXXlFVocGHqwLalNUSaLsgFx(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void MwqCCnJKMQfiBucsGpawITMmaJzU(TKey P_0, object P_1)
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			hVOGxnMsGfLhtGNSZqhbasQUPQzd.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MwqCCnJKMQfiBucsGpawITMmaJzU
			this.MwqCCnJKMQfiBucsGpawITMmaJzU(P_0, P_1);
		}

		private bool zaLTeEGwPJlofNaSlrEuxwlDriTA(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zaLTeEGwPJlofNaSlrEuxwlDriTA
			return this.zaLTeEGwPJlofNaSlrEuxwlDriTA(P_0);
		}

		private bool wnWmwLczizPPPmPQdVfAfVpHRlzm(TKey P_0)
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			return hVOGxnMsGfLhtGNSZqhbasQUPQzd.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wnWmwLczizPPPmPQdVfAfVpHRlzm
			return this.wnWmwLczizPPPmPQdVfAfVpHRlzm(P_0);
		}

		private bool eeMlfnEtSHSeKamxZAKLCMqodPgnA(TKey P_0, out object P_1)
		{
			return hVOGxnMsGfLhtGNSZqhbasQUPQzd.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eeMlfnEtSHSeKamxZAKLCMqodPgnA
			return this.eeMlfnEtSHSeKamxZAKLCMqodPgnA(P_0, out P_1);
		}

		private void wWxsGKkrMVHRYUuygIXmHhYZZgZe(KeyValuePair<TKey, object> P_0)
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			((ICollection<KeyValuePair<TKey, object>>)hVOGxnMsGfLhtGNSZqhbasQUPQzd).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wWxsGKkrMVHRYUuygIXmHhYZZgZe
			this.wWxsGKkrMVHRYUuygIXmHhYZZgZe(P_0);
		}

		private void KilYNhFezWFRhmsSDGtINIItCAjQ()
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			((ICollection<KeyValuePair<TKey, object>>)hVOGxnMsGfLhtGNSZqhbasQUPQzd).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in KilYNhFezWFRhmsSDGtINIItCAjQ
			this.KilYNhFezWFRhmsSDGtINIItCAjQ();
		}

		private bool fPoNrTgpUTDYygTatwzBNItyqnWd(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)hVOGxnMsGfLhtGNSZqhbasQUPQzd).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fPoNrTgpUTDYygTatwzBNItyqnWd
			return this.fPoNrTgpUTDYygTatwzBNItyqnWd(P_0);
		}

		private void IdzqbDbzAmcgSzhwxneFnxIzWnJG(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)hVOGxnMsGfLhtGNSZqhbasQUPQzd).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IdzqbDbzAmcgSzhwxneFnxIzWnJG
			this.IdzqbDbzAmcgSzhwxneFnxIzWnJG(P_0, P_1);
		}

		private bool XHMyGbNiMEbEaPamotJaWsTxTdcW(KeyValuePair<TKey, object> P_0)
		{
			rleRuqamxQlfUyRpHWRfXdcHpNy();
			return ((ICollection<KeyValuePair<TKey, object>>)hVOGxnMsGfLhtGNSZqhbasQUPQzd).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XHMyGbNiMEbEaPamotJaWsTxTdcW
			return this.XHMyGbNiMEbEaPamotJaWsTxTdcW(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> IIYfAxXWnIboJWOTcrpFLHFLOOSo()
		{
			return hVOGxnMsGfLhtGNSZqhbasQUPQzd.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in IIYfAxXWnIboJWOTcrpFLHFLOOSo
			return this.IIYfAxXWnIboJWOTcrpFLHFLOOSo();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return hVOGxnMsGfLhtGNSZqhbasQUPQzd.GetEnumerator();
		}
	}
}
