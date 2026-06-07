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
		private readonly Dictionary<TKey, object> xKVVPAxVNoBjqPqobEYcYHRnaGCx;

		private readonly bool iaKegXCgYYUzFsFmzDAvrPWxCkTBA;

		public int Count => xKVVPAxVNoBjqPqobEYcYHRnaGCx.Count;

		public bool isReadOnlyCollection => iaKegXCgYYUzFsFmzDAvrPWxCkTBA;

		ICollection<TKey> IDictionary<TKey, object>.Keys => xKVVPAxVNoBjqPqobEYcYHRnaGCx.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => xKVVPAxVNoBjqPqobEYcYHRnaGCx.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return xKVVPAxVNoBjqPqobEYcYHRnaGCx[P_0];
			}
			set
			{
				pXezURRPTsmRyBroDImSZmWLwcaT();
				xKVVPAxVNoBjqPqobEYcYHRnaGCx[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => xKVVPAxVNoBjqPqobEYcYHRnaGCx.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => iaKegXCgYYUzFsFmzDAvrPWxCkTBA;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			xKVVPAxVNoBjqPqobEYcYHRnaGCx = P_0;
			iaKegXCgYYUzFsFmzDAvrPWxCkTBA = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			iaKegXCgYYUzFsFmzDAvrPWxCkTBA = P_0;
			xKVVPAxVNoBjqPqobEYcYHRnaGCx = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			pXezURRPTsmRyBroDImSZmWLwcaT();
			xKVVPAxVNoBjqPqobEYcYHRnaGCx.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!xKVVPAxVNoBjqPqobEYcYHRnaGCx.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				XcYibUGmIWRbJGJVNglfNRkbhKuFA(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			return xKVVPAxVNoBjqPqobEYcYHRnaGCx.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return xKVVPAxVNoBjqPqobEYcYHRnaGCx.ContainsKey(key);
		}

		public void Clear()
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			xKVVPAxVNoBjqPqobEYcYHRnaGCx.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (xKVVPAxVNoBjqPqobEYcYHRnaGCx.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				XcYibUGmIWRbJGJVNglfNRkbhKuFA(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				XcYibUGmIWRbJGJVNglfNRkbhKuFA(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!xKVVPAxVNoBjqPqobEYcYHRnaGCx.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(AsKRIuoTqAGMXUYBbHkOqfBafpiK(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!xKVVPAxVNoBjqPqobEYcYHRnaGCx.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(AsKRIuoTqAGMXUYBbHkOqfBafpiK(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void pXezURRPTsmRyBroDImSZmWLwcaT()
		{
			if (iaKegXCgYYUzFsFmzDAvrPWxCkTBA)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void XcYibUGmIWRbJGJVNglfNRkbhKuFA(TKey P_0, Type P_1)
		{
			throw new Exception(AsKRIuoTqAGMXUYBbHkOqfBafpiK(P_0, P_1));
		}

		private static string AsKRIuoTqAGMXUYBbHkOqfBafpiK(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void SLvlTWkYvRLOQjlNgbIjoBfJDUQaA(TKey P_0, object P_1)
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			xKVVPAxVNoBjqPqobEYcYHRnaGCx.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SLvlTWkYvRLOQjlNgbIjoBfJDUQaA
			this.SLvlTWkYvRLOQjlNgbIjoBfJDUQaA(P_0, P_1);
		}

		private bool jTxXQHtfRKxNjEFPgcDDBLTKieJpA(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jTxXQHtfRKxNjEFPgcDDBLTKieJpA
			return this.jTxXQHtfRKxNjEFPgcDDBLTKieJpA(P_0);
		}

		private bool kxRbzmPEZsAhExjrPGNNaTKaJsKqA(TKey P_0)
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			return xKVVPAxVNoBjqPqobEYcYHRnaGCx.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kxRbzmPEZsAhExjrPGNNaTKaJsKqA
			return this.kxRbzmPEZsAhExjrPGNNaTKaJsKqA(P_0);
		}

		private bool ezJCwUfCzOpKVrsAvNcYcgZJaCBiA(TKey P_0, out object P_1)
		{
			return xKVVPAxVNoBjqPqobEYcYHRnaGCx.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ezJCwUfCzOpKVrsAvNcYcgZJaCBiA
			return this.ezJCwUfCzOpKVrsAvNcYcgZJaCBiA(P_0, out P_1);
		}

		private void gJuhldFvxYKjNBzTEMcpjDEqeGkiA(KeyValuePair<TKey, object> P_0)
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			((ICollection<KeyValuePair<TKey, object>>)xKVVPAxVNoBjqPqobEYcYHRnaGCx).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gJuhldFvxYKjNBzTEMcpjDEqeGkiA
			this.gJuhldFvxYKjNBzTEMcpjDEqeGkiA(P_0);
		}

		private void CvkqPKeJKVtrwfwnrqPFnenAZnIm()
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			((ICollection<KeyValuePair<TKey, object>>)xKVVPAxVNoBjqPqobEYcYHRnaGCx).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in CvkqPKeJKVtrwfwnrqPFnenAZnIm
			this.CvkqPKeJKVtrwfwnrqPFnenAZnIm();
		}

		private bool fSvaKkJTOQgbditseNOAldtWDzpMb(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)xKVVPAxVNoBjqPqobEYcYHRnaGCx).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fSvaKkJTOQgbditseNOAldtWDzpMb
			return this.fSvaKkJTOQgbditseNOAldtWDzpMb(P_0);
		}

		private void YycUbmYEEdXUTkKPXHBWEJvWmDyyA(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)xKVVPAxVNoBjqPqobEYcYHRnaGCx).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in YycUbmYEEdXUTkKPXHBWEJvWmDyyA
			this.YycUbmYEEdXUTkKPXHBWEJvWmDyyA(P_0, P_1);
		}

		private bool NvHRdUaIfPjqbbWBSgldischYeVKB(KeyValuePair<TKey, object> P_0)
		{
			pXezURRPTsmRyBroDImSZmWLwcaT();
			return ((ICollection<KeyValuePair<TKey, object>>)xKVVPAxVNoBjqPqobEYcYHRnaGCx).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NvHRdUaIfPjqbbWBSgldischYeVKB
			return this.NvHRdUaIfPjqbbWBSgldischYeVKB(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> CtXRWGeWKXQqIFzeIZDAjCiokBtV()
		{
			return xKVVPAxVNoBjqPqobEYcYHRnaGCx.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in CtXRWGeWKXQqIFzeIZDAjCiokBtV
			return this.CtXRWGeWKXQqIFzeIZDAjCiokBtV();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return xKVVPAxVNoBjqPqobEYcYHRnaGCx.GetEnumerator();
		}
	}
}
