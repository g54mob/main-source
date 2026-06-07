using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct ACHatJGFhKGUxaPSJUCJWLwMBnpEA
		{
			public TKey JjwcOhQJlFDCSYfMHZTrgennIqLA;

			public TValue PtOGmmDeOtYBMXEzQJqyUICmmlbm;

			public ACHatJGFhKGUxaPSJUCJWLwMBnpEA(TKey P_0, TValue P_1)
			{
				JjwcOhQJlFDCSYfMHZTrgennIqLA = P_0;
				PtOGmmDeOtYBMXEzQJqyUICmmlbm = P_1;
			}

			public KeyValuePair<TKey, TValue> hFGnEReCVNGJmvioZdAweTASvAct()
			{
				return new KeyValuePair<TKey, TValue>(JjwcOhQJlFDCSYfMHZTrgennIqLA, PtOGmmDeOtYBMXEzQJqyUICmmlbm);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private IndexedDictionary<TKey, TValue> xvnCKdcxxYzPDxFUdjoRGnppkGQW;

			private int VbwngqtsoFNZPfwqKNxNYGzGfJwF;

			private int BMRImrxCQrqppYssGeUQILQoJKBn;

			private KeyValuePair<TKey, TValue> JurEPeCbBihojIdAIvrcjyTTQYVPc;

			private int LdjIXqkspDzraVmsKivDbvkqfrZD;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => JurEPeCbBihojIdAIvrcjyTTQYVPc;

			object IEnumerator.Current
			{
				get
				{
					if (BMRImrxCQrqppYssGeUQILQoJKBn == 0 || BMRImrxCQrqppYssGeUQILQoJKBn == xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1)
					{
						throw new Exception();
					}
					if (LdjIXqkspDzraVmsKivDbvkqfrZD == 1)
					{
						return new DictionaryEntry(JurEPeCbBihojIdAIvrcjyTTQYVPc.Key, JurEPeCbBihojIdAIvrcjyTTQYVPc.Value);
					}
					return new KeyValuePair<TKey, TValue>(JurEPeCbBihojIdAIvrcjyTTQYVPc.Key, JurEPeCbBihojIdAIvrcjyTTQYVPc.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (BMRImrxCQrqppYssGeUQILQoJKBn == 0 || BMRImrxCQrqppYssGeUQILQoJKBn == xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(JurEPeCbBihojIdAIvrcjyTTQYVPc.Key, JurEPeCbBihojIdAIvrcjyTTQYVPc.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (BMRImrxCQrqppYssGeUQILQoJKBn == 0 || BMRImrxCQrqppYssGeUQILQoJKBn == xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1)
					{
						throw new Exception();
					}
					return JurEPeCbBihojIdAIvrcjyTTQYVPc.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (BMRImrxCQrqppYssGeUQILQoJKBn == 0 || BMRImrxCQrqppYssGeUQILQoJKBn == xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1)
					{
						throw new Exception();
					}
					return JurEPeCbBihojIdAIvrcjyTTQYVPc.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
			{
				xvnCKdcxxYzPDxFUdjoRGnppkGQW = P_0;
				VbwngqtsoFNZPfwqKNxNYGzGfJwF = P_0.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version;
				BMRImrxCQrqppYssGeUQILQoJKBn = 0;
				LdjIXqkspDzraVmsKivDbvkqfrZD = P_1;
				JurEPeCbBihojIdAIvrcjyTTQYVPc = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (VbwngqtsoFNZPfwqKNxNYGzGfJwF != xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version)
				{
					throw new Exception();
				}
				if ((uint)BMRImrxCQrqppYssGeUQILQoJKBn < (uint)xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
				{
					JurEPeCbBihojIdAIvrcjyTTQYVPc = new KeyValuePair<TKey, TValue>(xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[BMRImrxCQrqppYssGeUQILQoJKBn].JjwcOhQJlFDCSYfMHZTrgennIqLA, xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[BMRImrxCQrqppYssGeUQILQoJKBn].PtOGmmDeOtYBMXEzQJqyUICmmlbm);
					BMRImrxCQrqppYssGeUQILQoJKBn++;
					return true;
				}
				BMRImrxCQrqppYssGeUQILQoJKBn = xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1;
				JurEPeCbBihojIdAIvrcjyTTQYVPc = default(KeyValuePair<TKey, TValue>);
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
				if (VbwngqtsoFNZPfwqKNxNYGzGfJwF != xvnCKdcxxYzPDxFUdjoRGnppkGQW.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version)
				{
					throw new Exception();
				}
				BMRImrxCQrqppYssGeUQILQoJKBn = 0;
				JurEPeCbBihojIdAIvrcjyTTQYVPc = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private IndexedDictionary<TKey, TValue> mnPMejtcPiImEgnmDOnXCbcqNYXfA;

				private int frWuYAIGEtTnswuGtUGAFsgqdRMD;

				private int KJHyufetHGapuBOApIdJYBwUvDrc;

				private TKey tneexoaPPoikLhduIpqsmTsUKigqB;

				TKey IEnumerator<TKey>.Current => tneexoaPPoikLhduIpqsmTsUKigqB;

				object IEnumerator.Current
				{
					get
					{
						if (frWuYAIGEtTnswuGtUGAFsgqdRMD == 0 || frWuYAIGEtTnswuGtUGAFsgqdRMD == mnPMejtcPiImEgnmDOnXCbcqNYXfA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1)
						{
							throw new Exception();
						}
						return tneexoaPPoikLhduIpqsmTsUKigqB;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					mnPMejtcPiImEgnmDOnXCbcqNYXfA = P_0;
					KJHyufetHGapuBOApIdJYBwUvDrc = P_0.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version;
					frWuYAIGEtTnswuGtUGAFsgqdRMD = 0;
					tneexoaPPoikLhduIpqsmTsUKigqB = default(TKey);
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
					if (KJHyufetHGapuBOApIdJYBwUvDrc != mnPMejtcPiImEgnmDOnXCbcqNYXfA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version)
					{
						throw new Exception();
					}
					if ((uint)frWuYAIGEtTnswuGtUGAFsgqdRMD < (uint)mnPMejtcPiImEgnmDOnXCbcqNYXfA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
					{
						tneexoaPPoikLhduIpqsmTsUKigqB = mnPMejtcPiImEgnmDOnXCbcqNYXfA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[frWuYAIGEtTnswuGtUGAFsgqdRMD].JjwcOhQJlFDCSYfMHZTrgennIqLA;
						frWuYAIGEtTnswuGtUGAFsgqdRMD++;
						return true;
					}
					frWuYAIGEtTnswuGtUGAFsgqdRMD = mnPMejtcPiImEgnmDOnXCbcqNYXfA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1;
					tneexoaPPoikLhduIpqsmTsUKigqB = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (KJHyufetHGapuBOApIdJYBwUvDrc != mnPMejtcPiImEgnmDOnXCbcqNYXfA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version)
					{
						throw new Exception();
					}
					frWuYAIGEtTnswuGtUGAFsgqdRMD = 0;
					tneexoaPPoikLhduIpqsmTsUKigqB = default(TKey);
				}
			}

			private IndexedDictionary<TKey, TValue> JmUNDeXjxYTiAuiJYjggJMLpcLEBA;

			int ICollection<TKey>.Count => JmUNDeXjxYTiAuiJYjggJMLpcLEBA.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)JmUNDeXjxYTiAuiJYjggJMLpcLEBA).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				JmUNDeXjxYTiAuiJYjggJMLpcLEBA = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(JmUNDeXjxYTiAuiJYjggJMLpcLEBA);
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
				if (array.Length - index < JmUNDeXjxYTiAuiJYjggJMLpcLEBA.Count)
				{
					throw new Exception();
				}
				int count = JmUNDeXjxYTiAuiJYjggJMLpcLEBA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
				ACHatJGFhKGUxaPSJUCJWLwMBnpEA[] items = JmUNDeXjxYTiAuiJYjggJMLpcLEBA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA;
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void tFiktZHlOwEuARpeGZHfvgOCyyIr(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in tFiktZHlOwEuARpeGZHfvgOCyyIr
				this.tFiktZHlOwEuARpeGZHfvgOCyyIr(P_0);
			}

			private void ZLBDLZHUQMJRowVbVhpRLSPKqOAp()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ZLBDLZHUQMJRowVbVhpRLSPKqOAp
				this.ZLBDLZHUQMJRowVbVhpRLSPKqOAp();
			}

			private bool vnuEWQsSnEFSJopmkDiXULPDdaCf(TKey P_0)
			{
				return JmUNDeXjxYTiAuiJYjggJMLpcLEBA.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in vnuEWQsSnEFSJopmkDiXULPDdaCf
				return this.vnuEWQsSnEFSJopmkDiXULPDdaCf(P_0);
			}

			private bool wJpnLWWxgTtfTynizmlLetAoLLRM(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in wJpnLWWxgTtfTynizmlLetAoLLRM
				return this.wJpnLWWxgTtfTynizmlLetAoLLRM(P_0);
			}

			private IEnumerator<TKey> MnYpzqsnXmUDSPKOFuhPtpFvWcwF()
			{
				return new Enumerator(JmUNDeXjxYTiAuiJYjggJMLpcLEBA);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MnYpzqsnXmUDSPKOFuhPtpFvWcwF
				return this.MnYpzqsnXmUDSPKOFuhPtpFvWcwF();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(JmUNDeXjxYTiAuiJYjggJMLpcLEBA);
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
				if (array.Length - index < JmUNDeXjxYTiAuiJYjggJMLpcLEBA.Count)
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
				int count = JmUNDeXjxYTiAuiJYjggJMLpcLEBA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
				ACHatJGFhKGUxaPSJUCJWLwMBnpEA[] items = JmUNDeXjxYTiAuiJYjggJMLpcLEBA.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private IndexedDictionary<TKey, TValue> jRzJiXTPaBEXcFicxEzwAjjelMBx;

				private int eAgHXcgBfisWHCAAghVXtThORluXB;

				private int PCQWHGCENCFJKTSgkZphtFdMzevQ;

				private TValue gtkcUmaHprxLmvXKJcYoPuryMLRi;

				TValue IEnumerator<TValue>.Current => gtkcUmaHprxLmvXKJcYoPuryMLRi;

				object IEnumerator.Current
				{
					get
					{
						if (eAgHXcgBfisWHCAAghVXtThORluXB == 0 || eAgHXcgBfisWHCAAghVXtThORluXB == jRzJiXTPaBEXcFicxEzwAjjelMBx.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1)
						{
							throw new Exception();
						}
						return gtkcUmaHprxLmvXKJcYoPuryMLRi;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
				{
					jRzJiXTPaBEXcFicxEzwAjjelMBx = P_0;
					PCQWHGCENCFJKTSgkZphtFdMzevQ = P_0.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version;
					eAgHXcgBfisWHCAAghVXtThORluXB = 0;
					gtkcUmaHprxLmvXKJcYoPuryMLRi = default(TValue);
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
					if (PCQWHGCENCFJKTSgkZphtFdMzevQ != jRzJiXTPaBEXcFicxEzwAjjelMBx.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version)
					{
						throw new Exception();
					}
					if ((uint)eAgHXcgBfisWHCAAghVXtThORluXB < (uint)jRzJiXTPaBEXcFicxEzwAjjelMBx.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
					{
						gtkcUmaHprxLmvXKJcYoPuryMLRi = jRzJiXTPaBEXcFicxEzwAjjelMBx.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[eAgHXcgBfisWHCAAghVXtThORluXB].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
						eAgHXcgBfisWHCAAghVXtThORluXB++;
						return true;
					}
					eAgHXcgBfisWHCAAghVXtThORluXB = jRzJiXTPaBEXcFicxEzwAjjelMBx.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count + 1;
					gtkcUmaHprxLmvXKJcYoPuryMLRi = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (PCQWHGCENCFJKTSgkZphtFdMzevQ != jRzJiXTPaBEXcFicxEzwAjjelMBx.UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Version)
					{
						throw new Exception();
					}
					eAgHXcgBfisWHCAAghVXtThORluXB = 0;
					gtkcUmaHprxLmvXKJcYoPuryMLRi = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> icszYIDtIvxbAuINeHQExCJNreiU;

			int ICollection<TValue>.Count => icszYIDtIvxbAuINeHQExCJNreiU.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)icszYIDtIvxbAuINeHQExCJNreiU).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				icszYIDtIvxbAuINeHQExCJNreiU = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(icszYIDtIvxbAuINeHQExCJNreiU);
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
				if (array.Length - index < icszYIDtIvxbAuINeHQExCJNreiU.Count)
				{
					throw new Exception();
				}
				int count = icszYIDtIvxbAuINeHQExCJNreiU.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
				ACHatJGFhKGUxaPSJUCJWLwMBnpEA[] items = icszYIDtIvxbAuINeHQExCJNreiU.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items;
				for (int i = 0; i < count; i++)
				{
					array[index++] = items[i].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void STBjRdWaruiDPcpmWiRVEXFFjDxPA(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in STBjRdWaruiDPcpmWiRVEXFFjDxPA
				this.STBjRdWaruiDPcpmWiRVEXFFjDxPA(P_0);
			}

			private bool HuBajPsjQbOKcUPONGtymuSnYgWp(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in HuBajPsjQbOKcUPONGtymuSnYgWp
				return this.HuBajPsjQbOKcUPONGtymuSnYgWp(P_0);
			}

			private void BgXhObElaZqlZfnAHUCIAGCmLLkjA()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in BgXhObElaZqlZfnAHUCIAGCmLLkjA
				this.BgXhObElaZqlZfnAHUCIAGCmLLkjA();
			}

			private bool myyWNipJvUNqYhKbefdNIvAJawrDb(TValue P_0)
			{
				return icszYIDtIvxbAuINeHQExCJNreiU.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in myyWNipJvUNqYhKbefdNIvAJawrDb
				return this.myyWNipJvUNqYhKbefdNIvAJawrDb(P_0);
			}

			private IEnumerator<TValue> aCJcPmANnDGtCzdtVmefTRZEezvWA()
			{
				return new Enumerator(icszYIDtIvxbAuINeHQExCJNreiU);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in aCJcPmANnDGtCzdtVmefTRZEezvWA
				return this.aCJcPmANnDGtCzdtVmefTRZEezvWA();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(icszYIDtIvxbAuINeHQExCJNreiU);
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
				if (array.Length - index < icszYIDtIvxbAuINeHQExCJNreiU.Count)
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
				int count = icszYIDtIvxbAuINeHQExCJNreiU.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
				ACHatJGFhKGUxaPSJUCJWLwMBnpEA[] items = icszYIDtIvxbAuINeHQExCJNreiU.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items;
				try
				{
					for (int i = 0; i < count; i++)
					{
						array3[index++] = items[i].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private static readonly bool ZKufjiDbVVNVtXFZyktcztwFJxyz = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool rqalRiiFhcWYpYGeRrnlaxCLVXki = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> cxXSezDkCLApZxvRQEFrCXqqBPWyA = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> EIDcnqlqwthNCVObyGVwLNrxbNdA = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<ACHatJGFhKGUxaPSJUCJWLwMBnpEA> UlJgSBagjfTGFPzWzjmRvTWYhDxQA;

		private readonly ADictionary<TKey, int> qRuFMMljImhqaCAhhZYJhKiDewdP;

		private bool WXFidaEsdFiwcEkvgdMXydGvTFkq;

		int ICollection<KeyValuePair<TKey, TValue>>.Count => UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!WXFidaEsdFiwcEkvgdMXydGvTFkq)
				{
					return false;
				}
				return qRuFMMljImhqaCAhhZYJhKiDewdP._count < UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return WXFidaEsdFiwcEkvgdMXydGvTFkq;
			}
			set
			{
				if (WXFidaEsdFiwcEkvgdMXydGvTFkq != value)
				{
					WXFidaEsdFiwcEkvgdMXydGvTFkq = value;
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
				if ((uint)index >= (uint)UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[index].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
			}
			set
			{
				if ((uint)index >= (uint)UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[index].PtOGmmDeOtYBMXEzQJqyUICmmlbm = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return cxXSezDkCLApZxvRQEFrCXqqBPWyA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				cxXSezDkCLApZxvRQEFrCXqqBPWyA = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return EIDcnqlqwthNCVObyGVwLNrxbNdA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				EIDcnqlqwthNCVObyGVwLNrxbNdA = value;
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
				return UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
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

		bool ICollection.IsSynchronized => ((ICollection)UlJgSBagjfTGFPzWzjmRvTWYhDxQA).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)UlJgSBagjfTGFPzWzjmRvTWYhDxQA).SyncRoot;

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
			WXFidaEsdFiwcEkvgdMXydGvTFkq = P_1;
			UlJgSBagjfTGFPzWzjmRvTWYhDxQA = new AList<ACHatJGFhKGUxaPSJUCJWLwMBnpEA>(P_0);
			qRuFMMljImhqaCAhhZYJhKiDewdP = new ADictionary<TKey, int>(P_0);
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
				for (int i = 0; i < indexedDictionary.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count; i++)
				{
					Add(indexedDictionary.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA, indexedDictionary.UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].PtOGmmDeOtYBMXEzQJqyUICmmlbm);
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
			return UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[qRuFMMljImhqaCAhhZYJhKiDewdP[key]].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!qRuFMMljImhqaCAhhZYJhKiDewdP.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[value2].PtOGmmDeOtYBMXEzQJqyUICmmlbm;
			return true;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<ACHatJGFhKGUxaPSJUCJWLwMBnpEA, _003F>.ACHatJGFhKGUxaPSJUCJWLwMBnpEA>)(object)UlJgSBagjfTGFPzWzjmRvTWYhDxQA)[index].JjwcOhQJlFDCSYfMHZTrgennIqLA;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return ((AList<IndexedDictionary<ACHatJGFhKGUxaPSJUCJWLwMBnpEA, _003F>.ACHatJGFhKGUxaPSJUCJWLwMBnpEA>)(object)UlJgSBagjfTGFPzWzjmRvTWYhDxQA)[qRuFMMljImhqaCAhhZYJhKiDewdP[key]].hFGnEReCVNGJmvioZdAweTASvAct();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((AList<IndexedDictionary<ACHatJGFhKGUxaPSJUCJWLwMBnpEA, _003F>.ACHatJGFhKGUxaPSJUCJWLwMBnpEA>)(object)UlJgSBagjfTGFPzWzjmRvTWYhDxQA)[index].hFGnEReCVNGJmvioZdAweTASvAct();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!qRuFMMljImhqaCAhhZYJhKiDewdP.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = ((AList<IndexedDictionary<ACHatJGFhKGUxaPSJUCJWLwMBnpEA, _003F>.ACHatJGFhKGUxaPSJUCJWLwMBnpEA>)(object)UlJgSBagjfTGFPzWzjmRvTWYhDxQA)[value].hFGnEReCVNGJmvioZdAweTASvAct();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool num = qRuFMMljImhqaCAhhZYJhKiDewdP.ContainsKey(key);
			if (num && !WXFidaEsdFiwcEkvgdMXydGvTFkq)
			{
				TKey val = key;
				throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
			}
			int num2 = UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Add(new ACHatJGFhKGUxaPSJUCJWLwMBnpEA(key, value));
			if (num)
			{
				qRuFMMljImhqaCAhhZYJhKiDewdP[key] = num2;
			}
			else
			{
				qRuFMMljImhqaCAhhZYJhKiDewdP.Add(key, num2);
			}
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (qRuFMMljImhqaCAhhZYJhKiDewdP.TryGetValue(key, out var value2))
			{
				UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[value2].PtOGmmDeOtYBMXEzQJqyUICmmlbm = value;
				qRuFMMljImhqaCAhhZYJhKiDewdP[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			qRuFMMljImhqaCAhhZYJhKiDewdP.Remove(key);
			if (WXFidaEsdFiwcEkvgdMXydGvTFkq)
			{
				bool result = false;
				for (int num = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count - 1; num >= 0; num--)
				{
					if (cxXSezDkCLApZxvRQEFrCXqqBPWyA.Equals(UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num].JjwcOhQJlFDCSYfMHZTrgennIqLA, key))
					{
						UlJgSBagjfTGFPzWzjmRvTWYhDxQA.RemoveAt(num);
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
			if ((uint)index >= (uint)UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey jjwcOhQJlFDCSYfMHZTrgennIqLA = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[index].JjwcOhQJlFDCSYfMHZTrgennIqLA;
			if (index < UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count - 1)
			{
				for (int i = index + 1; i < ((AList<IndexedDictionary<ACHatJGFhKGUxaPSJUCJWLwMBnpEA, _003F>.ACHatJGFhKGUxaPSJUCJWLwMBnpEA>)(object)UlJgSBagjfTGFPzWzjmRvTWYhDxQA).Count; i++)
				{
					qRuFMMljImhqaCAhhZYJhKiDewdP[UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA] = i - 1;
				}
			}
			UlJgSBagjfTGFPzWzjmRvTWYhDxQA.RemoveAt(index);
			qRuFMMljImhqaCAhhZYJhKiDewdP.Remove(jjwcOhQJlFDCSYfMHZTrgennIqLA);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num >= 0)
			{
				_ = ref UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num];
				RemoveAt(num);
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			for (int num2 = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count - 1; num2 >= 0; num2--)
			{
				_ = ref UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num2];
				if (EIDcnqlqwthNCVObyGVwLNrxbNdA.Equals(UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num2].PtOGmmDeOtYBMXEzQJqyUICmmlbm, value))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public int IndexOfKey(TKey key)
		{
			if (!ZKufjiDbVVNVtXFZyktcztwFJxyz && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int count = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
			for (int i = 0; i < count; i++)
			{
				if (cxXSezDkCLApZxvRQEFrCXqqBPWyA.Equals(UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA, key))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int count = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
			for (int i = 0; i < count; i++)
			{
				if (EIDcnqlqwthNCVObyGVwLNrxbNdA.Equals(UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].PtOGmmDeOtYBMXEzQJqyUICmmlbm, value))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return qRuFMMljImhqaCAhhZYJhKiDewdP.ContainsKey(key);
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
			UlJgSBagjfTGFPzWzjmRvTWYhDxQA.Clear();
			qRuFMMljImhqaCAhhZYJhKiDewdP.Clear();
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
			UlJgSBagjfTGFPzWzjmRvTWYhDxQA.TrimExcess();
		}

		private void WNXvXmBygbwYuYGLMAWcJrycfToB(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WNXvXmBygbwYuYGLMAWcJrycfToB
			this.WNXvXmBygbwYuYGLMAWcJrycfToB(P_0);
		}

		private bool kuirExJLgsPFbWTrMQxoyZdfnLZH(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num < 0)
			{
				return false;
			}
			ACHatJGFhKGUxaPSJUCJWLwMBnpEA aCHatJGFhKGUxaPSJUCJWLwMBnpEA = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num];
			return EIDcnqlqwthNCVObyGVwLNrxbNdA.Equals(P_0.Value, aCHatJGFhKGUxaPSJUCJWLwMBnpEA.PtOGmmDeOtYBMXEzQJqyUICmmlbm);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kuirExJLgsPFbWTrMQxoyZdfnLZH
			return this.kuirExJLgsPFbWTrMQxoyZdfnLZH(P_0);
		}

		private void PkPiVlLGjNTnTxnGUjRDCgxYmWyaA(KeyValuePair<TKey, TValue>[] P_0, int P_1)
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
			int count = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1++] = new KeyValuePair<TKey, TValue>(UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA, UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].PtOGmmDeOtYBMXEzQJqyUICmmlbm);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PkPiVlLGjNTnTxnGUjRDCgxYmWyaA
			this.PkPiVlLGjNTnTxnGUjRDCgxYmWyaA(P_0, P_1);
		}

		private bool bsHdNKRvqUfLBzdyAzblCLLYKfsS(KeyValuePair<TKey, TValue> P_0)
		{
			if (WXFidaEsdFiwcEkvgdMXydGvTFkq)
			{
				bool result = false;
				for (int num = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count - 1; num >= 0; num--)
				{
					ACHatJGFhKGUxaPSJUCJWLwMBnpEA aCHatJGFhKGUxaPSJUCJWLwMBnpEA = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num];
					if (EIDcnqlqwthNCVObyGVwLNrxbNdA.Equals(P_0.Value, aCHatJGFhKGUxaPSJUCJWLwMBnpEA.PtOGmmDeOtYBMXEzQJqyUICmmlbm))
					{
						UlJgSBagjfTGFPzWzjmRvTWYhDxQA.RemoveAt(num);
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
			ACHatJGFhKGUxaPSJUCJWLwMBnpEA aCHatJGFhKGUxaPSJUCJWLwMBnpEA2 = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[num2];
			if (!EIDcnqlqwthNCVObyGVwLNrxbNdA.Equals(P_0.Value, aCHatJGFhKGUxaPSJUCJWLwMBnpEA2.PtOGmmDeOtYBMXEzQJqyUICmmlbm))
			{
				return false;
			}
			RemoveAt(num2);
			return true;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bsHdNKRvqUfLBzdyAzblCLLYKfsS
			return this.bsHdNKRvqUfLBzdyAzblCLLYKfsS(P_0);
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
			int count = UlJgSBagjfTGFPzWzjmRvTWYhDxQA._count;
			for (int i = 0; i < count; i++)
			{
				array.SetValue(new KeyValuePair<TKey, TValue>(UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].JjwcOhQJlFDCSYfMHZTrgennIqLA, UlJgSBagjfTGFPzWzjmRvTWYhDxQA._items[i].PtOGmmDeOtYBMXEzQJqyUICmmlbm), index++);
			}
		}

		private int cNxClfKNEBibBMYeyJjIkMSEFkwzA(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cNxClfKNEBibBMYeyJjIkMSEFkwzA
			return this.cNxClfKNEBibBMYeyJjIkMSEFkwzA(P_0);
		}

		private bool tGzGCuVFpgawUedFeXnaeYiRCUZCb(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tGzGCuVFpgawUedFeXnaeYiRCUZCb
			return this.tGzGCuVFpgawUedFeXnaeYiRCUZCb(P_0);
		}

		private int yDAbqPHbbPsNlwbpQzTAWaXVqYMc(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yDAbqPHbbPsNlwbpQzTAWaXVqYMc
			return this.yDAbqPHbbPsNlwbpQzTAWaXVqYMc(P_0);
		}

		private bool CvfCiiOoandYSByoDRxYvFONCtcK(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CvfCiiOoandYSByoDRxYvFONCtcK
			return this.CvfCiiOoandYSByoDRxYvFONCtcK(P_0);
		}
	}
}
