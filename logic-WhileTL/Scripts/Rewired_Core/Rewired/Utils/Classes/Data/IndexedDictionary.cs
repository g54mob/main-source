using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct onwvlRAXvfuHAecwrrOKpDmxyjXF
		{
			public TKey xzRewGuNweXrZjgHBeZSFNenqiYrA;

			public TValue pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

			public onwvlRAXvfuHAecwrrOKpDmxyjXF(TKey P_0, TValue P_1)
			{
				xzRewGuNweXrZjgHBeZSFNenqiYrA = P_0;
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = P_1;
			}

			public KeyValuePair<TKey, TValue> pSzkhDNdWcyKdSeTnpgGTeXCedcf()
			{
				return new KeyValuePair<TKey, TValue>(xzRewGuNweXrZjgHBeZSFNenqiYrA, pWbMhcBQKZEHHDwvEOhqpAUJhzfpA);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

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
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1)
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
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1)
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
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1)
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
					if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1)
					{
						throw new Exception();
					}
					return FzeFBTyCrPwRSotVRRvPtdRXkqzA.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
				ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = P_0.yStgeWABMBrpmQklPqcEgwUnhfhE.Version;
				OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
				oawkFEQJtASadJukuuXqlGvZvVOm = P_1;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE.Version)
				{
					throw new Exception();
				}
				if ((uint)OVaNqsFEyODDjJdeKwblTptrPuEz < (uint)rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count)
				{
					FzeFBTyCrPwRSotVRRvPtdRXkqzA = new KeyValuePair<TKey, TValue>(rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items[OVaNqsFEyODDjJdeKwblTptrPuEz].xzRewGuNweXrZjgHBeZSFNenqiYrA, rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items[OVaNqsFEyODDjJdeKwblTptrPuEz].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA);
					OVaNqsFEyODDjJdeKwblTptrPuEz++;
					return true;
				}
				OVaNqsFEyODDjJdeKwblTptrPuEz = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1;
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE.Version)
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
				private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TKey NCXBcBSNFcTabgxIwVeWlKzPsDno;

				public TKey Current => NCXBcBSNFcTabgxIwVeWlKzPsDno;

				object IEnumerator.Current
				{
					get
					{
						if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1)
						{
							throw new Exception();
						}
						return NCXBcBSNFcTabgxIwVeWlKzPsDno;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
					ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = P_0.yStgeWABMBrpmQklPqcEgwUnhfhE.Version;
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE.Version)
					{
						throw new Exception();
					}
					if ((uint)OVaNqsFEyODDjJdeKwblTptrPuEz < (uint)rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count)
					{
						NCXBcBSNFcTabgxIwVeWlKzPsDno = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items[OVaNqsFEyODDjJdeKwblTptrPuEz].xzRewGuNweXrZjgHBeZSFNenqiYrA;
						OVaNqsFEyODDjJdeKwblTptrPuEz++;
						return true;
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE.Version)
					{
						throw new Exception();
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					NCXBcBSNFcTabgxIwVeWlKzPsDno = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

			public int Count => rqzlMgBEqYlprpsgKizQkexqOZQq.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)rqzlMgBEqYlprpsgKizQkexqOZQq).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
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
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count;
				onwvlRAXvfuHAecwrrOKpDmxyjXF[] items = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA;
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
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count;
				onwvlRAXvfuHAecwrrOKpDmxyjXF[] items = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA;
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
				private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

				private int OVaNqsFEyODDjJdeKwblTptrPuEz;

				private int ZvlikOHSMnjEPWqRSdMlbMbbmQwQ;

				private TValue WgXGmgexMaKHPzrdvXYODgkBpyoT;

				public TValue Current => WgXGmgexMaKHPzrdvXYODgkBpyoT;

				object IEnumerator.Current
				{
					get
					{
						if (OVaNqsFEyODDjJdeKwblTptrPuEz == 0 || OVaNqsFEyODDjJdeKwblTptrPuEz == rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1)
						{
							throw new Exception();
						}
						return WgXGmgexMaKHPzrdvXYODgkBpyoT;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					rqzlMgBEqYlprpsgKizQkexqOZQq = P_0;
					ZvlikOHSMnjEPWqRSdMlbMbbmQwQ = P_0.yStgeWABMBrpmQklPqcEgwUnhfhE.Version;
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE.Version)
					{
						throw new Exception();
					}
					if ((uint)OVaNqsFEyODDjJdeKwblTptrPuEz < (uint)rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count)
					{
						WgXGmgexMaKHPzrdvXYODgkBpyoT = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items[OVaNqsFEyODDjJdeKwblTptrPuEz].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
						OVaNqsFEyODDjJdeKwblTptrPuEz++;
						return true;
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count + 1;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (ZvlikOHSMnjEPWqRSdMlbMbbmQwQ != rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE.Version)
					{
						throw new Exception();
					}
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					WgXGmgexMaKHPzrdvXYODgkBpyoT = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> rqzlMgBEqYlprpsgKizQkexqOZQq;

			public int Count => rqzlMgBEqYlprpsgKizQkexqOZQq.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)rqzlMgBEqYlprpsgKizQkexqOZQq).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
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
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count;
				onwvlRAXvfuHAecwrrOKpDmxyjXF[] items = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
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
				int count = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._count;
				onwvlRAXvfuHAecwrrOKpDmxyjXF[] items = rqzlMgBEqYlprpsgKizQkexqOZQq.yStgeWABMBrpmQklPqcEgwUnhfhE._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool cxbjJKonGVqunvFiXgKltFLZeWGhA = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool WNZmPPmomPckHPIvbQCHROzgxsAB = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> imceZluvEaPVivwVpYaTCMKfDLje = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> WYbeMBDIqctHZSJzkTTMpJDAVxPIA = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<onwvlRAXvfuHAecwrrOKpDmxyjXF> yStgeWABMBrpmQklPqcEgwUnhfhE;

		private readonly ADictionary<TKey, int> AJpcTypgrMIrtQSoFTgDfgwFGdNb;

		private bool lVOpvTBpnlcLRKzECvFmQfvyPSpdb;

		public int Count => yStgeWABMBrpmQklPqcEgwUnhfhE._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!lVOpvTBpnlcLRKzECvFmQfvyPSpdb)
				{
					return false;
				}
				return AJpcTypgrMIrtQSoFTgDfgwFGdNb._count < yStgeWABMBrpmQklPqcEgwUnhfhE._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return lVOpvTBpnlcLRKzECvFmQfvyPSpdb;
			}
			set
			{
				if (lVOpvTBpnlcLRKzECvFmQfvyPSpdb != value)
				{
					lVOpvTBpnlcLRKzECvFmQfvyPSpdb = value;
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
				if ((uint)index >= (uint)yStgeWABMBrpmQklPqcEgwUnhfhE._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return yStgeWABMBrpmQklPqcEgwUnhfhE._items[index].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
			}
			set
			{
				if ((uint)index >= (uint)yStgeWABMBrpmQklPqcEgwUnhfhE._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				yStgeWABMBrpmQklPqcEgwUnhfhE._items[index].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = value;
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

		public ICollection<TKey> Keys => new KeyCollection(this);

		public ICollection<TValue> Values => new ValueCollection(this);

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		TValue IDictionary<TKey, TValue>.this[TKey P_0]
		{
			get
			{
				int num = IndexOfKey(P_0);
				if (num < 0)
				{
					TKey val = P_0;
					throw new KeyNotFoundException("Key \"" + val?.ToString() + "\" does not exist.");
				}
				return yStgeWABMBrpmQklPqcEgwUnhfhE._items[num].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
			}
			set
			{
				SetValue(key, value2);
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

		bool ICollection.IsSynchronized => ((ICollection)yStgeWABMBrpmQklPqcEgwUnhfhE).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)yStgeWABMBrpmQklPqcEgwUnhfhE).SyncRoot;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int P_0] => this[P_0];

		int IReadOnlyList.Count => Count;

		object IReadOnlyList.this[int P_0] => this[P_0];

		public IndexedDictionary()
			: this(0, false)
		{
		}

		public IndexedDictionary(int P_0)
			: this(P_0, false)
		{
		}

		public IndexedDictionary(bool P_0)
			: this(0, P_0)
		{
		}

		public IndexedDictionary(int P_0, bool P_1)
		{
			if (P_0 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			lVOpvTBpnlcLRKzECvFmQfvyPSpdb = P_1;
			yStgeWABMBrpmQklPqcEgwUnhfhE = new AList<onwvlRAXvfuHAecwrrOKpDmxyjXF>(P_0);
			AJpcTypgrMIrtQSoFTgDfgwFGdNb = new ADictionary<TKey, int>(P_0);
		}

		public IndexedDictionary(IDictionary<TKey, TValue> P_0)
			: this(P_0, false)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> P_0, bool P_1)
			: this(0, P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (ReflectionTools.DoesTypeImplement(P_0.GetType(), typeof(IndexedDictionary<TKey, TValue>)))
			{
				IndexedDictionary<TKey, TValue> indexedDictionary = (IndexedDictionary<TKey, TValue>)P_0;
				for (int i = 0; i < indexedDictionary.yStgeWABMBrpmQklPqcEgwUnhfhE._count; i++)
				{
					Add(indexedDictionary.yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA, indexedDictionary.yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA);
				}
				return;
			}
			foreach (KeyValuePair<TKey, TValue> item in P_0)
			{
				Add(item.Key, item.Value);
			}
		}

		public TValue GetValue(TKey key)
		{
			return yStgeWABMBrpmQklPqcEgwUnhfhE._items[AJpcTypgrMIrtQSoFTgDfgwFGdNb[key]].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!AJpcTypgrMIrtQSoFTgDfgwFGdNb.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = yStgeWABMBrpmQklPqcEgwUnhfhE._items[value2].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)yStgeWABMBrpmQklPqcEgwUnhfhE._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yStgeWABMBrpmQklPqcEgwUnhfhE[index].xzRewGuNweXrZjgHBeZSFNenqiYrA;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return yStgeWABMBrpmQklPqcEgwUnhfhE[AJpcTypgrMIrtQSoFTgDfgwFGdNb[key]].pSzkhDNdWcyKdSeTnpgGTeXCedcf();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)yStgeWABMBrpmQklPqcEgwUnhfhE._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yStgeWABMBrpmQklPqcEgwUnhfhE[index].pSzkhDNdWcyKdSeTnpgGTeXCedcf();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!AJpcTypgrMIrtQSoFTgDfgwFGdNb.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = yStgeWABMBrpmQklPqcEgwUnhfhE[value].pSzkhDNdWcyKdSeTnpgGTeXCedcf();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = AJpcTypgrMIrtQSoFTgDfgwFGdNb.ContainsKey(key);
			if (num && !lVOpvTBpnlcLRKzECvFmQfvyPSpdb)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int value2 = yStgeWABMBrpmQklPqcEgwUnhfhE.Add(new onwvlRAXvfuHAecwrrOKpDmxyjXF(key, value));
			if (num)
			{
				AJpcTypgrMIrtQSoFTgDfgwFGdNb[key] = value2;
			}
			else
			{
				AJpcTypgrMIrtQSoFTgDfgwFGdNb.Add(key, value2);
			}
		}

		public void SetValue(TKey key, TValue value)
		{
			if (AJpcTypgrMIrtQSoFTgDfgwFGdNb.TryGetValue(key, out var value2))
			{
				yStgeWABMBrpmQklPqcEgwUnhfhE._items[value2].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = value;
				AJpcTypgrMIrtQSoFTgDfgwFGdNb[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			AJpcTypgrMIrtQSoFTgDfgwFGdNb.Remove(key);
			if (lVOpvTBpnlcLRKzECvFmQfvyPSpdb)
			{
				bool result = false;
				for (int num = yStgeWABMBrpmQklPqcEgwUnhfhE._count - 1; num >= 0; num--)
				{
					if (imceZluvEaPVivwVpYaTCMKfDLje.Equals(yStgeWABMBrpmQklPqcEgwUnhfhE._items[num].xzRewGuNweXrZjgHBeZSFNenqiYrA, key))
					{
						yStgeWABMBrpmQklPqcEgwUnhfhE.RemoveAt(num);
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
			if ((uint)index >= (uint)yStgeWABMBrpmQklPqcEgwUnhfhE._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey xzRewGuNweXrZjgHBeZSFNenqiYrA = yStgeWABMBrpmQklPqcEgwUnhfhE._items[index].xzRewGuNweXrZjgHBeZSFNenqiYrA;
			if (index < yStgeWABMBrpmQklPqcEgwUnhfhE._count - 1)
			{
				for (int i = index + 1; i < yStgeWABMBrpmQklPqcEgwUnhfhE.Count; i++)
				{
					AJpcTypgrMIrtQSoFTgDfgwFGdNb[yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA] = i - 1;
				}
			}
			yStgeWABMBrpmQklPqcEgwUnhfhE.RemoveAt(index);
			AJpcTypgrMIrtQSoFTgDfgwFGdNb.Remove(xzRewGuNweXrZjgHBeZSFNenqiYrA);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref yStgeWABMBrpmQklPqcEgwUnhfhE._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = yStgeWABMBrpmQklPqcEgwUnhfhE._count - 1; num2 >= 0; num2--)
			{
				_ = ref yStgeWABMBrpmQklPqcEgwUnhfhE._items[num2];
				if (WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(yStgeWABMBrpmQklPqcEgwUnhfhE._items[num2].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!cxbjJKonGVqunvFiXgKltFLZeWGhA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = yStgeWABMBrpmQklPqcEgwUnhfhE._count;
			for (int i = 0; i < count; i++)
			{
				if (imceZluvEaPVivwVpYaTCMKfDLje.Equals(yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = yStgeWABMBrpmQklPqcEgwUnhfhE._count;
			for (int i = 0; i < count; i++)
			{
				if (WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return AJpcTypgrMIrtQSoFTgDfgwFGdNb.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			yStgeWABMBrpmQklPqcEgwUnhfhE.Clear();
			AJpcTypgrMIrtQSoFTgDfgwFGdNb.Clear();
		}

		public void TrimExcess()
		{
			yStgeWABMBrpmQklPqcEgwUnhfhE.TrimExcess();
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			onwvlRAXvfuHAecwrrOKpDmxyjXF onwvlRAXvfuHAecwrrOKpDmxyjXF2 = yStgeWABMBrpmQklPqcEgwUnhfhE._items[num];
			return WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(P_0.Value, onwvlRAXvfuHAecwrrOKpDmxyjXF2.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
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
			int count = yStgeWABMBrpmQklPqcEgwUnhfhE._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA, yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA);
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			if (lVOpvTBpnlcLRKzECvFmQfvyPSpdb)
			{
				bool result = false;
				for (int num = yStgeWABMBrpmQklPqcEgwUnhfhE._count - 1; num >= 0; num--)
				{
					onwvlRAXvfuHAecwrrOKpDmxyjXF onwvlRAXvfuHAecwrrOKpDmxyjXF2 = yStgeWABMBrpmQklPqcEgwUnhfhE._items[num];
					if (WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(P_0.Value, onwvlRAXvfuHAecwrrOKpDmxyjXF2.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA))
					{
						yStgeWABMBrpmQklPqcEgwUnhfhE.RemoveAt(num);
						result = true;
					}
				}
				return result;
			}
			int num2 = IndexOfKey(P_0.Key);
			if (num2 < 0)
			{
				return false;
			}
			onwvlRAXvfuHAecwrrOKpDmxyjXF onwvlRAXvfuHAecwrrOKpDmxyjXF3 = yStgeWABMBrpmQklPqcEgwUnhfhE._items[num2];
			if (!WYbeMBDIqctHZSJzkTTMpJDAVxPIA.Equals(P_0.Value, onwvlRAXvfuHAecwrrOKpDmxyjXF3.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA))
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
			int count = yStgeWABMBrpmQklPqcEgwUnhfhE._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].xzRewGuNweXrZjgHBeZSFNenqiYrA, yStgeWABMBrpmQklPqcEgwUnhfhE._items[i].pWbMhcBQKZEHHDwvEOhqpAUJhzfpA), index++);
			}
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		private int BAqhqIlptXdxiVoQTgqZNhuheYtL(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BAqhqIlptXdxiVoQTgqZNhuheYtL
			return this.BAqhqIlptXdxiVoQTgqZNhuheYtL(P_0);
		}

		private bool IuAyVKNcfUjQJQOQTxbJHvPgUDop(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IuAyVKNcfUjQJQOQTxbJHvPgUDop
			return this.IuAyVKNcfUjQJQOQTxbJHvPgUDop(P_0);
		}
	}
}
