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
		private struct cICaBjRXiRzbfJMgCicWHJcfnqVe
		{
			public TKey tYjORezDGCsyoKVqwSlOtiXxaUS;

			public TValue lvXCTCWOhrCtuFDbbEqyqyUVPhp;

			public cICaBjRXiRzbfJMgCicWHJcfnqVe(TKey key, TValue value)
			{
				tYjORezDGCsyoKVqwSlOtiXxaUS = key;
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = value;
			}

			public KeyValuePair<TKey, TValue> nWRAQdgQbOThKafaOgkOLjeOMuqJ()
			{
				return new KeyValuePair<TKey, TValue>(tYjORezDGCsyoKVqwSlOtiXxaUS, lvXCTCWOhrCtuFDbbEqyqyUVPhp);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> lzZBwAKNPsUaSIywjNiGInbihBW;

			private int RYBOCkYQrNTnuzaLxPFpZllbCSq;

			private int ACGGwGOBHafSQSEmbVqxDttpurC;

			private KeyValuePair<TKey, TValue> TrWUdtjebjTxiTudwuGvXSlDJgg;

			private int ywUfCqVoKirKCyBqVfygLqpTjSE;

			public KeyValuePair<TKey, TValue> Current => TrWUdtjebjTxiTudwuGvXSlDJgg;

			object IEnumerator.Current
			{
				get
				{
					if (ACGGwGOBHafSQSEmbVqxDttpurC == 0 || ACGGwGOBHafSQSEmbVqxDttpurC == lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1)
					{
						throw new Exception();
					}
					if (ywUfCqVoKirKCyBqVfygLqpTjSE == 1)
					{
						return new DictionaryEntry(TrWUdtjebjTxiTudwuGvXSlDJgg.Key, TrWUdtjebjTxiTudwuGvXSlDJgg.Value);
					}
					return new KeyValuePair<TKey, TValue>(TrWUdtjebjTxiTudwuGvXSlDJgg.Key, TrWUdtjebjTxiTudwuGvXSlDJgg.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (ACGGwGOBHafSQSEmbVqxDttpurC == 0 || ACGGwGOBHafSQSEmbVqxDttpurC == lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(TrWUdtjebjTxiTudwuGvXSlDJgg.Key, TrWUdtjebjTxiTudwuGvXSlDJgg.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (ACGGwGOBHafSQSEmbVqxDttpurC == 0 || ACGGwGOBHafSQSEmbVqxDttpurC == lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1)
					{
						throw new Exception();
					}
					return TrWUdtjebjTxiTudwuGvXSlDJgg.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (ACGGwGOBHafSQSEmbVqxDttpurC == 0 || ACGGwGOBHafSQSEmbVqxDttpurC == lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1)
					{
						throw new Exception();
					}
					return TrWUdtjebjTxiTudwuGvXSlDJgg.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				lzZBwAKNPsUaSIywjNiGInbihBW = dictionary;
				RYBOCkYQrNTnuzaLxPFpZllbCSq = dictionary.yxHUQoFParyiBpDywOfWIJsrbSp.Version;
				ACGGwGOBHafSQSEmbVqxDttpurC = 0;
				ywUfCqVoKirKCyBqVfygLqpTjSE = getEnumeratorRetType;
				TrWUdtjebjTxiTudwuGvXSlDJgg = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (RYBOCkYQrNTnuzaLxPFpZllbCSq != lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp.Version)
				{
					throw new Exception();
				}
				if ((uint)ACGGwGOBHafSQSEmbVqxDttpurC < (uint)lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count)
				{
					TrWUdtjebjTxiTudwuGvXSlDJgg = new KeyValuePair<TKey, TValue>(lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items[ACGGwGOBHafSQSEmbVqxDttpurC].tYjORezDGCsyoKVqwSlOtiXxaUS, lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items[ACGGwGOBHafSQSEmbVqxDttpurC].lvXCTCWOhrCtuFDbbEqyqyUVPhp);
					ACGGwGOBHafSQSEmbVqxDttpurC++;
					return true;
				}
				ACGGwGOBHafSQSEmbVqxDttpurC = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1;
				TrWUdtjebjTxiTudwuGvXSlDJgg = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (RYBOCkYQrNTnuzaLxPFpZllbCSq != lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp.Version)
				{
					throw new Exception();
				}
				ACGGwGOBHafSQSEmbVqxDttpurC = 0;
				TrWUdtjebjTxiTudwuGvXSlDJgg = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> lzZBwAKNPsUaSIywjNiGInbihBW;

				private int ACGGwGOBHafSQSEmbVqxDttpurC;

				private int RYBOCkYQrNTnuzaLxPFpZllbCSq;

				private TKey PMzNMdPdqUbnCbLOPKrWIRdLHTva;

				public TKey Current => PMzNMdPdqUbnCbLOPKrWIRdLHTva;

				object IEnumerator.Current
				{
					get
					{
						if (ACGGwGOBHafSQSEmbVqxDttpurC == 0 || ACGGwGOBHafSQSEmbVqxDttpurC == lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1)
						{
							throw new Exception();
						}
						return PMzNMdPdqUbnCbLOPKrWIRdLHTva;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					lzZBwAKNPsUaSIywjNiGInbihBW = dictionary;
					RYBOCkYQrNTnuzaLxPFpZllbCSq = dictionary.yxHUQoFParyiBpDywOfWIJsrbSp.Version;
					ACGGwGOBHafSQSEmbVqxDttpurC = 0;
					PMzNMdPdqUbnCbLOPKrWIRdLHTva = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (RYBOCkYQrNTnuzaLxPFpZllbCSq != lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp.Version)
					{
						throw new Exception();
					}
					if ((uint)ACGGwGOBHafSQSEmbVqxDttpurC < (uint)lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count)
					{
						PMzNMdPdqUbnCbLOPKrWIRdLHTva = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items[ACGGwGOBHafSQSEmbVqxDttpurC].tYjORezDGCsyoKVqwSlOtiXxaUS;
						ACGGwGOBHafSQSEmbVqxDttpurC++;
						return true;
					}
					ACGGwGOBHafSQSEmbVqxDttpurC = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1;
					PMzNMdPdqUbnCbLOPKrWIRdLHTva = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (RYBOCkYQrNTnuzaLxPFpZllbCSq != lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp.Version)
					{
						throw new Exception();
					}
					ACGGwGOBHafSQSEmbVqxDttpurC = 0;
					PMzNMdPdqUbnCbLOPKrWIRdLHTva = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> lzZBwAKNPsUaSIywjNiGInbihBW;

			public int Count => lzZBwAKNPsUaSIywjNiGInbihBW.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)lzZBwAKNPsUaSIywjNiGInbihBW).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				lzZBwAKNPsUaSIywjNiGInbihBW = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(lzZBwAKNPsUaSIywjNiGInbihBW);
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
				if (array.Length - index < lzZBwAKNPsUaSIywjNiGInbihBW.Count)
				{
					throw new Exception();
				}
				int count = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count;
				cICaBjRXiRzbfJMgCicWHJcfnqVe[] items = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].tYjORezDGCsyoKVqwSlOtiXxaUS;
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
				return lzZBwAKNPsUaSIywjNiGInbihBW.ContainsKey(item);
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(lzZBwAKNPsUaSIywjNiGInbihBW);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(lzZBwAKNPsUaSIywjNiGInbihBW);
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
				if (array.Length - index < lzZBwAKNPsUaSIywjNiGInbihBW.Count)
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
				int count = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count;
				cICaBjRXiRzbfJMgCicWHJcfnqVe[] items = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].tYjORezDGCsyoKVqwSlOtiXxaUS;
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
				private IndexedDictionary<TKey, TValue> lzZBwAKNPsUaSIywjNiGInbihBW;

				private int ACGGwGOBHafSQSEmbVqxDttpurC;

				private int RYBOCkYQrNTnuzaLxPFpZllbCSq;

				private TValue CLpOCEuFtYKigWftQHHAfoaZIia;

				public TValue Current => CLpOCEuFtYKigWftQHHAfoaZIia;

				object IEnumerator.Current
				{
					get
					{
						if (ACGGwGOBHafSQSEmbVqxDttpurC == 0 || ACGGwGOBHafSQSEmbVqxDttpurC == lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1)
						{
							throw new Exception();
						}
						return CLpOCEuFtYKigWftQHHAfoaZIia;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					lzZBwAKNPsUaSIywjNiGInbihBW = dictionary;
					RYBOCkYQrNTnuzaLxPFpZllbCSq = dictionary.yxHUQoFParyiBpDywOfWIJsrbSp.Version;
					ACGGwGOBHafSQSEmbVqxDttpurC = 0;
					CLpOCEuFtYKigWftQHHAfoaZIia = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (RYBOCkYQrNTnuzaLxPFpZllbCSq != lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp.Version)
					{
						throw new Exception();
					}
					if ((uint)ACGGwGOBHafSQSEmbVqxDttpurC < (uint)lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count)
					{
						CLpOCEuFtYKigWftQHHAfoaZIia = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items[ACGGwGOBHafSQSEmbVqxDttpurC].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
						ACGGwGOBHafSQSEmbVqxDttpurC++;
						return true;
					}
					ACGGwGOBHafSQSEmbVqxDttpurC = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count + 1;
					CLpOCEuFtYKigWftQHHAfoaZIia = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (RYBOCkYQrNTnuzaLxPFpZllbCSq != lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp.Version)
					{
						throw new Exception();
					}
					ACGGwGOBHafSQSEmbVqxDttpurC = 0;
					CLpOCEuFtYKigWftQHHAfoaZIia = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> lzZBwAKNPsUaSIywjNiGInbihBW;

			public int Count => lzZBwAKNPsUaSIywjNiGInbihBW.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)lzZBwAKNPsUaSIywjNiGInbihBW).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				lzZBwAKNPsUaSIywjNiGInbihBW = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(lzZBwAKNPsUaSIywjNiGInbihBW);
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
				if (array.Length - index < lzZBwAKNPsUaSIywjNiGInbihBW.Count)
				{
					throw new Exception();
				}
				int count = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count;
				cICaBjRXiRzbfJMgCicWHJcfnqVe[] items = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
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
				return lzZBwAKNPsUaSIywjNiGInbihBW.ContainsValue(item);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(lzZBwAKNPsUaSIywjNiGInbihBW);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(lzZBwAKNPsUaSIywjNiGInbihBW);
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
				if (array.Length - index < lzZBwAKNPsUaSIywjNiGInbihBW.Count)
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
				int count = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._count;
				cICaBjRXiRzbfJMgCicWHJcfnqVe[] items = lzZBwAKNPsUaSIywjNiGInbihBW.yxHUQoFParyiBpDywOfWIJsrbSp._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool wQJxagdLrhxWWKOyqLefPoZVUbO = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool SgjxKljoPdcbVyMMKvVYzTMypxa = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> sdKFAJblYOoIHKKqSfHBPeWnyLvl = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> SzZsrnRBzOUNmydNDWBOpeFApfV = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<cICaBjRXiRzbfJMgCicWHJcfnqVe> yxHUQoFParyiBpDywOfWIJsrbSp;

		private readonly ADictionary<TKey, int> YeRzSnsqJgpJCljIeuOmDYwDKmj;

		private bool fCiaZtYPEFBAgMMMjWOqHEraaSrK;

		public int Count => yxHUQoFParyiBpDywOfWIJsrbSp._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!fCiaZtYPEFBAgMMMjWOqHEraaSrK)
				{
					return false;
				}
				return YeRzSnsqJgpJCljIeuOmDYwDKmj._count < yxHUQoFParyiBpDywOfWIJsrbSp._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return fCiaZtYPEFBAgMMMjWOqHEraaSrK;
			}
			set
			{
				if (fCiaZtYPEFBAgMMMjWOqHEraaSrK != value)
				{
					fCiaZtYPEFBAgMMMjWOqHEraaSrK = value;
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
				if ((uint)index >= (uint)yxHUQoFParyiBpDywOfWIJsrbSp._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return yxHUQoFParyiBpDywOfWIJsrbSp._items[index].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
			}
			set
			{
				if ((uint)index >= (uint)yxHUQoFParyiBpDywOfWIJsrbSp._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				yxHUQoFParyiBpDywOfWIJsrbSp._items[index].lvXCTCWOhrCtuFDbbEqyqyUVPhp = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return sdKFAJblYOoIHKKqSfHBPeWnyLvl;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				sdKFAJblYOoIHKKqSfHBPeWnyLvl = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return SzZsrnRBzOUNmydNDWBOpeFApfV;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				SzZsrnRBzOUNmydNDWBOpeFApfV = value;
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
				return yxHUQoFParyiBpDywOfWIJsrbSp._items[num].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
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

		bool ICollection.IsSynchronized => ((ICollection)yxHUQoFParyiBpDywOfWIJsrbSp).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)yxHUQoFParyiBpDywOfWIJsrbSp).SyncRoot;

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
			fCiaZtYPEFBAgMMMjWOqHEraaSrK = allowDuplicateKeys;
			yxHUQoFParyiBpDywOfWIJsrbSp = new AList<cICaBjRXiRzbfJMgCicWHJcfnqVe>(capacity);
			YeRzSnsqJgpJCljIeuOmDYwDKmj = new ADictionary<TKey, int>(capacity);
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
				for (int i = 0; i < indexedDictionary.yxHUQoFParyiBpDywOfWIJsrbSp._count; i++)
				{
					Add(indexedDictionary.yxHUQoFParyiBpDywOfWIJsrbSp._items[i].tYjORezDGCsyoKVqwSlOtiXxaUS, indexedDictionary.yxHUQoFParyiBpDywOfWIJsrbSp._items[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp);
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
			return yxHUQoFParyiBpDywOfWIJsrbSp._items[YeRzSnsqJgpJCljIeuOmDYwDKmj[key]].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!YeRzSnsqJgpJCljIeuOmDYwDKmj.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = yxHUQoFParyiBpDywOfWIJsrbSp._items[value2].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)yxHUQoFParyiBpDywOfWIJsrbSp._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yxHUQoFParyiBpDywOfWIJsrbSp[index].tYjORezDGCsyoKVqwSlOtiXxaUS;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return yxHUQoFParyiBpDywOfWIJsrbSp[YeRzSnsqJgpJCljIeuOmDYwDKmj[key]].nWRAQdgQbOThKafaOgkOLjeOMuqJ();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)yxHUQoFParyiBpDywOfWIJsrbSp._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yxHUQoFParyiBpDywOfWIJsrbSp[index].nWRAQdgQbOThKafaOgkOLjeOMuqJ();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!YeRzSnsqJgpJCljIeuOmDYwDKmj.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = yxHUQoFParyiBpDywOfWIJsrbSp[value].nWRAQdgQbOThKafaOgkOLjeOMuqJ();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool flag = YeRzSnsqJgpJCljIeuOmDYwDKmj.ContainsKey(key);
			if (flag && !fCiaZtYPEFBAgMMMjWOqHEraaSrK)
			{
				throw new ArgumentException(string.Concat("Key \"", key, "\" is already in use."));
			}
			int value2 = yxHUQoFParyiBpDywOfWIJsrbSp.Add(new cICaBjRXiRzbfJMgCicWHJcfnqVe(key, value));
			if (flag)
			{
				YeRzSnsqJgpJCljIeuOmDYwDKmj[key] = value2;
			}
			else
			{
				YeRzSnsqJgpJCljIeuOmDYwDKmj.Add(key, value2);
			}
		}

		public void SetValue(TKey key, TValue value)
		{
			if (YeRzSnsqJgpJCljIeuOmDYwDKmj.TryGetValue(key, out var value2))
			{
				yxHUQoFParyiBpDywOfWIJsrbSp._items[value2].lvXCTCWOhrCtuFDbbEqyqyUVPhp = value;
				YeRzSnsqJgpJCljIeuOmDYwDKmj[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			YeRzSnsqJgpJCljIeuOmDYwDKmj.Remove(key);
			if (fCiaZtYPEFBAgMMMjWOqHEraaSrK)
			{
				bool result = false;
				for (int num = yxHUQoFParyiBpDywOfWIJsrbSp._count - 1; num >= 0; num--)
				{
					if (sdKFAJblYOoIHKKqSfHBPeWnyLvl.Equals(yxHUQoFParyiBpDywOfWIJsrbSp._items[num].tYjORezDGCsyoKVqwSlOtiXxaUS, key))
					{
						yxHUQoFParyiBpDywOfWIJsrbSp.RemoveAt(num);
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
			if ((uint)index >= (uint)yxHUQoFParyiBpDywOfWIJsrbSp._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey tYjORezDGCsyoKVqwSlOtiXxaUS = yxHUQoFParyiBpDywOfWIJsrbSp._items[index].tYjORezDGCsyoKVqwSlOtiXxaUS;
			if (index < yxHUQoFParyiBpDywOfWIJsrbSp._count - 1)
			{
				for (int i = index + 1; i < yxHUQoFParyiBpDywOfWIJsrbSp.Count; i++)
				{
					YeRzSnsqJgpJCljIeuOmDYwDKmj[yxHUQoFParyiBpDywOfWIJsrbSp._items[i].tYjORezDGCsyoKVqwSlOtiXxaUS] = i - 1;
				}
			}
			yxHUQoFParyiBpDywOfWIJsrbSp.RemoveAt(index);
			YeRzSnsqJgpJCljIeuOmDYwDKmj.Remove(tYjORezDGCsyoKVqwSlOtiXxaUS);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = yxHUQoFParyiBpDywOfWIJsrbSp._items[num].tYjORezDGCsyoKVqwSlOtiXxaUS;
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			int count = yxHUQoFParyiBpDywOfWIJsrbSp._count;
			for (int num2 = count - 1; num2 >= 0; num2--)
			{
				_ = yxHUQoFParyiBpDywOfWIJsrbSp._items[num2].tYjORezDGCsyoKVqwSlOtiXxaUS;
				if (SzZsrnRBzOUNmydNDWBOpeFApfV.Equals(yxHUQoFParyiBpDywOfWIJsrbSp._items[num2].lvXCTCWOhrCtuFDbbEqyqyUVPhp, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!wQJxagdLrhxWWKOyqLefPoZVUbO && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = yxHUQoFParyiBpDywOfWIJsrbSp._count;
			for (int i = 0; i < count; i++)
			{
				if (sdKFAJblYOoIHKKqSfHBPeWnyLvl.Equals(yxHUQoFParyiBpDywOfWIJsrbSp._items[i].tYjORezDGCsyoKVqwSlOtiXxaUS, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = yxHUQoFParyiBpDywOfWIJsrbSp._count;
			for (int i = 0; i < count; i++)
			{
				if (SzZsrnRBzOUNmydNDWBOpeFApfV.Equals(yxHUQoFParyiBpDywOfWIJsrbSp._items[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return YeRzSnsqJgpJCljIeuOmDYwDKmj.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			yxHUQoFParyiBpDywOfWIJsrbSp.Clear();
			YeRzSnsqJgpJCljIeuOmDYwDKmj.Clear();
		}

		public void TrimExcess()
		{
			yxHUQoFParyiBpDywOfWIJsrbSp.TrimExcess();
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
			cICaBjRXiRzbfJMgCicWHJcfnqVe cICaBjRXiRzbfJMgCicWHJcfnqVe2 = yxHUQoFParyiBpDywOfWIJsrbSp._items[num];
			return SzZsrnRBzOUNmydNDWBOpeFApfV.Equals(item.Value, cICaBjRXiRzbfJMgCicWHJcfnqVe2.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
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
			int count = yxHUQoFParyiBpDywOfWIJsrbSp._count;
			for (int i = 0; i < count; i++)
			{
				ref KeyValuePair<TKey, TValue> reference = ref array[index++];
				reference = new KeyValuePair<TKey, TValue>(yxHUQoFParyiBpDywOfWIJsrbSp._items[i].tYjORezDGCsyoKVqwSlOtiXxaUS, yxHUQoFParyiBpDywOfWIJsrbSp._items[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp);
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			if (fCiaZtYPEFBAgMMMjWOqHEraaSrK)
			{
				bool result = false;
				for (int num = yxHUQoFParyiBpDywOfWIJsrbSp._count - 1; num >= 0; num--)
				{
					cICaBjRXiRzbfJMgCicWHJcfnqVe cICaBjRXiRzbfJMgCicWHJcfnqVe2 = yxHUQoFParyiBpDywOfWIJsrbSp._items[num];
					if (SzZsrnRBzOUNmydNDWBOpeFApfV.Equals(item.Value, cICaBjRXiRzbfJMgCicWHJcfnqVe2.lvXCTCWOhrCtuFDbbEqyqyUVPhp))
					{
						yxHUQoFParyiBpDywOfWIJsrbSp.RemoveAt(num);
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
			cICaBjRXiRzbfJMgCicWHJcfnqVe cICaBjRXiRzbfJMgCicWHJcfnqVe3 = yxHUQoFParyiBpDywOfWIJsrbSp._items[num2];
			if (!SzZsrnRBzOUNmydNDWBOpeFApfV.Equals(item.Value, cICaBjRXiRzbfJMgCicWHJcfnqVe3.lvXCTCWOhrCtuFDbbEqyqyUVPhp))
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
			int count = yxHUQoFParyiBpDywOfWIJsrbSp._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(yxHUQoFParyiBpDywOfWIJsrbSp._items[i].tYjORezDGCsyoKVqwSlOtiXxaUS, yxHUQoFParyiBpDywOfWIJsrbSp._items[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp), index++);
			}
		}

		private int dXJYHCIMBTOCMAMBPusqEMuEGa(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dXJYHCIMBTOCMAMBPusqEMuEGa
			return this.dXJYHCIMBTOCMAMBPusqEMuEGa(P_0);
		}

		private bool OAhqBOPqDUiIsCVhlXENJgMtkro(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OAhqBOPqDUiIsCVhlXENJgMtkro
			return this.OAhqBOPqDUiIsCVhlXENJgMtkro(P_0);
		}

		private int NwAOuqgTKfcDJwjImAfFlzezmUd(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NwAOuqgTKfcDJwjImAfFlzezmUd
			return this.NwAOuqgTKfcDJwjImAfFlzezmUd(P_0);
		}

		private bool GewNIeGqSayFurlIgxuBnqHgcTa(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GewNIeGqSayFurlIgxuBnqHgcTa
			return this.GewNIeGqSayFurlIgxuBnqHgcTa(P_0);
		}
	}
}
