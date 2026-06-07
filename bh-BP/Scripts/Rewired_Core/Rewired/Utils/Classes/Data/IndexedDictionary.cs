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
		private struct KdGrzyjICPauknGpnHkObuJrqwAWA
		{
			public TKey ZmqYxjpxeodtTVaKeFtQGsPEXZNs;

			public TValue TrPgHHGcLqPkHeSUeordTutFXjWpA;

			public KdGrzyjICPauknGpnHkObuJrqwAWA(TKey P_0, TValue P_1)
			{
				ZmqYxjpxeodtTVaKeFtQGsPEXZNs = default(TKey);
				TrPgHHGcLqPkHeSUeordTutFXjWpA = default(TValue);
			}

			public KeyValuePair<TKey, TValue> baLfoqiNuOxcrBoNrlormEzvyLPJA()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> nMgHGUPGKTpgMgNxJEqEsJOELBzi;

			private int LCtJqHIlTUVlAgZXeClQoKSnDmHs;

			private int JRQpcASltsHReFfDcyAJifpVCXws;

			private KeyValuePair<TKey, TValue> XNoOrXCalvWhgwxrPTabMoGlLFig;

			private int XhkgFPIPDQZPlgILikYWFTSRisuwA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				nMgHGUPGKTpgMgNxJEqEsJOELBzi = null;
				LCtJqHIlTUVlAgZXeClQoKSnDmHs = 0;
				JRQpcASltsHReFfDcyAJifpVCXws = 0;
				XNoOrXCalvWhgwxrPTabMoGlLFig = default(KeyValuePair<TKey, TValue>);
				XhkgFPIPDQZPlgILikYWFTSRisuwA = 0;
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
				private IndexedDictionary<TKey, TValue> qxMBxKKAaboAZyLXxDDIjHXZpJcZA;

				private int xRZvjrpGlmudankBXVaTvLDHIuraA;

				private int UuMVnPBOGVjCadGvFykWCguxzueqA;

				private TKey pxfecXmkjbIDKgiNXUJvliFxfaXJ;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					qxMBxKKAaboAZyLXxDDIjHXZpJcZA = null;
					xRZvjrpGlmudankBXVaTvLDHIuraA = 0;
					UuMVnPBOGVjCadGvFykWCguxzueqA = 0;
					pxfecXmkjbIDKgiNXUJvliFxfaXJ = default(TKey);
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

			private IndexedDictionary<TKey, TValue> VuZeCZekMLHxBnyyuuYxhUsIEvtJ;

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

			private void pVpcyiyjxxWnDKETatmaHerjtMtj(TKey P_0)
			{
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in pVpcyiyjxxWnDKETatmaHerjtMtj
				this.pVpcyiyjxxWnDKETatmaHerjtMtj(P_0);
			}

			private void LwEmKaoqdRoxddOStDZEhqupJSpk()
			{
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in LwEmKaoqdRoxddOStDZEhqupJSpk
				this.LwEmKaoqdRoxddOStDZEhqupJSpk();
			}

			private bool jxvdBtDXrFBbGQfQISjEweqoiadGA(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in jxvdBtDXrFBbGQfQISjEweqoiadGA
				return this.jxvdBtDXrFBbGQfQISjEweqoiadGA(P_0);
			}

			private bool mticGjdKZOJNExJTPLrIEDfDhWmr(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in mticGjdKZOJNExJTPLrIEDfDhWmr
				return this.mticGjdKZOJNExJTPLrIEDfDhWmr(P_0);
			}

			private IEnumerator<TKey> QxDeiZAPQpkeLbUxDnCKKNAjUNZNB()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in QxDeiZAPQpkeLbUxDnCKKNAjUNZNB
				return this.QxDeiZAPQpkeLbUxDnCKKNAjUNZNB();
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
				private IndexedDictionary<TKey, TValue> zOaxXycZKGwglEcHFDwpqHODBVwi;

				private int cklESFwGSdspMRdNJxmMdOOokKNd;

				private int NgLAcnrueJxQPWPCCHfcLeKvlDEm;

				private TValue eMvAjJgNAazBdfgdrCKjLtMPlPojA;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					zOaxXycZKGwglEcHFDwpqHODBVwi = null;
					cklESFwGSdspMRdNJxmMdOOokKNd = 0;
					NgLAcnrueJxQPWPCCHfcLeKvlDEm = 0;
					eMvAjJgNAazBdfgdrCKjLtMPlPojA = default(TValue);
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

			private IndexedDictionary<TKey, TValue> uexikboKdwVUJbBoMDyLDsmaMtFn;

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

			private void MoWQaUfdAxchAhtLqDhYKjauNOSvA(TValue P_0)
			{
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoWQaUfdAxchAhtLqDhYKjauNOSvA
				this.MoWQaUfdAxchAhtLqDhYKjauNOSvA(P_0);
			}

			private bool BQENigFbzagihELftfXjeWzEEfxCc(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in BQENigFbzagihELftfXjeWzEEfxCc
				return this.BQENigFbzagihELftfXjeWzEEfxCc(P_0);
			}

			private void DEWZqUMLDSBZIalktkmTgzhVStHD()
			{
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DEWZqUMLDSBZIalktkmTgzhVStHD
				this.DEWZqUMLDSBZIalktkmTgzhVStHD();
			}

			private bool sFvYFxUGdZKZZoSrKDCmRrlwhQxb(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in sFvYFxUGdZKZZoSrKDCmRrlwhQxb
				return this.sFvYFxUGdZKZZoSrKDCmRrlwhQxb(P_0);
			}

			private IEnumerator<TValue> iFEKQBsDKQVSZcJGtWTczsrzyFIh()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in iFEKQBsDKQVSZcJGtWTczsrzyFIh
				return this.iFEKQBsDKQVSZcJGtWTczsrzyFIh();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private static readonly bool LxxctBWesUnjqOwPQDzzPFtusaBD;

		private static readonly bool pRlawZDHKhvqmBWBvZTuMKxsjIFx;

		private IEqualityComparer<TKey> eJQjgQorQOPeMactwheazbDNEShF;

		private IEqualityComparer<TValue> ENTYlYIyJzuPCYldXCuEzxqKfomV;

		private readonly AList<KdGrzyjICPauknGpnHkObuJrqwAWA> IzMFncBSDamNMoxBXGmIrjYnMsGd;

		private readonly ADictionary<TKey, int> wlrqSdOKzxjEpHVQHLoSRAJmxjGx;

		private bool GIGaMJjMIUUkfDGOMuaUQPjKQqZg;

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

		private void KNAWowwXNaQQDBRfgDyDrSWJGeao(KeyValuePair<TKey, TValue> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KNAWowwXNaQQDBRfgDyDrSWJGeao
			this.KNAWowwXNaQQDBRfgDyDrSWJGeao(P_0);
		}

		private bool wqpFgSigBpdxcTYIaAwdOVWChqmw(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wqpFgSigBpdxcTYIaAwdOVWChqmw
			return this.wqpFgSigBpdxcTYIaAwdOVWChqmw(P_0);
		}

		private void TwMOmIyOAUPnYurNypzGIWvzVDoc(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TwMOmIyOAUPnYurNypzGIWvzVDoc
			this.TwMOmIyOAUPnYurNypzGIWvzVDoc(P_0, P_1);
		}

		private bool dSKLYbyWRPlfMwFXoZJwwpehCoZJA(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dSKLYbyWRPlfMwFXoZJwwpehCoZJA
			return this.dSKLYbyWRPlfMwFXoZJwwpehCoZJA(P_0);
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

		private int axuwEAcflYTuEHBTSFdZktsdlgXG(TValue P_0)
		{
			return 0;
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in axuwEAcflYTuEHBTSFdZktsdlgXG
			return this.axuwEAcflYTuEHBTSFdZktsdlgXG(P_0);
		}

		private bool pUuNPHqtEfAQHiHeIHQhgfZsBPmn(TValue P_0)
		{
			return false;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pUuNPHqtEfAQHiHeIHQhgfZsBPmn
			return this.pUuNPHqtEfAQHiHeIHQhgfZsBPmn(P_0);
		}

		private int mXBwiBcWCWoMIxuUgEXYijNwHvbo(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mXBwiBcWCWoMIxuUgEXYijNwHvbo
			return this.mXBwiBcWCWoMIxuUgEXYijNwHvbo(P_0);
		}

		private bool IKildBxQFkcwZUlDnzxHXMleeJXs(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IKildBxQFkcwZUlDnzxHXMleeJXs
			return this.IKildBxQFkcwZUlDnzxHXMleeJXs(P_0);
		}
	}
}
