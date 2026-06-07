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
		private readonly Dictionary<TKey, object> KXaBxIgpBfWuGQYgoPiflGXJAvek;

		private readonly bool VndvMDZpIXoWnhJesUJcGDIJugxr;

		public int Count => KXaBxIgpBfWuGQYgoPiflGXJAvek.Count;

		public bool isReadOnlyCollection => VndvMDZpIXoWnhJesUJcGDIJugxr;

		ICollection<TKey> IDictionary<TKey, object>.Keys => KXaBxIgpBfWuGQYgoPiflGXJAvek.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => KXaBxIgpBfWuGQYgoPiflGXJAvek.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return KXaBxIgpBfWuGQYgoPiflGXJAvek[P_0];
			}
			set
			{
				EgFaoVCHVzBmWGGoUObLFaStekQbb();
				KXaBxIgpBfWuGQYgoPiflGXJAvek[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => KXaBxIgpBfWuGQYgoPiflGXJAvek.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => VndvMDZpIXoWnhJesUJcGDIJugxr;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			KXaBxIgpBfWuGQYgoPiflGXJAvek = P_0;
			VndvMDZpIXoWnhJesUJcGDIJugxr = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			VndvMDZpIXoWnhJesUJcGDIJugxr = P_0;
			KXaBxIgpBfWuGQYgoPiflGXJAvek = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			KXaBxIgpBfWuGQYgoPiflGXJAvek.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!KXaBxIgpBfWuGQYgoPiflGXJAvek.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				clnZnMJMqVIDbJgBOeVcgUeJUKCL(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			return KXaBxIgpBfWuGQYgoPiflGXJAvek.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return KXaBxIgpBfWuGQYgoPiflGXJAvek.ContainsKey(key);
		}

		public void Clear()
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			KXaBxIgpBfWuGQYgoPiflGXJAvek.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (KXaBxIgpBfWuGQYgoPiflGXJAvek.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				clnZnMJMqVIDbJgBOeVcgUeJUKCL(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				clnZnMJMqVIDbJgBOeVcgUeJUKCL(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!KXaBxIgpBfWuGQYgoPiflGXJAvek.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(dJlAnohvyBErpkLLuxWZRDLAefCNA(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!KXaBxIgpBfWuGQYgoPiflGXJAvek.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(dJlAnohvyBErpkLLuxWZRDLAefCNA(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void EgFaoVCHVzBmWGGoUObLFaStekQbb()
		{
			if (VndvMDZpIXoWnhJesUJcGDIJugxr)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void clnZnMJMqVIDbJgBOeVcgUeJUKCL(TKey P_0, Type P_1)
		{
			throw new Exception(dJlAnohvyBErpkLLuxWZRDLAefCNA(P_0, P_1));
		}

		private static string dJlAnohvyBErpkLLuxWZRDLAefCNA(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void zwYrYAnpVQfiSgDGpNylHdffCuLb(TKey P_0, object P_1)
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			KXaBxIgpBfWuGQYgoPiflGXJAvek.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zwYrYAnpVQfiSgDGpNylHdffCuLb
			this.zwYrYAnpVQfiSgDGpNylHdffCuLb(P_0, P_1);
		}

		private bool SfOkrJebZREeZHmBbnEEojNgbsbDA(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SfOkrJebZREeZHmBbnEEojNgbsbDA
			return this.SfOkrJebZREeZHmBbnEEojNgbsbDA(P_0);
		}

		private bool JLuvXcKzVzcGuiPxMROEaEOAXigU(TKey P_0)
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			return KXaBxIgpBfWuGQYgoPiflGXJAvek.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JLuvXcKzVzcGuiPxMROEaEOAXigU
			return this.JLuvXcKzVzcGuiPxMROEaEOAXigU(P_0);
		}

		private bool ZokxYWcZvHtrteeUynHBBeZrAcrI(TKey P_0, out object P_1)
		{
			return KXaBxIgpBfWuGQYgoPiflGXJAvek.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZokxYWcZvHtrteeUynHBBeZrAcrI
			return this.ZokxYWcZvHtrteeUynHBBeZrAcrI(P_0, out P_1);
		}

		private void FwNXShGgxZKYlQkTFrbkUqYQEmWI(KeyValuePair<TKey, object> P_0)
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			((ICollection<KeyValuePair<TKey, object>>)KXaBxIgpBfWuGQYgoPiflGXJAvek).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FwNXShGgxZKYlQkTFrbkUqYQEmWI
			this.FwNXShGgxZKYlQkTFrbkUqYQEmWI(P_0);
		}

		private void rFJvYJfAoWQCEoxQmtUsShUmLkqb()
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			((ICollection<KeyValuePair<TKey, object>>)KXaBxIgpBfWuGQYgoPiflGXJAvek).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in rFJvYJfAoWQCEoxQmtUsShUmLkqb
			this.rFJvYJfAoWQCEoxQmtUsShUmLkqb();
		}

		private bool UCSqteIMMVWBFgwaQFdDQQtjjaDk(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)KXaBxIgpBfWuGQYgoPiflGXJAvek).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UCSqteIMMVWBFgwaQFdDQQtjjaDk
			return this.UCSqteIMMVWBFgwaQFdDQQtjjaDk(P_0);
		}

		private void dLPCJkZzCmoxlxGPCrMBepzoeBYCA(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)KXaBxIgpBfWuGQYgoPiflGXJAvek).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dLPCJkZzCmoxlxGPCrMBepzoeBYCA
			this.dLPCJkZzCmoxlxGPCrMBepzoeBYCA(P_0, P_1);
		}

		private bool ufgZONnrIWNfHPDrLoVyDenckvwc(KeyValuePair<TKey, object> P_0)
		{
			EgFaoVCHVzBmWGGoUObLFaStekQbb();
			return ((ICollection<KeyValuePair<TKey, object>>)KXaBxIgpBfWuGQYgoPiflGXJAvek).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ufgZONnrIWNfHPDrLoVyDenckvwc
			return this.ufgZONnrIWNfHPDrLoVyDenckvwc(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> vKscrMEpUGnbkDAskLOJhCyGSXHxc()
		{
			return KXaBxIgpBfWuGQYgoPiflGXJAvek.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in vKscrMEpUGnbkDAskLOJhCyGSXHxc
			return this.vKscrMEpUGnbkDAskLOJhCyGSXHxc();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return KXaBxIgpBfWuGQYgoPiflGXJAvek.GetEnumerator();
		}
	}
}
