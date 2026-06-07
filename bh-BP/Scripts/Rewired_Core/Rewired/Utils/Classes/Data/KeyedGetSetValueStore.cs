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

		public int Count => 0;

		public bool isReadOnlyCollection => false;

		ICollection<TKey> IDictionary<TKey, object>.Keys => null;

		ICollection<object> IDictionary<TKey, object>.Values => null;

		object IDictionary<TKey, object>.this[TKey P_0]
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

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
		}

		public KeyedGetSetValueStore(bool P_0)
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

		private void rleRuqamxQlfUyRpHWRfXdcHpNy()
		{
		}

		private static void NBBgOxftbTVWQHDupHMyfbTCdBJo(TKey P_0, Type P_1)
		{
		}

		private static string CONHOXXlFVocGHqwLalNUSaLsgFx(TKey P_0, Type P_1)
		{
			return null;
		}

		private void MwqCCnJKMQfiBucsGpawITMmaJzU(TKey P_0, object P_1)
		{
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MwqCCnJKMQfiBucsGpawITMmaJzU
			this.MwqCCnJKMQfiBucsGpawITMmaJzU(P_0, P_1);
		}

		private bool zaLTeEGwPJlofNaSlrEuxwlDriTA(TKey P_0)
		{
			return false;
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zaLTeEGwPJlofNaSlrEuxwlDriTA
			return this.zaLTeEGwPJlofNaSlrEuxwlDriTA(P_0);
		}

		private bool wnWmwLczizPPPmPQdVfAfVpHRlzm(TKey P_0)
		{
			return false;
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wnWmwLczizPPPmPQdVfAfVpHRlzm
			return this.wnWmwLczizPPPmPQdVfAfVpHRlzm(P_0);
		}

		private bool eeMlfnEtSHSeKamxZAKLCMqodPgnA(TKey P_0, out object P_1)
		{
			P_1 = null;
			return false;
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eeMlfnEtSHSeKamxZAKLCMqodPgnA
			return this.eeMlfnEtSHSeKamxZAKLCMqodPgnA(P_0, out P_1);
		}

		private void wWxsGKkrMVHRYUuygIXmHhYZZgZe(KeyValuePair<TKey, object> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wWxsGKkrMVHRYUuygIXmHhYZZgZe
			this.wWxsGKkrMVHRYUuygIXmHhYZZgZe(P_0);
		}

		private void KilYNhFezWFRhmsSDGtINIItCAjQ()
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in KilYNhFezWFRhmsSDGtINIItCAjQ
			this.KilYNhFezWFRhmsSDGtINIItCAjQ();
		}

		private bool fPoNrTgpUTDYygTatwzBNItyqnWd(KeyValuePair<TKey, object> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fPoNrTgpUTDYygTatwzBNItyqnWd
			return this.fPoNrTgpUTDYygTatwzBNItyqnWd(P_0);
		}

		private void IdzqbDbzAmcgSzhwxneFnxIzWnJG(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IdzqbDbzAmcgSzhwxneFnxIzWnJG
			this.IdzqbDbzAmcgSzhwxneFnxIzWnJG(P_0, P_1);
		}

		private bool XHMyGbNiMEbEaPamotJaWsTxTdcW(KeyValuePair<TKey, object> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XHMyGbNiMEbEaPamotJaWsTxTdcW
			return this.XHMyGbNiMEbEaPamotJaWsTxTdcW(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> IIYfAxXWnIboJWOTcrpFLHFLOOSo()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in IIYfAxXWnIboJWOTcrpFLHFLOOSo
			return this.IIYfAxXWnIboJWOTcrpFLHFLOOSo();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
