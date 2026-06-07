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
		private readonly Dictionary<TKey, object> bOMhCCoZQObOvDMfDRvxmivsGcsbA;

		private readonly bool eTBnsNXbBaANKwdhHvsoVoqwKVff;

		public int Count => bOMhCCoZQObOvDMfDRvxmivsGcsbA.Count;

		public bool isReadOnlyCollection => eTBnsNXbBaANKwdhHvsoVoqwKVff;

		ICollection<TKey> IDictionary<TKey, object>.Keys => bOMhCCoZQObOvDMfDRvxmivsGcsbA.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => bOMhCCoZQObOvDMfDRvxmivsGcsbA.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return bOMhCCoZQObOvDMfDRvxmivsGcsbA[P_0];
			}
			set
			{
				tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
				bOMhCCoZQObOvDMfDRvxmivsGcsbA[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => bOMhCCoZQObOvDMfDRvxmivsGcsbA.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => eTBnsNXbBaANKwdhHvsoVoqwKVff;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			bOMhCCoZQObOvDMfDRvxmivsGcsbA = P_0;
			eTBnsNXbBaANKwdhHvsoVoqwKVff = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			eTBnsNXbBaANKwdhHvsoVoqwKVff = P_0;
			bOMhCCoZQObOvDMfDRvxmivsGcsbA = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			bOMhCCoZQObOvDMfDRvxmivsGcsbA.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!bOMhCCoZQObOvDMfDRvxmivsGcsbA.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				LIFZaOJJPqEWEMQYvMIalNAsCqCo(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			return bOMhCCoZQObOvDMfDRvxmivsGcsbA.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return bOMhCCoZQObOvDMfDRvxmivsGcsbA.ContainsKey(key);
		}

		public void Clear()
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			bOMhCCoZQObOvDMfDRvxmivsGcsbA.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (bOMhCCoZQObOvDMfDRvxmivsGcsbA.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				LIFZaOJJPqEWEMQYvMIalNAsCqCo(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				LIFZaOJJPqEWEMQYvMIalNAsCqCo(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!bOMhCCoZQObOvDMfDRvxmivsGcsbA.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(EVTGwVzvKyhUgWYGPsHBYlYjVfIC(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!bOMhCCoZQObOvDMfDRvxmivsGcsbA.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(EVTGwVzvKyhUgWYGPsHBYlYjVfIC(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void tbxlVDCnUIzmnLtxfKHTbIoAKYSv()
		{
			if (eTBnsNXbBaANKwdhHvsoVoqwKVff)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void LIFZaOJJPqEWEMQYvMIalNAsCqCo(TKey P_0, Type P_1)
		{
			throw new Exception(EVTGwVzvKyhUgWYGPsHBYlYjVfIC(P_0, P_1));
		}

		private static string EVTGwVzvKyhUgWYGPsHBYlYjVfIC(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void IIeBEWHtudJnBifMKNfgaAPcEcaoc(TKey P_0, object P_1)
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			bOMhCCoZQObOvDMfDRvxmivsGcsbA.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IIeBEWHtudJnBifMKNfgaAPcEcaoc
			this.IIeBEWHtudJnBifMKNfgaAPcEcaoc(P_0, P_1);
		}

		private bool bnokXHkpOakcwSROMqoYfXlZSKdY(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bnokXHkpOakcwSROMqoYfXlZSKdY
			return this.bnokXHkpOakcwSROMqoYfXlZSKdY(P_0);
		}

		private bool uaCkGmErWCGsLzecpyXKxcvrIfuF(TKey P_0)
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			return bOMhCCoZQObOvDMfDRvxmivsGcsbA.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uaCkGmErWCGsLzecpyXKxcvrIfuF
			return this.uaCkGmErWCGsLzecpyXKxcvrIfuF(P_0);
		}

		private bool qSEhmEuIgkznKfVJTLcPMdnGEclN(TKey P_0, out object P_1)
		{
			return bOMhCCoZQObOvDMfDRvxmivsGcsbA.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qSEhmEuIgkznKfVJTLcPMdnGEclN
			return this.qSEhmEuIgkznKfVJTLcPMdnGEclN(P_0, out P_1);
		}

		private void yPnVelMlqeyUGHqOihRqZzgffgUN(KeyValuePair<TKey, object> P_0)
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			((ICollection<KeyValuePair<TKey, object>>)bOMhCCoZQObOvDMfDRvxmivsGcsbA).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yPnVelMlqeyUGHqOihRqZzgffgUN
			this.yPnVelMlqeyUGHqOihRqZzgffgUN(P_0);
		}

		private void QbfjGAcvXrgUfUvwTOXIBPLDXxkTB()
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			((ICollection<KeyValuePair<TKey, object>>)bOMhCCoZQObOvDMfDRvxmivsGcsbA).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in QbfjGAcvXrgUfUvwTOXIBPLDXxkTB
			this.QbfjGAcvXrgUfUvwTOXIBPLDXxkTB();
		}

		private bool pVmMNiCQXqJIypMzhQtNXnNGLDRw(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)bOMhCCoZQObOvDMfDRvxmivsGcsbA).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pVmMNiCQXqJIypMzhQtNXnNGLDRw
			return this.pVmMNiCQXqJIypMzhQtNXnNGLDRw(P_0);
		}

		private void MBpgoqBWDHmvMcdApmqFziFBNlCV(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)bOMhCCoZQObOvDMfDRvxmivsGcsbA).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MBpgoqBWDHmvMcdApmqFziFBNlCV
			this.MBpgoqBWDHmvMcdApmqFziFBNlCV(P_0, P_1);
		}

		private bool FBQHgCgrylSJogMKasYykEKFQQtjA(KeyValuePair<TKey, object> P_0)
		{
			tbxlVDCnUIzmnLtxfKHTbIoAKYSv();
			return ((ICollection<KeyValuePair<TKey, object>>)bOMhCCoZQObOvDMfDRvxmivsGcsbA).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FBQHgCgrylSJogMKasYykEKFQQtjA
			return this.FBQHgCgrylSJogMKasYykEKFQQtjA(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> MwKAHAhHWfbTTXnaecXXBAEpfhZg()
		{
			return bOMhCCoZQObOvDMfDRvxmivsGcsbA.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MwKAHAhHWfbTTXnaecXXBAEpfhZg
			return this.MwKAHAhHWfbTTXnaecXXBAEpfhZg();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return bOMhCCoZQObOvDMfDRvxmivsGcsbA.GetEnumerator();
		}
	}
}
