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
		private readonly Dictionary<TKey, object> sAjcIEOIkkSMIPaQwEOhADCXEsKcA;

		private readonly bool hNqkVBvUhWiAxgKQwRYiheZBnYTU;

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

		private void aqYvkNgwucsCQXOXOsHXFfTbYkoj()
		{
		}

		private static void CyuExEvDzEEuhUixOipoBEnZoawo(TKey P_0, Type P_1)
		{
		}

		private static string VieRogTJFSofjQTjoALPoNGEoHsx(TKey P_0, Type P_1)
		{
			return null;
		}

		private void PNBqdCNrOZrNqjvjfQFguskbmlUg(TKey P_0, object P_1)
		{
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PNBqdCNrOZrNqjvjfQFguskbmlUg
			this.PNBqdCNrOZrNqjvjfQFguskbmlUg(P_0, P_1);
		}

		private bool ySPtsZYAeYgUTCgjrHiIBmCaGNNl(TKey P_0)
		{
			return false;
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ySPtsZYAeYgUTCgjrHiIBmCaGNNl
			return this.ySPtsZYAeYgUTCgjrHiIBmCaGNNl(P_0);
		}

		private bool xpzJWoavisPQsbOVASZABoBSsKWm(TKey P_0)
		{
			return false;
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xpzJWoavisPQsbOVASZABoBSsKWm
			return this.xpzJWoavisPQsbOVASZABoBSsKWm(P_0);
		}

		private bool lOpIFYUVSMSdplPmcBuLbgCzhoRnA(TKey P_0, out object P_1)
		{
			P_1 = null;
			return false;
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lOpIFYUVSMSdplPmcBuLbgCzhoRnA
			return this.lOpIFYUVSMSdplPmcBuLbgCzhoRnA(P_0, out P_1);
		}

		private void jcQORzgFKQFEnDMpFykihuJGawqL(KeyValuePair<TKey, object> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jcQORzgFKQFEnDMpFykihuJGawqL
			this.jcQORzgFKQFEnDMpFykihuJGawqL(P_0);
		}

		private void FRMiBSDfzVFOIbrXikJIzbceDbSQ()
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in FRMiBSDfzVFOIbrXikJIzbceDbSQ
			this.FRMiBSDfzVFOIbrXikJIzbceDbSQ();
		}

		private bool gXkpyaohCGQVpnEYoYNjsahOTrx(KeyValuePair<TKey, object> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gXkpyaohCGQVpnEYoYNjsahOTrx
			return this.gXkpyaohCGQVpnEYoYNjsahOTrx(P_0);
		}

		private void RnUWZolrKpbgjmghQJNJREsaAvsS(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RnUWZolrKpbgjmghQJNJREsaAvsS
			this.RnUWZolrKpbgjmghQJNJREsaAvsS(P_0, P_1);
		}

		private bool QrpIUGRTOVDuVStvJxXiqlygKAZC(KeyValuePair<TKey, object> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QrpIUGRTOVDuVStvJxXiqlygKAZC
			return this.QrpIUGRTOVDuVStvJxXiqlygKAZC(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> FTpRaWRUnHbryJqGTSVFlazUNpno()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in FTpRaWRUnHbryJqGTSVFlazUNpno
			return this.FTpRaWRUnHbryJqGTSVFlazUNpno();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
