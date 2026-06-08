using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ADictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private ADictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			private int rYsophryboKqGVyVTsndxiQThpB;

			private int aCtihPxuRFLiowUoZPQdxLYTTal;

			private KeyValuePair<TKey, TValue> fSpdVoeWhOYoAilpUehbSxUxANDS;

			private int AyhVolgiIXJekWlilGCkjtGftMvS;

			public KeyValuePair<TKey, TValue> Current => fSpdVoeWhOYoAilpUehbSxUxANDS;

			object IEnumerator.Current
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal == 0)
					{
						goto IL_003f;
					}
					if (aCtihPxuRFLiowUoZPQdxLYTTal == ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1)
					{
						goto IL_001d;
					}
					goto IL_004c;
					IL_003f:
					throw new Exception();
					IL_001d:
					int num = -930022879;
					goto IL_0022;
					IL_0022:
					switch (num ^ -930022878)
					{
					case 0:
						break;
					case 3:
						goto IL_003f;
					case 1:
						goto IL_004c;
					default:
						return new DictionaryEntry(fSpdVoeWhOYoAilpUehbSxUxANDS.Key, fSpdVoeWhOYoAilpUehbSxUxANDS.Value);
					}
					goto IL_001d;
					IL_004c:
					if (AyhVolgiIXJekWlilGCkjtGftMvS == 1)
					{
						num = -930022880;
						goto IL_0022;
					}
					return new KeyValuePair<TKey, TValue>(fSpdVoeWhOYoAilpUehbSxUxANDS.Key, fSpdVoeWhOYoAilpUehbSxUxANDS.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (0x6D400910 ^ 0x6D400912)
							{
							case 0:
								break;
							case 2:
								goto end_IL_001d;
							default:
								goto IL_0048;
							}
							continue;
							end_IL_001d:
							break;
						}
					}
					throw new Exception();
					IL_0048:
					return new DictionaryEntry(fSpdVoeWhOYoAilpUehbSxUxANDS.Key, fSpdVoeWhOYoAilpUehbSxUxANDS.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-1773701143 ^ -1773701141)
							{
							case 0:
								break;
							case 2:
								goto end_IL_001d;
							default:
								goto IL_0048;
							}
							continue;
							end_IL_001d:
							break;
						}
					}
					throw new Exception();
					IL_0048:
					return fSpdVoeWhOYoAilpUehbSxUxANDS.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (aCtihPxuRFLiowUoZPQdxLYTTal != 0)
					{
						if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (0x68633480 ^ 0x68633481)
							{
							case 2:
								break;
							case 1:
								goto end_IL_001d;
							default:
								goto IL_0048;
							}
							continue;
							end_IL_001d:
							break;
						}
					}
					throw new Exception();
					IL_0048:
					return fSpdVoeWhOYoAilpUehbSxUxANDS.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
				rYsophryboKqGVyVTsndxiQThpB = dictionary.yBIrBfrsPGDuPEQynAujInSmPSQ;
				aCtihPxuRFLiowUoZPQdxLYTTal = 0;
				AyhVolgiIXJekWlilGCkjtGftMvS = getEnumeratorRetType;
				fSpdVoeWhOYoAilpUehbSxUxANDS = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.yBIrBfrsPGDuPEQynAujInSmPSQ)
				{
					throw new Exception();
				}
				while ((uint)aCtihPxuRFLiowUoZPQdxLYTTal < (uint)ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count)
				{
					while (true)
					{
						int num;
						if (ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].hashCode >= 0)
						{
							num = 444597380;
						}
						else
						{
							aCtihPxuRFLiowUoZPQdxLYTTal++;
							num = 444597382;
						}
						while (true)
						{
							switch (num ^ 0x1A800485)
							{
							case 0:
								num = 444597383;
								continue;
							case 2:
								break;
							case 1:
								fSpdVoeWhOYoAilpUehbSxUxANDS = new KeyValuePair<TKey, TValue>(ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].key, ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].value);
								aCtihPxuRFLiowUoZPQdxLYTTal++;
								return true;
							default:
								goto end_IL_0041;
							}
							break;
						}
						continue;
						end_IL_0041:
						break;
					}
				}
				aCtihPxuRFLiowUoZPQdxLYTTal = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1;
				fSpdVoeWhOYoAilpUehbSxUxANDS = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.yBIrBfrsPGDuPEQynAujInSmPSQ)
				{
					goto IL_0013;
				}
				goto IL_0042;
				IL_0013:
				int num = 1800694011;
				goto IL_0018;
				IL_0018:
				switch (num ^ 0x6B5468F9)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					throw new Exception();
				case 3:
					goto IL_0042;
				case 1:
					return;
				}
				goto IL_0013;
				IL_0042:
				aCtihPxuRFLiowUoZPQdxLYTTal = 0;
				fSpdVoeWhOYoAilpUehbSxUxANDS = default(KeyValuePair<TKey, TValue>);
				num = 1800694008;
				goto IL_0018;
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
				private ADictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

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
							if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1)
							{
								goto IL_0048;
							}
							while (true)
							{
								switch (-1484903447 ^ -1484903448)
								{
								case 2:
									break;
								case 1:
									goto end_IL_001d;
								default:
									goto IL_0048;
								}
								continue;
								end_IL_001d:
								break;
							}
						}
						throw new Exception();
						IL_0048:
						return zmSGmgunsjDgmfrGnNSKrgWvnmM;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
					rYsophryboKqGVyVTsndxiQThpB = dictionary.yBIrBfrsPGDuPEQynAujInSmPSQ;
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					zmSGmgunsjDgmfrGnNSKrgWvnmM = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.yBIrBfrsPGDuPEQynAujInSmPSQ)
					{
						throw new Exception();
					}
					while (true)
					{
						int num;
						int num2;
						if ((uint)aCtihPxuRFLiowUoZPQdxLYTTal < (uint)ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count)
						{
							num = -1385007473;
							num2 = num;
						}
						else
						{
							num = -1385007474;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1385007474)
							{
							case 4:
								num = -1385007473;
								continue;
							case 1:
								if (ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].hashCode >= 0)
								{
									zmSGmgunsjDgmfrGnNSKrgWvnmM = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].key;
									aCtihPxuRFLiowUoZPQdxLYTTal++;
									num = -1385007476;
								}
								else
								{
									aCtihPxuRFLiowUoZPQdxLYTTal++;
									num = -1385007475;
								}
								continue;
							case 3:
								break;
							case 2:
								return true;
							default:
								aCtihPxuRFLiowUoZPQdxLYTTal = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1;
								zmSGmgunsjDgmfrGnNSKrgWvnmM = default(TKey);
								return false;
							}
							break;
						}
					}
				}

				void IEnumerator.Reset()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.yBIrBfrsPGDuPEQynAujInSmPSQ)
					{
						throw new Exception();
					}
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					zmSGmgunsjDgmfrGnNSKrgWvnmM = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			public int Count => ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)ZXmCvDfLDDrtmgBgFDRMaBCKoyr).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> dictionary)
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
				int num3 = default(int);
				int count = default(int);
				Entry[] entries = default(Entry[]);
				while (true)
				{
					int num;
					int num2;
					if (index >= 0)
					{
						num = 1877503292;
						num2 = num;
					}
					else
					{
						num = 1877503280;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x6FE86D36)
						{
						case 9:
							num = 1877503282;
							continue;
						default:
							return;
						case 5:
							if (array.Length - index < ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
							{
								throw new Exception();
							}
							goto case 3;
						case 8:
							num3++;
							num = 1877503286;
							continue;
						case 3:
							count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count;
							entries = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries;
							num = 1877503284;
							continue;
						case 4:
							break;
						case 1:
							if (entries[num3].hashCode >= 0)
							{
								array[index++] = entries[num3].key;
								num = 1877503294;
								continue;
							}
							goto case 8;
						case 2:
							num3 = 0;
							num = 1877503286;
							continue;
						case 10:
						{
							int num5;
							if (index <= array.Length)
							{
								num = 1877503283;
								num5 = num;
							}
							else
							{
								num = 1877503280;
								num5 = num;
							}
							continue;
						}
						case 0:
						{
							int num4;
							if (num3 >= count)
							{
								num = 1877503281;
								num4 = num;
							}
							else
							{
								num = 1877503287;
								num4 = num;
							}
							continue;
						}
						case 6:
							throw new ArgumentOutOfRangeException("index");
						case 7:
							return;
						}
						break;
					}
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
				object[] array2 = default(object[]);
				int count = default(int);
				while (true)
				{
					int num;
					int num2;
					if (array.Rank != 1)
					{
						num = -34241416;
						num2 = num;
					}
					else
					{
						num = -34241415;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -34241416)
						{
						case 5:
							num = -34241423;
							continue;
						case 6:
							if (index >= 0)
							{
								int num5;
								if (index > array.Length)
								{
									num = -34241409;
									num5 = num;
								}
								else
								{
									num = -34241424;
									num5 = num;
								}
								continue;
							}
							goto case 7;
						case 3:
							if (array2 == null)
							{
								throw new Exception();
							}
							goto case 11;
						case 11:
							count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count;
							num = -34241422;
							continue;
						case 9:
							break;
						case 7:
							throw new Exception();
						case 4:
							array2 = array as object[];
							num = -34241413;
							continue;
						case 8:
							if (array.Length - index < ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
							{
								throw new Exception();
							}
							goto case 2;
						case 1:
							if (array.GetLowerBound(0) != 0)
							{
								throw new Exception();
							}
							goto case 6;
						case 0:
							throw new Exception();
						case 2:
							if (array is TKey[] array3)
							{
								CopyTo(array3, index);
								return;
							}
							goto case 4;
						default:
						{
							Entry[] entries = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries;
							try
							{
								int num3 = 0;
								while (num3 < count)
								{
									while (true)
									{
										int num4;
										if (entries[num3].hashCode >= 0)
										{
											array2[index++] = entries[num3].key;
											num4 = -34241413;
											goto IL_015c;
										}
										goto IL_01aa;
										IL_015c:
										while (true)
										{
											switch (num4 ^ -34241416)
											{
											case 2:
												num4 = -34241415;
												continue;
											case 1:
												break;
											case 3:
												goto IL_01aa;
											default:
												goto end_IL_0179;
											}
											break;
										}
										continue;
										IL_01aa:
										num3++;
										num4 = -34241416;
										goto IL_015c;
										continue;
										end_IL_0179:
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
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private ADictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

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
							if (aCtihPxuRFLiowUoZPQdxLYTTal != ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1)
							{
								goto IL_0048;
							}
							while (true)
							{
								switch (0x235C4BA7 ^ 0x235C4BA5)
								{
								case 0:
									break;
								case 2:
									goto end_IL_001d;
								default:
									goto IL_0048;
								}
								continue;
								end_IL_001d:
								break;
							}
						}
						throw new Exception();
						IL_0048:
						return akOsXqJjhjXkUanTgiMMPHmlVNV;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					ZXmCvDfLDDrtmgBgFDRMaBCKoyr = dictionary;
					rYsophryboKqGVyVTsndxiQThpB = dictionary.yBIrBfrsPGDuPEQynAujInSmPSQ;
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					akOsXqJjhjXkUanTgiMMPHmlVNV = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.yBIrBfrsPGDuPEQynAujInSmPSQ)
					{
						throw new Exception();
					}
					while ((uint)aCtihPxuRFLiowUoZPQdxLYTTal < (uint)ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count)
					{
						while (true)
						{
							int num;
							if (ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].hashCode < 0)
							{
								aCtihPxuRFLiowUoZPQdxLYTTal++;
								num = 581292733;
							}
							else
							{
								akOsXqJjhjXkUanTgiMMPHmlVNV = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries[aCtihPxuRFLiowUoZPQdxLYTTal].value;
								num = 581292735;
							}
							while (true)
							{
								switch (num ^ 0x22A5D2BD)
								{
								case 4:
									num = 581292734;
									continue;
								case 1:
									return true;
								case 2:
									aCtihPxuRFLiowUoZPQdxLYTTal++;
									num = 581292732;
									continue;
								case 3:
									break;
								default:
									goto end_IL_006e;
								}
								break;
							}
							continue;
							end_IL_006e:
							break;
						}
					}
					aCtihPxuRFLiowUoZPQdxLYTTal = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count + 1;
					akOsXqJjhjXkUanTgiMMPHmlVNV = default(TValue);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (rYsophryboKqGVyVTsndxiQThpB != ZXmCvDfLDDrtmgBgFDRMaBCKoyr.yBIrBfrsPGDuPEQynAujInSmPSQ)
					{
						throw new Exception();
					}
					aCtihPxuRFLiowUoZPQdxLYTTal = 0;
					akOsXqJjhjXkUanTgiMMPHmlVNV = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			public int Count => ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)ZXmCvDfLDDrtmgBgFDRMaBCKoyr).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> dictionary)
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
				int num3 = default(int);
				Entry[] entries = default(Entry[]);
				int count = default(int);
				while (true)
				{
					int num;
					int num2;
					if (index < 0)
					{
						num = -391074838;
						num2 = num;
					}
					else
					{
						num = -391074840;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -391074836)
						{
						case 8:
							num = -391074835;
							continue;
						case 6:
							throw new Exception();
						case 7:
							num3++;
							num = -391074834;
							continue;
						case 9:
							if (entries[num3].hashCode >= 0)
							{
								array[index++] = entries[num3].value;
								num = -391074837;
								continue;
							}
							goto case 7;
						case 5:
							num = -391074834;
							continue;
						case 0:
							if (array.Length - index < ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
							{
								throw new Exception();
							}
							goto case 3;
						case 4:
						{
							int num4;
							if (index > array.Length)
							{
								num = -391074838;
								num4 = num;
							}
							else
							{
								num = -391074836;
								num4 = num;
							}
							continue;
						}
						case 1:
							break;
						case 3:
							count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count;
							entries = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries;
							num3 = 0;
							num = -391074839;
							continue;
						default:
							if (num3 >= count)
							{
								return;
							}
							goto case 9;
						}
						break;
					}
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
					throw new ArgumentNullException("array");
				}
				TValue[] array3 = default(TValue[]);
				object[] array2 = default(object[]);
				while (true)
				{
					int num;
					int num2;
					if (array.Rank == 1)
					{
						num = 1582149245;
						num2 = num;
					}
					else
					{
						num = 1582149244;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x5E4DAE7A)
						{
						case 2:
							num = 1582149243;
							continue;
						case 8:
						{
							int num8;
							if (index < 0)
							{
								num = 1582149233;
								num8 = num;
							}
							else
							{
								num = 1582149247;
								num8 = num;
							}
							continue;
						}
						case 6:
							throw new Exception();
						case 7:
						{
							int num7;
							if (array.GetLowerBound(0) == 0)
							{
								num = 1582149234;
								num7 = num;
							}
							else
							{
								num = 1582149241;
								num7 = num;
							}
							continue;
						}
						case 1:
							break;
						case 0:
							CopyTo(array3, index);
							return;
						case 12:
							array2 = array as object[];
							num = 1582149232;
							continue;
						case 3:
							throw new Exception();
						case 14:
							if (array.Length - index < ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Count)
							{
								throw new Exception();
							}
							goto case 13;
						case 11:
							throw new Exception();
						case 5:
						{
							int num6;
							if (index <= array.Length)
							{
								num = 1582149236;
								num6 = num;
							}
							else
							{
								num = 1582149233;
								num6 = num;
							}
							continue;
						}
						case 13:
						{
							array3 = array as TValue[];
							int num9;
							if (array3 == null)
							{
								num = 1582149238;
								num9 = num;
							}
							else
							{
								num = 1582149242;
								num9 = num;
							}
							continue;
						}
						case 10:
						{
							int num5;
							if (array2 == null)
							{
								num = 1582149235;
								num5 = num;
							}
							else
							{
								num = 1582149246;
								num5 = num;
							}
							continue;
						}
						case 9:
							throw new Exception();
						default:
						{
							int count = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._count;
							Entry[] entries = ZXmCvDfLDDrtmgBgFDRMaBCKoyr._entries;
							try
							{
								int num3 = 0;
								while (num3 < count)
								{
									while (true)
									{
										int num4;
										if (entries[num3].hashCode >= 0)
										{
											array2[index++] = entries[num3].value;
											num4 = 1582149242;
											goto IL_01ab;
										}
										goto IL_01f9;
										IL_01ab:
										while (true)
										{
											switch (num4 ^ 0x5E4DAE7A)
											{
											case 2:
												num4 = 1582149243;
												continue;
											case 1:
												break;
											case 0:
												goto IL_01f9;
											default:
												goto end_IL_01c8;
											}
											break;
										}
										continue;
										IL_01f9:
										num3++;
										num4 = 1582149241;
										goto IL_01ab;
										continue;
										end_IL_01c8:
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

		private const string sipfQrilsKljKiMWfTzihXLbBCl = "Version";

		private const string oGeGzcOqHABcUERPRVSmTHwDHvyc = "HashSize";

		private const string ujzcJhiHfnZItaXoAtXdazJammT = "KeyValuePairs";

		private const string yJwYGarePltObNjNWYIlKAGBXWO = "Comparer";

		private int[] iCaeSdFVXJNhkppGVVqlSAoFJOd;

		internal Entry[] _entries;

		internal int _count;

		private int yBIrBfrsPGDuPEQynAujInSmPSQ;

		private int ytjXRexHICOCNLblwYrZFsvOUWp;

		private int VBnMmOlcCCepavEDPiGFhWAVBd;

		private int BYVqlFzpjtATyryNBxBUSRZArAz;

		private IEqualityComparer<TKey> GcxxwMSnKhQJjkeyqdiHIMlJtaEh;

		private IEqualityComparer<TValue> qcNUiXcHrkXMpAhltjKBTwcPAmj;

		private KeyCollection TzjUZwdoZvqBsSkZLyNQAuQwzCg;

		private ValueCollection sLrrXqOcjGJUZpChpAEeYDKuQek;

		private readonly object xDtHAZlziJWMAMdwmzVBgbUwfPN = new object();

		private static readonly bool MrkXHlQCvMAquqwgKuxhveelbzd = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool iGIDmwHIPONsdyKEecwUpHbWJERp;

		public int Count => _count - BYVqlFzpjtATyryNBxBUSRZArAz;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (TzjUZwdoZvqBsSkZLyNQAuQwzCg == null)
				{
					while (true)
					{
						int num = 1878392860;
						while (true)
						{
							switch (num ^ 0x6FF6001E)
							{
							case 0:
								break;
							case 2:
								TzjUZwdoZvqBsSkZLyNQAuQwzCg = new KeyCollection(this);
								num = 1878392863;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				return TzjUZwdoZvqBsSkZLyNQAuQwzCg;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (sLrrXqOcjGJUZpChpAEeYDKuQek == null)
				{
					sLrrXqOcjGJUZpChpAEeYDKuQek = new ValueCollection(this);
				}
				return sLrrXqOcjGJUZpChpAEeYDKuQek;
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
					value = EqualityComparerNoAlloc<TValue>.Default;
					goto IL_000a;
				}
				goto IL_0028;
				IL_0028:
				qcNUiXcHrkXMpAhltjKBTwcPAmj = value;
				int num = -1437127968;
				goto IL_000f;
				IL_000a:
				num = -1437127965;
				goto IL_000f;
				IL_000f:
				switch (num ^ -1437127967)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_0028;
				case 1:
					return;
				}
				goto IL_000a;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					throw new KeyNotFoundException(string.Concat("Key \"", key, " does not exist."));
				}
				return _entries[num].value;
			}
			set
			{
				onfDVfXdYjhpDkxDKJdyOnbcFuM(key, value, false);
			}
		}

		public int IndexOfFirst
		{
			get
			{
				int num = 0;
				while (num < _count)
				{
					while (true)
					{
						if (_entries[num].hashCode >= 0)
						{
							return num;
						}
						num++;
						int num2 = -430679521;
						while (true)
						{
							switch (num2 ^ -430679522)
							{
							case 0:
								num2 = -430679524;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
				return -1;
			}
		}

		public int IndexOfLast
		{
			get
			{
				int num = _count - 1;
				while (num >= 0)
				{
					while (true)
					{
						int num2;
						if (_entries[num].hashCode >= 0)
						{
							num2 = -686775294;
						}
						else
						{
							num--;
							num2 = -686775296;
						}
						while (true)
						{
							switch (num2 ^ -686775295)
							{
							case 0:
								num2 = -686775293;
								continue;
							case 2:
								break;
							case 3:
								return num;
							default:
								goto end_IL_002d;
							}
							break;
						}
						continue;
						end_IL_002d:
						break;
					}
				}
				return -1;
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				if (TzjUZwdoZvqBsSkZLyNQAuQwzCg == null)
				{
					TzjUZwdoZvqBsSkZLyNQAuQwzCg = new KeyCollection(this);
				}
				return TzjUZwdoZvqBsSkZLyNQAuQwzCg;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (sLrrXqOcjGJUZpChpAEeYDKuQek == null)
				{
					while (true)
					{
						int num = -126860268;
						while (true)
						{
							switch (num ^ -126860267)
							{
							case 2:
								break;
							case 1:
								sLrrXqOcjGJUZpChpAEeYDKuQek = new ValueCollection(this);
								num = -126860267;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				return sLrrXqOcjGJUZpChpAEeYDKuQek;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => xDtHAZlziJWMAMdwmzVBgbUwfPN;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (TnWmjWMgwQxNOKtXtKMVloAIyxa(key))
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
				NMkAEdgibIZwdOYyyOPJOJyOyUg<TValue>(value, "value");
				try
				{
					TKey key2 = (TKey)key;
					try
					{
						this[key2] = (TValue)value;
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

		public ADictionary(IEqualityComparer<TKey> keyComparer)
			: this(0, keyComparer, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: this(0, keyComparer, valueComparer)
		{
		}

		public ADictionary(int capacity)
			: this(capacity, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int capacity, IEqualityComparer<TKey> keyComparer)
			: this(capacity, keyComparer, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int capacity, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			while (true)
			{
				int num = 1962589834;
				while (true)
				{
					switch (num ^ 0x74FABE8B)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (capacity < 0)
						{
							throw new ArgumentOutOfRangeException("capacity");
						}
						goto case 5;
					case 3:
						GcxxwMSnKhQJjkeyqdiHIMlJtaEh = keyComparer ?? EqualityComparerNoAlloc<TKey>.Default;
						qcNUiXcHrkXMpAhltjKBTwcPAmj = valueComparer ?? EqualityComparerNoAlloc<TValue>.Default;
						num = 1962589833;
						continue;
					case 5:
					{
						int num2;
						if (capacity > 0)
						{
							num = 1962589839;
							num2 = num;
						}
						else
						{
							num = 1962589832;
							num2 = num;
						}
						continue;
					}
					case 4:
						SdmfoteCDVoXNaSlWEvRMBbwmDy(capacity);
						num = 1962589832;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer)
			: this(dictionary, keyComparer, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: this(dictionary?.Count ?? 0, keyComparer)
		{
			while (true)
			{
				switch (-2144977213 ^ -2144977214)
				{
				case 2:
					continue;
				case 1:
					if (dictionary == null)
					{
						throw new ArgumentNullException("dictionary");
					}
					break;
				}
				break;
			}
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			onfDVfXdYjhpDkxDKJdyOnbcFuM(key, value, true);
		}

		public void Clear()
		{
			if (_count <= 0)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int num = 1633679018;
				while (true)
				{
					switch (num ^ 0x615FF6A9)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						num2 = 0;
						num = 1633679020;
						continue;
					case 0:
						iCaeSdFVXJNhkppGVVqlSAoFJOd[num2] = -1;
						num2++;
						num = 1633679020;
						continue;
					case 5:
						if (num2 >= iCaeSdFVXJNhkppGVVqlSAoFJOd.Length)
						{
							Array.Clear(_entries, 0, _count);
							VBnMmOlcCCepavEDPiGFhWAVBd = -1;
							_count = 0;
							num = 1633679016;
							continue;
						}
						goto case 0;
					case 1:
						BYVqlFzpjtATyryNBxBUSRZArAz = 0;
						yBIrBfrsPGDuPEQynAujInSmPSQ++;
						ytjXRexHICOCNLblwYrZFsvOUWp++;
						num = 1633679021;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOfKey(key) >= 0;
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
			if (!MrkXHlQCvMAquqwgKuxhveelbzd)
			{
				goto IL_000a;
			}
			goto IL_01f7;
			IL_000a:
			int num = 1855154821;
			goto IL_000f;
			IL_000f:
			int num2 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num ^ 0x6E936A83)
				{
				case 5:
					break;
				case 6:
					if (object.ReferenceEquals(key, null))
					{
						throw new ArgumentNullException("key");
					}
					goto IL_01f7;
				case 13:
					num2 = iCaeSdFVXJNhkppGVVqlSAoFJOd[num3];
					num = 1855154818;
					continue;
				case 2:
					_entries[num2].next = VBnMmOlcCCepavEDPiGFhWAVBd;
					num = 1855154827;
					continue;
				case 12:
					goto IL_00ab;
				case 8:
					_entries[num2].key = default(TKey);
					_entries[num2].value = default(TValue);
					VBnMmOlcCCepavEDPiGFhWAVBd = num2;
					BYVqlFzpjtATyryNBxBUSRZArAz++;
					num = 1855154816;
					continue;
				case 9:
					num = 1855154820;
					continue;
				case 7:
					_entries[num2].hashCode = -1;
					num = 1855154817;
					continue;
				case 0:
					num2 = _entries[num2].next;
					num = 1855154818;
					continue;
				case 11:
					goto IL_0166;
				case 3:
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					return true;
				case 1:
					goto IL_01df;
				case 10:
					goto IL_01f7;
				default:
					goto IL_0229;
				}
				break;
				IL_01df:
				int num4;
				if (num2 < 0)
				{
					num = 1855154823;
					num4 = num;
				}
				else
				{
					num = 1855154824;
					num4 = num;
				}
				continue;
				IL_0166:
				if (_entries[num2].hashCode == num5 && GcxxwMSnKhQJjkeyqdiHIMlJtaEh.Equals(_entries[num2].key, key))
				{
					if (num6 < 0)
					{
						iCaeSdFVXJNhkppGVVqlSAoFJOd[num3] = _entries[num2].next;
						num = 1855154826;
						continue;
					}
					goto IL_00ab;
				}
				num6 = num2;
				num = 1855154819;
				continue;
				IL_00ab:
				_entries[num6].next = _entries[num2].next;
				num = 1855154820;
			}
			goto IL_000a;
			IL_0229:
			return false;
			IL_01f7:
			if (iCaeSdFVXJNhkppGVVqlSAoFJOd != null)
			{
				num5 = GcxxwMSnKhQJjkeyqdiHIMlJtaEh.GetHashCode(key) & 0x7FFFFFFF;
				num3 = num5 % iCaeSdFVXJNhkppGVVqlSAoFJOd.Length;
				num6 = -1;
				num = 1855154830;
				goto IL_000f;
			}
			goto IL_0229;
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

		public TValue GetValueSafe(TKey key)
		{
			int num = IndexOfKey(key);
			TValue result = default(TValue);
			while (true)
			{
				int num2 = -1678228914;
				while (true)
				{
					switch (num2 ^ -1678228913)
					{
					case 2:
						break;
					case 1:
						if (num < 0)
						{
							goto IL_003c;
						}
						return _entries[num].value;
					default:
						return result;
					}
					break;
					IL_003c:
					result = default(TValue);
					num2 = -1678228913;
				}
			}
		}

		public int IndexOfKey(TKey key)
		{
			if (!MrkXHlQCvMAquqwgKuxhveelbzd)
			{
				goto IL_000a;
			}
			goto IL_00f3;
			IL_000a:
			int num = 414752175;
			goto IL_000f;
			IL_000f:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x18B89DAD)
				{
				case 6:
					break;
				case 2:
					if (object.ReferenceEquals(key, null))
					{
						throw new ArgumentNullException("key");
					}
					goto IL_00f3;
				case 3:
					goto IL_005e;
				case 0:
					num2 = GcxxwMSnKhQJjkeyqdiHIMlJtaEh.GetHashCode(key) & 0x7FFFFFFF;
					num3 = iCaeSdFVXJNhkppGVVqlSAoFJOd[num2 % iCaeSdFVXJNhkppGVVqlSAoFJOd.Length];
					num = 414752174;
					continue;
				case 5:
					goto IL_00a2;
				case 1:
					goto IL_00f3;
				default:
					return -1;
				}
				break;
				IL_00a2:
				if (_entries[num3].hashCode == num2 && GcxxwMSnKhQJjkeyqdiHIMlJtaEh.Equals(_entries[num3].key, key))
				{
					return num3;
				}
				num3 = _entries[num3].next;
				num = 414752174;
				continue;
				IL_005e:
				int num4;
				if (num3 >= 0)
				{
					num = 414752168;
					num4 = num;
				}
				else
				{
					num = 414752169;
					num4 = num;
				}
			}
			goto IL_000a;
			IL_00f3:
			int num5;
			if (iCaeSdFVXJNhkppGVVqlSAoFJOd == null)
			{
				num = 414752169;
				num5 = num;
			}
			else
			{
				num = 414752173;
				num5 = num;
			}
			goto IL_000f;
		}

		public int IndexOfValue(TValue value)
		{
			Entry[] entries = _entries;
			int num3 = default(int);
			int num2 = default(int);
			IEqualityComparer<TValue> equalityComparer = default(IEqualityComparer<TValue>);
			while (true)
			{
				int num = -1844527512;
				while (true)
				{
					switch (num ^ -1844527509)
					{
					case 10:
						break;
					case 7:
					{
						int num4;
						if (num3 < _count)
						{
							num = -1844527520;
							num4 = num;
						}
						else
						{
							num = -1844527506;
							num4 = num;
						}
						continue;
					}
					case 2:
						num = -1844527506;
						continue;
					case 6:
					{
						int num5;
						if (num2 >= _count)
						{
							num = -1844527511;
							num5 = num;
						}
						else
						{
							num = -1844527509;
							num5 = num;
						}
						continue;
					}
					case 1:
						return num2;
					case 4:
						equalityComparer = qcNUiXcHrkXMpAhltjKBTwcPAmj;
						num3 = 0;
						num = -1844527508;
						continue;
					case 9:
						if (equalityComparer.Equals(entries[num3].value, value))
						{
							num = -1844527517;
							continue;
						}
						goto IL_00f7;
					case 0:
						if (entries[num2].hashCode < 0 || entries[num2].value != null)
						{
							num2++;
							num = -1844527507;
						}
						else
						{
							num = -1844527510;
						}
						continue;
					case 8:
						return num3;
					case 11:
						if (entries[num3].hashCode >= 0)
						{
							num = -1844527518;
							continue;
						}
						goto IL_00f7;
					case 3:
						if (!iGIDmwHIPONsdyKEecwUpHbWJERp && value == null)
						{
							num2 = 0;
							num = -1844527507;
							continue;
						}
						goto case 4;
					default:
						{
							return -1;
						}
						IL_00f7:
						num3++;
						num = -1844527508;
						continue;
					}
					break;
				}
			}
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
			while (true)
			{
				int num;
				int num2;
				if (_entries[index].hashCode < 0)
				{
					num = 1102661832;
					num2 = num;
				}
				else
				{
					num = 1102661834;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x41B948C9)
					{
					case 0:
						goto IL_0014;
					case 2:
						break;
					case 1:
						throw new ArgumentException("index points to an invalid entry.");
					default:
						return _entries[index].key;
					}
					break;
					IL_0014:
					num = 1102661835;
				}
			}
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
			while (true)
			{
				int num;
				int num2;
				if (_entries[index].hashCode >= 0)
				{
					num = 845551666;
					num2 = num;
				}
				else
				{
					num = 845551664;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x32661832)
					{
					case 3:
						goto IL_0014;
					case 1:
						break;
					case 2:
						throw new ArgumentException("index points to an invalid entry.");
					default:
						return new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					}
					break;
					IL_0014:
					num = 845551667;
				}
			}
		}

		public bool TryGetKeyAt(int index, out TKey key)
		{
			if ((uint)index < (uint)_count)
			{
				while (true)
				{
					int num = -463558677;
					while (true)
					{
						switch (num ^ -463558678)
						{
						case 0:
							break;
						case 1:
							goto IL_0027;
						default:
							goto end_IL_0009;
						}
						break;
						IL_0027:
						if (_entries[index].hashCode < 0)
						{
							num = -463558680;
							continue;
						}
						key = _entries[index].key;
						return true;
					}
					continue;
					end_IL_0009:
					break;
				}
			}
			key = default(TKey);
			return false;
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
			if ((uint)index < (uint)_count)
			{
				while (true)
				{
					int num = -8956621;
					while (true)
					{
						switch (num ^ -8956622)
						{
						case 3:
							break;
						case 1:
							goto IL_002b;
						case 2:
							goto end_IL_0009;
						default:
							return true;
						}
						break;
						IL_002b:
						if (_entries[index].hashCode < 0)
						{
							num = -8956624;
							continue;
						}
						entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
						num = -8956622;
					}
					continue;
					end_IL_0009:
					break;
				}
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
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
				while (true)
				{
					int num = 430948663;
					while (true)
					{
						switch (num ^ 0x19AFC135)
						{
						case 0:
							break;
						case 2:
							goto IL_002e;
						default:
							return false;
						}
						break;
						IL_002e:
						value = default(TValue);
						num = 430948660;
					}
				}
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
				goto IL_0010;
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
			int num = 384329917;
			goto IL_0015;
			IL_0010:
			num = 384329916;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x16E868BD)
			{
			case 2:
				break;
			case 1:
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			default:
				return false;
			}
			goto IL_0010;
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
				goto IL_0010;
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
			int num = -1427028795;
			goto IL_0015;
			IL_0010:
			num = -1427028794;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1427028793)
				{
				case 0:
					break;
				case 2:
					key = default(TKey);
					num = -1427028797;
					continue;
				case 3:
					return false;
				case 1:
					key = default(TKey);
					num = -1427028796;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0010;
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
			while (true)
			{
				int num = 797280062;
				while (true)
				{
					switch (num ^ 0x2F85873F)
					{
					case 2:
						break;
					case 1:
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
						goto IL_0088;
					default:
						return false;
					}
					break;
					IL_0088:
					entry = default(KeyValuePair<TKey, TValue>);
					num = 797280063;
				}
			}
		}

		public bool RemoveAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = -257272999;
			goto IL_000e;
			IL_000e:
			switch (num ^ -257272998)
			{
			case 0:
				break;
			case 3:
				throw new ArgumentOutOfRangeException("index");
			case 2:
				goto IL_003d;
			default:
				return false;
			}
			goto IL_0009;
			IL_003d:
			if (_entries[index].hashCode < 0)
			{
				num = -257272997;
				goto IL_000e;
			}
			Remove(_entries[index].key);
			return true;
		}

		private void puzGFZqzDbqWTsmoCZBrxaUqkZB(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			int count = default(int);
			Entry[] entries = default(Entry[]);
			int num3 = default(int);
			while (true)
			{
				if (P_1 >= 0)
				{
					int num;
					int num2;
					if (P_1 <= P_0.Length)
					{
						num = 1907689347;
						num2 = num;
					}
					else
					{
						num = 1907689346;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x71B50780)
						{
						case 5:
							num = 1907689348;
							continue;
						case 4:
							break;
						case 7:
							count = _count;
							entries = _entries;
							num = 1907689345;
							continue;
						case 3:
							goto IL_007b;
						case 2:
							goto IL_009c;
						case 1:
							num3 = 0;
							num = 1907689353;
							continue;
						case 8:
							if (entries[num3].hashCode >= 0)
							{
								ref KeyValuePair<TKey, TValue> reference = ref P_0[P_1++];
								reference = new KeyValuePair<TKey, TValue>(entries[num3].key, entries[num3].value);
								num = 1907689344;
								continue;
							}
							goto case 0;
						case 6:
							throw new Exception();
						case 0:
							num3++;
							num = 1907689353;
							continue;
						default:
							if (num3 >= count)
							{
								return;
							}
							goto case 8;
						}
						break;
						IL_007b:
						int num4;
						if (P_0.Length - P_1 >= Count)
						{
							num = 1907689351;
							num4 = num;
						}
						else
						{
							num = 1907689350;
							num4 = num;
						}
					}
					continue;
				}
				goto IL_009c;
				IL_009c:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		private void SdmfoteCDVoXNaSlWEvRMBbwmDy(int P_0)
		{
			int num = OTTDLVeCUPmzOXufKxLwdAvCsJAQ.zbeAceNSyGcZTUpJMPIRoiRaJUk(P_0);
			int num3 = default(int);
			while (true)
			{
				int num2 = -104563513;
				while (true)
				{
					switch (num2 ^ -104563517)
					{
					case 3:
						break;
					case 0:
						if (num3 >= iCaeSdFVXJNhkppGVVqlSAoFJOd.Length)
						{
							_entries = new Entry[num];
							num2 = -104563519;
							continue;
						}
						goto case 1;
					case 1:
						iCaeSdFVXJNhkppGVVqlSAoFJOd[num3] = -1;
						num3++;
						num2 = -104563517;
						continue;
					case 4:
						iCaeSdFVXJNhkppGVVqlSAoFJOd = new int[num];
						num3 = 0;
						num2 = -104563517;
						continue;
					default:
						VBnMmOlcCCepavEDPiGFhWAVBd = -1;
						return;
					}
					break;
				}
			}
		}

		private void onfDVfXdYjhpDkxDKJdyOnbcFuM(TKey P_0, TValue P_1, bool P_2)
		{
			if (!MrkXHlQCvMAquqwgKuxhveelbzd && object.ReferenceEquals(P_0, null))
			{
				goto IL_0018;
			}
			goto IL_0095;
			IL_0095:
			int num;
			if (iCaeSdFVXJNhkppGVVqlSAoFJOd == null)
			{
				SdmfoteCDVoXNaSlWEvRMBbwmDy(0);
				num = -10229926;
				goto IL_001d;
			}
			goto IL_00ae;
			IL_0018:
			num = -10229939;
			goto IL_001d;
			IL_001d:
			int num3 = default(int);
			int num2 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ -10229942)
				{
				case 12:
					break;
				case 4:
					num3 = _count;
					_count++;
					num = -10229942;
					continue;
				case 9:
					goto IL_0095;
				case 16:
					goto IL_00ae;
				case 11:
					num = -10229947;
					continue;
				case 7:
					throw new ArgumentNullException("key");
				case 15:
					goto IL_00fe;
				case 5:
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					return;
				case 6:
					if (_count == _entries.Length)
					{
						ApmnsHLLLtsLslDynvvWTzQJcBz();
						num2 = num5 % iCaeSdFVXJNhkppGVVqlSAoFJOd.Length;
						num = -10229938;
						continue;
					}
					goto case 4;
				case 3:
					if (_entries[num4].hashCode == num5 && GcxxwMSnKhQJjkeyqdiHIMlJtaEh.Equals(_entries[num4].key, P_0))
					{
						goto IL_0190;
					}
					goto case 8;
				case 0:
					_entries[num3].hashCode = num5;
					num = -10229948;
					continue;
				case 8:
					num4 = _entries[num4].next;
					num = -10229947;
					continue;
				case 18:
					BYVqlFzpjtATyryNBxBUSRZArAz--;
					num = -10229942;
					continue;
				case 10:
					throw new ArgumentException("An element with the same key already exists in the dictionary.");
				case 17:
					if (BYVqlFzpjtATyryNBxBUSRZArAz > 0)
					{
						num3 = VBnMmOlcCCepavEDPiGFhWAVBd;
						VBnMmOlcCCepavEDPiGFhWAVBd = _entries[num3].next;
						num = -10229928;
						continue;
					}
					goto case 6;
				case 1:
					_entries[num3].key = P_0;
					_entries[num3].value = P_1;
					num = -10229945;
					continue;
				case 14:
					_entries[num3].next = iCaeSdFVXJNhkppGVVqlSAoFJOd[num2];
					num = -10229941;
					continue;
				case 2:
					_entries[num4].value = P_1;
					num = -10229937;
					continue;
				default:
					iCaeSdFVXJNhkppGVVqlSAoFJOd[num2] = num3;
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					ytjXRexHICOCNLblwYrZFsvOUWp++;
					return;
				}
				break;
				IL_0190:
				int num6;
				if (P_2)
				{
					num = -10229952;
					num6 = num;
				}
				else
				{
					num = -10229944;
					num6 = num;
				}
				continue;
				IL_00fe:
				int num7;
				if (num4 >= 0)
				{
					num = -10229943;
					num7 = num;
				}
				else
				{
					num = -10229925;
					num7 = num;
				}
			}
			goto IL_0018;
			IL_00ae:
			num5 = GcxxwMSnKhQJjkeyqdiHIMlJtaEh.GetHashCode(P_0) & 0x7FFFFFFF;
			num2 = num5 % iCaeSdFVXJNhkppGVVqlSAoFJOd.Length;
			num4 = iCaeSdFVXJNhkppGVVqlSAoFJOd[num2];
			num = -10229951;
			goto IL_001d;
		}

		private void ApmnsHLLLtsLslDynvvWTzQJcBz()
		{
			ApmnsHLLLtsLslDynvvWTzQJcBz(OTTDLVeCUPmzOXufKxLwdAvCsJAQ.PRpOnHOTCSFgEJafMnrPgbBfWEC(_count), false);
		}

		private void ApmnsHLLLtsLslDynvvWTzQJcBz(int P_0, bool P_1)
		{
			int[] array = new int[P_0];
			int num = 0;
			Entry[] array2 = default(Entry[]);
			int num4 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2;
				if (num >= array.Length)
				{
					array2 = new Entry[P_0];
					num2 = -424235140;
					goto IL_0013;
				}
				goto IL_0193;
				IL_0013:
				while (true)
				{
					switch (num2 ^ -424235141)
					{
					case 3:
						num2 = -424235152;
						continue;
					default:
						return;
					case 6:
						num4 = array2[num3].hashCode % P_0;
						array2[num3].next = array[num4];
						num2 = -424235151;
						continue;
					case 2:
						if (array2[num5].hashCode != -1)
						{
							array2[num5].hashCode = GcxxwMSnKhQJjkeyqdiHIMlJtaEh.GetHashCode(array2[num5].key) & 0x7FFFFFFF;
							num2 = -424235146;
							continue;
						}
						goto case 13;
					case 1:
						break;
					case 12:
						if (num3 >= _count)
						{
							iCaeSdFVXJNhkppGVVqlSAoFJOd = array;
							_entries = array2;
							num2 = -424235149;
							continue;
						}
						break;
					case 0:
						goto IL_010f;
					case 7:
						Array.Copy(_entries, 0, array2, 0, _count);
						if (P_1)
						{
							num5 = 0;
							num2 = -424235141;
							continue;
						}
						goto case 4;
					case 4:
						num3 = 0;
						num2 = -424235145;
						continue;
					case 10:
						array[num4] = num3;
						num2 = -424235138;
						continue;
					case 5:
						num3++;
						num2 = -424235145;
						continue;
					case 9:
						goto end_IL_0013;
					case 11:
						goto IL_0193;
					case 13:
						num5++;
						num2 = -424235141;
						continue;
					case 8:
						return;
					}
					int num6;
					if (array2[num3].hashCode >= 0)
					{
						num2 = -424235139;
						num6 = num2;
					}
					else
					{
						num2 = -424235138;
						num6 = num2;
					}
					continue;
					IL_010f:
					int num7;
					if (num5 < _count)
					{
						num2 = -424235143;
						num7 = num2;
					}
					else
					{
						num2 = -424235137;
						num7 = num2;
					}
					continue;
					end_IL_0013:
					break;
				}
				continue;
				IL_0193:
				array[num] = -1;
				num++;
				num2 = -424235150;
				goto IL_0013;
			}
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			Add(keyValuePair.Key, keyValuePair.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = IndexOfKey(keyValuePair.Key);
			if (num >= 0 && qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(_entries[num].value, keyValuePair.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = IndexOfKey(keyValuePair.Key);
			if (num >= 0 && qcNUiXcHrkXMpAhltjKBTwcPAmj.Equals(_entries[num].value, keyValuePair.Value))
			{
				Remove(keyValuePair.Key);
				return true;
			}
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			puzGFZqzDbqWTsmoCZBrxaUqkZB(array, index);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Entry[] entries = default(Entry[]);
			int num3 = default(int);
			DictionaryEntry[] array3 = default(DictionaryEntry[]);
			KeyValuePair<TKey, TValue>[] array2 = default(KeyValuePair<TKey, TValue>[]);
			int num9 = default(int);
			while (array.Rank == 1)
			{
				while (true)
				{
					IL_01a8:
					if (array.GetLowerBound(0) == 0)
					{
						while (true)
						{
							IL_012e:
							if (index >= 0)
							{
								int num;
								int num2;
								if (index > array.Length)
								{
									num = 1459226483;
									num2 = num;
								}
								else
								{
									num = 1459226492;
									num2 = num;
								}
								while (true)
								{
									switch (num ^ 0x56FA0774)
									{
									case 2:
										num = 1459226481;
										continue;
									case 5:
										break;
									case 8:
										goto IL_0084;
									case 7:
										goto IL_00a8;
									case 6:
										if (entries[num3].hashCode >= 0)
										{
											ref DictionaryEntry reference = ref array3[index++];
											reference = new DictionaryEntry(entries[num3].key, entries[num3].value);
											num = 1459226469;
											continue;
										}
										goto case 17;
									case 11:
										goto IL_0111;
									case 4:
										goto IL_012e;
									case 10:
										return;
									case 15:
										goto IL_015d;
									case 3:
										array3 = array as DictionaryEntry[];
										num = 1459226489;
										continue;
									case 16:
										goto IL_018a;
									case 14:
										goto IL_01a8;
									case 0:
										throw new Exception();
									case 13:
										entries = _entries;
										num3 = 0;
										num = 1459226495;
										continue;
									case 17:
										num3++;
										num = 1459226495;
										continue;
									case 12:
										return;
									case 1:
										puzGFZqzDbqWTsmoCZBrxaUqkZB(array2, index);
										num = 1459226494;
										continue;
									default:
										goto IL_0212;
									}
									break;
									IL_018a:
									array2 = array as KeyValuePair<TKey, TValue>[];
									int num4;
									if (array2 != null)
									{
										num = 1459226485;
										num4 = num;
									}
									else
									{
										num = 1459226491;
										num4 = num;
									}
									continue;
									IL_0111:
									int num5;
									if (num3 >= _count)
									{
										num = 1459226488;
										num5 = num;
									}
									else
									{
										num = 1459226482;
										num5 = num;
									}
									continue;
									IL_0084:
									int num6;
									if (array.Length - index < Count)
									{
										num = 1459226484;
										num6 = num;
									}
									else
									{
										num = 1459226468;
										num6 = num;
									}
									continue;
									IL_015d:
									int num7;
									if (array is DictionaryEntry[])
									{
										num = 1459226487;
										num7 = num;
									}
									else
									{
										num = 1459226493;
										num7 = num;
									}
								}
								break;
							}
							goto IL_00a8;
							IL_00a8:
							throw new ArgumentOutOfRangeException("index");
						}
						break;
					}
					throw new Exception();
					IL_0212:
					if (!(array is object[] array4))
					{
						throw new Exception();
					}
					try
					{
						int count = _count;
						Entry[] entries2 = _entries;
						while (true)
						{
							int num8 = 1459226481;
							while (true)
							{
								switch (num8 ^ 0x56FA0774)
								{
								case 0:
									break;
								case 2:
									array4[index++] = new KeyValuePair<TKey, TValue>(entries2[num9].key, entries2[num9].value);
									num8 = 1459226480;
									continue;
								case 3:
								{
									int num10;
									if (entries2[num9].hashCode >= 0)
									{
										num8 = 1459226486;
										num10 = num8;
									}
									else
									{
										num8 = 1459226480;
										num10 = num8;
									}
									continue;
								}
								case 5:
									num9 = 0;
									num8 = 1459226485;
									continue;
								case 4:
									num9++;
									num8 = 1459226485;
									continue;
								default:
									if (num9 >= count)
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
			throw new Exception();
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
			NMkAEdgibIZwdOYyyOPJOJyOyUg<TValue>(value, "value");
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
			if (TnWmjWMgwQxNOKtXtKMVloAIyxa(key))
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
			if (!TnWmjWMgwQxNOKtXtKMVloAIyxa(key))
			{
				return;
			}
			while (true)
			{
				int num = 789848141;
				while (true)
				{
					switch (num ^ 0x2F14204C)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0026;
					case 0:
						return;
					}
					break;
					IL_0026:
					Remove((TKey)key);
					num = 789848140;
				}
			}
		}

		private static bool TnWmjWMgwQxNOKtXtKMVloAIyxa(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void NMkAEdgibIZwdOYyyOPJOJyOyUg<T>(object P_0, string P_1)
		{
			if (P_0 == null && default(T) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}

		static ADictionary()
		{
			while (true)
			{
				int num = -548089288;
				while (true)
				{
					switch (num ^ -548089287)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0032;
					case 0:
						return;
					}
					break;
					IL_0032:
					iGIDmwHIPONsdyKEecwUpHbWJERp = ReflectionTools.IsValueType(typeof(TValue));
					num = -548089287;
				}
			}
		}
	}
}
