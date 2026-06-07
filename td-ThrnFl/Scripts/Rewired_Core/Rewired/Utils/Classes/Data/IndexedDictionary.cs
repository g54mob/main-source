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
		private struct xreyYHBIjNvfPnLYCFHMnEwcobFV
		{
			public TKey eiArWSLsZaryoDPxTFAMJFoFrYCM;

			public TValue qIdJkyQnakDfqAhlLxEbtKMOGqDkA;

			public xreyYHBIjNvfPnLYCFHMnEwcobFV(TKey P_0, TValue P_1)
			{
				eiArWSLsZaryoDPxTFAMJFoFrYCM = P_0;
				qIdJkyQnakDfqAhlLxEbtKMOGqDkA = P_1;
			}

			public KeyValuePair<TKey, TValue> IvhKZLnfXWPjSqyuCnDzJwOiHGIr()
			{
				return new KeyValuePair<TKey, TValue>(eiArWSLsZaryoDPxTFAMJFoFrYCM, qIdJkyQnakDfqAhlLxEbtKMOGqDkA);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> KgMyzpzkvJmCxunAybHWnnlFKIsJ;

			private int ysTfRyBiwYfkztsmNiAKnhdyipIXA;

			private int aUeSqzyUqgSCLDgFHHMXhAAGUlfC;

			private KeyValuePair<TKey, TValue> gEYnIywJHbFLNqMYyqcbRLPiAzlJ;

			private int mSGJiavXgAgWGIJcFFlAWVnQUfpV;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => gEYnIywJHbFLNqMYyqcbRLPiAzlJ;

			object IEnumerator.Current
			{
				get
				{
					if (aUeSqzyUqgSCLDgFHHMXhAAGUlfC == 0 || aUeSqzyUqgSCLDgFHHMXhAAGUlfC == KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1)
					{
						throw new Exception();
					}
					if (mSGJiavXgAgWGIJcFFlAWVnQUfpV == 1)
					{
						return new DictionaryEntry(gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Key, gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Value);
					}
					return new KeyValuePair<TKey, TValue>(gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Key, gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (aUeSqzyUqgSCLDgFHHMXhAAGUlfC == 0 || aUeSqzyUqgSCLDgFHHMXhAAGUlfC == KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Key, gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (aUeSqzyUqgSCLDgFHHMXhAAGUlfC == 0 || aUeSqzyUqgSCLDgFHHMXhAAGUlfC == KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1)
					{
						throw new Exception();
					}
					return gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (aUeSqzyUqgSCLDgFHHMXhAAGUlfC == 0 || aUeSqzyUqgSCLDgFHHMXhAAGUlfC == KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1)
					{
						throw new Exception();
					}
					return gEYnIywJHbFLNqMYyqcbRLPiAzlJ.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				KgMyzpzkvJmCxunAybHWnnlFKIsJ = P_0;
				ysTfRyBiwYfkztsmNiAKnhdyipIXA = P_0.lTiugXzIbqvDryAOoazOaYAaTTTk.Version;
				aUeSqzyUqgSCLDgFHHMXhAAGUlfC = 0;
				mSGJiavXgAgWGIJcFFlAWVnQUfpV = P_1;
				gEYnIywJHbFLNqMYyqcbRLPiAzlJ = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (ysTfRyBiwYfkztsmNiAKnhdyipIXA != KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk.Version)
				{
					throw new Exception();
				}
				if ((uint)aUeSqzyUqgSCLDgFHHMXhAAGUlfC < (uint)KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._count)
				{
					gEYnIywJHbFLNqMYyqcbRLPiAzlJ = new KeyValuePair<TKey, TValue>(KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._items[aUeSqzyUqgSCLDgFHHMXhAAGUlfC].eiArWSLsZaryoDPxTFAMJFoFrYCM, KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._items[aUeSqzyUqgSCLDgFHHMXhAAGUlfC].qIdJkyQnakDfqAhlLxEbtKMOGqDkA);
					aUeSqzyUqgSCLDgFHHMXhAAGUlfC++;
					return true;
				}
				aUeSqzyUqgSCLDgFHHMXhAAGUlfC = KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1;
				gEYnIywJHbFLNqMYyqcbRLPiAzlJ = default(KeyValuePair<TKey, TValue>);
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
				if (ysTfRyBiwYfkztsmNiAKnhdyipIXA != KgMyzpzkvJmCxunAybHWnnlFKIsJ.lTiugXzIbqvDryAOoazOaYAaTTTk.Version)
				{
					throw new Exception();
				}
				aUeSqzyUqgSCLDgFHHMXhAAGUlfC = 0;
				gEYnIywJHbFLNqMYyqcbRLPiAzlJ = default(KeyValuePair<TKey, TValue>);
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
				private IndexedDictionary<TKey, TValue> FvwKvqcVrfBeiuixUmQsIqeUGlPb;

				private int UhtmAGFjMaAiXDrwkzNRteeIKtkRA;

				private int pAeuGyrEbZLJHKfGwyHArXDiazrn;

				private TKey AVFJauCzNbXupwfeqlDfkmiymjEg;

				TKey IEnumerator<TKey>.Current => AVFJauCzNbXupwfeqlDfkmiymjEg;

				object IEnumerator.Current
				{
					get
					{
						if (UhtmAGFjMaAiXDrwkzNRteeIKtkRA == 0 || UhtmAGFjMaAiXDrwkzNRteeIKtkRA == FvwKvqcVrfBeiuixUmQsIqeUGlPb.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1)
						{
							throw new Exception();
						}
						return AVFJauCzNbXupwfeqlDfkmiymjEg;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					FvwKvqcVrfBeiuixUmQsIqeUGlPb = P_0;
					pAeuGyrEbZLJHKfGwyHArXDiazrn = P_0.lTiugXzIbqvDryAOoazOaYAaTTTk.Version;
					UhtmAGFjMaAiXDrwkzNRteeIKtkRA = 0;
					AVFJauCzNbXupwfeqlDfkmiymjEg = default(TKey);
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
					if (pAeuGyrEbZLJHKfGwyHArXDiazrn != FvwKvqcVrfBeiuixUmQsIqeUGlPb.lTiugXzIbqvDryAOoazOaYAaTTTk.Version)
					{
						throw new Exception();
					}
					if ((uint)UhtmAGFjMaAiXDrwkzNRteeIKtkRA < (uint)FvwKvqcVrfBeiuixUmQsIqeUGlPb.lTiugXzIbqvDryAOoazOaYAaTTTk._count)
					{
						AVFJauCzNbXupwfeqlDfkmiymjEg = FvwKvqcVrfBeiuixUmQsIqeUGlPb.lTiugXzIbqvDryAOoazOaYAaTTTk._items[UhtmAGFjMaAiXDrwkzNRteeIKtkRA].eiArWSLsZaryoDPxTFAMJFoFrYCM;
						UhtmAGFjMaAiXDrwkzNRteeIKtkRA++;
						return true;
					}
					UhtmAGFjMaAiXDrwkzNRteeIKtkRA = FvwKvqcVrfBeiuixUmQsIqeUGlPb.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1;
					AVFJauCzNbXupwfeqlDfkmiymjEg = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (pAeuGyrEbZLJHKfGwyHArXDiazrn != FvwKvqcVrfBeiuixUmQsIqeUGlPb.lTiugXzIbqvDryAOoazOaYAaTTTk.Version)
					{
						throw new Exception();
					}
					UhtmAGFjMaAiXDrwkzNRteeIKtkRA = 0;
					AVFJauCzNbXupwfeqlDfkmiymjEg = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> oCzDzmEMfTxysLtBRNfpRgDLnBmdb;

			int ICollection<TKey>.Count => oCzDzmEMfTxysLtBRNfpRgDLnBmdb.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)oCzDzmEMfTxysLtBRNfpRgDLnBmdb).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				oCzDzmEMfTxysLtBRNfpRgDLnBmdb = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(oCzDzmEMfTxysLtBRNfpRgDLnBmdb);
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
				if (array.Length - index < oCzDzmEMfTxysLtBRNfpRgDLnBmdb.Count)
				{
					throw new Exception();
				}
				int count = oCzDzmEMfTxysLtBRNfpRgDLnBmdb.lTiugXzIbqvDryAOoazOaYAaTTTk._count;
				xreyYHBIjNvfPnLYCFHMnEwcobFV[] items = oCzDzmEMfTxysLtBRNfpRgDLnBmdb.lTiugXzIbqvDryAOoazOaYAaTTTk._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void MrHBVZWSDfDicAceTAqaKtWkcRmG(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in MrHBVZWSDfDicAceTAqaKtWkcRmG
				this.MrHBVZWSDfDicAceTAqaKtWkcRmG(P_0);
			}

			private void kdswtDWqAXiqWdZrCuoKyNPofIgs()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in kdswtDWqAXiqWdZrCuoKyNPofIgs
				this.kdswtDWqAXiqWdZrCuoKyNPofIgs();
			}

			private bool AcRLcUbGYJzmlrmjvpSWrHJlGdqz(TKey P_0)
			{
				return oCzDzmEMfTxysLtBRNfpRgDLnBmdb.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in AcRLcUbGYJzmlrmjvpSWrHJlGdqz
				return this.AcRLcUbGYJzmlrmjvpSWrHJlGdqz(P_0);
			}

			private bool HTGlCcBueGUAtpgKkwDMHSFQPSdD(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in HTGlCcBueGUAtpgKkwDMHSFQPSdD
				return this.HTGlCcBueGUAtpgKkwDMHSFQPSdD(P_0);
			}

			private IEnumerator<TKey> jcjlJixCrzengHKSWLbYmSbDNUSlA()
			{
				return new Enumerator(oCzDzmEMfTxysLtBRNfpRgDLnBmdb);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in jcjlJixCrzengHKSWLbYmSbDNUSlA
				return this.jcjlJixCrzengHKSWLbYmSbDNUSlA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(oCzDzmEMfTxysLtBRNfpRgDLnBmdb);
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
				if (array.Length - index < oCzDzmEMfTxysLtBRNfpRgDLnBmdb.Count)
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
				int count = oCzDzmEMfTxysLtBRNfpRgDLnBmdb.lTiugXzIbqvDryAOoazOaYAaTTTk._count;
				xreyYHBIjNvfPnLYCFHMnEwcobFV[] items = oCzDzmEMfTxysLtBRNfpRgDLnBmdb.lTiugXzIbqvDryAOoazOaYAaTTTk._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM;
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
				private IndexedDictionary<TKey, TValue> OeMKFBKdoGfWUIckcwQjnAzECelf;

				private int PiJtmoQrbpxcdXgYucOGkRvhQfEp;

				private int imxcvKNXTFqkcUpyployQObmeuRl;

				private TValue FHDHMkdLfciKSyNYWSzniprKDShp;

				TValue IEnumerator<TValue>.Current => FHDHMkdLfciKSyNYWSzniprKDShp;

				object IEnumerator.Current
				{
					get
					{
						if (PiJtmoQrbpxcdXgYucOGkRvhQfEp == 0 || PiJtmoQrbpxcdXgYucOGkRvhQfEp == OeMKFBKdoGfWUIckcwQjnAzECelf.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1)
						{
							throw new Exception();
						}
						return FHDHMkdLfciKSyNYWSzniprKDShp;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					OeMKFBKdoGfWUIckcwQjnAzECelf = P_0;
					imxcvKNXTFqkcUpyployQObmeuRl = P_0.lTiugXzIbqvDryAOoazOaYAaTTTk.Version;
					PiJtmoQrbpxcdXgYucOGkRvhQfEp = 0;
					FHDHMkdLfciKSyNYWSzniprKDShp = default(TValue);
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
					if (imxcvKNXTFqkcUpyployQObmeuRl != OeMKFBKdoGfWUIckcwQjnAzECelf.lTiugXzIbqvDryAOoazOaYAaTTTk.Version)
					{
						throw new Exception();
					}
					if ((uint)PiJtmoQrbpxcdXgYucOGkRvhQfEp < (uint)OeMKFBKdoGfWUIckcwQjnAzECelf.lTiugXzIbqvDryAOoazOaYAaTTTk._count)
					{
						FHDHMkdLfciKSyNYWSzniprKDShp = OeMKFBKdoGfWUIckcwQjnAzECelf.lTiugXzIbqvDryAOoazOaYAaTTTk._items[PiJtmoQrbpxcdXgYucOGkRvhQfEp].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
						PiJtmoQrbpxcdXgYucOGkRvhQfEp++;
						return true;
					}
					PiJtmoQrbpxcdXgYucOGkRvhQfEp = OeMKFBKdoGfWUIckcwQjnAzECelf.lTiugXzIbqvDryAOoazOaYAaTTTk._count + 1;
					FHDHMkdLfciKSyNYWSzniprKDShp = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (imxcvKNXTFqkcUpyployQObmeuRl != OeMKFBKdoGfWUIckcwQjnAzECelf.lTiugXzIbqvDryAOoazOaYAaTTTk.Version)
					{
						throw new Exception();
					}
					PiJtmoQrbpxcdXgYucOGkRvhQfEp = 0;
					FHDHMkdLfciKSyNYWSzniprKDShp = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> FtBaHWgYGajIacdLfdNLGUDCzeYcb;

			int ICollection<TValue>.Count => FtBaHWgYGajIacdLfdNLGUDCzeYcb.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)FtBaHWgYGajIacdLfdNLGUDCzeYcb).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				FtBaHWgYGajIacdLfdNLGUDCzeYcb = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(FtBaHWgYGajIacdLfdNLGUDCzeYcb);
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
				if (array.Length - index < FtBaHWgYGajIacdLfdNLGUDCzeYcb.Count)
				{
					throw new Exception();
				}
				int count = FtBaHWgYGajIacdLfdNLGUDCzeYcb.lTiugXzIbqvDryAOoazOaYAaTTTk._count;
				xreyYHBIjNvfPnLYCFHMnEwcobFV[] items = FtBaHWgYGajIacdLfdNLGUDCzeYcb.lTiugXzIbqvDryAOoazOaYAaTTTk._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void nluYDxXQvpEejzYsJfEWkrZxANBP(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in nluYDxXQvpEejzYsJfEWkrZxANBP
				this.nluYDxXQvpEejzYsJfEWkrZxANBP(P_0);
			}

			private bool iHmuLZxOAkbdURJYMsipXuODlamr(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in iHmuLZxOAkbdURJYMsipXuODlamr
				return this.iHmuLZxOAkbdURJYMsipXuODlamr(P_0);
			}

			private void ymwsMleVoWMOhgbOQZoJprAWVNAf()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ymwsMleVoWMOhgbOQZoJprAWVNAf
				this.ymwsMleVoWMOhgbOQZoJprAWVNAf();
			}

			private bool ViZtNgqGxTHuwewrvgSGGoUfuQHJ(TValue P_0)
			{
				return FtBaHWgYGajIacdLfdNLGUDCzeYcb.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ViZtNgqGxTHuwewrvgSGGoUfuQHJ
				return this.ViZtNgqGxTHuwewrvgSGGoUfuQHJ(P_0);
			}

			private IEnumerator<TValue> BMcdXeWOpIWcywLlQvOyiGPqfJRl()
			{
				return new Enumerator(FtBaHWgYGajIacdLfdNLGUDCzeYcb);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in BMcdXeWOpIWcywLlQvOyiGPqfJRl
				return this.BMcdXeWOpIWcywLlQvOyiGPqfJRl();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(FtBaHWgYGajIacdLfdNLGUDCzeYcb);
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
				if (array.Length - index < FtBaHWgYGajIacdLfdNLGUDCzeYcb.Count)
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
				int count = FtBaHWgYGajIacdLfdNLGUDCzeYcb.lTiugXzIbqvDryAOoazOaYAaTTTk._count;
				xreyYHBIjNvfPnLYCFHMnEwcobFV[] items = FtBaHWgYGajIacdLfdNLGUDCzeYcb.lTiugXzIbqvDryAOoazOaYAaTTTk._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool kuTFVuafLImnLAGHdkezADmhblUY = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool UfNiZaxKjbjvZXykCmPyFEMfDfAk = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> PiqbMzMsEElOpgeVHCAiKiaOeXajA = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> nGzQMhwQopcYhYwImLFGwTRBljvN = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<xreyYHBIjNvfPnLYCFHMnEwcobFV> lTiugXzIbqvDryAOoazOaYAaTTTk;

		private readonly ADictionary<TKey, int> FIBZbQkZItKRSRubiFFQOzuxrkZO;

		private bool dKgVQqRvLYJfWDnilNWILAbTNyYe;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => lTiugXzIbqvDryAOoazOaYAaTTTk._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!dKgVQqRvLYJfWDnilNWILAbTNyYe)
				{
					return false;
				}
				return FIBZbQkZItKRSRubiFFQOzuxrkZO._count < lTiugXzIbqvDryAOoazOaYAaTTTk._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return dKgVQqRvLYJfWDnilNWILAbTNyYe;
			}
			set
			{
				if (dKgVQqRvLYJfWDnilNWILAbTNyYe != value)
				{
					dKgVQqRvLYJfWDnilNWILAbTNyYe = value;
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
				if ((uint)index >= (uint)lTiugXzIbqvDryAOoazOaYAaTTTk._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return lTiugXzIbqvDryAOoazOaYAaTTTk._items[index].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
			}
			set
			{
				if ((uint)index >= (uint)lTiugXzIbqvDryAOoazOaYAaTTTk._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				lTiugXzIbqvDryAOoazOaYAaTTTk._items[index].qIdJkyQnakDfqAhlLxEbtKMOGqDkA = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return PiqbMzMsEElOpgeVHCAiKiaOeXajA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				PiqbMzMsEElOpgeVHCAiKiaOeXajA = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return nGzQMhwQopcYhYwImLFGwTRBljvN;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				nGzQMhwQopcYhYwImLFGwTRBljvN = value;
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
				return lTiugXzIbqvDryAOoazOaYAaTTTk._items[num].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
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

		bool ICollection.IsSynchronized => ((ICollection)lTiugXzIbqvDryAOoazOaYAaTTTk).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)lTiugXzIbqvDryAOoazOaYAaTTTk).SyncRoot;

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
			dKgVQqRvLYJfWDnilNWILAbTNyYe = P_1;
			lTiugXzIbqvDryAOoazOaYAaTTTk = new AList<xreyYHBIjNvfPnLYCFHMnEwcobFV>(P_0);
			FIBZbQkZItKRSRubiFFQOzuxrkZO = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.lTiugXzIbqvDryAOoazOaYAaTTTk._count; i++)
				{
					Add(indexedDictionary.lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM, indexedDictionary.lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].qIdJkyQnakDfqAhlLxEbtKMOGqDkA);
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
			return lTiugXzIbqvDryAOoazOaYAaTTTk._items[FIBZbQkZItKRSRubiFFQOzuxrkZO[key]].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!FIBZbQkZItKRSRubiFFQOzuxrkZO.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = lTiugXzIbqvDryAOoazOaYAaTTTk._items[value2].qIdJkyQnakDfqAhlLxEbtKMOGqDkA;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)lTiugXzIbqvDryAOoazOaYAaTTTk._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<xreyYHBIjNvfPnLYCFHMnEwcobFV, _003F>.xreyYHBIjNvfPnLYCFHMnEwcobFV>)(object)lTiugXzIbqvDryAOoazOaYAaTTTk)[index].eiArWSLsZaryoDPxTFAMJFoFrYCM;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<xreyYHBIjNvfPnLYCFHMnEwcobFV, _003F>.xreyYHBIjNvfPnLYCFHMnEwcobFV>)(object)lTiugXzIbqvDryAOoazOaYAaTTTk)[FIBZbQkZItKRSRubiFFQOzuxrkZO[key]].IvhKZLnfXWPjSqyuCnDzJwOiHGIr();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)lTiugXzIbqvDryAOoazOaYAaTTTk._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<xreyYHBIjNvfPnLYCFHMnEwcobFV, _003F>.xreyYHBIjNvfPnLYCFHMnEwcobFV>)(object)lTiugXzIbqvDryAOoazOaYAaTTTk)[index].IvhKZLnfXWPjSqyuCnDzJwOiHGIr();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!FIBZbQkZItKRSRubiFFQOzuxrkZO.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<xreyYHBIjNvfPnLYCFHMnEwcobFV, _003F>.xreyYHBIjNvfPnLYCFHMnEwcobFV>)(object)lTiugXzIbqvDryAOoazOaYAaTTTk)[value].IvhKZLnfXWPjSqyuCnDzJwOiHGIr();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = FIBZbQkZItKRSRubiFFQOzuxrkZO.ContainsKey(key);
			if (num && !dKgVQqRvLYJfWDnilNWILAbTNyYe)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = lTiugXzIbqvDryAOoazOaYAaTTTk.Add(new xreyYHBIjNvfPnLYCFHMnEwcobFV(key, value));
			if (num)
			{
				FIBZbQkZItKRSRubiFFQOzuxrkZO[key] = num2;
			}
			else
			{
				FIBZbQkZItKRSRubiFFQOzuxrkZO.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (FIBZbQkZItKRSRubiFFQOzuxrkZO.TryGetValue(key, out var value2))
			{
				lTiugXzIbqvDryAOoazOaYAaTTTk._items[value2].qIdJkyQnakDfqAhlLxEbtKMOGqDkA = value;
				FIBZbQkZItKRSRubiFFQOzuxrkZO[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			FIBZbQkZItKRSRubiFFQOzuxrkZO.Remove(key);
			if (dKgVQqRvLYJfWDnilNWILAbTNyYe)
			{
				bool result = false;
				for (int num = lTiugXzIbqvDryAOoazOaYAaTTTk._count - 1; num >= 0; num--)
				{
					if (PiqbMzMsEElOpgeVHCAiKiaOeXajA.Equals(lTiugXzIbqvDryAOoazOaYAaTTTk._items[num].eiArWSLsZaryoDPxTFAMJFoFrYCM, key))
					{
						lTiugXzIbqvDryAOoazOaYAaTTTk.RemoveAt(num);
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
			if ((uint)index >= (uint)lTiugXzIbqvDryAOoazOaYAaTTTk._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey eiArWSLsZaryoDPxTFAMJFoFrYCM = lTiugXzIbqvDryAOoazOaYAaTTTk._items[index].eiArWSLsZaryoDPxTFAMJFoFrYCM;
			if (index < lTiugXzIbqvDryAOoazOaYAaTTTk._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<xreyYHBIjNvfPnLYCFHMnEwcobFV, _003F>.xreyYHBIjNvfPnLYCFHMnEwcobFV>)(object)lTiugXzIbqvDryAOoazOaYAaTTTk).Count; i++)
				{
					FIBZbQkZItKRSRubiFFQOzuxrkZO[lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM] = i - 1;
				}
			}
			lTiugXzIbqvDryAOoazOaYAaTTTk.RemoveAt(index);
			FIBZbQkZItKRSRubiFFQOzuxrkZO.Remove(eiArWSLsZaryoDPxTFAMJFoFrYCM);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref lTiugXzIbqvDryAOoazOaYAaTTTk._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = lTiugXzIbqvDryAOoazOaYAaTTTk._count - 1; num2 >= 0; num2--)
			{
				_ = ref lTiugXzIbqvDryAOoazOaYAaTTTk._items[num2];
				if (nGzQMhwQopcYhYwImLFGwTRBljvN.Equals(lTiugXzIbqvDryAOoazOaYAaTTTk._items[num2].qIdJkyQnakDfqAhlLxEbtKMOGqDkA, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!kuTFVuafLImnLAGHdkezADmhblUY && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = lTiugXzIbqvDryAOoazOaYAaTTTk._count;
			for (int i = 0; i < count; i++)
			{
				if (PiqbMzMsEElOpgeVHCAiKiaOeXajA.Equals(lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = lTiugXzIbqvDryAOoazOaYAaTTTk._count;
			for (int i = 0; i < count; i++)
			{
				if (nGzQMhwQopcYhYwImLFGwTRBljvN.Equals(lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].qIdJkyQnakDfqAhlLxEbtKMOGqDkA, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return FIBZbQkZItKRSRubiFFQOzuxrkZO.ContainsKey(key);
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
			lTiugXzIbqvDryAOoazOaYAaTTTk.Clear();
			FIBZbQkZItKRSRubiFFQOzuxrkZO.Clear();
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
			lTiugXzIbqvDryAOoazOaYAaTTTk.TrimExcess();
		}

		private void pFwLJFItyidBuFJKNYPTeNzMdddV(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pFwLJFItyidBuFJKNYPTeNzMdddV
			this.pFwLJFItyidBuFJKNYPTeNzMdddV(P_0);
		}

		private bool FBZsnuKcnhiDoLfLNHrwVfEVffyB(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			xreyYHBIjNvfPnLYCFHMnEwcobFV xreyYHBIjNvfPnLYCFHMnEwcobFV2 = lTiugXzIbqvDryAOoazOaYAaTTTk._items[num];
			return nGzQMhwQopcYhYwImLFGwTRBljvN.Equals(P_0.Value, xreyYHBIjNvfPnLYCFHMnEwcobFV2.qIdJkyQnakDfqAhlLxEbtKMOGqDkA);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FBZsnuKcnhiDoLfLNHrwVfEVffyB
			return this.FBZsnuKcnhiDoLfLNHrwVfEVffyB(P_0);
		}

		private void aVczQxWbjWOpruYKPUrQNTzqCbII(KeyValuePair<TKey, TValue>[] P_0, int P_1)
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
			int count = lTiugXzIbqvDryAOoazOaYAaTTTk._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM, lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].qIdJkyQnakDfqAhlLxEbtKMOGqDkA);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in aVczQxWbjWOpruYKPUrQNTzqCbII
			this.aVczQxWbjWOpruYKPUrQNTzqCbII(P_0, P_1);
		}

		private bool OGgwhOULsFuuvmlsHaoizIXiYtCr(KeyValuePair<TKey, TValue> P_0)
		{
			if (dKgVQqRvLYJfWDnilNWILAbTNyYe)
			{
				bool result = false;
				for (int num = lTiugXzIbqvDryAOoazOaYAaTTTk._count - 1; num >= 0; num--)
				{
					xreyYHBIjNvfPnLYCFHMnEwcobFV xreyYHBIjNvfPnLYCFHMnEwcobFV2 = lTiugXzIbqvDryAOoazOaYAaTTTk._items[num];
					if (nGzQMhwQopcYhYwImLFGwTRBljvN.Equals(P_0.Value, xreyYHBIjNvfPnLYCFHMnEwcobFV2.qIdJkyQnakDfqAhlLxEbtKMOGqDkA))
					{
						lTiugXzIbqvDryAOoazOaYAaTTTk.RemoveAt(num);
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
			xreyYHBIjNvfPnLYCFHMnEwcobFV xreyYHBIjNvfPnLYCFHMnEwcobFV3 = lTiugXzIbqvDryAOoazOaYAaTTTk._items[num2];
			if (!nGzQMhwQopcYhYwImLFGwTRBljvN.Equals(P_0.Value, xreyYHBIjNvfPnLYCFHMnEwcobFV3.qIdJkyQnakDfqAhlLxEbtKMOGqDkA))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OGgwhOULsFuuvmlsHaoizIXiYtCr
			return this.OGgwhOULsFuuvmlsHaoizIXiYtCr(P_0);
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
			int count = lTiugXzIbqvDryAOoazOaYAaTTTk._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].eiArWSLsZaryoDPxTFAMJFoFrYCM, lTiugXzIbqvDryAOoazOaYAaTTTk._items[i].qIdJkyQnakDfqAhlLxEbtKMOGqDkA), index++);
			}
		}

		private int FvORtfINGAQAlJXcrqGDpVCaiJYg(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FvORtfINGAQAlJXcrqGDpVCaiJYg
			return this.FvORtfINGAQAlJXcrqGDpVCaiJYg(P_0);
		}

		private bool WTUsloOFdfTyaqILjyArloydGFbk(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WTUsloOFdfTyaqILjyArloydGFbk
			return this.WTUsloOFdfTyaqILjyArloydGFbk(P_0);
		}

		private int VWnQLcUkbQiNbppnRGoCAnkdtikRA(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in VWnQLcUkbQiNbppnRGoCAnkdtikRA
			return this.VWnQLcUkbQiNbppnRGoCAnkdtikRA(P_0);
		}

		private bool vIIWCkFrqsOpyEocSaOZCVUnYAOw(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in vIIWCkFrqsOpyEocSaOZCVUnYAOw
			return this.vIIWCkFrqsOpyEocSaOZCVUnYAOw(P_0);
		}
	}
}
