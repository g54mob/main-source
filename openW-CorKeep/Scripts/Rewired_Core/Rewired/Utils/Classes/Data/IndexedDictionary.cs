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
		private struct KdGrzyjICPauknGpnHkObuJrqwAWA
		{
			public TKey ZmqYxjpxeodtTVaKeFtQGsPEXZNs;

			public TValue TrPgHHGcLqPkHeSUeordTutFXjWpA;

			public KdGrzyjICPauknGpnHkObuJrqwAWA(TKey P_0, TValue P_1)
			{
				ZmqYxjpxeodtTVaKeFtQGsPEXZNs = P_0;
				TrPgHHGcLqPkHeSUeordTutFXjWpA = P_1;
			}

			public KeyValuePair<TKey, TValue> baLfoqiNuOxcrBoNrlormEzvyLPJA()
			{
				return new KeyValuePair<TKey, TValue>(ZmqYxjpxeodtTVaKeFtQGsPEXZNs, TrPgHHGcLqPkHeSUeordTutFXjWpA);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> nMgHGUPGKTpgMgNxJEqEsJOELBzi;

			private int LCtJqHIlTUVlAgZXeClQoKSnDmHs;

			private int JRQpcASltsHReFfDcyAJifpVCXws;

			private KeyValuePair<TKey, TValue> XNoOrXCalvWhgwxrPTabMoGlLFig;

			private int XhkgFPIPDQZPlgILikYWFTSRisuwA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => XNoOrXCalvWhgwxrPTabMoGlLFig;

			object IEnumerator.Current
			{
				get
				{
					if (JRQpcASltsHReFfDcyAJifpVCXws == 0 || JRQpcASltsHReFfDcyAJifpVCXws == nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1)
					{
						throw new Exception();
					}
					if (XhkgFPIPDQZPlgILikYWFTSRisuwA == 1)
					{
						return new DictionaryEntry(XNoOrXCalvWhgwxrPTabMoGlLFig.Key, XNoOrXCalvWhgwxrPTabMoGlLFig.Value);
					}
					return new KeyValuePair<TKey, TValue>(XNoOrXCalvWhgwxrPTabMoGlLFig.Key, XNoOrXCalvWhgwxrPTabMoGlLFig.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (JRQpcASltsHReFfDcyAJifpVCXws == 0 || JRQpcASltsHReFfDcyAJifpVCXws == nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(XNoOrXCalvWhgwxrPTabMoGlLFig.Key, XNoOrXCalvWhgwxrPTabMoGlLFig.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (JRQpcASltsHReFfDcyAJifpVCXws == 0 || JRQpcASltsHReFfDcyAJifpVCXws == nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1)
					{
						throw new Exception();
					}
					return XNoOrXCalvWhgwxrPTabMoGlLFig.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (JRQpcASltsHReFfDcyAJifpVCXws == 0 || JRQpcASltsHReFfDcyAJifpVCXws == nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1)
					{
						throw new Exception();
					}
					return XNoOrXCalvWhgwxrPTabMoGlLFig.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				nMgHGUPGKTpgMgNxJEqEsJOELBzi = P_0;
				LCtJqHIlTUVlAgZXeClQoKSnDmHs = P_0.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version;
				JRQpcASltsHReFfDcyAJifpVCXws = 0;
				XhkgFPIPDQZPlgILikYWFTSRisuwA = P_1;
				XNoOrXCalvWhgwxrPTabMoGlLFig = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (LCtJqHIlTUVlAgZXeClQoKSnDmHs != nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version)
				{
					throw new Exception();
				}
				if ((uint)JRQpcASltsHReFfDcyAJifpVCXws < (uint)nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
				{
					XNoOrXCalvWhgwxrPTabMoGlLFig = new KeyValuePair<TKey, TValue>(nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._items[JRQpcASltsHReFfDcyAJifpVCXws].ZmqYxjpxeodtTVaKeFtQGsPEXZNs, nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._items[JRQpcASltsHReFfDcyAJifpVCXws].TrPgHHGcLqPkHeSUeordTutFXjWpA);
					JRQpcASltsHReFfDcyAJifpVCXws++;
					return true;
				}
				JRQpcASltsHReFfDcyAJifpVCXws = nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1;
				XNoOrXCalvWhgwxrPTabMoGlLFig = default(KeyValuePair<TKey, TValue>);
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
				if (LCtJqHIlTUVlAgZXeClQoKSnDmHs != nMgHGUPGKTpgMgNxJEqEsJOELBzi.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version)
				{
					throw new Exception();
				}
				JRQpcASltsHReFfDcyAJifpVCXws = 0;
				XNoOrXCalvWhgwxrPTabMoGlLFig = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> qxMBxKKAaboAZyLXxDDIjHXZpJcZA;

				private int xRZvjrpGlmudankBXVaTvLDHIuraA;

				private int UuMVnPBOGVjCadGvFykWCguxzueqA;

				private TKey pxfecXmkjbIDKgiNXUJvliFxfaXJ;

				TKey IEnumerator<TKey>.Current => pxfecXmkjbIDKgiNXUJvliFxfaXJ;

				object IEnumerator.Current
				{
					get
					{
						if (xRZvjrpGlmudankBXVaTvLDHIuraA == 0 || xRZvjrpGlmudankBXVaTvLDHIuraA == qxMBxKKAaboAZyLXxDDIjHXZpJcZA.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1)
						{
							throw new Exception();
						}
						return pxfecXmkjbIDKgiNXUJvliFxfaXJ;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					qxMBxKKAaboAZyLXxDDIjHXZpJcZA = P_0;
					UuMVnPBOGVjCadGvFykWCguxzueqA = P_0.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version;
					xRZvjrpGlmudankBXVaTvLDHIuraA = 0;
					pxfecXmkjbIDKgiNXUJvliFxfaXJ = default(TKey);
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
					if (UuMVnPBOGVjCadGvFykWCguxzueqA != qxMBxKKAaboAZyLXxDDIjHXZpJcZA.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version)
					{
						throw new Exception();
					}
					if ((uint)xRZvjrpGlmudankBXVaTvLDHIuraA < (uint)qxMBxKKAaboAZyLXxDDIjHXZpJcZA.IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
					{
						pxfecXmkjbIDKgiNXUJvliFxfaXJ = qxMBxKKAaboAZyLXxDDIjHXZpJcZA.IzMFncBSDamNMoxBXGmIrjYnMsGd._items[xRZvjrpGlmudankBXVaTvLDHIuraA].ZmqYxjpxeodtTVaKeFtQGsPEXZNs;
						xRZvjrpGlmudankBXVaTvLDHIuraA++;
						return true;
					}
					xRZvjrpGlmudankBXVaTvLDHIuraA = qxMBxKKAaboAZyLXxDDIjHXZpJcZA.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1;
					pxfecXmkjbIDKgiNXUJvliFxfaXJ = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (UuMVnPBOGVjCadGvFykWCguxzueqA != qxMBxKKAaboAZyLXxDDIjHXZpJcZA.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version)
					{
						throw new Exception();
					}
					xRZvjrpGlmudankBXVaTvLDHIuraA = 0;
					pxfecXmkjbIDKgiNXUJvliFxfaXJ = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> VuZeCZekMLHxBnyyuuYxhUsIEvtJ;

			int ICollection.Count => VuZeCZekMLHxBnyyuuYxhUsIEvtJ.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)VuZeCZekMLHxBnyyuuYxhUsIEvtJ).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				VuZeCZekMLHxBnyyuuYxhUsIEvtJ = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(VuZeCZekMLHxBnyyuuYxhUsIEvtJ);
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
				if (array.Length - index < VuZeCZekMLHxBnyyuuYxhUsIEvtJ.Count)
				{
					throw new Exception();
				}
				int count = VuZeCZekMLHxBnyyuuYxhUsIEvtJ.IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
				KdGrzyjICPauknGpnHkObuJrqwAWA[] items = VuZeCZekMLHxBnyyuuYxhUsIEvtJ.IzMFncBSDamNMoxBXGmIrjYnMsGd._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void pVpcyiyjxxWnDKETatmaHerjtMtj(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in pVpcyiyjxxWnDKETatmaHerjtMtj
				this.pVpcyiyjxxWnDKETatmaHerjtMtj(P_0);
			}

			private void LwEmKaoqdRoxddOStDZEhqupJSpk()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in LwEmKaoqdRoxddOStDZEhqupJSpk
				this.LwEmKaoqdRoxddOStDZEhqupJSpk();
			}

			private bool jxvdBtDXrFBbGQfQISjEweqoiadGA(TKey P_0)
			{
				return VuZeCZekMLHxBnyyuuYxhUsIEvtJ.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in jxvdBtDXrFBbGQfQISjEweqoiadGA
				return this.jxvdBtDXrFBbGQfQISjEweqoiadGA(P_0);
			}

			private bool mticGjdKZOJNExJTPLrIEDfDhWmr(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in mticGjdKZOJNExJTPLrIEDfDhWmr
				return this.mticGjdKZOJNExJTPLrIEDfDhWmr(P_0);
			}

			private IEnumerator<TKey> QxDeiZAPQpkeLbUxDnCKKNAjUNZNB()
			{
				return new Enumerator(VuZeCZekMLHxBnyyuuYxhUsIEvtJ);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in QxDeiZAPQpkeLbUxDnCKKNAjUNZNB
				return this.QxDeiZAPQpkeLbUxDnCKKNAjUNZNB();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(VuZeCZekMLHxBnyyuuYxhUsIEvtJ);
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
				if (array.Length - index < VuZeCZekMLHxBnyyuuYxhUsIEvtJ.Count)
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
				int count = VuZeCZekMLHxBnyyuuYxhUsIEvtJ.IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
				KdGrzyjICPauknGpnHkObuJrqwAWA[] items = VuZeCZekMLHxBnyyuuYxhUsIEvtJ.IzMFncBSDamNMoxBXGmIrjYnMsGd._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs;
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
				private IndexedDictionary<TKey, TValue> zOaxXycZKGwglEcHFDwpqHODBVwi;

				private int cklESFwGSdspMRdNJxmMdOOokKNd;

				private int NgLAcnrueJxQPWPCCHfcLeKvlDEm;

				private TValue eMvAjJgNAazBdfgdrCKjLtMPlPojA;

				TValue IEnumerator<TValue>.Current => eMvAjJgNAazBdfgdrCKjLtMPlPojA;

				object IEnumerator.Current
				{
					get
					{
						if (cklESFwGSdspMRdNJxmMdOOokKNd == 0 || cklESFwGSdspMRdNJxmMdOOokKNd == zOaxXycZKGwglEcHFDwpqHODBVwi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1)
						{
							throw new Exception();
						}
						return eMvAjJgNAazBdfgdrCKjLtMPlPojA;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					zOaxXycZKGwglEcHFDwpqHODBVwi = P_0;
					NgLAcnrueJxQPWPCCHfcLeKvlDEm = P_0.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version;
					cklESFwGSdspMRdNJxmMdOOokKNd = 0;
					eMvAjJgNAazBdfgdrCKjLtMPlPojA = default(TValue);
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
					if (NgLAcnrueJxQPWPCCHfcLeKvlDEm != zOaxXycZKGwglEcHFDwpqHODBVwi.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version)
					{
						throw new Exception();
					}
					if ((uint)cklESFwGSdspMRdNJxmMdOOokKNd < (uint)zOaxXycZKGwglEcHFDwpqHODBVwi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
					{
						eMvAjJgNAazBdfgdrCKjLtMPlPojA = zOaxXycZKGwglEcHFDwpqHODBVwi.IzMFncBSDamNMoxBXGmIrjYnMsGd._items[cklESFwGSdspMRdNJxmMdOOokKNd].TrPgHHGcLqPkHeSUeordTutFXjWpA;
						cklESFwGSdspMRdNJxmMdOOokKNd++;
						return true;
					}
					cklESFwGSdspMRdNJxmMdOOokKNd = zOaxXycZKGwglEcHFDwpqHODBVwi.IzMFncBSDamNMoxBXGmIrjYnMsGd._count + 1;
					eMvAjJgNAazBdfgdrCKjLtMPlPojA = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (NgLAcnrueJxQPWPCCHfcLeKvlDEm != zOaxXycZKGwglEcHFDwpqHODBVwi.IzMFncBSDamNMoxBXGmIrjYnMsGd.Version)
					{
						throw new Exception();
					}
					cklESFwGSdspMRdNJxmMdOOokKNd = 0;
					eMvAjJgNAazBdfgdrCKjLtMPlPojA = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> uexikboKdwVUJbBoMDyLDsmaMtFn;

			int ICollection<TValue>.Count => uexikboKdwVUJbBoMDyLDsmaMtFn.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)uexikboKdwVUJbBoMDyLDsmaMtFn).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				uexikboKdwVUJbBoMDyLDsmaMtFn = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(uexikboKdwVUJbBoMDyLDsmaMtFn);
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
				if (array.Length - index < uexikboKdwVUJbBoMDyLDsmaMtFn.Count)
				{
					throw new Exception();
				}
				int count = uexikboKdwVUJbBoMDyLDsmaMtFn.IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
				KdGrzyjICPauknGpnHkObuJrqwAWA[] items = uexikboKdwVUJbBoMDyLDsmaMtFn.IzMFncBSDamNMoxBXGmIrjYnMsGd._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].TrPgHHGcLqPkHeSUeordTutFXjWpA;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void MoWQaUfdAxchAhtLqDhYKjauNOSvA(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoWQaUfdAxchAhtLqDhYKjauNOSvA
				this.MoWQaUfdAxchAhtLqDhYKjauNOSvA(P_0);
			}

			private bool BQENigFbzagihELftfXjeWzEEfxCc(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in BQENigFbzagihELftfXjeWzEEfxCc
				return this.BQENigFbzagihELftfXjeWzEEfxCc(P_0);
			}

			private void DEWZqUMLDSBZIalktkmTgzhVStHD()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DEWZqUMLDSBZIalktkmTgzhVStHD
				this.DEWZqUMLDSBZIalktkmTgzhVStHD();
			}

			private bool sFvYFxUGdZKZZoSrKDCmRrlwhQxb(TValue P_0)
			{
				return uexikboKdwVUJbBoMDyLDsmaMtFn.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in sFvYFxUGdZKZZoSrKDCmRrlwhQxb
				return this.sFvYFxUGdZKZZoSrKDCmRrlwhQxb(P_0);
			}

			private IEnumerator<TValue> iFEKQBsDKQVSZcJGtWTczsrzyFIh()
			{
				return new Enumerator(uexikboKdwVUJbBoMDyLDsmaMtFn);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in iFEKQBsDKQVSZcJGtWTczsrzyFIh
				return this.iFEKQBsDKQVSZcJGtWTczsrzyFIh();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(uexikboKdwVUJbBoMDyLDsmaMtFn);
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
				if (array.Length - index < uexikboKdwVUJbBoMDyLDsmaMtFn.Count)
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
				int count = uexikboKdwVUJbBoMDyLDsmaMtFn.IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
				KdGrzyjICPauknGpnHkObuJrqwAWA[] items = uexikboKdwVUJbBoMDyLDsmaMtFn.IzMFncBSDamNMoxBXGmIrjYnMsGd._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].TrPgHHGcLqPkHeSUeordTutFXjWpA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool LxxctBWesUnjqOwPQDzzPFtusaBD = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool pRlawZDHKhvqmBWBvZTuMKxsjIFx = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> eJQjgQorQOPeMactwheazbDNEShF = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> ENTYlYIyJzuPCYldXCuEzxqKfomV = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<KdGrzyjICPauknGpnHkObuJrqwAWA> IzMFncBSDamNMoxBXGmIrjYnMsGd;

		private readonly ADictionary<TKey, int> wlrqSdOKzxjEpHVQHLoSRAJmxjGx;

		private bool GIGaMJjMIUUkfDGOMuaUQPjKQqZg;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => IzMFncBSDamNMoxBXGmIrjYnMsGd._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!GIGaMJjMIUUkfDGOMuaUQPjKQqZg)
				{
					return false;
				}
				return wlrqSdOKzxjEpHVQHLoSRAJmxjGx._count < IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return GIGaMJjMIUUkfDGOMuaUQPjKQqZg;
			}
			set
			{
				if (GIGaMJjMIUUkfDGOMuaUQPjKQqZg != value)
				{
					GIGaMJjMIUUkfDGOMuaUQPjKQqZg = value;
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
				if ((uint)index >= (uint)IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return IzMFncBSDamNMoxBXGmIrjYnMsGd._items[index].TrPgHHGcLqPkHeSUeordTutFXjWpA;
			}
			set
			{
				if ((uint)index >= (uint)IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				IzMFncBSDamNMoxBXGmIrjYnMsGd._items[index].TrPgHHGcLqPkHeSUeordTutFXjWpA = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return eJQjgQorQOPeMactwheazbDNEShF;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				eJQjgQorQOPeMactwheazbDNEShF = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return ENTYlYIyJzuPCYldXCuEzxqKfomV;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				ENTYlYIyJzuPCYldXCuEzxqKfomV = value;
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
				return IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num].TrPgHHGcLqPkHeSUeordTutFXjWpA;
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

		bool ICollection.IsSynchronized => ((ICollection)IzMFncBSDamNMoxBXGmIrjYnMsGd).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)IzMFncBSDamNMoxBXGmIrjYnMsGd).SyncRoot;

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
			GIGaMJjMIUUkfDGOMuaUQPjKQqZg = P_1;
			IzMFncBSDamNMoxBXGmIrjYnMsGd = new AList<KdGrzyjICPauknGpnHkObuJrqwAWA>(P_0);
			wlrqSdOKzxjEpHVQHLoSRAJmxjGx = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.IzMFncBSDamNMoxBXGmIrjYnMsGd._count; i++)
				{
					Add(indexedDictionary.IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs, indexedDictionary.IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].TrPgHHGcLqPkHeSUeordTutFXjWpA);
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
			return IzMFncBSDamNMoxBXGmIrjYnMsGd._items[wlrqSdOKzxjEpHVQHLoSRAJmxjGx[key]].TrPgHHGcLqPkHeSUeordTutFXjWpA;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!wlrqSdOKzxjEpHVQHLoSRAJmxjGx.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = IzMFncBSDamNMoxBXGmIrjYnMsGd._items[value2].TrPgHHGcLqPkHeSUeordTutFXjWpA;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<KdGrzyjICPauknGpnHkObuJrqwAWA, _003F>.KdGrzyjICPauknGpnHkObuJrqwAWA>)(object)IzMFncBSDamNMoxBXGmIrjYnMsGd)[index].ZmqYxjpxeodtTVaKeFtQGsPEXZNs;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<KdGrzyjICPauknGpnHkObuJrqwAWA, _003F>.KdGrzyjICPauknGpnHkObuJrqwAWA>)(object)IzMFncBSDamNMoxBXGmIrjYnMsGd)[wlrqSdOKzxjEpHVQHLoSRAJmxjGx[key]].baLfoqiNuOxcrBoNrlormEzvyLPJA();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<KdGrzyjICPauknGpnHkObuJrqwAWA, _003F>.KdGrzyjICPauknGpnHkObuJrqwAWA>)(object)IzMFncBSDamNMoxBXGmIrjYnMsGd)[index].baLfoqiNuOxcrBoNrlormEzvyLPJA();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!wlrqSdOKzxjEpHVQHLoSRAJmxjGx.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<KdGrzyjICPauknGpnHkObuJrqwAWA, _003F>.KdGrzyjICPauknGpnHkObuJrqwAWA>)(object)IzMFncBSDamNMoxBXGmIrjYnMsGd)[value].baLfoqiNuOxcrBoNrlormEzvyLPJA();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = wlrqSdOKzxjEpHVQHLoSRAJmxjGx.ContainsKey(key);
			if (num && !GIGaMJjMIUUkfDGOMuaUQPjKQqZg)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = IzMFncBSDamNMoxBXGmIrjYnMsGd.Add(new KdGrzyjICPauknGpnHkObuJrqwAWA(key, value));
			if (num)
			{
				wlrqSdOKzxjEpHVQHLoSRAJmxjGx[key] = num2;
			}
			else
			{
				wlrqSdOKzxjEpHVQHLoSRAJmxjGx.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (wlrqSdOKzxjEpHVQHLoSRAJmxjGx.TryGetValue(key, out var value2))
			{
				IzMFncBSDamNMoxBXGmIrjYnMsGd._items[value2].TrPgHHGcLqPkHeSUeordTutFXjWpA = value;
				wlrqSdOKzxjEpHVQHLoSRAJmxjGx[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			wlrqSdOKzxjEpHVQHLoSRAJmxjGx.Remove(key);
			if (GIGaMJjMIUUkfDGOMuaUQPjKQqZg)
			{
				bool result = false;
				for (int num = IzMFncBSDamNMoxBXGmIrjYnMsGd._count - 1; num >= 0; num--)
				{
					if (eJQjgQorQOPeMactwheazbDNEShF.Equals(IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num].ZmqYxjpxeodtTVaKeFtQGsPEXZNs, key))
					{
						IzMFncBSDamNMoxBXGmIrjYnMsGd.RemoveAt(num);
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
			if ((uint)index >= (uint)IzMFncBSDamNMoxBXGmIrjYnMsGd._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey zmqYxjpxeodtTVaKeFtQGsPEXZNs = IzMFncBSDamNMoxBXGmIrjYnMsGd._items[index].ZmqYxjpxeodtTVaKeFtQGsPEXZNs;
			if (index < IzMFncBSDamNMoxBXGmIrjYnMsGd._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<KdGrzyjICPauknGpnHkObuJrqwAWA, _003F>.KdGrzyjICPauknGpnHkObuJrqwAWA>)(object)IzMFncBSDamNMoxBXGmIrjYnMsGd).Count; i++)
				{
					wlrqSdOKzxjEpHVQHLoSRAJmxjGx[IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs] = i - 1;
				}
			}
			IzMFncBSDamNMoxBXGmIrjYnMsGd.RemoveAt(index);
			wlrqSdOKzxjEpHVQHLoSRAJmxjGx.Remove(zmqYxjpxeodtTVaKeFtQGsPEXZNs);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = IzMFncBSDamNMoxBXGmIrjYnMsGd._count - 1; num2 >= 0; num2--)
			{
				_ = ref IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num2];
				if (ENTYlYIyJzuPCYldXCuEzxqKfomV.Equals(IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num2].TrPgHHGcLqPkHeSUeordTutFXjWpA, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!LxxctBWesUnjqOwPQDzzPFtusaBD && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
			for (int i = 0; i < count; i++)
			{
				if (eJQjgQorQOPeMactwheazbDNEShF.Equals(IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
			for (int i = 0; i < count; i++)
			{
				if (ENTYlYIyJzuPCYldXCuEzxqKfomV.Equals(IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].TrPgHHGcLqPkHeSUeordTutFXjWpA, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return wlrqSdOKzxjEpHVQHLoSRAJmxjGx.ContainsKey(key);
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
			IzMFncBSDamNMoxBXGmIrjYnMsGd.Clear();
			wlrqSdOKzxjEpHVQHLoSRAJmxjGx.Clear();
		}

		void IDictionary.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public void TrimExcess()
		{
			IzMFncBSDamNMoxBXGmIrjYnMsGd.TrimExcess();
		}

		private void KNAWowwXNaQQDBRfgDyDrSWJGeao(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KNAWowwXNaQQDBRfgDyDrSWJGeao
			this.KNAWowwXNaQQDBRfgDyDrSWJGeao(P_0);
		}

		private bool wqpFgSigBpdxcTYIaAwdOVWChqmw(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			KdGrzyjICPauknGpnHkObuJrqwAWA kdGrzyjICPauknGpnHkObuJrqwAWA = IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num];
			return ENTYlYIyJzuPCYldXCuEzxqKfomV.Equals(P_0.Value, kdGrzyjICPauknGpnHkObuJrqwAWA.TrPgHHGcLqPkHeSUeordTutFXjWpA);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wqpFgSigBpdxcTYIaAwdOVWChqmw
			return this.wqpFgSigBpdxcTYIaAwdOVWChqmw(P_0);
		}

		private void TwMOmIyOAUPnYurNypzGIWvzVDoc(KeyValuePair<TKey, TValue>[] P_0, int P_1)
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
			int count = IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs, IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].TrPgHHGcLqPkHeSUeordTutFXjWpA);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TwMOmIyOAUPnYurNypzGIWvzVDoc
			this.TwMOmIyOAUPnYurNypzGIWvzVDoc(P_0, P_1);
		}

		private bool dSKLYbyWRPlfMwFXoZJwwpehCoZJA(KeyValuePair<TKey, TValue> P_0)
		{
			if (GIGaMJjMIUUkfDGOMuaUQPjKQqZg)
			{
				bool result = false;
				for (int num = IzMFncBSDamNMoxBXGmIrjYnMsGd._count - 1; num >= 0; num--)
				{
					KdGrzyjICPauknGpnHkObuJrqwAWA kdGrzyjICPauknGpnHkObuJrqwAWA = IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num];
					if (ENTYlYIyJzuPCYldXCuEzxqKfomV.Equals(P_0.Value, kdGrzyjICPauknGpnHkObuJrqwAWA.TrPgHHGcLqPkHeSUeordTutFXjWpA))
					{
						IzMFncBSDamNMoxBXGmIrjYnMsGd.RemoveAt(num);
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
			KdGrzyjICPauknGpnHkObuJrqwAWA kdGrzyjICPauknGpnHkObuJrqwAWA2 = IzMFncBSDamNMoxBXGmIrjYnMsGd._items[num2];
			if (!ENTYlYIyJzuPCYldXCuEzxqKfomV.Equals(P_0.Value, kdGrzyjICPauknGpnHkObuJrqwAWA2.TrPgHHGcLqPkHeSUeordTutFXjWpA))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dSKLYbyWRPlfMwFXoZJwwpehCoZJA
			return this.dSKLYbyWRPlfMwFXoZJwwpehCoZJA(P_0);
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
			int count = IzMFncBSDamNMoxBXGmIrjYnMsGd._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].ZmqYxjpxeodtTVaKeFtQGsPEXZNs, IzMFncBSDamNMoxBXGmIrjYnMsGd._items[i].TrPgHHGcLqPkHeSUeordTutFXjWpA), index++);
			}
		}

		private int axuwEAcflYTuEHBTSFdZktsdlgXG(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in axuwEAcflYTuEHBTSFdZktsdlgXG
			return this.axuwEAcflYTuEHBTSFdZktsdlgXG(P_0);
		}

		private bool pUuNPHqtEfAQHiHeIHQhgfZsBPmn(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pUuNPHqtEfAQHiHeIHQhgfZsBPmn
			return this.pUuNPHqtEfAQHiHeIHQhgfZsBPmn(P_0);
		}

		private int mXBwiBcWCWoMIxuUgEXYijNwHvbo(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mXBwiBcWCWoMIxuUgEXYijNwHvbo
			return this.mXBwiBcWCWoMIxuUgEXYijNwHvbo(P_0);
		}

		private bool IKildBxQFkcwZUlDnzxHXMleeJXs(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IKildBxQFkcwZUlDnzxHXMleeJXs
			return this.IKildBxQFkcwZUlDnzxHXMleeJXs(P_0);
		}
	}
}
