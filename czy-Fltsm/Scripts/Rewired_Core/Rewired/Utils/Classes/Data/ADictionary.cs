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
			private ADictionary<TKey, TValue> DuFerRXUPifdsEMfBkJOrfkWpGyZA;

			private int QcmmfKkZJpiLnBfiArtGqjPgUcPl;

			private int IEZvffYcQgzKTsPsvSfBXaafqcfw;

			private KeyValuePair<TKey, TValue> XKYcMJCrUHKiHntlMZIWrJTxnDby;

			private int CFkXrmQGTtgOSFthZKsMBcLLBtYu;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => XKYcMJCrUHKiHntlMZIWrJTxnDby;

			object IEnumerator.Current
			{
				get
				{
					if (IEZvffYcQgzKTsPsvSfBXaafqcfw == 0 || IEZvffYcQgzKTsPsvSfBXaafqcfw == DuFerRXUPifdsEMfBkJOrfkWpGyZA._count + 1)
					{
						throw new Exception();
					}
					if (CFkXrmQGTtgOSFthZKsMBcLLBtYu == 1)
					{
						return new DictionaryEntry(XKYcMJCrUHKiHntlMZIWrJTxnDby.Key, XKYcMJCrUHKiHntlMZIWrJTxnDby.Value);
					}
					return new KeyValuePair<TKey, TValue>(XKYcMJCrUHKiHntlMZIWrJTxnDby.Key, XKYcMJCrUHKiHntlMZIWrJTxnDby.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (IEZvffYcQgzKTsPsvSfBXaafqcfw == 0 || IEZvffYcQgzKTsPsvSfBXaafqcfw == DuFerRXUPifdsEMfBkJOrfkWpGyZA._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(XKYcMJCrUHKiHntlMZIWrJTxnDby.Key, XKYcMJCrUHKiHntlMZIWrJTxnDby.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (IEZvffYcQgzKTsPsvSfBXaafqcfw == 0 || IEZvffYcQgzKTsPsvSfBXaafqcfw == DuFerRXUPifdsEMfBkJOrfkWpGyZA._count + 1)
					{
						throw new Exception();
					}
					return XKYcMJCrUHKiHntlMZIWrJTxnDby.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (IEZvffYcQgzKTsPsvSfBXaafqcfw == 0 || IEZvffYcQgzKTsPsvSfBXaafqcfw == DuFerRXUPifdsEMfBkJOrfkWpGyZA._count + 1)
					{
						throw new Exception();
					}
					return XKYcMJCrUHKiHntlMZIWrJTxnDby.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				DuFerRXUPifdsEMfBkJOrfkWpGyZA = P_0;
				QcmmfKkZJpiLnBfiArtGqjPgUcPl = P_0.iiXlpfrJUlLAUGCUYrVPGZyKtEbM;
				IEZvffYcQgzKTsPsvSfBXaafqcfw = 0;
				CFkXrmQGTtgOSFthZKsMBcLLBtYu = P_1;
				XKYcMJCrUHKiHntlMZIWrJTxnDby = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (QcmmfKkZJpiLnBfiArtGqjPgUcPl != DuFerRXUPifdsEMfBkJOrfkWpGyZA.iiXlpfrJUlLAUGCUYrVPGZyKtEbM)
				{
					throw new Exception();
				}
				while ((uint)IEZvffYcQgzKTsPsvSfBXaafqcfw < (uint)DuFerRXUPifdsEMfBkJOrfkWpGyZA._count)
				{
					if (DuFerRXUPifdsEMfBkJOrfkWpGyZA._entries[IEZvffYcQgzKTsPsvSfBXaafqcfw].hashCode >= 0)
					{
						XKYcMJCrUHKiHntlMZIWrJTxnDby = new KeyValuePair<TKey, TValue>(DuFerRXUPifdsEMfBkJOrfkWpGyZA._entries[IEZvffYcQgzKTsPsvSfBXaafqcfw].key, DuFerRXUPifdsEMfBkJOrfkWpGyZA._entries[IEZvffYcQgzKTsPsvSfBXaafqcfw].value);
						IEZvffYcQgzKTsPsvSfBXaafqcfw++;
						return true;
					}
					IEZvffYcQgzKTsPsvSfBXaafqcfw++;
				}
				IEZvffYcQgzKTsPsvSfBXaafqcfw = DuFerRXUPifdsEMfBkJOrfkWpGyZA._count + 1;
				XKYcMJCrUHKiHntlMZIWrJTxnDby = default(KeyValuePair<TKey, TValue>);
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
				if (QcmmfKkZJpiLnBfiArtGqjPgUcPl != DuFerRXUPifdsEMfBkJOrfkWpGyZA.iiXlpfrJUlLAUGCUYrVPGZyKtEbM)
				{
					throw new Exception();
				}
				IEZvffYcQgzKTsPsvSfBXaafqcfw = 0;
				XKYcMJCrUHKiHntlMZIWrJTxnDby = default(KeyValuePair<TKey, TValue>);
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
				private ADictionary<TKey, TValue> IAlAtlWdOAICzCgqgQbwhRmDsBmc;

				private int AothEMPULgUkDleiXXvbyFZWlAWf;

				private int jZCxnfusdqbBaEzUdBjbPkytvDiNA;

				private TKey GcQtqAdHSLYKoTfiEKdiLoRHTSHr;

				TKey IEnumerator<TKey>.Current => GcQtqAdHSLYKoTfiEKdiLoRHTSHr;

				object IEnumerator.Current
				{
					get
					{
						if (AothEMPULgUkDleiXXvbyFZWlAWf == 0 || AothEMPULgUkDleiXXvbyFZWlAWf == IAlAtlWdOAICzCgqgQbwhRmDsBmc._count + 1)
						{
							throw new Exception();
						}
						return GcQtqAdHSLYKoTfiEKdiLoRHTSHr;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					IAlAtlWdOAICzCgqgQbwhRmDsBmc = P_0;
					jZCxnfusdqbBaEzUdBjbPkytvDiNA = P_0.iiXlpfrJUlLAUGCUYrVPGZyKtEbM;
					AothEMPULgUkDleiXXvbyFZWlAWf = 0;
					GcQtqAdHSLYKoTfiEKdiLoRHTSHr = default(TKey);
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
					if (jZCxnfusdqbBaEzUdBjbPkytvDiNA != IAlAtlWdOAICzCgqgQbwhRmDsBmc.iiXlpfrJUlLAUGCUYrVPGZyKtEbM)
					{
						throw new Exception();
					}
					while ((uint)AothEMPULgUkDleiXXvbyFZWlAWf < (uint)IAlAtlWdOAICzCgqgQbwhRmDsBmc._count)
					{
						if (IAlAtlWdOAICzCgqgQbwhRmDsBmc._entries[AothEMPULgUkDleiXXvbyFZWlAWf].hashCode >= 0)
						{
							GcQtqAdHSLYKoTfiEKdiLoRHTSHr = IAlAtlWdOAICzCgqgQbwhRmDsBmc._entries[AothEMPULgUkDleiXXvbyFZWlAWf].key;
							AothEMPULgUkDleiXXvbyFZWlAWf++;
							return true;
						}
						AothEMPULgUkDleiXXvbyFZWlAWf++;
					}
					AothEMPULgUkDleiXXvbyFZWlAWf = IAlAtlWdOAICzCgqgQbwhRmDsBmc._count + 1;
					GcQtqAdHSLYKoTfiEKdiLoRHTSHr = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (jZCxnfusdqbBaEzUdBjbPkytvDiNA != IAlAtlWdOAICzCgqgQbwhRmDsBmc.iiXlpfrJUlLAUGCUYrVPGZyKtEbM)
					{
						throw new Exception();
					}
					AothEMPULgUkDleiXXvbyFZWlAWf = 0;
					GcQtqAdHSLYKoTfiEKdiLoRHTSHr = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> hnFHxkUuLZeaYAdxcyBKjkQaCKqX;

			int ICollection<TKey>.Count => hnFHxkUuLZeaYAdxcyBKjkQaCKqX.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)hnFHxkUuLZeaYAdxcyBKjkQaCKqX).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				hnFHxkUuLZeaYAdxcyBKjkQaCKqX = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(hnFHxkUuLZeaYAdxcyBKjkQaCKqX);
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
				if (array.Length - index < hnFHxkUuLZeaYAdxcyBKjkQaCKqX.Count)
				{
					throw new Exception();
				}
				int count = hnFHxkUuLZeaYAdxcyBKjkQaCKqX._count;
				Entry[] entries = hnFHxkUuLZeaYAdxcyBKjkQaCKqX._entries;
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

			private void hvCBEWHKzMShmunTzDsVGZhgoGwQA(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hvCBEWHKzMShmunTzDsVGZhgoGwQA
				this.hvCBEWHKzMShmunTzDsVGZhgoGwQA(P_0);
			}

			private void esVwapTomoxEVReLVTAjnWDgpyQn()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in esVwapTomoxEVReLVTAjnWDgpyQn
				this.esVwapTomoxEVReLVTAjnWDgpyQn();
			}

			private bool godVuFxTmQQIqOSyezKGOIRAavke(TKey P_0)
			{
				return hnFHxkUuLZeaYAdxcyBKjkQaCKqX.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in godVuFxTmQQIqOSyezKGOIRAavke
				return this.godVuFxTmQQIqOSyezKGOIRAavke(P_0);
			}

			private bool hxavJFkDsiiooIWtrEzCAuNCFksf(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hxavJFkDsiiooIWtrEzCAuNCFksf
				return this.hxavJFkDsiiooIWtrEzCAuNCFksf(P_0);
			}

			private IEnumerator<TKey> IeLiaMdimRccFPtUqiHyKdSOiiptA()
			{
				return new Enumerator(hnFHxkUuLZeaYAdxcyBKjkQaCKqX);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in IeLiaMdimRccFPtUqiHyKdSOiiptA
				return this.IeLiaMdimRccFPtUqiHyKdSOiiptA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(hnFHxkUuLZeaYAdxcyBKjkQaCKqX);
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
				if (array.Length - index < hnFHxkUuLZeaYAdxcyBKjkQaCKqX.Count)
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
				int count = hnFHxkUuLZeaYAdxcyBKjkQaCKqX._count;
				Entry[] entries = hnFHxkUuLZeaYAdxcyBKjkQaCKqX._entries;
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
				private ADictionary<TKey, TValue> ZfpinZOtocjRsQMYHnMPNgcIOlIq;

				private int UmyCIPSanOSyxFaExiRCerNyHHqeb;

				private int rulcPfwWWFxPnpiNBuimKTYBWdOe;

				private TValue hvfciLDllYTcFutLNAUEOQEvAFB;

				TValue IEnumerator<TValue>.Current => hvfciLDllYTcFutLNAUEOQEvAFB;

				object IEnumerator.Current
				{
					get
					{
						if (UmyCIPSanOSyxFaExiRCerNyHHqeb == 0 || UmyCIPSanOSyxFaExiRCerNyHHqeb == ZfpinZOtocjRsQMYHnMPNgcIOlIq._count + 1)
						{
							throw new Exception();
						}
						return hvfciLDllYTcFutLNAUEOQEvAFB;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					ZfpinZOtocjRsQMYHnMPNgcIOlIq = P_0;
					rulcPfwWWFxPnpiNBuimKTYBWdOe = P_0.iiXlpfrJUlLAUGCUYrVPGZyKtEbM;
					UmyCIPSanOSyxFaExiRCerNyHHqeb = 0;
					hvfciLDllYTcFutLNAUEOQEvAFB = default(TValue);
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
					if (rulcPfwWWFxPnpiNBuimKTYBWdOe != ZfpinZOtocjRsQMYHnMPNgcIOlIq.iiXlpfrJUlLAUGCUYrVPGZyKtEbM)
					{
						throw new Exception();
					}
					while ((uint)UmyCIPSanOSyxFaExiRCerNyHHqeb < (uint)ZfpinZOtocjRsQMYHnMPNgcIOlIq._count)
					{
						if (ZfpinZOtocjRsQMYHnMPNgcIOlIq._entries[UmyCIPSanOSyxFaExiRCerNyHHqeb].hashCode >= 0)
						{
							hvfciLDllYTcFutLNAUEOQEvAFB = ZfpinZOtocjRsQMYHnMPNgcIOlIq._entries[UmyCIPSanOSyxFaExiRCerNyHHqeb].value;
							UmyCIPSanOSyxFaExiRCerNyHHqeb++;
							return true;
						}
						UmyCIPSanOSyxFaExiRCerNyHHqeb++;
					}
					UmyCIPSanOSyxFaExiRCerNyHHqeb = ZfpinZOtocjRsQMYHnMPNgcIOlIq._count + 1;
					hvfciLDllYTcFutLNAUEOQEvAFB = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (rulcPfwWWFxPnpiNBuimKTYBWdOe != ZfpinZOtocjRsQMYHnMPNgcIOlIq.iiXlpfrJUlLAUGCUYrVPGZyKtEbM)
					{
						throw new Exception();
					}
					UmyCIPSanOSyxFaExiRCerNyHHqeb = 0;
					hvfciLDllYTcFutLNAUEOQEvAFB = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> sMvrleDrszJKxbFwUsvojVXRnvwg;

			int ICollection<TValue>.Count => sMvrleDrszJKxbFwUsvojVXRnvwg.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)sMvrleDrszJKxbFwUsvojVXRnvwg).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				sMvrleDrszJKxbFwUsvojVXRnvwg = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(sMvrleDrszJKxbFwUsvojVXRnvwg);
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
				if (array.Length - index < sMvrleDrszJKxbFwUsvojVXRnvwg.Count)
				{
					throw new Exception();
				}
				int count = sMvrleDrszJKxbFwUsvojVXRnvwg._count;
				Entry[] entries = sMvrleDrszJKxbFwUsvojVXRnvwg._entries;
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

			private void PeUkkHkdDmyAjcatstBLNJkricnJ(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in PeUkkHkdDmyAjcatstBLNJkricnJ
				this.PeUkkHkdDmyAjcatstBLNJkricnJ(P_0);
			}

			private bool KpqDsEbrhDbhSWQRJXqZLBRwByaL(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in KpqDsEbrhDbhSWQRJXqZLBRwByaL
				return this.KpqDsEbrhDbhSWQRJXqZLBRwByaL(P_0);
			}

			private void mxYkpQkcQEspubmMzzpWpIPCHKXf()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in mxYkpQkcQEspubmMzzpWpIPCHKXf
				this.mxYkpQkcQEspubmMzzpWpIPCHKXf();
			}

			private bool UFgEwdWwInkgMPqrfwmYLKJbbfSi(TValue P_0)
			{
				return sMvrleDrszJKxbFwUsvojVXRnvwg.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in UFgEwdWwInkgMPqrfwmYLKJbbfSi
				return this.UFgEwdWwInkgMPqrfwmYLKJbbfSi(P_0);
			}

			private IEnumerator<TValue> GXQGWBrhxXmoeuRAMpjyoWHDlCrE()
			{
				return new Enumerator(sMvrleDrszJKxbFwUsvojVXRnvwg);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in GXQGWBrhxXmoeuRAMpjyoWHDlCrE
				return this.GXQGWBrhxXmoeuRAMpjyoWHDlCrE();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(sMvrleDrszJKxbFwUsvojVXRnvwg);
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
				if (array.Length - index < sMvrleDrszJKxbFwUsvojVXRnvwg.Count)
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
				int count = sMvrleDrszJKxbFwUsvojVXRnvwg._count;
				Entry[] entries = sMvrleDrszJKxbFwUsvojVXRnvwg._entries;
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

		private int[] gVHYOKVCxPHLmEqHZuwohHjgEQjB;

		internal Entry[] _entries;

		internal int _count;

		private int iiXlpfrJUlLAUGCUYrVPGZyKtEbM;

		private int rDWfnlRLMfunWfNZZbMCXPlzhdWg;

		private int xTbSAgopsbLoLUkGReirKYRzEYst;

		private int nJcBUjVyuOpckOQgDKZrUOhZRVwE;

		private IEqualityComparer<TKey> qxYojbnHWmDpqdVsJYaGzsGphtUe;

		private IEqualityComparer<TValue> YuLppDKblmgjLBljzbETdjhIjkvMb;

		private KeyCollection KxkUxKIjtVRWMsZpCgfcCQDFbIHL;

		private ValueCollection RGtpNFnDtqKCARnhqzSsnapmYRXr;

		private readonly object QHNFGTclufHyNnhxHANxULcJByvF = new object();

		private static readonly bool MGRlJnYsdJhCukqhlDRCfUZQXJMB = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool aIWcHxnvvHikhjLFywjTdKLmpEtc = ReflectionTools.IsValueType(typeof(TValue));

		private const string FYzIUeYtnBmjbeYkUPZcWNaynmil = "Version";

		private const string DmEbqMCtaPaKqbEjEJXYWAiezfRBb = "HashSize";

		private const string CflAjkxuLzcumMKsRwlHdOBysVLk = "KeyValuePairs";

		private const string gGivGySiLHBAXrPFbVcQYmFneOev = "Comparer";

		int ICollection<KeyValuePair<TKey, TValue>>.Count => _count - nJcBUjVyuOpckOQgDKZrUOhZRVwE;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (KxkUxKIjtVRWMsZpCgfcCQDFbIHL == null)
				{
					KxkUxKIjtVRWMsZpCgfcCQDFbIHL = new KeyCollection(this);
				}
				return KxkUxKIjtVRWMsZpCgfcCQDFbIHL;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (RGtpNFnDtqKCARnhqzSsnapmYRXr == null)
				{
					RGtpNFnDtqKCARnhqzSsnapmYRXr = new ValueCollection(this);
				}
				return RGtpNFnDtqKCARnhqzSsnapmYRXr;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return qxYojbnHWmDpqdVsJYaGzsGphtUe;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				qxYojbnHWmDpqdVsJYaGzsGphtUe = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return YuLppDKblmgjLBljzbETdjhIjkvMb;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				YuLppDKblmgjLBljzbETdjhIjkvMb = value;
			}
		}

		TValue Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.this[TKey key]
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
				MNvMELSKwzdGauyPTuuqqTslEOaK(key, value, false);
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
				if (KxkUxKIjtVRWMsZpCgfcCQDFbIHL == null)
				{
					KxkUxKIjtVRWMsZpCgfcCQDFbIHL = new KeyCollection(this);
				}
				return KxkUxKIjtVRWMsZpCgfcCQDFbIHL;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (RGtpNFnDtqKCARnhqzSsnapmYRXr == null)
				{
					RGtpNFnDtqKCARnhqzSsnapmYRXr = new ValueCollection(this);
				}
				return RGtpNFnDtqKCARnhqzSsnapmYRXr;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => QHNFGTclufHyNnhxHANxULcJByvF;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (uSZdMBsvBlfPttMCMSqDyxsMioZF(key))
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
				gOqcDOcvBUoiGdRzMzQgaxRLphbBA<TValue>(value, "value");
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
				XoxSenMIzkESdrnVamEczEPrBiwo(P_0);
			}
			qxYojbnHWmDpqdVsJYaGzsGphtUe = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			YuLppDKblmgjLBljzbETdjhIjkvMb = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
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
			MNvMELSKwzdGauyPTuuqqTslEOaK(key, value, true);
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
				for (int i = 0; i < gVHYOKVCxPHLmEqHZuwohHjgEQjB.Length; i++)
				{
					gVHYOKVCxPHLmEqHZuwohHjgEQjB[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				xTbSAgopsbLoLUkGReirKYRzEYst = -1;
				_count = 0;
				nJcBUjVyuOpckOQgDKZrUOhZRVwE = 0;
				iiXlpfrJUlLAUGCUYrVPGZyKtEbM++;
				rDWfnlRLMfunWfNZZbMCXPlzhdWg++;
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
			if (!MGRlJnYsdJhCukqhlDRCfUZQXJMB && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (gVHYOKVCxPHLmEqHZuwohHjgEQjB != null)
			{
				int num = qxYojbnHWmDpqdVsJYaGzsGphtUe.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % gVHYOKVCxPHLmEqHZuwohHjgEQjB.Length;
				int num3 = -1;
				for (int num4 = gVHYOKVCxPHLmEqHZuwohHjgEQjB[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && qxYojbnHWmDpqdVsJYaGzsGphtUe.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							gVHYOKVCxPHLmEqHZuwohHjgEQjB[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = xTbSAgopsbLoLUkGReirKYRzEYst;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						xTbSAgopsbLoLUkGReirKYRzEYst = num4;
						nJcBUjVyuOpckOQgDKZrUOhZRVwE++;
						iiXlpfrJUlLAUGCUYrVPGZyKtEbM++;
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
			if (!MGRlJnYsdJhCukqhlDRCfUZQXJMB && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (gVHYOKVCxPHLmEqHZuwohHjgEQjB != null)
			{
				int num = qxYojbnHWmDpqdVsJYaGzsGphtUe.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = gVHYOKVCxPHLmEqHZuwohHjgEQjB[num % gVHYOKVCxPHLmEqHZuwohHjgEQjB.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && qxYojbnHWmDpqdVsJYaGzsGphtUe.Equals(_entries[num2].key, key))
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
			if (!aIWcHxnvvHikhjLFywjTdKLmpEtc && value == null)
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
				IEqualityComparer<TValue> yuLppDKblmgjLBljzbETdjhIjkvMb = YuLppDKblmgjLBljzbETdjhIjkvMb;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && yuLppDKblmgjLBljzbETdjhIjkvMb.Equals(entries[j].value, value))
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

		private void XoxSenMIzkESdrnVamEczEPrBiwo(int P_0)
		{
			int num = GXweVSCpEkMhVoVUEVjVNOhTwtyFA.ZgVcNrhLwSWJyhIZculVMRNMcUMTA(P_0);
			gVHYOKVCxPHLmEqHZuwohHjgEQjB = new int[num];
			for (int i = 0; i < gVHYOKVCxPHLmEqHZuwohHjgEQjB.Length; i++)
			{
				gVHYOKVCxPHLmEqHZuwohHjgEQjB[i] = -1;
			}
			_entries = new Entry[num];
			xTbSAgopsbLoLUkGReirKYRzEYst = -1;
		}

		private void MNvMELSKwzdGauyPTuuqqTslEOaK(TKey P_0, TValue P_1, bool P_2)
		{
			if (!MGRlJnYsdJhCukqhlDRCfUZQXJMB && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (gVHYOKVCxPHLmEqHZuwohHjgEQjB == null)
			{
				XoxSenMIzkESdrnVamEczEPrBiwo(0);
			}
			int num = qxYojbnHWmDpqdVsJYaGzsGphtUe.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % gVHYOKVCxPHLmEqHZuwohHjgEQjB.Length;
			for (int num3 = gVHYOKVCxPHLmEqHZuwohHjgEQjB[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && qxYojbnHWmDpqdVsJYaGzsGphtUe.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					iiXlpfrJUlLAUGCUYrVPGZyKtEbM++;
					return;
				}
			}
			int count;
			if (nJcBUjVyuOpckOQgDKZrUOhZRVwE > 0)
			{
				count = xTbSAgopsbLoLUkGReirKYRzEYst;
				xTbSAgopsbLoLUkGReirKYRzEYst = _entries[count].next;
				nJcBUjVyuOpckOQgDKZrUOhZRVwE--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					YqxEQLQEhAditfmklxEWSlmfCYlBA();
					num2 = num % gVHYOKVCxPHLmEqHZuwohHjgEQjB.Length;
				}
				count = _count;
				_count++;
			}
			_entries[count].hashCode = num;
			_entries[count].next = gVHYOKVCxPHLmEqHZuwohHjgEQjB[num2];
			_entries[count].key = P_0;
			_entries[count].value = P_1;
			gVHYOKVCxPHLmEqHZuwohHjgEQjB[num2] = count;
			iiXlpfrJUlLAUGCUYrVPGZyKtEbM++;
			rDWfnlRLMfunWfNZZbMCXPlzhdWg++;
		}

		private void YqxEQLQEhAditfmklxEWSlmfCYlBA()
		{
			YxERAnohARHIecymIQpbAJxXEJGuA(GXweVSCpEkMhVoVUEVjVNOhTwtyFA.vQqhrDzNMHDdvdULDmBePkWqHjMGA(_count), false);
		}

		private void YxERAnohARHIecymIQpbAJxXEJGuA(int P_0, bool P_1)
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
						array2[j].hashCode = qxYojbnHWmDpqdVsJYaGzsGphtUe.GetHashCode(array2[j].key) & 0x7FFFFFFF;
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
			gVHYOKVCxPHLmEqHZuwohHjgEQjB = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> OeGxGBolGUhbSwYFIeKMXPfyVXvV()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OeGxGBolGUhbSwYFIeKMXPfyVXvV
			return this.OeGxGBolGUhbSwYFIeKMXPfyVXvV();
		}

		private void OowEEpVmhcCXPDkgRCBFcYVfUejdA(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OowEEpVmhcCXPDkgRCBFcYVfUejdA
			this.OowEEpVmhcCXPDkgRCBFcYVfUejdA(P_0);
		}

		private bool QiJeaEDSGmFutfiDjtXsUWDFKHPVA(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && YuLppDKblmgjLBljzbETdjhIjkvMb.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QiJeaEDSGmFutfiDjtXsUWDFKHPVA
			return this.QiJeaEDSGmFutfiDjtXsUWDFKHPVA(P_0);
		}

		private bool ORCBtLBjYTIIcDXiaWOjgOikyOfFA(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && YuLppDKblmgjLBljzbETdjhIjkvMb.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ORCBtLBjYTIIcDXiaWOjgOikyOfFA
			return this.ORCBtLBjYTIIcDXiaWOjgOikyOfFA(P_0);
		}

		private void bpwcfxHbinsdMTPwsrlpVBFIWtfm(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bpwcfxHbinsdMTPwsrlpVBFIWtfm
			this.bpwcfxHbinsdMTPwsrlpVBFIWtfm(P_0, P_1);
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
			gOqcDOcvBUoiGdRzMzQgaxRLphbBA<TValue>(value, "value");
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
			if (uSZdMBsvBlfPttMCMSqDyxsMioZF(key))
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
			if (uSZdMBsvBlfPttMCMSqDyxsMioZF(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool uSZdMBsvBlfPttMCMSqDyxsMioZF(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void gOqcDOcvBUoiGdRzMzQgaxRLphbBA<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
