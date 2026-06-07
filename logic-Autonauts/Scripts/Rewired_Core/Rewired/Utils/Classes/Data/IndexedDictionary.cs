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
		private struct zAvfWGRctzEUQXnaVBnrdAWTR
		{
			public TKey eZCuZcaXadasLLacRQKJXebMgIEg;

			public TValue kXoKOSZJMKwATOiGMaylYIDqdDnb;

			public zAvfWGRctzEUQXnaVBnrdAWTR(TKey key, TValue value)
			{
				eZCuZcaXadasLLacRQKJXebMgIEg = key;
				kXoKOSZJMKwATOiGMaylYIDqdDnb = value;
			}

			public KeyValuePair<TKey, TValue> uaWVzCFMhTzjLiLjeeZWDfxsKmC()
			{
				return new KeyValuePair<TKey, TValue>(eZCuZcaXadasLLacRQKJXebMgIEg, kXoKOSZJMKwATOiGMaylYIDqdDnb);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

			private int EygMDwDKOyuDPoDuSCVwhlkKZwkB;

			private int VgtGZGVNuFqErLJXYsgetKqIFWC;

			private KeyValuePair<TKey, TValue> CLjmYleEuCraJMMUJEFwtuAaGlg;

			private int zBtOmsIQrDkhrlaBuhnfGniszHA;

			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					return CLjmYleEuCraJMMUJEFwtuAaGlg;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x309973D3 ^ 0x309973D1)
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
					if (zBtOmsIQrDkhrlaBuhnfGniszHA == 1)
					{
						return new DictionaryEntry(CLjmYleEuCraJMMUJEFwtuAaGlg.Key, CLjmYleEuCraJMMUJEFwtuAaGlg.Value);
					}
					return new KeyValuePair<TKey, TValue>(CLjmYleEuCraJMMUJEFwtuAaGlg.Key, CLjmYleEuCraJMMUJEFwtuAaGlg.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (-2072504990 ^ -2072504992)
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
					return new DictionaryEntry(CLjmYleEuCraJMMUJEFwtuAaGlg.Key, CLjmYleEuCraJMMUJEFwtuAaGlg.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x6147F7B7 ^ 0x6147F7B6)
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
					return CLjmYleEuCraJMMUJEFwtuAaGlg.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x6837482B ^ 0x6837482A)
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
					return CLjmYleEuCraJMMUJEFwtuAaGlg.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
				EygMDwDKOyuDPoDuSCVwhlkKZwkB = dictionary.nRmHtmCTLMujsmHWTvkVqllSHbd.Version;
				VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
				zBtOmsIQrDkhrlaBuhnfGniszHA = getEnumeratorRetType;
				CLjmYleEuCraJMMUJEFwtuAaGlg = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd.Version)
				{
					throw new Exception();
				}
				while ((uint)VgtGZGVNuFqErLJXYsgetKqIFWC < (uint)kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count)
				{
					int num = 135014144;
					while (true)
					{
						switch (num ^ 0x80C2700)
						{
						case 2:
							goto IL_001e;
						case 1:
							break;
						default:
							CLjmYleEuCraJMMUJEFwtuAaGlg = new KeyValuePair<TKey, TValue>(kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items[VgtGZGVNuFqErLJXYsgetKqIFWC].eZCuZcaXadasLLacRQKJXebMgIEg, kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items[VgtGZGVNuFqErLJXYsgetKqIFWC].kXoKOSZJMKwATOiGMaylYIDqdDnb);
							VgtGZGVNuFqErLJXYsgetKqIFWC++;
							return true;
						}
						break;
						IL_001e:
						num = 135014145;
					}
				}
				VgtGZGVNuFqErLJXYsgetKqIFWC = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1;
				CLjmYleEuCraJMMUJEFwtuAaGlg = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd.Version)
				{
					goto IL_0018;
				}
				goto IL_0047;
				IL_0018:
				int num = -246860719;
				goto IL_001d;
				IL_001d:
				switch (num ^ -246860720)
				{
				case 2:
					break;
				case 1:
					throw new Exception();
				case 0:
					goto IL_0047;
				default:
					CLjmYleEuCraJMMUJEFwtuAaGlg = default(KeyValuePair<TKey, TValue>);
					return;
				}
				goto IL_0018;
				IL_0047:
				VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
				num = -246860717;
				goto IL_001d;
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
				private IndexedDictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

				private int VgtGZGVNuFqErLJXYsgetKqIFWC;

				private int EygMDwDKOyuDPoDuSCVwhlkKZwkB;

				private TKey INSXFvKINlnifElhwbRPpEuydSv;

				public TKey Current
				{
					get
					{
						return INSXFvKINlnifElhwbRPpEuydSv;
					}
				}

				object IEnumerator.Current
				{
					get
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
						{
							if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1)
							{
								goto IL_004d;
							}
							while (true)
							{
								switch (0x2571C487 ^ 0x2571C486)
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
						return INSXFvKINlnifElhwbRPpEuydSv;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
					EygMDwDKOyuDPoDuSCVwhlkKZwkB = dictionary.nRmHtmCTLMujsmHWTvkVqllSHbd.Version;
					VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
					INSXFvKINlnifElhwbRPpEuydSv = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd.Version)
					{
						throw new Exception();
					}
					while ((uint)VgtGZGVNuFqErLJXYsgetKqIFWC < (uint)kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count)
					{
						INSXFvKINlnifElhwbRPpEuydSv = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items[VgtGZGVNuFqErLJXYsgetKqIFWC].eZCuZcaXadasLLacRQKJXebMgIEg;
						int num = 1381165053;
						while (true)
						{
							switch (num ^ 0x5252E7FC)
							{
							case 0:
								goto IL_001e;
							case 2:
								break;
							default:
								VgtGZGVNuFqErLJXYsgetKqIFWC++;
								return true;
							}
							break;
							IL_001e:
							num = 1381165054;
						}
					}
					VgtGZGVNuFqErLJXYsgetKqIFWC = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1;
					INSXFvKINlnifElhwbRPpEuydSv = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd.Version)
					{
						goto IL_0018;
					}
					goto IL_0047;
					IL_0018:
					int num = -1858361489;
					goto IL_001d;
					IL_001d:
					switch (num ^ -1858361492)
					{
					case 2:
						break;
					case 3:
						throw new Exception();
					case 0:
						goto IL_0047;
					default:
						INSXFvKINlnifElhwbRPpEuydSv = default(TKey);
						return;
					}
					goto IL_0018;
					IL_0047:
					VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
					num = -1858361491;
					goto IL_001d;
				}
			}

			private IndexedDictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

			public int Count
			{
				get
				{
					return kByLbWRXiXsWnZdJKBoJqLwPfkS.Count;
				}
			}

			bool ICollection<TKey>.IsReadOnly
			{
				get
				{
					return true;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)kByLbWRXiXsWnZdJKBoJqLwPfkS).SyncRoot;
				}
			}

			public KeyCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				while (true)
				{
					switch (-73453377 ^ -73453379)
					{
					case 0:
						continue;
					case 2:
						if (dictionary == null)
						{
							throw new ArgumentNullException("dictionary");
						}
						break;
					}
					break;
				}
				kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(kByLbWRXiXsWnZdJKBoJqLwPfkS);
			}

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					goto IL_0003;
				}
				goto IL_0069;
				IL_0003:
				int num = -344221434;
				goto IL_0008;
				IL_0008:
				int count = default(int);
				zAvfWGRctzEUQXnaVBnrdAWTR[] items = default(zAvfWGRctzEUQXnaVBnrdAWTR[]);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -344221436)
					{
					case 3:
						break;
					case 2:
						throw new ArgumentNullException("array");
					case 6:
						if (array.Length - index < kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
						{
							throw new Exception();
						}
						goto case 4;
					case 1:
						goto IL_0069;
					case 4:
						count = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count;
						items = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items;
						num2 = 0;
						num = -344221436;
						continue;
					case 5:
						array[index++] = items[num2].eZCuZcaXadasLLacRQKJXebMgIEg;
						num2++;
						num = -344221436;
						continue;
					case 7:
						goto IL_00d8;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
				goto IL_0003;
				IL_0069:
				if (index >= 0)
				{
					int num3;
					if (index <= array.Length)
					{
						num = -344221438;
						num3 = num;
					}
					else
					{
						num = -344221437;
						num3 = num;
					}
					goto IL_0008;
				}
				goto IL_00d8;
				IL_00d8:
				throw new ArgumentOutOfRangeException("index");
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
				return kByLbWRXiXsWnZdJKBoJqLwPfkS.ContainsKey(item);
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(kByLbWRXiXsWnZdJKBoJqLwPfkS);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(kByLbWRXiXsWnZdJKBoJqLwPfkS);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				object[] array3 = default(object[]);
				while (array.Rank == 1)
				{
					while (true)
					{
						IL_008c:
						if (array.GetLowerBound(0) == 0)
						{
							while (true)
							{
								if (index >= 0)
								{
									int num;
									int num2;
									if (index <= array.Length)
									{
										num = 214595711;
										num2 = num;
									}
									else
									{
										num = 214595702;
										num2 = num;
									}
									while (true)
									{
										switch (num ^ 0xCCA787F)
										{
										case 3:
											num = 214595709;
											continue;
										case 7:
											break;
										case 9:
											goto IL_0069;
										case 2:
											goto end_IL_004b;
										case 1:
											goto IL_008c;
										case 6:
											throw new Exception();
										case 5:
											array3 = array as object[];
											if (array3 == null)
											{
												throw new Exception();
											}
											goto default;
										case 8:
										{
											TKey[] array2 = array as TKey[];
											if (array2 != null)
											{
												CopyTo(array2, index);
												return;
											}
											goto case 5;
										}
										case 0:
											goto IL_00ec;
										default:
										{
											int count = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count;
											zAvfWGRctzEUQXnaVBnrdAWTR[] items = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items;
											try
											{
												int num3 = 0;
												while (true)
												{
													int num4;
													int num5;
													if (num3 < count)
													{
														num4 = 214595709;
														num5 = num4;
													}
													else
													{
														num4 = 214595707;
														num5 = num4;
													}
													while (true)
													{
														switch (num4 ^ 0xCCA787F)
														{
														case 0:
															num4 = 214595709;
															continue;
														default:
															return;
														case 2:
															array3[index++] = items[num3].eZCuZcaXadasLLacRQKJXebMgIEg;
															num4 = 214595710;
															continue;
														case 1:
															num3++;
															num4 = 214595708;
															continue;
														case 3:
															break;
														case 4:
															return;
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
										IL_00ec:
										int num6;
										if (array.Length - index >= kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
										{
											num = 214595703;
											num6 = num;
										}
										else
										{
											num = 214595705;
											num6 = num;
										}
									}
									continue;
								}
								goto IL_0069;
								IL_0069:
								throw new Exception();
								continue;
								end_IL_004b:
								break;
							}
							break;
						}
						throw new Exception();
					}
				}
				throw new Exception();
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private IndexedDictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

				private int VgtGZGVNuFqErLJXYsgetKqIFWC;

				private int EygMDwDKOyuDPoDuSCVwhlkKZwkB;

				private TValue TrSwHWtMEpzOZTvGxWBBPsvwXGo;

				public TValue Current
				{
					get
					{
						return TrSwHWtMEpzOZTvGxWBBPsvwXGo;
					}
				}

				object IEnumerator.Current
				{
					get
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
						{
							if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1)
							{
								goto IL_004d;
							}
							while (true)
							{
								switch (-1329377642 ^ -1329377641)
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
						return TrSwHWtMEpzOZTvGxWBBPsvwXGo;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
					EygMDwDKOyuDPoDuSCVwhlkKZwkB = dictionary.nRmHtmCTLMujsmHWTvkVqllSHbd.Version;
					VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
					TrSwHWtMEpzOZTvGxWBBPsvwXGo = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd.Version)
					{
						throw new Exception();
					}
					while ((uint)VgtGZGVNuFqErLJXYsgetKqIFWC >= (uint)kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count)
					{
						VgtGZGVNuFqErLJXYsgetKqIFWC = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count + 1;
						int num = -406857676;
						while (true)
						{
							switch (num ^ -406857676)
							{
							case 2:
								goto IL_001e;
							case 1:
								break;
							default:
								TrSwHWtMEpzOZTvGxWBBPsvwXGo = default(TValue);
								return false;
							}
							break;
							IL_001e:
							num = -406857675;
						}
					}
					TrSwHWtMEpzOZTvGxWBBPsvwXGo = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items[VgtGZGVNuFqErLJXYsgetKqIFWC].kXoKOSZJMKwATOiGMaylYIDqdDnb;
					VgtGZGVNuFqErLJXYsgetKqIFWC++;
					return true;
				}

				void IEnumerator.Reset()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd.Version)
					{
						throw new Exception();
					}
					while (true)
					{
						VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
						int num = -1167606813;
						while (true)
						{
							switch (num ^ -1167606815)
							{
							case 0:
								goto IL_001e;
							case 1:
								break;
							default:
								TrSwHWtMEpzOZTvGxWBBPsvwXGo = default(TValue);
								return;
							}
							break;
							IL_001e:
							num = -1167606816;
						}
					}
				}
			}

			private IndexedDictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

			public int Count
			{
				get
				{
					return kByLbWRXiXsWnZdJKBoJqLwPfkS.Count;
				}
			}

			bool ICollection<TValue>.IsReadOnly
			{
				get
				{
					return true;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					return ((ICollection)kByLbWRXiXsWnZdJKBoJqLwPfkS).SyncRoot;
				}
			}

			public ValueCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(kByLbWRXiXsWnZdJKBoJqLwPfkS);
			}

			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				int count = default(int);
				zAvfWGRctzEUQXnaVBnrdAWTR[] items = default(zAvfWGRctzEUQXnaVBnrdAWTR[]);
				int num3 = default(int);
				while (true)
				{
					if (index >= 0)
					{
						int num;
						int num2;
						if (index <= array.Length)
						{
							num = 614169029;
							num2 = num;
						}
						else
						{
							num = 614169037;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x249B79C5)
							{
							case 7:
								num = 614169028;
								continue;
							case 1:
								break;
							case 5:
								count = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count;
								items = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items;
								num = 614169025;
								continue;
							case 4:
								num3 = 0;
								num = 614169030;
								continue;
							case 2:
								array[index++] = items[num3].kXoKOSZJMKwATOiGMaylYIDqdDnb;
								num = 614169027;
								continue;
							case 6:
								num3++;
								num = 614169030;
								continue;
							case 0:
								if (array.Length - index < kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
								{
									throw new Exception();
								}
								goto case 5;
							case 8:
								goto IL_00ec;
							default:
								if (num3 >= count)
								{
									return;
								}
								goto case 2;
							}
							break;
						}
						continue;
					}
					goto IL_00ec;
					IL_00ec:
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
				return kByLbWRXiXsWnZdJKBoJqLwPfkS.ContainsValue(item);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(kByLbWRXiXsWnZdJKBoJqLwPfkS);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(kByLbWRXiXsWnZdJKBoJqLwPfkS);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					goto IL_0003;
				}
				goto IL_0051;
				IL_0003:
				int num = 464753020;
				goto IL_0008;
				IL_0008:
				object[] array2 = default(object[]);
				while (true)
				{
					switch (num ^ 0x1BB3917F)
					{
					case 6:
						break;
					case 8:
						goto IL_0044;
					case 7:
						goto IL_0051;
					case 4:
					{
						TValue[] array3 = array as TValue[];
						if (array3 != null)
						{
							CopyTo(array3, index);
							return;
						}
						goto IL_0091;
					}
					case 5:
						throw new Exception();
					case 1:
						goto IL_0091;
					case 0:
						goto IL_00af;
					case 10:
						goto IL_00d0;
					case 3:
						throw new ArgumentNullException("array");
					case 2:
						if (array.Length - index < kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
						{
							throw new Exception();
						}
						goto case 4;
					default:
					{
						int count = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._count;
						zAvfWGRctzEUQXnaVBnrdAWTR[] items = kByLbWRXiXsWnZdJKBoJqLwPfkS.nRmHtmCTLMujsmHWTvkVqllSHbd._items;
						try
						{
							int num2 = 0;
							while (num2 < count)
							{
								while (true)
								{
									array2[index++] = items[num2].kXoKOSZJMKwATOiGMaylYIDqdDnb;
									int num3 = 464753021;
									while (true)
									{
										switch (num3 ^ 0x1BB3917F)
										{
										case 0:
											num3 = 464753022;
											continue;
										case 1:
											break;
										case 2:
											num2++;
											num3 = 464753020;
											continue;
										default:
											goto end_IL_016f;
										}
										break;
									}
									continue;
									end_IL_016f:
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
					IL_0091:
					array2 = array as object[];
					int num4;
					if (array2 != null)
					{
						num = 464753014;
						num4 = num;
					}
					else
					{
						num = 464753018;
						num4 = num;
					}
				}
				goto IL_0003;
				IL_0051:
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				goto IL_00d0;
				IL_00af:
				if (index >= 0)
				{
					int num5;
					if (index > array.Length)
					{
						num = 464753015;
						num5 = num;
					}
					else
					{
						num = 464753021;
						num5 = num;
					}
					goto IL_0008;
				}
				goto IL_0044;
				IL_00d0:
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				goto IL_00af;
				IL_0044:
				throw new Exception();
			}
		}

		private static readonly bool lvyLiqaRKEntfLPHVcBclEAmheAK = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool ZzQFuzoumExvsjduzBNBZJbXJDc = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> lZfPLCqrrbEgPDNPlDAoALVQnvj = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> BakwdxKAwdnMTrIEiIUPFkGxcZD = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<zAvfWGRctzEUQXnaVBnrdAWTR> nRmHtmCTLMujsmHWTvkVqllSHbd;

		private readonly ADictionary<TKey, int> VYeDHflAiLPvrotxXWQztthwgpt;

		private bool qgVhUjPKzeRGBPfxOTYzppkXegn;

		public int Count
		{
			get
			{
				return nRmHtmCTLMujsmHWTvkVqllSHbd._count;
			}
		}

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!qgVhUjPKzeRGBPfxOTYzppkXegn)
				{
					return false;
				}
				return VYeDHflAiLPvrotxXWQztthwgpt._count < nRmHtmCTLMujsmHWTvkVqllSHbd._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return qgVhUjPKzeRGBPfxOTYzppkXegn;
			}
			set
			{
				if (qgVhUjPKzeRGBPfxOTYzppkXegn == value)
				{
					return;
				}
				while (true)
				{
					qgVhUjPKzeRGBPfxOTYzppkXegn = value;
					int num = 1392845433;
					while (true)
					{
						switch (num ^ 0x53052279)
						{
						case 3:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							if (!value && ContainsDuplicateKeys)
							{
								throw new Exception("The dictionary contains duplicate keys and cannot be changed unless the keys are removed.");
							}
							return;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = 1392845432;
					}
				}
			}
		}

		public TValue this[int index]
		{
			get
			{
				if ((uint)index >= (uint)nRmHtmCTLMujsmHWTvkVqllSHbd._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return nRmHtmCTLMujsmHWTvkVqllSHbd._items[index].kXoKOSZJMKwATOiGMaylYIDqdDnb;
			}
			set
			{
				if ((uint)index >= (uint)nRmHtmCTLMujsmHWTvkVqllSHbd._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				nRmHtmCTLMujsmHWTvkVqllSHbd._items[index].kXoKOSZJMKwATOiGMaylYIDqdDnb = value;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return lZfPLCqrrbEgPDNPlDAoALVQnvj;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
					goto IL_000a;
				}
				goto IL_0028;
				IL_0028:
				lZfPLCqrrbEgPDNPlDAoALVQnvj = value;
				int num = 2108988937;
				goto IL_000f;
				IL_000a:
				num = 2108988938;
				goto IL_000f;
				IL_000f:
				switch (num ^ 0x7DB49E08)
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

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return BakwdxKAwdnMTrIEiIUPFkGxcZD;
			}
			set
			{
				if (value == null)
				{
					while (true)
					{
						int num = 157833925;
						while (true)
						{
							switch (num ^ 0x9685AC4)
							{
							case 0:
								break;
							case 1:
								value = EqualityComparerNoAlloc<TValue>.Default;
								num = 157833926;
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
				BakwdxKAwdnMTrIEiIUPFkGxcZD = value;
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return new KeyCollection(this);
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				return new ValueCollection(this);
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					throw new KeyNotFoundException(string.Concat("Key \"", key, "\" does not exist."));
				}
				return nRmHtmCTLMujsmHWTvkVqllSHbd._items[num].kXoKOSZJMKwATOiGMaylYIDqdDnb;
			}
			set
			{
				SetValue(key, value);
			}
		}

		bool IDictionary.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		bool IDictionary.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		ICollection IDictionary.Keys
		{
			get
			{
				return new KeyCollection(this);
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				return new ValueCollection(this);
			}
		}

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

		bool ICollection.IsSynchronized
		{
			get
			{
				return ((ICollection)nRmHtmCTLMujsmHWTvkVqllSHbd).IsSynchronized;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return ((ICollection)nRmHtmCTLMujsmHWTvkVqllSHbd).SyncRoot;
			}
		}

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int P_0]
		{
			get
			{
				return this[P_0];
			}
		}

		int IReadOnlyList.Count
		{
			get
			{
				return Count;
			}
		}

		object IReadOnlyList.this[int P_0]
		{
			get
			{
				return this[P_0];
			}
		}

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
			qgVhUjPKzeRGBPfxOTYzppkXegn = allowDuplicateKeys;
			nRmHtmCTLMujsmHWTvkVqllSHbd = new AList<zAvfWGRctzEUQXnaVBnrdAWTR>(capacity);
			VYeDHflAiLPvrotxXWQztthwgpt = new ADictionary<TKey, int>(capacity);
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
				for (int i = 0; i < indexedDictionary.nRmHtmCTLMujsmHWTvkVqllSHbd._count; i++)
				{
					Add(indexedDictionary.nRmHtmCTLMujsmHWTvkVqllSHbd._items[i].eZCuZcaXadasLLacRQKJXebMgIEg, indexedDictionary.nRmHtmCTLMujsmHWTvkVqllSHbd._items[i].kXoKOSZJMKwATOiGMaylYIDqdDnb);
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
			return nRmHtmCTLMujsmHWTvkVqllSHbd._items[VYeDHflAiLPvrotxXWQztthwgpt[key]].kXoKOSZJMKwATOiGMaylYIDqdDnb;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int value2;
			if (!VYeDHflAiLPvrotxXWQztthwgpt.TryGetValue(key, out value2))
			{
				value = default(TValue);
				return false;
			}
			value = nRmHtmCTLMujsmHWTvkVqllSHbd._items[value2].kXoKOSZJMKwATOiGMaylYIDqdDnb;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)nRmHtmCTLMujsmHWTvkVqllSHbd._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return nRmHtmCTLMujsmHWTvkVqllSHbd[index].eZCuZcaXadasLLacRQKJXebMgIEg;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return nRmHtmCTLMujsmHWTvkVqllSHbd[VYeDHflAiLPvrotxXWQztthwgpt[key]].uaWVzCFMhTzjLiLjeeZWDfxsKmC();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)nRmHtmCTLMujsmHWTvkVqllSHbd._count)
			{
				goto IL_000e;
			}
			goto IL_0042;
			IL_000e:
			int num = 768751808;
			goto IL_0013;
			IL_0013:
			zAvfWGRctzEUQXnaVBnrdAWTR zAvfWGRctzEUQXnaVBnrdAWTR2 = default(zAvfWGRctzEUQXnaVBnrdAWTR);
			switch (num ^ 0x2DD238C1)
			{
			case 3:
				break;
			case 1:
				throw new ArgumentOutOfRangeException("index");
			case 2:
				goto IL_0042;
			default:
				return zAvfWGRctzEUQXnaVBnrdAWTR2.uaWVzCFMhTzjLiLjeeZWDfxsKmC();
			}
			goto IL_000e;
			IL_0042:
			zAvfWGRctzEUQXnaVBnrdAWTR2 = nRmHtmCTLMujsmHWTvkVqllSHbd[index];
			num = 768751809;
			goto IL_0013;
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			int value;
			if (!VYeDHflAiLPvrotxXWQztthwgpt.TryGetValue(key, out value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = nRmHtmCTLMujsmHWTvkVqllSHbd[value].uaWVzCFMhTzjLiLjeeZWDfxsKmC();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool flag = VYeDHflAiLPvrotxXWQztthwgpt.ContainsKey(key);
			int value2 = default(int);
			while (true)
			{
				int num = -843710172;
				while (true)
				{
					switch (num ^ -843710176)
					{
					case 2:
						break;
					case 6:
						value2 = nRmHtmCTLMujsmHWTvkVqllSHbd.Add(new zAvfWGRctzEUQXnaVBnrdAWTR(key, value));
						if (flag)
						{
							VYeDHflAiLPvrotxXWQztthwgpt[key] = value2;
							num = -843710173;
							continue;
						}
						goto default;
					case 0:
						throw new ArgumentException(string.Concat("Key \"", key, "\" is already in use."));
					case 5:
					{
						int num3;
						if (qgVhUjPKzeRGBPfxOTYzppkXegn)
						{
							num = -843710170;
							num3 = num;
						}
						else
						{
							num = -843710176;
							num3 = num;
						}
						continue;
					}
					case 3:
						return;
					case 4:
					{
						int num2;
						if (!flag)
						{
							num = -843710170;
							num2 = num;
						}
						else
						{
							num = -843710171;
							num2 = num;
						}
						continue;
					}
					default:
						VYeDHflAiLPvrotxXWQztthwgpt.Add(key, value2);
						return;
					}
					break;
				}
			}
		}

		public void SetValue(TKey key, TValue value)
		{
			int value2;
			if (VYeDHflAiLPvrotxXWQztthwgpt.TryGetValue(key, out value2))
			{
				nRmHtmCTLMujsmHWTvkVqllSHbd._items[value2].kXoKOSZJMKwATOiGMaylYIDqdDnb = value;
				VYeDHflAiLPvrotxXWQztthwgpt[key] = value2;
			}
			else
			{
				Add(key, value);
			}
		}

		public bool Remove(TKey key)
		{
			VYeDHflAiLPvrotxXWQztthwgpt.Remove(key);
			bool result = default(bool);
			int num2 = default(int);
			if (qgVhUjPKzeRGBPfxOTYzppkXegn)
			{
				while (true)
				{
					int num = -608935910;
					while (true)
					{
						switch (num ^ -608935905)
						{
						case 0:
							break;
						case 5:
							result = false;
							num2 = nRmHtmCTLMujsmHWTvkVqllSHbd._count - 1;
							num = -608935908;
							continue;
						case 4:
							num2--;
							num = -608935908;
							continue;
						case 2:
							nRmHtmCTLMujsmHWTvkVqllSHbd.RemoveAt(num2);
							result = true;
							num = -608935909;
							continue;
						case 1:
						{
							int num3;
							if (lZfPLCqrrbEgPDNPlDAoALVQnvj.Equals(nRmHtmCTLMujsmHWTvkVqllSHbd._items[num2].eZCuZcaXadasLLacRQKJXebMgIEg, key))
							{
								num = -608935907;
								num3 = num;
							}
							else
							{
								num = -608935909;
								num3 = num;
							}
							continue;
						}
						default:
							if (num2 < 0)
							{
								return result;
							}
							goto case 1;
						}
						break;
					}
				}
			}
			int num4 = IndexOfKey(key);
			if (num4 < 0)
			{
				return false;
			}
			RemoveAt(num4);
			return true;
		}

		public void RemoveAt(int index)
		{
			if ((uint)index >= (uint)nRmHtmCTLMujsmHWTvkVqllSHbd._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey eZCuZcaXadasLLacRQKJXebMgIEg;
			while (true)
			{
				eZCuZcaXadasLLacRQKJXebMgIEg = nRmHtmCTLMujsmHWTvkVqllSHbd._items[index].eZCuZcaXadasLLacRQKJXebMgIEg;
				if (index >= nRmHtmCTLMujsmHWTvkVqllSHbd._count - 1)
				{
					break;
				}
				int num = index + 1;
				int num2 = -1163341253;
				while (true)
				{
					switch (num2 ^ -1163341255)
					{
					case 0:
						num2 = -1163341256;
						continue;
					case 1:
						break;
					case 3:
						VYeDHflAiLPvrotxXWQztthwgpt[nRmHtmCTLMujsmHWTvkVqllSHbd._items[num].eZCuZcaXadasLLacRQKJXebMgIEg] = num - 1;
						num++;
						num2 = -1163341253;
						continue;
					case 2:
						goto IL_00a6;
					default:
						goto end_IL_0042;
					}
					break;
					IL_00a6:
					int num3;
					if (num < nRmHtmCTLMujsmHWTvkVqllSHbd.Count)
					{
						num2 = -1163341254;
						num3 = num2;
					}
					else
					{
						num2 = -1163341251;
						num3 = num2;
					}
				}
				continue;
				end_IL_0042:
				break;
			}
			nRmHtmCTLMujsmHWTvkVqllSHbd.RemoveAt(index);
			VYeDHflAiLPvrotxXWQztthwgpt.Remove(eZCuZcaXadasLLacRQKJXebMgIEg);
		}

		public void RemoveValue(TValue value)
		{
			int num = IndexOfValue(value);
			if (num < 0)
			{
				return;
			}
			while (true)
			{
				TKey eZCuZcaXadasLLacRQKJXebMgIEg = nRmHtmCTLMujsmHWTvkVqllSHbd._items[num].eZCuZcaXadasLLacRQKJXebMgIEg;
				int num2 = -541773920;
				while (true)
				{
					switch (num2 ^ -541773919)
					{
					case 0:
						goto IL_000d;
					case 2:
						break;
					default:
						RemoveAt(num);
						return;
					}
					break;
					IL_000d:
					num2 = -541773917;
				}
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				int num2 = -2004819379;
				while (true)
				{
					switch (num2 ^ -2004819384)
					{
					case 7:
						break;
					case 6:
						if (BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(nRmHtmCTLMujsmHWTvkVqllSHbd._items[num3].kXoKOSZJMKwATOiGMaylYIDqdDnb, value))
						{
							RemoveAt(num3);
							num2 = -2004819381;
							continue;
						}
						goto case 4;
					case 1:
						num3 = count - 1;
						num2 = -2004819384;
						continue;
					case 5:
						count = nRmHtmCTLMujsmHWTvkVqllSHbd._count;
						num2 = -2004819383;
						continue;
					case 3:
						num++;
						num2 = -2004819380;
						continue;
					case 2:
					{
						TKey eZCuZcaXadasLLacRQKJXebMgIEg = nRmHtmCTLMujsmHWTvkVqllSHbd._items[num3].eZCuZcaXadasLLacRQKJXebMgIEg;
						num2 = -2004819378;
						continue;
					}
					case 4:
						num3--;
						num2 = -2004819384;
						continue;
					default:
						if (num3 < 0)
						{
							return num;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int IndexOfKey(TKey key)
		{
			if (!lvyLiqaRKEntfLPHVcBclEAmheAK && key == null)
			{
				goto IL_000f;
			}
			goto IL_006a;
			IL_006a:
			int count = nRmHtmCTLMujsmHWTvkVqllSHbd._count;
			int num = 0;
			int num2 = 2040599479;
			goto IL_0014;
			IL_000f:
			num2 = 2040599478;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num2 ^ 0x79A113B7)
				{
				case 5:
					break;
				case 2:
					goto IL_0039;
				case 3:
					goto IL_006a;
				case 0:
					goto IL_007f;
				case 1:
					throw new ArgumentNullException("key");
				default:
					return -1;
				}
				break;
				IL_007f:
				int num3;
				if (num >= count)
				{
					num2 = 2040599475;
					num3 = num2;
				}
				else
				{
					num2 = 2040599477;
					num3 = num2;
				}
				continue;
				IL_0039:
				if (lZfPLCqrrbEgPDNPlDAoALVQnvj.Equals(nRmHtmCTLMujsmHWTvkVqllSHbd._items[num].eZCuZcaXadasLLacRQKJXebMgIEg, key))
				{
					return num;
				}
				num++;
				num2 = 2040599479;
			}
			goto IL_000f;
		}

		public int IndexOfValue(TValue value)
		{
			int count = nRmHtmCTLMujsmHWTvkVqllSHbd._count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = 493984917;
					num3 = num2;
				}
				else
				{
					num2 = 493984919;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1D719C94)
					{
					case 0:
						num2 = 493984919;
						continue;
					case 3:
						if (BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(nRmHtmCTLMujsmHWTvkVqllSHbd._items[num].kXoKOSZJMKwATOiGMaylYIDqdDnb, value))
						{
							return num;
						}
						num++;
						num2 = 493984918;
						continue;
					case 2:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public bool ContainsKey(TKey key)
		{
			return VYeDHflAiLPvrotxXWQztthwgpt.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			nRmHtmCTLMujsmHWTvkVqllSHbd.Clear();
			VYeDHflAiLPvrotxXWQztthwgpt.Clear();
		}

		public void TrimExcess()
		{
			nRmHtmCTLMujsmHWTvkVqllSHbd.TrimExcess();
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
			zAvfWGRctzEUQXnaVBnrdAWTR zAvfWGRctzEUQXnaVBnrdAWTR2 = nRmHtmCTLMujsmHWTvkVqllSHbd._items[num];
			int num2 = 1733840302;
			goto IL_0017;
			IL_0017:
			switch (num2 ^ 0x67584DAC)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(item.Value, zAvfWGRctzEUQXnaVBnrdAWTR2.kXoKOSZJMKwATOiGMaylYIDqdDnb);
			}
			goto IL_0012;
			IL_0012:
			num2 = 1733840301;
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
					if (index <= array.Length)
					{
						num = -1379872054;
						num2 = num;
					}
					else
					{
						num = -1379872049;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1379872052)
						{
						case 2:
							num = -1379872051;
							continue;
						case 6:
							break;
						case 4:
							num3++;
							num = -1379872060;
							continue;
						case 1:
							goto end_IL_0013;
						case 5:
							throw new Exception();
						case 0:
							array[index++] = new KeyValuePair<TKey, TValue>(nRmHtmCTLMujsmHWTvkVqllSHbd._items[num3].eZCuZcaXadasLLacRQKJXebMgIEg, nRmHtmCTLMujsmHWTvkVqllSHbd._items[num3].kXoKOSZJMKwATOiGMaylYIDqdDnb);
							num = -1379872056;
							continue;
						case 3:
							goto IL_00e7;
						case 7:
							count = nRmHtmCTLMujsmHWTvkVqllSHbd._count;
							num3 = 0;
							num = -1379872060;
							continue;
						default:
							if (num3 >= count)
							{
								return;
							}
							goto case 0;
						}
						int num4;
						if (array.Length - index < Count)
						{
							num = -1379872055;
							num4 = num;
						}
						else
						{
							num = -1379872053;
							num4 = num;
						}
						continue;
						end_IL_0013:
						break;
					}
					continue;
				}
				goto IL_00e7;
				IL_00e7:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			bool result = default(bool);
			int num = default(int);
			if (qgVhUjPKzeRGBPfxOTYzppkXegn)
			{
				result = false;
				num = nRmHtmCTLMujsmHWTvkVqllSHbd._count - 1;
				goto IL_00c4;
			}
			int num2 = IndexOfKey(item.Key);
			if (num2 < 0)
			{
				return false;
			}
			zAvfWGRctzEUQXnaVBnrdAWTR zAvfWGRctzEUQXnaVBnrdAWTR2 = nRmHtmCTLMujsmHWTvkVqllSHbd._items[num2];
			int num3 = 770218835;
			goto IL_0022;
			IL_00c4:
			int num4;
			if (num >= 0)
			{
				num3 = 770218833;
				num4 = num3;
			}
			else
			{
				num3 = 770218847;
				num4 = num3;
			}
			goto IL_0022;
			IL_0022:
			zAvfWGRctzEUQXnaVBnrdAWTR zAvfWGRctzEUQXnaVBnrdAWTR3 = default(zAvfWGRctzEUQXnaVBnrdAWTR);
			while (true)
			{
				switch (num3 ^ 0x2DE89B57)
				{
				case 0:
					num3 = 770218833;
					continue;
				case 8:
					return result;
				case 1:
					num--;
					num3 = 770218836;
					continue;
				case 4:
					if (!BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(item.Value, zAvfWGRctzEUQXnaVBnrdAWTR2.kXoKOSZJMKwATOiGMaylYIDqdDnb))
					{
						return false;
					}
					RemoveAt(num2);
					num3 = 770218832;
					continue;
				case 3:
					break;
				case 2:
				{
					int num5;
					if (BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(item.Value, zAvfWGRctzEUQXnaVBnrdAWTR3.kXoKOSZJMKwATOiGMaylYIDqdDnb))
					{
						num3 = 770218834;
						num5 = num3;
					}
					else
					{
						num3 = 770218838;
						num5 = num3;
					}
					continue;
				}
				case 5:
					nRmHtmCTLMujsmHWTvkVqllSHbd.RemoveAt(num);
					result = true;
					num3 = 770218838;
					continue;
				case 6:
					zAvfWGRctzEUQXnaVBnrdAWTR3 = nRmHtmCTLMujsmHWTvkVqllSHbd._items[num];
					num3 = 770218837;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_00c4;
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
				throw new ArgumentNullException("array");
			}
			int count = default(int);
			int num3 = default(int);
			while (true)
			{
				if (index >= 0)
				{
					int num;
					int num2;
					if (index > array.Length)
					{
						num = -2000273516;
						num2 = num;
					}
					else
					{
						num = -2000273519;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -2000273519)
						{
						case 4:
							num = -2000273520;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0061;
						case 5:
							goto IL_0082;
						case 6:
							throw new Exception();
						case 7:
							count = nRmHtmCTLMujsmHWTvkVqllSHbd._count;
							num3 = 0;
							num = -2000273518;
							continue;
						case 2:
							array.SetValue(new KeyValuePair<TKey, TValue>(nRmHtmCTLMujsmHWTvkVqllSHbd._items[num3].eZCuZcaXadasLLacRQKJXebMgIEg, nRmHtmCTLMujsmHWTvkVqllSHbd._items[num3].kXoKOSZJMKwATOiGMaylYIDqdDnb), index++);
							num3++;
							num = -2000273518;
							continue;
						default:
							if (num3 >= count)
							{
								return;
							}
							goto case 2;
						}
						break;
						IL_0061:
						int num4;
						if (array.Length - index >= Count)
						{
							num = -2000273514;
							num4 = num;
						}
						else
						{
							num = -2000273513;
							num4 = num;
						}
					}
					continue;
				}
				goto IL_0082;
				IL_0082:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			return ContainsValue(P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			return IndexOfValue((TValue)P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			return ContainsValue((TValue)P_0);
		}
	}
}
