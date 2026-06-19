using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ADictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
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
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private ADictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			private int jLlbMmxSEOaHcwbQgTgmHIMPYPY;

			private int qFslVgpsJvzXCDAccmwaJAuNiAc;

			private KeyValuePair<TKey, TValue> bAihUPOaQoqOwOHZvtGkVuGzqqW;

			private int MkqSSDmzElYEEpIYUlurVUvnzay;

			public KeyValuePair<TKey, TValue> Current => bAihUPOaQoqOwOHZvtGkVuGzqqW;

			object IEnumerator.Current
			{
				get
				{
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1)
					{
						throw new Exception();
					}
					if (MkqSSDmzElYEEpIYUlurVUvnzay == 1)
					{
						return new DictionaryEntry(bAihUPOaQoqOwOHZvtGkVuGzqqW.Key, bAihUPOaQoqOwOHZvtGkVuGzqqW.Value);
					}
					return new KeyValuePair<TKey, TValue>(bAihUPOaQoqOwOHZvtGkVuGzqqW.Key, bAihUPOaQoqOwOHZvtGkVuGzqqW.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(bAihUPOaQoqOwOHZvtGkVuGzqqW.Key, bAihUPOaQoqOwOHZvtGkVuGzqqW.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1)
					{
						throw new Exception();
					}
					return bAihUPOaQoqOwOHZvtGkVuGzqqW.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1)
					{
						throw new Exception();
					}
					return bAihUPOaQoqOwOHZvtGkVuGzqqW.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
				jLlbMmxSEOaHcwbQgTgmHIMPYPY = dictionary.wxDwUInmywxWjbzUIARycmGyOtR;
				qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
				MkqSSDmzElYEEpIYUlurVUvnzay = getEnumeratorRetType;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.wxDwUInmywxWjbzUIARycmGyOtR)
				{
					throw new Exception();
				}
				while ((uint)qFslVgpsJvzXCDAccmwaJAuNiAc < (uint)JIrXlwvAsrFbMRDIqaqVCXOEeRm._count)
				{
					if (JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].hashCode >= 0)
					{
						bAihUPOaQoqOwOHZvtGkVuGzqqW = new KeyValuePair<TKey, TValue>(JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].key, JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].value);
						qFslVgpsJvzXCDAccmwaJAuNiAc++;
						return true;
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc++;
				}
				qFslVgpsJvzXCDAccmwaJAuNiAc = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.wxDwUInmywxWjbzUIARycmGyOtR)
				{
					throw new Exception();
				}
				qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private ADictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

				private int qFslVgpsJvzXCDAccmwaJAuNiAc;

				private int jLlbMmxSEOaHcwbQgTgmHIMPYPY;

				private TKey jzBAhDJaHZyUQGraGafRdFQdHHZH;

				public TKey Current => jzBAhDJaHZyUQGraGafRdFQdHHZH;

				object IEnumerator.Current
				{
					get
					{
						if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1)
						{
							throw new Exception();
						}
						return jzBAhDJaHZyUQGraGafRdFQdHHZH;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
					jLlbMmxSEOaHcwbQgTgmHIMPYPY = dictionary.wxDwUInmywxWjbzUIARycmGyOtR;
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					jzBAhDJaHZyUQGraGafRdFQdHHZH = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.wxDwUInmywxWjbzUIARycmGyOtR)
					{
						throw new Exception();
					}
					while ((uint)qFslVgpsJvzXCDAccmwaJAuNiAc < (uint)JIrXlwvAsrFbMRDIqaqVCXOEeRm._count)
					{
						if (JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].hashCode >= 0)
						{
							jzBAhDJaHZyUQGraGafRdFQdHHZH = JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].key;
							qFslVgpsJvzXCDAccmwaJAuNiAc++;
							return true;
						}
						qFslVgpsJvzXCDAccmwaJAuNiAc++;
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1;
					jzBAhDJaHZyUQGraGafRdFQdHHZH = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.wxDwUInmywxWjbzUIARycmGyOtR)
					{
						throw new Exception();
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					jzBAhDJaHZyUQGraGafRdFQdHHZH = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			public int Count => JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)JIrXlwvAsrFbMRDIqaqVCXOEeRm).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(JIrXlwvAsrFbMRDIqaqVCXOEeRm);
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
				if (array.Length - index < JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count)
				{
					throw new Exception();
				}
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count;
				Entry[] entries = JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			void ICollection<TKey>.Add(TKey item)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Contains(TKey item)
			{
				return JIrXlwvAsrFbMRDIqaqVCXOEeRm.ContainsKey(item);
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(JIrXlwvAsrFbMRDIqaqVCXOEeRm);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(JIrXlwvAsrFbMRDIqaqVCXOEeRm);
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
				if (array.Length - index < JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count)
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
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count;
				Entry[] entries = JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries;
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
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private ADictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

				private int qFslVgpsJvzXCDAccmwaJAuNiAc;

				private int jLlbMmxSEOaHcwbQgTgmHIMPYPY;

				private TValue wXFvQoZfQTinaPLLZsHFlBFjEwGa;

				public TValue Current => wXFvQoZfQTinaPLLZsHFlBFjEwGa;

				object IEnumerator.Current
				{
					get
					{
						if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1)
						{
							throw new Exception();
						}
						return wXFvQoZfQTinaPLLZsHFlBFjEwGa;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
					jLlbMmxSEOaHcwbQgTgmHIMPYPY = dictionary.wxDwUInmywxWjbzUIARycmGyOtR;
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					wXFvQoZfQTinaPLLZsHFlBFjEwGa = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.wxDwUInmywxWjbzUIARycmGyOtR)
					{
						throw new Exception();
					}
					while ((uint)qFslVgpsJvzXCDAccmwaJAuNiAc < (uint)JIrXlwvAsrFbMRDIqaqVCXOEeRm._count)
					{
						if (JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].hashCode >= 0)
						{
							wXFvQoZfQTinaPLLZsHFlBFjEwGa = JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries[qFslVgpsJvzXCDAccmwaJAuNiAc].value;
							qFslVgpsJvzXCDAccmwaJAuNiAc++;
							return true;
						}
						qFslVgpsJvzXCDAccmwaJAuNiAc++;
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count + 1;
					wXFvQoZfQTinaPLLZsHFlBFjEwGa = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.wxDwUInmywxWjbzUIARycmGyOtR)
					{
						throw new Exception();
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					wXFvQoZfQTinaPLLZsHFlBFjEwGa = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			public int Count => JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)JIrXlwvAsrFbMRDIqaqVCXOEeRm).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(JIrXlwvAsrFbMRDIqaqVCXOEeRm);
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
				if (array.Length - index < JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count)
				{
					throw new Exception();
				}
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count;
				Entry[] entries = JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			void ICollection<TValue>.Add(TValue item)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue item)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Contains(TValue item)
			{
				return JIrXlwvAsrFbMRDIqaqVCXOEeRm.ContainsValue(item);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(JIrXlwvAsrFbMRDIqaqVCXOEeRm);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(JIrXlwvAsrFbMRDIqaqVCXOEeRm);
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
				if (array.Length - index < JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count)
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
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm._count;
				Entry[] entries = JIrXlwvAsrFbMRDIqaqVCXOEeRm._entries;
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

		private const string yPybDSesJasVymFuEEYzNRZlnbwH = "Version";

		private const string wZtHuROpskDAoBopgxznhjuHKWzQ = "HashSize";

		private const string sWwQDIiGUJabPRSbzozkWTwmVUv = "KeyValuePairs";

		private const string culpPFzbwVvmLqAjbzfaeZUJLxD = "Comparer";

		private int[] qHbzIQXievfeMWCigKouyIyZEngb;

		internal Entry[] _entries;

		internal int _count;

		private int wxDwUInmywxWjbzUIARycmGyOtR;

		private int sXiqANzctgdkxjsNRlAWdjvKEliC;

		private int BPKTqXCvRaMpPXweaHiNnMOEeKw;

		private int TgXhrIfbMNDqzMCIstWAifFBEUVA;

		private IEqualityComparer<TKey> OxgNvdYEdHotNNfUNdNAIkbPTZLq;

		private IEqualityComparer<TValue> gpfARPeueLxrsziJKiOFpzqsHhv;

		private KeyCollection DweVMBpPPXSyWlIhmDaVoAakIIp;

		private ValueCollection cGuwlHOGRinWrMccSxezoCQuzuz;

		private readonly object lRwArgfgKziwkpmDNUWAWEraLIK = new object();

		private static readonly bool IxSIxGAJoIgMRSndXRsTiLpUNg = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool okVhhDWgsopIHjpgFrFHnRvInjO = ReflectionTools.IsValueType(typeof(TValue));

		public int Count => _count - TgXhrIfbMNDqzMCIstWAifFBEUVA;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (DweVMBpPPXSyWlIhmDaVoAakIIp == null)
				{
					DweVMBpPPXSyWlIhmDaVoAakIIp = new KeyCollection(this);
				}
				return DweVMBpPPXSyWlIhmDaVoAakIIp;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (cGuwlHOGRinWrMccSxezoCQuzuz == null)
				{
					cGuwlHOGRinWrMccSxezoCQuzuz = new ValueCollection(this);
				}
				return cGuwlHOGRinWrMccSxezoCQuzuz;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return OxgNvdYEdHotNNfUNdNAIkbPTZLq;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				OxgNvdYEdHotNNfUNdNAIkbPTZLq = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return gpfARPeueLxrsziJKiOFpzqsHhv;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				gpfARPeueLxrsziJKiOFpzqsHhv = value;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					throw new KeyNotFoundException(string.Concat("Key \"", key, " does not exist."));
				}
				return _entries[num].value;
			}
			set
			{
				stsEcOFAlVcZfJjvxmgdoHbmbaDK(key, value, false);
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
				if (DweVMBpPPXSyWlIhmDaVoAakIIp == null)
				{
					DweVMBpPPXSyWlIhmDaVoAakIIp = new KeyCollection(this);
				}
				return DweVMBpPPXSyWlIhmDaVoAakIIp;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (cGuwlHOGRinWrMccSxezoCQuzuz == null)
				{
					cGuwlHOGRinWrMccSxezoCQuzuz = new ValueCollection(this);
				}
				return cGuwlHOGRinWrMccSxezoCQuzuz;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => lRwArgfgKziwkpmDNUWAWEraLIK;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (JSLTmtYkNiIpgvqzExrEFsUKXWr(key))
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
				PxbLSxqWetKDfpWZZyEsuaWxTv<TValue>(value, "value");
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

		public ADictionary(IEqualityComparer<TKey> keyComparer)
			: this(0, keyComparer, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: this(0, keyComparer, valueComparer)
		{
		}

		public ADictionary(int capacity)
			: this(capacity, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int capacity, IEqualityComparer<TKey> keyComparer)
			: this(capacity, keyComparer, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int capacity, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (capacity > 0)
			{
				EJpmrTgGvrhKjJnkpXbomYBpQTQ(capacity);
			}
			OxgNvdYEdHotNNfUNdNAIkbPTZLq = keyComparer ?? EqualityComparerNoAlloc<TKey>.Default;
			gpfARPeueLxrsziJKiOFpzqsHhv = valueComparer ?? EqualityComparerNoAlloc<TValue>.Default;
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer)
			: this(dictionary, keyComparer, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: this(dictionary?.Count ?? 0, keyComparer)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			stsEcOFAlVcZfJjvxmgdoHbmbaDK(key, value, true);
		}

		public void Clear()
		{
			if (_count > 0)
			{
				for (int i = 0; i < qHbzIQXievfeMWCigKouyIyZEngb.Length; i++)
				{
					qHbzIQXievfeMWCigKouyIyZEngb[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				BPKTqXCvRaMpPXweaHiNnMOEeKw = -1;
				_count = 0;
				TgXhrIfbMNDqzMCIstWAifFBEUVA = 0;
				wxDwUInmywxWjbzUIARycmGyOtR++;
				sXiqANzctgdkxjsNRlAWdjvKEliC++;
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
			if (!IxSIxGAJoIgMRSndXRsTiLpUNg && object.ReferenceEquals(key, null))
			{
				throw new ArgumentNullException("key");
			}
			if (qHbzIQXievfeMWCigKouyIyZEngb != null)
			{
				int num = OxgNvdYEdHotNNfUNdNAIkbPTZLq.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % qHbzIQXievfeMWCigKouyIyZEngb.Length;
				int num3 = -1;
				for (int num4 = qHbzIQXievfeMWCigKouyIyZEngb[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && OxgNvdYEdHotNNfUNdNAIkbPTZLq.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							qHbzIQXievfeMWCigKouyIyZEngb[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = BPKTqXCvRaMpPXweaHiNnMOEeKw;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						BPKTqXCvRaMpPXweaHiNnMOEeKw = num4;
						TgXhrIfbMNDqzMCIstWAifFBEUVA++;
						wxDwUInmywxWjbzUIARycmGyOtR++;
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
			if (!IxSIxGAJoIgMRSndXRsTiLpUNg && object.ReferenceEquals(key, null))
			{
				throw new ArgumentNullException("key");
			}
			if (qHbzIQXievfeMWCigKouyIyZEngb != null)
			{
				int num = OxgNvdYEdHotNNfUNdNAIkbPTZLq.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = qHbzIQXievfeMWCigKouyIyZEngb[num % qHbzIQXievfeMWCigKouyIyZEngb.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && OxgNvdYEdHotNNfUNdNAIkbPTZLq.Equals(_entries[num2].key, key))
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
			if (!okVhhDWgsopIHjpgFrFHnRvInjO && value == null)
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
				IEqualityComparer<TValue> equalityComparer = gpfARPeueLxrsziJKiOFpzqsHhv;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && equalityComparer.Equals(entries[j].value, value))
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

		private void prmCPcknIVfYrNjUfjqmFhAyjNCb(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (P_1 < 0 || P_1 > P_0.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (P_0.Length - P_1 < Count)
			{
				throw new Exception();
			}
			int count = _count;
			Entry[] entries = _entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					ref KeyValuePair<TKey, TValue> reference = ref P_0[P_1++];
					reference = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
				}
			}
		}

		private void EJpmrTgGvrhKjJnkpXbomYBpQTQ(int P_0)
		{
			int num = MfOkIwKLdjqDmNVRvmwbiHbUBmV.zmzFyRHrXkOTzhlXhavWEhFcksx(P_0);
			qHbzIQXievfeMWCigKouyIyZEngb = new int[num];
			for (int i = 0; i < qHbzIQXievfeMWCigKouyIyZEngb.Length; i++)
			{
				qHbzIQXievfeMWCigKouyIyZEngb[i] = -1;
			}
			_entries = new Entry[num];
			BPKTqXCvRaMpPXweaHiNnMOEeKw = -1;
		}

		private void stsEcOFAlVcZfJjvxmgdoHbmbaDK(TKey P_0, TValue P_1, bool P_2)
		{
			if (!IxSIxGAJoIgMRSndXRsTiLpUNg && object.ReferenceEquals(P_0, null))
			{
				throw new ArgumentNullException("key");
			}
			if (qHbzIQXievfeMWCigKouyIyZEngb == null)
			{
				EJpmrTgGvrhKjJnkpXbomYBpQTQ(0);
			}
			int num = OxgNvdYEdHotNNfUNdNAIkbPTZLq.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % qHbzIQXievfeMWCigKouyIyZEngb.Length;
			for (int num3 = qHbzIQXievfeMWCigKouyIyZEngb[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && OxgNvdYEdHotNNfUNdNAIkbPTZLq.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					wxDwUInmywxWjbzUIARycmGyOtR++;
					return;
				}
			}
			int num4;
			if (TgXhrIfbMNDqzMCIstWAifFBEUVA > 0)
			{
				num4 = BPKTqXCvRaMpPXweaHiNnMOEeKw;
				BPKTqXCvRaMpPXweaHiNnMOEeKw = _entries[num4].next;
				TgXhrIfbMNDqzMCIstWAifFBEUVA--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					AuvmjaZdaBCIGYAAWdUBnVbZKRw();
					num2 = num % qHbzIQXievfeMWCigKouyIyZEngb.Length;
				}
				num4 = _count;
				_count++;
			}
			_entries[num4].hashCode = num;
			_entries[num4].next = qHbzIQXievfeMWCigKouyIyZEngb[num2];
			_entries[num4].key = P_0;
			_entries[num4].value = P_1;
			qHbzIQXievfeMWCigKouyIyZEngb[num2] = num4;
			wxDwUInmywxWjbzUIARycmGyOtR++;
			sXiqANzctgdkxjsNRlAWdjvKEliC++;
		}

		private void AuvmjaZdaBCIGYAAWdUBnVbZKRw()
		{
			AuvmjaZdaBCIGYAAWdUBnVbZKRw(MfOkIwKLdjqDmNVRvmwbiHbUBmV.ZOMFVOCbycivCsoMteOoHWhpZpLr(_count), false);
		}

		private void AuvmjaZdaBCIGYAAWdUBnVbZKRw(int P_0, bool P_1)
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
						array2[j].hashCode = OxgNvdYEdHotNNfUNdNAIkbPTZLq.GetHashCode(array2[j].key) & 0x7FFFFFFF;
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
			qHbzIQXievfeMWCigKouyIyZEngb = array;
			_entries = array2;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			Add(keyValuePair.Key, keyValuePair.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = IndexOfKey(keyValuePair.Key);
			if (num >= 0 && gpfARPeueLxrsziJKiOFpzqsHhv.Equals(_entries[num].value, keyValuePair.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = IndexOfKey(keyValuePair.Key);
			if (num >= 0 && gpfARPeueLxrsziJKiOFpzqsHhv.Equals(_entries[num].value, keyValuePair.Value))
			{
				Remove(keyValuePair.Key);
				return true;
			}
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			prmCPcknIVfYrNjUfjqmFhAyjNCb(array, index);
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
				prmCPcknIVfYrNjUfjqmFhAyjNCb(array2, index);
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
						ref DictionaryEntry reference = ref array3[index++];
						reference = new DictionaryEntry(entries[i].key, entries[i].value);
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
			PxbLSxqWetKDfpWZZyEsuaWxTv<TValue>(value, "value");
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
			if (JSLTmtYkNiIpgvqzExrEFsUKXWr(key))
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
			if (JSLTmtYkNiIpgvqzExrEFsUKXWr(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool JSLTmtYkNiIpgvqzExrEFsUKXWr(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void PxbLSxqWetKDfpWZZyEsuaWxTv<T>(object P_0, string P_1)
		{
			if (P_0 == null && default(T) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
