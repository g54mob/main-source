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
			private ADictionary<TKey, TValue> UjurVYUAYoJoDevEuezAEpplgUTC;

			private int HbLuqJnSEteSMvNyzvOYFsMJswoS;

			private int NxmbuSRJVaokBMmBQCgLcdaIOxWe;

			private KeyValuePair<TKey, TValue> MThMhAcCNZYTiJjwphHGWiOSbxOh;

			private int JENRHlTMAhGalvUdmAhMmnOsAVdcA;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => MThMhAcCNZYTiJjwphHGWiOSbxOh;

			object IEnumerator.Current
			{
				get
				{
					if (NxmbuSRJVaokBMmBQCgLcdaIOxWe == 0 || NxmbuSRJVaokBMmBQCgLcdaIOxWe == UjurVYUAYoJoDevEuezAEpplgUTC._count + 1)
					{
						throw new Exception();
					}
					if (JENRHlTMAhGalvUdmAhMmnOsAVdcA == 1)
					{
						return new DictionaryEntry(MThMhAcCNZYTiJjwphHGWiOSbxOh.Key, MThMhAcCNZYTiJjwphHGWiOSbxOh.Value);
					}
					return new KeyValuePair<TKey, TValue>(MThMhAcCNZYTiJjwphHGWiOSbxOh.Key, MThMhAcCNZYTiJjwphHGWiOSbxOh.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (NxmbuSRJVaokBMmBQCgLcdaIOxWe == 0 || NxmbuSRJVaokBMmBQCgLcdaIOxWe == UjurVYUAYoJoDevEuezAEpplgUTC._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(MThMhAcCNZYTiJjwphHGWiOSbxOh.Key, MThMhAcCNZYTiJjwphHGWiOSbxOh.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (NxmbuSRJVaokBMmBQCgLcdaIOxWe == 0 || NxmbuSRJVaokBMmBQCgLcdaIOxWe == UjurVYUAYoJoDevEuezAEpplgUTC._count + 1)
					{
						throw new Exception();
					}
					return MThMhAcCNZYTiJjwphHGWiOSbxOh.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (NxmbuSRJVaokBMmBQCgLcdaIOxWe == 0 || NxmbuSRJVaokBMmBQCgLcdaIOxWe == UjurVYUAYoJoDevEuezAEpplgUTC._count + 1)
					{
						throw new Exception();
					}
					return MThMhAcCNZYTiJjwphHGWiOSbxOh.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				UjurVYUAYoJoDevEuezAEpplgUTC = P_0;
				HbLuqJnSEteSMvNyzvOYFsMJswoS = P_0.xbwFxaacLlakvsxGxCoXejbjGcGSA;
				NxmbuSRJVaokBMmBQCgLcdaIOxWe = 0;
				JENRHlTMAhGalvUdmAhMmnOsAVdcA = P_1;
				MThMhAcCNZYTiJjwphHGWiOSbxOh = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (HbLuqJnSEteSMvNyzvOYFsMJswoS != UjurVYUAYoJoDevEuezAEpplgUTC.xbwFxaacLlakvsxGxCoXejbjGcGSA)
				{
					throw new Exception();
				}
				while ((uint)NxmbuSRJVaokBMmBQCgLcdaIOxWe < (uint)UjurVYUAYoJoDevEuezAEpplgUTC._count)
				{
					if (UjurVYUAYoJoDevEuezAEpplgUTC._entries[NxmbuSRJVaokBMmBQCgLcdaIOxWe].hashCode >= 0)
					{
						MThMhAcCNZYTiJjwphHGWiOSbxOh = new KeyValuePair<TKey, TValue>(UjurVYUAYoJoDevEuezAEpplgUTC._entries[NxmbuSRJVaokBMmBQCgLcdaIOxWe].key, UjurVYUAYoJoDevEuezAEpplgUTC._entries[NxmbuSRJVaokBMmBQCgLcdaIOxWe].value);
						NxmbuSRJVaokBMmBQCgLcdaIOxWe++;
						return true;
					}
					NxmbuSRJVaokBMmBQCgLcdaIOxWe++;
				}
				NxmbuSRJVaokBMmBQCgLcdaIOxWe = UjurVYUAYoJoDevEuezAEpplgUTC._count + 1;
				MThMhAcCNZYTiJjwphHGWiOSbxOh = default(KeyValuePair<TKey, TValue>);
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
				if (HbLuqJnSEteSMvNyzvOYFsMJswoS != UjurVYUAYoJoDevEuezAEpplgUTC.xbwFxaacLlakvsxGxCoXejbjGcGSA)
				{
					throw new Exception();
				}
				NxmbuSRJVaokBMmBQCgLcdaIOxWe = 0;
				MThMhAcCNZYTiJjwphHGWiOSbxOh = default(KeyValuePair<TKey, TValue>);
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
				private ADictionary<TKey, TValue> ZcYXIsXSgAAefmFwPjbjKMYkFGaM;

				private int RSIIbLClYsagueBccAojrHIjvRrsA;

				private int qhpxwpzamIjVaHQaEUtsFlVWzHDB;

				private TKey BhxCjHemNDOqNFxgnTWiuVMoIsqkA;

				TKey IEnumerator<TKey>.Current => BhxCjHemNDOqNFxgnTWiuVMoIsqkA;

				object IEnumerator.Current
				{
					get
					{
						if (RSIIbLClYsagueBccAojrHIjvRrsA == 0 || RSIIbLClYsagueBccAojrHIjvRrsA == ZcYXIsXSgAAefmFwPjbjKMYkFGaM._count + 1)
						{
							throw new Exception();
						}
						return BhxCjHemNDOqNFxgnTWiuVMoIsqkA;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					ZcYXIsXSgAAefmFwPjbjKMYkFGaM = P_0;
					qhpxwpzamIjVaHQaEUtsFlVWzHDB = P_0.xbwFxaacLlakvsxGxCoXejbjGcGSA;
					RSIIbLClYsagueBccAojrHIjvRrsA = 0;
					BhxCjHemNDOqNFxgnTWiuVMoIsqkA = default(TKey);
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
					if (qhpxwpzamIjVaHQaEUtsFlVWzHDB != ZcYXIsXSgAAefmFwPjbjKMYkFGaM.xbwFxaacLlakvsxGxCoXejbjGcGSA)
					{
						throw new Exception();
					}
					while ((uint)RSIIbLClYsagueBccAojrHIjvRrsA < (uint)ZcYXIsXSgAAefmFwPjbjKMYkFGaM._count)
					{
						if (ZcYXIsXSgAAefmFwPjbjKMYkFGaM._entries[RSIIbLClYsagueBccAojrHIjvRrsA].hashCode >= 0)
						{
							BhxCjHemNDOqNFxgnTWiuVMoIsqkA = ZcYXIsXSgAAefmFwPjbjKMYkFGaM._entries[RSIIbLClYsagueBccAojrHIjvRrsA].key;
							RSIIbLClYsagueBccAojrHIjvRrsA++;
							return true;
						}
						RSIIbLClYsagueBccAojrHIjvRrsA++;
					}
					RSIIbLClYsagueBccAojrHIjvRrsA = ZcYXIsXSgAAefmFwPjbjKMYkFGaM._count + 1;
					BhxCjHemNDOqNFxgnTWiuVMoIsqkA = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (qhpxwpzamIjVaHQaEUtsFlVWzHDB != ZcYXIsXSgAAefmFwPjbjKMYkFGaM.xbwFxaacLlakvsxGxCoXejbjGcGSA)
					{
						throw new Exception();
					}
					RSIIbLClYsagueBccAojrHIjvRrsA = 0;
					BhxCjHemNDOqNFxgnTWiuVMoIsqkA = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> upmnLrXpKLEFliEpPaeOUdXDpiNq;

			int ICollection<TKey>.Count => upmnLrXpKLEFliEpPaeOUdXDpiNq.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)upmnLrXpKLEFliEpPaeOUdXDpiNq).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				upmnLrXpKLEFliEpPaeOUdXDpiNq = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(upmnLrXpKLEFliEpPaeOUdXDpiNq);
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
				if (array.Length - index < upmnLrXpKLEFliEpPaeOUdXDpiNq.Count)
				{
					throw new Exception();
				}
				int count = upmnLrXpKLEFliEpPaeOUdXDpiNq._count;
				Entry[] entries = upmnLrXpKLEFliEpPaeOUdXDpiNq._entries;
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

			private void cJtnWBKviKGTBSbHQCPHfwmLaiVXA(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in cJtnWBKviKGTBSbHQCPHfwmLaiVXA
				this.cJtnWBKviKGTBSbHQCPHfwmLaiVXA(P_0);
			}

			private void zJwiwbAzSumgAbBMszjfKWtRIzNB()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in zJwiwbAzSumgAbBMszjfKWtRIzNB
				this.zJwiwbAzSumgAbBMszjfKWtRIzNB();
			}

			private bool nwCFXYEuUYVuNKeINQCQcnBluIDTA(TKey P_0)
			{
				return upmnLrXpKLEFliEpPaeOUdXDpiNq.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in nwCFXYEuUYVuNKeINQCQcnBluIDTA
				return this.nwCFXYEuUYVuNKeINQCQcnBluIDTA(P_0);
			}

			private bool wGPBtMdhhgGINBkhiQrUNdKvppLOb(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in wGPBtMdhhgGINBkhiQrUNdKvppLOb
				return this.wGPBtMdhhgGINBkhiQrUNdKvppLOb(P_0);
			}

			private IEnumerator<TKey> REiytHftuPMtuZMCFyHsOIDnUiIi()
			{
				return new Enumerator(upmnLrXpKLEFliEpPaeOUdXDpiNq);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in REiytHftuPMtuZMCFyHsOIDnUiIi
				return this.REiytHftuPMtuZMCFyHsOIDnUiIi();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(upmnLrXpKLEFliEpPaeOUdXDpiNq);
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
				if (array.Length - index < upmnLrXpKLEFliEpPaeOUdXDpiNq.Count)
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
				int count = upmnLrXpKLEFliEpPaeOUdXDpiNq._count;
				Entry[] entries = upmnLrXpKLEFliEpPaeOUdXDpiNq._entries;
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
				private ADictionary<TKey, TValue> ABArvCDQxenmNsOQevlTyjfdRRzI;

				private int NWBlEGVueQGQGlmIKiyYHCQJSnZMA;

				private int uPEgaygdRDYTERteaFNgHxUghmvcA;

				private TValue aCSbjdhYIblqirxkiXeOsvFjnHhFA;

				TValue IEnumerator<TValue>.Current => aCSbjdhYIblqirxkiXeOsvFjnHhFA;

				object IEnumerator.Current
				{
					get
					{
						if (NWBlEGVueQGQGlmIKiyYHCQJSnZMA == 0 || NWBlEGVueQGQGlmIKiyYHCQJSnZMA == ABArvCDQxenmNsOQevlTyjfdRRzI._count + 1)
						{
							throw new Exception();
						}
						return aCSbjdhYIblqirxkiXeOsvFjnHhFA;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					ABArvCDQxenmNsOQevlTyjfdRRzI = P_0;
					uPEgaygdRDYTERteaFNgHxUghmvcA = P_0.xbwFxaacLlakvsxGxCoXejbjGcGSA;
					NWBlEGVueQGQGlmIKiyYHCQJSnZMA = 0;
					aCSbjdhYIblqirxkiXeOsvFjnHhFA = default(TValue);
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
					if (uPEgaygdRDYTERteaFNgHxUghmvcA != ABArvCDQxenmNsOQevlTyjfdRRzI.xbwFxaacLlakvsxGxCoXejbjGcGSA)
					{
						throw new Exception();
					}
					while ((uint)NWBlEGVueQGQGlmIKiyYHCQJSnZMA < (uint)ABArvCDQxenmNsOQevlTyjfdRRzI._count)
					{
						if (ABArvCDQxenmNsOQevlTyjfdRRzI._entries[NWBlEGVueQGQGlmIKiyYHCQJSnZMA].hashCode >= 0)
						{
							aCSbjdhYIblqirxkiXeOsvFjnHhFA = ABArvCDQxenmNsOQevlTyjfdRRzI._entries[NWBlEGVueQGQGlmIKiyYHCQJSnZMA].value;
							NWBlEGVueQGQGlmIKiyYHCQJSnZMA++;
							return true;
						}
						NWBlEGVueQGQGlmIKiyYHCQJSnZMA++;
					}
					NWBlEGVueQGQGlmIKiyYHCQJSnZMA = ABArvCDQxenmNsOQevlTyjfdRRzI._count + 1;
					aCSbjdhYIblqirxkiXeOsvFjnHhFA = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (uPEgaygdRDYTERteaFNgHxUghmvcA != ABArvCDQxenmNsOQevlTyjfdRRzI.xbwFxaacLlakvsxGxCoXejbjGcGSA)
					{
						throw new Exception();
					}
					NWBlEGVueQGQGlmIKiyYHCQJSnZMA = 0;
					aCSbjdhYIblqirxkiXeOsvFjnHhFA = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> nUMHfbMvfvbnYZcwbuLqKhMiBVVq;

			int ICollection<TValue>.Count => nUMHfbMvfvbnYZcwbuLqKhMiBVVq.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)nUMHfbMvfvbnYZcwbuLqKhMiBVVq).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				nUMHfbMvfvbnYZcwbuLqKhMiBVVq = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(nUMHfbMvfvbnYZcwbuLqKhMiBVVq);
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
				if (array.Length - index < nUMHfbMvfvbnYZcwbuLqKhMiBVVq.Count)
				{
					throw new Exception();
				}
				int count = nUMHfbMvfvbnYZcwbuLqKhMiBVVq._count;
				Entry[] entries = nUMHfbMvfvbnYZcwbuLqKhMiBVVq._entries;
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

			private void AznvihzsqwvYGGdaZiALgatKKQEzA(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in AznvihzsqwvYGGdaZiALgatKKQEzA
				this.AznvihzsqwvYGGdaZiALgatKKQEzA(P_0);
			}

			private bool ZnVfFZgfoNmHxaZJiveDgAUHAYBfA(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ZnVfFZgfoNmHxaZJiveDgAUHAYBfA
				return this.ZnVfFZgfoNmHxaZJiveDgAUHAYBfA(P_0);
			}

			private void xhhAaBAvTEeOTEDGaKEIFYCNprwQb()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in xhhAaBAvTEeOTEDGaKEIFYCNprwQb
				this.xhhAaBAvTEeOTEDGaKEIFYCNprwQb();
			}

			private bool TXLFMqVjBlyGtnptEfTYwPAADJvz(TValue P_0)
			{
				return nUMHfbMvfvbnYZcwbuLqKhMiBVVq.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in TXLFMqVjBlyGtnptEfTYwPAADJvz
				return this.TXLFMqVjBlyGtnptEfTYwPAADJvz(P_0);
			}

			private IEnumerator<TValue> DflwUTycqPDMZkGTfmEabHLeyZQkA()
			{
				return new Enumerator(nUMHfbMvfvbnYZcwbuLqKhMiBVVq);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DflwUTycqPDMZkGTfmEabHLeyZQkA
				return this.DflwUTycqPDMZkGTfmEabHLeyZQkA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(nUMHfbMvfvbnYZcwbuLqKhMiBVVq);
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
				if (array.Length - index < nUMHfbMvfvbnYZcwbuLqKhMiBVVq.Count)
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
				int count = nUMHfbMvfvbnYZcwbuLqKhMiBVVq._count;
				Entry[] entries = nUMHfbMvfvbnYZcwbuLqKhMiBVVq._entries;
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

		private int[] fMkvWNMwHBQdoikyqRZsQICJemzR;

		internal Entry[] _entries;

		internal int _count;

		private int xbwFxaacLlakvsxGxCoXejbjGcGSA;

		private int qfxjbmgWWrZMfnNNiIAUhyKiSHjrB;

		private int mIASIdjvMpGbaiAKcHgvvImCuSLE;

		private int gYDPZyObzIxNPiZgwtxnnCaoqtPp;

		private IEqualityComparer<TKey> rLbGeisuKmCnHDVXezjErIzOyPvKA;

		private IEqualityComparer<TValue> HpkxXCNxgiTCuHBjSDtZKYkSlUIx;

		private KeyCollection RlLpMPFLaDPbpYXhboLytKGyUJiN;

		private ValueCollection OCATzYwFomrulnNvFvlcKKiBMvgM;

		private readonly object JzyHLWjqdpbvmFEjcEzhnDbelfCP = new object();

		private static readonly bool ZbyzlYXSjHEBjGlmUCkDfMJpldgKA = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool vtfSioqmiTFSCENZBiLXMIPZdFpvA = ReflectionTools.IsValueType(typeof(TValue));

		private const string QfCfMjNXiHeQUSLelGacdQfDwXDt = "Version";

		private const string AslmmXonXVwyNonGeqsQdnjWLnkE = "HashSize";

		private const string FeCqnlqaYpnCDuleeySTIzYTaKur = "KeyValuePairs";

		private const string dcHOjpPMIPeouHTzGDtSjQlYiNDe = "Comparer";

		int ICollection.Count => _count - gYDPZyObzIxNPiZgwtxnnCaoqtPp;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (RlLpMPFLaDPbpYXhboLytKGyUJiN == null)
				{
					RlLpMPFLaDPbpYXhboLytKGyUJiN = new KeyCollection(this);
				}
				return RlLpMPFLaDPbpYXhboLytKGyUJiN;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (OCATzYwFomrulnNvFvlcKKiBMvgM == null)
				{
					OCATzYwFomrulnNvFvlcKKiBMvgM = new ValueCollection(this);
				}
				return OCATzYwFomrulnNvFvlcKKiBMvgM;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return rLbGeisuKmCnHDVXezjErIzOyPvKA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				rLbGeisuKmCnHDVXezjErIzOyPvKA = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return HpkxXCNxgiTCuHBjSDtZKYkSlUIx;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				HpkxXCNxgiTCuHBjSDtZKYkSlUIx = value;
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
				LPEbIYPbxdoXPAUZesPiXwrEUqRs(key, value, false);
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
				if (RlLpMPFLaDPbpYXhboLytKGyUJiN == null)
				{
					RlLpMPFLaDPbpYXhboLytKGyUJiN = new KeyCollection(this);
				}
				return RlLpMPFLaDPbpYXhboLytKGyUJiN;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (OCATzYwFomrulnNvFvlcKKiBMvgM == null)
				{
					OCATzYwFomrulnNvFvlcKKiBMvgM = new ValueCollection(this);
				}
				return OCATzYwFomrulnNvFvlcKKiBMvgM;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => JzyHLWjqdpbvmFEjcEzhnDbelfCP;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (fomGrUvjUfkPEPlOrgbZDCffyEgP(key))
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
				dqZJEHsJQQYprrIxnrBsQoGqJzGH<TValue>(value, "value");
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
				IpIdYcEBaqCeQXNNHPVeoEMMLGDUA(P_0);
			}
			rLbGeisuKmCnHDVXezjErIzOyPvKA = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			HpkxXCNxgiTCuHBjSDtZKYkSlUIx = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
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
			LPEbIYPbxdoXPAUZesPiXwrEUqRs(key, value, true);
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
				for (int i = 0; i < fMkvWNMwHBQdoikyqRZsQICJemzR.Length; i++)
				{
					fMkvWNMwHBQdoikyqRZsQICJemzR[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				mIASIdjvMpGbaiAKcHgvvImCuSLE = -1;
				_count = 0;
				gYDPZyObzIxNPiZgwtxnnCaoqtPp = 0;
				xbwFxaacLlakvsxGxCoXejbjGcGSA++;
				qfxjbmgWWrZMfnNNiIAUhyKiSHjrB++;
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
			if (!ZbyzlYXSjHEBjGlmUCkDfMJpldgKA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (fMkvWNMwHBQdoikyqRZsQICJemzR != null)
			{
				int num = rLbGeisuKmCnHDVXezjErIzOyPvKA.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % fMkvWNMwHBQdoikyqRZsQICJemzR.Length;
				int num3 = -1;
				for (int num4 = fMkvWNMwHBQdoikyqRZsQICJemzR[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && rLbGeisuKmCnHDVXezjErIzOyPvKA.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							fMkvWNMwHBQdoikyqRZsQICJemzR[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = mIASIdjvMpGbaiAKcHgvvImCuSLE;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						mIASIdjvMpGbaiAKcHgvvImCuSLE = num4;
						gYDPZyObzIxNPiZgwtxnnCaoqtPp++;
						xbwFxaacLlakvsxGxCoXejbjGcGSA++;
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
			if (!ZbyzlYXSjHEBjGlmUCkDfMJpldgKA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (fMkvWNMwHBQdoikyqRZsQICJemzR != null)
			{
				int num = rLbGeisuKmCnHDVXezjErIzOyPvKA.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = fMkvWNMwHBQdoikyqRZsQICJemzR[num % fMkvWNMwHBQdoikyqRZsQICJemzR.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && rLbGeisuKmCnHDVXezjErIzOyPvKA.Equals(_entries[num2].key, key))
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
			if (!vtfSioqmiTFSCENZBiLXMIPZdFpvA && value == null)
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
				IEqualityComparer<TValue> hpkxXCNxgiTCuHBjSDtZKYkSlUIx = HpkxXCNxgiTCuHBjSDtZKYkSlUIx;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && hpkxXCNxgiTCuHBjSDtZKYkSlUIx.Equals(entries[j].value, value))
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

		private void IpIdYcEBaqCeQXNNHPVeoEMMLGDUA(int P_0)
		{
			int num = NMJDXPqDkmBhgbAenCqXnksaXlVe.UBsRteWAtWziJyHBNAKXkMsvmdzg(P_0);
			fMkvWNMwHBQdoikyqRZsQICJemzR = new int[num];
			for (int i = 0; i < fMkvWNMwHBQdoikyqRZsQICJemzR.Length; i++)
			{
				fMkvWNMwHBQdoikyqRZsQICJemzR[i] = -1;
			}
			_entries = new Entry[num];
			mIASIdjvMpGbaiAKcHgvvImCuSLE = -1;
		}

		private void LPEbIYPbxdoXPAUZesPiXwrEUqRs(TKey P_0, TValue P_1, bool P_2)
		{
			if (!ZbyzlYXSjHEBjGlmUCkDfMJpldgKA && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (fMkvWNMwHBQdoikyqRZsQICJemzR == null)
			{
				IpIdYcEBaqCeQXNNHPVeoEMMLGDUA(0);
			}
			int num = rLbGeisuKmCnHDVXezjErIzOyPvKA.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % fMkvWNMwHBQdoikyqRZsQICJemzR.Length;
			for (int num3 = fMkvWNMwHBQdoikyqRZsQICJemzR[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && rLbGeisuKmCnHDVXezjErIzOyPvKA.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					xbwFxaacLlakvsxGxCoXejbjGcGSA++;
					return;
				}
			}
			int count;
			if (gYDPZyObzIxNPiZgwtxnnCaoqtPp > 0)
			{
				count = mIASIdjvMpGbaiAKcHgvvImCuSLE;
				mIASIdjvMpGbaiAKcHgvvImCuSLE = _entries[count].next;
				gYDPZyObzIxNPiZgwtxnnCaoqtPp--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					HtIqMCDYmEMQGBAgQUxWzLxCqwQU();
					num2 = num % fMkvWNMwHBQdoikyqRZsQICJemzR.Length;
				}
				count = _count;
				_count++;
			}
			_entries[count].hashCode = num;
			_entries[count].next = fMkvWNMwHBQdoikyqRZsQICJemzR[num2];
			_entries[count].key = P_0;
			_entries[count].value = P_1;
			fMkvWNMwHBQdoikyqRZsQICJemzR[num2] = count;
			xbwFxaacLlakvsxGxCoXejbjGcGSA++;
			qfxjbmgWWrZMfnNNiIAUhyKiSHjrB++;
		}

		private void HtIqMCDYmEMQGBAgQUxWzLxCqwQU()
		{
			DlrGKwzdPXDyXCWorDUtewwqhlhN(NMJDXPqDkmBhgbAenCqXnksaXlVe.oLVtJYmjVFFRYsGHeEaeNkBLcJzn(_count), false);
		}

		private void DlrGKwzdPXDyXCWorDUtewwqhlhN(int P_0, bool P_1)
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
						array2[j].hashCode = rLbGeisuKmCnHDVXezjErIzOyPvKA.GetHashCode(array2[j].key) & 0x7FFFFFFF;
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
			fMkvWNMwHBQdoikyqRZsQICJemzR = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> HZbEIZbNAQXlfWJynfMcakeFhcYe()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in HZbEIZbNAQXlfWJynfMcakeFhcYe
			return this.HZbEIZbNAQXlfWJynfMcakeFhcYe();
		}

		private void PNFUysOnkuhhkfawsfgHhNYELIWy(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PNFUysOnkuhhkfawsfgHhNYELIWy
			this.PNFUysOnkuhhkfawsfgHhNYELIWy(P_0);
		}

		private bool PbeckXLETcQuQSoZGgumvkGkhRqF(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && HpkxXCNxgiTCuHBjSDtZKYkSlUIx.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PbeckXLETcQuQSoZGgumvkGkhRqF
			return this.PbeckXLETcQuQSoZGgumvkGkhRqF(P_0);
		}

		private bool NQxxhAekJTgrRjlwHlsjbIlPsrEh(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && HpkxXCNxgiTCuHBjSDtZKYkSlUIx.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NQxxhAekJTgrRjlwHlsjbIlPsrEh
			return this.NQxxhAekJTgrRjlwHlsjbIlPsrEh(P_0);
		}

		private void qPDLbqAljzJVfltiVCxruDMhuRYL(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qPDLbqAljzJVfltiVCxruDMhuRYL
			this.qPDLbqAljzJVfltiVCxruDMhuRYL(P_0, P_1);
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
			dqZJEHsJQQYprrIxnrBsQoGqJzGH<TValue>(value, "value");
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
			if (fomGrUvjUfkPEPlOrgbZDCffyEgP(key))
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
			if (fomGrUvjUfkPEPlOrgbZDCffyEgP(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool fomGrUvjUfkPEPlOrgbZDCffyEgP(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void dqZJEHsJQQYprrIxnrBsQoGqJzGH<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
