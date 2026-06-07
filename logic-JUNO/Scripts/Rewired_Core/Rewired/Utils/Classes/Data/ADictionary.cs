using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Rewired.Utils.Classes.Data
{
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection
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
			private ADictionary<TKey, TValue> VINzAdXJXDmUYyjoAHkhqvOVwtxe;

			private int QxkFowaaNMDnFBxoTEvvspSxskOz;

			private int ShXzQTQQILJbvUqdmxLaOjZgGOsC;

			private KeyValuePair<TKey, TValue> FAjMnexCwfpjrNjZLIpbyGgmlsFB;

			private int CMkFPGMJHEpFklxvUSQxUoWGlHVx;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => FAjMnexCwfpjrNjZLIpbyGgmlsFB;

			object IEnumerator.Current
			{
				get
				{
					if (ShXzQTQQILJbvUqdmxLaOjZgGOsC == 0 || ShXzQTQQILJbvUqdmxLaOjZgGOsC == VINzAdXJXDmUYyjoAHkhqvOVwtxe._count + 1)
					{
						throw new Exception();
					}
					if (CMkFPGMJHEpFklxvUSQxUoWGlHVx == 1)
					{
						return new DictionaryEntry(FAjMnexCwfpjrNjZLIpbyGgmlsFB.Key, FAjMnexCwfpjrNjZLIpbyGgmlsFB.Value);
					}
					return new KeyValuePair<TKey, TValue>(FAjMnexCwfpjrNjZLIpbyGgmlsFB.Key, FAjMnexCwfpjrNjZLIpbyGgmlsFB.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (ShXzQTQQILJbvUqdmxLaOjZgGOsC == 0 || ShXzQTQQILJbvUqdmxLaOjZgGOsC == VINzAdXJXDmUYyjoAHkhqvOVwtxe._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(FAjMnexCwfpjrNjZLIpbyGgmlsFB.Key, FAjMnexCwfpjrNjZLIpbyGgmlsFB.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (ShXzQTQQILJbvUqdmxLaOjZgGOsC == 0 || ShXzQTQQILJbvUqdmxLaOjZgGOsC == VINzAdXJXDmUYyjoAHkhqvOVwtxe._count + 1)
					{
						throw new Exception();
					}
					return FAjMnexCwfpjrNjZLIpbyGgmlsFB.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (ShXzQTQQILJbvUqdmxLaOjZgGOsC == 0 || ShXzQTQQILJbvUqdmxLaOjZgGOsC == VINzAdXJXDmUYyjoAHkhqvOVwtxe._count + 1)
					{
						throw new Exception();
					}
					return FAjMnexCwfpjrNjZLIpbyGgmlsFB.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				VINzAdXJXDmUYyjoAHkhqvOVwtxe = P_0;
				QxkFowaaNMDnFBxoTEvvspSxskOz = P_0.eaTtqRfUIEDDcqXQZXCeRojPusoj;
				ShXzQTQQILJbvUqdmxLaOjZgGOsC = 0;
				CMkFPGMJHEpFklxvUSQxUoWGlHVx = P_1;
				FAjMnexCwfpjrNjZLIpbyGgmlsFB = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (QxkFowaaNMDnFBxoTEvvspSxskOz != VINzAdXJXDmUYyjoAHkhqvOVwtxe.eaTtqRfUIEDDcqXQZXCeRojPusoj)
				{
					throw new Exception();
				}
				while ((uint)ShXzQTQQILJbvUqdmxLaOjZgGOsC < (uint)VINzAdXJXDmUYyjoAHkhqvOVwtxe._count)
				{
					if (VINzAdXJXDmUYyjoAHkhqvOVwtxe._entries[ShXzQTQQILJbvUqdmxLaOjZgGOsC].hashCode >= 0)
					{
						FAjMnexCwfpjrNjZLIpbyGgmlsFB = new KeyValuePair<TKey, TValue>(VINzAdXJXDmUYyjoAHkhqvOVwtxe._entries[ShXzQTQQILJbvUqdmxLaOjZgGOsC].key, VINzAdXJXDmUYyjoAHkhqvOVwtxe._entries[ShXzQTQQILJbvUqdmxLaOjZgGOsC].value);
						ShXzQTQQILJbvUqdmxLaOjZgGOsC++;
						return true;
					}
					ShXzQTQQILJbvUqdmxLaOjZgGOsC++;
				}
				ShXzQTQQILJbvUqdmxLaOjZgGOsC = VINzAdXJXDmUYyjoAHkhqvOVwtxe._count + 1;
				FAjMnexCwfpjrNjZLIpbyGgmlsFB = default(KeyValuePair<TKey, TValue>);
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
				if (QxkFowaaNMDnFBxoTEvvspSxskOz != VINzAdXJXDmUYyjoAHkhqvOVwtxe.eaTtqRfUIEDDcqXQZXCeRojPusoj)
				{
					throw new Exception();
				}
				ShXzQTQQILJbvUqdmxLaOjZgGOsC = 0;
				FAjMnexCwfpjrNjZLIpbyGgmlsFB = default(KeyValuePair<TKey, TValue>);
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
				private ADictionary<TKey, TValue> EMlAOFfUnvTLujmqprUGouIChQIsA;

				private int MktNlaZwXPfZhHDkMcTYJnMZKHFPA;

				private int fPSdHFabxPSWYNTAwrjSvMbsruvG;

				private TKey WzSylajoGwFDUbaqRMrXWyYIFgER;

				TKey IEnumerator<TKey>.Current => WzSylajoGwFDUbaqRMrXWyYIFgER;

				object IEnumerator.Current
				{
					get
					{
						if (MktNlaZwXPfZhHDkMcTYJnMZKHFPA == 0 || MktNlaZwXPfZhHDkMcTYJnMZKHFPA == EMlAOFfUnvTLujmqprUGouIChQIsA._count + 1)
						{
							throw new Exception();
						}
						return WzSylajoGwFDUbaqRMrXWyYIFgER;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					EMlAOFfUnvTLujmqprUGouIChQIsA = P_0;
					fPSdHFabxPSWYNTAwrjSvMbsruvG = P_0.eaTtqRfUIEDDcqXQZXCeRojPusoj;
					MktNlaZwXPfZhHDkMcTYJnMZKHFPA = 0;
					WzSylajoGwFDUbaqRMrXWyYIFgER = default(TKey);
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
					if (fPSdHFabxPSWYNTAwrjSvMbsruvG != EMlAOFfUnvTLujmqprUGouIChQIsA.eaTtqRfUIEDDcqXQZXCeRojPusoj)
					{
						throw new Exception();
					}
					while ((uint)MktNlaZwXPfZhHDkMcTYJnMZKHFPA < (uint)EMlAOFfUnvTLujmqprUGouIChQIsA._count)
					{
						if (EMlAOFfUnvTLujmqprUGouIChQIsA._entries[MktNlaZwXPfZhHDkMcTYJnMZKHFPA].hashCode >= 0)
						{
							WzSylajoGwFDUbaqRMrXWyYIFgER = EMlAOFfUnvTLujmqprUGouIChQIsA._entries[MktNlaZwXPfZhHDkMcTYJnMZKHFPA].key;
							MktNlaZwXPfZhHDkMcTYJnMZKHFPA++;
							return true;
						}
						MktNlaZwXPfZhHDkMcTYJnMZKHFPA++;
					}
					MktNlaZwXPfZhHDkMcTYJnMZKHFPA = EMlAOFfUnvTLujmqprUGouIChQIsA._count + 1;
					WzSylajoGwFDUbaqRMrXWyYIFgER = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (fPSdHFabxPSWYNTAwrjSvMbsruvG != EMlAOFfUnvTLujmqprUGouIChQIsA.eaTtqRfUIEDDcqXQZXCeRojPusoj)
					{
						throw new Exception();
					}
					MktNlaZwXPfZhHDkMcTYJnMZKHFPA = 0;
					WzSylajoGwFDUbaqRMrXWyYIFgER = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> fSVdjCGXZkzhksctvLhnifXzawvU;

			int ICollection<TKey>.Count => fSVdjCGXZkzhksctvLhnifXzawvU.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)fSVdjCGXZkzhksctvLhnifXzawvU).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				fSVdjCGXZkzhksctvLhnifXzawvU = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(fSVdjCGXZkzhksctvLhnifXzawvU);
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
				if (array.Length - index < fSVdjCGXZkzhksctvLhnifXzawvU.Count)
				{
					throw new Exception();
				}
				int count = fSVdjCGXZkzhksctvLhnifXzawvU._count;
				Entry[] entries = fSVdjCGXZkzhksctvLhnifXzawvU._entries;
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

			private void nCCKEeBanzbwQbKHuZeikIcjrwlDb(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in nCCKEeBanzbwQbKHuZeikIcjrwlDb
				this.nCCKEeBanzbwQbKHuZeikIcjrwlDb(P_0);
			}

			private void qiXgJVXmUNFetxcHCSQAkwUzErLG()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in qiXgJVXmUNFetxcHCSQAkwUzErLG
				this.qiXgJVXmUNFetxcHCSQAkwUzErLG();
			}

			private bool wlxvBzxrZfEHUoyIbNvnHqJRhCnP(TKey P_0)
			{
				return fSVdjCGXZkzhksctvLhnifXzawvU.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in wlxvBzxrZfEHUoyIbNvnHqJRhCnP
				return this.wlxvBzxrZfEHUoyIbNvnHqJRhCnP(P_0);
			}

			private bool vGiZtfymcNxtQqhtqVUrVwAFQnnO(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in vGiZtfymcNxtQqhtqVUrVwAFQnnO
				return this.vGiZtfymcNxtQqhtqVUrVwAFQnnO(P_0);
			}

			private IEnumerator<TKey> KEXkFeushwfArRCZbFRvwJvROaCB()
			{
				return new Enumerator(fSVdjCGXZkzhksctvLhnifXzawvU);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in KEXkFeushwfArRCZbFRvwJvROaCB
				return this.KEXkFeushwfArRCZbFRvwJvROaCB();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(fSVdjCGXZkzhksctvLhnifXzawvU);
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
				if (array.Length - index < fSVdjCGXZkzhksctvLhnifXzawvU.Count)
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
				int count = fSVdjCGXZkzhksctvLhnifXzawvU._count;
				Entry[] entries = fSVdjCGXZkzhksctvLhnifXzawvU._entries;
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
				private ADictionary<TKey, TValue> VlljgzAWcTGnQcSSEOseKHtHAZVp;

				private int WSwgUbAOdzOrThvScaNpkdIfazbeA;

				private int zrfWcXkXKoFkPDOuKpyBFcGKAwDhA;

				private TValue nazdtSDRJMeZttreOgFtABVPhRDjA;

				TValue IEnumerator<TValue>.Current => nazdtSDRJMeZttreOgFtABVPhRDjA;

				object IEnumerator.Current
				{
					get
					{
						if (WSwgUbAOdzOrThvScaNpkdIfazbeA == 0 || WSwgUbAOdzOrThvScaNpkdIfazbeA == VlljgzAWcTGnQcSSEOseKHtHAZVp._count + 1)
						{
							throw new Exception();
						}
						return nazdtSDRJMeZttreOgFtABVPhRDjA;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					VlljgzAWcTGnQcSSEOseKHtHAZVp = P_0;
					zrfWcXkXKoFkPDOuKpyBFcGKAwDhA = P_0.eaTtqRfUIEDDcqXQZXCeRojPusoj;
					WSwgUbAOdzOrThvScaNpkdIfazbeA = 0;
					nazdtSDRJMeZttreOgFtABVPhRDjA = default(TValue);
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
					if (zrfWcXkXKoFkPDOuKpyBFcGKAwDhA != VlljgzAWcTGnQcSSEOseKHtHAZVp.eaTtqRfUIEDDcqXQZXCeRojPusoj)
					{
						throw new Exception();
					}
					while ((uint)WSwgUbAOdzOrThvScaNpkdIfazbeA < (uint)VlljgzAWcTGnQcSSEOseKHtHAZVp._count)
					{
						if (VlljgzAWcTGnQcSSEOseKHtHAZVp._entries[WSwgUbAOdzOrThvScaNpkdIfazbeA].hashCode >= 0)
						{
							nazdtSDRJMeZttreOgFtABVPhRDjA = VlljgzAWcTGnQcSSEOseKHtHAZVp._entries[WSwgUbAOdzOrThvScaNpkdIfazbeA].value;
							WSwgUbAOdzOrThvScaNpkdIfazbeA++;
							return true;
						}
						WSwgUbAOdzOrThvScaNpkdIfazbeA++;
					}
					WSwgUbAOdzOrThvScaNpkdIfazbeA = VlljgzAWcTGnQcSSEOseKHtHAZVp._count + 1;
					nazdtSDRJMeZttreOgFtABVPhRDjA = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (zrfWcXkXKoFkPDOuKpyBFcGKAwDhA != VlljgzAWcTGnQcSSEOseKHtHAZVp.eaTtqRfUIEDDcqXQZXCeRojPusoj)
					{
						throw new Exception();
					}
					WSwgUbAOdzOrThvScaNpkdIfazbeA = 0;
					nazdtSDRJMeZttreOgFtABVPhRDjA = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> mvrmvGJNcQuUZPEwDVeXcgAKLJvW;

			int ICollection<TValue>.Count => mvrmvGJNcQuUZPEwDVeXcgAKLJvW.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)mvrmvGJNcQuUZPEwDVeXcgAKLJvW).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				mvrmvGJNcQuUZPEwDVeXcgAKLJvW = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(mvrmvGJNcQuUZPEwDVeXcgAKLJvW);
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
				if (array.Length - index < mvrmvGJNcQuUZPEwDVeXcgAKLJvW.Count)
				{
					throw new Exception();
				}
				int count = mvrmvGJNcQuUZPEwDVeXcgAKLJvW._count;
				Entry[] entries = mvrmvGJNcQuUZPEwDVeXcgAKLJvW._entries;
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

			private void TqUZiAiNdZYjFIKybmvkWunonKcu(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in TqUZiAiNdZYjFIKybmvkWunonKcu
				this.TqUZiAiNdZYjFIKybmvkWunonKcu(P_0);
			}

			private bool EXePDcnmloFwagiRIzTiAbStxQbN(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in EXePDcnmloFwagiRIzTiAbStxQbN
				return this.EXePDcnmloFwagiRIzTiAbStxQbN(P_0);
			}

			private void wHUXsweNYlIxEHcAcpzxkCCXanOdA()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in wHUXsweNYlIxEHcAcpzxkCCXanOdA
				this.wHUXsweNYlIxEHcAcpzxkCCXanOdA();
			}

			private bool QBkuETYHOKwpizwfaouxWQKenZZS(TValue P_0)
			{
				return mvrmvGJNcQuUZPEwDVeXcgAKLJvW.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in QBkuETYHOKwpizwfaouxWQKenZZS
				return this.QBkuETYHOKwpizwfaouxWQKenZZS(P_0);
			}

			private IEnumerator<TValue> YwQgKaCppoXpAoSXRpfHsnLSiNkqA()
			{
				return new Enumerator(mvrmvGJNcQuUZPEwDVeXcgAKLJvW);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in YwQgKaCppoXpAoSXRpfHsnLSiNkqA
				return this.YwQgKaCppoXpAoSXRpfHsnLSiNkqA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(mvrmvGJNcQuUZPEwDVeXcgAKLJvW);
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
				if (array.Length - index < mvrmvGJNcQuUZPEwDVeXcgAKLJvW.Count)
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
				int count = mvrmvGJNcQuUZPEwDVeXcgAKLJvW._count;
				Entry[] entries = mvrmvGJNcQuUZPEwDVeXcgAKLJvW._entries;
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

		private int[] oULEMqBHOcaAvwmwMYoNbyIfIuFkA;

		internal Entry[] _entries;

		internal int _count;

		private int eaTtqRfUIEDDcqXQZXCeRojPusoj;

		private int rAOWdRPYRKdpqJLDGvrnEKKmUFBP;

		private int njpOIGgfkQbbpmDKKGuADBOgWmrT;

		private int drwfJNPDetUiQclwACCIJQsMjvtL;

		private IEqualityComparer<TKey> mhYuoZrjTTpQOJpREbKfgMbgYDZr;

		private IEqualityComparer<TValue> EmBtXrQPhTmXtJjtgSEomrgsQjmI;

		private KeyCollection CswJMcAldigEyKtrFfmFJmCOFRCEA;

		private ValueCollection BBtGbtlofZeNmjWbrkMPehahBdUHA;

		private readonly object AQJnLtoqeAWWpFUrUcASLrnOctwv = new object();

		private static readonly bool QSJBjzEUqmnewFGayZJoJyBDQpGbA = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool wuKCgJFpbayxRnBLfriyCuFvBRVpA = ReflectionTools.IsValueType(typeof(TValue));

		private const string JGhRUEYxvsppVIoyBpZZPCnniNjn = "Version";

		private const string ZKWeoCliDuLCcgtDKHcxRfgkVoEC = "HashSize";

		private const string ULbevUxsXSsfKyqoEuxoenSjdAIO = "KeyValuePairs";

		private const string ajmOuUCLqaRGpNdPgqmlNeGealdF = "Comparer";

		int ICollection<KeyValuePair<TKey, TValue>>.Count => _count - drwfJNPDetUiQclwACCIJQsMjvtL;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (CswJMcAldigEyKtrFfmFJmCOFRCEA == null)
				{
					CswJMcAldigEyKtrFfmFJmCOFRCEA = new KeyCollection(this);
				}
				return CswJMcAldigEyKtrFfmFJmCOFRCEA;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (BBtGbtlofZeNmjWbrkMPehahBdUHA == null)
				{
					BBtGbtlofZeNmjWbrkMPehahBdUHA = new ValueCollection(this);
				}
				return BBtGbtlofZeNmjWbrkMPehahBdUHA;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return mhYuoZrjTTpQOJpREbKfgMbgYDZr;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				mhYuoZrjTTpQOJpREbKfgMbgYDZr = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return EmBtXrQPhTmXtJjtgSEomrgsQjmI;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				EmBtXrQPhTmXtJjtgSEomrgsQjmI = value;
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
				IFfIkpMumYaoCETHQkHNhntykKrI(key, value, false);
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
				if (CswJMcAldigEyKtrFfmFJmCOFRCEA == null)
				{
					CswJMcAldigEyKtrFfmFJmCOFRCEA = new KeyCollection(this);
				}
				return CswJMcAldigEyKtrFfmFJmCOFRCEA;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (BBtGbtlofZeNmjWbrkMPehahBdUHA == null)
				{
					BBtGbtlofZeNmjWbrkMPehahBdUHA = new ValueCollection(this);
				}
				return BBtGbtlofZeNmjWbrkMPehahBdUHA;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => AQJnLtoqeAWWpFUrUcASLrnOctwv;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (yOTQjpmKJQjqFFNIPMWenfzNXSAV(key))
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
				okAVmrbLfQpqtdzDASTViGWFXqPA<TValue>(value, "value");
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
				DmzXADMWnBCLTXzBjnaLuMUsErzJ(P_0);
			}
			mhYuoZrjTTpQOJpREbKfgMbgYDZr = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			EmBtXrQPhTmXtJjtgSEomrgsQjmI = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
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
			IFfIkpMumYaoCETHQkHNhntykKrI(key, value, true);
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
				for (int i = 0; i < oULEMqBHOcaAvwmwMYoNbyIfIuFkA.Length; i++)
				{
					oULEMqBHOcaAvwmwMYoNbyIfIuFkA[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				njpOIGgfkQbbpmDKKGuADBOgWmrT = -1;
				_count = 0;
				drwfJNPDetUiQclwACCIJQsMjvtL = 0;
				eaTtqRfUIEDDcqXQZXCeRojPusoj++;
				rAOWdRPYRKdpqJLDGvrnEKKmUFBP++;
			}
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

		public bool ContainsKey(TKey key)
		{
			return IndexOfKey(key) >= 0;
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

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		public bool Remove(TKey key)
		{
			if (!QSJBjzEUqmnewFGayZJoJyBDQpGbA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (oULEMqBHOcaAvwmwMYoNbyIfIuFkA != null)
			{
				int num = mhYuoZrjTTpQOJpREbKfgMbgYDZr.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % oULEMqBHOcaAvwmwMYoNbyIfIuFkA.Length;
				int num3 = -1;
				for (int num4 = oULEMqBHOcaAvwmwMYoNbyIfIuFkA[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && mhYuoZrjTTpQOJpREbKfgMbgYDZr.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							oULEMqBHOcaAvwmwMYoNbyIfIuFkA[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = njpOIGgfkQbbpmDKKGuADBOgWmrT;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						njpOIGgfkQbbpmDKKGuADBOgWmrT = num4;
						drwfJNPDetUiQclwACCIJQsMjvtL++;
						eaTtqRfUIEDDcqXQZXCeRojPusoj++;
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
			if (!QSJBjzEUqmnewFGayZJoJyBDQpGbA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (oULEMqBHOcaAvwmwMYoNbyIfIuFkA != null)
			{
				int num = mhYuoZrjTTpQOJpREbKfgMbgYDZr.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = oULEMqBHOcaAvwmwMYoNbyIfIuFkA[num % oULEMqBHOcaAvwmwMYoNbyIfIuFkA.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && mhYuoZrjTTpQOJpREbKfgMbgYDZr.Equals(_entries[num2].key, key))
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
			if (!wuKCgJFpbayxRnBLfriyCuFvBRVpA && value == null)
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
				IEqualityComparer<TValue> emBtXrQPhTmXtJjtgSEomrgsQjmI = EmBtXrQPhTmXtJjtgSEomrgsQjmI;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && emBtXrQPhTmXtJjtgSEomrgsQjmI.Equals(entries[j].value, value))
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

		private void DmzXADMWnBCLTXzBjnaLuMUsErzJ(int P_0)
		{
			int num = UlyXaMpMGJyCbjGiVtAaVIkKBarH.XNnVNXyoxiCGeWBxkdgSJMXkqRW(P_0);
			oULEMqBHOcaAvwmwMYoNbyIfIuFkA = new int[num];
			for (int i = 0; i < oULEMqBHOcaAvwmwMYoNbyIfIuFkA.Length; i++)
			{
				oULEMqBHOcaAvwmwMYoNbyIfIuFkA[i] = -1;
			}
			_entries = new Entry[num];
			njpOIGgfkQbbpmDKKGuADBOgWmrT = -1;
		}

		private void IFfIkpMumYaoCETHQkHNhntykKrI(TKey P_0, TValue P_1, bool P_2)
		{
			if (!QSJBjzEUqmnewFGayZJoJyBDQpGbA && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (oULEMqBHOcaAvwmwMYoNbyIfIuFkA == null)
			{
				DmzXADMWnBCLTXzBjnaLuMUsErzJ(0);
			}
			int num = mhYuoZrjTTpQOJpREbKfgMbgYDZr.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % oULEMqBHOcaAvwmwMYoNbyIfIuFkA.Length;
			for (int num3 = oULEMqBHOcaAvwmwMYoNbyIfIuFkA[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && mhYuoZrjTTpQOJpREbKfgMbgYDZr.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					eaTtqRfUIEDDcqXQZXCeRojPusoj++;
					return;
				}
			}
			int count;
			if (drwfJNPDetUiQclwACCIJQsMjvtL > 0)
			{
				count = njpOIGgfkQbbpmDKKGuADBOgWmrT;
				njpOIGgfkQbbpmDKKGuADBOgWmrT = _entries[count].next;
				drwfJNPDetUiQclwACCIJQsMjvtL--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					YldgOnSkvvGrFHpswzQjRKnmigycA();
					num2 = num % oULEMqBHOcaAvwmwMYoNbyIfIuFkA.Length;
				}
				count = _count;
				_count++;
			}
			_entries[count].hashCode = num;
			_entries[count].next = oULEMqBHOcaAvwmwMYoNbyIfIuFkA[num2];
			_entries[count].key = P_0;
			_entries[count].value = P_1;
			oULEMqBHOcaAvwmwMYoNbyIfIuFkA[num2] = count;
			eaTtqRfUIEDDcqXQZXCeRojPusoj++;
			rAOWdRPYRKdpqJLDGvrnEKKmUFBP++;
		}

		private void YldgOnSkvvGrFHpswzQjRKnmigycA()
		{
			CBEAxVwtWsHfWMumLrFOUloWdrXi(UlyXaMpMGJyCbjGiVtAaVIkKBarH.fJactbhqGmcSFkAZUEZTruVrbTNS(_count), false);
		}

		private void CBEAxVwtWsHfWMumLrFOUloWdrXi(int P_0, bool P_1)
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
						array2[j].hashCode = mhYuoZrjTTpQOJpREbKfgMbgYDZr.GetHashCode(array2[j].key) & 0x7FFFFFFF;
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
			oULEMqBHOcaAvwmwMYoNbyIfIuFkA = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> AGIUMtaGrvywwAJDLQbbSBqhvkuH()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in AGIUMtaGrvywwAJDLQbbSBqhvkuH
			return this.AGIUMtaGrvywwAJDLQbbSBqhvkuH();
		}

		private void EHoCVBPZzJWFthHeIBYkLDWiOWaf(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EHoCVBPZzJWFthHeIBYkLDWiOWaf
			this.EHoCVBPZzJWFthHeIBYkLDWiOWaf(P_0);
		}

		private bool ORvgwGdAJcrVdIVqoJXzHSUirUgb(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && EmBtXrQPhTmXtJjtgSEomrgsQjmI.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ORvgwGdAJcrVdIVqoJXzHSUirUgb
			return this.ORvgwGdAJcrVdIVqoJXzHSUirUgb(P_0);
		}

		private bool YgShfSnACuVUIvqFtAGiRdLbqwzB(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && EmBtXrQPhTmXtJjtgSEomrgsQjmI.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in YgShfSnACuVUIvqFtAGiRdLbqwzB
			return this.YgShfSnACuVUIvqFtAGiRdLbqwzB(P_0);
		}

		private void zwyGzTHjuAJkgljoptpAKnALdwkW(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zwyGzTHjuAJkgljoptpAKnALdwkW
			this.zwyGzTHjuAJkgljoptpAKnALdwkW(P_0, P_1);
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
			okAVmrbLfQpqtdzDASTViGWFXqPA<TValue>(value, "value");
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
			if (yOTQjpmKJQjqFFNIPMWenfzNXSAV(key))
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
			if (yOTQjpmKJQjqFFNIPMWenfzNXSAV(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool yOTQjpmKJQjqFFNIPMWenfzNXSAV(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void okAVmrbLfQpqtdzDASTViGWFXqPA<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}
