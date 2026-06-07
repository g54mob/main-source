using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class ADictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
	{
		[CustomObfuscation]
		[CustomClassObfuscation]
		internal struct Entry
		{
			public int hashCode;

			public int next;

			public TKey key;

			public TValue value;
		}

		[Serializable]
		[CustomObfuscation]
		[CustomClassObfuscation]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

			private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

			private int OVaNqsFEyODDjJdeKwblTptrPuEz;

			private KeyValuePair<TKey, TValue> FzeFBTyCrPwRSotVRRvPtdRXkqzA;

			private int oawkFEQJtASadJukuuXqlGvZvVOm;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				rqzlMgBEqYlprpsgKizQkexqOZQq = null;
				ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = 0;
				OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(KeyValuePair<TKey, TValue>);
				oawkFEQJtASadJukuuXqlGvZvVOm = 0;
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
		[CustomClassObfuscation]
		[CustomObfuscation]
		public sealed class KeyCollection : IEnumerable, IEnumerable<TKey>, ICollection, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation]
			[CustomClassObfuscation]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TKey NCXBcBSNFcTabgxIwVeWlKzPsDno;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					rqzlMgBEqYlprpsgKizQkexqOZQq = null;
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = 0;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
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

			private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

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

			void ICollection<TKey>.Add(TKey P_0)
			{
			}

			void ICollection<TKey>.Clear()
			{
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				return false;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return null;
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
		[CustomObfuscation]
		[CustomClassObfuscation]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation]
			[CustomClassObfuscation]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TValue WgXGmgexMaKHPzrdvXYODgkBpyoT;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					rqzlMgBEqYlprpsgKizQkexqOZQq = null;
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = 0;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
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

			private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

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

			void ICollection<TValue>.Add(TValue P_0)
			{
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				return false;
			}

			void ICollection<TValue>.Clear()
			{
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				return false;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private int[] GRjPmMpxcKcHngQAGprpQcXdYjEv;

		internal Entry[] _entries;

		internal int _count;

		private int CNDFoUJoeZozIXLwyWmfCLhOpTpJ;

		private int QAqXlPLjKPIJQUtilFIVNMykdEAe;

		private int lMKGAZFeLRKyiprYSrSAuZhwEkOrA;

		private int rwFCyEfTEaKOWGkgIALJGMoQrQveB;

		private IEqualityComparer<TKey> imceZluvEaPVivwVpYaTCMKfDLje;

		private IEqualityComparer<TValue> WYbeMBDIqctHZSJzkTTMpJDAVxPIA;

		private KeyCollection freVGZZoLcUutVigWPIUYOXCaOFo;

		private ValueCollection WcsSbDkbQXyTAgdKmuecERjWzjVW;

		private readonly object RMeCNmGPKKFWHvRprhLLNwMGEUsJA;

		private static readonly bool cxbjJKonGVqunvFiXgKltFLZeWGhA;

		private static readonly bool WNZmPPmomPckHPIvbQCHROzgxsAB;

		private const string WLqCGKEoDHYdTpCYoBDkCpgLNzGyA = "Version";

		private const string YJxlHxicmXyDOCDfYuccZHDfIGHE = "HashSize";

		private const string UKwEPUCrUkOYkbhsFNjncPuYFJyGA = "KeyValuePairs";

		private const string MfdAfVPCgiCOySgNRFwbAkxzutbo = "Comparer";

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

		public TValue Item
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

		object IDictionary.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		private void gUxczTgMdKUcYRnCXamteWaCXJodc(int P_0)
		{
		}

		private void QheURIfNjcSfOlMXZfzaIDWOcarBA(TKey P_0, TValue P_1, bool P_2)
		{
		}

		private void cizKfixQyiMsziIsefTUZmGlIPQY()
		{
		}

		private void cizKfixQyiMsziIsefTUZmGlIPQY(int P_0, bool P_1)
		{
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return null;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
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

		private static bool xKLlArkEJVZwLFeBeHsLjXzqTSBn(object P_0)
		{
			return false;
		}

		private static void xEdKIECfSRyiwDswvidVMpNmkPXo<_0001>(object P_0, string P_1)
		{
		}
	}
}
