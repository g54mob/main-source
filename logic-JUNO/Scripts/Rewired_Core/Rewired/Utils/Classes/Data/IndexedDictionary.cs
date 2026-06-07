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
		private struct IwMjwRDuscrxoeTblplSwOsTXDRe
		{
			public TKey ZLqffSNuODkJPShwiifMCzCawmIH;

			public TValue BqPTowYCpHjuVVBykbobeeklXCPS;

			public IwMjwRDuscrxoeTblplSwOsTXDRe(TKey P_0, TValue P_1)
			{
				ZLqffSNuODkJPShwiifMCzCawmIH = P_0;
				BqPTowYCpHjuVVBykbobeeklXCPS = P_1;
			}

			public KeyValuePair<TKey, TValue> pmTcuDtxQfbIhjZfhtvdMtoBwqSh()
			{
				return new KeyValuePair<TKey, TValue>(ZLqffSNuODkJPShwiifMCzCawmIH, BqPTowYCpHjuVVBykbobeeklXCPS);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> hYqpFhpiuiMuOdtLBxFOsPXkxeqO;

			private int HdBgwAspfxyIZrvwskQjuFeTJCSC;

			private int PSMzbboGVVQOeAWtgPzXixwvkmpT;

			private KeyValuePair<TKey, TValue> VNasWseRSMZwytYRPGIfShrRCmhr;

			private int XZkROmlEhrIYzZkjqIBCNqDpzPxo;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => VNasWseRSMZwytYRPGIfShrRCmhr;

			object IEnumerator.Current
			{
				get
				{
					if (PSMzbboGVVQOeAWtgPzXixwvkmpT == 0 || PSMzbboGVVQOeAWtgPzXixwvkmpT == hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1)
					{
						throw new Exception();
					}
					if (XZkROmlEhrIYzZkjqIBCNqDpzPxo == 1)
					{
						return new DictionaryEntry(VNasWseRSMZwytYRPGIfShrRCmhr.Key, VNasWseRSMZwytYRPGIfShrRCmhr.Value);
					}
					return new KeyValuePair<TKey, TValue>(VNasWseRSMZwytYRPGIfShrRCmhr.Key, VNasWseRSMZwytYRPGIfShrRCmhr.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (PSMzbboGVVQOeAWtgPzXixwvkmpT == 0 || PSMzbboGVVQOeAWtgPzXixwvkmpT == hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(VNasWseRSMZwytYRPGIfShrRCmhr.Key, VNasWseRSMZwytYRPGIfShrRCmhr.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (PSMzbboGVVQOeAWtgPzXixwvkmpT == 0 || PSMzbboGVVQOeAWtgPzXixwvkmpT == hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1)
					{
						throw new Exception();
					}
					return VNasWseRSMZwytYRPGIfShrRCmhr.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (PSMzbboGVVQOeAWtgPzXixwvkmpT == 0 || PSMzbboGVVQOeAWtgPzXixwvkmpT == hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1)
					{
						throw new Exception();
					}
					return VNasWseRSMZwytYRPGIfShrRCmhr.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				hYqpFhpiuiMuOdtLBxFOsPXkxeqO = P_0;
				HdBgwAspfxyIZrvwskQjuFeTJCSC = P_0.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version;
				PSMzbboGVVQOeAWtgPzXixwvkmpT = 0;
				XZkROmlEhrIYzZkjqIBCNqDpzPxo = P_1;
				VNasWseRSMZwytYRPGIfShrRCmhr = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (HdBgwAspfxyIZrvwskQjuFeTJCSC != hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version)
				{
					throw new Exception();
				}
				if ((uint)PSMzbboGVVQOeAWtgPzXixwvkmpT < (uint)hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
				{
					VNasWseRSMZwytYRPGIfShrRCmhr = new KeyValuePair<TKey, TValue>(hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[PSMzbboGVVQOeAWtgPzXixwvkmpT].ZLqffSNuODkJPShwiifMCzCawmIH, hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[PSMzbboGVVQOeAWtgPzXixwvkmpT].BqPTowYCpHjuVVBykbobeeklXCPS);
					PSMzbboGVVQOeAWtgPzXixwvkmpT++;
					return true;
				}
				PSMzbboGVVQOeAWtgPzXixwvkmpT = hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1;
				VNasWseRSMZwytYRPGIfShrRCmhr = default(KeyValuePair<TKey, TValue>);
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
				if (HdBgwAspfxyIZrvwskQjuFeTJCSC != hYqpFhpiuiMuOdtLBxFOsPXkxeqO.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version)
				{
					throw new Exception();
				}
				PSMzbboGVVQOeAWtgPzXixwvkmpT = 0;
				VNasWseRSMZwytYRPGIfShrRCmhr = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> mJKapphcCKGJBZznxaAWtRUrBsdwA;

				private int nXPnkILvDVonimCnFflPdeMnBcmL;

				private int AGWvgwfmqyFXuBeLFxnQgwnNDlvK;

				private TKey tQzNsyIeEMpZArhbHvNffHMHWYYP;

				TKey IEnumerator<TKey>.Current => tQzNsyIeEMpZArhbHvNffHMHWYYP;

				object IEnumerator.Current
				{
					get
					{
						if (nXPnkILvDVonimCnFflPdeMnBcmL == 0 || nXPnkILvDVonimCnFflPdeMnBcmL == mJKapphcCKGJBZznxaAWtRUrBsdwA.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1)
						{
							throw new Exception();
						}
						return tQzNsyIeEMpZArhbHvNffHMHWYYP;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					mJKapphcCKGJBZznxaAWtRUrBsdwA = P_0;
					AGWvgwfmqyFXuBeLFxnQgwnNDlvK = P_0.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version;
					nXPnkILvDVonimCnFflPdeMnBcmL = 0;
					tQzNsyIeEMpZArhbHvNffHMHWYYP = default(TKey);
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
					if (AGWvgwfmqyFXuBeLFxnQgwnNDlvK != mJKapphcCKGJBZznxaAWtRUrBsdwA.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version)
					{
						throw new Exception();
					}
					if ((uint)nXPnkILvDVonimCnFflPdeMnBcmL < (uint)mJKapphcCKGJBZznxaAWtRUrBsdwA.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
					{
						tQzNsyIeEMpZArhbHvNffHMHWYYP = mJKapphcCKGJBZznxaAWtRUrBsdwA.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[nXPnkILvDVonimCnFflPdeMnBcmL].ZLqffSNuODkJPShwiifMCzCawmIH;
						nXPnkILvDVonimCnFflPdeMnBcmL++;
						return true;
					}
					nXPnkILvDVonimCnFflPdeMnBcmL = mJKapphcCKGJBZznxaAWtRUrBsdwA.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1;
					tQzNsyIeEMpZArhbHvNffHMHWYYP = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (AGWvgwfmqyFXuBeLFxnQgwnNDlvK != mJKapphcCKGJBZznxaAWtRUrBsdwA.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version)
					{
						throw new Exception();
					}
					nXPnkILvDVonimCnFflPdeMnBcmL = 0;
					tQzNsyIeEMpZArhbHvNffHMHWYYP = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> XpFOaaIaxyajBmGTmPgvtdPivdeD;

			int ICollection.Count => XpFOaaIaxyajBmGTmPgvtdPivdeD.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)XpFOaaIaxyajBmGTmPgvtdPivdeD).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				XpFOaaIaxyajBmGTmPgvtdPivdeD = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(XpFOaaIaxyajBmGTmPgvtdPivdeD);
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
				if (array.Length - index < XpFOaaIaxyajBmGTmPgvtdPivdeD.Count)
				{
					throw new Exception();
				}
				int count = XpFOaaIaxyajBmGTmPgvtdPivdeD.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
				IwMjwRDuscrxoeTblplSwOsTXDRe[] items = XpFOaaIaxyajBmGTmPgvtdPivdeD.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].ZLqffSNuODkJPShwiifMCzCawmIH;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void jCvXeVUTLAFVHZVjuImaFYwLgUyv(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in jCvXeVUTLAFVHZVjuImaFYwLgUyv
				this.jCvXeVUTLAFVHZVjuImaFYwLgUyv(P_0);
			}

			private void ZpUWhRMbPmcqtqFmnBECfExToqax()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ZpUWhRMbPmcqtqFmnBECfExToqax
				this.ZpUWhRMbPmcqtqFmnBECfExToqax();
			}

			private bool vJxABClODaZkMqHsGSwYaNpYnNyR(TKey P_0)
			{
				return XpFOaaIaxyajBmGTmPgvtdPivdeD.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in vJxABClODaZkMqHsGSwYaNpYnNyR
				return this.vJxABClODaZkMqHsGSwYaNpYnNyR(P_0);
			}

			private bool wgkZEENPjffIKjsdRGEGpKadEhnFb(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in wgkZEENPjffIKjsdRGEGpKadEhnFb
				return this.wgkZEENPjffIKjsdRGEGpKadEhnFb(P_0);
			}

			private IEnumerator<TKey> CkTaosjTsSunJHeFniZMBZJezkKSA()
			{
				return new Enumerator(XpFOaaIaxyajBmGTmPgvtdPivdeD);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in CkTaosjTsSunJHeFniZMBZJezkKSA
				return this.CkTaosjTsSunJHeFniZMBZJezkKSA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(XpFOaaIaxyajBmGTmPgvtdPivdeD);
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
				if (array.Length - index < XpFOaaIaxyajBmGTmPgvtdPivdeD.Count)
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
				int count = XpFOaaIaxyajBmGTmPgvtdPivdeD.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
				IwMjwRDuscrxoeTblplSwOsTXDRe[] items = XpFOaaIaxyajBmGTmPgvtdPivdeD.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].ZLqffSNuODkJPShwiifMCzCawmIH;
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
				private IndexedDictionary<TKey, TValue> vomyjVCPvzijpJTlLeUlkhDdVkbp;

				private int oDpuMwGvmKxbQMfLXVkYtFDUdTSgA;

				private int DgRgSWLAQkfkRFZpGpAeoXBFhCPwA;

				private TValue uzlbhibTqPKMlbqDfpPtvyBvfazw;

				TValue IEnumerator<TValue>.Current => uzlbhibTqPKMlbqDfpPtvyBvfazw;

				object IEnumerator.Current
				{
					get
					{
						if (oDpuMwGvmKxbQMfLXVkYtFDUdTSgA == 0 || oDpuMwGvmKxbQMfLXVkYtFDUdTSgA == vomyjVCPvzijpJTlLeUlkhDdVkbp.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1)
						{
							throw new Exception();
						}
						return uzlbhibTqPKMlbqDfpPtvyBvfazw;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					vomyjVCPvzijpJTlLeUlkhDdVkbp = P_0;
					DgRgSWLAQkfkRFZpGpAeoXBFhCPwA = P_0.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version;
					oDpuMwGvmKxbQMfLXVkYtFDUdTSgA = 0;
					uzlbhibTqPKMlbqDfpPtvyBvfazw = default(TValue);
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
					if (DgRgSWLAQkfkRFZpGpAeoXBFhCPwA != vomyjVCPvzijpJTlLeUlkhDdVkbp.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version)
					{
						throw new Exception();
					}
					if ((uint)oDpuMwGvmKxbQMfLXVkYtFDUdTSgA < (uint)vomyjVCPvzijpJTlLeUlkhDdVkbp.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
					{
						uzlbhibTqPKMlbqDfpPtvyBvfazw = vomyjVCPvzijpJTlLeUlkhDdVkbp.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[oDpuMwGvmKxbQMfLXVkYtFDUdTSgA].BqPTowYCpHjuVVBykbobeeklXCPS;
						oDpuMwGvmKxbQMfLXVkYtFDUdTSgA++;
						return true;
					}
					oDpuMwGvmKxbQMfLXVkYtFDUdTSgA = vomyjVCPvzijpJTlLeUlkhDdVkbp.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count + 1;
					uzlbhibTqPKMlbqDfpPtvyBvfazw = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (DgRgSWLAQkfkRFZpGpAeoXBFhCPwA != vomyjVCPvzijpJTlLeUlkhDdVkbp.QEIQHTzfmJxzKnuJLtDIppiTKdHW.Version)
					{
						throw new Exception();
					}
					oDpuMwGvmKxbQMfLXVkYtFDUdTSgA = 0;
					uzlbhibTqPKMlbqDfpPtvyBvfazw = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> mFpsfOOXPHOHZeUOWpbBXbhMGPMH;

			int ICollection<TValue>.Count => mFpsfOOXPHOHZeUOWpbBXbhMGPMH.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)mFpsfOOXPHOHZeUOWpbBXbhMGPMH).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				mFpsfOOXPHOHZeUOWpbBXbhMGPMH = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(mFpsfOOXPHOHZeUOWpbBXbhMGPMH);
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
				if (array.Length - index < mFpsfOOXPHOHZeUOWpbBXbhMGPMH.Count)
				{
					throw new Exception();
				}
				int count = mFpsfOOXPHOHZeUOWpbBXbhMGPMH.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
				IwMjwRDuscrxoeTblplSwOsTXDRe[] items = mFpsfOOXPHOHZeUOWpbBXbhMGPMH.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].BqPTowYCpHjuVVBykbobeeklXCPS;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void ENUaIzZeGAiGAixVogcAjvaKbnJd(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ENUaIzZeGAiGAixVogcAjvaKbnJd
				this.ENUaIzZeGAiGAixVogcAjvaKbnJd(P_0);
			}

			private bool HXQuZDbBtPdmpIZrbGAnYgNyQGyE(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in HXQuZDbBtPdmpIZrbGAnYgNyQGyE
				return this.HXQuZDbBtPdmpIZrbGAnYgNyQGyE(P_0);
			}

			private void XzSRJfeizdbICfuDdypFolcjIjKbA()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in XzSRJfeizdbICfuDdypFolcjIjKbA
				this.XzSRJfeizdbICfuDdypFolcjIjKbA();
			}

			private bool yRjgMgoJokAXHcjcWlISYFwImYXy(TValue P_0)
			{
				return mFpsfOOXPHOHZeUOWpbBXbhMGPMH.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in yRjgMgoJokAXHcjcWlISYFwImYXy
				return this.yRjgMgoJokAXHcjcWlISYFwImYXy(P_0);
			}

			private IEnumerator<TValue> agMPKkYBulkEDzWivQLmvVfNaHLv()
			{
				return new Enumerator(mFpsfOOXPHOHZeUOWpbBXbhMGPMH);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in agMPKkYBulkEDzWivQLmvVfNaHLv
				return this.agMPKkYBulkEDzWivQLmvVfNaHLv();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(mFpsfOOXPHOHZeUOWpbBXbhMGPMH);
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
				if (array.Length - index < mFpsfOOXPHOHZeUOWpbBXbhMGPMH.Count)
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
				int count = mFpsfOOXPHOHZeUOWpbBXbhMGPMH.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
				IwMjwRDuscrxoeTblplSwOsTXDRe[] items = mFpsfOOXPHOHZeUOWpbBXbhMGPMH.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].BqPTowYCpHjuVVBykbobeeklXCPS;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool HExrkqwhIvgaeHFSMXQvsNYSmPUcb = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool rMnBakzDgANfaWGhndGgjUiUmrKgA = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> uqOfldMDZnXMAfdWezmkfsKlprqR = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> AnTvdraPfICoGVCLRpnInmxoTdvl = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<IwMjwRDuscrxoeTblplSwOsTXDRe> QEIQHTzfmJxzKnuJLtDIppiTKdHW;

		private readonly ADictionary<TKey, int> ylbUNIwPwAJVbSyHRtMSZOoAMRHC;

		private bool MUKvuiXHwhrHhCfoIcfQGEsyIbGjb;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!MUKvuiXHwhrHhCfoIcfQGEsyIbGjb)
				{
					return false;
				}
				return ylbUNIwPwAJVbSyHRtMSZOoAMRHC._count < QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return MUKvuiXHwhrHhCfoIcfQGEsyIbGjb;
			}
			set
			{
				if (MUKvuiXHwhrHhCfoIcfQGEsyIbGjb != value)
				{
					MUKvuiXHwhrHhCfoIcfQGEsyIbGjb = value;
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
				if ((uint)index >= (uint)QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[index].BqPTowYCpHjuVVBykbobeeklXCPS;
			}
			set
			{
				if ((uint)index >= (uint)QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[index].BqPTowYCpHjuVVBykbobeeklXCPS = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return uqOfldMDZnXMAfdWezmkfsKlprqR;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				uqOfldMDZnXMAfdWezmkfsKlprqR = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return AnTvdraPfICoGVCLRpnInmxoTdvl;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				AnTvdraPfICoGVCLRpnInmxoTdvl = value;
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
				return QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num].BqPTowYCpHjuVVBykbobeeklXCPS;
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

		bool ICollection.IsSynchronized => ((ICollection)QEIQHTzfmJxzKnuJLtDIppiTKdHW).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)QEIQHTzfmJxzKnuJLtDIppiTKdHW).SyncRoot;

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
			MUKvuiXHwhrHhCfoIcfQGEsyIbGjb = P_1;
			QEIQHTzfmJxzKnuJLtDIppiTKdHW = new AList<IwMjwRDuscrxoeTblplSwOsTXDRe>(P_0);
			ylbUNIwPwAJVbSyHRtMSZOoAMRHC = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.QEIQHTzfmJxzKnuJLtDIppiTKdHW._count; i++)
				{
					Add(indexedDictionary.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].ZLqffSNuODkJPShwiifMCzCawmIH, indexedDictionary.QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].BqPTowYCpHjuVVBykbobeeklXCPS);
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
			return QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[ylbUNIwPwAJVbSyHRtMSZOoAMRHC[key]].BqPTowYCpHjuVVBykbobeeklXCPS;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!ylbUNIwPwAJVbSyHRtMSZOoAMRHC.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[value2].BqPTowYCpHjuVVBykbobeeklXCPS;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<IwMjwRDuscrxoeTblplSwOsTXDRe, _003F>.IwMjwRDuscrxoeTblplSwOsTXDRe>)(object)QEIQHTzfmJxzKnuJLtDIppiTKdHW)[index].ZLqffSNuODkJPShwiifMCzCawmIH;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<IwMjwRDuscrxoeTblplSwOsTXDRe, _003F>.IwMjwRDuscrxoeTblplSwOsTXDRe>)(object)QEIQHTzfmJxzKnuJLtDIppiTKdHW)[ylbUNIwPwAJVbSyHRtMSZOoAMRHC[key]].pmTcuDtxQfbIhjZfhtvdMtoBwqSh();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<IwMjwRDuscrxoeTblplSwOsTXDRe, _003F>.IwMjwRDuscrxoeTblplSwOsTXDRe>)(object)QEIQHTzfmJxzKnuJLtDIppiTKdHW)[index].pmTcuDtxQfbIhjZfhtvdMtoBwqSh();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!ylbUNIwPwAJVbSyHRtMSZOoAMRHC.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<IwMjwRDuscrxoeTblplSwOsTXDRe, _003F>.IwMjwRDuscrxoeTblplSwOsTXDRe>)(object)QEIQHTzfmJxzKnuJLtDIppiTKdHW)[value].pmTcuDtxQfbIhjZfhtvdMtoBwqSh();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = ylbUNIwPwAJVbSyHRtMSZOoAMRHC.ContainsKey(key);
			if (num && !MUKvuiXHwhrHhCfoIcfQGEsyIbGjb)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = QEIQHTzfmJxzKnuJLtDIppiTKdHW.Add(new IwMjwRDuscrxoeTblplSwOsTXDRe(key, value));
			if (num)
			{
				ylbUNIwPwAJVbSyHRtMSZOoAMRHC[key] = num2;
			}
			else
			{
				ylbUNIwPwAJVbSyHRtMSZOoAMRHC.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (ylbUNIwPwAJVbSyHRtMSZOoAMRHC.TryGetValue(key, out var value2))
			{
				QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[value2].BqPTowYCpHjuVVBykbobeeklXCPS = value;
				ylbUNIwPwAJVbSyHRtMSZOoAMRHC[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			ylbUNIwPwAJVbSyHRtMSZOoAMRHC.Remove(key);
			if (MUKvuiXHwhrHhCfoIcfQGEsyIbGjb)
			{
				bool result = false;
				for (int num = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count - 1; num >= 0; num--)
				{
					if (uqOfldMDZnXMAfdWezmkfsKlprqR.Equals(QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num].ZLqffSNuODkJPShwiifMCzCawmIH, key))
					{
						QEIQHTzfmJxzKnuJLtDIppiTKdHW.RemoveAt(num);
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
			if ((uint)index >= (uint)QEIQHTzfmJxzKnuJLtDIppiTKdHW._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey zLqffSNuODkJPShwiifMCzCawmIH = QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[index].ZLqffSNuODkJPShwiifMCzCawmIH;
			if (index < QEIQHTzfmJxzKnuJLtDIppiTKdHW._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<IwMjwRDuscrxoeTblplSwOsTXDRe, _003F>.IwMjwRDuscrxoeTblplSwOsTXDRe>)(object)QEIQHTzfmJxzKnuJLtDIppiTKdHW).Count; i++)
				{
					ylbUNIwPwAJVbSyHRtMSZOoAMRHC[QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].ZLqffSNuODkJPShwiifMCzCawmIH] = i - 1;
				}
			}
			QEIQHTzfmJxzKnuJLtDIppiTKdHW.RemoveAt(index);
			ylbUNIwPwAJVbSyHRtMSZOoAMRHC.Remove(zLqffSNuODkJPShwiifMCzCawmIH);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count - 1; num2 >= 0; num2--)
			{
				_ = ref QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num2];
				if (AnTvdraPfICoGVCLRpnInmxoTdvl.Equals(QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num2].BqPTowYCpHjuVVBykbobeeklXCPS, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!HExrkqwhIvgaeHFSMXQvsNYSmPUcb && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
			for (int i = 0; i < count; i++)
			{
				if (uqOfldMDZnXMAfdWezmkfsKlprqR.Equals(QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].ZLqffSNuODkJPShwiifMCzCawmIH, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
			for (int i = 0; i < count; i++)
			{
				if (AnTvdraPfICoGVCLRpnInmxoTdvl.Equals(QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].BqPTowYCpHjuVVBykbobeeklXCPS, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return ylbUNIwPwAJVbSyHRtMSZOoAMRHC.ContainsKey(key);
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
			QEIQHTzfmJxzKnuJLtDIppiTKdHW.Clear();
			ylbUNIwPwAJVbSyHRtMSZOoAMRHC.Clear();
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
			QEIQHTzfmJxzKnuJLtDIppiTKdHW.TrimExcess();
		}

		private void OuGoPTUNbLLHFYvNmdXLdsRlFIpj(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OuGoPTUNbLLHFYvNmdXLdsRlFIpj
			this.OuGoPTUNbLLHFYvNmdXLdsRlFIpj(P_0);
		}

		private bool wQrFLhAVjCdqcDKsoEdxpCBwLVrFb(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			IwMjwRDuscrxoeTblplSwOsTXDRe iwMjwRDuscrxoeTblplSwOsTXDRe = QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num];
			return AnTvdraPfICoGVCLRpnInmxoTdvl.Equals(P_0.Value, iwMjwRDuscrxoeTblplSwOsTXDRe.BqPTowYCpHjuVVBykbobeeklXCPS);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wQrFLhAVjCdqcDKsoEdxpCBwLVrFb
			return this.wQrFLhAVjCdqcDKsoEdxpCBwLVrFb(P_0);
		}

		private void DQAvCdQtgxHCCzmJolaGAWLXQuYs(KeyValuePair<TKey, TValue>[] P_0, int P_1)
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
			int count = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].ZLqffSNuODkJPShwiifMCzCawmIH, QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].BqPTowYCpHjuVVBykbobeeklXCPS);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DQAvCdQtgxHCCzmJolaGAWLXQuYs
			this.DQAvCdQtgxHCCzmJolaGAWLXQuYs(P_0, P_1);
		}

		private bool nLGIKGSGxmynMbPjmQyuuTfRRIEm(KeyValuePair<TKey, TValue> P_0)
		{
			if (MUKvuiXHwhrHhCfoIcfQGEsyIbGjb)
			{
				bool result = false;
				for (int num = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count - 1; num >= 0; num--)
				{
					IwMjwRDuscrxoeTblplSwOsTXDRe iwMjwRDuscrxoeTblplSwOsTXDRe = QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num];
					if (AnTvdraPfICoGVCLRpnInmxoTdvl.Equals(P_0.Value, iwMjwRDuscrxoeTblplSwOsTXDRe.BqPTowYCpHjuVVBykbobeeklXCPS))
					{
						QEIQHTzfmJxzKnuJLtDIppiTKdHW.RemoveAt(num);
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
			IwMjwRDuscrxoeTblplSwOsTXDRe iwMjwRDuscrxoeTblplSwOsTXDRe2 = QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[num2];
			if (!AnTvdraPfICoGVCLRpnInmxoTdvl.Equals(P_0.Value, iwMjwRDuscrxoeTblplSwOsTXDRe2.BqPTowYCpHjuVVBykbobeeklXCPS))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nLGIKGSGxmynMbPjmQyuuTfRRIEm
			return this.nLGIKGSGxmynMbPjmQyuuTfRRIEm(P_0);
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
			int count = QEIQHTzfmJxzKnuJLtDIppiTKdHW._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].ZLqffSNuODkJPShwiifMCzCawmIH, QEIQHTzfmJxzKnuJLtDIppiTKdHW._items[i].BqPTowYCpHjuVVBykbobeeklXCPS), index++);
			}
		}

		private int gryOmjWOPxwSSOIjIxITyhiTkMQS(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gryOmjWOPxwSSOIjIxITyhiTkMQS
			return this.gryOmjWOPxwSSOIjIxITyhiTkMQS(P_0);
		}

		private bool lniwJyYUuYoZJrfWWGEbonSOlydk(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lniwJyYUuYoZJrfWWGEbonSOlydk
			return this.lniwJyYUuYoZJrfWWGEbonSOlydk(P_0);
		}

		private int cKDksoETolVqWucoobGKmyEOkEko(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cKDksoETolVqWucoobGKmyEOkEko
			return this.cKDksoETolVqWucoobGKmyEOkEko(P_0);
		}

		private bool MyqlneRdwJzGBVJbvsmTRaaKjsSO(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MyqlneRdwJzGBVJbvsmTRaaKjsSO
			return this.MyqlneRdwJzGBVJbvsmTRaaKjsSO(P_0);
		}
	}
}
