using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct HwxfgkOzgFSwtoJuNAtdGMHpXwrC
		{
			public TKey AwXArdMDHeMZOGmaWWZvyKQKgTmm;

			public TValue UWgTtVXTweYDODigOiZQMbcDdOhjA;

			public HwxfgkOzgFSwtoJuNAtdGMHpXwrC(TKey P_0, TValue P_1)
			{
				AwXArdMDHeMZOGmaWWZvyKQKgTmm = P_0;
				UWgTtVXTweYDODigOiZQMbcDdOhjA = P_1;
			}

			public KeyValuePair<TKey, TValue> ejkszqkPNWIronEfLAqIatgvuggH()
			{
				return new KeyValuePair<TKey, TValue>(AwXArdMDHeMZOGmaWWZvyKQKgTmm, UWgTtVXTweYDODigOiZQMbcDdOhjA);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> crRFNCcLzPfVDCnFtGcdGUReSgKRB;

			private int IxKsSPzjsSDwPnEfYLFjMmTtBgsj;

			private int IJbEzCfrSgmdlMOdQdKmTWkFNaTdA;

			private KeyValuePair<TKey, TValue> YpVHENjbNvFubitLflfWiytjjyJgA;

			private int SaZPqDyGcIAxoLRvQMmljeFZbBDGA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => YpVHENjbNvFubitLflfWiytjjyJgA;

			object IEnumerator.Current
			{
				get
				{
					if (IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == 0 || IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1)
					{
						throw new Exception();
					}
					if (SaZPqDyGcIAxoLRvQMmljeFZbBDGA == 1)
					{
						return new DictionaryEntry(YpVHENjbNvFubitLflfWiytjjyJgA.Key, YpVHENjbNvFubitLflfWiytjjyJgA.Value);
					}
					return new KeyValuePair<TKey, TValue>(YpVHENjbNvFubitLflfWiytjjyJgA.Key, YpVHENjbNvFubitLflfWiytjjyJgA.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == 0 || IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(YpVHENjbNvFubitLflfWiytjjyJgA.Key, YpVHENjbNvFubitLflfWiytjjyJgA.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == 0 || IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1)
					{
						throw new Exception();
					}
					return YpVHENjbNvFubitLflfWiytjjyJgA.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == 0 || IJbEzCfrSgmdlMOdQdKmTWkFNaTdA == crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1)
					{
						throw new Exception();
					}
					return YpVHENjbNvFubitLflfWiytjjyJgA.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				crRFNCcLzPfVDCnFtGcdGUReSgKRB = P_0;
				IxKsSPzjsSDwPnEfYLFjMmTtBgsj = P_0.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version;
				IJbEzCfrSgmdlMOdQdKmTWkFNaTdA = 0;
				SaZPqDyGcIAxoLRvQMmljeFZbBDGA = P_1;
				YpVHENjbNvFubitLflfWiytjjyJgA = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (IxKsSPzjsSDwPnEfYLFjMmTtBgsj != crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version)
				{
					throw new Exception();
				}
				if ((uint)IJbEzCfrSgmdlMOdQdKmTWkFNaTdA < (uint)crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
				{
					YpVHENjbNvFubitLflfWiytjjyJgA = new KeyValuePair<TKey, TValue>(crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[IJbEzCfrSgmdlMOdQdKmTWkFNaTdA].AwXArdMDHeMZOGmaWWZvyKQKgTmm, crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[IJbEzCfrSgmdlMOdQdKmTWkFNaTdA].UWgTtVXTweYDODigOiZQMbcDdOhjA);
					IJbEzCfrSgmdlMOdQdKmTWkFNaTdA++;
					return true;
				}
				IJbEzCfrSgmdlMOdQdKmTWkFNaTdA = crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1;
				YpVHENjbNvFubitLflfWiytjjyJgA = default(KeyValuePair<TKey, TValue>);
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
				if (IxKsSPzjsSDwPnEfYLFjMmTtBgsj != crRFNCcLzPfVDCnFtGcdGUReSgKRB.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version)
				{
					throw new Exception();
				}
				IJbEzCfrSgmdlMOdQdKmTWkFNaTdA = 0;
				YpVHENjbNvFubitLflfWiytjjyJgA = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> nkvxrEdGJblqWtMjVSthjzGJwmJs;

				private int ipwxErIeEkJTxsrpxiWiJZCDWVCR;

				private int TOdBzXmVfFukvPIRhcIbOhhfSBFq;

				private TKey mNKIsFVAVhCqJhtrzIaOdNQtnGcIb;

				TKey IEnumerator<TKey>.Current => mNKIsFVAVhCqJhtrzIaOdNQtnGcIb;

				object IEnumerator.Current
				{
					get
					{
						if (ipwxErIeEkJTxsrpxiWiJZCDWVCR == 0 || ipwxErIeEkJTxsrpxiWiJZCDWVCR == nkvxrEdGJblqWtMjVSthjzGJwmJs.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1)
						{
							throw new Exception();
						}
						return mNKIsFVAVhCqJhtrzIaOdNQtnGcIb;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					nkvxrEdGJblqWtMjVSthjzGJwmJs = P_0;
					TOdBzXmVfFukvPIRhcIbOhhfSBFq = P_0.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version;
					ipwxErIeEkJTxsrpxiWiJZCDWVCR = 0;
					mNKIsFVAVhCqJhtrzIaOdNQtnGcIb = default(TKey);
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
					if (TOdBzXmVfFukvPIRhcIbOhhfSBFq != nkvxrEdGJblqWtMjVSthjzGJwmJs.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version)
					{
						throw new Exception();
					}
					if ((uint)ipwxErIeEkJTxsrpxiWiJZCDWVCR < (uint)nkvxrEdGJblqWtMjVSthjzGJwmJs.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
					{
						mNKIsFVAVhCqJhtrzIaOdNQtnGcIb = nkvxrEdGJblqWtMjVSthjzGJwmJs.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[ipwxErIeEkJTxsrpxiWiJZCDWVCR].AwXArdMDHeMZOGmaWWZvyKQKgTmm;
						ipwxErIeEkJTxsrpxiWiJZCDWVCR++;
						return true;
					}
					ipwxErIeEkJTxsrpxiWiJZCDWVCR = nkvxrEdGJblqWtMjVSthjzGJwmJs.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1;
					mNKIsFVAVhCqJhtrzIaOdNQtnGcIb = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (TOdBzXmVfFukvPIRhcIbOhhfSBFq != nkvxrEdGJblqWtMjVSthjzGJwmJs.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version)
					{
						throw new Exception();
					}
					ipwxErIeEkJTxsrpxiWiJZCDWVCR = 0;
					mNKIsFVAVhCqJhtrzIaOdNQtnGcIb = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> KIsMXBHtNNBISmESEayWNmtGjKQg;

			int ICollection<TKey>.Count => KIsMXBHtNNBISmESEayWNmtGjKQg.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)KIsMXBHtNNBISmESEayWNmtGjKQg).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				KIsMXBHtNNBISmESEayWNmtGjKQg = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(KIsMXBHtNNBISmESEayWNmtGjKQg);
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
				if (array.Length - index < KIsMXBHtNNBISmESEayWNmtGjKQg.Count)
				{
					throw new Exception();
				}
				int count = KIsMXBHtNNBISmESEayWNmtGjKQg.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
				HwxfgkOzgFSwtoJuNAtdGMHpXwrC[] items = KIsMXBHtNNBISmESEayWNmtGjKQg.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void kMGAagJVMbXsCuRnGkZPLzghPIYBA(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in kMGAagJVMbXsCuRnGkZPLzghPIYBA
				this.kMGAagJVMbXsCuRnGkZPLzghPIYBA(P_0);
			}

			private void MHvGqrLKITRgMsoJDhhwZtqduQNb()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MHvGqrLKITRgMsoJDhhwZtqduQNb
				this.MHvGqrLKITRgMsoJDhhwZtqduQNb();
			}

			private bool eqMFCdaGSNIVLspeyaRlMLvmVZYl(TKey P_0)
			{
				return KIsMXBHtNNBISmESEayWNmtGjKQg.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in eqMFCdaGSNIVLspeyaRlMLvmVZYl
				return this.eqMFCdaGSNIVLspeyaRlMLvmVZYl(P_0);
			}

			private bool hIFXGfEekMphVsfttmrtyPcHhdJq(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hIFXGfEekMphVsfttmrtyPcHhdJq
				return this.hIFXGfEekMphVsfttmrtyPcHhdJq(P_0);
			}

			private IEnumerator<TKey> NqemZTiorjMJQHcZPyolzdDGqbsj()
			{
				return new Enumerator(KIsMXBHtNNBISmESEayWNmtGjKQg);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in NqemZTiorjMJQHcZPyolzdDGqbsj
				return this.NqemZTiorjMJQHcZPyolzdDGqbsj();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(KIsMXBHtNNBISmESEayWNmtGjKQg);
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
				if (array.Length - index < KIsMXBHtNNBISmESEayWNmtGjKQg.Count)
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
				int count = KIsMXBHtNNBISmESEayWNmtGjKQg.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
				HwxfgkOzgFSwtoJuNAtdGMHpXwrC[] items = KIsMXBHtNNBISmESEayWNmtGjKQg.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm;
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
				private IndexedDictionary<TKey, TValue> csVChuJVuYqCyiXvedrMuGFuDkJFB;

				private int pzOFOTRllnCsBYaTfaNnZjNknLgQ;

				private int MyuPShSeNVMTANOhcevLnMHxiWxP;

				private TValue jVIjxJsFhqzhqpCXBilSLNTZmpRG;

				TValue IEnumerator<TValue>.Current => jVIjxJsFhqzhqpCXBilSLNTZmpRG;

				object IEnumerator.Current
				{
					get
					{
						if (pzOFOTRllnCsBYaTfaNnZjNknLgQ == 0 || pzOFOTRllnCsBYaTfaNnZjNknLgQ == csVChuJVuYqCyiXvedrMuGFuDkJFB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1)
						{
							throw new Exception();
						}
						return jVIjxJsFhqzhqpCXBilSLNTZmpRG;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					csVChuJVuYqCyiXvedrMuGFuDkJFB = P_0;
					MyuPShSeNVMTANOhcevLnMHxiWxP = P_0.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version;
					pzOFOTRllnCsBYaTfaNnZjNknLgQ = 0;
					jVIjxJsFhqzhqpCXBilSLNTZmpRG = default(TValue);
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
					if (MyuPShSeNVMTANOhcevLnMHxiWxP != csVChuJVuYqCyiXvedrMuGFuDkJFB.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version)
					{
						throw new Exception();
					}
					if ((uint)pzOFOTRllnCsBYaTfaNnZjNknLgQ < (uint)csVChuJVuYqCyiXvedrMuGFuDkJFB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
					{
						jVIjxJsFhqzhqpCXBilSLNTZmpRG = csVChuJVuYqCyiXvedrMuGFuDkJFB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[pzOFOTRllnCsBYaTfaNnZjNknLgQ].UWgTtVXTweYDODigOiZQMbcDdOhjA;
						pzOFOTRllnCsBYaTfaNnZjNknLgQ++;
						return true;
					}
					pzOFOTRllnCsBYaTfaNnZjNknLgQ = csVChuJVuYqCyiXvedrMuGFuDkJFB.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count + 1;
					jVIjxJsFhqzhqpCXBilSLNTZmpRG = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (MyuPShSeNVMTANOhcevLnMHxiWxP != csVChuJVuYqCyiXvedrMuGFuDkJFB.TKhEFquLhqxIHfoTlpwnZBenTtrQ.Version)
					{
						throw new Exception();
					}
					pzOFOTRllnCsBYaTfaNnZjNknLgQ = 0;
					jVIjxJsFhqzhqpCXBilSLNTZmpRG = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> rfAiSnDWIihnUwCJoORsxvhmShqe;

			int ICollection<TValue>.Count => rfAiSnDWIihnUwCJoORsxvhmShqe.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)rfAiSnDWIihnUwCJoORsxvhmShqe).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				rfAiSnDWIihnUwCJoORsxvhmShqe = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(rfAiSnDWIihnUwCJoORsxvhmShqe);
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
				if (array.Length - index < rfAiSnDWIihnUwCJoORsxvhmShqe.Count)
				{
					throw new Exception();
				}
				int count = rfAiSnDWIihnUwCJoORsxvhmShqe.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
				HwxfgkOzgFSwtoJuNAtdGMHpXwrC[] items = rfAiSnDWIihnUwCJoORsxvhmShqe.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].UWgTtVXTweYDODigOiZQMbcDdOhjA;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void NwrqEPMzxrFLIcdiMLxsBfrkjzZb(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in NwrqEPMzxrFLIcdiMLxsBfrkjzZb
				this.NwrqEPMzxrFLIcdiMLxsBfrkjzZb(P_0);
			}

			private bool WhMoeDgCcQAikEZZflKUugOOQCPA(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in WhMoeDgCcQAikEZZflKUugOOQCPA
				return this.WhMoeDgCcQAikEZZflKUugOOQCPA(P_0);
			}

			private void SEtiJEnLuCrlBfePTgWiEUyHNpsGb()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in SEtiJEnLuCrlBfePTgWiEUyHNpsGb
				this.SEtiJEnLuCrlBfePTgWiEUyHNpsGb();
			}

			private bool ftWlEVfHlRrsGpfekcjvCrmmKIhDA(TValue P_0)
			{
				return rfAiSnDWIihnUwCJoORsxvhmShqe.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ftWlEVfHlRrsGpfekcjvCrmmKIhDA
				return this.ftWlEVfHlRrsGpfekcjvCrmmKIhDA(P_0);
			}

			private IEnumerator<TValue> fYzkARVpfMHzExpkDbmZDrdfBRpZ()
			{
				return new Enumerator(rfAiSnDWIihnUwCJoORsxvhmShqe);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in fYzkARVpfMHzExpkDbmZDrdfBRpZ
				return this.fYzkARVpfMHzExpkDbmZDrdfBRpZ();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(rfAiSnDWIihnUwCJoORsxvhmShqe);
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
				if (array.Length - index < rfAiSnDWIihnUwCJoORsxvhmShqe.Count)
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
				int count = rfAiSnDWIihnUwCJoORsxvhmShqe.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
				HwxfgkOzgFSwtoJuNAtdGMHpXwrC[] items = rfAiSnDWIihnUwCJoORsxvhmShqe.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].UWgTtVXTweYDODigOiZQMbcDdOhjA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool EMOEcLxJLEoDrXJAmHdYvTEivHmO = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool uoIimLaudhUffAgpZcpBiKugjfer = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> bAnrvCZrCUHjNdJEOIBTHEYPWdUo = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> JUcbpWbgevwhRHqPdoGrNhrERLZM = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<HwxfgkOzgFSwtoJuNAtdGMHpXwrC> TKhEFquLhqxIHfoTlpwnZBenTtrQ;

		private readonly ADictionary<TKey, int> jUWWjCfGtvgqVOaexOjAtACiMxvc;

		private bool RypZsBULdQAwkKlcsBOhGqqGFriab;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!RypZsBULdQAwkKlcsBOhGqqGFriab)
				{
					return false;
				}
				return jUWWjCfGtvgqVOaexOjAtACiMxvc._count < TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return RypZsBULdQAwkKlcsBOhGqqGFriab;
			}
			set
			{
				if (RypZsBULdQAwkKlcsBOhGqqGFriab != value)
				{
					RypZsBULdQAwkKlcsBOhGqqGFriab = value;
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
				if ((uint)index >= (uint)TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[index].UWgTtVXTweYDODigOiZQMbcDdOhjA;
			}
			set
			{
				if ((uint)index >= (uint)TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[index].UWgTtVXTweYDODigOiZQMbcDdOhjA = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return bAnrvCZrCUHjNdJEOIBTHEYPWdUo;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				bAnrvCZrCUHjNdJEOIBTHEYPWdUo = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return JUcbpWbgevwhRHqPdoGrNhrERLZM;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				JUcbpWbgevwhRHqPdoGrNhrERLZM = value;
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys => new KeyCollection(this);

		ICollection<TValue> IDictionary<TKey, TValue>.Values => new ValueCollection(this);

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
				return TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num].UWgTtVXTweYDODigOiZQMbcDdOhjA;
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

		bool ICollection.IsSynchronized => ((ICollection)TKhEFquLhqxIHfoTlpwnZBenTtrQ).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)TKhEFquLhqxIHfoTlpwnZBenTtrQ).SyncRoot;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int P_0] => this[P_0];

		int IReadOnlyList.Count => this.Count;

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
			RypZsBULdQAwkKlcsBOhGqqGFriab = P_1;
			TKhEFquLhqxIHfoTlpwnZBenTtrQ = new AList<HwxfgkOzgFSwtoJuNAtdGMHpXwrC>(P_0);
			jUWWjCfGtvgqVOaexOjAtACiMxvc = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.TKhEFquLhqxIHfoTlpwnZBenTtrQ._count; i++)
				{
					Add(indexedDictionary.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm, indexedDictionary.TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].UWgTtVXTweYDODigOiZQMbcDdOhjA);
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
			return TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[jUWWjCfGtvgqVOaexOjAtACiMxvc[key]].UWgTtVXTweYDODigOiZQMbcDdOhjA;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!jUWWjCfGtvgqVOaexOjAtACiMxvc.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[value2].UWgTtVXTweYDODigOiZQMbcDdOhjA;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<HwxfgkOzgFSwtoJuNAtdGMHpXwrC, _003F>.HwxfgkOzgFSwtoJuNAtdGMHpXwrC>)(object)TKhEFquLhqxIHfoTlpwnZBenTtrQ)[index].AwXArdMDHeMZOGmaWWZvyKQKgTmm;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<HwxfgkOzgFSwtoJuNAtdGMHpXwrC, _003F>.HwxfgkOzgFSwtoJuNAtdGMHpXwrC>)(object)TKhEFquLhqxIHfoTlpwnZBenTtrQ)[jUWWjCfGtvgqVOaexOjAtACiMxvc[key]].ejkszqkPNWIronEfLAqIatgvuggH();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<HwxfgkOzgFSwtoJuNAtdGMHpXwrC, _003F>.HwxfgkOzgFSwtoJuNAtdGMHpXwrC>)(object)TKhEFquLhqxIHfoTlpwnZBenTtrQ)[index].ejkszqkPNWIronEfLAqIatgvuggH();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!jUWWjCfGtvgqVOaexOjAtACiMxvc.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<HwxfgkOzgFSwtoJuNAtdGMHpXwrC, _003F>.HwxfgkOzgFSwtoJuNAtdGMHpXwrC>)(object)TKhEFquLhqxIHfoTlpwnZBenTtrQ)[value].ejkszqkPNWIronEfLAqIatgvuggH();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = jUWWjCfGtvgqVOaexOjAtACiMxvc.ContainsKey(key);
			if (num && !RypZsBULdQAwkKlcsBOhGqqGFriab)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = TKhEFquLhqxIHfoTlpwnZBenTtrQ.Add(new HwxfgkOzgFSwtoJuNAtdGMHpXwrC(key, value));
			if (num)
			{
				jUWWjCfGtvgqVOaexOjAtACiMxvc[key] = num2;
			}
			else
			{
				jUWWjCfGtvgqVOaexOjAtACiMxvc.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (jUWWjCfGtvgqVOaexOjAtACiMxvc.TryGetValue(key, out var value2))
			{
				TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[value2].UWgTtVXTweYDODigOiZQMbcDdOhjA = value;
				jUWWjCfGtvgqVOaexOjAtACiMxvc[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			jUWWjCfGtvgqVOaexOjAtACiMxvc.Remove(key);
			if (RypZsBULdQAwkKlcsBOhGqqGFriab)
			{
				bool result = false;
				for (int num = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count - 1; num >= 0; num--)
				{
					if (bAnrvCZrCUHjNdJEOIBTHEYPWdUo.Equals(TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num].AwXArdMDHeMZOGmaWWZvyKQKgTmm, key))
					{
						TKhEFquLhqxIHfoTlpwnZBenTtrQ.RemoveAt(num);
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

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Remove
			return this.Remove(key);
		}

		public void RemoveAt(int index)
		{
			if ((uint)index >= (uint)TKhEFquLhqxIHfoTlpwnZBenTtrQ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey awXArdMDHeMZOGmaWWZvyKQKgTmm = TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[index].AwXArdMDHeMZOGmaWWZvyKQKgTmm;
			if (index < TKhEFquLhqxIHfoTlpwnZBenTtrQ._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<HwxfgkOzgFSwtoJuNAtdGMHpXwrC, _003F>.HwxfgkOzgFSwtoJuNAtdGMHpXwrC>)(object)TKhEFquLhqxIHfoTlpwnZBenTtrQ).Count; i++)
				{
					jUWWjCfGtvgqVOaexOjAtACiMxvc[TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm] = i - 1;
				}
			}
			TKhEFquLhqxIHfoTlpwnZBenTtrQ.RemoveAt(index);
			jUWWjCfGtvgqVOaexOjAtACiMxvc.Remove(awXArdMDHeMZOGmaWWZvyKQKgTmm);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count - 1; num2 >= 0; num2--)
			{
				_ = ref TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num2];
				if (JUcbpWbgevwhRHqPdoGrNhrERLZM.Equals(TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num2].UWgTtVXTweYDODigOiZQMbcDdOhjA, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!EMOEcLxJLEoDrXJAmHdYvTEivHmO && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
			for (int i = 0; i < count; i++)
			{
				if (bAnrvCZrCUHjNdJEOIBTHEYPWdUo.Equals(TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
			for (int i = 0; i < count; i++)
			{
				if (JUcbpWbgevwhRHqPdoGrNhrERLZM.Equals(TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].UWgTtVXTweYDODigOiZQMbcDdOhjA, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return jUWWjCfGtvgqVOaexOjAtACiMxvc.ContainsKey(key);
		}

		bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			TKhEFquLhqxIHfoTlpwnZBenTtrQ.Clear();
			jUWWjCfGtvgqVOaexOjAtACiMxvc.Clear();
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

		public void TrimExcess()
		{
			TKhEFquLhqxIHfoTlpwnZBenTtrQ.TrimExcess();
		}

		private void VnrupaJzyqktAORXGKbuRRBDTKJk(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in VnrupaJzyqktAORXGKbuRRBDTKJk
			this.VnrupaJzyqktAORXGKbuRRBDTKJk(P_0);
		}

		private bool nQGVNSJiqdpDjMCwEjSImtZGhNNq(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			HwxfgkOzgFSwtoJuNAtdGMHpXwrC hwxfgkOzgFSwtoJuNAtdGMHpXwrC = TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num];
			return JUcbpWbgevwhRHqPdoGrNhrERLZM.Equals(P_0.Value, hwxfgkOzgFSwtoJuNAtdGMHpXwrC.UWgTtVXTweYDODigOiZQMbcDdOhjA);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nQGVNSJiqdpDjMCwEjSImtZGhNNq
			return this.nQGVNSJiqdpDjMCwEjSImtZGhNNq(P_0);
		}

		private void QQlfQUfBjCMdTkfHGfTtSuJxoakyA(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (P_1 < 0 || P_1 > P_0.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (P_0.Length - P_1 < this.Count)
			{
				throw new Exception();
			}
			int count = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm, TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].UWgTtVXTweYDODigOiZQMbcDdOhjA);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QQlfQUfBjCMdTkfHGfTtSuJxoakyA
			this.QQlfQUfBjCMdTkfHGfTtSuJxoakyA(P_0, P_1);
		}

		private bool ylbEpvBehBBBppxoQjVTMhrtFgmb(KeyValuePair<TKey, TValue> P_0)
		{
			if (RypZsBULdQAwkKlcsBOhGqqGFriab)
			{
				bool result = false;
				for (int num = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count - 1; num >= 0; num--)
				{
					HwxfgkOzgFSwtoJuNAtdGMHpXwrC hwxfgkOzgFSwtoJuNAtdGMHpXwrC = TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num];
					if (JUcbpWbgevwhRHqPdoGrNhrERLZM.Equals(P_0.Value, hwxfgkOzgFSwtoJuNAtdGMHpXwrC.UWgTtVXTweYDODigOiZQMbcDdOhjA))
					{
						TKhEFquLhqxIHfoTlpwnZBenTtrQ.RemoveAt(num);
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
			HwxfgkOzgFSwtoJuNAtdGMHpXwrC hwxfgkOzgFSwtoJuNAtdGMHpXwrC2 = TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[num2];
			if (!JUcbpWbgevwhRHqPdoGrNhrERLZM.Equals(P_0.Value, hwxfgkOzgFSwtoJuNAtdGMHpXwrC2.UWgTtVXTweYDODigOiZQMbcDdOhjA))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ylbEpvBehBBBppxoQjVTMhrtFgmb
			return this.ylbEpvBehBBBppxoQjVTMhrtFgmb(P_0);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
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
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			int count = TKhEFquLhqxIHfoTlpwnZBenTtrQ._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].AwXArdMDHeMZOGmaWWZvyKQKgTmm, TKhEFquLhqxIHfoTlpwnZBenTtrQ._items[i].UWgTtVXTweYDODigOiZQMbcDdOhjA), index++);
			}
		}

		private int znLJmYBREAhwTYgvspRaMxirUzai(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in znLJmYBREAhwTYgvspRaMxirUzai
			return this.znLJmYBREAhwTYgvspRaMxirUzai(P_0);
		}

		private bool aoTgRZDSfvdeWgvQmthQmCOazkTFA(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in aoTgRZDSfvdeWgvQmthQmCOazkTFA
			return this.aoTgRZDSfvdeWgvQmthQmCOazkTFA(P_0);
		}

		private int rKgdqXNohOlgPqxkUFttCLKaiOCR(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rKgdqXNohOlgPqxkUFttCLKaiOCR
			return this.rKgdqXNohOlgPqxkUFttCLKaiOCR(P_0);
		}

		private bool NNSfNVKsoqMEoJvVHRqdWeycamKA(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NNSfNVKsoqMEoJvVHRqdWeycamKA
			return this.NNSfNVKsoqMEoJvVHRqdWeycamKA(P_0);
		}
	}
}
