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
		private readonly Dictionary<TKey, object> sOxrCdxvHbUrcFuzreSUSJnGrsEw;

		private readonly bool hyWbcXCWXPrFzerrnCFofoEUCVFA;

		public int Count => sOxrCdxvHbUrcFuzreSUSJnGrsEw.Count;

		public bool isReadOnlyCollection => hyWbcXCWXPrFzerrnCFofoEUCVFA;

		ICollection<TKey> IDictionary<TKey, object>.Keys => sOxrCdxvHbUrcFuzreSUSJnGrsEw.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => sOxrCdxvHbUrcFuzreSUSJnGrsEw.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return sOxrCdxvHbUrcFuzreSUSJnGrsEw[P_0];
			}
			set
			{
				qyElXyReVtSJmVQbDjiuBHceuOyp();
				sOxrCdxvHbUrcFuzreSUSJnGrsEw[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => sOxrCdxvHbUrcFuzreSUSJnGrsEw.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => hyWbcXCWXPrFzerrnCFofoEUCVFA;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			sOxrCdxvHbUrcFuzreSUSJnGrsEw = P_0;
			hyWbcXCWXPrFzerrnCFofoEUCVFA = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			hyWbcXCWXPrFzerrnCFofoEUCVFA = P_0;
			sOxrCdxvHbUrcFuzreSUSJnGrsEw = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			sOxrCdxvHbUrcFuzreSUSJnGrsEw.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!sOxrCdxvHbUrcFuzreSUSJnGrsEw.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				SgkBwleOGTktByUQFObDdVAEAkymc(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			return sOxrCdxvHbUrcFuzreSUSJnGrsEw.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return sOxrCdxvHbUrcFuzreSUSJnGrsEw.ContainsKey(key);
		}

		public void Clear()
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			sOxrCdxvHbUrcFuzreSUSJnGrsEw.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (sOxrCdxvHbUrcFuzreSUSJnGrsEw.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				SgkBwleOGTktByUQFObDdVAEAkymc(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				SgkBwleOGTktByUQFObDdVAEAkymc(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!sOxrCdxvHbUrcFuzreSUSJnGrsEw.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(ZpcAWNaqQJAyJGKYnPaugfnLHjoE(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!sOxrCdxvHbUrcFuzreSUSJnGrsEw.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(ZpcAWNaqQJAyJGKYnPaugfnLHjoE(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void qyElXyReVtSJmVQbDjiuBHceuOyp()
		{
			if (hyWbcXCWXPrFzerrnCFofoEUCVFA)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void SgkBwleOGTktByUQFObDdVAEAkymc(TKey P_0, Type P_1)
		{
			throw new Exception(ZpcAWNaqQJAyJGKYnPaugfnLHjoE(P_0, P_1));
		}

		private static string ZpcAWNaqQJAyJGKYnPaugfnLHjoE(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void HLVzYhySzQiGWxkEaeOTmJPqaiAM(TKey P_0, object P_1)
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			sOxrCdxvHbUrcFuzreSUSJnGrsEw.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HLVzYhySzQiGWxkEaeOTmJPqaiAM
			this.HLVzYhySzQiGWxkEaeOTmJPqaiAM(P_0, P_1);
		}

		private bool cqTOFgbgHByFpQkEgBXvhBxxPWJNA(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cqTOFgbgHByFpQkEgBXvhBxxPWJNA
			return this.cqTOFgbgHByFpQkEgBXvhBxxPWJNA(P_0);
		}

		private bool blIiZjHHFhpWddwWBTpLDeDZSfKD(TKey P_0)
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			return sOxrCdxvHbUrcFuzreSUSJnGrsEw.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in blIiZjHHFhpWddwWBTpLDeDZSfKD
			return this.blIiZjHHFhpWddwWBTpLDeDZSfKD(P_0);
		}

		private bool lAfjbOvlTZCLBxTtzcwAofdmiFPb(TKey P_0, out object P_1)
		{
			return sOxrCdxvHbUrcFuzreSUSJnGrsEw.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lAfjbOvlTZCLBxTtzcwAofdmiFPb
			return this.lAfjbOvlTZCLBxTtzcwAofdmiFPb(P_0, out P_1);
		}

		private void jqMfeQbVvDSjPDVEAlwPrwkLzusR(KeyValuePair<TKey, object> P_0)
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			((ICollection<KeyValuePair<TKey, object>>)sOxrCdxvHbUrcFuzreSUSJnGrsEw).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jqMfeQbVvDSjPDVEAlwPrwkLzusR
			this.jqMfeQbVvDSjPDVEAlwPrwkLzusR(P_0);
		}

		private void VZIUYvatQYwjwrLsdMmvbSHhCzCs()
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			((ICollection<KeyValuePair<TKey, object>>)sOxrCdxvHbUrcFuzreSUSJnGrsEw).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in VZIUYvatQYwjwrLsdMmvbSHhCzCs
			this.VZIUYvatQYwjwrLsdMmvbSHhCzCs();
		}

		private bool gvZhNHTsKJJztxSdDRUytjDaCRxdA(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)sOxrCdxvHbUrcFuzreSUSJnGrsEw).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gvZhNHTsKJJztxSdDRUytjDaCRxdA
			return this.gvZhNHTsKJJztxSdDRUytjDaCRxdA(P_0);
		}

		private void VwUqqRWJQqJWPctUTtHgTGBjyxiM(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)sOxrCdxvHbUrcFuzreSUSJnGrsEw).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in VwUqqRWJQqJWPctUTtHgTGBjyxiM
			this.VwUqqRWJQqJWPctUTtHgTGBjyxiM(P_0, P_1);
		}

		private bool GZrtsveobQqtlKCCGKxJeDQbuIBt(KeyValuePair<TKey, object> P_0)
		{
			qyElXyReVtSJmVQbDjiuBHceuOyp();
			return ((ICollection<KeyValuePair<TKey, object>>)sOxrCdxvHbUrcFuzreSUSJnGrsEw).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GZrtsveobQqtlKCCGKxJeDQbuIBt
			return this.GZrtsveobQqtlKCCGKxJeDQbuIBt(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> NVvUPbiMoYMzOPhxQLjcnUONxdfF()
		{
			return sOxrCdxvHbUrcFuzreSUSJnGrsEw.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in NVvUPbiMoYMzOPhxQLjcnUONxdfF
			return this.NVvUPbiMoYMzOPhxQLjcnUONxdfF();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return sOxrCdxvHbUrcFuzreSUSJnGrsEw.GetEnumerator();
		}
	}
}
