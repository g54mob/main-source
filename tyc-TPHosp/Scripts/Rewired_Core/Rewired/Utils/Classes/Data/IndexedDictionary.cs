using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct IwiLoVsDJEmSvGXSPRiZDjTBkmn
		{
			public TKey DPVAvOYLwDuXkZartmSLvlLHnus;

			public TValue HpxePuhaScltgSCBmgsrsCpjliL;

			public IwiLoVsDJEmSvGXSPRiZDjTBkmn(TKey key, TValue value)
			{
				DPVAvOYLwDuXkZartmSLvlLHnus = key;
				HpxePuhaScltgSCBmgsrsCpjliL = value;
			}

			public KeyValuePair<TKey, TValue> RGllxZvoYHTACcnWXEyZxlVwMmK()
			{
				return new KeyValuePair<TKey, TValue>(DPVAvOYLwDuXkZartmSLvlLHnus, HpxePuhaScltgSCBmgsrsCpjliL);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			private int jLlbMmxSEOaHcwbQgTgmHIMPYPY;

			private int qFslVgpsJvzXCDAccmwaJAuNiAc;

			private KeyValuePair<TKey, TValue> bAihUPOaQoqOwOHZvtGkVuGzqqW;

			private int MkqSSDmzElYEEpIYUlurVUvnzay;

			public KeyValuePair<TKey, TValue> Current => bAihUPOaQoqOwOHZvtGkVuGzqqW;

			object IEnumerator.Current
			{
				get
				{
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1)
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
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1)
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
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1)
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
					if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1)
					{
						throw new Exception();
					}
					return bAihUPOaQoqOwOHZvtGkVuGzqqW.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
				jLlbMmxSEOaHcwbQgTgmHIMPYPY = dictionary.WGbffMyxRwMRJaYYpbgRACDXbfV.Version;
				qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
				MkqSSDmzElYEEpIYUlurVUvnzay = getEnumeratorRetType;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV.Version)
				{
					throw new Exception();
				}
				if ((uint)qFslVgpsJvzXCDAccmwaJAuNiAc < (uint)JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count)
				{
					bAihUPOaQoqOwOHZvtGkVuGzqqW = new KeyValuePair<TKey, TValue>(JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items[qFslVgpsJvzXCDAccmwaJAuNiAc].DPVAvOYLwDuXkZartmSLvlLHnus, JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items[qFslVgpsJvzXCDAccmwaJAuNiAc].HpxePuhaScltgSCBmgsrsCpjliL);
					qFslVgpsJvzXCDAccmwaJAuNiAc++;
					return true;
				}
				qFslVgpsJvzXCDAccmwaJAuNiAc = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV.Version)
				{
					throw new Exception();
				}
				qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private IndexedDictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

				private int qFslVgpsJvzXCDAccmwaJAuNiAc;

				private int jLlbMmxSEOaHcwbQgTgmHIMPYPY;

				private TKey jzBAhDJaHZyUQGraGafRdFQdHHZH;

				public TKey Current => jzBAhDJaHZyUQGraGafRdFQdHHZH;

				object IEnumerator.Current
				{
					get
					{
						if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1)
						{
							throw new Exception();
						}
						return jzBAhDJaHZyUQGraGafRdFQdHHZH;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
					jLlbMmxSEOaHcwbQgTgmHIMPYPY = dictionary.WGbffMyxRwMRJaYYpbgRACDXbfV.Version;
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					jzBAhDJaHZyUQGraGafRdFQdHHZH = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV.Version)
					{
						throw new Exception();
					}
					if ((uint)qFslVgpsJvzXCDAccmwaJAuNiAc < (uint)JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count)
					{
						jzBAhDJaHZyUQGraGafRdFQdHHZH = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items[qFslVgpsJvzXCDAccmwaJAuNiAc].DPVAvOYLwDuXkZartmSLvlLHnus;
						qFslVgpsJvzXCDAccmwaJAuNiAc++;
						return true;
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1;
					jzBAhDJaHZyUQGraGafRdFQdHHZH = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV.Version)
					{
						throw new Exception();
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					jzBAhDJaHZyUQGraGafRdFQdHHZH = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			public int Count => JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)JIrXlwvAsrFbMRDIqaqVCXOEeRm).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> dictionary)
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
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count;
				IwiLoVsDJEmSvGXSPRiZDjTBkmn[] items = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].DPVAvOYLwDuXkZartmSLvlLHnus;
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
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count;
				IwiLoVsDJEmSvGXSPRiZDjTBkmn[] items = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].DPVAvOYLwDuXkZartmSLvlLHnus;
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
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private IndexedDictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

				private int qFslVgpsJvzXCDAccmwaJAuNiAc;

				private int jLlbMmxSEOaHcwbQgTgmHIMPYPY;

				private TValue wXFvQoZfQTinaPLLZsHFlBFjEwGa;

				public TValue Current => wXFvQoZfQTinaPLLZsHFlBFjEwGa;

				object IEnumerator.Current
				{
					get
					{
						if (qFslVgpsJvzXCDAccmwaJAuNiAc == 0 || qFslVgpsJvzXCDAccmwaJAuNiAc == JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1)
						{
							throw new Exception();
						}
						return wXFvQoZfQTinaPLLZsHFlBFjEwGa;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					JIrXlwvAsrFbMRDIqaqVCXOEeRm = dictionary;
					jLlbMmxSEOaHcwbQgTgmHIMPYPY = dictionary.WGbffMyxRwMRJaYYpbgRACDXbfV.Version;
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					wXFvQoZfQTinaPLLZsHFlBFjEwGa = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV.Version)
					{
						throw new Exception();
					}
					if ((uint)qFslVgpsJvzXCDAccmwaJAuNiAc < (uint)JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count)
					{
						wXFvQoZfQTinaPLLZsHFlBFjEwGa = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items[qFslVgpsJvzXCDAccmwaJAuNiAc].HpxePuhaScltgSCBmgsrsCpjliL;
						qFslVgpsJvzXCDAccmwaJAuNiAc++;
						return true;
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count + 1;
					wXFvQoZfQTinaPLLZsHFlBFjEwGa = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (jLlbMmxSEOaHcwbQgTgmHIMPYPY != JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV.Version)
					{
						throw new Exception();
					}
					qFslVgpsJvzXCDAccmwaJAuNiAc = 0;
					wXFvQoZfQTinaPLLZsHFlBFjEwGa = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			public int Count => JIrXlwvAsrFbMRDIqaqVCXOEeRm.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)JIrXlwvAsrFbMRDIqaqVCXOEeRm).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> dictionary)
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
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count;
				IwiLoVsDJEmSvGXSPRiZDjTBkmn[] items = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].HpxePuhaScltgSCBmgsrsCpjliL;
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
				int count = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._count;
				IwiLoVsDJEmSvGXSPRiZDjTBkmn[] items = JIrXlwvAsrFbMRDIqaqVCXOEeRm.WGbffMyxRwMRJaYYpbgRACDXbfV._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].HpxePuhaScltgSCBmgsrsCpjliL;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool IxSIxGAJoIgMRSndXRsTiLpUNg = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool okVhhDWgsopIHjpgFrFHnRvInjO = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> OxgNvdYEdHotNNfUNdNAIkbPTZLq = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> gpfARPeueLxrsziJKiOFpzqsHhv = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<IwiLoVsDJEmSvGXSPRiZDjTBkmn> WGbffMyxRwMRJaYYpbgRACDXbfV;

		private readonly ADictionary<TKey, int> mylHxHRzwfNaIiqsbSKzJmVnbGBG;

		private bool NFOgFFfnuOtdiRikmSlrVsCYMiF;

		public int Count => WGbffMyxRwMRJaYYpbgRACDXbfV._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!NFOgFFfnuOtdiRikmSlrVsCYMiF)
				{
					return false;
				}
				return mylHxHRzwfNaIiqsbSKzJmVnbGBG._count < WGbffMyxRwMRJaYYpbgRACDXbfV._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return NFOgFFfnuOtdiRikmSlrVsCYMiF;
			}
			set
			{
				if (NFOgFFfnuOtdiRikmSlrVsCYMiF != value)
				{
					NFOgFFfnuOtdiRikmSlrVsCYMiF = value;
					if (!value && ContainsDuplicateKeys)
					{
						throw new Exception("The dictionary contains duplicate keys and cannot be changed unless the keys are removed.");
					}
				}
			}
		}

		public TValue this[int index]
		{
			get
			{
				if ((uint)index >= (uint)WGbffMyxRwMRJaYYpbgRACDXbfV._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return WGbffMyxRwMRJaYYpbgRACDXbfV._items[index].HpxePuhaScltgSCBmgsrsCpjliL;
			}
			set
			{
				if ((uint)index >= (uint)WGbffMyxRwMRJaYYpbgRACDXbfV._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				WGbffMyxRwMRJaYYpbgRACDXbfV._items[index].HpxePuhaScltgSCBmgsrsCpjliL = value;
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

		public ICollection<TKey> Keys => new KeyCollection(this);

		public ICollection<TValue> Values => new ValueCollection(this);

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					throw new KeyNotFoundException(string.Concat("Key \"", key, "\" does not exist."));
				}
				return WGbffMyxRwMRJaYYpbgRACDXbfV._items[num].HpxePuhaScltgSCBmgsrsCpjliL;
			}
			set
			{
				SetValue(key, value);
			}
		}

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => new KeyCollection(this);

		ICollection IDictionary.Values => new ValueCollection(this);

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary<TKey, TValue>)this)[(TKey)key];
			}
			set
			{
				((IDictionary<TKey, TValue>)this)[(TKey)key] = (TValue)value;
			}
		}

		bool ICollection.IsSynchronized => ((ICollection)WGbffMyxRwMRJaYYpbgRACDXbfV).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)WGbffMyxRwMRJaYYpbgRACDXbfV).SyncRoot;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int index] => this[index];

		int IReadOnlyList.Count => Count;

		object IReadOnlyList.this[int index] => this[index];

		public IndexedDictionary()
			: this(0, false)
		{
		}

		public IndexedDictionary(int capacity)
			: this(capacity, false)
		{
		}

		public IndexedDictionary(bool allowDuplicateKeys)
			: this(0, allowDuplicateKeys)
		{
		}

		public IndexedDictionary(int capacity, bool allowDuplicateKeys)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			NFOgFFfnuOtdiRikmSlrVsCYMiF = allowDuplicateKeys;
			WGbffMyxRwMRJaYYpbgRACDXbfV = new AList<IwiLoVsDJEmSvGXSPRiZDjTBkmn>(capacity);
			mylHxHRzwfNaIiqsbSKzJmVnbGBG = new ADictionary<TKey, int>(capacity);
		}

		public IndexedDictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, false)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> dictionary, bool allowDuplicateKeys)
			: this(0, allowDuplicateKeys)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (ReflectionTools.DoesTypeImplement(dictionary.GetType(), typeof(IndexedDictionary<TKey, TValue>)))
			{
				IndexedDictionary<TKey, TValue> indexedDictionary = (IndexedDictionary<TKey, TValue>)dictionary;
				for (int i = 0; i < indexedDictionary.WGbffMyxRwMRJaYYpbgRACDXbfV._count; i++)
				{
					Add(indexedDictionary.WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].DPVAvOYLwDuXkZartmSLvlLHnus, indexedDictionary.WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].HpxePuhaScltgSCBmgsrsCpjliL);
				}
				return;
			}
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
		}

		public TValue GetValue(TKey key)
		{
			return WGbffMyxRwMRJaYYpbgRACDXbfV._items[mylHxHRzwfNaIiqsbSKzJmVnbGBG[key]].HpxePuhaScltgSCBmgsrsCpjliL;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!mylHxHRzwfNaIiqsbSKzJmVnbGBG.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = WGbffMyxRwMRJaYYpbgRACDXbfV._items[value2].HpxePuhaScltgSCBmgsrsCpjliL;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)WGbffMyxRwMRJaYYpbgRACDXbfV._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return WGbffMyxRwMRJaYYpbgRACDXbfV[index].DPVAvOYLwDuXkZartmSLvlLHnus;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return WGbffMyxRwMRJaYYpbgRACDXbfV[mylHxHRzwfNaIiqsbSKzJmVnbGBG[key]].RGllxZvoYHTACcnWXEyZxlVwMmK();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)WGbffMyxRwMRJaYYpbgRACDXbfV._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return WGbffMyxRwMRJaYYpbgRACDXbfV[index].RGllxZvoYHTACcnWXEyZxlVwMmK();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!mylHxHRzwfNaIiqsbSKzJmVnbGBG.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = WGbffMyxRwMRJaYYpbgRACDXbfV[value].RGllxZvoYHTACcnWXEyZxlVwMmK();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool flag = mylHxHRzwfNaIiqsbSKzJmVnbGBG.ContainsKey(key);
			if (flag && !NFOgFFfnuOtdiRikmSlrVsCYMiF)
			{
				throw new ArgumentException(string.Concat("Key \"", key, "\" is already in use."));
			}
			int value2 = WGbffMyxRwMRJaYYpbgRACDXbfV.Add(new IwiLoVsDJEmSvGXSPRiZDjTBkmn(key, value));
			if (flag)
			{
				mylHxHRzwfNaIiqsbSKzJmVnbGBG[key] = value2;
			}
			else
			{
				mylHxHRzwfNaIiqsbSKzJmVnbGBG.Add(key, value2);
			}
		}

		public void SetValue(TKey key, TValue value)
		{
			if (mylHxHRzwfNaIiqsbSKzJmVnbGBG.TryGetValue(key, out var value2))
			{
				WGbffMyxRwMRJaYYpbgRACDXbfV._items[value2].HpxePuhaScltgSCBmgsrsCpjliL = value;
				mylHxHRzwfNaIiqsbSKzJmVnbGBG[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			mylHxHRzwfNaIiqsbSKzJmVnbGBG.Remove(key);
			if (NFOgFFfnuOtdiRikmSlrVsCYMiF)
			{
				bool result = false;
				for (int num = WGbffMyxRwMRJaYYpbgRACDXbfV._count - 1; num >= 0; num--)
				{
					if (OxgNvdYEdHotNNfUNdNAIkbPTZLq.Equals(WGbffMyxRwMRJaYYpbgRACDXbfV._items[num].DPVAvOYLwDuXkZartmSLvlLHnus, key))
					{
						WGbffMyxRwMRJaYYpbgRACDXbfV.RemoveAt(num);
						result = true;
					}
				}
				return result;
			}
			int num2 = IndexOfKey(key);
			if (num2 < 0)
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		public void RemoveAt(int index)
		{
			if ((uint)index >= (uint)WGbffMyxRwMRJaYYpbgRACDXbfV._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey dPVAvOYLwDuXkZartmSLvlLHnus = WGbffMyxRwMRJaYYpbgRACDXbfV._items[index].DPVAvOYLwDuXkZartmSLvlLHnus;
			if (index < WGbffMyxRwMRJaYYpbgRACDXbfV._count - 1)
			{
				for (int i = index + 1; i < WGbffMyxRwMRJaYYpbgRACDXbfV.Count; i++)
				{
					mylHxHRzwfNaIiqsbSKzJmVnbGBG[WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].DPVAvOYLwDuXkZartmSLvlLHnus] = i - 1;
				}
			}
			WGbffMyxRwMRJaYYpbgRACDXbfV.RemoveAt(index);
			mylHxHRzwfNaIiqsbSKzJmVnbGBG.Remove(dPVAvOYLwDuXkZartmSLvlLHnus);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = WGbffMyxRwMRJaYYpbgRACDXbfV._items[num].DPVAvOYLwDuXkZartmSLvlLHnus;
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			int count = WGbffMyxRwMRJaYYpbgRACDXbfV._count;
			for (int num2 = count - 1; num2 >= 0; num2--)
			{
				_ = WGbffMyxRwMRJaYYpbgRACDXbfV._items[num2].DPVAvOYLwDuXkZartmSLvlLHnus;
				if (gpfARPeueLxrsziJKiOFpzqsHhv.Equals(WGbffMyxRwMRJaYYpbgRACDXbfV._items[num2].HpxePuhaScltgSCBmgsrsCpjliL, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!IxSIxGAJoIgMRSndXRsTiLpUNg && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = WGbffMyxRwMRJaYYpbgRACDXbfV._count;
			for (int i = 0; i < count; i++)
			{
				if (OxgNvdYEdHotNNfUNdNAIkbPTZLq.Equals(WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].DPVAvOYLwDuXkZartmSLvlLHnus, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = WGbffMyxRwMRJaYYpbgRACDXbfV._count;
			for (int i = 0; i < count; i++)
			{
				if (gpfARPeueLxrsziJKiOFpzqsHhv.Equals(WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].HpxePuhaScltgSCBmgsrsCpjliL, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return mylHxHRzwfNaIiqsbSKzJmVnbGBG.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			WGbffMyxRwMRJaYYpbgRACDXbfV.Clear();
			mylHxHRzwfNaIiqsbSKzJmVnbGBG.Clear();
		}

		public void TrimExcess()
		{
			WGbffMyxRwMRJaYYpbgRACDXbfV.TrimExcess();
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			int num = IndexOfKey(item.Key);
			if (num < 0)
			{
				return false;
			}
			IwiLoVsDJEmSvGXSPRiZDjTBkmn iwiLoVsDJEmSvGXSPRiZDjTBkmn = WGbffMyxRwMRJaYYpbgRACDXbfV._items[num];
			return gpfARPeueLxrsziJKiOFpzqsHhv.Equals(item.Value, iwiLoVsDJEmSvGXSPRiZDjTBkmn.HpxePuhaScltgSCBmgsrsCpjliL);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
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
			int count = WGbffMyxRwMRJaYYpbgRACDXbfV._count;
			for (int i = 0; i < count; i++)
			{
				ref KeyValuePair<TKey, TValue> reference = ref array[index++];
				reference = new KeyValuePair<TKey, TValue>(WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].DPVAvOYLwDuXkZartmSLvlLHnus, WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].HpxePuhaScltgSCBmgsrsCpjliL);
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			if (NFOgFFfnuOtdiRikmSlrVsCYMiF)
			{
				bool result = false;
				for (int num = WGbffMyxRwMRJaYYpbgRACDXbfV._count - 1; num >= 0; num--)
				{
					IwiLoVsDJEmSvGXSPRiZDjTBkmn iwiLoVsDJEmSvGXSPRiZDjTBkmn = WGbffMyxRwMRJaYYpbgRACDXbfV._items[num];
					if (gpfARPeueLxrsziJKiOFpzqsHhv.Equals(item.Value, iwiLoVsDJEmSvGXSPRiZDjTBkmn.HpxePuhaScltgSCBmgsrsCpjliL))
					{
						WGbffMyxRwMRJaYYpbgRACDXbfV.RemoveAt(num);
						result = true;
					}
				}
				return result;
			}
			int num2 = IndexOfKey(item.Key);
			if (num2 < 0)
			{
				return false;
			}
			IwiLoVsDJEmSvGXSPRiZDjTBkmn iwiLoVsDJEmSvGXSPRiZDjTBkmn2 = WGbffMyxRwMRJaYYpbgRACDXbfV._items[num2];
			if (!gpfARPeueLxrsziJKiOFpzqsHhv.Equals(item.Value, iwiLoVsDJEmSvGXSPRiZDjTBkmn2.HpxePuhaScltgSCBmgsrsCpjliL))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		void IDictionary.Add(object key, object value)
		{
			Add((TKey)key, (TValue)value);
		}

		bool IDictionary.Contains(object key)
		{
			return ContainsKey((TKey)key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void IDictionary.Remove(object key)
		{
			Remove((TKey)key);
		}

		void ICollection.CopyTo(Array array, int index)
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
			int count = WGbffMyxRwMRJaYYpbgRACDXbfV._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].DPVAvOYLwDuXkZartmSLvlLHnus, WGbffMyxRwMRJaYYpbgRACDXbfV._items[i].HpxePuhaScltgSCBmgsrsCpjliL), index++);
			}
		}

		private int RSxcUnjCzGoXWZqoCHCzcjjYEmY(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RSxcUnjCzGoXWZqoCHCzcjjYEmY
			return this.RSxcUnjCzGoXWZqoCHCzcjjYEmY(P_0);
		}

		private bool axDRieyVZVLceJhruLbUHBdXarS(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in axDRieyVZVLceJhruLbUHBdXarS
			return this.axDRieyVZVLceJhruLbUHBdXarS(P_0);
		}

		private int fzmxMoNnmwRBbzstdxYGpZtTWLq(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fzmxMoNnmwRBbzstdxYGpZtTWLq
			return this.fzmxMoNnmwRBbzstdxYGpZtTWLq(P_0);
		}

		private bool skWClIhvtlVuycwmhBoWrteCjZST(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in skWClIhvtlVuycwmhBoWrteCjZST
			return this.skWClIhvtlVuycwmhBoWrteCjZST(P_0);
		}
	}
}
