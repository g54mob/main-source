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
		private struct YCYQGfPOHoZnBniwbkpPdHzPLfsG
		{
			public TKey HTwOlcPxNRYmeBFOqdBRDpeyuwjC;

			public TValue RTTmKICGXbDowMJulxgtvThoSapA;

			public YCYQGfPOHoZnBniwbkpPdHzPLfsG(TKey P_0, TValue P_1)
			{
				HTwOlcPxNRYmeBFOqdBRDpeyuwjC = default(TKey);
				RTTmKICGXbDowMJulxgtvThoSapA = default(TValue);
			}

			public KeyValuePair<TKey, TValue> fgBXdYtpotHGywGfdmqIJFMPuptb()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> xtgvsJdoVmRQjqFqBWKLxwiuroVO;

			private int VdnTsWiZMhQrlyJCoxzDvWgTDXnf;

			private int BOWqEZahsBXuVJSWqCmKvXLprgKT;

			private KeyValuePair<TKey, TValue> JssxbIiJhKcnJkueFEZicTEdLqKjc;

			private int NiruQdtQBpsACUIKgCZPYqrpNKkB;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				xtgvsJdoVmRQjqFqBWKLxwiuroVO = null;
				VdnTsWiZMhQrlyJCoxzDvWgTDXnf = 0;
				BOWqEZahsBXuVJSWqCmKvXLprgKT = 0;
				JssxbIiJhKcnJkueFEZicTEdLqKjc = default(KeyValuePair<TKey, TValue>);
				NiruQdtQBpsACUIKgCZPYqrpNKkB = 0;
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
				private IndexedDictionary<TKey, TValue> oIGFQTaLrUcjyesUhORLKbxpYiIN;

				private int joVKfkNBaLKsLpuGXylUoBzhBOVG;

				private int KLMMIKlDPkhhTYaoDFkZlVSBBFIU;

				private TKey vIpWNCAxdYwtvmgSPFYsusbJDGjEA;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					oIGFQTaLrUcjyesUhORLKbxpYiIN = null;
					joVKfkNBaLKsLpuGXylUoBzhBOVG = 0;
					KLMMIKlDPkhhTYaoDFkZlVSBBFIU = 0;
					vIpWNCAxdYwtvmgSPFYsusbJDGjEA = default(TKey);
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

			private IndexedDictionary<TKey, TValue> LLBDjCYVZkEEcrFduzEgiRQwUjTx;

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

			private void rkzrDvOaoCzpkKpCiizlaUJBzCJkA(TKey P_0)
			{
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in rkzrDvOaoCzpkKpCiizlaUJBzCJkA
				this.rkzrDvOaoCzpkKpCiizlaUJBzCJkA(P_0);
			}

			private void ZJUlDbMiokCOEhwPrbTFqoEBjgXW()
			{
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ZJUlDbMiokCOEhwPrbTFqoEBjgXW
				this.ZJUlDbMiokCOEhwPrbTFqoEBjgXW();
			}

			private bool xInokKluCyUbilJuIdVSjUpOJXbB(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in xInokKluCyUbilJuIdVSjUpOJXbB
				return this.xInokKluCyUbilJuIdVSjUpOJXbB(P_0);
			}

			private bool sMqFbuPaEdLgdhqCJvPLXNHlehUU(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in sMqFbuPaEdLgdhqCJvPLXNHlehUU
				return this.sMqFbuPaEdLgdhqCJvPLXNHlehUU(P_0);
			}

			private IEnumerator<TKey> OIRHYZrZGCFcvMcsrSNIEmioqlZB()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in OIRHYZrZGCFcvMcsrSNIEmioqlZB
				return this.OIRHYZrZGCFcvMcsrSNIEmioqlZB();
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
				private IndexedDictionary<TKey, TValue> lrgrWhGLAvtDYSpIVcBqpSurZqWO;

				private int gwdXtEGgPMOFdJwqHvlJiRkUWFfW;

				private int TZJBnkPSrwaGuCtAWFRjaKoZNOuJA;

				private TValue eTfQKInFzJmDCcazlCjwscnvkRSC;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					lrgrWhGLAvtDYSpIVcBqpSurZqWO = null;
					gwdXtEGgPMOFdJwqHvlJiRkUWFfW = 0;
					TZJBnkPSrwaGuCtAWFRjaKoZNOuJA = 0;
					eTfQKInFzJmDCcazlCjwscnvkRSC = default(TValue);
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

			private IndexedDictionary<TKey, TValue> kBbcRaCacXmcanszIXwMKCKWiKdz;

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

			private void SRCTHLDuXQOfrbtAshhXqgOYpaai(TValue P_0)
			{
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SRCTHLDuXQOfrbtAshhXqgOYpaai
				this.SRCTHLDuXQOfrbtAshhXqgOYpaai(P_0);
			}

			private bool JPCVptfTqDHzUTTyhPNyBROeYeDf(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in JPCVptfTqDHzUTTyhPNyBROeYeDf
				return this.JPCVptfTqDHzUTTyhPNyBROeYeDf(P_0);
			}

			private void DBOawDsNYdhmjFcchJuSEfLrznxnA()
			{
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DBOawDsNYdhmjFcchJuSEfLrznxnA
				this.DBOawDsNYdhmjFcchJuSEfLrznxnA();
			}

			private bool madhbKAmLydpowmBUmFBoCHMSCgnA(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in madhbKAmLydpowmBUmFBoCHMSCgnA
				return this.madhbKAmLydpowmBUmFBoCHMSCgnA(P_0);
			}

			private IEnumerator<TValue> aAAvfEIUBluaumBLrqQvesWVFNgv()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in aAAvfEIUBluaumBLrqQvesWVFNgv
				return this.aAAvfEIUBluaumBLrqQvesWVFNgv();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private static readonly bool ZIxXFKqThdAYHWNdGDBsMdrYxLvr;

		private static readonly bool rodHiEfTkEFQBNCKpFYhZBWAtRnC;

		private IEqualityComparer<TKey> eWCAKPcGwbCmzXghoittGchFhhLmc;

		private IEqualityComparer<TValue> ESVOnFuOnMuXnQkdNoiPqKEcFcAj;

		private readonly AList<YCYQGfPOHoZnBniwbkpPdHzPLfsG> WGAzajjyPLOFfahgRsUNkYVJCxmu;

		private readonly ADictionary<TKey, int> mUxpCaoliYxqWFEHNoKBEenSIYwT;

		private bool YxMpNUVjZrKdURTVWesBVdNugpfKA;

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

		private void UsMJZdCGKLpCgBqUqgXUmoAxXNWe(KeyValuePair<TKey, TValue> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UsMJZdCGKLpCgBqUqgXUmoAxXNWe
			this.UsMJZdCGKLpCgBqUqgXUmoAxXNWe(P_0);
		}

		private bool mPtJsZIKIIXYJBHZwiuuHlwqHIYK(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mPtJsZIKIIXYJBHZwiuuHlwqHIYK
			return this.mPtJsZIKIIXYJBHZwiuuHlwqHIYK(P_0);
		}

		private void RJMPnNKFFbzgnmnauyvFZduLvkdS(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RJMPnNKFFbzgnmnauyvFZduLvkdS
			this.RJMPnNKFFbzgnmnauyvFZduLvkdS(P_0, P_1);
		}

		private bool dNIndyMvWeIvdqHOiTWxbnMBLXfh(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dNIndyMvWeIvdqHOiTWxbnMBLXfh
			return this.dNIndyMvWeIvdqHOiTWxbnMBLXfh(P_0);
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

		private int ejyvVJYxkldydXEECkJArSTTOSvS(TValue P_0)
		{
			return 0;
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ejyvVJYxkldydXEECkJArSTTOSvS
			return this.ejyvVJYxkldydXEECkJArSTTOSvS(P_0);
		}

		private bool rleOoCEGNQstycIbSvNsbnnIhiEM(TValue P_0)
		{
			return false;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rleOoCEGNQstycIbSvNsbnnIhiEM
			return this.rleOoCEGNQstycIbSvNsbnnIhiEM(P_0);
		}

		private int wiHDZGATSzbrpxHzgBBTzzXCAvXe(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wiHDZGATSzbrpxHzgBBTzzXCAvXe
			return this.wiHDZGATSzbrpxHzgBBTzzXCAvXe(P_0);
		}

		private bool AVyUyCBSYLBQoOnCvfOEMCNMbipO(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AVyUyCBSYLBQoOnCvfOEMCNMbipO
			return this.AVyUyCBSYLBQoOnCvfOEMCNMbipO(P_0);
		}
	}
}
