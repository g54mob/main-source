using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal struct Entry
		{
			public int hashCode;

			public int next;

			public TKey key;

			public TValue value;
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private ADictionary<TKey, TValue> TmtLEtqNHaFijOFHQiQVGtAOvyUp;

			private int AeYxYqLzZtlOgVRIPEoJNzhytypL;

			private int OzxBLDdvIkAiYiRMaNaOcsGjfYRS;

			private KeyValuePair<TKey, TValue> FjiiWlORITKoWxHqTPXVMdthzuZD;

			private int WCWZjUnoBhHcHKNDIOFFKqhHARuUA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				TmtLEtqNHaFijOFHQiQVGtAOvyUp = null;
				AeYxYqLzZtlOgVRIPEoJNzhytypL = 0;
				OzxBLDdvIkAiYiRMaNaOcsGjfYRS = 0;
				FjiiWlORITKoWxHqTPXVMdthzuZD = default(KeyValuePair<TKey, TValue>);
				WCWZjUnoBhHcHKNDIOFFKqhHARuUA = 0;
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
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> KaLTgFzkhABuPFMCfOXoIIjVaItdb;

				private int CXFeNkAmHshwOClGiOKoQNjbQZyvB;

				private int zVeBRTXftqCrbdmysLikPmOtdjSR;

				private TKey OguEFcQNUVtilVhEHsybiLpDGwvq;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					KaLTgFzkhABuPFMCfOXoIIjVaItdb = null;
					CXFeNkAmHshwOClGiOKoQNjbQZyvB = 0;
					zVeBRTXftqCrbdmysLikPmOtdjSR = 0;
					OguEFcQNUVtilVhEHsybiLpDGwvq = default(TKey);
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

			private ADictionary<TKey, TValue> xndJsYphHVQXZETFjCXBCUogsXMh;

			public int Count => 0;

			bool ICollection<TKey>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
			}

			public Enumerator GetEnumerator()
			{
				return default(Enumerator);
			}

			public void CopyTo(TKey[] array, int index)
			{
			}

			private void jYgSsymWlMvNlkpbyvWYgfViFmGu(TKey P_0)
			{
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in jYgSsymWlMvNlkpbyvWYgfViFmGu
				this.jYgSsymWlMvNlkpbyvWYgfViFmGu(P_0);
			}

			private void uoxIMJyjwuggEXirCaJsSmfmZEqM()
			{
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in uoxIMJyjwuggEXirCaJsSmfmZEqM
				this.uoxIMJyjwuggEXirCaJsSmfmZEqM();
			}

			private bool ouRHzfQxDQAcbYRshveJvGwStOCO(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ouRHzfQxDQAcbYRshveJvGwStOCO
				return this.ouRHzfQxDQAcbYRshveJvGwStOCO(P_0);
			}

			private bool nDCgVdDnigTQlEqJcoDHlUfCMzWK(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in nDCgVdDnigTQlEqJcoDHlUfCMzWK
				return this.nDCgVdDnigTQlEqJcoDHlUfCMzWK(P_0);
			}

			private IEnumerator<TKey> GElYLsVTiBGDSjFwrgSdSCeKpKPR()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in GElYLsVTiBGDSjFwrgSdSCeKpKPR
				return this.GElYLsVTiBGDSjFwrgSdSCeKpKPR();
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
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> FaLThtdSeyvfzYxeMLDGcDIEBFkt;

				private int KMQWsrrhfAHSsPxcyDYNHSpqXnQHA;

				private int byJGMDRBOTLRcniUIYplpDrFYwsV;

				private TValue hCXQFSkfNlLkIBBECwIBhpuKPJsX;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					FaLThtdSeyvfzYxeMLDGcDIEBFkt = null;
					KMQWsrrhfAHSsPxcyDYNHSpqXnQHA = 0;
					byJGMDRBOTLRcniUIYplpDrFYwsV = 0;
					hCXQFSkfNlLkIBBECwIBhpuKPJsX = default(TValue);
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

			private ADictionary<TKey, TValue> oVHFRMjsmdGlyrxIJnjpUXvXbRQkA;

			public int Count => 0;

			bool ICollection<TValue>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
			}

			public Enumerator GetEnumerator()
			{
				return default(Enumerator);
			}

			public void CopyTo(TValue[] array, int index)
			{
			}

			private void FMgsOYFjjuSCqyQYxBcMsxCdNERv(TValue P_0)
			{
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FMgsOYFjjuSCqyQYxBcMsxCdNERv
				this.FMgsOYFjjuSCqyQYxBcMsxCdNERv(P_0);
			}

			private bool EOWcjoGUpXMBBRQjOMAIUgdsMWMnA(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in EOWcjoGUpXMBBRQjOMAIUgdsMWMnA
				return this.EOWcjoGUpXMBBRQjOMAIUgdsMWMnA(P_0);
			}

			private void mdqHUmLKWCDEhzRaaYoZMypCMjpP()
			{
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in mdqHUmLKWCDEhzRaaYoZMypCMjpP
				this.mdqHUmLKWCDEhzRaaYoZMypCMjpP();
			}

			private bool SkOaiFAfEfYSPHZXatpFwevvVJeeA(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SkOaiFAfEfYSPHZXatpFwevvVJeeA
				return this.SkOaiFAfEfYSPHZXatpFwevvVJeeA(P_0);
			}

			private IEnumerator<TValue> OFgLceYydZkSnqsfRkgdPpkVdTTS()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in OFgLceYydZkSnqsfRkgdPpkVdTTS
				return this.OFgLceYydZkSnqsfRkgdPpkVdTTS();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private int[] sWnnagadOVSfAMvOYKzbKpjadmiM;

		internal Entry[] _entries;

		internal int _count;

		private int aapJJtYAXliNEYalXEWnfQuMiZhc;

		private int vEsINXocLfVUDjRdMEeRjuxjrRwCA;

		private int lWJmSILEixMSGQYkEtjgrivvDcWU;

		private int ppQXrXaIgQcVfMEWMMXwnDHZOtEU;

		private IEqualityComparer<TKey> uykIIBMNPoflnbjvOTLXFIOdyXqOA;

		private IEqualityComparer<TValue> AfSDjanbwhFWtjVgVRWiEBxxUFbA;

		private KeyCollection GyMtcqdqxXJhNuMNHTlhjuvRTRxt;

		private ValueCollection REPYZxYbxcUqFNRNpFLjYkNsllvu;

		private readonly object SrpElnIHsthbCYjTMhVipxKXVzTSA;

		private static readonly bool CptqNzbimLEDLkwGaYMWMRiALhfq;

		private static readonly bool aImpGFKJrTKKstytfepWIqisJJgs;

		private const string BFPCaAHvhLqQgvcCVjWpptSiPVAKA = "Version";

		private const string BEwKzgMqaRcwvGrHQMjLjjGpCFzs = "HashSize";

		private const string IDHBBCiKVzLUhjUKIcoYnAleSGfmA = "KeyValuePairs";

		private const string sBEeaOzvDLqsMlRzeOlBjhzpPmKt = "Comparer";

		public int Count => 0;

		public int TotalCount => 0;

		public KeyCollection Keys => null;

		public ValueCollection Values => null;

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

		public TValue this[TKey key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public int IndexOfFirst => 0;

		public int IndexOfLast => 0;

		ICollection<TKey> IDictionary<TKey, TValue>.Keys => null;

		ICollection<TValue> IDictionary<TKey, TValue>.Values => null;

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

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

		ICollection<TKey> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Keys => null;

		ICollection<TValue> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Values => null;

		public ADictionary()
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0, IEqualityComparer<TValue> P_1)
		{
		}

		public ADictionary(int P_0)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void Clear()
		{
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool ContainsValue(TValue value)
		{
			return false;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public TValue GetValueSafe(TKey key)
		{
			return default(TValue);
		}

		public int IndexOfKey(TKey key)
		{
			return 0;
		}

		public int IndexOfValue(TValue value)
		{
			return 0;
		}

		public bool IsValidAt(int index)
		{
			return false;
		}

		public TKey GetKeyAt(int index)
		{
			return default(TKey);
		}

		public TValue GetValueAt(int index)
		{
			return default(TValue);
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public bool TryGetKeyAt(int index, out TKey key)
		{
			key = default(TKey);
			return false;
		}

		public bool TryGetValueAt(int index, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetNextIndex(ref int index)
		{
			return false;
		}

		public int GetNextIndex(int index)
		{
			return 0;
		}

		public bool GetNextKey(ref int index, out TKey key)
		{
			key = default(TKey);
			return false;
		}

		public bool GetNextValue(ref int index, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetPreviousIndex(ref int index)
		{
			return false;
		}

		public int GetPreviousIndex(int index)
		{
			return 0;
		}

		public bool GetPreviousKey(ref int index, out TKey key)
		{
			key = default(TKey);
			return false;
		}

		public bool GetPreviousValue(ref int index, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool RemoveAt(int index)
		{
			return false;
		}

		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
		}

		private void TpPfoVdFpcvqcbUpnpznKxlbDUCN(int P_0)
		{
		}

		private void EPFynLreabPbretOMxajPIyvobKC(TKey P_0, TValue P_1, bool P_2)
		{
		}

		private void OULxkdfirWpKshjSspXPrGStroDp()
		{
		}

		private void CksqTZDEXOcbFsAgBeuJaRjXvulc(int P_0, bool P_1)
		{
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> AZodanRvSKrTTowjTVTZkVJmWrXX()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in AZodanRvSKrTTowjTVTZkVJmWrXX
			return this.AZodanRvSKrTTowjTVTZkVJmWrXX();
		}

		private void KpEkdLgfhkvWABpGWInIrkbpGsLg(KeyValuePair<TKey, TValue> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KpEkdLgfhkvWABpGWInIrkbpGsLg
			this.KpEkdLgfhkvWABpGWInIrkbpGsLg(P_0);
		}

		private bool IabAqmhXAyGJaselcGKfnbpJLzlu(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IabAqmhXAyGJaselcGKfnbpJLzlu
			return this.IabAqmhXAyGJaselcGKfnbpJLzlu(P_0);
		}

		private bool GTmDRxOPATyBvVmOrLyopsOyolNg(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GTmDRxOPATyBvVmOrLyopsOyolNg
			return this.GTmDRxOPATyBvVmOrLyopsOyolNg(P_0);
		}

		private void lOOwPVilarGPBkBIrNuaskbIxkTaA(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lOOwPVilarGPBkBIrNuaskbIxkTaA
			this.lOOwPVilarGPBkBIrNuaskbIxkTaA(P_0, P_1);
		}

		void ICollection.CopyTo(Array array, int index)
		{
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

		private static bool uSfbFtFZTzwPqUzcNoZYEJAYwYpSA(object P_0)
		{
			return false;
		}

		private static void mpKruiMpVYWEDTwLXRHhKYvJFtZi<_0001>(object P_0, string P_1)
		{
		}
	}
}
