using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct QhxShecGseFoRffccNZQUnRDFJcM
		{
			public TKey HSNuvaOTnspQYeFIJlWQXPNTRvo;

			public TValue ZTonADnXjOPnKfCdZaXyKwbxjUQ;

			public QhxShecGseFoRffccNZQUnRDFJcM(TKey key, TValue value)
			{
				HSNuvaOTnspQYeFIJlWQXPNTRvo = key;
				ZTonADnXjOPnKfCdZaXyKwbxjUQ = value;
			}

			public KeyValuePair<TKey, TValue> NWysuifbftmkeJdqqrNIBpJimNL()
			{
				return new KeyValuePair<TKey, TValue>(HSNuvaOTnspQYeFIJlWQXPNTRvo, ZTonADnXjOPnKfCdZaXyKwbxjUQ);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			private int rYsophryboKqGVyVTsndxiQThpB;

			private int aCtihPxuRFLiowUoZPQdxLYTTal;

			private KeyValuePair<TKey, TValue> fSpdVoeWhOYoAilpUehbSxUxANDS;

			private int AyhVolgiIXJekWlilGCkjtGftMvS;

			public KeyValuePair<TKey, TValue> Current => fSpdVoeWhOYoAilpUehbSxUxANDS;

			object IEnumerator.Current
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						while (true)
						{
							int num = 231994917;
							while (true)
							{
								switch (num ^ 0xDD3F627)
								{
								case 4:
									break;
								case 1:
									goto IL_002e;
								case 3:
									goto end_IL_0008;
								case 2:
									goto IL_004b;
								default:
									return new DictionaryEntry(fSpdVoeWhOYoAilpUehbSxUxANDS.Key, fSpdVoeWhOYoAilpUehbSxUxANDS.Value);
								}
								break;
								IL_004b:
								int num2;
								if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1)
								{
									num = 231994918;
									num2 = num;
								}
								else
								{
									num = 231994916;
									num2 = num;
								}
								continue;
								IL_002e:
								if (AyhVolgiIXJekWlilGCkjtGftMvS == 1)
								{
									num = 231994919;
									continue;
								}
								return new KeyValuePair<TKey, TValue>(fSpdVoeWhOYoAilpUehbSxUxANDS.Key, fSpdVoeWhOYoAilpUehbSxUxANDS.Value);
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					throw new Exception();
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x207847A6 ^ 0x207847A7)
							{
							case 0:
								break;
							case 1:
								goto end_IL_0022;
							default:
								goto IL_004d;
							}
							continue;
							end_IL_0022:
							break;
						}
					}
					throw new Exception();
					IL_004d:
					return new DictionaryEntry(fSpdVoeWhOYoAilpUehbSxUxANDS.Key, fSpdVoeWhOYoAilpUehbSxUxANDS.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x17585448 ^ 0x17585449)
							{
							case 2:
								break;
							case 1:
								goto end_IL_0022;
							default:
								goto IL_004d;
							}
							continue;
							end_IL_0022:
							break;
						}
					}
					throw new Exception();
					IL_004d:
					return fSpdVoeWhOYoAilpUehbSxUxANDS.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						while (true)
						{
							int num = -2049430094;
							while (true)
							{
								switch (num ^ -2049430093)
								{
								case 3:
									break;
								case 1:
									goto IL_002a;
								case 0:
									goto end_IL_0008;
								default:
									return fSpdVoeWhOYoAilpUehbSxUxANDS.Value;
								}
								break;
								IL_002a:
								int num2;
								if (aCtihPxuRFLiowUoZPQdxLYTTal == ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1)
								{
									num = -2049430093;
									num2 = num;
								}
								else
								{
									num = -2049430095;
									num2 = num;
								}
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					throw new Exception();
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
				rYsophryboKqGVyVTsndxiQThpB = dictionary.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version;
				aCtihPxuRFLiowUoZPQdxLYTTal = 0;
				AyhVolgiIXJekWlilGCkjtGftMvS = getEnumeratorRetType;
				fSpdVoeWhOYoAilpUehbSxUxANDS = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version)
				{
					throw new Exception();
				}
				while (true)
				{
					int num;
					if ((uint)aCtihPxuRFLiowUoZPQdxLYTTal < (uint)ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
					{
						num = -943237884;
					}
					else
					{
						aCtihPxuRFLiowUoZPQdxLYTTal = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1;
						num = -943237883;
					}
					while (true)
					{
						switch (num ^ -943237881)
						{
						case 0:
							goto IL_001e;
						case 1:
							break;
						case 3:
							fSpdVoeWhOYoAilpUehbSxUxANDS = new KeyValuePair<TKey, TValue>(ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items[aCtihPxuRFLiowUoZPQdxLYTTal].HSNuvaOTnspQYeFIJlWQXPNTRvo, ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items[aCtihPxuRFLiowUoZPQdxLYTTal].ZTonADnXjOPnKfCdZaXyKwbxjUQ);
							aCtihPxuRFLiowUoZPQdxLYTTal++;
							return true;
						default:
							fSpdVoeWhOYoAilpUehbSxUxANDS = default(KeyValuePair<TKey, TValue>);
							return false;
						}
						break;
						IL_001e:
						num = -943237882;
					}
				}
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version)
				{
					throw new Exception();
				}
				while (true)
				{
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					int num = -192393408;
					while (true)
					{
						switch (num ^ -192393405)
						{
						case 2:
							num = -192393406;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							fSpdVoeWhOYoAilpUehbSxUxANDS = default(KeyValuePair<TKey, TValue>);
							num = -192393405;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private IndexedDictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

				private int aCtihPxuRFLiowUoZPQdxLYTTal;

				private int rYsophryboKqGVyVTsndxiQThpB;

				private TKey zmSGmgunsjDgmfrGnNSKrgWvnmM;

				public TKey Current => zmSGmgunsjDgmfrGnNSKrgWvnmM;

				object IEnumerator.Current
				{
					get
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
						{
							if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1)
							{
								goto IL_004d;
							}
							while (true)
							{
								switch (-1822930109 ^ -1822930111)
								{
								case 0:
									break;
								case 2:
									goto end_IL_0022;
								default:
									goto IL_004d;
								}
								continue;
								end_IL_0022:
								break;
							}
						}
						throw new Exception();
						IL_004d:
						return zmSGmgunsjDgmfrGnNSKrgWvnmM;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
					rYsophryboKqGVyVTsndxiQThpB = dictionary.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version;
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					zmSGmgunsjDgmfrGnNSKrgWvnmM = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version)
					{
						throw new Exception();
					}
					while ((uint)aCtihPxuRFLiowUoZPQdxLYTTal < (uint)ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
					{
						zmSGmgunsjDgmfrGnNSKrgWvnmM = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items[aCtihPxuRFLiowUoZPQdxLYTTal].HSNuvaOTnspQYeFIJlWQXPNTRvo;
						int num = -1047033193;
						while (true)
						{
							switch (num ^ -1047033193)
							{
							case 3:
								num = -1047033194;
								continue;
							case 1:
								break;
							case 0:
								aCtihPxuRFLiowUoZPQdxLYTTal++;
								num = -1047033195;
								continue;
							default:
								return true;
							}
							break;
						}
					}
					aCtihPxuRFLiowUoZPQdxLYTTal = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1;
					zmSGmgunsjDgmfrGnNSKrgWvnmM = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version)
					{
						throw new Exception();
					}
					while (true)
					{
						aCtihPxuRFLiowUoZPQdxLYTTal = 0;
						int num = 315016662;
						while (true)
						{
							switch (num ^ 0x12C6C5D6)
							{
							case 2:
								goto IL_001e;
							case 1:
								break;
							default:
								zmSGmgunsjDgmfrGnNSKrgWvnmM = default(TKey);
								return;
							}
							break;
							IL_001e:
							num = 315016663;
						}
					}
				}
			}

			private IndexedDictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			public int Count => ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)ZXmCvDfLDDrtmgBgFDRMaBCKoyr).SyncRoot;

			public KeyCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(ZXmCvDfLDDrtmgBgFDRMaBCKoyr);
			}

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				int count = default(int);
				QhxShecGseFoRffccNZQUnRDFJcM[] items = default(QhxShecGseFoRffccNZQUnRDFJcM[]);
				int num3 = default(int);
				while (true)
				{
					if (index >= 0)
					{
						int num;
						int num2;
						if (index > array.Length)
						{
							num = -1805838172;
							num2 = num;
						}
						else
						{
							num = -1805838176;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1805838172)
							{
							case 2:
								num = -1805838164;
								continue;
							case 7:
								count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
								items = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items;
								num = -1805838175;
								continue;
							case 5:
								num3 = 0;
								num = -1805838169;
								continue;
							case 8:
								break;
							case 6:
								throw new Exception();
							case 1:
								array[index++] = items[num3].HSNuvaOTnspQYeFIJlWQXPNTRvo;
								num3++;
								num = -1805838169;
								continue;
							case 0:
								goto IL_00cd;
							case 4:
								goto IL_00e2;
							default:
								if (num3 >= count)
								{
									return;
								}
								goto case 1;
							}
							break;
							IL_00e2:
							int num4;
							if (array.Length - index >= ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
							{
								num = -1805838173;
								num4 = num;
							}
							else
							{
								num = -1805838174;
								num4 = num;
							}
						}
						continue;
					}
					goto IL_00cd;
					IL_00cd:
					throw new ArgumentOutOfRangeException("index");
				}
			}

			void ICollection<TKey>.Add(TKey item)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Contains(TKey item)
			{
				return ZXmCvDfLDDrtmgBgFDRMaBCKoyr.ContainsKey(item);
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(ZXmCvDfLDDrtmgBgFDRMaBCKoyr);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(ZXmCvDfLDDrtmgBgFDRMaBCKoyr);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				TKey[] array3 = default(TKey[]);
				object[] array2 = default(object[]);
				while (true)
				{
					int num;
					int num2;
					if (array.Rank == 1)
					{
						num = 1258026373;
						num2 = num;
					}
					else
					{
						num = 1258026380;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x4AFBF58C)
						{
						case 8:
							num = 1258026370;
							continue;
						case 7:
							throw new Exception();
						case 5:
							if (index >= 0)
							{
								int num7;
								if (index <= array.Length)
								{
									num = 1258026374;
									num7 = num;
								}
								else
								{
									num = 1258026378;
									num7 = num;
								}
								continue;
							}
							goto case 6;
						case 14:
							break;
						case 3:
							CopyTo(array3, index);
							num = 1258026382;
							continue;
						case 2:
							return;
						case 12:
							array3 = array as TKey[];
							num = 1258026376;
							continue;
						case 6:
							throw new Exception();
						case 9:
						{
							int num8;
							if (array.GetLowerBound(0) != 0)
							{
								num = 1258026379;
								num8 = num;
							}
							else
							{
								num = 1258026377;
								num8 = num;
							}
							continue;
						}
						case 13:
							throw new Exception();
						case 10:
						{
							int num6;
							if (array.Length - index >= ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
							{
								num = 1258026368;
								num6 = num;
							}
							else
							{
								num = 1258026369;
								num6 = num;
							}
							continue;
						}
						case 4:
						{
							int num5;
							if (array3 != null)
							{
								num = 1258026383;
								num5 = num;
							}
							else
							{
								num = 1258026375;
								num5 = num;
							}
							continue;
						}
						case 0:
							throw new Exception();
						case 11:
							array2 = array as object[];
							if (array2 == null)
							{
								throw new Exception();
							}
							goto default;
						default:
						{
							int count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
							QhxShecGseFoRffccNZQUnRDFJcM[] items = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items;
							try
							{
								int num3 = 0;
								while (num3 < count)
								{
									while (true)
									{
										array2[index++] = items[num3].HSNuvaOTnspQYeFIJlWQXPNTRvo;
										num3++;
										int num4 = 1258026380;
										while (true)
										{
											switch (num4 ^ 0x4AFBF58C)
											{
											case 2:
												num4 = 1258026381;
												continue;
											case 1:
												break;
											default:
												goto end_IL_01c4;
											}
											break;
										}
										continue;
										end_IL_01c4:
										break;
									}
								}
								return;
							}
							catch (ArrayTypeMismatchException)
							{
								throw new Exception();
							}
						}
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private IndexedDictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

				private int aCtihPxuRFLiowUoZPQdxLYTTal;

				private int rYsophryboKqGVyVTsndxiQThpB;

				private TValue akOsXqJjhjXkUanTgiMMPHmlVNV;

				public TValue Current => akOsXqJjhjXkUanTgiMMPHmlVNV;

				object IEnumerator.Current
				{
					get
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
						{
							if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1)
							{
								goto IL_004d;
							}
							while (true)
							{
								switch (0x124F802F ^ 0x124F802D)
								{
								case 0:
									break;
								case 2:
									goto end_IL_0022;
								default:
									goto IL_004d;
								}
								continue;
								end_IL_0022:
								break;
							}
						}
						throw new Exception();
						IL_004d:
						return akOsXqJjhjXkUanTgiMMPHmlVNV;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
					rYsophryboKqGVyVTsndxiQThpB = dictionary.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version;
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					akOsXqJjhjXkUanTgiMMPHmlVNV = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version)
					{
						goto IL_0018;
					}
					goto IL_004e;
					IL_0018:
					int num = 1948797174;
					goto IL_001d;
					IL_001d:
					switch (num ^ 0x742848F4)
					{
					case 0:
						break;
					case 2:
						throw new Exception();
					case 4:
						goto IL_004e;
					case 1:
						akOsXqJjhjXkUanTgiMMPHmlVNV = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items[aCtihPxuRFLiowUoZPQdxLYTTal].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
						aCtihPxuRFLiowUoZPQdxLYTTal++;
						return true;
					default:
						return false;
					}
					goto IL_0018;
					IL_004e:
					if ((uint)aCtihPxuRFLiowUoZPQdxLYTTal < (uint)ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
					{
						num = 1948797173;
					}
					else
					{
						aCtihPxuRFLiowUoZPQdxLYTTal = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count + 1;
						akOsXqJjhjXkUanTgiMMPHmlVNV = default(TValue);
						num = 1948797175;
					}
					goto IL_001d;
				}

				void IEnumerator.Reset()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN.Version)
					{
						throw new Exception();
					}
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					akOsXqJjhjXkUanTgiMMPHmlVNV = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			public int Count => ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)ZXmCvDfLDDrtmgBgFDRMaBCKoyr).SyncRoot;

			public ValueCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(ZXmCvDfLDDrtmgBgFDRMaBCKoyr);
			}

			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				QhxShecGseFoRffccNZQUnRDFJcM[] items = default(QhxShecGseFoRffccNZQUnRDFJcM[]);
				int num3 = default(int);
				int count = default(int);
				while (true)
				{
					IL_00cd:
					if (index >= 0)
					{
						int num;
						int num2;
						if (index <= array.Length)
						{
							num = 1999216928;
							num2 = num;
						}
						else
						{
							num = 1999216931;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x7729A121)
							{
							case 5:
								num = 1999216935;
								continue;
							case 0:
								num = 1999216934;
								continue;
							case 2:
								break;
							case 3:
								array[index++] = items[num3].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
								num3++;
								num = 1999216934;
								continue;
							case 4:
								count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
								items = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items;
								num3 = 0;
								num = 1999216929;
								continue;
							case 1:
								if (array.Length - index < ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
								{
									throw new Exception();
								}
								goto case 4;
							case 6:
								goto IL_00cd;
							default:
								if (num3 >= count)
								{
									return;
								}
								goto case 3;
							}
							break;
						}
					}
					throw new Exception();
				}
			}

			void ICollection<TValue>.Add(TValue item)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue item)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Contains(TValue item)
			{
				return ZXmCvDfLDDrtmgBgFDRMaBCKoyr.ContainsValue(item);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(ZXmCvDfLDDrtmgBgFDRMaBCKoyr);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(ZXmCvDfLDDrtmgBgFDRMaBCKoyr);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					goto IL_0006;
				}
				goto IL_009a;
				IL_0006:
				int num = -749316870;
				goto IL_000b;
				IL_000b:
				object[] array3 = default(object[]);
				while (true)
				{
					switch (num ^ -749316869)
					{
					case 2:
						break;
					case 6:
						return;
					case 11:
						throw new Exception();
					case 9:
						if (index >= 0)
						{
							goto IL_0067;
						}
						goto case 8;
					case 4:
						if (array.GetLowerBound(0) != 0)
						{
							throw new Exception();
						}
						goto case 9;
					case 7:
						goto IL_009a;
					case 10:
						array3 = array as object[];
						if (array3 == null)
						{
							throw new Exception();
						}
						goto default;
					case 3:
						if (array.Length - index < ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
						{
							throw new Exception();
						}
						goto case 0;
					case 8:
						throw new Exception();
					case 0:
						if (array is TValue[] array2)
						{
							CopyTo(array2, index);
							num = -749316867;
							continue;
						}
						goto case 10;
					case 1:
						throw new ArgumentNullException("array");
					default:
					{
						int count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
						QhxShecGseFoRffccNZQUnRDFJcM[] items = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.AzgbkpBsuARdvmLsMFAITmLDyAKN._items;
						try
						{
							int num2 = 0;
							while (true)
							{
								int num3 = -749316870;
								while (true)
								{
									switch (num3 ^ -749316869)
									{
									case 0:
										break;
									case 1:
										num3 = -749316871;
										continue;
									case 3:
										array3[index++] = items[num2].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
										num2++;
										num3 = -749316871;
										continue;
									default:
										if (num2 >= count)
										{
											return;
										}
										goto case 3;
									}
									break;
								}
							}
						}
						catch (ArrayTypeMismatchException)
						{
							throw new Exception();
						}
					}
					}
					break;
					IL_0067:
					int num4;
					if (index > array.Length)
					{
						num = -749316877;
						num4 = num;
					}
					else
					{
						num = -749316872;
						num4 = num;
					}
				}
				goto IL_0006;
				IL_009a:
				int num5;
				if (array.Rank == 1)
				{
					num = -749316865;
					num5 = num;
				}
				else
				{
					num = -749316880;
					num5 = num;
				}
				goto IL_000b;
			}
		}

		private static readonly bool MrkXHlQCvMAquqwgKuxhveelbzd = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool iGIDmwHIPONsdyKEecwUpHbWJERp = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> GcxxwMSnKhQJjkeyqdiHIMlJtaEh = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> qcNUiXcHrkXMpAhltjKBTwcPAmj = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<QhxShecGseFoRffccNZQUnRDFJcM> AzgbkpBsuARdvmLsMFAITmLDyAKN;

		private readonly ADictionary<TKey, int> kFwgwoTTVNcOmJSMUEnekhTpWfMt;

		private bool FCHxQuvmKaVZYsoOJxlalwOWlKI;

		public int Count => AzgbkpBsuARdvmLsMFAITmLDyAKN._count;

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!FCHxQuvmKaVZYsoOJxlalwOWlKI)
				{
					return false;
				}
				return kFwgwoTTVNcOmJSMUEnekhTpWfMt._count < AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return FCHxQuvmKaVZYsoOJxlalwOWlKI;
			}
			set
			{
				if (FCHxQuvmKaVZYsoOJxlalwOWlKI == value)
				{
					while (true)
					{
						switch (-1828565654 ^ -1828565653)
						{
						case 2:
							continue;
						default:
							return;
						case 1:
							return;
						case 0:
							break;
						case 3:
							return;
						}
						break;
					}
				}
				FCHxQuvmKaVZYsoOJxlalwOWlKI = value;
				if (!value && ContainsDuplicateKeys)
				{
					throw new Exception("The dictionary contains duplicate keys and cannot be changed unless the keys are removed.");
				}
			}
		}

		public TValue this[int index]
		{
			get
			{
				if ((uint)index >= (uint)AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return AzgbkpBsuARdvmLsMFAITmLDyAKN._items[index].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
			}
			set
			{
				if ((uint)index >= (uint)AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				AzgbkpBsuARdvmLsMFAITmLDyAKN._items[index].ZTonADnXjOPnKfCdZaXyKwbxjUQ = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return GcxxwMSnKhQJjkeyqdiHIMlJtaEh;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				GcxxwMSnKhQJjkeyqdiHIMlJtaEh = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return qcNUiXcHrkXMpAhltjKBTwcPAmj;
			}
			set
			{
				if (value == null)
				{
					while (true)
					{
						int num = 1485313758;
						while (true)
						{
							switch (num ^ 0x588816DF)
							{
							case 2:
								break;
							case 1:
								value = EqualityComparerNoAlloc<TValue>.Default;
								num = 1485313759;
								continue;
							default:
								goto end_IL_0003;
							}
							break;
						}
						continue;
						end_IL_0003:
						break;
					}
				}
				qcNUiXcHrkXMpAhltjKBTwcPAmj = value;
			}
		}

		public ICollection<TKey> Keys => new KeyCollection(this);

		public ICollection<TValue> Values => new ValueCollection(this);

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					while (true)
					{
						switch (-224363254 ^ -224363253)
						{
						case 2:
							continue;
						case 1:
							throw new KeyNotFoundException(string.Concat("Key \"", key, "\" does not exist."));
						}
						break;
					}
				}
				return AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
			}
			set
			{
				SetValue(key, value);
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

		bool ICollection.IsSynchronized => ((ICollection)AzgbkpBsuARdvmLsMFAITmLDyAKN).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)AzgbkpBsuARdvmLsMFAITmLDyAKN).SyncRoot;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int index] => this[index];

		int IReadOnlyList.Count => Count;

		object IReadOnlyList.this[int index] => this[index];

		public IndexedDictionary()
			: this(0, false)
		{
		}

		public IndexedDictionary(int capacity)
			: this(capacity, false)
		{
		}

		public IndexedDictionary(bool allowDuplicateKeys)
			: this(0, allowDuplicateKeys)
		{
		}

		public IndexedDictionary(int capacity, bool allowDuplicateKeys)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			FCHxQuvmKaVZYsoOJxlalwOWlKI = allowDuplicateKeys;
			AzgbkpBsuARdvmLsMFAITmLDyAKN = new AList<QhxShecGseFoRffccNZQUnRDFJcM>(capacity);
			kFwgwoTTVNcOmJSMUEnekhTpWfMt = new ADictionary<TKey, int>(capacity);
		}

		public IndexedDictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, false)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> dictionary, bool allowDuplicateKeys)
			: this(0, allowDuplicateKeys)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (ReflectionTools.DoesTypeImplement(dictionary.GetType(), typeof(IndexedDictionary<TKey, TValue>)))
			{
				IndexedDictionary<TKey, TValue> indexedDictionary = (IndexedDictionary<TKey, TValue>)dictionary;
				for (int i = 0; i < indexedDictionary.AzgbkpBsuARdvmLsMFAITmLDyAKN._count; i++)
				{
					Add(indexedDictionary.AzgbkpBsuARdvmLsMFAITmLDyAKN._items[i].HSNuvaOTnspQYeFIJlWQXPNTRvo, indexedDictionary.AzgbkpBsuARdvmLsMFAITmLDyAKN._items[i].ZTonADnXjOPnKfCdZaXyKwbxjUQ);
				}
				return;
			}
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
		}

		public TValue GetValue(TKey key)
		{
			return AzgbkpBsuARdvmLsMFAITmLDyAKN._items[kFwgwoTTVNcOmJSMUEnekhTpWfMt[key]].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!kFwgwoTTVNcOmJSMUEnekhTpWfMt.TryGetValue(key, out var value2))
			{
				value = default(TValue);
				return false;
			}
			value = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[value2].ZTonADnXjOPnKfCdZaXyKwbxjUQ;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return AzgbkpBsuARdvmLsMFAITmLDyAKN[index].HSNuvaOTnspQYeFIJlWQXPNTRvo;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return AzgbkpBsuARdvmLsMFAITmLDyAKN[kFwgwoTTVNcOmJSMUEnekhTpWfMt[key]].NWysuifbftmkeJdqqrNIBpJimNL();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return AzgbkpBsuARdvmLsMFAITmLDyAKN[index].NWysuifbftmkeJdqqrNIBpJimNL();
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			if (!kFwgwoTTVNcOmJSMUEnekhTpWfMt.TryGetValue(key, out var value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = AzgbkpBsuARdvmLsMFAITmLDyAKN[value].NWysuifbftmkeJdqqrNIBpJimNL();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool flag = kFwgwoTTVNcOmJSMUEnekhTpWfMt.ContainsKey(key);
			int value2 = default(int);
			while (true)
			{
				switch (-1257053248 ^ -1257053245)
				{
				case 2:
					continue;
				case 3:
					if (flag && !FCHxQuvmKaVZYsoOJxlalwOWlKI)
					{
						throw new ArgumentException(string.Concat("Key \"", key, "\" is already in use."));
					}
					goto case 0;
				case 0:
					value2 = AzgbkpBsuARdvmLsMFAITmLDyAKN.Add(new QhxShecGseFoRffccNZQUnRDFJcM(key, value));
					if (flag)
					{
						kFwgwoTTVNcOmJSMUEnekhTpWfMt[key] = value2;
						return;
					}
					break;
				}
				break;
			}
			kFwgwoTTVNcOmJSMUEnekhTpWfMt.Add(key, value2);
		}

		public void SetValue(TKey key, TValue value)
		{
			if (kFwgwoTTVNcOmJSMUEnekhTpWfMt.TryGetValue(key, out var value2))
			{
				AzgbkpBsuARdvmLsMFAITmLDyAKN._items[value2].ZTonADnXjOPnKfCdZaXyKwbxjUQ = value;
				while (true)
				{
					switch (0x1E2F3E64 ^ 0x1E2F3E65)
					{
					case 2:
						continue;
					case 1:
						kFwgwoTTVNcOmJSMUEnekhTpWfMt[key] = value2;
						return;
					}
					break;
				}
			}
			Add(key, value);
		}

		public bool Remove(TKey key)
		{
			kFwgwoTTVNcOmJSMUEnekhTpWfMt.Remove(key);
			if (FCHxQuvmKaVZYsoOJxlalwOWlKI)
			{
				bool result = false;
				int num = AzgbkpBsuARdvmLsMFAITmLDyAKN._count - 1;
				while (true)
				{
					int num2 = -1547420910;
					while (true)
					{
						switch (num2 ^ -1547420909)
						{
						case 3:
							break;
						case 2:
							num--;
							num2 = -1547420909;
							continue;
						case 5:
							if (GcxxwMSnKhQJjkeyqdiHIMlJtaEh.Equals(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num].HSNuvaOTnspQYeFIJlWQXPNTRvo, key))
							{
								AzgbkpBsuARdvmLsMFAITmLDyAKN.RemoveAt(num);
								num2 = -1547420905;
								continue;
							}
							goto case 2;
						case 1:
							num2 = -1547420909;
							continue;
						case 4:
							result = true;
							num2 = -1547420911;
							continue;
						default:
							if (num < 0)
							{
								return result;
							}
							goto case 5;
						}
						break;
					}
				}
			}
			int num3 = IndexOfKey(key);
			if (num3 < 0)
			{
				return false;
			}
			RemoveAt(num3);
			return true;
		}

		public void RemoveAt(int index)
		{
			if ((uint)index >= (uint)AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey hSNuvaOTnspQYeFIJlWQXPNTRvo;
			while (true)
			{
				hSNuvaOTnspQYeFIJlWQXPNTRvo = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[index].HSNuvaOTnspQYeFIJlWQXPNTRvo;
				if (index >= AzgbkpBsuARdvmLsMFAITmLDyAKN._count - 1)
				{
					break;
				}
				int num = index + 1;
				int num2 = 135314212;
				while (true)
				{
					switch (num2 ^ 0x810BB25)
					{
					case 2:
						num2 = 135314209;
						continue;
					case 4:
						break;
					case 1:
						goto IL_0078;
					case 3:
						num++;
						num2 = 135314212;
						continue;
					case 5:
						kFwgwoTTVNcOmJSMUEnekhTpWfMt[AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num].HSNuvaOTnspQYeFIJlWQXPNTRvo] = num - 1;
						num2 = 135314214;
						continue;
					default:
						goto end_IL_0046;
					}
					break;
					IL_0078:
					int num3;
					if (num >= AzgbkpBsuARdvmLsMFAITmLDyAKN.Count)
					{
						num2 = 135314213;
						num3 = num2;
					}
					else
					{
						num2 = 135314208;
						num3 = num2;
					}
				}
				continue;
				end_IL_0046:
				break;
			}
			AzgbkpBsuARdvmLsMFAITmLDyAKN.RemoveAt(index);
			kFwgwoTTVNcOmJSMUEnekhTpWfMt.Remove(hSNuvaOTnspQYeFIJlWQXPNTRvo);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			while (true)
			{
				int num2 = 951857472;
				while (true)
				{
					switch (num2 ^ 0x38BC3141)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (num < 0)
						{
							return;
						}
						goto case 2;
					case 2:
						_ = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num].HSNuvaOTnspQYeFIJlWQXPNTRvo;
						RemoveAt(num);
						num2 = 951857474;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			int count = AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
			int num3 = default(int);
			while (true)
			{
				int num2 = -930627724;
				while (true)
				{
					switch (num2 ^ -930627725)
					{
					case 6:
						break;
					case 2:
						num3--;
						num2 = -930627721;
						continue;
					case 5:
					{
						_ = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num3].HSNuvaOTnspQYeFIJlWQXPNTRvo;
						int num5;
						if (qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num3].ZTonADnXjOPnKfCdZaXyKwbxjUQ, value))
						{
							num2 = -930627728;
							num5 = num2;
						}
						else
						{
							num2 = -930627727;
							num5 = num2;
						}
						continue;
					}
					case 4:
					{
						int num4;
						if (num3 < 0)
						{
							num2 = -930627726;
							num4 = num2;
						}
						else
						{
							num2 = -930627722;
							num4 = num2;
						}
						continue;
					}
					case 0:
						num2 = -930627721;
						continue;
					case 7:
						num3 = count - 1;
						num2 = -930627725;
						continue;
					case 3:
						RemoveAt(num3);
						num++;
						num2 = -930627727;
						continue;
					default:
						return num;
					}
					break;
				}
			}
		}

		public int IndexOfKey(TKey key)
		{
			if (!MrkXHlQCvMAquqwgKuxhveelbzd && key == null)
			{
				throw new ArgumentNullException("key");
			}
			while (true)
			{
				int count = AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
				int num = 0;
				int num2 = 1992141741;
				while (true)
				{
					switch (num2 ^ 0x76BDABAE)
					{
					case 0:
						num2 = 1992141740;
						continue;
					case 2:
						break;
					case 1:
						if (GcxxwMSnKhQJjkeyqdiHIMlJtaEh.Equals(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num].HSNuvaOTnspQYeFIJlWQXPNTRvo, key))
						{
							return num;
						}
						num++;
						num2 = 1992141741;
						continue;
					default:
						if (num >= count)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public int IndexOfValue(TValue value)
		{
			int count = AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
			int num = 0;
			while (true)
			{
				int num2 = -1533384855;
				while (true)
				{
					switch (num2 ^ -1533384854)
					{
					case 0:
						break;
					case 3:
						num2 = -1533384856;
						continue;
					case 1:
						if (qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num].ZTonADnXjOPnKfCdZaXyKwbxjUQ, value))
						{
							return num;
						}
						num++;
						num2 = -1533384856;
						continue;
					default:
						if (num >= count)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool ContainsKey(TKey key)
		{
			return kFwgwoTTVNcOmJSMUEnekhTpWfMt.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			AzgbkpBsuARdvmLsMFAITmLDyAKN.Clear();
			kFwgwoTTVNcOmJSMUEnekhTpWfMt.Clear();
		}

		public void TrimExcess()
		{
			AzgbkpBsuARdvmLsMFAITmLDyAKN.TrimExcess();
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			int num = IndexOfKey(item.Key);
			if (num < 0)
			{
				goto IL_0012;
			}
			QhxShecGseFoRffccNZQUnRDFJcM qhxShecGseFoRffccNZQUnRDFJcM = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num];
			int num2 = -28541930;
			goto IL_0017;
			IL_0017:
			switch (num2 ^ -28541930)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(item.Value, qhxShecGseFoRffccNZQUnRDFJcM.ZTonADnXjOPnKfCdZaXyKwbxjUQ);
			}
			goto IL_0012;
			IL_0012:
			num2 = -28541929;
			goto IL_0017;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				if (index >= 0)
				{
					int num;
					int num2;
					if (index > array.Length)
					{
						num = 1508468216;
						num2 = num;
					}
					else
					{
						num = 1508468221;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x59E965FB)
						{
						case 2:
							num = 1508468218;
							continue;
						case 1:
							break;
						case 6:
							if (array.Length - index < Count)
							{
								throw new Exception();
							}
							goto case 4;
						case 3:
							goto IL_0074;
						case 5:
						{
							ref KeyValuePair<TKey, TValue> reference = ref array[index++];
							reference = new KeyValuePair<TKey, TValue>(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num3].HSNuvaOTnspQYeFIJlWQXPNTRvo, AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num3].ZTonADnXjOPnKfCdZaXyKwbxjUQ);
							num3++;
							num = 1508468219;
							continue;
						}
						case 4:
							count = AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
							num3 = 0;
							num = 1508468219;
							continue;
						default:
							if (num3 >= count)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
					continue;
				}
				goto IL_0074;
				IL_0074:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			bool result = default(bool);
			int num = default(int);
			if (FCHxQuvmKaVZYsoOJxlalwOWlKI)
			{
				result = false;
				num = AzgbkpBsuARdvmLsMFAITmLDyAKN._count - 1;
				goto IL_00b1;
			}
			int num2 = IndexOfKey(item.Key);
			int num3 = -1203397930;
			goto IL_0025;
			IL_0025:
			QhxShecGseFoRffccNZQUnRDFJcM qhxShecGseFoRffccNZQUnRDFJcM = default(QhxShecGseFoRffccNZQUnRDFJcM);
			QhxShecGseFoRffccNZQUnRDFJcM qhxShecGseFoRffccNZQUnRDFJcM2 = default(QhxShecGseFoRffccNZQUnRDFJcM);
			while (true)
			{
				switch (num3 ^ -1203397932)
				{
				case 5:
					num3 = -1203397934;
					continue;
				case 3:
					break;
				case 8:
					num--;
					num3 = -1203397932;
					continue;
				case 2:
					goto IL_0089;
				case 0:
					goto end_IL_0025;
				case 4:
					goto IL_00cf;
				case 6:
					goto IL_00fe;
				case 7:
					AzgbkpBsuARdvmLsMFAITmLDyAKN.RemoveAt(num);
					result = true;
					num3 = -1203397924;
					continue;
				default:
					return false;
				}
				if (!qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(item.Value, qhxShecGseFoRffccNZQUnRDFJcM.ZTonADnXjOPnKfCdZaXyKwbxjUQ))
				{
					num3 = -1203397931;
					continue;
				}
				RemoveAt(num2);
				return true;
				IL_00cf:
				int num4;
				if (qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(item.Value, qhxShecGseFoRffccNZQUnRDFJcM2.ZTonADnXjOPnKfCdZaXyKwbxjUQ))
				{
					num3 = -1203397933;
					num4 = num3;
				}
				else
				{
					num3 = -1203397924;
					num4 = num3;
				}
				continue;
				IL_0089:
				if (num2 < 0)
				{
					return false;
				}
				qhxShecGseFoRffccNZQUnRDFJcM = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num2];
				num3 = -1203397929;
				continue;
				end_IL_0025:
				break;
			}
			goto IL_00b1;
			IL_00fe:
			qhxShecGseFoRffccNZQUnRDFJcM2 = AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num];
			num3 = -1203397936;
			goto IL_0025;
			IL_00b1:
			if (num < 0)
			{
				return result;
			}
			goto IL_00fe;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Enumerator(this, 1);
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
				goto IL_0003;
			}
			goto IL_005a;
			IL_0003:
			int num = -1454455680;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ -1454455669)
				{
				case 0:
					break;
				case 11:
					throw new ArgumentNullException("array");
				case 1:
					goto IL_005a;
				case 5:
					goto IL_006f;
				case 4:
					array.SetValue(new KeyValuePair<TKey, TValue>(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num2].HSNuvaOTnspQYeFIJlWQXPNTRvo, AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num2].ZTonADnXjOPnKfCdZaXyKwbxjUQ), index++);
					num = -1454455679;
					continue;
				case 2:
					throw new ArgumentOutOfRangeException("index");
				case 3:
					throw new Exception();
				case 9:
					count = AzgbkpBsuARdvmLsMFAITmLDyAKN._count;
					num = -1454455677;
					continue;
				case 7:
					goto IL_011a;
				case 10:
					num2++;
					num = -1454455667;
					continue;
				case 8:
					num2 = 0;
					num = -1454455667;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 4;
				}
				break;
				IL_011a:
				int num3;
				if (index > array.Length)
				{
					num = -1454455671;
					num3 = num;
				}
				else
				{
					num = -1454455666;
					num3 = num;
				}
				continue;
				IL_006f:
				int num4;
				if (array.Length - index >= Count)
				{
					num = -1454455678;
					num4 = num;
				}
				else
				{
					num = -1454455672;
					num4 = num;
				}
			}
			goto IL_0003;
			IL_005a:
			int num5;
			if (index < 0)
			{
				num = -1454455671;
				num5 = num;
			}
			else
			{
				num = -1454455668;
				num5 = num;
			}
			goto IL_0008;
		}

		private int PeijmCtYFeAqwqGenwRmSxqKtIV(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PeijmCtYFeAqwqGenwRmSxqKtIV
			return this.PeijmCtYFeAqwqGenwRmSxqKtIV(P_0);
		}

		private bool oAMOLPciwbfCUagBDcmRlmnHpXL(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in oAMOLPciwbfCUagBDcmRlmnHpXL
			return this.oAMOLPciwbfCUagBDcmRlmnHpXL(P_0);
		}

		private int nwxmwnDbEMclpUOQSACBaRDJafWU(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nwxmwnDbEMclpUOQSACBaRDJafWU
			return this.nwxmwnDbEMclpUOQSACBaRDJafWU(P_0);
		}

		private bool geVGejnaOFUUGRoQQePXLnaClcB(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in geVGejnaOFUUGRoQQePXLnaClcB
			return this.geVGejnaOFUUGRoQQePXLnaClcB(P_0);
		}
	}
}
