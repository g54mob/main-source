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
		private struct LWspuIkPfdrLaRPEWuTioQReLyDP
		{
			public TKey EqHcpXWaGauOvKqzuxjiUENyiiKN;

			public TValue ANnyYrpgRHgHrBXsbJxMFrsUzupD;

			public LWspuIkPfdrLaRPEWuTioQReLyDP(TKey P_0, TValue P_1)
			{
				EqHcpXWaGauOvKqzuxjiUENyiiKN = P_0;
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = P_1;
			}

			public KeyValuePair<TKey, TValue> OctrrQtCiiTFFrbGETLiMmHZIoiW()
			{
				return new KeyValuePair<TKey, TValue>(EqHcpXWaGauOvKqzuxjiUENyiiKN, ANnyYrpgRHgHrBXsbJxMFrsUzupD);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			private IndexedDictionary<TKey, TValue> ChfJEnxaCSMBJEcUlaFghoMrBRWJA;

			private int cmxrBVhgPrfinfdtfygTkEMyCAcE;

			private int tmcbqprIOUgJRYkEdFEZugQwfaOT;

			private KeyValuePair<TKey, TValue> yVsKAUWymJvXlLdJcirLAkYCwgyuA;

			private int PQcUbTgDaEJeZwbYHIqGyqYMtgQG;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			public KeyValuePair<TKey, TValue> Current => yVsKAUWymJvXlLdJcirLAkYCwgyuA;

			object IEnumerator.Current
			{
				get
				{
					if (tmcbqprIOUgJRYkEdFEZugQwfaOT == 0 || tmcbqprIOUgJRYkEdFEZugQwfaOT == ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1)
					{
						throw new Exception();
					}
					if (PQcUbTgDaEJeZwbYHIqGyqYMtgQG == 1)
					{
						return new DictionaryEntry(yVsKAUWymJvXlLdJcirLAkYCwgyuA.Key, yVsKAUWymJvXlLdJcirLAkYCwgyuA.Value);
					}
					return new KeyValuePair<TKey, TValue>(yVsKAUWymJvXlLdJcirLAkYCwgyuA.Key, yVsKAUWymJvXlLdJcirLAkYCwgyuA.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (tmcbqprIOUgJRYkEdFEZugQwfaOT == 0 || tmcbqprIOUgJRYkEdFEZugQwfaOT == ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(yVsKAUWymJvXlLdJcirLAkYCwgyuA.Key, yVsKAUWymJvXlLdJcirLAkYCwgyuA.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (tmcbqprIOUgJRYkEdFEZugQwfaOT == 0 || tmcbqprIOUgJRYkEdFEZugQwfaOT == ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1)
					{
						throw new Exception();
					}
					return yVsKAUWymJvXlLdJcirLAkYCwgyuA.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (tmcbqprIOUgJRYkEdFEZugQwfaOT == 0 || tmcbqprIOUgJRYkEdFEZugQwfaOT == ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1)
					{
						throw new Exception();
					}
					return yVsKAUWymJvXlLdJcirLAkYCwgyuA.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				ChfJEnxaCSMBJEcUlaFghoMrBRWJA = P_0;
				cmxrBVhgPrfinfdtfygTkEMyCAcE = P_0.VclIzXqzjHdMOfpSsGrynyTedqzj.Version;
				tmcbqprIOUgJRYkEdFEZugQwfaOT = 0;
				PQcUbTgDaEJeZwbYHIqGyqYMtgQG = P_1;
				yVsKAUWymJvXlLdJcirLAkYCwgyuA = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (cmxrBVhgPrfinfdtfygTkEMyCAcE != ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj.Version)
				{
					throw new Exception();
				}
				if ((uint)tmcbqprIOUgJRYkEdFEZugQwfaOT < (uint)ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count)
				{
					yVsKAUWymJvXlLdJcirLAkYCwgyuA = new KeyValuePair<TKey, TValue>(ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items[tmcbqprIOUgJRYkEdFEZugQwfaOT].EqHcpXWaGauOvKqzuxjiUENyiiKN, ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items[tmcbqprIOUgJRYkEdFEZugQwfaOT].ANnyYrpgRHgHrBXsbJxMFrsUzupD);
					tmcbqprIOUgJRYkEdFEZugQwfaOT++;
					return true;
				}
				tmcbqprIOUgJRYkEdFEZugQwfaOT = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1;
				yVsKAUWymJvXlLdJcirLAkYCwgyuA = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (cmxrBVhgPrfinfdtfygTkEMyCAcE != ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj.Version)
				{
					throw new Exception();
				}
				tmcbqprIOUgJRYkEdFEZugQwfaOT = 0;
				yVsKAUWymJvXlLdJcirLAkYCwgyuA = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> ChfJEnxaCSMBJEcUlaFghoMrBRWJA;

				private int tmcbqprIOUgJRYkEdFEZugQwfaOT;

				private int cmxrBVhgPrfinfdtfygTkEMyCAcE;

				private TKey uzJGpEcWvwxFNZqwXNQisVQERXdT;

				public TKey Current => uzJGpEcWvwxFNZqwXNQisVQERXdT;

				object IEnumerator.Current
				{
					get
					{
						if (tmcbqprIOUgJRYkEdFEZugQwfaOT == 0 || tmcbqprIOUgJRYkEdFEZugQwfaOT == ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1)
						{
							throw new Exception();
						}
						return uzJGpEcWvwxFNZqwXNQisVQERXdT;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					ChfJEnxaCSMBJEcUlaFghoMrBRWJA = P_0;
					cmxrBVhgPrfinfdtfygTkEMyCAcE = P_0.VclIzXqzjHdMOfpSsGrynyTedqzj.Version;
					tmcbqprIOUgJRYkEdFEZugQwfaOT = 0;
					uzJGpEcWvwxFNZqwXNQisVQERXdT = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (cmxrBVhgPrfinfdtfygTkEMyCAcE != ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj.Version)
					{
						throw new Exception();
					}
					if ((uint)tmcbqprIOUgJRYkEdFEZugQwfaOT < (uint)ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count)
					{
						uzJGpEcWvwxFNZqwXNQisVQERXdT = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items[tmcbqprIOUgJRYkEdFEZugQwfaOT].EqHcpXWaGauOvKqzuxjiUENyiiKN;
						tmcbqprIOUgJRYkEdFEZugQwfaOT++;
						return true;
					}
					tmcbqprIOUgJRYkEdFEZugQwfaOT = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1;
					uzJGpEcWvwxFNZqwXNQisVQERXdT = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (cmxrBVhgPrfinfdtfygTkEMyCAcE != ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj.Version)
					{
						throw new Exception();
					}
					tmcbqprIOUgJRYkEdFEZugQwfaOT = 0;
					uzJGpEcWvwxFNZqwXNQisVQERXdT = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> ChfJEnxaCSMBJEcUlaFghoMrBRWJA;

			public int Count => ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)ChfJEnxaCSMBJEcUlaFghoMrBRWJA).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				ChfJEnxaCSMBJEcUlaFghoMrBRWJA = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(ChfJEnxaCSMBJEcUlaFghoMrBRWJA);
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
				if (array.Length - index < ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Count)
				{
					throw new Exception();
				}
				int count = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count;
				LWspuIkPfdrLaRPEWuTioQReLyDP[] items = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN;
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
				return ChfJEnxaCSMBJEcUlaFghoMrBRWJA.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(ChfJEnxaCSMBJEcUlaFghoMrBRWJA);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(ChfJEnxaCSMBJEcUlaFghoMrBRWJA);
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
				if (array.Length - index < ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Count)
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
				int count = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count;
				LWspuIkPfdrLaRPEWuTioQReLyDP[] items = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN;
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
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private IndexedDictionary<TKey, TValue> ChfJEnxaCSMBJEcUlaFghoMrBRWJA;

				private int tmcbqprIOUgJRYkEdFEZugQwfaOT;

				private int cmxrBVhgPrfinfdtfygTkEMyCAcE;

				private TValue xWPcfpNowyeoxhUNAOqqUURSBccBA;

				public TValue Current => xWPcfpNowyeoxhUNAOqqUURSBccBA;

				object IEnumerator.Current
				{
					get
					{
						if (tmcbqprIOUgJRYkEdFEZugQwfaOT == 0 || tmcbqprIOUgJRYkEdFEZugQwfaOT == ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1)
						{
							throw new Exception();
						}
						return xWPcfpNowyeoxhUNAOqqUURSBccBA;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					ChfJEnxaCSMBJEcUlaFghoMrBRWJA = P_0;
					cmxrBVhgPrfinfdtfygTkEMyCAcE = P_0.VclIzXqzjHdMOfpSsGrynyTedqzj.Version;
					tmcbqprIOUgJRYkEdFEZugQwfaOT = 0;
					xWPcfpNowyeoxhUNAOqqUURSBccBA = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (cmxrBVhgPrfinfdtfygTkEMyCAcE != ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj.Version)
					{
						throw new Exception();
					}
					if ((uint)tmcbqprIOUgJRYkEdFEZugQwfaOT < (uint)ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count)
					{
						xWPcfpNowyeoxhUNAOqqUURSBccBA = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items[tmcbqprIOUgJRYkEdFEZugQwfaOT].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
						tmcbqprIOUgJRYkEdFEZugQwfaOT++;
						return true;
					}
					tmcbqprIOUgJRYkEdFEZugQwfaOT = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count + 1;
					xWPcfpNowyeoxhUNAOqqUURSBccBA = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (cmxrBVhgPrfinfdtfygTkEMyCAcE != ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj.Version)
					{
						throw new Exception();
					}
					tmcbqprIOUgJRYkEdFEZugQwfaOT = 0;
					xWPcfpNowyeoxhUNAOqqUURSBccBA = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> ChfJEnxaCSMBJEcUlaFghoMrBRWJA;

			public int Count => ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)ChfJEnxaCSMBJEcUlaFghoMrBRWJA).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				ChfJEnxaCSMBJEcUlaFghoMrBRWJA = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(ChfJEnxaCSMBJEcUlaFghoMrBRWJA);
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
				if (array.Length - index < ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Count)
				{
					throw new Exception();
				}
				int count = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count;
				LWspuIkPfdrLaRPEWuTioQReLyDP[] items = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
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
				return ChfJEnxaCSMBJEcUlaFghoMrBRWJA.ContainsValue(P_0);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(ChfJEnxaCSMBJEcUlaFghoMrBRWJA);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(ChfJEnxaCSMBJEcUlaFghoMrBRWJA);
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
				if (array.Length - index < ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Count)
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
				int count = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._count;
				LWspuIkPfdrLaRPEWuTioQReLyDP[] items = ChfJEnxaCSMBJEcUlaFghoMrBRWJA.VclIzXqzjHdMOfpSsGrynyTedqzj._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool JajGGPAsdNXfDUdYsuMHgBoYAaEK = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool jKHInGOsWRkBEiZcWhowWFdlhbcBA = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> JVumbsEBLwXoIScIGdcjFXpsvVhTA = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> jPrBZGcYMgwSnkuZDbumMqiJzKJf = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<LWspuIkPfdrLaRPEWuTioQReLyDP> VclIzXqzjHdMOfpSsGrynyTedqzj;

		private readonly ADictionary<TKey, int> pSbefWHNCObrZzUiitfQuANIGSjv;

		private bool WmAgNYfZjnkCbGfevtYCeLCbMQfK;

		public int Count => VclIzXqzjHdMOfpSsGrynyTedqzj._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!WmAgNYfZjnkCbGfevtYCeLCbMQfK)
				{
					return false;
				}
				return pSbefWHNCObrZzUiitfQuANIGSjv._count < VclIzXqzjHdMOfpSsGrynyTedqzj._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return WmAgNYfZjnkCbGfevtYCeLCbMQfK;
			}
			set
			{
				if (WmAgNYfZjnkCbGfevtYCeLCbMQfK != value)
				{
					WmAgNYfZjnkCbGfevtYCeLCbMQfK = value;
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
				if ((uint)index >= (uint)VclIzXqzjHdMOfpSsGrynyTedqzj._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return VclIzXqzjHdMOfpSsGrynyTedqzj._items[index].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
			}
			set
			{
				if ((uint)index >= (uint)VclIzXqzjHdMOfpSsGrynyTedqzj._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				VclIzXqzjHdMOfpSsGrynyTedqzj._items[index].ANnyYrpgRHgHrBXsbJxMFrsUzupD = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return JVumbsEBLwXoIScIGdcjFXpsvVhTA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				JVumbsEBLwXoIScIGdcjFXpsvVhTA = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return jPrBZGcYMgwSnkuZDbumMqiJzKJf;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				jPrBZGcYMgwSnkuZDbumMqiJzKJf = value;
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
				return VclIzXqzjHdMOfpSsGrynyTedqzj._items[num].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
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

		bool ICollection.IsSynchronized => ((ICollection)VclIzXqzjHdMOfpSsGrynyTedqzj).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)VclIzXqzjHdMOfpSsGrynyTedqzj).SyncRoot;

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
			WmAgNYfZjnkCbGfevtYCeLCbMQfK = P_1;
			VclIzXqzjHdMOfpSsGrynyTedqzj = new AList<LWspuIkPfdrLaRPEWuTioQReLyDP>(P_0);
			pSbefWHNCObrZzUiitfQuANIGSjv = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.VclIzXqzjHdMOfpSsGrynyTedqzj._count; i++)
				{
					Add(indexedDictionary.VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN, indexedDictionary.VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD);
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
			return VclIzXqzjHdMOfpSsGrynyTedqzj._items[pSbefWHNCObrZzUiitfQuANIGSjv[key]].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!pSbefWHNCObrZzUiitfQuANIGSjv.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = VclIzXqzjHdMOfpSsGrynyTedqzj._items[value2].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)VclIzXqzjHdMOfpSsGrynyTedqzj._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return VclIzXqzjHdMOfpSsGrynyTedqzj[index].EqHcpXWaGauOvKqzuxjiUENyiiKN;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return VclIzXqzjHdMOfpSsGrynyTedqzj[pSbefWHNCObrZzUiitfQuANIGSjv[key]].OctrrQtCiiTFFrbGETLiMmHZIoiW();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)VclIzXqzjHdMOfpSsGrynyTedqzj._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return VclIzXqzjHdMOfpSsGrynyTedqzj[index].OctrrQtCiiTFFrbGETLiMmHZIoiW();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!pSbefWHNCObrZzUiitfQuANIGSjv.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = VclIzXqzjHdMOfpSsGrynyTedqzj[value].OctrrQtCiiTFFrbGETLiMmHZIoiW();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = pSbefWHNCObrZzUiitfQuANIGSjv.ContainsKey(key);
			if (num && !WmAgNYfZjnkCbGfevtYCeLCbMQfK)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int value2 = VclIzXqzjHdMOfpSsGrynyTedqzj.Add(new LWspuIkPfdrLaRPEWuTioQReLyDP(key, value));
			if (num)
			{
				pSbefWHNCObrZzUiitfQuANIGSjv[key] = value2;
			}
			else
			{
				pSbefWHNCObrZzUiitfQuANIGSjv.Add(key, value2);
			}
		}

		public void SetValue(TKey key, TValue value)
		{
			if (pSbefWHNCObrZzUiitfQuANIGSjv.TryGetValue(key, out var value2))
			{
				VclIzXqzjHdMOfpSsGrynyTedqzj._items[value2].ANnyYrpgRHgHrBXsbJxMFrsUzupD = value;
				pSbefWHNCObrZzUiitfQuANIGSjv[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			pSbefWHNCObrZzUiitfQuANIGSjv.Remove(key);
			if (WmAgNYfZjnkCbGfevtYCeLCbMQfK)
			{
				bool result = false;
				for (int num = VclIzXqzjHdMOfpSsGrynyTedqzj._count - 1; num >= 0; num--)
				{
					if (JVumbsEBLwXoIScIGdcjFXpsvVhTA.Equals(VclIzXqzjHdMOfpSsGrynyTedqzj._items[num].EqHcpXWaGauOvKqzuxjiUENyiiKN, key))
					{
						VclIzXqzjHdMOfpSsGrynyTedqzj.RemoveAt(num);
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
			if ((uint)index >= (uint)VclIzXqzjHdMOfpSsGrynyTedqzj._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey eqHcpXWaGauOvKqzuxjiUENyiiKN = VclIzXqzjHdMOfpSsGrynyTedqzj._items[index].EqHcpXWaGauOvKqzuxjiUENyiiKN;
			if (index < VclIzXqzjHdMOfpSsGrynyTedqzj._count - 1)
			{
				for (int i = index + 1; i < VclIzXqzjHdMOfpSsGrynyTedqzj.Count; i++)
				{
					pSbefWHNCObrZzUiitfQuANIGSjv[VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN] = i - 1;
				}
			}
			VclIzXqzjHdMOfpSsGrynyTedqzj.RemoveAt(index);
			pSbefWHNCObrZzUiitfQuANIGSjv.Remove(eqHcpXWaGauOvKqzuxjiUENyiiKN);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref VclIzXqzjHdMOfpSsGrynyTedqzj._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = VclIzXqzjHdMOfpSsGrynyTedqzj._count - 1; num2 >= 0; num2--)
			{
				_ = ref VclIzXqzjHdMOfpSsGrynyTedqzj._items[num2];
				if (jPrBZGcYMgwSnkuZDbumMqiJzKJf.Equals(VclIzXqzjHdMOfpSsGrynyTedqzj._items[num2].ANnyYrpgRHgHrBXsbJxMFrsUzupD, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!JajGGPAsdNXfDUdYsuMHgBoYAaEK && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = VclIzXqzjHdMOfpSsGrynyTedqzj._count;
			for (int i = 0; i < count; i++)
			{
				if (JVumbsEBLwXoIScIGdcjFXpsvVhTA.Equals(VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = VclIzXqzjHdMOfpSsGrynyTedqzj._count;
			for (int i = 0; i < count; i++)
			{
				if (jPrBZGcYMgwSnkuZDbumMqiJzKJf.Equals(VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return pSbefWHNCObrZzUiitfQuANIGSjv.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			VclIzXqzjHdMOfpSsGrynyTedqzj.Clear();
			pSbefWHNCObrZzUiitfQuANIGSjv.Clear();
		}

		public void TrimExcess()
		{
			VclIzXqzjHdMOfpSsGrynyTedqzj.TrimExcess();
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
			LWspuIkPfdrLaRPEWuTioQReLyDP lWspuIkPfdrLaRPEWuTioQReLyDP = VclIzXqzjHdMOfpSsGrynyTedqzj._items[num];
			return jPrBZGcYMgwSnkuZDbumMqiJzKJf.Equals(P_0.Value, lWspuIkPfdrLaRPEWuTioQReLyDP.ANnyYrpgRHgHrBXsbJxMFrsUzupD);
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
			int count = VclIzXqzjHdMOfpSsGrynyTedqzj._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN, VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD);
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			if (WmAgNYfZjnkCbGfevtYCeLCbMQfK)
			{
				bool result = false;
				for (int num = VclIzXqzjHdMOfpSsGrynyTedqzj._count - 1; num >= 0; num--)
				{
					LWspuIkPfdrLaRPEWuTioQReLyDP lWspuIkPfdrLaRPEWuTioQReLyDP = VclIzXqzjHdMOfpSsGrynyTedqzj._items[num];
					if (jPrBZGcYMgwSnkuZDbumMqiJzKJf.Equals(P_0.Value, lWspuIkPfdrLaRPEWuTioQReLyDP.ANnyYrpgRHgHrBXsbJxMFrsUzupD))
					{
						VclIzXqzjHdMOfpSsGrynyTedqzj.RemoveAt(num);
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
			LWspuIkPfdrLaRPEWuTioQReLyDP lWspuIkPfdrLaRPEWuTioQReLyDP2 = VclIzXqzjHdMOfpSsGrynyTedqzj._items[num2];
			if (!jPrBZGcYMgwSnkuZDbumMqiJzKJf.Equals(P_0.Value, lWspuIkPfdrLaRPEWuTioQReLyDP2.ANnyYrpgRHgHrBXsbJxMFrsUzupD))
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
			int count = VclIzXqzjHdMOfpSsGrynyTedqzj._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].EqHcpXWaGauOvKqzuxjiUENyiiKN, VclIzXqzjHdMOfpSsGrynyTedqzj._items[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD), index++);
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

		private int oopGXBOLFWlYyFeccShWLBwtSzt(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in oopGXBOLFWlYyFeccShWLBwtSzt
			return this.oopGXBOLFWlYyFeccShWLBwtSzt(P_0);
		}

		private bool drGGfFExRSonxdTcsfHrIXktIFggA(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in drGGfFExRSonxdTcsfHrIXktIFggA
			return this.drGGfFExRSonxdTcsfHrIXktIFggA(P_0);
		}
	}
}
