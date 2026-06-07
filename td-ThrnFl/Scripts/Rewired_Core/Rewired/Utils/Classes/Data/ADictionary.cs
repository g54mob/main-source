using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[DefaultMember("Item")]
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
			private ADictionary<TKey, TValue> sEbDQhJTAixqnjjatOvbHjDmjObjb;

			private int xqQBJkwyOdTncuyjwBJzoCsYXUSR;

			private int lSvUGFGuDuVFSPItFFDyNLTZJcmM;

			private KeyValuePair<TKey, TValue> iHeFlzEnZLDpWeIcDmivhpweJJEiC;

			private int nSSsuKMiIdaHRetgtpmzLIwbGxTcA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => iHeFlzEnZLDpWeIcDmivhpweJJEiC;

			object IEnumerator.Current
			{
				get
				{
					if (lSvUGFGuDuVFSPItFFDyNLTZJcmM == 0 || lSvUGFGuDuVFSPItFFDyNLTZJcmM == sEbDQhJTAixqnjjatOvbHjDmjObjb._count + 1)
					{
						throw new Exception();
					}
					if (nSSsuKMiIdaHRetgtpmzLIwbGxTcA == 1)
					{
						return new DictionaryEntry(iHeFlzEnZLDpWeIcDmivhpweJJEiC.Key, iHeFlzEnZLDpWeIcDmivhpweJJEiC.Value);
					}
					return new KeyValuePair<TKey, TValue>(iHeFlzEnZLDpWeIcDmivhpweJJEiC.Key, iHeFlzEnZLDpWeIcDmivhpweJJEiC.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (lSvUGFGuDuVFSPItFFDyNLTZJcmM == 0 || lSvUGFGuDuVFSPItFFDyNLTZJcmM == sEbDQhJTAixqnjjatOvbHjDmjObjb._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(iHeFlzEnZLDpWeIcDmivhpweJJEiC.Key, iHeFlzEnZLDpWeIcDmivhpweJJEiC.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (lSvUGFGuDuVFSPItFFDyNLTZJcmM == 0 || lSvUGFGuDuVFSPItFFDyNLTZJcmM == sEbDQhJTAixqnjjatOvbHjDmjObjb._count + 1)
					{
						throw new Exception();
					}
					return iHeFlzEnZLDpWeIcDmivhpweJJEiC.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (lSvUGFGuDuVFSPItFFDyNLTZJcmM == 0 || lSvUGFGuDuVFSPItFFDyNLTZJcmM == sEbDQhJTAixqnjjatOvbHjDmjObjb._count + 1)
					{
						throw new Exception();
					}
					return iHeFlzEnZLDpWeIcDmivhpweJJEiC.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				sEbDQhJTAixqnjjatOvbHjDmjObjb = P_0;
				xqQBJkwyOdTncuyjwBJzoCsYXUSR = P_0.FSxQQZtTHhKLPlXPwSluUnJypAcV;
				lSvUGFGuDuVFSPItFFDyNLTZJcmM = 0;
				nSSsuKMiIdaHRetgtpmzLIwbGxTcA = P_1;
				iHeFlzEnZLDpWeIcDmivhpweJJEiC = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (xqQBJkwyOdTncuyjwBJzoCsYXUSR != sEbDQhJTAixqnjjatOvbHjDmjObjb.FSxQQZtTHhKLPlXPwSluUnJypAcV)
				{
					throw new Exception();
				}
				while ((uint)lSvUGFGuDuVFSPItFFDyNLTZJcmM < (uint)sEbDQhJTAixqnjjatOvbHjDmjObjb._count)
				{
					if (sEbDQhJTAixqnjjatOvbHjDmjObjb._entries[lSvUGFGuDuVFSPItFFDyNLTZJcmM].hashCode >= 0)
					{
						iHeFlzEnZLDpWeIcDmivhpweJJEiC = new KeyValuePair<TKey, TValue>(sEbDQhJTAixqnjjatOvbHjDmjObjb._entries[lSvUGFGuDuVFSPItFFDyNLTZJcmM].key, sEbDQhJTAixqnjjatOvbHjDmjObjb._entries[lSvUGFGuDuVFSPItFFDyNLTZJcmM].value);
						lSvUGFGuDuVFSPItFFDyNLTZJcmM++;
						return true;
					}
					lSvUGFGuDuVFSPItFFDyNLTZJcmM++;
				}
				lSvUGFGuDuVFSPItFFDyNLTZJcmM = sEbDQhJTAixqnjjatOvbHjDmjObjb._count + 1;
				iHeFlzEnZLDpWeIcDmivhpweJJEiC = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			void IEnumerator.Reset()
			{
				if (xqQBJkwyOdTncuyjwBJzoCsYXUSR != sEbDQhJTAixqnjjatOvbHjDmjObjb.FSxQQZtTHhKLPlXPwSluUnJypAcV)
				{
					throw new Exception();
				}
				lSvUGFGuDuVFSPItFFDyNLTZJcmM = 0;
				iHeFlzEnZLDpWeIcDmivhpweJJEiC = default(KeyValuePair<TKey, TValue>);
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
				private ADictionary<TKey, TValue> znTxHyKuwGDXtjhjGsAvnsbRgEZA;

				private int rBJQmmHgSuhBQMNbhZzUaMkkstTV;

				private int GCuwCNeDseqUzEoJTIJIAqRHRHlWA;

				private TKey pMwQEsheTXZrfmAjkBvVFQevKVMf;

				TKey IEnumerator<TKey>.Current => pMwQEsheTXZrfmAjkBvVFQevKVMf;

				object IEnumerator.Current
				{
					get
					{
						if (rBJQmmHgSuhBQMNbhZzUaMkkstTV == 0 || rBJQmmHgSuhBQMNbhZzUaMkkstTV == znTxHyKuwGDXtjhjGsAvnsbRgEZA._count + 1)
						{
							throw new Exception();
						}
						return pMwQEsheTXZrfmAjkBvVFQevKVMf;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					znTxHyKuwGDXtjhjGsAvnsbRgEZA = P_0;
					GCuwCNeDseqUzEoJTIJIAqRHRHlWA = P_0.FSxQQZtTHhKLPlXPwSluUnJypAcV;
					rBJQmmHgSuhBQMNbhZzUaMkkstTV = 0;
					pMwQEsheTXZrfmAjkBvVFQevKVMf = default(TKey);
				}

				public void Dispose()
				{
				}

				void IDisposable.Dispose()
				{
					//ILSpy generated this explicit interface implementation from .override directive in Dispose
					this.Dispose();
				}

				public bool MoveNext()
				{
					if (GCuwCNeDseqUzEoJTIJIAqRHRHlWA != znTxHyKuwGDXtjhjGsAvnsbRgEZA.FSxQQZtTHhKLPlXPwSluUnJypAcV)
					{
						throw new Exception();
					}
					while ((uint)rBJQmmHgSuhBQMNbhZzUaMkkstTV < (uint)znTxHyKuwGDXtjhjGsAvnsbRgEZA._count)
					{
						if (znTxHyKuwGDXtjhjGsAvnsbRgEZA._entries[rBJQmmHgSuhBQMNbhZzUaMkkstTV].hashCode >= 0)
						{
							pMwQEsheTXZrfmAjkBvVFQevKVMf = znTxHyKuwGDXtjhjGsAvnsbRgEZA._entries[rBJQmmHgSuhBQMNbhZzUaMkkstTV].key;
							rBJQmmHgSuhBQMNbhZzUaMkkstTV++;
							return true;
						}
						rBJQmmHgSuhBQMNbhZzUaMkkstTV++;
					}
					rBJQmmHgSuhBQMNbhZzUaMkkstTV = znTxHyKuwGDXtjhjGsAvnsbRgEZA._count + 1;
					pMwQEsheTXZrfmAjkBvVFQevKVMf = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (GCuwCNeDseqUzEoJTIJIAqRHRHlWA != znTxHyKuwGDXtjhjGsAvnsbRgEZA.FSxQQZtTHhKLPlXPwSluUnJypAcV)
					{
						throw new Exception();
					}
					rBJQmmHgSuhBQMNbhZzUaMkkstTV = 0;
					pMwQEsheTXZrfmAjkBvVFQevKVMf = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> YbhKGEAQILBtHrvqABjvbhpKPCdOA;

			int ICollection<TKey>.Count => YbhKGEAQILBtHrvqABjvbhpKPCdOA.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)YbhKGEAQILBtHrvqABjvbhpKPCdOA).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				YbhKGEAQILBtHrvqABjvbhpKPCdOA = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(YbhKGEAQILBtHrvqABjvbhpKPCdOA);
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
				if (array.Length - index < YbhKGEAQILBtHrvqABjvbhpKPCdOA.Count)
				{
					throw new Exception();
				}
				int count = YbhKGEAQILBtHrvqABjvbhpKPCdOA._count;
				Entry[] entries = YbhKGEAQILBtHrvqABjvbhpKPCdOA._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void QrorKeLbaGaaxXKOHtKcLmGInUvN(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in QrorKeLbaGaaxXKOHtKcLmGInUvN
				this.QrorKeLbaGaaxXKOHtKcLmGInUvN(P_0);
			}

			private void PfdxBFLUrkkXMiuEbVkKrIqEfuTfA()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in PfdxBFLUrkkXMiuEbVkKrIqEfuTfA
				this.PfdxBFLUrkkXMiuEbVkKrIqEfuTfA();
			}

			private bool PABoFzjnQSVifvzXGDfxYBnwBkhU(TKey P_0)
			{
				return YbhKGEAQILBtHrvqABjvbhpKPCdOA.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in PABoFzjnQSVifvzXGDfxYBnwBkhU
				return this.PABoFzjnQSVifvzXGDfxYBnwBkhU(P_0);
			}

			private bool SMIMPjgvbmtnphaNXifdAqAsFDrh(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SMIMPjgvbmtnphaNXifdAqAsFDrh
				return this.SMIMPjgvbmtnphaNXifdAqAsFDrh(P_0);
			}

			private IEnumerator<TKey> zTjaLykatXGpKfWXKGhRZjlcEegMA()
			{
				return new Enumerator(YbhKGEAQILBtHrvqABjvbhpKPCdOA);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in zTjaLykatXGpKfWXKGhRZjlcEegMA
				return this.zTjaLykatXGpKfWXKGhRZjlcEegMA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(YbhKGEAQILBtHrvqABjvbhpKPCdOA);
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
				if (array.Length - index < YbhKGEAQILBtHrvqABjvbhpKPCdOA.Count)
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
				int count = YbhKGEAQILBtHrvqABjvbhpKPCdOA._count;
				Entry[] entries = YbhKGEAQILBtHrvqABjvbhpKPCdOA._entries;
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
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> mTHHWlSCleYYbnFVlbwqBsTqshRW;

				private int vLUlKlUaeSxwuoBHZGdnnIeAhRhz;

				private int EUZDHVqDZJgdmYGpljIDOXefuQPP;

				private TValue ANPWASJMGtDjIcdIpzofYpLqfhBd;

				TValue IEnumerator<TValue>.Current => ANPWASJMGtDjIcdIpzofYpLqfhBd;

				object IEnumerator.Current
				{
					get
					{
						if (vLUlKlUaeSxwuoBHZGdnnIeAhRhz == 0 || vLUlKlUaeSxwuoBHZGdnnIeAhRhz == mTHHWlSCleYYbnFVlbwqBsTqshRW._count + 1)
						{
							throw new Exception();
						}
						return ANPWASJMGtDjIcdIpzofYpLqfhBd;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					mTHHWlSCleYYbnFVlbwqBsTqshRW = P_0;
					EUZDHVqDZJgdmYGpljIDOXefuQPP = P_0.FSxQQZtTHhKLPlXPwSluUnJypAcV;
					vLUlKlUaeSxwuoBHZGdnnIeAhRhz = 0;
					ANPWASJMGtDjIcdIpzofYpLqfhBd = default(TValue);
				}

				public void Dispose()
				{
				}

				void IDisposable.Dispose()
				{
					//ILSpy generated this explicit interface implementation from .override directive in Dispose
					this.Dispose();
				}

				public bool MoveNext()
				{
					if (EUZDHVqDZJgdmYGpljIDOXefuQPP != mTHHWlSCleYYbnFVlbwqBsTqshRW.FSxQQZtTHhKLPlXPwSluUnJypAcV)
					{
						throw new Exception();
					}
					while ((uint)vLUlKlUaeSxwuoBHZGdnnIeAhRhz < (uint)mTHHWlSCleYYbnFVlbwqBsTqshRW._count)
					{
						if (mTHHWlSCleYYbnFVlbwqBsTqshRW._entries[vLUlKlUaeSxwuoBHZGdnnIeAhRhz].hashCode >= 0)
						{
							ANPWASJMGtDjIcdIpzofYpLqfhBd = mTHHWlSCleYYbnFVlbwqBsTqshRW._entries[vLUlKlUaeSxwuoBHZGdnnIeAhRhz].value;
							vLUlKlUaeSxwuoBHZGdnnIeAhRhz++;
							return true;
						}
						vLUlKlUaeSxwuoBHZGdnnIeAhRhz++;
					}
					vLUlKlUaeSxwuoBHZGdnnIeAhRhz = mTHHWlSCleYYbnFVlbwqBsTqshRW._count + 1;
					ANPWASJMGtDjIcdIpzofYpLqfhBd = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (EUZDHVqDZJgdmYGpljIDOXefuQPP != mTHHWlSCleYYbnFVlbwqBsTqshRW.FSxQQZtTHhKLPlXPwSluUnJypAcV)
					{
						throw new Exception();
					}
					vLUlKlUaeSxwuoBHZGdnnIeAhRhz = 0;
					ANPWASJMGtDjIcdIpzofYpLqfhBd = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> FDPWVGDPtbAtaEAtefIHtuklJbxR;

			int ICollection<TValue>.Count => FDPWVGDPtbAtaEAtefIHtuklJbxR.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)FDPWVGDPtbAtaEAtefIHtuklJbxR).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				FDPWVGDPtbAtaEAtefIHtuklJbxR = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(FDPWVGDPtbAtaEAtefIHtuklJbxR);
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
				if (array.Length - index < FDPWVGDPtbAtaEAtefIHtuklJbxR.Count)
				{
					throw new Exception();
				}
				int count = FDPWVGDPtbAtaEAtefIHtuklJbxR._count;
				Entry[] entries = FDPWVGDPtbAtaEAtefIHtuklJbxR._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void cDkNiMwauqlEcPtZIJfiZFNLqXoC(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in cDkNiMwauqlEcPtZIJfiZFNLqXoC
				this.cDkNiMwauqlEcPtZIJfiZFNLqXoC(P_0);
			}

			private bool hCYuXipduHiKBdPGndweFsaOqPbl(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hCYuXipduHiKBdPGndweFsaOqPbl
				return this.hCYuXipduHiKBdPGndweFsaOqPbl(P_0);
			}

			private void HmgPwayXqYtLnQPqNVbdtmssPeEh()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in HmgPwayXqYtLnQPqNVbdtmssPeEh
				this.HmgPwayXqYtLnQPqNVbdtmssPeEh();
			}

			private bool hFMpLVOSHvjbJaByLHQjRgkFfhRaA(TValue P_0)
			{
				return FDPWVGDPtbAtaEAtefIHtuklJbxR.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hFMpLVOSHvjbJaByLHQjRgkFfhRaA
				return this.hFMpLVOSHvjbJaByLHQjRgkFfhRaA(P_0);
			}

			private IEnumerator<TValue> rKmlkMtwbJfzKRKvkFHJqbitnqsB()
			{
				return new Enumerator(FDPWVGDPtbAtaEAtefIHtuklJbxR);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in rKmlkMtwbJfzKRKvkFHJqbitnqsB
				return this.rKmlkMtwbJfzKRKvkFHJqbitnqsB();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(FDPWVGDPtbAtaEAtefIHtuklJbxR);
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
				if (array.Length - index < FDPWVGDPtbAtaEAtefIHtuklJbxR.Count)
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
				int count = FDPWVGDPtbAtaEAtefIHtuklJbxR._count;
				Entry[] entries = FDPWVGDPtbAtaEAtefIHtuklJbxR._entries;
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

		private int[] XrKlebVHeTQARzhnfKHjzeGSOJHe;

		internal Entry[] _entries;

		internal int _count;

		private int FSxQQZtTHhKLPlXPwSluUnJypAcV;

		private int UraWOHPiClnUHGQRvVGxRHsLpXHF;

		private int MXBypMcAbxifQivDnwUWjGcLJUlY;

		private int GHEcgXFVhWggfropxjyOUZUvhNrQ;

		private IEqualityComparer<TKey> VXeZARhfWcKTtQIQbgFxbaNFjtXw;

		private IEqualityComparer<TValue> pgpPAdSPcilqIMZmPSuqxYSNroyx;

		private KeyCollection zaGntmOfsZICFLPcuWuXOAklClSn;

		private ValueCollection sQXdCbzrsoVTJmaeCBqRboYEqPIo;

		private readonly object bitqVvsJjfQaQSZqtuXSQLLtHacL = new object();

		private static readonly bool bgtWcjEpgZcrZHjkPlOathmyZkYc = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool HaCDNhGuPjdoOBMCPUgtJxIClLy = ReflectionTools.IsValueType(typeof(TValue));

		private const string wMZpvIMFcBdhqFSnajkFKZTQpxrF = "Version";

		private const string yniGPcfrhFAXvtlerizzVILBEdSUA = "HashSize";

		private const string ntHaSGjeEzcbjffjlMLqcxcCOoSFA = "KeyValuePairs";

		private const string PwQVrAKUGJrHMGiILgCbcCgTvEpz = "Comparer";

		int ICollection.Count => _count - GHEcgXFVhWggfropxjyOUZUvhNrQ;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (zaGntmOfsZICFLPcuWuXOAklClSn == null)
				{
					zaGntmOfsZICFLPcuWuXOAklClSn = new KeyCollection(this);
				}
				return zaGntmOfsZICFLPcuWuXOAklClSn;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (sQXdCbzrsoVTJmaeCBqRboYEqPIo == null)
				{
					sQXdCbzrsoVTJmaeCBqRboYEqPIo = new ValueCollection(this);
				}
				return sQXdCbzrsoVTJmaeCBqRboYEqPIo;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return VXeZARhfWcKTtQIQbgFxbaNFjtXw;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				VXeZARhfWcKTtQIQbgFxbaNFjtXw = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return pgpPAdSPcilqIMZmPSuqxYSNroyx;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				pgpPAdSPcilqIMZmPSuqxYSNroyx = value;
			}
		}

		TValue IDictionary<TKey, TValue>.this[TKey key]
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
				pBHTfvAEtbgubdLSdQCZgaFhNAjcB(key, value, false);
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
				if (zaGntmOfsZICFLPcuWuXOAklClSn == null)
				{
					zaGntmOfsZICFLPcuWuXOAklClSn = new KeyCollection(this);
				}
				return zaGntmOfsZICFLPcuWuXOAklClSn;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (sQXdCbzrsoVTJmaeCBqRboYEqPIo == null)
				{
					sQXdCbzrsoVTJmaeCBqRboYEqPIo = new ValueCollection(this);
				}
				return sQXdCbzrsoVTJmaeCBqRboYEqPIo;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => bitqVvsJjfQaQSZqtuXSQLLtHacL;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (NdhOPjqwOvmygGVLkqJimlBueCGL(key))
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
				ZDWfqoejIEalNEssgoiDmziIvvmec<TValue>(value, "value");
				try
				{
					TKey val = (TKey)key;
					try
					{
						this[val] = (TValue)value;
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

		ICollection<TKey> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

		ICollection<TValue> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Values => Values;

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
				mbBfHPMhycRgsAhSYIGJfSyHgDxJ(P_0);
			}
			VXeZARhfWcKTtQIQbgFxbaNFjtXw = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			pgpPAdSPcilqIMZmPSuqxYSNroyx = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
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
			pBHTfvAEtbgubdLSdQCZgaFhNAjcB(key, value, true);
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void Clear()
		{
			if (_count > 0)
			{
				for (int i = 0; i < XrKlebVHeTQARzhnfKHjzeGSOJHe.Length; i++)
				{
					XrKlebVHeTQARzhnfKHjzeGSOJHe[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				MXBypMcAbxifQivDnwUWjGcLJUlY = -1;
				_count = 0;
				GHEcgXFVhWggfropxjyOUZUvhNrQ = 0;
				FSxQQZtTHhKLPlXPwSluUnJypAcV++;
				UraWOHPiClnUHGQRvVGxRHsLpXHF++;
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		void IDictionary.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOfKey(key) >= 0;
		}

		bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
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
			if (!bgtWcjEpgZcrZHjkPlOathmyZkYc && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (XrKlebVHeTQARzhnfKHjzeGSOJHe != null)
			{
				int num = VXeZARhfWcKTtQIQbgFxbaNFjtXw.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % XrKlebVHeTQARzhnfKHjzeGSOJHe.Length;
				int num3 = -1;
				for (int num4 = XrKlebVHeTQARzhnfKHjzeGSOJHe[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && VXeZARhfWcKTtQIQbgFxbaNFjtXw.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							XrKlebVHeTQARzhnfKHjzeGSOJHe[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = MXBypMcAbxifQivDnwUWjGcLJUlY;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						MXBypMcAbxifQivDnwUWjGcLJUlY = num4;
						GHEcgXFVhWggfropxjyOUZUvhNrQ++;
						FSxQQZtTHhKLPlXPwSluUnJypAcV++;
						return true;
					}
					num3 = num4;
				}
			}
			return false;
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Remove
			return this.Remove(key);
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

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
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
			if (!bgtWcjEpgZcrZHjkPlOathmyZkYc && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (XrKlebVHeTQARzhnfKHjzeGSOJHe != null)
			{
				int num = VXeZARhfWcKTtQIQbgFxbaNFjtXw.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = XrKlebVHeTQARzhnfKHjzeGSOJHe[num % XrKlebVHeTQARzhnfKHjzeGSOJHe.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && VXeZARhfWcKTtQIQbgFxbaNFjtXw.Equals(_entries[num2].key, key))
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
			if (!HaCDNhGuPjdoOBMCPUgtJxIClLy && value == null)
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
				IEqualityComparer<TValue> equalityComparer = pgpPAdSPcilqIMZmPSuqxYSNroyx;
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
			if (array.Length - index < this.Count)
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

		private void mbBfHPMhycRgsAhSYIGJfSyHgDxJ(int P_0)
		{
			int num = rGODiqhjHypoKHqXuUJkGuArgzbz.sxddyTCZhYbUtXpYGkXyCVwiTGJeA(P_0);
			XrKlebVHeTQARzhnfKHjzeGSOJHe = new int[num];
			for (int i = 0; i < XrKlebVHeTQARzhnfKHjzeGSOJHe.Length; i++)
			{
				XrKlebVHeTQARzhnfKHjzeGSOJHe[i] = -1;
			}
			_entries = new Entry[num];
			MXBypMcAbxifQivDnwUWjGcLJUlY = -1;
		}

		private void pBHTfvAEtbgubdLSdQCZgaFhNAjcB(TKey P_0, TValue P_1, bool P_2)
		{
			if (!bgtWcjEpgZcrZHjkPlOathmyZkYc && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (XrKlebVHeTQARzhnfKHjzeGSOJHe == null)
			{
				mbBfHPMhycRgsAhSYIGJfSyHgDxJ(0);
			}
			int num = VXeZARhfWcKTtQIQbgFxbaNFjtXw.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % XrKlebVHeTQARzhnfKHjzeGSOJHe.Length;
			for (int num3 = XrKlebVHeTQARzhnfKHjzeGSOJHe[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && VXeZARhfWcKTtQIQbgFxbaNFjtXw.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					FSxQQZtTHhKLPlXPwSluUnJypAcV++;
					return;
				}
			}
			int num4;
			if (GHEcgXFVhWggfropxjyOUZUvhNrQ > 0)
			{
				num4 = MXBypMcAbxifQivDnwUWjGcLJUlY;
				MXBypMcAbxifQivDnwUWjGcLJUlY = _entries[num4].next;
				GHEcgXFVhWggfropxjyOUZUvhNrQ--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					vAJfvhKUuKEpqOLzTcsvEIVXFKcgb();
					num2 = num % XrKlebVHeTQARzhnfKHjzeGSOJHe.Length;
				}
				num4 = _count;
				_count++;
			}
			_entries[num4].hashCode = num;
			_entries[num4].next = XrKlebVHeTQARzhnfKHjzeGSOJHe[num2];
			_entries[num4].key = P_0;
			_entries[num4].value = P_1;
			XrKlebVHeTQARzhnfKHjzeGSOJHe[num2] = num4;
			FSxQQZtTHhKLPlXPwSluUnJypAcV++;
			UraWOHPiClnUHGQRvVGxRHsLpXHF++;
		}

		private void vAJfvhKUuKEpqOLzTcsvEIVXFKcgb()
		{
			zWmnbXkIVDbRvZArmEZCdDMhlFXLA(rGODiqhjHypoKHqXuUJkGuArgzbz.AeYHQtdPDZbwebUYhmdFkTlYflPN(_count), false);
		}

		private void zWmnbXkIVDbRvZArmEZCdDMhlFXLA(int P_0, bool P_1)
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
						array2[j].hashCode = VXeZARhfWcKTtQIQbgFxbaNFjtXw.GetHashCode(array2[j].key) & 0x7FFFFFFF;
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
			XrKlebVHeTQARzhnfKHjzeGSOJHe = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> lTywrdsURKNkRVbIsYupBcUEcTcBA()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lTywrdsURKNkRVbIsYupBcUEcTcBA
			return this.lTywrdsURKNkRVbIsYupBcUEcTcBA();
		}

		private void lZAKfPBQmcCQUyObxwfiUliNskow(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lZAKfPBQmcCQUyObxwfiUliNskow
			this.lZAKfPBQmcCQUyObxwfiUliNskow(P_0);
		}

		private bool bVfDZceQLkwpaCPSPMbVnAqdABABb(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && pgpPAdSPcilqIMZmPSuqxYSNroyx.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bVfDZceQLkwpaCPSPMbVnAqdABABb
			return this.bVfDZceQLkwpaCPSPMbVnAqdABABb(P_0);
		}

		private bool nFsiGfhpFHPBbnqnUKiUcYHCCCiiB(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && pgpPAdSPcilqIMZmPSuqxYSNroyx.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nFsiGfhpFHPBbnqnUKiUcYHCCCiiB
			return this.nFsiGfhpFHPBbnqnUKiUcYHCCCiiB(P_0);
		}

		private void MDECPTXDnpBmZiinQOTMNMsiROqR(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MDECPTXDnpBmZiinQOTMNMsiROqR
			this.MDECPTXDnpBmZiinQOTMNMsiROqR(P_0, P_1);
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
			if (array.Length - index < this.Count)
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
			ZDWfqoejIEalNEssgoiDmziIvvmec<TValue>(value, "value");
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
			if (NdhOPjqwOvmygGVLkqJimlBueCGL(key))
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
			if (NdhOPjqwOvmygGVLkqJimlBueCGL(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool NdhOPjqwOvmygGVLkqJimlBueCGL(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void ZDWfqoejIEalNEssgoiDmziIvvmec<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
