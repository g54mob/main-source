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
			private ADictionary<TKey, TValue> XORenUzXriIdOhmNWaCrciajINsCA;

			private int CysyZgIplnsXpeOFSwjCxZZlXLXA;

			private int CBRuzimCsaxUhViOmfkgaMsKIxnQA;

			private KeyValuePair<TKey, TValue> XlMkUYBpcBaWxEgRNcPpqQLWbEhx;

			private int CaoPqxelGxIVaoZyOZdrSDoqmpQE;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => XlMkUYBpcBaWxEgRNcPpqQLWbEhx;

			object IEnumerator.Current
			{
				get
				{
					if (CBRuzimCsaxUhViOmfkgaMsKIxnQA == 0 || CBRuzimCsaxUhViOmfkgaMsKIxnQA == XORenUzXriIdOhmNWaCrciajINsCA._count + 1)
					{
						throw new Exception();
					}
					if (CaoPqxelGxIVaoZyOZdrSDoqmpQE == 1)
					{
						return new DictionaryEntry(XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Key, XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Value);
					}
					return new KeyValuePair<TKey, TValue>(XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Key, XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (CBRuzimCsaxUhViOmfkgaMsKIxnQA == 0 || CBRuzimCsaxUhViOmfkgaMsKIxnQA == XORenUzXriIdOhmNWaCrciajINsCA._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Key, XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (CBRuzimCsaxUhViOmfkgaMsKIxnQA == 0 || CBRuzimCsaxUhViOmfkgaMsKIxnQA == XORenUzXriIdOhmNWaCrciajINsCA._count + 1)
					{
						throw new Exception();
					}
					return XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (CBRuzimCsaxUhViOmfkgaMsKIxnQA == 0 || CBRuzimCsaxUhViOmfkgaMsKIxnQA == XORenUzXriIdOhmNWaCrciajINsCA._count + 1)
					{
						throw new Exception();
					}
					return XlMkUYBpcBaWxEgRNcPpqQLWbEhx.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				XORenUzXriIdOhmNWaCrciajINsCA = P_0;
				CysyZgIplnsXpeOFSwjCxZZlXLXA = P_0.mFVYpeZiuzVGwdWuFFUsNlizVDbo;
				CBRuzimCsaxUhViOmfkgaMsKIxnQA = 0;
				CaoPqxelGxIVaoZyOZdrSDoqmpQE = P_1;
				XlMkUYBpcBaWxEgRNcPpqQLWbEhx = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (CysyZgIplnsXpeOFSwjCxZZlXLXA != XORenUzXriIdOhmNWaCrciajINsCA.mFVYpeZiuzVGwdWuFFUsNlizVDbo)
				{
					throw new Exception();
				}
				while ((uint)CBRuzimCsaxUhViOmfkgaMsKIxnQA < (uint)XORenUzXriIdOhmNWaCrciajINsCA._count)
				{
					if (XORenUzXriIdOhmNWaCrciajINsCA._entries[CBRuzimCsaxUhViOmfkgaMsKIxnQA].hashCode >= 0)
					{
						XlMkUYBpcBaWxEgRNcPpqQLWbEhx = new KeyValuePair<TKey, TValue>(XORenUzXriIdOhmNWaCrciajINsCA._entries[CBRuzimCsaxUhViOmfkgaMsKIxnQA].key, XORenUzXriIdOhmNWaCrciajINsCA._entries[CBRuzimCsaxUhViOmfkgaMsKIxnQA].value);
						CBRuzimCsaxUhViOmfkgaMsKIxnQA++;
						return true;
					}
					CBRuzimCsaxUhViOmfkgaMsKIxnQA++;
				}
				CBRuzimCsaxUhViOmfkgaMsKIxnQA = XORenUzXriIdOhmNWaCrciajINsCA._count + 1;
				XlMkUYBpcBaWxEgRNcPpqQLWbEhx = default(KeyValuePair<TKey, TValue>);
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
				if (CysyZgIplnsXpeOFSwjCxZZlXLXA != XORenUzXriIdOhmNWaCrciajINsCA.mFVYpeZiuzVGwdWuFFUsNlizVDbo)
				{
					throw new Exception();
				}
				CBRuzimCsaxUhViOmfkgaMsKIxnQA = 0;
				XlMkUYBpcBaWxEgRNcPpqQLWbEhx = default(KeyValuePair<TKey, TValue>);
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
				private ADictionary<TKey, TValue> UzrbSygKHWcKotLIhANUgMBuilZU;

				private int OrzzzVxlEyGvxKOqWKOApVZjwoSD;

				private int pVCmveETDgrFGGQewgeWtjuOcEcQ;

				private TKey UgQlvFRHuRUwMqMMLgmBGaTekRDP;

				TKey IEnumerator<TKey>.Current => UgQlvFRHuRUwMqMMLgmBGaTekRDP;

				object IEnumerator.Current
				{
					get
					{
						if (OrzzzVxlEyGvxKOqWKOApVZjwoSD == 0 || OrzzzVxlEyGvxKOqWKOApVZjwoSD == UzrbSygKHWcKotLIhANUgMBuilZU._count + 1)
						{
							throw new Exception();
						}
						return UgQlvFRHuRUwMqMMLgmBGaTekRDP;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					UzrbSygKHWcKotLIhANUgMBuilZU = P_0;
					pVCmveETDgrFGGQewgeWtjuOcEcQ = P_0.mFVYpeZiuzVGwdWuFFUsNlizVDbo;
					OrzzzVxlEyGvxKOqWKOApVZjwoSD = 0;
					UgQlvFRHuRUwMqMMLgmBGaTekRDP = default(TKey);
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
					if (pVCmveETDgrFGGQewgeWtjuOcEcQ != UzrbSygKHWcKotLIhANUgMBuilZU.mFVYpeZiuzVGwdWuFFUsNlizVDbo)
					{
						throw new Exception();
					}
					while ((uint)OrzzzVxlEyGvxKOqWKOApVZjwoSD < (uint)UzrbSygKHWcKotLIhANUgMBuilZU._count)
					{
						if (UzrbSygKHWcKotLIhANUgMBuilZU._entries[OrzzzVxlEyGvxKOqWKOApVZjwoSD].hashCode >= 0)
						{
							UgQlvFRHuRUwMqMMLgmBGaTekRDP = UzrbSygKHWcKotLIhANUgMBuilZU._entries[OrzzzVxlEyGvxKOqWKOApVZjwoSD].key;
							OrzzzVxlEyGvxKOqWKOApVZjwoSD++;
							return true;
						}
						OrzzzVxlEyGvxKOqWKOApVZjwoSD++;
					}
					OrzzzVxlEyGvxKOqWKOApVZjwoSD = UzrbSygKHWcKotLIhANUgMBuilZU._count + 1;
					UgQlvFRHuRUwMqMMLgmBGaTekRDP = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (pVCmveETDgrFGGQewgeWtjuOcEcQ != UzrbSygKHWcKotLIhANUgMBuilZU.mFVYpeZiuzVGwdWuFFUsNlizVDbo)
					{
						throw new Exception();
					}
					OrzzzVxlEyGvxKOqWKOApVZjwoSD = 0;
					UgQlvFRHuRUwMqMMLgmBGaTekRDP = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> lTLfhvdezRNaoUpLjhKfciGPxHihb;

			int ICollection<TKey>.Count => lTLfhvdezRNaoUpLjhKfciGPxHihb.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)lTLfhvdezRNaoUpLjhKfciGPxHihb).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				lTLfhvdezRNaoUpLjhKfciGPxHihb = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(lTLfhvdezRNaoUpLjhKfciGPxHihb);
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
				if (array.Length - index < lTLfhvdezRNaoUpLjhKfciGPxHihb.Count)
				{
					throw new Exception();
				}
				int count = lTLfhvdezRNaoUpLjhKfciGPxHihb._count;
				Entry[] entries = lTLfhvdezRNaoUpLjhKfciGPxHihb._entries;
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

			private void fAbYVVnDUtxMeBngCrkrSpHaHkeb(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in fAbYVVnDUtxMeBngCrkrSpHaHkeb
				this.fAbYVVnDUtxMeBngCrkrSpHaHkeb(P_0);
			}

			private void eOVlgmxBEgXCnmylEiVQuPXHbvEAA()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in eOVlgmxBEgXCnmylEiVQuPXHbvEAA
				this.eOVlgmxBEgXCnmylEiVQuPXHbvEAA();
			}

			private bool wRnLJWZjjSORSbbsnylbJTKfvQak(TKey P_0)
			{
				return lTLfhvdezRNaoUpLjhKfciGPxHihb.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in wRnLJWZjjSORSbbsnylbJTKfvQak
				return this.wRnLJWZjjSORSbbsnylbJTKfvQak(P_0);
			}

			private bool fbezNYANAyaZEjLRoRTfFsTtGkmg(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in fbezNYANAyaZEjLRoRTfFsTtGkmg
				return this.fbezNYANAyaZEjLRoRTfFsTtGkmg(P_0);
			}

			private IEnumerator<TKey> GfPigBAGAJTatGTchcGRgDApqpdV()
			{
				return new Enumerator(lTLfhvdezRNaoUpLjhKfciGPxHihb);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in GfPigBAGAJTatGTchcGRgDApqpdV
				return this.GfPigBAGAJTatGTchcGRgDApqpdV();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(lTLfhvdezRNaoUpLjhKfciGPxHihb);
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
				if (array.Length - index < lTLfhvdezRNaoUpLjhKfciGPxHihb.Count)
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
				int count = lTLfhvdezRNaoUpLjhKfciGPxHihb._count;
				Entry[] entries = lTLfhvdezRNaoUpLjhKfciGPxHihb._entries;
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
				private ADictionary<TKey, TValue> RFlivQdkCqoJCIzgBWReRQyoduYUB;

				private int ChsMOWsRiMyRpooioGtqaLERQcgd;

				private int vXlarwSrwFhnNMKEOxdFLCDuXSEk;

				private TValue nZbbpjfSztLWvavAORWrFDKrocSW;

				TValue IEnumerator<TValue>.Current => nZbbpjfSztLWvavAORWrFDKrocSW;

				object IEnumerator.Current
				{
					get
					{
						if (ChsMOWsRiMyRpooioGtqaLERQcgd == 0 || ChsMOWsRiMyRpooioGtqaLERQcgd == RFlivQdkCqoJCIzgBWReRQyoduYUB._count + 1)
						{
							throw new Exception();
						}
						return nZbbpjfSztLWvavAORWrFDKrocSW;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					RFlivQdkCqoJCIzgBWReRQyoduYUB = P_0;
					vXlarwSrwFhnNMKEOxdFLCDuXSEk = P_0.mFVYpeZiuzVGwdWuFFUsNlizVDbo;
					ChsMOWsRiMyRpooioGtqaLERQcgd = 0;
					nZbbpjfSztLWvavAORWrFDKrocSW = default(TValue);
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
					if (vXlarwSrwFhnNMKEOxdFLCDuXSEk != RFlivQdkCqoJCIzgBWReRQyoduYUB.mFVYpeZiuzVGwdWuFFUsNlizVDbo)
					{
						throw new Exception();
					}
					while ((uint)ChsMOWsRiMyRpooioGtqaLERQcgd < (uint)RFlivQdkCqoJCIzgBWReRQyoduYUB._count)
					{
						if (RFlivQdkCqoJCIzgBWReRQyoduYUB._entries[ChsMOWsRiMyRpooioGtqaLERQcgd].hashCode >= 0)
						{
							nZbbpjfSztLWvavAORWrFDKrocSW = RFlivQdkCqoJCIzgBWReRQyoduYUB._entries[ChsMOWsRiMyRpooioGtqaLERQcgd].value;
							ChsMOWsRiMyRpooioGtqaLERQcgd++;
							return true;
						}
						ChsMOWsRiMyRpooioGtqaLERQcgd++;
					}
					ChsMOWsRiMyRpooioGtqaLERQcgd = RFlivQdkCqoJCIzgBWReRQyoduYUB._count + 1;
					nZbbpjfSztLWvavAORWrFDKrocSW = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (vXlarwSrwFhnNMKEOxdFLCDuXSEk != RFlivQdkCqoJCIzgBWReRQyoduYUB.mFVYpeZiuzVGwdWuFFUsNlizVDbo)
					{
						throw new Exception();
					}
					ChsMOWsRiMyRpooioGtqaLERQcgd = 0;
					nZbbpjfSztLWvavAORWrFDKrocSW = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> wqzvrdzeKrFmBKeULzuPyKNgmXyf;

			int ICollection<TValue>.Count => wqzvrdzeKrFmBKeULzuPyKNgmXyf.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)wqzvrdzeKrFmBKeULzuPyKNgmXyf).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				wqzvrdzeKrFmBKeULzuPyKNgmXyf = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(wqzvrdzeKrFmBKeULzuPyKNgmXyf);
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
				if (array.Length - index < wqzvrdzeKrFmBKeULzuPyKNgmXyf.Count)
				{
					throw new Exception();
				}
				int count = wqzvrdzeKrFmBKeULzuPyKNgmXyf._count;
				Entry[] entries = wqzvrdzeKrFmBKeULzuPyKNgmXyf._entries;
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

			private void HJCcepKZZiDoRPGQzUooEWcErvbs(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in HJCcepKZZiDoRPGQzUooEWcErvbs
				this.HJCcepKZZiDoRPGQzUooEWcErvbs(P_0);
			}

			private bool GLoTdDBEFFvRanspQUnwYdXNcbum(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GLoTdDBEFFvRanspQUnwYdXNcbum
				return this.GLoTdDBEFFvRanspQUnwYdXNcbum(P_0);
			}

			private void saMiILUooMoAWAhiyfcnadDpXEHS()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in saMiILUooMoAWAhiyfcnadDpXEHS
				this.saMiILUooMoAWAhiyfcnadDpXEHS();
			}

			private bool UhgQukswmpwXusFcmfndSVMOyDOG(TValue P_0)
			{
				return wqzvrdzeKrFmBKeULzuPyKNgmXyf.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in UhgQukswmpwXusFcmfndSVMOyDOG
				return this.UhgQukswmpwXusFcmfndSVMOyDOG(P_0);
			}

			private IEnumerator<TValue> ADAAQXTBRJieSLuzNOcRbSYacgzu()
			{
				return new Enumerator(wqzvrdzeKrFmBKeULzuPyKNgmXyf);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ADAAQXTBRJieSLuzNOcRbSYacgzu
				return this.ADAAQXTBRJieSLuzNOcRbSYacgzu();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(wqzvrdzeKrFmBKeULzuPyKNgmXyf);
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
				if (array.Length - index < wqzvrdzeKrFmBKeULzuPyKNgmXyf.Count)
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
				int count = wqzvrdzeKrFmBKeULzuPyKNgmXyf._count;
				Entry[] entries = wqzvrdzeKrFmBKeULzuPyKNgmXyf._entries;
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

		private int[] iTRCLZvccFITlnTKKGvNslBVePWo;

		internal Entry[] _entries;

		internal int _count;

		private int mFVYpeZiuzVGwdWuFFUsNlizVDbo;

		private int ncMtAildjxjicUilCLsnWgBUisGBA;

		private int lxnOIpSQWrkfnhGeYDjGBsBMHXus;

		private int vliPispOMGjiWbQhKZVIFxCsGZce;

		private IEqualityComparer<TKey> gwEqZaJSzqXYQUSzKHmbwSkYaeWi;

		private IEqualityComparer<TValue> YQJStYyyLcwxzCpXgfFqunlMXrjr;

		private KeyCollection EsMINUsZHTPywXBBMtZrHFaTgPgA;

		private ValueCollection XArjaOBBRyUTueFwbZhJmxFLGTJe;

		private readonly object AlPROYOUrzJwnSVUKDJKNsGwYWre = new object();

		private static readonly bool EmVCrUenCBjrsDNMoRYyonKfMGRs = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool kHQivuVzHFgqZMdzppJmkHYBgeSq = ReflectionTools.IsValueType(typeof(TValue));

		private const string PZrStniDzBcrVLAgRMFTZegJomok = "Version";

		private const string VhCIqVDQKFhQYtLBCeKvTOcSDiXP = "HashSize";

		private const string KAbxopNjkjsFWnDAWeRosBDXhbHI = "KeyValuePairs";

		private const string iCauYbqxtPbGvAIfwIpdNeHUoNku = "Comparer";

		int ICollection<KeyValuePair<TKey, TValue>>.Count => _count - vliPispOMGjiWbQhKZVIFxCsGZce;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (EsMINUsZHTPywXBBMtZrHFaTgPgA == null)
				{
					EsMINUsZHTPywXBBMtZrHFaTgPgA = new KeyCollection(this);
				}
				return EsMINUsZHTPywXBBMtZrHFaTgPgA;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (XArjaOBBRyUTueFwbZhJmxFLGTJe == null)
				{
					XArjaOBBRyUTueFwbZhJmxFLGTJe = new ValueCollection(this);
				}
				return XArjaOBBRyUTueFwbZhJmxFLGTJe;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return gwEqZaJSzqXYQUSzKHmbwSkYaeWi;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				gwEqZaJSzqXYQUSzKHmbwSkYaeWi = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return YQJStYyyLcwxzCpXgfFqunlMXrjr;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				YQJStYyyLcwxzCpXgfFqunlMXrjr = value;
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
				OSfVECeJSdlvIRujStdXvTsIUTyo(key, value, false);
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
				if (EsMINUsZHTPywXBBMtZrHFaTgPgA == null)
				{
					EsMINUsZHTPywXBBMtZrHFaTgPgA = new KeyCollection(this);
				}
				return EsMINUsZHTPywXBBMtZrHFaTgPgA;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (XArjaOBBRyUTueFwbZhJmxFLGTJe == null)
				{
					XArjaOBBRyUTueFwbZhJmxFLGTJe = new ValueCollection(this);
				}
				return XArjaOBBRyUTueFwbZhJmxFLGTJe;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => AlPROYOUrzJwnSVUKDJKNsGwYWre;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (apHhMAYlfbniDEjeNZnmnfknpvPL(key))
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
				gpoJBVPYfEFwscLFRDFZijBstkfq<TValue>(value, "value");
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
				FmtSxqyiHeUhPIivthdJqLXWohyn(P_0);
			}
			gwEqZaJSzqXYQUSzKHmbwSkYaeWi = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			YQJStYyyLcwxzCpXgfFqunlMXrjr = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
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
			OSfVECeJSdlvIRujStdXvTsIUTyo(key, value, true);
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
				for (int i = 0; i < iTRCLZvccFITlnTKKGvNslBVePWo.Length; i++)
				{
					iTRCLZvccFITlnTKKGvNslBVePWo[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				lxnOIpSQWrkfnhGeYDjGBsBMHXus = -1;
				_count = 0;
				vliPispOMGjiWbQhKZVIFxCsGZce = 0;
				mFVYpeZiuzVGwdWuFFUsNlizVDbo++;
				ncMtAildjxjicUilCLsnWgBUisGBA++;
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
			if (!EmVCrUenCBjrsDNMoRYyonKfMGRs && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (iTRCLZvccFITlnTKKGvNslBVePWo != null)
			{
				int num = gwEqZaJSzqXYQUSzKHmbwSkYaeWi.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % iTRCLZvccFITlnTKKGvNslBVePWo.Length;
				int num3 = -1;
				for (int num4 = iTRCLZvccFITlnTKKGvNslBVePWo[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && gwEqZaJSzqXYQUSzKHmbwSkYaeWi.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							iTRCLZvccFITlnTKKGvNslBVePWo[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = lxnOIpSQWrkfnhGeYDjGBsBMHXus;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						lxnOIpSQWrkfnhGeYDjGBsBMHXus = num4;
						vliPispOMGjiWbQhKZVIFxCsGZce++;
						mFVYpeZiuzVGwdWuFFUsNlizVDbo++;
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
			if (!EmVCrUenCBjrsDNMoRYyonKfMGRs && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (iTRCLZvccFITlnTKKGvNslBVePWo != null)
			{
				int num = gwEqZaJSzqXYQUSzKHmbwSkYaeWi.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = iTRCLZvccFITlnTKKGvNslBVePWo[num % iTRCLZvccFITlnTKKGvNslBVePWo.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && gwEqZaJSzqXYQUSzKHmbwSkYaeWi.Equals(_entries[num2].key, key))
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
			if (!kHQivuVzHFgqZMdzppJmkHYBgeSq && value == null)
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
				IEqualityComparer<TValue> yQJStYyyLcwxzCpXgfFqunlMXrjr = YQJStYyyLcwxzCpXgfFqunlMXrjr;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && yQJStYyyLcwxzCpXgfFqunlMXrjr.Equals(entries[j].value, value))
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

		private void FmtSxqyiHeUhPIivthdJqLXWohyn(int P_0)
		{
			int num = CriENBTswwdxfepiJbeaBTfqaskK.LcJmTwlXAAQVQzxhdMiaIiDfuBGW(P_0);
			iTRCLZvccFITlnTKKGvNslBVePWo = new int[num];
			for (int i = 0; i < iTRCLZvccFITlnTKKGvNslBVePWo.Length; i++)
			{
				iTRCLZvccFITlnTKKGvNslBVePWo[i] = -1;
			}
			_entries = new Entry[num];
			lxnOIpSQWrkfnhGeYDjGBsBMHXus = -1;
		}

		private void OSfVECeJSdlvIRujStdXvTsIUTyo(TKey P_0, TValue P_1, bool P_2)
		{
			if (!EmVCrUenCBjrsDNMoRYyonKfMGRs && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (iTRCLZvccFITlnTKKGvNslBVePWo == null)
			{
				FmtSxqyiHeUhPIivthdJqLXWohyn(0);
			}
			int num = gwEqZaJSzqXYQUSzKHmbwSkYaeWi.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % iTRCLZvccFITlnTKKGvNslBVePWo.Length;
			for (int num3 = iTRCLZvccFITlnTKKGvNslBVePWo[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && gwEqZaJSzqXYQUSzKHmbwSkYaeWi.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					mFVYpeZiuzVGwdWuFFUsNlizVDbo++;
					return;
				}
			}
			int count;
			if (vliPispOMGjiWbQhKZVIFxCsGZce > 0)
			{
				count = lxnOIpSQWrkfnhGeYDjGBsBMHXus;
				lxnOIpSQWrkfnhGeYDjGBsBMHXus = _entries[count].next;
				vliPispOMGjiWbQhKZVIFxCsGZce--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					OrfAApyHJIiPFAEZkZxlJwrERlob();
					num2 = num % iTRCLZvccFITlnTKKGvNslBVePWo.Length;
				}
				count = _count;
				_count++;
			}
			_entries[count].hashCode = num;
			_entries[count].next = iTRCLZvccFITlnTKKGvNslBVePWo[num2];
			_entries[count].key = P_0;
			_entries[count].value = P_1;
			iTRCLZvccFITlnTKKGvNslBVePWo[num2] = count;
			mFVYpeZiuzVGwdWuFFUsNlizVDbo++;
			ncMtAildjxjicUilCLsnWgBUisGBA++;
		}

		private void OrfAApyHJIiPFAEZkZxlJwrERlob()
		{
			ABKvGkSUuNtWEPqQBfgWSFxkTOWT(CriENBTswwdxfepiJbeaBTfqaskK.vqsZrKVpwFRdDhwtQdMRjkYJmxEm(_count), false);
		}

		private void ABKvGkSUuNtWEPqQBfgWSFxkTOWT(int P_0, bool P_1)
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
						array2[j].hashCode = gwEqZaJSzqXYQUSzKHmbwSkYaeWi.GetHashCode(array2[j].key) & 0x7FFFFFFF;
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
			iTRCLZvccFITlnTKKGvNslBVePWo = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> MaStYCYxiSfhoLCfXqFjUftBFShGA()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MaStYCYxiSfhoLCfXqFjUftBFShGA
			return this.MaStYCYxiSfhoLCfXqFjUftBFShGA();
		}

		private void SUmcAcHpBodFrreUOJOybVJYTzxyA(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SUmcAcHpBodFrreUOJOybVJYTzxyA
			this.SUmcAcHpBodFrreUOJOybVJYTzxyA(P_0);
		}

		private bool QCHLcXijuoHeNPAnsyOTFfFcnMHy(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && YQJStYyyLcwxzCpXgfFqunlMXrjr.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QCHLcXijuoHeNPAnsyOTFfFcnMHy
			return this.QCHLcXijuoHeNPAnsyOTFfFcnMHy(P_0);
		}

		private bool QTSGlAFmmDaUWwqOpXZEJPiZMPrs(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && YQJStYyyLcwxzCpXgfFqunlMXrjr.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QTSGlAFmmDaUWwqOpXZEJPiZMPrs
			return this.QTSGlAFmmDaUWwqOpXZEJPiZMPrs(P_0);
		}

		private void nIitglzSabpukeOxzgSDMTglHpkb(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nIitglzSabpukeOxzgSDMTglHpkb
			this.nIitglzSabpukeOxzgSDMTglHpkb(P_0, P_1);
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
			gpoJBVPYfEFwscLFRDFZijBstkfq<TValue>(value, "value");
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
			if (apHhMAYlfbniDEjeNZnmnfknpvPL(key))
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
			if (apHhMAYlfbniDEjeNZnmnfknpvPL(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool apHhMAYlfbniDEjeNZnmnfknpvPL(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void gpoJBVPYfEFwscLFRDFZijBstkfq<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
