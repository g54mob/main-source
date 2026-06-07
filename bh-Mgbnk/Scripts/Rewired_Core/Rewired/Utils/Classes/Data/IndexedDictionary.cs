using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct TjphZZjkCIatRwksGEUOCKvcpXvwA
		{
			public TKey MjPbVOcduvkmquKXZoFWYoxJhuyQA;

			public TValue KfyTjuouPfrlsRiHPqVbUIZGZMlQ;

			public TjphZZjkCIatRwksGEUOCKvcpXvwA(TKey P_0, TValue P_1)
			{
				MjPbVOcduvkmquKXZoFWYoxJhuyQA = default(TKey);
				KfyTjuouPfrlsRiHPqVbUIZGZMlQ = default(TValue);
			}

			public KeyValuePair<TKey, TValue> igsvQPHbyLYhMxVEKbMrskFqCmeX()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> qDLbixZQoUajrpmOsaHGCqBVsLAD;

			private int UkOOQgKhTXVinxVEJdVKUPegHNsR;

			private int SbffZfCMpbnKRKTMZfSZGgRUnwJs;

			private KeyValuePair<TKey, TValue> UsRyEwKihmLTBhsKqhOdgKIewQZD;

			private int IITwhoXKHFbQAhVONFqMQnmAJTBWA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				qDLbixZQoUajrpmOsaHGCqBVsLAD = null;
				UkOOQgKhTXVinxVEJdVKUPegHNsR = 0;
				SbffZfCMpbnKRKTMZfSZGgRUnwJs = 0;
				UsRyEwKihmLTBhsKqhOdgKIewQZD = default(KeyValuePair<TKey, TValue>);
				IITwhoXKHFbQAhVONFqMQnmAJTBWA = 0;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private IndexedDictionary<TKey, TValue> vmxRWxUmreLBobHOInuIhxbIehHm;

				private int eiqfHWevdxraPQqEogCZUZzUEVOaA;

				private int FchdLoJRYOeBXbRchgIUXIGTmLXzB;

				private TKey mOwMuHauKeLzOpSNayfiNtJcAkmb;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					vmxRWxUmreLBobHOInuIhxbIehHm = null;
					eiqfHWevdxraPQqEogCZUZzUEVOaA = 0;
					FchdLoJRYOeBXbRchgIUXIGTmLXzB = 0;
					mOwMuHauKeLzOpSNayfiNtJcAkmb = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					return false;
				}

				void IEnumerator.Reset()
				{
				}
			}

			private IndexedDictionary<TKey, TValue> GBmtcykjMQHuecUnPwsbJEELmzYT;

			public int Count => 0;

			bool ICollection<TKey>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
			}

			public Enumerator GetEnumerator()
			{
				return default(Enumerator);
			}

			public void CopyTo(TKey[] array, int index)
			{
			}

			private void cUGOvJyFvoXWwJxAXNhyvgLqEeSL(TKey P_0)
			{
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in cUGOvJyFvoXWwJxAXNhyvgLqEeSL
				this.cUGOvJyFvoXWwJxAXNhyvgLqEeSL(P_0);
			}

			private void IAfmkBgTdWoyMkULYGzIBzCyaQUf()
			{
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in IAfmkBgTdWoyMkULYGzIBzCyaQUf
				this.IAfmkBgTdWoyMkULYGzIBzCyaQUf();
			}

			private bool uyCTdSTLxKQcjcILxKDEAhUfzDCu(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in uyCTdSTLxKQcjcILxKDEAhUfzDCu
				return this.uyCTdSTLxKQcjcILxKDEAhUfzDCu(P_0);
			}

			private bool lPTyzErDDFKOtkCYipZUcVPWzhNC(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in lPTyzErDDFKOtkCYipZUcVPWzhNC
				return this.lPTyzErDDFKOtkCYipZUcVPWzhNC(P_0);
			}

			private IEnumerator<TKey> DYkuKsJOEyejwZdwQjuWhtwDoiyk()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DYkuKsJOEyejwZdwQjuWhtwDoiyk
				return this.DYkuKsJOEyejwZdwQjuWhtwDoiyk();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private IndexedDictionary<TKey, TValue> yURbDXcIFTglWgLIkkjlyEyUywZoA;

				private int dmMogueMrchBrQImiHNKXhkbNoiF;

				private int MkggAYhwHIodoBhKhlFuftqeYmnJ;

				private TValue bTWyLsLwGdoEUxraKTidZTgKySDK;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					yURbDXcIFTglWgLIkkjlyEyUywZoA = null;
					dmMogueMrchBrQImiHNKXhkbNoiF = 0;
					MkggAYhwHIodoBhKhlFuftqeYmnJ = 0;
					bTWyLsLwGdoEUxraKTidZTgKySDK = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					return false;
				}

				void IEnumerator.Reset()
				{
				}
			}

			private IndexedDictionary<TKey, TValue> nyQPKWaKdzSUmqXbzIWZbqMdWJiF;

			public int Count => 0;

			bool ICollection<TValue>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
			}

			public Enumerator GetEnumerator()
			{
				return default(Enumerator);
			}

			public void CopyTo(TValue[] array, int index)
			{
			}

			private void DEhEAvtaAqcilgeSRpPOYZEzfpfvA(TValue P_0)
			{
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in DEhEAvtaAqcilgeSRpPOYZEzfpfvA
				this.DEhEAvtaAqcilgeSRpPOYZEzfpfvA(P_0);
			}

			private bool SgjIIDJCzhglIDYsQrrjEoVPnOStA(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SgjIIDJCzhglIDYsQrrjEoVPnOStA
				return this.SgjIIDJCzhglIDYsQrrjEoVPnOStA(P_0);
			}

			private void OHzjezKBkXInztcECMfTQVpUnAuF()
			{
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in OHzjezKBkXInztcECMfTQVpUnAuF
				this.OHzjezKBkXInztcECMfTQVpUnAuF();
			}

			private bool xAMkMyMhAOHPyvxJfpCQpXHvOrlg(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in xAMkMyMhAOHPyvxJfpCQpXHvOrlg
				return this.xAMkMyMhAOHPyvxJfpCQpXHvOrlg(P_0);
			}

			private IEnumerator<TValue> fKnyuPoCuZKqAnZjKuavVMywLbEb()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in fKnyuPoCuZKqAnZjKuavVMywLbEb
				return this.fKnyuPoCuZKqAnZjKuavVMywLbEb();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private static readonly bool APAUgjOihDwVuNhbdtEtrhRnFRcD;

		private static readonly bool yxMXYuZMOcWvVOjWSBdqecXvzjsx;

		private IEqualityComparer<TKey> jCpZsdwzMHCQtthMDJxwRhIAbROd;

		private IEqualityComparer<TValue> VHqbJbiWDaFMvLJqeZMScPQDZLNuA;

		private readonly AList<TjphZZjkCIatRwksGEUOCKvcpXvwA> PNrzXRLKBlfpwlwoucUZVHmbphVA;

		private readonly ADictionary<TKey, int> vHAesMCizyjHQSWVeIOQxGhnMIrx;

		private bool NbzBSunvEVlTOAfDjqMGuqPJXraV;

		public int Count => 0;

		public bool ContainsDuplicateKeys => false;

		public bool AllowDuplicateKeys
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TValue this[int index]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		TValue IDictionary<TKey, TValue>.this[TKey P_0]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => null;

		ICollection IDictionary.Values => null;

		object IDictionary.this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int P_0] => default(TValue);

		int IReadOnlyList.Count => 0;

		object IReadOnlyList.this[int P_0] => null;

		public IndexedDictionary()
		{
		}

		public IndexedDictionary(int P_0)
		{
		}

		public IndexedDictionary(bool P_0)
		{
		}

		public IndexedDictionary(int P_0, bool P_1)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> P_0)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> P_0, bool P_1)
		{
		}

		public TValue GetValue(TKey key)
		{
			return default(TValue);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public TKey GetKeyAt(int index)
		{
			return default(TKey);
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void SetValue(TKey key, TValue value)
		{
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public void RemoveValue(TValue value)
		{
		}

		public int RemoveAll(TValue value)
		{
			return 0;
		}

		public int IndexOfKey(TKey key)
		{
			return 0;
		}

		public int IndexOfValue(TValue value)
		{
			return 0;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool ContainsValue(TValue value)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void TrimExcess()
		{
		}

		private void NltgMDiqFpNLsMOaJXUHIZwMeZXwA(KeyValuePair<TKey, TValue> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NltgMDiqFpNLsMOaJXUHIZwMeZXwA
			this.NltgMDiqFpNLsMOaJXUHIZwMeZXwA(P_0);
		}

		private bool jTQpTjaQDagGRKMZDAOjsdkJBQDk(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jTQpTjaQDagGRKMZDAOjsdkJBQDk
			return this.jTQpTjaQDagGRKMZDAOjsdkJBQDk(P_0);
		}

		private void QChkxvuvABKPfdeoLZgEoGkmkkwV(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QChkxvuvABKPfdeoLZgEoGkmkkwV
			this.QChkxvuvABKPfdeoLZgEoGkmkkwV(P_0, P_1);
		}

		private bool cUnjyKiuRQlcphJMXaxkGSAuQNawA(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cUnjyKiuRQlcphJMXaxkGSAuQNawA
			return this.cUnjyKiuRQlcphJMXaxkGSAuQNawA(P_0);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Add(object key, object value)
		{
		}

		bool IDictionary.Contains(object key)
		{
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Remove(object key)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		private int zHvIfXgzViQxoKKfulVOMJeOAyHA(TValue P_0)
		{
			return 0;
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zHvIfXgzViQxoKKfulVOMJeOAyHA
			return this.zHvIfXgzViQxoKKfulVOMJeOAyHA(P_0);
		}

		private bool wEPAjyosCskPcbNxtXzfSJntdoBN(TValue P_0)
		{
			return false;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wEPAjyosCskPcbNxtXzfSJntdoBN
			return this.wEPAjyosCskPcbNxtXzfSJntdoBN(P_0);
		}

		private int vHudGghcWPWJxqXFHfzUINhpdSOaA(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in vHudGghcWPWJxqXFHfzUINhpdSOaA
			return this.vHudGghcWPWJxqXFHfzUINhpdSOaA(P_0);
		}

		private bool FRLIDkfNFnczaDRUIYBHbUNphiis(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FRLIDkfNFnczaDRUIYBHbUNphiis
			return this.FRLIDkfNFnczaDRUIYBHbUNphiis(P_0);
		}
	}
}
