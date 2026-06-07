using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct onwvlRAXvfuHAecwrrOKpDmxyjXF
		{
			public TKey xzRewGuNweXrZjgHBeZSFNenqiYrA;

			public TValue pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

			public onwvlRAXvfuHAecwrrOKpDmxyjXF(TKey P_0, TValue P_1)
			{
				xzRewGuNweXrZjgHBeZSFNenqiYrA = default(TKey);
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = default(TValue);
			}

			public KeyValuePair<TKey, TValue> pSzkhDNdWcyKdSeTnpgGTeXCedcf()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		[CustomObfuscation]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

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

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
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
				private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TKey NCXBcBSNFcTabgxIwVeWlKzPsDno;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
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

			private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

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
				private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TValue WgXGmgexMaKHPzrdvXYODgkBpyoT;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
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

			private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

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

		private static readonly bool cxbjJKonGVqunvFiXgKltFLZeWGhA;

		private static readonly bool WNZmPPmomPckHPIvbQCHROzgxsAB;

		private IEqualityComparer<TKey> imceZluvEaPVivwVpYaTCMKfDLje;

		private IEqualityComparer<TValue> WYbeMBDIqctHZSJzkTTMpJDAVxPIA;

		private readonly AList<onwvlRAXvfuHAecwrrOKpDmxyjXF> yStgeWABMBrpmQklPqcEgwUnhfhE;

		private readonly ADictionary<TKey, int> AJpcTypgrMIrtQSoFTgDfgwFGdNb;

		private bool lVOpvTBpnlcLRKzECvFmQfvyPSpdb;

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

		TValue IDictionary<TKey, TValue>.Item
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

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Item => default(TValue);

		int IReadOnlyList.Count => 0;

		object IReadOnlyList.Item => null;

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

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			return false;
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

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			return 0;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			return false;
		}

		private int BAqhqIlptXdxiVoQTgqZNhuheYtL(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BAqhqIlptXdxiVoQTgqZNhuheYtL
			return this.BAqhqIlptXdxiVoQTgqZNhuheYtL(P_0);
		}

		private bool IuAyVKNcfUjQJQOQTxbJHvPgUDop(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IuAyVKNcfUjQJQOQTxbJHvPgUDop
			return this.IuAyVKNcfUjQJQOQTxbJHvPgUDop(P_0);
		}
	}
}
