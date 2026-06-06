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
		private readonly Dictionary<TKey, object> jTIUlikGAlJZNhflGHbYtNixgUddA;

		private readonly bool oeFypdLeHZRJeYtnIizDOEvpgvkL;

		public int Count => jTIUlikGAlJZNhflGHbYtNixgUddA.Count;

		public bool isReadOnlyCollection => oeFypdLeHZRJeYtnIizDOEvpgvkL;

		ICollection<TKey> IDictionary<TKey, object>.Keys => jTIUlikGAlJZNhflGHbYtNixgUddA.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => jTIUlikGAlJZNhflGHbYtNixgUddA.Values;

		object IDictionary<TKey, object>.this[TKey P_0]
		{
			get
			{
				return jTIUlikGAlJZNhflGHbYtNixgUddA[P_0];
			}
			set
			{
				tgldPbWqMvGxFjspuHBayHvFrqTx();
				jTIUlikGAlJZNhflGHbYtNixgUddA[key] = value2;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => jTIUlikGAlJZNhflGHbYtNixgUddA.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => oeFypdLeHZRJeYtnIizDOEvpgvkL;

		public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
		{
			jTIUlikGAlJZNhflGHbYtNixgUddA = P_0;
			oeFypdLeHZRJeYtnIizDOEvpgvkL = P_1;
		}

		public KeyedGetSetValueStore(bool P_0)
		{
			oeFypdLeHZRJeYtnIizDOEvpgvkL = P_0;
			jTIUlikGAlJZNhflGHbYtNixgUddA = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			jTIUlikGAlJZNhflGHbYtNixgUddA.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!jTIUlikGAlJZNhflGHbYtNixgUddA.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				XYFgLcLjDZNhgoESkMOXeeNtdYRK(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			return jTIUlikGAlJZNhflGHbYtNixgUddA.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return jTIUlikGAlJZNhflGHbYtNixgUddA.ContainsKey(key);
		}

		public void Clear()
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			jTIUlikGAlJZNhflGHbYtNixgUddA.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (jTIUlikGAlJZNhflGHbYtNixgUddA.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				XYFgLcLjDZNhgoESkMOXeeNtdYRK(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				XYFgLcLjDZNhgoESkMOXeeNtdYRK(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!jTIUlikGAlJZNhflGHbYtNixgUddA.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(UUDfMEJjxZYcaEqOGLiaKBweLhTkA(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!jTIUlikGAlJZNhflGHbYtNixgUddA.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(UUDfMEJjxZYcaEqOGLiaKBweLhTkA(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void tgldPbWqMvGxFjspuHBayHvFrqTx()
		{
			if (oeFypdLeHZRJeYtnIizDOEvpgvkL)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void XYFgLcLjDZNhgoESkMOXeeNtdYRK(TKey P_0, Type P_1)
		{
			throw new Exception(UUDfMEJjxZYcaEqOGLiaKBweLhTkA(P_0, P_1));
		}

		private static string UUDfMEJjxZYcaEqOGLiaKBweLhTkA(TKey P_0, Type P_1)
		{
			string[] obj = new string[5] { "Value with key ", null, null, null, null };
			TKey val = P_0;
			obj[1] = val?.ToString();
			obj[2] = " of type ";
			obj[3] = P_1?.ToString();
			obj[4] = " not found.";
			return string.Concat(obj);
		}

		private void KiJWcaxsCUmljLSLVjPYDENPYvnB(TKey P_0, object P_1)
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			jTIUlikGAlJZNhflGHbYtNixgUddA.Add(P_0, P_1);
		}

		void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KiJWcaxsCUmljLSLVjPYDENPYvnB
			this.KiJWcaxsCUmljLSLVjPYDENPYvnB(P_0, P_1);
		}

		private bool rswTvrqZCNdKMaNONoxxiBaQogmk(TKey P_0)
		{
			return ContainsKey(P_0);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rswTvrqZCNdKMaNONoxxiBaQogmk
			return this.rswTvrqZCNdKMaNONoxxiBaQogmk(P_0);
		}

		private bool wKOxkGOYGhSRlPimaHopKuvwPktaA(TKey P_0)
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			return jTIUlikGAlJZNhflGHbYtNixgUddA.Remove(P_0);
		}

		bool IDictionary<TKey, object>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wKOxkGOYGhSRlPimaHopKuvwPktaA
			return this.wKOxkGOYGhSRlPimaHopKuvwPktaA(P_0);
		}

		private bool eCAzzqctqVUawFwBMsFyFmeRIUwM(TKey P_0, out object P_1)
		{
			return jTIUlikGAlJZNhflGHbYtNixgUddA.TryGetValue(P_0, out P_1);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eCAzzqctqVUawFwBMsFyFmeRIUwM
			return this.eCAzzqctqVUawFwBMsFyFmeRIUwM(P_0, out P_1);
		}

		private void ksnsPLGqOTVTyfCmtJcLMvFmOvFD(KeyValuePair<TKey, object> P_0)
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			((ICollection<KeyValuePair<TKey, object>>)jTIUlikGAlJZNhflGHbYtNixgUddA).Add(P_0);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ksnsPLGqOTVTyfCmtJcLMvFmOvFD
			this.ksnsPLGqOTVTyfCmtJcLMvFmOvFD(P_0);
		}

		private void GCzCaqpXQWJtNPoTKXBpICUUHevd()
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			((ICollection<KeyValuePair<TKey, object>>)jTIUlikGAlJZNhflGHbYtNixgUddA).Clear();
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GCzCaqpXQWJtNPoTKXBpICUUHevd
			this.GCzCaqpXQWJtNPoTKXBpICUUHevd();
		}

		private bool dNcZlMQlLZDiYLlvyhXaWeKDpyOG(KeyValuePair<TKey, object> P_0)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)jTIUlikGAlJZNhflGHbYtNixgUddA).Contains(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dNcZlMQlLZDiYLlvyhXaWeKDpyOG
			return this.dNcZlMQlLZDiYLlvyhXaWeKDpyOG(P_0);
		}

		private void QHbcRADgToFkaWGOcgawHqEKWRLDA(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			((ICollection<KeyValuePair<TKey, object>>)jTIUlikGAlJZNhflGHbYtNixgUddA).CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QHbcRADgToFkaWGOcgawHqEKWRLDA
			this.QHbcRADgToFkaWGOcgawHqEKWRLDA(P_0, P_1);
		}

		private bool XcAchkhkkOQXAsSwhMlDVLAKyRqD(KeyValuePair<TKey, object> P_0)
		{
			tgldPbWqMvGxFjspuHBayHvFrqTx();
			return ((ICollection<KeyValuePair<TKey, object>>)jTIUlikGAlJZNhflGHbYtNixgUddA).Remove(P_0);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XcAchkhkkOQXAsSwhMlDVLAKyRqD
			return this.XcAchkhkkOQXAsSwhMlDVLAKyRqD(P_0);
		}

		private IEnumerator<KeyValuePair<TKey, object>> KHUfCqBbLYKmxVjppAyoIOXmmNAmA()
		{
			return jTIUlikGAlJZNhflGHbYtNixgUddA.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in KHUfCqBbLYKmxVjppAyoIOXmmNAmA
			return this.KHUfCqBbLYKmxVjppAyoIOXmmNAmA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return jTIUlikGAlJZNhflGHbYtNixgUddA.GetEnumerator();
		}
	}
}
