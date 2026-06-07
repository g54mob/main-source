using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private ADictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

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
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (0x2349D98E ^ 0x2349D98C)
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
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (0x3CE27CB2 ^ 0x3CE27CB0)
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
					return new DictionaryEntry(CLjmYleEuCraJMMUJEFwtuAaGlg.Key, CLjmYleEuCraJMMUJEFwtuAaGlg.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-1806801259 ^ -1806801257)
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
					return CLjmYleEuCraJMMUJEFwtuAaGlg.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (VgtGZGVNuFqErLJXYsgetKqIFWC != 0)
					{
						if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-48298350 ^ -48298349)
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
					return CLjmYleEuCraJMMUJEFwtuAaGlg.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
				EygMDwDKOyuDPoDuSCVwhlkKZwkB = dictionary.HCKdygRhwCetItzVwbRsEqktGNve;
				VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
				zBtOmsIQrDkhrlaBuhnfGniszHA = getEnumeratorRetType;
				CLjmYleEuCraJMMUJEFwtuAaGlg = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.HCKdygRhwCetItzVwbRsEqktGNve)
				{
					goto IL_0016;
				}
				goto IL_00cf;
				IL_0016:
				int num = 1376355694;
				goto IL_001b;
				IL_001b:
				switch (num ^ 0x5209856D)
				{
				case 0:
					break;
				case 3:
					throw new Exception();
				case 2:
					goto IL_0048;
				default:
					goto IL_00cf;
				}
				goto IL_0016;
				IL_0048:
				if (kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].hashCode >= 0)
				{
					CLjmYleEuCraJMMUJEFwtuAaGlg = new KeyValuePair<TKey, TValue>(kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].key, kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].value);
					VgtGZGVNuFqErLJXYsgetKqIFWC++;
					return true;
				}
				VgtGZGVNuFqErLJXYsgetKqIFWC++;
				num = 1376355692;
				goto IL_001b;
				IL_00cf:
				if ((uint)VgtGZGVNuFqErLJXYsgetKqIFWC >= (uint)kByLbWRXiXsWnZdJKBoJqLwPfkS._count)
				{
					VgtGZGVNuFqErLJXYsgetKqIFWC = kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1;
					CLjmYleEuCraJMMUJEFwtuAaGlg = default(KeyValuePair<TKey, TValue>);
					return false;
				}
				goto IL_0048;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.HCKdygRhwCetItzVwbRsEqktGNve)
				{
					throw new Exception();
				}
				VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
				CLjmYleEuCraJMMUJEFwtuAaGlg = default(KeyValuePair<TKey, TValue>);
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
				private ADictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

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
							if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1)
							{
								goto IL_0048;
							}
							while (true)
							{
								switch (-722194895 ^ -722194896)
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
						return INSXFvKINlnifElhwbRPpEuydSv;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
					EygMDwDKOyuDPoDuSCVwhlkKZwkB = dictionary.HCKdygRhwCetItzVwbRsEqktGNve;
					VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
					INSXFvKINlnifElhwbRPpEuydSv = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.HCKdygRhwCetItzVwbRsEqktGNve)
					{
						throw new Exception();
					}
					while (true)
					{
						int num;
						int num2;
						if ((uint)VgtGZGVNuFqErLJXYsgetKqIFWC < (uint)kByLbWRXiXsWnZdJKBoJqLwPfkS._count)
						{
							num = -1334632726;
							num2 = num;
						}
						else
						{
							num = -1334632728;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1334632725)
							{
							case 4:
								num = -1334632726;
								continue;
							case 1:
								if (kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].hashCode >= 0)
								{
									INSXFvKINlnifElhwbRPpEuydSv = kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].key;
									num = -1334632727;
								}
								else
								{
									VgtGZGVNuFqErLJXYsgetKqIFWC++;
									num = -1334632725;
								}
								continue;
							case 0:
								break;
							case 2:
								VgtGZGVNuFqErLJXYsgetKqIFWC++;
								return true;
							default:
								VgtGZGVNuFqErLJXYsgetKqIFWC = kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1;
								INSXFvKINlnifElhwbRPpEuydSv = default(TKey);
								return false;
							}
							break;
						}
					}
				}

				void IEnumerator.Reset()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.HCKdygRhwCetItzVwbRsEqktGNve)
					{
						throw new Exception();
					}
					while (true)
					{
						VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
						int num = 549996164;
						while (true)
						{
							switch (num ^ 0x20C84685)
							{
							case 0:
								goto IL_0019;
							case 2:
								break;
							default:
								INSXFvKINlnifElhwbRPpEuydSv = default(TKey);
								return;
							}
							break;
							IL_0019:
							num = 549996167;
						}
					}
				}
			}

			private ADictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

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

			public KeyCollection(ADictionary<TKey, TValue> dictionary)
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

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				Entry[] entries = default(Entry[]);
				int num3 = default(int);
				int count = default(int);
				while (index >= 0)
				{
					int num;
					int num2;
					if (index > array.Length)
					{
						num = 1947784172;
						num2 = num;
					}
					else
					{
						num = 1947784171;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x7418D3EC)
						{
						case 4:
							num = 1947784170;
							continue;
						default:
							return;
						case 1:
							array[index++] = entries[num3].key;
							num = 1947784169;
							continue;
						case 0:
							break;
						case 8:
							goto IL_007f;
						case 7:
							if (array.Length - index < kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
							{
								throw new Exception();
							}
							goto case 3;
						case 6:
							goto end_IL_0016;
						case 5:
							num3++;
							num = 1947784164;
							continue;
						case 9:
							goto IL_00e2;
						case 3:
							count = kByLbWRXiXsWnZdJKBoJqLwPfkS._count;
							entries = kByLbWRXiXsWnZdJKBoJqLwPfkS._entries;
							num3 = 0;
							num = 1947784164;
							continue;
						case 2:
							return;
						}
						goto end_IL_00b6;
						IL_00e2:
						int num4;
						if (entries[num3].hashCode >= 0)
						{
							num = 1947784173;
							num4 = num;
						}
						else
						{
							num = 1947784169;
							num4 = num;
						}
						continue;
						IL_007f:
						int num5;
						if (num3 < count)
						{
							num = 1947784165;
							num5 = num;
						}
						else
						{
							num = 1947784174;
							num5 = num;
						}
						continue;
						end_IL_0016:
						break;
					}
					continue;
					end_IL_00b6:
					break;
				}
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
				TKey[] array3 = default(TKey[]);
				object[] array2 = default(object[]);
				while (array.Rank == 1)
				{
					while (true)
					{
						int num;
						int num2;
						if (array.GetLowerBound(0) != 0)
						{
							num = -701966312;
							num2 = num;
						}
						else
						{
							num = -701966318;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -701966306)
							{
							case 0:
								num = -701966314;
								continue;
							case 11:
								break;
							case 9:
								goto end_IL_0016;
							case 5:
								array3 = array as TKey[];
								num = -701966315;
								continue;
							case 7:
								goto IL_009d;
							case 10:
								CopyTo(array3, index);
								return;
							case 8:
								goto end_IL_0072;
							case 4:
								array2 = array as object[];
								num = -701966305;
								continue;
							case 1:
								if (array2 == null)
								{
									throw new Exception();
								}
								goto default;
							case 13:
								throw new Exception();
							case 12:
								if (index < 0)
								{
									goto case 13;
								}
								goto IL_012a;
							case 2:
								throw new Exception();
							case 6:
								throw new Exception();
							default:
							{
								int count = kByLbWRXiXsWnZdJKBoJqLwPfkS._count;
								Entry[] entries = kByLbWRXiXsWnZdJKBoJqLwPfkS._entries;
								try
								{
									int num3 = 0;
									while (true)
									{
										int num4 = -701966305;
										while (true)
										{
											switch (num4 ^ -701966306)
											{
											case 0:
												break;
											case 1:
												num4 = -701966307;
												continue;
											case 4:
											{
												int num5;
												if (entries[num3].hashCode < 0)
												{
													num4 = -701966309;
													num5 = num4;
												}
												else
												{
													num4 = -701966308;
													num5 = num4;
												}
												continue;
											}
											case 2:
												array2[index++] = entries[num3].key;
												num4 = -701966309;
												continue;
											case 5:
												num3++;
												num4 = -701966307;
												continue;
											default:
												if (num3 >= count)
												{
													return;
												}
												goto case 4;
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
							int num6;
							if (array3 != null)
							{
								num = -701966316;
								num6 = num;
							}
							else
							{
								num = -701966310;
								num6 = num;
							}
							continue;
							IL_012a:
							int num7;
							if (index > array.Length)
							{
								num = -701966317;
								num7 = num;
							}
							else
							{
								num = -701966311;
								num7 = num;
							}
							continue;
							IL_009d:
							int num8;
							if (array.Length - index >= kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
							{
								num = -701966309;
								num8 = num;
							}
							else
							{
								num = -701966308;
								num8 = num;
							}
							continue;
							end_IL_0016:
							break;
						}
						continue;
						end_IL_0072:
						break;
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
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private ADictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

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
							if (VgtGZGVNuFqErLJXYsgetKqIFWC != kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1)
							{
								goto IL_0048;
							}
							while (true)
							{
								switch (-200460065 ^ -200460067)
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
						return TrSwHWtMEpzOZTvGxWBBPsvwXGo;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					kByLbWRXiXsWnZdJKBoJqLwPfkS = dictionary;
					EygMDwDKOyuDPoDuSCVwhlkKZwkB = dictionary.HCKdygRhwCetItzVwbRsEqktGNve;
					VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
					TrSwHWtMEpzOZTvGxWBBPsvwXGo = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.HCKdygRhwCetItzVwbRsEqktGNve)
					{
						goto IL_0016;
					}
					goto IL_00ba;
					IL_0016:
					int num = 2110677257;
					goto IL_001b;
					IL_001b:
					switch (num ^ 0x7DCE6108)
					{
					case 0:
						break;
					case 1:
						throw new Exception();
					case 2:
						goto IL_0049;
					case 3:
						return true;
					default:
						goto IL_00ba;
					}
					goto IL_0016;
					IL_0049:
					if (kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].hashCode >= 0)
					{
						TrSwHWtMEpzOZTvGxWBBPsvwXGo = kByLbWRXiXsWnZdJKBoJqLwPfkS._entries[VgtGZGVNuFqErLJXYsgetKqIFWC].value;
						VgtGZGVNuFqErLJXYsgetKqIFWC++;
						num = 2110677259;
					}
					else
					{
						VgtGZGVNuFqErLJXYsgetKqIFWC++;
						num = 2110677260;
					}
					goto IL_001b;
					IL_00ba:
					if ((uint)VgtGZGVNuFqErLJXYsgetKqIFWC >= (uint)kByLbWRXiXsWnZdJKBoJqLwPfkS._count)
					{
						VgtGZGVNuFqErLJXYsgetKqIFWC = kByLbWRXiXsWnZdJKBoJqLwPfkS._count + 1;
						TrSwHWtMEpzOZTvGxWBBPsvwXGo = default(TValue);
						return false;
					}
					goto IL_0049;
				}

				void IEnumerator.Reset()
				{
					if (EygMDwDKOyuDPoDuSCVwhlkKZwkB != kByLbWRXiXsWnZdJKBoJqLwPfkS.HCKdygRhwCetItzVwbRsEqktGNve)
					{
						goto IL_0013;
					}
					goto IL_0042;
					IL_0013:
					int num = -6507882;
					goto IL_0018;
					IL_0018:
					switch (num ^ -6507884)
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
					VgtGZGVNuFqErLJXYsgetKqIFWC = 0;
					TrSwHWtMEpzOZTvGxWBBPsvwXGo = default(TValue);
					num = -6507883;
					goto IL_0018;
				}
			}

			private ADictionary<TKey, TValue> kByLbWRXiXsWnZdJKBoJqLwPfkS;

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

			public ValueCollection(ADictionary<TKey, TValue> dictionary)
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
				int num3 = default(int);
				int count = default(int);
				Entry[] entries = default(Entry[]);
				while (true)
				{
					int num;
					int num2;
					if (index < 0)
					{
						num = 689293191;
						num2 = num;
					}
					else
					{
						num = 689293198;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x2915C78E)
						{
						case 10:
							num = 689293189;
							continue;
						default:
							return;
						case 5:
							if (array.Length - index < kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
							{
								throw new Exception();
							}
							goto case 6;
						case 7:
						{
							int num5;
							if (num3 < count)
							{
								num = 689293190;
								num5 = num;
							}
							else
							{
								num = 689293199;
								num5 = num;
							}
							continue;
						}
						case 6:
							count = kByLbWRXiXsWnZdJKBoJqLwPfkS._count;
							num = 689293194;
							continue;
						case 2:
							num3++;
							num = 689293193;
							continue;
						case 4:
							entries = kByLbWRXiXsWnZdJKBoJqLwPfkS._entries;
							num3 = 0;
							num = 689293193;
							continue;
						case 3:
							array[index++] = entries[num3].value;
							num = 689293196;
							continue;
						case 9:
							throw new Exception();
						case 0:
						{
							int num6;
							if (index <= array.Length)
							{
								num = 689293195;
								num6 = num;
							}
							else
							{
								num = 689293191;
								num6 = num;
							}
							continue;
						}
						case 11:
							break;
						case 8:
						{
							int num4;
							if (entries[num3].hashCode >= 0)
							{
								num = 689293197;
								num4 = num;
							}
							else
							{
								num = 689293196;
								num4 = num;
							}
							continue;
						}
						case 1:
							return;
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
					throw new ArgumentNullException("array");
				}
				object[] array2 = default(object[]);
				while (true)
				{
					int num;
					int num2;
					if (array.Rank == 1)
					{
						num = -204987557;
						num2 = num;
					}
					else
					{
						num = -204987556;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -204987560)
						{
						case 2:
							num = -204987559;
							continue;
						case 0:
							if (index >= 0)
							{
								int num8;
								if (index > array.Length)
								{
									num = -204987567;
									num8 = num;
								}
								else
								{
									num = -204987555;
									num8 = num;
								}
								continue;
							}
							goto case 9;
						case 3:
							if (array.GetLowerBound(0) != 0)
							{
								throw new Exception();
							}
							goto case 0;
						case 4:
							throw new Exception();
						case 10:
							throw new Exception();
						case 6:
						{
							TValue[] array3 = array as TValue[];
							if (array3 != null)
							{
								CopyTo(array3, index);
								return;
							}
							goto case 11;
						}
						case 11:
						{
							array2 = array as object[];
							int num7;
							if (array2 != null)
							{
								num = -204987568;
								num7 = num;
							}
							else
							{
								num = -204987553;
								num7 = num;
							}
							continue;
						}
						case 5:
						{
							int num6;
							if (array.Length - index < kByLbWRXiXsWnZdJKBoJqLwPfkS.Count)
							{
								num = -204987566;
								num6 = num;
							}
							else
							{
								num = -204987554;
								num6 = num;
							}
							continue;
						}
						case 7:
							throw new Exception();
						case 1:
							break;
						case 9:
							throw new Exception();
						default:
						{
							int count = kByLbWRXiXsWnZdJKBoJqLwPfkS._count;
							Entry[] entries = kByLbWRXiXsWnZdJKBoJqLwPfkS._entries;
							try
							{
								int num3 = 0;
								while (true)
								{
									int num4;
									int num5;
									if (num3 < count)
									{
										num4 = -204987557;
										num5 = num4;
									}
									else
									{
										num4 = -204987560;
										num5 = num4;
									}
									while (true)
									{
										switch (num4 ^ -204987560)
										{
										case 4:
											num4 = -204987557;
											continue;
										default:
											return;
										case 1:
											break;
										case 2:
											num3++;
											num4 = -204987559;
											continue;
										case 3:
											if (entries[num3].hashCode >= 0)
											{
												array2[index++] = entries[num3].value;
												num4 = -204987558;
												continue;
											}
											goto case 2;
										case 0:
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
					}
				}
			}
		}

		private const string ZjxdEmGMPGiJZBEpwKKndOrgTHO = "Version";

		private const string JZqIcrseeArAFyouUzZhPIQUuHZ = "HashSize";

		private const string JNnRggOlMnaPqHRLPOckSkfzRlwf = "KeyValuePairs";

		private const string XCgfjhDiSpXAwmfeXjkiYvmKNsd = "Comparer";

		private int[] XBoHBatfaNRYfAAjOEmwDMYYvHQq;

		internal Entry[] _entries;

		internal int _count;

		private int HCKdygRhwCetItzVwbRsEqktGNve;

		private int BMfwedHdXCXpWuCUhMBSBZQTNoY;

		private int wJJTlzeMLICdcXRdYxNTRkcFtMK;

		private int qgWVVcJwKvNVYAdJOwKGWzbKMin;

		private IEqualityComparer<TKey> lZfPLCqrrbEgPDNPlDAoALVQnvj;

		private IEqualityComparer<TValue> BakwdxKAwdnMTrIEiIUPFkGxcZD;

		private KeyCollection yghEffJvJbdbfbnBGqRVBOCdycJl;

		private ValueCollection RPfEUpsuWWkQAYqzoyvrYHgxnBX;

		private readonly object QKvyaEXPQDXBJnyOvUMQktZhEwo = new object();

		private static readonly bool lvyLiqaRKEntfLPHVcBclEAmheAK = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool ZzQFuzoumExvsjduzBNBZJbXJDc = ReflectionTools.IsValueType(typeof(TValue));

		public int Count
		{
			get
			{
				return _count - qgWVVcJwKvNVYAdJOwKGWzbKMin;
			}
		}

		public int TotalCount
		{
			get
			{
				return _count;
			}
		}

		public KeyCollection Keys
		{
			get
			{
				if (yghEffJvJbdbfbnBGqRVBOCdycJl == null)
				{
					while (true)
					{
						int num = -884498019;
						while (true)
						{
							switch (num ^ -884498020)
							{
							case 0:
								break;
							case 1:
								yghEffJvJbdbfbnBGqRVBOCdycJl = new KeyCollection(this);
								num = -884498018;
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
				return yghEffJvJbdbfbnBGqRVBOCdycJl;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (RPfEUpsuWWkQAYqzoyvrYHgxnBX == null)
				{
					RPfEUpsuWWkQAYqzoyvrYHgxnBX = new ValueCollection(this);
				}
				return RPfEUpsuWWkQAYqzoyvrYHgxnBX;
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
				}
				lZfPLCqrrbEgPDNPlDAoALVQnvj = value;
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
					value = EqualityComparerNoAlloc<TValue>.Default;
					goto IL_000a;
				}
				goto IL_0028;
				IL_0028:
				BakwdxKAwdnMTrIEiIUPFkGxcZD = value;
				int num = 1438070044;
				goto IL_000f;
				IL_000a:
				num = 1438070047;
				goto IL_000f;
				IL_000f:
				switch (num ^ 0x55B7351D)
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
				NuvgggIjflOyKqLkTzupeYNltCvA(key, value, false);
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
						int num2 = 1461646681;
						while (true)
						{
							switch (num2 ^ 0x571EF559)
							{
							case 2:
								num2 = 1461646680;
								continue;
							case 1:
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
						if (_entries[num].hashCode >= 0)
						{
							return num;
						}
						num--;
						int num2 = -755159178;
						while (true)
						{
							switch (num2 ^ -755159180)
							{
							case 0:
								num2 = -755159179;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0029;
							}
							break;
						}
						continue;
						end_IL_0029:
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
				if (yghEffJvJbdbfbnBGqRVBOCdycJl == null)
				{
					while (true)
					{
						int num = 1618024929;
						while (true)
						{
							switch (num ^ 0x607119E0)
							{
							case 2:
								break;
							case 1:
								yghEffJvJbdbfbnBGqRVBOCdycJl = new KeyCollection(this);
								num = 1618024928;
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
				return yghEffJvJbdbfbnBGqRVBOCdycJl;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (RPfEUpsuWWkQAYqzoyvrYHgxnBX == null)
				{
					RPfEUpsuWWkQAYqzoyvrYHgxnBX = new ValueCollection(this);
				}
				return RPfEUpsuWWkQAYqzoyvrYHgxnBX;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			get
			{
				return false;
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
				return QKvyaEXPQDXBJnyOvUMQktZhEwo;
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
				return Keys;
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				return Values;
			}
		}

		object IDictionary.this[object key]
		{
			get
			{
				if (ejEQqDqaTGAvRfGoebrKzOgBTkD(key))
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
				oQmOdsOjSGWpkzaPhyeEUaULQhB<TValue>(value, "value");
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
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (capacity > 0)
			{
				dFyvOnKBbTYzKLbxHBbiIGdcrpeH(capacity);
			}
			lZfPLCqrrbEgPDNPlDAoALVQnvj = keyComparer ?? EqualityComparerNoAlloc<TKey>.Default;
			BakwdxKAwdnMTrIEiIUPFkGxcZD = valueComparer ?? EqualityComparerNoAlloc<TValue>.Default;
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
			: this((dictionary != null) ? dictionary.Count : 0, keyComparer)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			NuvgggIjflOyKqLkTzupeYNltCvA(key, value, true);
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
				int num = 1712778476;
				while (true)
				{
					switch (num ^ 0x6616ECED)
					{
					case 3:
						break;
					default:
						return;
					case 4:
						if (num2 >= XBoHBatfaNRYfAAjOEmwDMYYvHQq.Length)
						{
							Array.Clear(_entries, 0, _count);
							wJJTlzeMLICdcXRdYxNTRkcFtMK = -1;
							_count = 0;
							qgWVVcJwKvNVYAdJOwKGWzbKMin = 0;
							HCKdygRhwCetItzVwbRsEqktGNve++;
							BMfwedHdXCXpWuCUhMBSBZQTNoY++;
							num = 1712778477;
							continue;
						}
						goto case 2;
					case 2:
						XBoHBatfaNRYfAAjOEmwDMYYvHQq[num2] = -1;
						num2++;
						num = 1712778473;
						continue;
					case 1:
						num2 = 0;
						num = 1712778473;
						continue;
					case 0:
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
			if (!lvyLiqaRKEntfLPHVcBclEAmheAK && object.ReferenceEquals(key, null))
			{
				goto IL_001b;
			}
			goto IL_018c;
			IL_020d:
			return false;
			IL_001b:
			int num = -1665028826;
			goto IL_0020;
			IL_0020:
			int num3 = default(int);
			int num4 = default(int);
			int num5 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1665028825)
				{
				case 2:
					break;
				case 8:
					num3 = num4 % XBoHBatfaNRYfAAjOEmwDMYYvHQq.Length;
					num5 = -1;
					num = -1665028829;
					continue;
				case 5:
					goto IL_0074;
				case 6:
					_entries[num2].hashCode = -1;
					_entries[num2].next = wJJTlzeMLICdcXRdYxNTRkcFtMK;
					_entries[num2].key = default(TKey);
					_entries[num2].value = default(TValue);
					wJJTlzeMLICdcXRdYxNTRkcFtMK = num2;
					qgWVVcJwKvNVYAdJOwKGWzbKMin++;
					HCKdygRhwCetItzVwbRsEqktGNve++;
					return true;
				case 7:
					goto IL_0125;
				case 3:
					goto IL_016e;
				case 0:
					goto IL_018c;
				case 4:
					num2 = XBoHBatfaNRYfAAjOEmwDMYYvHQq[num3];
					num = -1665028818;
					continue;
				case 9:
					goto IL_01c4;
				case 1:
					throw new ArgumentNullException("key");
				case 10:
					num2 = _entries[num2].next;
					num = -1665028818;
					continue;
				default:
					goto IL_020d;
				}
				break;
				IL_01c4:
				int num6;
				if (num2 < 0)
				{
					num = -1665028820;
					num6 = num;
				}
				else
				{
					num = -1665028828;
					num6 = num;
				}
				continue;
				IL_0125:
				if (lZfPLCqrrbEgPDNPlDAoALVQnvj.Equals(_entries[num2].key, key))
				{
					if (num5 < 0)
					{
						XBoHBatfaNRYfAAjOEmwDMYYvHQq[num3] = _entries[num2].next;
						num = -1665028831;
						continue;
					}
					goto IL_0074;
				}
				goto IL_0119;
				IL_0119:
				num5 = num2;
				num = -1665028819;
				continue;
				IL_016e:
				if (_entries[num2].hashCode == num4)
				{
					num = -1665028832;
					continue;
				}
				goto IL_0119;
				IL_0074:
				_entries[num5].next = _entries[num2].next;
				num = -1665028831;
			}
			goto IL_001b;
			IL_018c:
			if (XBoHBatfaNRYfAAjOEmwDMYYvHQq != null)
			{
				num4 = lZfPLCqrrbEgPDNPlDAoALVQnvj.GetHashCode(key) & 0x7FFFFFFF;
				num = -1665028817;
				goto IL_0020;
			}
			goto IL_020d;
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
			if (num >= 0)
			{
				return _entries[num].value;
			}
			return default(TValue);
		}

		public int IndexOfKey(TKey key)
		{
			if (!lvyLiqaRKEntfLPHVcBclEAmheAK && object.ReferenceEquals(key, null))
			{
				throw new ArgumentNullException("key");
			}
			while (XBoHBatfaNRYfAAjOEmwDMYYvHQq != null)
			{
				int num = lZfPLCqrrbEgPDNPlDAoALVQnvj.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = XBoHBatfaNRYfAAjOEmwDMYYvHQq[num % XBoHBatfaNRYfAAjOEmwDMYYvHQq.Length];
				int num3 = -321395606;
				while (true)
				{
					switch (num3 ^ -321395606)
					{
					case 2:
						num3 = -321395605;
						continue;
					case 1:
						break;
					case 3:
						goto IL_0080;
					case 0:
						goto IL_00d1;
					default:
						goto end_IL_0049;
					}
					break;
					IL_00d1:
					int num4;
					if (num2 < 0)
					{
						num3 = -321395602;
						num4 = num3;
					}
					else
					{
						num3 = -321395607;
						num4 = num3;
					}
					continue;
					IL_0080:
					if (_entries[num2].hashCode == num && lZfPLCqrrbEgPDNPlDAoALVQnvj.Equals(_entries[num2].key, key))
					{
						return num2;
					}
					num2 = _entries[num2].next;
					num3 = -321395606;
				}
				continue;
				end_IL_0049:
				break;
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			Entry[] entries = _entries;
			if (ZzQFuzoumExvsjduzBNBZJbXJDc || value != null)
			{
				goto IL_007b;
			}
			int num = 0;
			goto IL_00dc;
			IL_00ff:
			int num2;
			if (entries[num].hashCode >= 0)
			{
				num2 = 990819615;
				goto IL_0022;
			}
			goto IL_00ce;
			IL_00ce:
			num++;
			num2 = 990819602;
			goto IL_0022;
			IL_00dc:
			if (num >= _count)
			{
				num2 = 990819611;
				goto IL_0022;
			}
			goto IL_00ff;
			IL_00b9:
			if (entries[num].value == null)
			{
				return num;
			}
			goto IL_00ce;
			IL_0022:
			int num3 = default(int);
			IEqualityComparer<TValue> bakwdxKAwdnMTrIEiIUPFkGxcZD = default(IEqualityComparer<TValue>);
			while (true)
			{
				switch (num2 ^ 0x3B0EB51A)
				{
				case 2:
					num2 = 990819603;
					continue;
				case 4:
					break;
				case 7:
					num2 = 990819614;
					continue;
				case 0:
					goto end_IL_0022;
				case 3:
					goto IL_008b;
				case 5:
					goto IL_00b9;
				case 8:
					goto IL_00dc;
				case 6:
					return num3;
				case 9:
					goto IL_00ff;
				default:
					return -1;
				}
				int num4;
				if (num3 >= _count)
				{
					num2 = 990819611;
					num4 = num2;
				}
				else
				{
					num2 = 990819609;
					num4 = num2;
				}
				continue;
				IL_008b:
				if (entries[num3].hashCode >= 0 && bakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(entries[num3].value, value))
				{
					num2 = 990819612;
					continue;
				}
				num3++;
				num2 = 990819614;
				continue;
				end_IL_0022:
				break;
			}
			goto IL_007b;
			IL_007b:
			bakwdxKAwdnMTrIEiIUPFkGxcZD = BakwdxKAwdnMTrIEiIUPFkGxcZD;
			num3 = 0;
			num2 = 990819613;
			goto IL_0022;
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
				while (true)
				{
					switch (0x359F50C5 ^ 0x359F50C4)
					{
					case 0:
						break;
					case 1:
						throw new ArgumentOutOfRangeException("index");
					case 3:
						goto end_IL_0009;
					default:
						goto IL_0063;
					}
					continue;
					end_IL_0009:
					break;
				}
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			goto IL_0063;
			IL_0063:
			return _entries[index].key;
		}

		public TValue GetValueAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = 1551158005;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x5C74CAF4)
			{
			case 4:
				break;
			case 0:
				throw new ArgumentException("index points to an invalid entry.");
			case 3:
				goto IL_0041;
			case 1:
				throw new ArgumentOutOfRangeException("index");
			default:
				return _entries[index].value;
			}
			goto IL_0009;
			IL_0041:
			int num2;
			if (_entries[index].hashCode >= 0)
			{
				num = 1551158006;
				num2 = num;
			}
			else
			{
				num = 1551158004;
				num2 = num;
			}
			goto IL_000e;
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
			if ((uint)index < (uint)_count)
			{
				while (true)
				{
					int num = 110310465;
					while (true)
					{
						switch (num ^ 0x6933440)
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
							num = 110310466;
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
			if ((uint)index < (uint)_count)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				goto IL_001d;
			}
			goto IL_003b;
			IL_0022:
			int num;
			switch (num ^ -853180832)
			{
			case 0:
				break;
			case 2:
				goto IL_003b;
			default:
				return false;
			}
			goto IL_001d;
			IL_003b:
			value = default(TValue);
			num = -853180831;
			goto IL_0022;
			IL_001d:
			num = -853180830;
			goto IL_0022;
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
			while (true)
			{
				int num = -1395841265;
				while (true)
				{
					switch (num ^ -1395841267)
					{
					case 0:
						break;
					case 2:
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
						goto IL_0057;
					default:
						return false;
					}
					break;
					IL_0057:
					num = -1395841268;
				}
			}
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
				while (true)
				{
					int num = 1188010936;
					while (true)
					{
						switch (num ^ 0x46CF9BB9)
						{
						case 2:
							break;
						case 1:
							goto IL_002e;
						default:
							return false;
						}
						break;
						IL_002e:
						key = default(TKey);
						num = 1188010937;
					}
				}
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
			while (true)
			{
				int num = -2000993760;
				while (true)
				{
					switch (num ^ -2000993757)
					{
					case 2:
						break;
					case 1:
						entry = default(KeyValuePair<TKey, TValue>);
						num = -2000993757;
						continue;
					case 4:
						entry = default(KeyValuePair<TKey, TValue>);
						return false;
					case 3:
						if ((uint)index < (uint)_count)
						{
							while (index < _count)
							{
								if (_entries[index].hashCode >= 0)
								{
									entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
									return true;
								}
								index++;
							}
							num = -2000993758;
						}
						else
						{
							num = -2000993753;
						}
						continue;
					default:
						return false;
					}
					break;
				}
			}
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
			while (true)
			{
				int num = -1489671523;
				while (true)
				{
					switch (num ^ -1489671524)
					{
					case 0:
						break;
					case 1:
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
						goto IL_0071;
					default:
						key = default(TKey);
						return false;
					}
					break;
					IL_0071:
					num = -1489671522;
				}
			}
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
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = -1072378853;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1072378854)
			{
			case 0:
				break;
			case 1:
				throw new ArgumentOutOfRangeException("index");
			case 3:
				goto IL_003d;
			default:
				return false;
			}
			goto IL_0009;
			IL_003d:
			if (_entries[index].hashCode < 0)
			{
				num = -1072378856;
				goto IL_000e;
			}
			Remove(_entries[index].key);
			return true;
		}

		private void IwfZfMIHMtBbEGPFBamkQjotmnkW(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_007d;
			IL_0003:
			int num = 686122805;
			goto IL_0008;
			IL_0008:
			Entry[] entries = default(Entry[]);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x28E56737)
				{
				case 0:
					break;
				case 3:
					P_0[P_1++] = new KeyValuePair<TKey, TValue>(entries[num2].key, entries[num2].value);
					num = 686122803;
					continue;
				case 9:
					goto IL_007d;
				case 5:
					goto IL_009b;
				case 11:
					count = _count;
					entries = _entries;
					num = 686122806;
					continue;
				case 4:
					num2++;
					num = 686122800;
					continue;
				case 8:
					throw new Exception();
				case 6:
					goto IL_00f2;
				case 1:
					num2 = 0;
					num = 686122800;
					continue;
				case 2:
					throw new ArgumentNullException("array");
				case 10:
				{
					int num3;
					if (entries[num2].hashCode < 0)
					{
						num = 686122803;
						num3 = num;
					}
					else
					{
						num = 686122804;
						num3 = num;
					}
					continue;
				}
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 10;
				}
				break;
				IL_009b:
				int num4;
				if (P_0.Length - P_1 >= Count)
				{
					num = 686122812;
					num4 = num;
				}
				else
				{
					num = 686122815;
					num4 = num;
				}
			}
			goto IL_0003;
			IL_007d:
			if (P_1 >= 0)
			{
				int num5;
				if (P_1 <= P_0.Length)
				{
					num = 686122802;
					num5 = num;
				}
				else
				{
					num = 686122801;
					num5 = num;
				}
				goto IL_0008;
			}
			goto IL_00f2;
			IL_00f2:
			throw new ArgumentOutOfRangeException("index");
		}

		private void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(int P_0)
		{
			int num = nRDqiCujUTmvVJSpZialYeJXOSn.WdkjlnFdTQshWqxOBmwMHudtQKPd(P_0);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1723589386;
				while (true)
				{
					switch (num2 ^ 0x66BBE30B)
					{
					case 6:
						break;
					case 5:
						XBoHBatfaNRYfAAjOEmwDMYYvHQq[num3] = -1;
						num2 = 1723589384;
						continue;
					case 0:
						if (num3 >= XBoHBatfaNRYfAAjOEmwDMYYvHQq.Length)
						{
							_entries = new Entry[num];
							num2 = 1723589385;
							continue;
						}
						goto case 5;
					case 3:
						num3++;
						num2 = 1723589387;
						continue;
					case 1:
						XBoHBatfaNRYfAAjOEmwDMYYvHQq = new int[num];
						num3 = 0;
						num2 = 1723589391;
						continue;
					case 4:
						num2 = 1723589387;
						continue;
					default:
						wJJTlzeMLICdcXRdYxNTRkcFtMK = -1;
						return;
					}
					break;
				}
			}
		}

		private void NuvgggIjflOyKqLkTzupeYNltCvA(TKey P_0, TValue P_1, bool P_2)
		{
			if (!lvyLiqaRKEntfLPHVcBclEAmheAK)
			{
				goto IL_000a;
			}
			goto IL_01a4;
			IL_000a:
			int num = -778191266;
			goto IL_000f;
			IL_000f:
			int num4 = default(int);
			int num2 = default(int);
			int count = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -778191270)
				{
				case 12:
					break;
				case 3:
					goto IL_005f;
				case 6:
					if (_entries[num4].hashCode == num2 && lZfPLCqrrbEgPDNPlDAoALVQnvj.Equals(_entries[num4].key, P_0))
					{
						if (P_2)
						{
							throw new ArgumentException("An element with the same key already exists in the dictionary.");
						}
						goto case 9;
					}
					goto case 15;
				case 14:
					dFyvOnKBbTYzKLbxHBbiIGdcrpeH(0);
					num = -778191278;
					continue;
				case 7:
					if (num4 < 0)
					{
						if (qgWVVcJwKvNVYAdJOwKGWzbKMin > 0)
						{
							count = wJJTlzeMLICdcXRdYxNTRkcFtMK;
							wJJTlzeMLICdcXRdYxNTRkcFtMK = _entries[count].next;
							num = -778191279;
							continue;
						}
						goto IL_005f;
					}
					goto case 6;
				case 1:
					return;
				case 5:
					rSmjMCfoajtRhMbXgbITDWHCQjC();
					num3 = num2 % XBoHBatfaNRYfAAjOEmwDMYYvHQq.Length;
					num = -778191273;
					continue;
				case 8:
					num2 = lZfPLCqrrbEgPDNPlDAoALVQnvj.GetHashCode(P_0) & 0x7FFFFFFF;
					num3 = num2 % XBoHBatfaNRYfAAjOEmwDMYYvHQq.Length;
					num4 = XBoHBatfaNRYfAAjOEmwDMYYvHQq[num3];
					num = -778191267;
					continue;
				case 11:
					qgWVVcJwKvNVYAdJOwKGWzbKMin--;
					num = -778191272;
					continue;
				case 10:
					HCKdygRhwCetItzVwbRsEqktGNve++;
					num = -778191269;
					continue;
				case 0:
					goto IL_01a4;
				case 9:
					_entries[num4].value = P_1;
					num = -778191280;
					continue;
				case 4:
					if (object.ReferenceEquals(P_0, null))
					{
						throw new ArgumentNullException("key");
					}
					goto IL_01a4;
				case 13:
					count = _count;
					_count++;
					num = -778191272;
					continue;
				case 15:
					num4 = _entries[num4].next;
					num = -778191267;
					continue;
				default:
					_entries[count].hashCode = num2;
					_entries[count].next = XBoHBatfaNRYfAAjOEmwDMYYvHQq[num3];
					_entries[count].key = P_0;
					_entries[count].value = P_1;
					XBoHBatfaNRYfAAjOEmwDMYYvHQq[num3] = count;
					HCKdygRhwCetItzVwbRsEqktGNve++;
					BMfwedHdXCXpWuCUhMBSBZQTNoY++;
					return;
				}
				break;
				IL_005f:
				int num5;
				if (_count != _entries.Length)
				{
					num = -778191273;
					num5 = num;
				}
				else
				{
					num = -778191265;
					num5 = num;
				}
			}
			goto IL_000a;
			IL_01a4:
			int num6;
			if (XBoHBatfaNRYfAAjOEmwDMYYvHQq != null)
			{
				num = -778191278;
				num6 = num;
			}
			else
			{
				num = -778191276;
				num6 = num;
			}
			goto IL_000f;
		}

		private void rSmjMCfoajtRhMbXgbITDWHCQjC()
		{
			rSmjMCfoajtRhMbXgbITDWHCQjC(nRDqiCujUTmvVJSpZialYeJXOSn.iaLvtqyFwGxSfqcNREKgisZiGDjp(_count), false);
		}

		private void rSmjMCfoajtRhMbXgbITDWHCQjC(int P_0, bool P_1)
		{
			int[] array = new int[P_0];
			int num = 0;
			int num7 = default(int);
			int num4 = default(int);
			Entry[] array2 = default(Entry[]);
			while (true)
			{
				int num2;
				int num3;
				if (num >= array.Length)
				{
					num2 = 599714521;
					num3 = num2;
				}
				else
				{
					num2 = 599714519;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x23BEEADD)
					{
					case 0:
						num2 = 599714519;
						continue;
					default:
						return;
					case 8:
						num7 = 0;
						num2 = 599714524;
						continue;
					case 3:
					{
						int num6;
						if (num4 < _count)
						{
							num2 = 599714527;
							num6 = num2;
						}
						else
						{
							num2 = 599714517;
							num6 = num2;
						}
						continue;
					}
					case 4:
						array2 = new Entry[P_0];
						num2 = 599714523;
						continue;
					case 13:
						num4++;
						num2 = 599714526;
						continue;
					case 1:
						if (num7 >= _count)
						{
							XBoHBatfaNRYfAAjOEmwDMYYvHQq = array;
							_entries = array2;
							num2 = 599714513;
							continue;
						}
						goto case 9;
					case 2:
					{
						int num5;
						if (array2[num4].hashCode == -1)
						{
							num2 = 599714512;
							num5 = num2;
						}
						else
						{
							num2 = 599714520;
							num5 = num2;
						}
						continue;
					}
					case 7:
						break;
					case 5:
						array2[num4].hashCode = lZfPLCqrrbEgPDNPlDAoALVQnvj.GetHashCode(array2[num4].key) & 0x7FFFFFFF;
						num2 = 599714512;
						continue;
					case 9:
						if (array2[num7].hashCode >= 0)
						{
							int num8 = array2[num7].hashCode % P_0;
							array2[num7].next = array[num8];
							array[num8] = num7;
							num2 = 599714518;
							continue;
						}
						goto case 11;
					case 10:
						array[num] = -1;
						num++;
						num2 = 599714522;
						continue;
					case 6:
						Array.Copy(_entries, 0, array2, 0, _count);
						if (P_1)
						{
							num4 = 0;
							num2 = 599714526;
							continue;
						}
						goto case 8;
					case 11:
						num7++;
						num2 = 599714524;
						continue;
					case 12:
						return;
					}
					break;
				}
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
			if (num >= 0 && BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(_entries[num].value, keyValuePair.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = IndexOfKey(keyValuePair.Key);
			if (num >= 0 && BakwdxKAwdnMTrIEiIUPFkGxcZD.Equals(_entries[num].value, keyValuePair.Value))
			{
				Remove(keyValuePair.Key);
				return true;
			}
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			IwfZfMIHMtBbEGPFBamkQjotmnkW(array, index);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num4 = default(int);
			DictionaryEntry[] array2 = default(DictionaryEntry[]);
			Entry[] entries = default(Entry[]);
			while (true)
			{
				int num;
				int num2;
				if (array.Rank == 1)
				{
					num = -1237214046;
					num2 = num;
				}
				else
				{
					num = -1237214043;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1237214043)
					{
					case 9:
						num = -1237214033;
						continue;
					case 12:
						throw new Exception();
					case 4:
						num4 = 0;
						num = -1237214040;
						continue;
					case 3:
						if (index >= 0)
						{
							int num5;
							if (index <= array.Length)
							{
								num = -1237214038;
								num5 = num;
							}
							else
							{
								num = -1237214041;
								num5 = num;
							}
							continue;
						}
						goto case 2;
					case 7:
						if (array.GetLowerBound(0) != 0)
						{
							throw new Exception();
						}
						goto case 3;
					case 1:
					{
						KeyValuePair<TKey, TValue>[] array3 = array as KeyValuePair<TKey, TValue>[];
						if (array3 != null)
						{
							IwfZfMIHMtBbEGPFBamkQjotmnkW(array3, index);
							return;
						}
						goto case 14;
					}
					case 13:
						num = -1237214034;
						continue;
					case 10:
						break;
					case 5:
						num4++;
						num = -1237214034;
						continue;
					case 0:
						throw new Exception();
					case 14:
						if (array is DictionaryEntry[])
						{
							array2 = array as DictionaryEntry[];
							entries = _entries;
							num = -1237214047;
							continue;
						}
						goto default;
					case 11:
						if (num4 >= _count)
						{
							return;
						}
						goto case 6;
					case 15:
					{
						int num3;
						if (array.Length - index >= Count)
						{
							num = -1237214044;
							num3 = num;
						}
						else
						{
							num = -1237214039;
							num3 = num;
						}
						continue;
					}
					case 6:
						if (entries[num4].hashCode >= 0)
						{
							array2[index++] = new DictionaryEntry(entries[num4].key, entries[num4].value);
							num = -1237214048;
							continue;
						}
						goto case 5;
					case 2:
						throw new ArgumentOutOfRangeException("index");
					default:
					{
						object[] array4 = array as object[];
						if (array4 == null)
						{
							throw new Exception();
						}
						try
						{
							int count = _count;
							Entry[] entries2 = _entries;
							int num6 = 0;
							while (true)
							{
								int num7;
								int num8;
								if (num6 >= count)
								{
									num7 = -1237214041;
									num8 = num7;
								}
								else
								{
									num7 = -1237214047;
									num8 = num7;
								}
								while (true)
								{
									switch (num7 ^ -1237214043)
									{
									case 0:
										num7 = -1237214047;
										continue;
									default:
										return;
									case 1:
										break;
									case 3:
										num6++;
										num7 = -1237214044;
										continue;
									case 4:
										if (entries2[num6].hashCode >= 0)
										{
											array4[index++] = new KeyValuePair<TKey, TValue>(entries2[num6].key, entries2[num6].value);
											num7 = -1237214042;
											continue;
										}
										goto case 3;
									case 2:
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
				}
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
			oQmOdsOjSGWpkzaPhyeEUaULQhB<TValue>(value, "value");
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
			if (ejEQqDqaTGAvRfGoebrKzOgBTkD(key))
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
			if (ejEQqDqaTGAvRfGoebrKzOgBTkD(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool ejEQqDqaTGAvRfGoebrKzOgBTkD(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void oQmOdsOjSGWpkzaPhyeEUaULQhB<T>(object P_0, string P_1)
		{
			if (P_0 != null)
			{
				return;
			}
			while (true)
			{
				switch (-2017648270 ^ -2017648272)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (default(T) != null)
					{
						throw new ArgumentNullException(P_1);
					}
					return;
				case 1:
					return;
				}
			}
		}
	}
}
