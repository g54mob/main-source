using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct CAkbVJeHcNYITSQxzniwYVlCJZcn
		{
			public TKey PjSPaEoUMyJGeaWIoxlgqzyjcHtD;

			public TValue BljlKuzdpcEPezWCgtXXCGHqOeqH;

			public CAkbVJeHcNYITSQxzniwYVlCJZcn(TKey P_0, TValue P_1)
			{
				PjSPaEoUMyJGeaWIoxlgqzyjcHtD = default(TKey);
				BljlKuzdpcEPezWCgtXXCGHqOeqH = default(TValue);
			}

			public KeyValuePair<TKey, TValue> nTfKEZCHQSGCQPsTloELqgDCCypU()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> vsGCjtAAiZZLdTBpXOEauUodYqVcA;

			private int BZZOgaXNlYBLtZFTijoqOAcOhNpv;

			private int VswDPjZXVqAvNwbTezozODRgaaOhA;

			private KeyValuePair<TKey, TValue> ZTWZsyHVIzFiNDSbBhHZuYYKLkWP;

			private int FbMxJyMvmAnfUxGNqOTavsekNIIi;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				vsGCjtAAiZZLdTBpXOEauUodYqVcA = null;
				BZZOgaXNlYBLtZFTijoqOAcOhNpv = 0;
				VswDPjZXVqAvNwbTezozODRgaaOhA = 0;
				ZTWZsyHVIzFiNDSbBhHZuYYKLkWP = default(KeyValuePair<TKey, TValue>);
				FbMxJyMvmAnfUxGNqOTavsekNIIi = 0;
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
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private IndexedDictionary<TKey, TValue> aXqRHtDUMzoomRzXzATwjsvcSmUm;

				private int jLrXQZgXrsZDqATfXeAhTnqqTxJd;

				private int GomBijUyGPsHHpdLBkGsGYLQVrGE;

				private TKey jaBGUyfSCpHkdJxLPcAFCJnQOCtFA;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					aXqRHtDUMzoomRzXzATwjsvcSmUm = null;
					jLrXQZgXrsZDqATfXeAhTnqqTxJd = 0;
					GomBijUyGPsHHpdLBkGsGYLQVrGE = 0;
					jaBGUyfSCpHkdJxLPcAFCJnQOCtFA = default(TKey);
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

			private IndexedDictionary<TKey, TValue> FUbcHqrpcXJXmOsikSBBZoGxnQRh;

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

			private void hyTfUPvsRpotanELcgdErXHQiAJW(TKey P_0)
			{
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hyTfUPvsRpotanELcgdErXHQiAJW
				this.hyTfUPvsRpotanELcgdErXHQiAJW(P_0);
			}

			private void VvysOTzDRTBJCGyWbJVsRRCSoXVL()
			{
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in VvysOTzDRTBJCGyWbJVsRRCSoXVL
				this.VvysOTzDRTBJCGyWbJVsRRCSoXVL();
			}

			private bool rRXdWAMNqVXdpSCrYrKcEKrHDIPG(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in rRXdWAMNqVXdpSCrYrKcEKrHDIPG
				return this.rRXdWAMNqVXdpSCrYrKcEKrHDIPG(P_0);
			}

			private bool aWMsiOesdKMzhWqLLtRuuRRyFdEw(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in aWMsiOesdKMzhWqLLtRuuRRyFdEw
				return this.aWMsiOesdKMzhWqLLtRuuRRyFdEw(P_0);
			}

			private IEnumerator<TKey> IRfKBwAgujOacjPnzYuoxKatgIbG()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in IRfKBwAgujOacjPnzYuoxKatgIbG
				return this.IRfKBwAgujOacjPnzYuoxKatgIbG();
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
				private IndexedDictionary<TKey, TValue> nrWEHHllfQhCEdbXTtFLKpiofmKq;

				private int sNLayshlatkEfAwdHNdaBZiNXRtEB;

				private int BJrzeQoxQHpPgnKJAJTYtsiOdSgIA;

				private TValue cGNZVySopetFGNdwvEeNVerocAGe;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					nrWEHHllfQhCEdbXTtFLKpiofmKq = null;
					sNLayshlatkEfAwdHNdaBZiNXRtEB = 0;
					BJrzeQoxQHpPgnKJAJTYtsiOdSgIA = 0;
					cGNZVySopetFGNdwvEeNVerocAGe = default(TValue);
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

			private IndexedDictionary<TKey, TValue> oeTGMSbmJofMoYfmIwNlxdKRMJdG;

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

			private void GoydYhqeqrNXbQrPicziDbKVHteV(TValue P_0)
			{
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GoydYhqeqrNXbQrPicziDbKVHteV
				this.GoydYhqeqrNXbQrPicziDbKVHteV(P_0);
			}

			private bool NngaGXKNPsTYYaexvbPXyXBtSSZx(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in NngaGXKNPsTYYaexvbPXyXBtSSZx
				return this.NngaGXKNPsTYYaexvbPXyXBtSSZx(P_0);
			}

			private void XieanrFRvYQzjCZxdxwjDAFeplrcA()
			{
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in XieanrFRvYQzjCZxdxwjDAFeplrcA
				this.XieanrFRvYQzjCZxdxwjDAFeplrcA();
			}

			private bool qIBxkqBOsZumaFVCEALitfFPnKmn(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in qIBxkqBOsZumaFVCEALitfFPnKmn
				return this.qIBxkqBOsZumaFVCEALitfFPnKmn(P_0);
			}

			private IEnumerator<TValue> gLmEmwfvaKfdykBSfRMAFXWWaHigA()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in gLmEmwfvaKfdykBSfRMAFXWWaHigA
				return this.gLmEmwfvaKfdykBSfRMAFXWWaHigA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private static readonly bool JdDdKqELQOETDfdugIRDozdnBBrAc;

		private static readonly bool vOLGtcYetlIfHsDunLOSmXTVfixD;

		private IEqualityComparer<TKey> sPyXDjrfHUIvbGLosMxStDjgHnTDb;

		private IEqualityComparer<TValue> IinRfxXnbxdHrbtDLqdaVeGpLVQH;

		private readonly AList<CAkbVJeHcNYITSQxzniwYVlCJZcn> WcqDrTOrkoAArhLvPpQsBLTEMlmSb;

		private readonly ADictionary<TKey, int> gKTCqSZaDnLsAaTMDgcgpfhHYCiX;

		private bool YKciEskkcMkSYwaQUgqmeUPxKvbx;

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

		private void QKcUVZvzEeqgoehPgkdyXuAaHYhc(KeyValuePair<TKey, TValue> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QKcUVZvzEeqgoehPgkdyXuAaHYhc
			this.QKcUVZvzEeqgoehPgkdyXuAaHYhc(P_0);
		}

		private bool mqLmdfpSnzMJZyJIydqVacerVTQiA(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mqLmdfpSnzMJZyJIydqVacerVTQiA
			return this.mqLmdfpSnzMJZyJIydqVacerVTQiA(P_0);
		}

		private void DZiiwvhzkMhtzZgjkbxqaUgKwotr(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DZiiwvhzkMhtzZgjkbxqaUgKwotr
			this.DZiiwvhzkMhtzZgjkbxqaUgKwotr(P_0, P_1);
		}

		private bool tpmuoWdcxRBRtNGFgjVYQMIIgTzGA(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tpmuoWdcxRBRtNGFgjVYQMIIgTzGA
			return this.tpmuoWdcxRBRtNGFgjVYQMIIgTzGA(P_0);
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

		private int eAAFIpjbDYKflWeFMfDtQSZCJQdCb(TValue P_0)
		{
			return 0;
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eAAFIpjbDYKflWeFMfDtQSZCJQdCb
			return this.eAAFIpjbDYKflWeFMfDtQSZCJQdCb(P_0);
		}

		private bool xxAhfcjnmbhcceJaYbHJnSzRwiUmA(TValue P_0)
		{
			return false;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xxAhfcjnmbhcceJaYbHJnSzRwiUmA
			return this.xxAhfcjnmbhcceJaYbHJnSzRwiUmA(P_0);
		}

		private int yudYcmraWwsfCIKkrNsXSdRpERz(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yudYcmraWwsfCIKkrNsXSdRpERz
			return this.yudYcmraWwsfCIKkrNsXSdRpERz(P_0);
		}

		private bool QiCTLsgGvceKadmJtrttziLHHedq(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QiCTLsgGvceKadmJtrttziLHHedq
			return this.QiCTLsgGvceKadmJtrttziLHHedq(P_0);
		}
	}
}
