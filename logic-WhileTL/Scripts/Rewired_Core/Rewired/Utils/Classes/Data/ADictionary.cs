using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ADictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
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
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

			private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

			private int OVaNqsFEyODDjJdeKwblTptrPuEz;

			private KeyValuePair<TKey, TValue> FzeFBTyCrPwRSotVRRvPtdRXkqzA;

			private int oawkFEQJtASadJukuuXqlGvZvVOm;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => FzeFBTyCrPwRSotVRRvPtdRXkqzA;

			object IEnumerator.Current
			{
				get
				{
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1)
					{
						throw new Exception();
					}
					if (oawkFEQJtASadJukuuXqlGvZvVOm == 1)
					{
						return new DictionaryEntry(FzeFBTyCrPwRSotVRRvPtdRXkqzA.Key, FzeFBTyCrPwRSotVRRvPtdRXkqzA.Value);
					}
					return new KeyValuePair<TKey, TValue>(FzeFBTyCrPwRSotVRRvPtdRXkqzA.Key, FzeFBTyCrPwRSotVRRvPtdRXkqzA.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(FzeFBTyCrPwRSotVRRvPtdRXkqzA.Key, FzeFBTyCrPwRSotVRRvPtdRXkqzA.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1)
					{
						throw new Exception();
					}
					return FzeFBTyCrPwRSotVRRvPtdRXkqzA.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1)
					{
						throw new Exception();
					}
					return FzeFBTyCrPwRSotVRRvPtdRXkqzA.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
				ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = P_0.CNDFoUJoeZozIXLwyWmfCLhOpTpJ;
				OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
				oawkFEQJtASadJukuuXqlGvZvVOm = P_1;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
				{
					throw new Exception();
				}
				while ((uint)OVaNqsFEyODDjJdeKwblTptrPuEz < (uint)rqzlMgBEqYlprpsgKizQkexqOZQq._count)
				{
					if (rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].hashCode >= 0)
					{
						FzeFBTyCrPwRSotVRRvPtdRXkqzA = new KeyValuePair<TKey, TValue>(rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].key, rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].value);
						OVaNqsFEyODDjJdeKwblTptrPuEz++;
						return true;
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz++;
				}
				OVaNqsFEyODDjJdeKwblTptrPuEz = rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
				{
					throw new Exception();
				}
				OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : IEnumerable, IEnumerable<TKey>, ICollection, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TKey NCXBcBSNFcTabgxIwVeWlKzPsDno;

				public TKey Current => NCXBcBSNFcTabgxIwVeWlKzPsDno;

				object IEnumerator.Current
				{
					get
					{
						if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1)
						{
							throw new Exception();
						}
						return NCXBcBSNFcTabgxIwVeWlKzPsDno;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
					ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = P_0.CNDFoUJoeZozIXLwyWmfCLhOpTpJ;
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
					{
						throw new Exception();
					}
					while ((uint)OVaNqsFEyODDjJdeKwblTptrPuEz < (uint)rqzlMgBEqYlprpsgKizQkexqOZQq._count)
					{
						if (rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].hashCode >= 0)
						{
							NCXBcBSNFcTabgxIwVeWlKzPsDno = rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].key;
							OVaNqsFEyODDjJdeKwblTptrPuEz++;
							return true;
						}
						OVaNqsFEyODDjJdeKwblTptrPuEz++;
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
					{
						throw new Exception();
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

			public int Count => rqzlMgBEqYlprpsgKizQkexqOZQq.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)rqzlMgBEqYlprpsgKizQkexqOZQq).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(rqzlMgBEqYlprpsgKizQkexqOZQq);
			}

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (array.Length - index < rqzlMgBEqYlprpsgKizQkexqOZQq.Count)
				{
					throw new Exception();
				}
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq._count;
				Entry[] entries = rqzlMgBEqYlprpsgKizQkexqOZQq._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				return rqzlMgBEqYlprpsgKizQkexqOZQq.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(rqzlMgBEqYlprpsgKizQkexqOZQq);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(rqzlMgBEqYlprpsgKizQkexqOZQq);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < rqzlMgBEqYlprpsgKizQkexqOZQq.Count)
				{
					throw new Exception();
				}
				if (array is TKey[] array2)
				{
					CopyTo(array2, index);
					return;
				}
				if (!(array is object[] array3))
				{
					throw new Exception();
				}
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq._count;
				Entry[] entries = rqzlMgBEqYlprpsgKizQkexqOZQq._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].key;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TValue WgXGmgexMaKHPzrdvXYODgkBpyoT;

				public TValue Current => WgXGmgexMaKHPzrdvXYODgkBpyoT;

				object IEnumerator.Current
				{
					get
					{
						if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1)
						{
							throw new Exception();
						}
						return WgXGmgexMaKHPzrdvXYODgkBpyoT;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
					ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = P_0.CNDFoUJoeZozIXLwyWmfCLhOpTpJ;
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
					{
						throw new Exception();
					}
					while ((uint)OVaNqsFEyODDjJdeKwblTptrPuEz < (uint)rqzlMgBEqYlprpsgKizQkexqOZQq._count)
					{
						if (rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].hashCode >= 0)
						{
							WgXGmgexMaKHPzrdvXYODgkBpyoT = rqzlMgBEqYlprpsgKizQkexqOZQq._entries[OVaNqsFEyODDjJdeKwblTptrPuEz].value;
							OVaNqsFEyODDjJdeKwblTptrPuEz++;
							return true;
						}
						OVaNqsFEyODDjJdeKwblTptrPuEz++;
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = rqzlMgBEqYlprpsgKizQkexqOZQq._count + 1;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
					{
						throw new Exception();
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

			public int Count => rqzlMgBEqYlprpsgKizQkexqOZQq.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)rqzlMgBEqYlprpsgKizQkexqOZQq).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(rqzlMgBEqYlprpsgKizQkexqOZQq);
			}

			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < rqzlMgBEqYlprpsgKizQkexqOZQq.Count)
				{
					throw new Exception();
				}
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq._count;
				Entry[] entries = rqzlMgBEqYlprpsgKizQkexqOZQq._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				return rqzlMgBEqYlprpsgKizQkexqOZQq.ContainsValue(P_0);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(rqzlMgBEqYlprpsgKizQkexqOZQq);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(rqzlMgBEqYlprpsgKizQkexqOZQq);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < rqzlMgBEqYlprpsgKizQkexqOZQq.Count)
				{
					throw new Exception();
				}
				if (array is TValue[] array2)
				{
					CopyTo(array2, index);
					return;
				}
				if (!(array is object[] array3))
				{
					throw new Exception();
				}
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq._count;
				Entry[] entries = rqzlMgBEqYlprpsgKizQkexqOZQq._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].value;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
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

		private readonly object RMeCNmGPKKFWHvRprhLLNwMGEUsJA = new object();

		private static readonly bool cxbjJKonGVqunvFiXgKltFLZeWGhA = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool WNZmPPmomPckHPIvbQCHROzgxsAB = ReflectionTools.IsValueType(typeof(TValue));

		private const string WLqCGKEoDHYdTpCYoBDkCpgLNzGyA = "Version";

		private const string YJxlHxicmXyDOCDfYuccZHDfIGHE = "HashSize";

		private const string UKwEPUCrUkOYkbhsFNjncPuYFJyGA = "KeyValuePairs";

		private const string MfdAfVPCgiCOySgNRFwbAkxzutbo = "Comparer";

		public int Count => _count - rwFCyEfTEaKOWGkgIALJGMoQrQveB;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (freVGZZoLcUutVigWPIUYOXCaOFo == null)
				{
					freVGZZoLcUutVigWPIUYOXCaOFo = new KeyCollection(this);
				}
				return freVGZZoLcUutVigWPIUYOXCaOFo;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (WcsSbDkbQXyTAgdKmuecERjWzjVW == null)
				{
					WcsSbDkbQXyTAgdKmuecERjWzjVW = new ValueCollection(this);
				}
				return WcsSbDkbQXyTAgdKmuecERjWzjVW;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return imceZluvEaPVivwVpYaTCMKfDLje;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				imceZluvEaPVivwVpYaTCMKfDLje = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return WYbeMBDIqctHZSJzkTTMpJDAVxPIA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				WYbeMBDIqctHZSJzkTTMpJDAVxPIA = value;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					TKey val = key;
					throw new KeyNotFoundException("Key \"" + val?.ToString() + " does not exist.");
				}
				return _entries[num].value;
			}
			set
			{
				QheURIfNjcSfOlMXZfzaIDWOcarBA(key, value, false);
			}
		}

		public int IndexOfFirst
		{
			get
			{
				for (int i = 0; i < _count; i++)
				{
					if (_entries[i].hashCode >= 0)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public int IndexOfLast
		{
			get
			{
				for (int num = _count - 1; num >= 0; num--)
				{
					if (_entries[num].hashCode >= 0)
					{
						return num;
					}
				}
				return -1;
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				if (freVGZZoLcUutVigWPIUYOXCaOFo == null)
				{
					freVGZZoLcUutVigWPIUYOXCaOFo = new KeyCollection(this);
				}
				return freVGZZoLcUutVigWPIUYOXCaOFo;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (WcsSbDkbQXyTAgdKmuecERjWzjVW == null)
				{
					WcsSbDkbQXyTAgdKmuecERjWzjVW = new ValueCollection(this);
				}
				return WcsSbDkbQXyTAgdKmuecERjWzjVW;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => RMeCNmGPKKFWHvRprhLLNwMGEUsJA;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (xKLlArkEJVZwLFeBeHsLjXzqTSBn(key))
				{
					int num = IndexOfKey((TKey)key);
					if (num >= 0)
					{
						return _entries[num].value;
					}
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				xEdKIECfSRyiwDswvidVMpNmkPXo<TValue>(value, "value");
				try
				{
					TKey key2 = (TKey)key;
					try
					{
						this[key2] = (TValue)value;
					}
					catch (InvalidCastException)
					{
						throw new Exception();
					}
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
		}

		public ADictionary()
			: this(0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0)
			: this(0, P_0, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0, IEqualityComparer<TValue> P_1)
			: this(0, P_0, P_1)
		{
		}

		public ADictionary(int P_0)
			: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1)
			: this(P_0, P_1, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
		{
			if (P_0 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (P_0 > 0)
			{
				gUxczTgMdKUcYRnCXamteWaCXJodc(P_0);
			}
			imceZluvEaPVivwVpYaTCMKfDLje = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			WYbeMBDIqctHZSJzkTTMpJDAVxPIA = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
		}

		public ADictionary(IDictionary<TKey, TValue> P_0)
			: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1)
			: this(P_0, P_1, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
			: this(P_0?.Count ?? 0, P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> item in P_0)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			QheURIfNjcSfOlMXZfzaIDWOcarBA(key, value, true);
		}

		public void Clear()
		{
			if (_count > 0)
			{
				for (int i = 0; i < GRjPmMpxcKcHngQAGprpQcXdYjEv.Length; i++)
				{
					GRjPmMpxcKcHngQAGprpQcXdYjEv[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				lMKGAZFeLRKyiprYSrSAuZhwEkOrA = -1;
				_count = 0;
				rwFCyEfTEaKOWGkgIALJGMoQrQveB = 0;
				CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
				QAqXlPLjKPIJQUtilFIVNMykdEAe++;
			}
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOfKey(key) >= 0;
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		public bool Remove(TKey key)
		{
			if (!cxbjJKonGVqunvFiXgKltFLZeWGhA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (GRjPmMpxcKcHngQAGprpQcXdYjEv != null)
			{
				int num = imceZluvEaPVivwVpYaTCMKfDLje.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % GRjPmMpxcKcHngQAGprpQcXdYjEv.Length;
				int num3 = -1;
				for (int num4 = GRjPmMpxcKcHngQAGprpQcXdYjEv[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && imceZluvEaPVivwVpYaTCMKfDLje.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							GRjPmMpxcKcHngQAGprpQcXdYjEv[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = lMKGAZFeLRKyiprYSrSAuZhwEkOrA;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						lMKGAZFeLRKyiprYSrSAuZhwEkOrA = num4;
						rwFCyEfTEaKOWGkgIALJGMoQrQveB++;
						CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
						return true;
					}
					num3 = num4;
				}
			}
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				value = _entries[num].value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		public TValue GetValueSafe(TKey key)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				return _entries[num].value;
			}
			return default(TValue);
		}

		public int IndexOfKey(TKey key)
		{
			if (!cxbjJKonGVqunvFiXgKltFLZeWGhA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (GRjPmMpxcKcHngQAGprpQcXdYjEv != null)
			{
				int num = imceZluvEaPVivwVpYaTCMKfDLje.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = GRjPmMpxcKcHngQAGprpQcXdYjEv[num % GRjPmMpxcKcHngQAGprpQcXdYjEv.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && imceZluvEaPVivwVpYaTCMKfDLje.Equals(_entries[num2].key, key))
					{
						return num2;
					}
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			Entry[] entries = _entries;
			if (!WNZmPPmomPckHPIvbQCHROzgxsAB && value == null)
			{
				for (int i = 0; i < _count; i++)
				{
					if (entries[i].hashCode >= 0 && entries[i].value == null)
					{
						return i;
					}
				}
			}
			else
			{
				IEqualityComparer<TValue> wYbeMBDIqctHZSJzkTTMpJDAVxPIA = WYbeMBDIqctHZSJzkTTMpJDAVxPIA;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && wYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(entries[j].value, value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		public bool IsValidAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			return _entries[index].hashCode >= 0;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return _entries[index].key;
		}

		public TValue GetValueAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return _entries[index].value;
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
		}

		public bool TryGetKeyAt(int index, out TKey key)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				key = default(TKey);
				return false;
			}
			key = _entries[index].key;
			return true;
		}

		public bool TryGetValueAt(int index, out TValue value)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				value = default(TValue);
				return false;
			}
			value = _entries[index].value;
			return true;
		}

		public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
			return true;
		}

		public bool GetNextIndex(ref int index)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					return true;
				}
				index++;
			}
			return false;
		}

		public int GetNextIndex(int index)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				return -1;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		public bool GetNextKey(ref int index, out TKey key)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				key = default(TKey);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					key = _entries[index].key;
					return true;
				}
				index++;
			}
			key = default(TKey);
			return false;
		}

		public bool GetNextValue(ref int index, out TValue value)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				index++;
			}
			value = default(TValue);
			return false;
		}

		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					return true;
				}
				index++;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetPreviousIndex(ref int index)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					return true;
				}
				index--;
			}
			return false;
		}

		public int GetPreviousIndex(int index)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				return -1;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					return index;
				}
				index--;
			}
			return -1;
		}

		public bool GetPreviousKey(ref int index, out TKey key)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				key = default(TKey);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					key = _entries[index].key;
					return true;
				}
				index--;
			}
			key = default(TKey);
			return false;
		}

		public bool GetPreviousValue(ref int index, out TValue value)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				index--;
			}
			value = default(TValue);
			return false;
		}

		public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					return true;
				}
				index--;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool RemoveAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				return false;
			}
			Remove(_entries[index].key);
			return true;
		}

		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < Count)
			{
				throw new Exception();
			}
			int count = _count;
			Entry[] entries = _entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array[index++] = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
				}
			}
		}

		private void gUxczTgMdKUcYRnCXamteWaCXJodc(int P_0)
		{
			int num = mBIXidehYIjLbvtFXjheYIRokVnD.BQhTMFbLLHYsAZOvHfxVmJiAvuXp(P_0);
			GRjPmMpxcKcHngQAGprpQcXdYjEv = new int[num];
			for (int i = 0; i < GRjPmMpxcKcHngQAGprpQcXdYjEv.Length; i++)
			{
				GRjPmMpxcKcHngQAGprpQcXdYjEv[i] = -1;
			}
			_entries = new Entry[num];
			lMKGAZFeLRKyiprYSrSAuZhwEkOrA = -1;
		}

		private void QheURIfNjcSfOlMXZfzaIDWOcarBA(TKey P_0, TValue P_1, bool P_2)
		{
			if (!cxbjJKonGVqunvFiXgKltFLZeWGhA && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (GRjPmMpxcKcHngQAGprpQcXdYjEv == null)
			{
				gUxczTgMdKUcYRnCXamteWaCXJodc(0);
			}
			int num = imceZluvEaPVivwVpYaTCMKfDLje.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % GRjPmMpxcKcHngQAGprpQcXdYjEv.Length;
			for (int num3 = GRjPmMpxcKcHngQAGprpQcXdYjEv[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && imceZluvEaPVivwVpYaTCMKfDLje.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
					return;
				}
			}
			int count;
			if (rwFCyEfTEaKOWGkgIALJGMoQrQveB > 0)
			{
				count = lMKGAZFeLRKyiprYSrSAuZhwEkOrA;
				lMKGAZFeLRKyiprYSrSAuZhwEkOrA = _entries[count].next;
				rwFCyEfTEaKOWGkgIALJGMoQrQveB--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					cizKfixQyiMsziIsefTUZmGlIPQY();
					num2 = num % GRjPmMpxcKcHngQAGprpQcXdYjEv.Length;
				}
				count = _count;
				_count++;
			}
			_entries[count].hashCode = num;
			_entries[count].next = GRjPmMpxcKcHngQAGprpQcXdYjEv[num2];
			_entries[count].key = P_0;
			_entries[count].value = P_1;
			GRjPmMpxcKcHngQAGprpQcXdYjEv[num2] = count;
			CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
			QAqXlPLjKPIJQUtilFIVNMykdEAe++;
		}

		private void cizKfixQyiMsziIsefTUZmGlIPQY()
		{
			cizKfixQyiMsziIsefTUZmGlIPQY(mBIXidehYIjLbvtFXjheYIRokVnD.baOFQYEimXhVzAWiPUJbHiMRWzxZA(_count), false);
		}

		private void cizKfixQyiMsziIsefTUZmGlIPQY(int P_0, bool P_1)
		{
			int[] array = new int[P_0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			Entry[] array2 = new Entry[P_0];
			Array.Copy(_entries, 0, array2, 0, _count);
			if (P_1)
			{
				for (int j = 0; j < _count; j++)
				{
					if (array2[j].hashCode != -1)
					{
						array2[j].hashCode = imceZluvEaPVivwVpYaTCMKfDLje.GetHashCode(array2[j].key) & 0x7FFFFFFF;
					}
				}
			}
			for (int k = 0; k < _count; k++)
			{
				if (array2[k].hashCode >= 0)
				{
					int num = array2[k].hashCode % P_0;
					array2[k].next = array[num];
					array[num] = k;
				}
			}
			GRjPmMpxcKcHngQAGprpQcXdYjEv = array;
			_entries = array2;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new Exception();
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new Exception();
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < Count)
			{
				throw new Exception();
			}
			if (array is KeyValuePair<TKey, TValue>[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (array is DictionaryEntry[])
			{
				DictionaryEntry[] array3 = array as DictionaryEntry[];
				Entry[] entries = _entries;
				for (int i = 0; i < _count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array3[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
					}
				}
				return;
			}
			if (!(array is object[] array4))
			{
				throw new Exception();
			}
			try
			{
				int count = _count;
				Entry[] entries2 = _entries;
				for (int j = 0; j < count; j++)
				{
					if (entries2[j].hashCode >= 0)
					{
						array4[index++] = new KeyValuePair<TKey, TValue>(entries2[j].key, entries2[j].value);
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			xEdKIECfSRyiwDswvidVMpNmkPXo<TValue>(value, "value");
			try
			{
				TKey key2 = (TKey)key;
				try
				{
					Add(key2, (TValue)value);
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
			catch (InvalidCastException)
			{
				throw new Exception();
			}
		}

		bool IDictionary.Contains(object key)
		{
			if (xKLlArkEJVZwLFeBeHsLjXzqTSBn(key))
			{
				return ContainsKey((TKey)key);
			}
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		void IDictionary.Remove(object key)
		{
			if (xKLlArkEJVZwLFeBeHsLjXzqTSBn(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool xKLlArkEJVZwLFeBeHsLjXzqTSBn(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void xEdKIECfSRyiwDswvidVMpNmkPXo<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
