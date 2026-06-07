using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal struct Entry
		{
			public int hashCode;

			public int next;

			public TKey key;

			public TValue value;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private ADictionary<TKey, TValue> JrDdGDPLgFKAhpPICwSezbQFYuIQ;

			private int GiocPIbssELRuHaXPtkiishjayljA;

			private int CEBKZtCEnHblQTfByamhJdSuGhLH;

			private KeyValuePair<TKey, TValue> NUArHLlhfcaZAADQJeDaxZjiDlVw;

			private int GgqZaiCpeGWbNyBAKVJaFLfQfPoJA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				JrDdGDPLgFKAhpPICwSezbQFYuIQ = null;
				GiocPIbssELRuHaXPtkiishjayljA = 0;
				CEBKZtCEnHblQTfByamhJdSuGhLH = 0;
				NUArHLlhfcaZAADQJeDaxZjiDlVw = default(KeyValuePair<TKey, TValue>);
				GgqZaiCpeGWbNyBAKVJaFLfQfPoJA = 0;
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
				private ADictionary<TKey, TValue> KGrEzdAWMnBjHppXdUZXxcdCFKhT;

				private int UOvWEOPZuRMfQWXJSeUTanfXVRcr;

				private int rkWUDbagURByjKytobgVgSIqGfGt;

				private TKey KZQrUAxRvwFfphyBXVsQmDjUjwrNA;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					KGrEzdAWMnBjHppXdUZXxcdCFKhT = null;
					UOvWEOPZuRMfQWXJSeUTanfXVRcr = 0;
					rkWUDbagURByjKytobgVgSIqGfGt = 0;
					KZQrUAxRvwFfphyBXVsQmDjUjwrNA = default(TKey);
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

			private ADictionary<TKey, TValue> vHIAmaEuccJTTjApQAgafsCzqIQB;

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

			private void blGfjABTIrvQlKVguonveXTfLeWTA(TKey P_0)
			{
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in blGfjABTIrvQlKVguonveXTfLeWTA
				this.blGfjABTIrvQlKVguonveXTfLeWTA(P_0);
			}

			private void eRTJBlNCZRbpMwecKFHJbjvzDYsX()
			{
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in eRTJBlNCZRbpMwecKFHJbjvzDYsX
				this.eRTJBlNCZRbpMwecKFHJbjvzDYsX();
			}

			private bool iobpgDhkwdvdhddpjogyQawZMSSn(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in iobpgDhkwdvdhddpjogyQawZMSSn
				return this.iobpgDhkwdvdhddpjogyQawZMSSn(P_0);
			}

			private bool bfaqMLekNFhZbfeAulBqGbnNhbYAA(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in bfaqMLekNFhZbfeAulBqGbnNhbYAA
				return this.bfaqMLekNFhZbfeAulBqGbnNhbYAA(P_0);
			}

			private IEnumerator<TKey> CbJcBAsRJiGTUUAnjQQObUaDgODt()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in CbJcBAsRJiGTUUAnjQQObUaDgODt
				return this.CbJcBAsRJiGTUUAnjQQObUaDgODt();
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
				private ADictionary<TKey, TValue> nuMHMENNqolCfvFAFtBXOYRXqlB;

				private int GzaebFeUWlqPahyrguKqcjjjdpfAd;

				private int pijoDdmspkYGeUoVMdnAUXbOvsiU;

				private TValue xgzGUoZzkCMfWocHWGEcDGaPNJovA;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					nuMHMENNqolCfvFAFtBXOYRXqlB = null;
					GzaebFeUWlqPahyrguKqcjjjdpfAd = 0;
					pijoDdmspkYGeUoVMdnAUXbOvsiU = 0;
					xgzGUoZzkCMfWocHWGEcDGaPNJovA = default(TValue);
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

			private ADictionary<TKey, TValue> mPbTCiZIXAkamQqXFInMnujIDPQW;

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

			private void ZwWFZqqYOFHeyHdVdgUfRiCgHAHu(TValue P_0)
			{
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ZwWFZqqYOFHeyHdVdgUfRiCgHAHu
				this.ZwWFZqqYOFHeyHdVdgUfRiCgHAHu(P_0);
			}

			private bool YusUcKhWWibSPrRySmGpZYjftWWn(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in YusUcKhWWibSPrRySmGpZYjftWWn
				return this.YusUcKhWWibSPrRySmGpZYjftWWn(P_0);
			}

			private void qFYrFSeGxtQRrALfackagrlFrdtdA()
			{
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in qFYrFSeGxtQRrALfackagrlFrdtdA
				this.qFYrFSeGxtQRrALfackagrlFrdtdA();
			}

			private bool KYgXtxSojEPVJgSEsbvoFGbwgNsfA(TValue P_0)
			{
				return false;
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in KYgXtxSojEPVJgSEsbvoFGbwgNsfA
				return this.KYgXtxSojEPVJgSEsbvoFGbwgNsfA(P_0);
			}

			private IEnumerator<TValue> ICQLlEbWYkSXvLBiTggIatiQfVZDA()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ICQLlEbWYkSXvLBiTggIatiQfVZDA
				return this.ICQLlEbWYkSXvLBiTggIatiQfVZDA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private int[] aMJKjANElaGiWBxXEnvAbhlpMcoYA;

		internal Entry[] _entries;

		internal int _count;

		private int waRWYfbrnGhSJddkHUizQDCFuYVG;

		private int tDYNCjBpkMIJTIVgMigeKLlkJLcoA;

		private int zIvbGmouNUZrUzClUfsVQNfmmOWh;

		private int lUeaefhNBzzKxfvHIlPJAUFfMpAtb;

		private IEqualityComparer<TKey> ckClBdjssHuklQxiOoLwvKUqRXwO;

		private IEqualityComparer<TValue> KpFKsDUJMVEHYIvMoHCdhsRwSfHl;

		private KeyCollection AomFrCkOImfsRcPCfVxWkEpaOVzwc;

		private ValueCollection JfvDEZkrMLPnJuySxsLIftLjElpuA;

		private readonly object EvTswLiYJYCqYWoGMBZJBUSCDvHuA;

		private static readonly bool AuTDWJAWPqiKNJEZcZKjrlkDwlvO;

		private static readonly bool uyCiXjjMQoUFoYSqdtrnrJydVHwL;

		private const string RgdyvyKROqHLkJmHVFYUWwUtaDEn = "Version";

		private const string LYEJMOtjBoHfzxfKWsAuGnAegJpr = "HashSize";

		private const string UfrBSmahyWzHdjzPQGoxcffjUEdbA = "KeyValuePairs";

		private const string aDknwcMCisjQACTuupHyEBzsaJEi = "Comparer";

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

		private void BuvrflKmOPjpaAWsbWbYvnlySQSm(int P_0)
		{
		}

		private void QnphfFEfVKMtrPdeCvmSoTMwkrWg(TKey P_0, TValue P_1, bool P_2)
		{
		}

		private void UOverVhCMnYVgBATqlXoECOeJmJbb()
		{
		}

		private void IEAltzsbxqlalTYTRmBNDtBEnsuF(int P_0, bool P_1)
		{
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> SFEfgDuOztWKZDniNTTwNSZzhcBF()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SFEfgDuOztWKZDniNTTwNSZzhcBF
			return this.SFEfgDuOztWKZDniNTTwNSZzhcBF();
		}

		private void MluxxRRApXwCSqDtYCldYrdeSHKB(KeyValuePair<TKey, TValue> P_0)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MluxxRRApXwCSqDtYCldYrdeSHKB
			this.MluxxRRApXwCSqDtYCldYrdeSHKB(P_0);
		}

		private bool SdLTOIYBxFhXkPteaVIUUUrSidtX(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SdLTOIYBxFhXkPteaVIUUUrSidtX
			return this.SdLTOIYBxFhXkPteaVIUUUrSidtX(P_0);
		}

		private bool SmAAQXzTbyBxzcKDpULXYgSnUoRT(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SmAAQXzTbyBxzcKDpULXYgSnUoRT
			return this.SmAAQXzTbyBxzcKDpULXYgSnUoRT(P_0);
		}

		private void xxydEzFFXMOELAeNzruBEHbFrcLXA(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xxydEzFFXMOELAeNzruBEHbFrcLXA
			this.xxydEzFFXMOELAeNzruBEHbFrcLXA(P_0, P_1);
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

		private static bool erBYOBuLyGXMaOpfHaDtosSRtYxv(object P_0)
		{
			return false;
		}

		private static void crsyfOpxwdJWVwfKDZvStqhURjNJ<_0001>(object P_0, string P_1)
		{
		}
	}
}
