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
		private struct WFESlbHXaRckYIQPqvflbSHQkfYm
		{
			public TKey XhyNngTKCyfnrgWodSchXrHzKWLt;

			public TValue LKBGVUIUxursjvoytcsQetzgjkYoA;

			public WFESlbHXaRckYIQPqvflbSHQkfYm(TKey P_0, TValue P_1)
			{
				XhyNngTKCyfnrgWodSchXrHzKWLt = P_0;
				LKBGVUIUxursjvoytcsQetzgjkYoA = P_1;
			}

			public KeyValuePair<TKey, TValue> xtHfmfdfWYbaHCZvkadIeLbUmIVIA()
			{
				return new KeyValuePair<TKey, TValue>(XhyNngTKCyfnrgWodSchXrHzKWLt, LKBGVUIUxursjvoytcsQetzgjkYoA);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> dQaFwPdtiBfvgLTZGNVvdAUvMBxj;

			private int DhpZqOiMtOLxsZozndgzrfWSqlHT;

			private int JvUxzBoPJqZIUglJljxajjLuSrcE;

			private KeyValuePair<TKey, TValue> BRqYHWyKEtEeOVHVYQvUNVyYCsof;

			private int FhgeXGtIrEpPFrFprXVdQiCudzow;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => BRqYHWyKEtEeOVHVYQvUNVyYCsof;

			object IEnumerator.Current
			{
				get
				{
					if (JvUxzBoPJqZIUglJljxajjLuSrcE == 0 || JvUxzBoPJqZIUglJljxajjLuSrcE == dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1)
					{
						throw new Exception();
					}
					if (FhgeXGtIrEpPFrFprXVdQiCudzow == 1)
					{
						return new DictionaryEntry(BRqYHWyKEtEeOVHVYQvUNVyYCsof.Key, BRqYHWyKEtEeOVHVYQvUNVyYCsof.Value);
					}
					return new KeyValuePair<TKey, TValue>(BRqYHWyKEtEeOVHVYQvUNVyYCsof.Key, BRqYHWyKEtEeOVHVYQvUNVyYCsof.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (JvUxzBoPJqZIUglJljxajjLuSrcE == 0 || JvUxzBoPJqZIUglJljxajjLuSrcE == dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(BRqYHWyKEtEeOVHVYQvUNVyYCsof.Key, BRqYHWyKEtEeOVHVYQvUNVyYCsof.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (JvUxzBoPJqZIUglJljxajjLuSrcE == 0 || JvUxzBoPJqZIUglJljxajjLuSrcE == dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1)
					{
						throw new Exception();
					}
					return BRqYHWyKEtEeOVHVYQvUNVyYCsof.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (JvUxzBoPJqZIUglJljxajjLuSrcE == 0 || JvUxzBoPJqZIUglJljxajjLuSrcE == dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1)
					{
						throw new Exception();
					}
					return BRqYHWyKEtEeOVHVYQvUNVyYCsof.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				dQaFwPdtiBfvgLTZGNVvdAUvMBxj = P_0;
				DhpZqOiMtOLxsZozndgzrfWSqlHT = P_0.MWARdttYcoylkBSJUZirqNlUBPCJ.Version;
				JvUxzBoPJqZIUglJljxajjLuSrcE = 0;
				FhgeXGtIrEpPFrFprXVdQiCudzow = P_1;
				BRqYHWyKEtEeOVHVYQvUNVyYCsof = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (DhpZqOiMtOLxsZozndgzrfWSqlHT != dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ.Version)
				{
					throw new Exception();
				}
				if ((uint)JvUxzBoPJqZIUglJljxajjLuSrcE < (uint)dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._count)
				{
					BRqYHWyKEtEeOVHVYQvUNVyYCsof = new KeyValuePair<TKey, TValue>(dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._items[JvUxzBoPJqZIUglJljxajjLuSrcE].XhyNngTKCyfnrgWodSchXrHzKWLt, dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._items[JvUxzBoPJqZIUglJljxajjLuSrcE].LKBGVUIUxursjvoytcsQetzgjkYoA);
					JvUxzBoPJqZIUglJljxajjLuSrcE++;
					return true;
				}
				JvUxzBoPJqZIUglJljxajjLuSrcE = dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1;
				BRqYHWyKEtEeOVHVYQvUNVyYCsof = default(KeyValuePair<TKey, TValue>);
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
				if (DhpZqOiMtOLxsZozndgzrfWSqlHT != dQaFwPdtiBfvgLTZGNVvdAUvMBxj.MWARdttYcoylkBSJUZirqNlUBPCJ.Version)
				{
					throw new Exception();
				}
				JvUxzBoPJqZIUglJljxajjLuSrcE = 0;
				BRqYHWyKEtEeOVHVYQvUNVyYCsof = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> eMShNyiMpkYxCTffsWvyIVueCovB;

				private int zTTRbqHiPmFfGIubAIpislVcTzbM;

				private int SpSnvOfqaVWCGrXFACfzxjkUDxct;

				private TKey xUryeYOIWbEzkLolULKKwaZIqNDj;

				TKey IEnumerator<TKey>.Current => xUryeYOIWbEzkLolULKKwaZIqNDj;

				object IEnumerator.Current
				{
					get
					{
						if (zTTRbqHiPmFfGIubAIpislVcTzbM == 0 || zTTRbqHiPmFfGIubAIpislVcTzbM == eMShNyiMpkYxCTffsWvyIVueCovB.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1)
						{
							throw new Exception();
						}
						return xUryeYOIWbEzkLolULKKwaZIqNDj;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					eMShNyiMpkYxCTffsWvyIVueCovB = P_0;
					SpSnvOfqaVWCGrXFACfzxjkUDxct = P_0.MWARdttYcoylkBSJUZirqNlUBPCJ.Version;
					zTTRbqHiPmFfGIubAIpislVcTzbM = 0;
					xUryeYOIWbEzkLolULKKwaZIqNDj = default(TKey);
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
					if (SpSnvOfqaVWCGrXFACfzxjkUDxct != eMShNyiMpkYxCTffsWvyIVueCovB.MWARdttYcoylkBSJUZirqNlUBPCJ.Version)
					{
						throw new Exception();
					}
					if ((uint)zTTRbqHiPmFfGIubAIpislVcTzbM < (uint)eMShNyiMpkYxCTffsWvyIVueCovB.MWARdttYcoylkBSJUZirqNlUBPCJ._count)
					{
						xUryeYOIWbEzkLolULKKwaZIqNDj = eMShNyiMpkYxCTffsWvyIVueCovB.MWARdttYcoylkBSJUZirqNlUBPCJ._items[zTTRbqHiPmFfGIubAIpislVcTzbM].XhyNngTKCyfnrgWodSchXrHzKWLt;
						zTTRbqHiPmFfGIubAIpislVcTzbM++;
						return true;
					}
					zTTRbqHiPmFfGIubAIpislVcTzbM = eMShNyiMpkYxCTffsWvyIVueCovB.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1;
					xUryeYOIWbEzkLolULKKwaZIqNDj = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (SpSnvOfqaVWCGrXFACfzxjkUDxct != eMShNyiMpkYxCTffsWvyIVueCovB.MWARdttYcoylkBSJUZirqNlUBPCJ.Version)
					{
						throw new Exception();
					}
					zTTRbqHiPmFfGIubAIpislVcTzbM = 0;
					xUryeYOIWbEzkLolULKKwaZIqNDj = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> DbBhAOeQiZPhpHYYlgXYacudEVlgb;

			int ICollection.Count => DbBhAOeQiZPhpHYYlgXYacudEVlgb.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)DbBhAOeQiZPhpHYYlgXYacudEVlgb).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				DbBhAOeQiZPhpHYYlgXYacudEVlgb = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(DbBhAOeQiZPhpHYYlgXYacudEVlgb);
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
				if (array.Length - index < DbBhAOeQiZPhpHYYlgXYacudEVlgb.Count)
				{
					throw new Exception();
				}
				int count = DbBhAOeQiZPhpHYYlgXYacudEVlgb.MWARdttYcoylkBSJUZirqNlUBPCJ._count;
				WFESlbHXaRckYIQPqvflbSHQkfYm[] items = DbBhAOeQiZPhpHYYlgXYacudEVlgb.MWARdttYcoylkBSJUZirqNlUBPCJ._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].XhyNngTKCyfnrgWodSchXrHzKWLt;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void nSzyPfEJZlWBvtFvrkKZAEnQmWvi(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in nSzyPfEJZlWBvtFvrkKZAEnQmWvi
				this.nSzyPfEJZlWBvtFvrkKZAEnQmWvi(P_0);
			}

			private void LZWWStYmZXajHcKgyNUloqkOESxFb()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in LZWWStYmZXajHcKgyNUloqkOESxFb
				this.LZWWStYmZXajHcKgyNUloqkOESxFb();
			}

			private bool vQpDDklKRLEdgMraJoUlbAwBfxtl(TKey P_0)
			{
				return DbBhAOeQiZPhpHYYlgXYacudEVlgb.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in vQpDDklKRLEdgMraJoUlbAwBfxtl
				return this.vQpDDklKRLEdgMraJoUlbAwBfxtl(P_0);
			}

			private bool aizUqIJlSiPacYxDAIzlTpTkPscB(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in aizUqIJlSiPacYxDAIzlTpTkPscB
				return this.aizUqIJlSiPacYxDAIzlTpTkPscB(P_0);
			}

			private IEnumerator<TKey> MQXeuKzHebowvjmTcLwzODCtaWHT()
			{
				return new Enumerator(DbBhAOeQiZPhpHYYlgXYacudEVlgb);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MQXeuKzHebowvjmTcLwzODCtaWHT
				return this.MQXeuKzHebowvjmTcLwzODCtaWHT();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(DbBhAOeQiZPhpHYYlgXYacudEVlgb);
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
				if (array.Length - index < DbBhAOeQiZPhpHYYlgXYacudEVlgb.Count)
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
				int count = DbBhAOeQiZPhpHYYlgXYacudEVlgb.MWARdttYcoylkBSJUZirqNlUBPCJ._count;
				WFESlbHXaRckYIQPqvflbSHQkfYm[] items = DbBhAOeQiZPhpHYYlgXYacudEVlgb.MWARdttYcoylkBSJUZirqNlUBPCJ._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].XhyNngTKCyfnrgWodSchXrHzKWLt;
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
				private IndexedDictionary<TKey, TValue> xQelDdMtuOaeNjifIAzErAOoKGqj;

				private int cHdWvWUPcnqmuqNZMsNveiITltPh;

				private int HmFUokHBGLCffxMvDdYTCbGMRsWu;

				private TValue ahjKxWnSeqQFVZNJifJMioGsmOyy;

				TValue IEnumerator<TValue>.Current => ahjKxWnSeqQFVZNJifJMioGsmOyy;

				object IEnumerator.Current
				{
					get
					{
						if (cHdWvWUPcnqmuqNZMsNveiITltPh == 0 || cHdWvWUPcnqmuqNZMsNveiITltPh == xQelDdMtuOaeNjifIAzErAOoKGqj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1)
						{
							throw new Exception();
						}
						return ahjKxWnSeqQFVZNJifJMioGsmOyy;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					xQelDdMtuOaeNjifIAzErAOoKGqj = P_0;
					HmFUokHBGLCffxMvDdYTCbGMRsWu = P_0.MWARdttYcoylkBSJUZirqNlUBPCJ.Version;
					cHdWvWUPcnqmuqNZMsNveiITltPh = 0;
					ahjKxWnSeqQFVZNJifJMioGsmOyy = default(TValue);
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
					if (HmFUokHBGLCffxMvDdYTCbGMRsWu != xQelDdMtuOaeNjifIAzErAOoKGqj.MWARdttYcoylkBSJUZirqNlUBPCJ.Version)
					{
						throw new Exception();
					}
					if ((uint)cHdWvWUPcnqmuqNZMsNveiITltPh < (uint)xQelDdMtuOaeNjifIAzErAOoKGqj.MWARdttYcoylkBSJUZirqNlUBPCJ._count)
					{
						ahjKxWnSeqQFVZNJifJMioGsmOyy = xQelDdMtuOaeNjifIAzErAOoKGqj.MWARdttYcoylkBSJUZirqNlUBPCJ._items[cHdWvWUPcnqmuqNZMsNveiITltPh].LKBGVUIUxursjvoytcsQetzgjkYoA;
						cHdWvWUPcnqmuqNZMsNveiITltPh++;
						return true;
					}
					cHdWvWUPcnqmuqNZMsNveiITltPh = xQelDdMtuOaeNjifIAzErAOoKGqj.MWARdttYcoylkBSJUZirqNlUBPCJ._count + 1;
					ahjKxWnSeqQFVZNJifJMioGsmOyy = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (HmFUokHBGLCffxMvDdYTCbGMRsWu != xQelDdMtuOaeNjifIAzErAOoKGqj.MWARdttYcoylkBSJUZirqNlUBPCJ.Version)
					{
						throw new Exception();
					}
					cHdWvWUPcnqmuqNZMsNveiITltPh = 0;
					ahjKxWnSeqQFVZNJifJMioGsmOyy = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> wedissbYRqjNfuYGZppcFSwJUsZAA;

			int ICollection<TValue>.Count => wedissbYRqjNfuYGZppcFSwJUsZAA.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)wedissbYRqjNfuYGZppcFSwJUsZAA).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				wedissbYRqjNfuYGZppcFSwJUsZAA = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(wedissbYRqjNfuYGZppcFSwJUsZAA);
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
				if (array.Length - index < wedissbYRqjNfuYGZppcFSwJUsZAA.Count)
				{
					throw new Exception();
				}
				int count = wedissbYRqjNfuYGZppcFSwJUsZAA.MWARdttYcoylkBSJUZirqNlUBPCJ._count;
				WFESlbHXaRckYIQPqvflbSHQkfYm[] items = wedissbYRqjNfuYGZppcFSwJUsZAA.MWARdttYcoylkBSJUZirqNlUBPCJ._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].LKBGVUIUxursjvoytcsQetzgjkYoA;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void MKAxcXJPcjavohAhpOanBoqaFJYtB(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in MKAxcXJPcjavohAhpOanBoqaFJYtB
				this.MKAxcXJPcjavohAhpOanBoqaFJYtB(P_0);
			}

			private bool NvEYuldbHuIsZJcLsFOOUTnlAkjGb(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in NvEYuldbHuIsZJcLsFOOUTnlAkjGb
				return this.NvEYuldbHuIsZJcLsFOOUTnlAkjGb(P_0);
			}

			private void TdMBvNmupULFmFDXmGdatnlyeXLdA()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in TdMBvNmupULFmFDXmGdatnlyeXLdA
				this.TdMBvNmupULFmFDXmGdatnlyeXLdA();
			}

			private bool yKzdWGgPgVKGjVoqFEApKuhVXoUM(TValue P_0)
			{
				return wedissbYRqjNfuYGZppcFSwJUsZAA.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in yKzdWGgPgVKGjVoqFEApKuhVXoUM
				return this.yKzdWGgPgVKGjVoqFEApKuhVXoUM(P_0);
			}

			private IEnumerator<TValue> gJCMxEGemCZifJxeuPzDiJgIrtGi()
			{
				return new Enumerator(wedissbYRqjNfuYGZppcFSwJUsZAA);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in gJCMxEGemCZifJxeuPzDiJgIrtGi
				return this.gJCMxEGemCZifJxeuPzDiJgIrtGi();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(wedissbYRqjNfuYGZppcFSwJUsZAA);
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
				if (array.Length - index < wedissbYRqjNfuYGZppcFSwJUsZAA.Count)
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
				int count = wedissbYRqjNfuYGZppcFSwJUsZAA.MWARdttYcoylkBSJUZirqNlUBPCJ._count;
				WFESlbHXaRckYIQPqvflbSHQkfYm[] items = wedissbYRqjNfuYGZppcFSwJUsZAA.MWARdttYcoylkBSJUZirqNlUBPCJ._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].LKBGVUIUxursjvoytcsQetzgjkYoA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool HVxyUAssAKpwIxUUFSBGUJBRbgPL = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool rTjHiAvGofgmCCmpoHQNgNdBJVXrB = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> ejAdWPAYTMTZuJJSncPHiiBqdFzV = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> OITNxDuAjheRwdfXIXbvdomdnhkFb = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<WFESlbHXaRckYIQPqvflbSHQkfYm> MWARdttYcoylkBSJUZirqNlUBPCJ;

		private readonly ADictionary<TKey, int> ejvwKcsjVxXAJyqmMXhtKlDDXgAy;

		private bool IKKmSGNaqYWhDoCmBhxlFHpbRSZE;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => MWARdttYcoylkBSJUZirqNlUBPCJ._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!IKKmSGNaqYWhDoCmBhxlFHpbRSZE)
				{
					return false;
				}
				return ejvwKcsjVxXAJyqmMXhtKlDDXgAy._count < MWARdttYcoylkBSJUZirqNlUBPCJ._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return IKKmSGNaqYWhDoCmBhxlFHpbRSZE;
			}
			set
			{
				if (IKKmSGNaqYWhDoCmBhxlFHpbRSZE != value)
				{
					IKKmSGNaqYWhDoCmBhxlFHpbRSZE = value;
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
				if ((uint)index >= (uint)MWARdttYcoylkBSJUZirqNlUBPCJ._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return MWARdttYcoylkBSJUZirqNlUBPCJ._items[index].LKBGVUIUxursjvoytcsQetzgjkYoA;
			}
			set
			{
				if ((uint)index >= (uint)MWARdttYcoylkBSJUZirqNlUBPCJ._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				MWARdttYcoylkBSJUZirqNlUBPCJ._items[index].LKBGVUIUxursjvoytcsQetzgjkYoA = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return ejAdWPAYTMTZuJJSncPHiiBqdFzV;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				ejAdWPAYTMTZuJJSncPHiiBqdFzV = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return OITNxDuAjheRwdfXIXbvdomdnhkFb;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				OITNxDuAjheRwdfXIXbvdomdnhkFb = value;
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
				return MWARdttYcoylkBSJUZirqNlUBPCJ._items[num].LKBGVUIUxursjvoytcsQetzgjkYoA;
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

		bool ICollection.IsSynchronized => ((ICollection)MWARdttYcoylkBSJUZirqNlUBPCJ).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)MWARdttYcoylkBSJUZirqNlUBPCJ).SyncRoot;

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
			IKKmSGNaqYWhDoCmBhxlFHpbRSZE = P_1;
			MWARdttYcoylkBSJUZirqNlUBPCJ = new AList<WFESlbHXaRckYIQPqvflbSHQkfYm>(P_0);
			ejvwKcsjVxXAJyqmMXhtKlDDXgAy = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.MWARdttYcoylkBSJUZirqNlUBPCJ._count; i++)
				{
					Add(indexedDictionary.MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].XhyNngTKCyfnrgWodSchXrHzKWLt, indexedDictionary.MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].LKBGVUIUxursjvoytcsQetzgjkYoA);
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
			return MWARdttYcoylkBSJUZirqNlUBPCJ._items[ejvwKcsjVxXAJyqmMXhtKlDDXgAy[key]].LKBGVUIUxursjvoytcsQetzgjkYoA;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!ejvwKcsjVxXAJyqmMXhtKlDDXgAy.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = MWARdttYcoylkBSJUZirqNlUBPCJ._items[value2].LKBGVUIUxursjvoytcsQetzgjkYoA;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)MWARdttYcoylkBSJUZirqNlUBPCJ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<WFESlbHXaRckYIQPqvflbSHQkfYm, _003F>.WFESlbHXaRckYIQPqvflbSHQkfYm>)(object)MWARdttYcoylkBSJUZirqNlUBPCJ)[index].XhyNngTKCyfnrgWodSchXrHzKWLt;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<WFESlbHXaRckYIQPqvflbSHQkfYm, _003F>.WFESlbHXaRckYIQPqvflbSHQkfYm>)(object)MWARdttYcoylkBSJUZirqNlUBPCJ)[ejvwKcsjVxXAJyqmMXhtKlDDXgAy[key]].xtHfmfdfWYbaHCZvkadIeLbUmIVIA();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)MWARdttYcoylkBSJUZirqNlUBPCJ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<WFESlbHXaRckYIQPqvflbSHQkfYm, _003F>.WFESlbHXaRckYIQPqvflbSHQkfYm>)(object)MWARdttYcoylkBSJUZirqNlUBPCJ)[index].xtHfmfdfWYbaHCZvkadIeLbUmIVIA();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!ejvwKcsjVxXAJyqmMXhtKlDDXgAy.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<WFESlbHXaRckYIQPqvflbSHQkfYm, _003F>.WFESlbHXaRckYIQPqvflbSHQkfYm>)(object)MWARdttYcoylkBSJUZirqNlUBPCJ)[value].xtHfmfdfWYbaHCZvkadIeLbUmIVIA();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = ejvwKcsjVxXAJyqmMXhtKlDDXgAy.ContainsKey(key);
			if (num && !IKKmSGNaqYWhDoCmBhxlFHpbRSZE)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = MWARdttYcoylkBSJUZirqNlUBPCJ.Add(new WFESlbHXaRckYIQPqvflbSHQkfYm(key, value));
			if (num)
			{
				ejvwKcsjVxXAJyqmMXhtKlDDXgAy[key] = num2;
			}
			else
			{
				ejvwKcsjVxXAJyqmMXhtKlDDXgAy.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (ejvwKcsjVxXAJyqmMXhtKlDDXgAy.TryGetValue(key, out var value2))
			{
				MWARdttYcoylkBSJUZirqNlUBPCJ._items[value2].LKBGVUIUxursjvoytcsQetzgjkYoA = value;
				ejvwKcsjVxXAJyqmMXhtKlDDXgAy[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			ejvwKcsjVxXAJyqmMXhtKlDDXgAy.Remove(key);
			if (IKKmSGNaqYWhDoCmBhxlFHpbRSZE)
			{
				bool result = false;
				for (int num = MWARdttYcoylkBSJUZirqNlUBPCJ._count - 1; num >= 0; num--)
				{
					if (ejAdWPAYTMTZuJJSncPHiiBqdFzV.Equals(MWARdttYcoylkBSJUZirqNlUBPCJ._items[num].XhyNngTKCyfnrgWodSchXrHzKWLt, key))
					{
						MWARdttYcoylkBSJUZirqNlUBPCJ.RemoveAt(num);
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
			if ((uint)index >= (uint)MWARdttYcoylkBSJUZirqNlUBPCJ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey xhyNngTKCyfnrgWodSchXrHzKWLt = MWARdttYcoylkBSJUZirqNlUBPCJ._items[index].XhyNngTKCyfnrgWodSchXrHzKWLt;
			if (index < MWARdttYcoylkBSJUZirqNlUBPCJ._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<WFESlbHXaRckYIQPqvflbSHQkfYm, _003F>.WFESlbHXaRckYIQPqvflbSHQkfYm>)(object)MWARdttYcoylkBSJUZirqNlUBPCJ).Count; i++)
				{
					ejvwKcsjVxXAJyqmMXhtKlDDXgAy[MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].XhyNngTKCyfnrgWodSchXrHzKWLt] = i - 1;
				}
			}
			MWARdttYcoylkBSJUZirqNlUBPCJ.RemoveAt(index);
			ejvwKcsjVxXAJyqmMXhtKlDDXgAy.Remove(xhyNngTKCyfnrgWodSchXrHzKWLt);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref MWARdttYcoylkBSJUZirqNlUBPCJ._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = MWARdttYcoylkBSJUZirqNlUBPCJ._count - 1; num2 >= 0; num2--)
			{
				_ = ref MWARdttYcoylkBSJUZirqNlUBPCJ._items[num2];
				if (OITNxDuAjheRwdfXIXbvdomdnhkFb.Equals(MWARdttYcoylkBSJUZirqNlUBPCJ._items[num2].LKBGVUIUxursjvoytcsQetzgjkYoA, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!HVxyUAssAKpwIxUUFSBGUJBRbgPL && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = MWARdttYcoylkBSJUZirqNlUBPCJ._count;
			for (int i = 0; i < count; i++)
			{
				if (ejAdWPAYTMTZuJJSncPHiiBqdFzV.Equals(MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].XhyNngTKCyfnrgWodSchXrHzKWLt, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = MWARdttYcoylkBSJUZirqNlUBPCJ._count;
			for (int i = 0; i < count; i++)
			{
				if (OITNxDuAjheRwdfXIXbvdomdnhkFb.Equals(MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].LKBGVUIUxursjvoytcsQetzgjkYoA, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return ejvwKcsjVxXAJyqmMXhtKlDDXgAy.ContainsKey(key);
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
			MWARdttYcoylkBSJUZirqNlUBPCJ.Clear();
			ejvwKcsjVxXAJyqmMXhtKlDDXgAy.Clear();
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
			MWARdttYcoylkBSJUZirqNlUBPCJ.TrimExcess();
		}

		private void CqOqsbAAjgFOxBkVdyvsoyWaQziIA(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CqOqsbAAjgFOxBkVdyvsoyWaQziIA
			this.CqOqsbAAjgFOxBkVdyvsoyWaQziIA(P_0);
		}

		private bool esvFHRKxsvxQTeeSnnYxXCslfshB(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			WFESlbHXaRckYIQPqvflbSHQkfYm wFESlbHXaRckYIQPqvflbSHQkfYm = MWARdttYcoylkBSJUZirqNlUBPCJ._items[num];
			return OITNxDuAjheRwdfXIXbvdomdnhkFb.Equals(P_0.Value, wFESlbHXaRckYIQPqvflbSHQkfYm.LKBGVUIUxursjvoytcsQetzgjkYoA);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in esvFHRKxsvxQTeeSnnYxXCslfshB
			return this.esvFHRKxsvxQTeeSnnYxXCslfshB(P_0);
		}

		private void PSKQWRCmDOPPkNTIxcYrTCBKWYNd(KeyValuePair<TKey, TValue>[] P_0, int P_1)
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
			int count = MWARdttYcoylkBSJUZirqNlUBPCJ._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].XhyNngTKCyfnrgWodSchXrHzKWLt, MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].LKBGVUIUxursjvoytcsQetzgjkYoA);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PSKQWRCmDOPPkNTIxcYrTCBKWYNd
			this.PSKQWRCmDOPPkNTIxcYrTCBKWYNd(P_0, P_1);
		}

		private bool hwKWEeIxjBlbuJczrAKFGfuSLjHHb(KeyValuePair<TKey, TValue> P_0)
		{
			if (IKKmSGNaqYWhDoCmBhxlFHpbRSZE)
			{
				bool result = false;
				for (int num = MWARdttYcoylkBSJUZirqNlUBPCJ._count - 1; num >= 0; num--)
				{
					WFESlbHXaRckYIQPqvflbSHQkfYm wFESlbHXaRckYIQPqvflbSHQkfYm = MWARdttYcoylkBSJUZirqNlUBPCJ._items[num];
					if (OITNxDuAjheRwdfXIXbvdomdnhkFb.Equals(P_0.Value, wFESlbHXaRckYIQPqvflbSHQkfYm.LKBGVUIUxursjvoytcsQetzgjkYoA))
					{
						MWARdttYcoylkBSJUZirqNlUBPCJ.RemoveAt(num);
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
			WFESlbHXaRckYIQPqvflbSHQkfYm wFESlbHXaRckYIQPqvflbSHQkfYm2 = MWARdttYcoylkBSJUZirqNlUBPCJ._items[num2];
			if (!OITNxDuAjheRwdfXIXbvdomdnhkFb.Equals(P_0.Value, wFESlbHXaRckYIQPqvflbSHQkfYm2.LKBGVUIUxursjvoytcsQetzgjkYoA))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hwKWEeIxjBlbuJczrAKFGfuSLjHHb
			return this.hwKWEeIxjBlbuJczrAKFGfuSLjHHb(P_0);
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
			int count = MWARdttYcoylkBSJUZirqNlUBPCJ._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].XhyNngTKCyfnrgWodSchXrHzKWLt, MWARdttYcoylkBSJUZirqNlUBPCJ._items[i].LKBGVUIUxursjvoytcsQetzgjkYoA), index++);
			}
		}

		private int mUaizFOEJOViqeWtZARinjlGgOBI(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mUaizFOEJOViqeWtZARinjlGgOBI
			return this.mUaizFOEJOViqeWtZARinjlGgOBI(P_0);
		}

		private bool dqcVQOQkzfEwzFQEFWeYrJzBUDse(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dqcVQOQkzfEwzFQEFWeYrJzBUDse
			return this.dqcVQOQkzfEwzFQEFWeYrJzBUDse(P_0);
		}

		private int gSJluESwaYqUaCywjDAfpQLFssbM(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gSJluESwaYqUaCywjDAfpQLFssbM
			return this.gSJluESwaYqUaCywjDAfpQLFssbM(P_0);
		}

		private bool IiyybGVEdafgbEzxcvyscAzBbCXRA(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IiyybGVEdafgbEzxcvyscAzBbCXRA
			return this.IiyybGVEdafgbEzxcvyscAzBbCXRA(P_0);
		}
	}
}
