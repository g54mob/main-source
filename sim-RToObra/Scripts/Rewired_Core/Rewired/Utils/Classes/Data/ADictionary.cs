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
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private ADictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

			private int jKkfIpbjIavykANnmWTcMYiQOxz;

			private int mFfLSVvRgZulYzYIyEkqCMoEiNXj;

			private KeyValuePair<TKey, TValue> xbRrcEKKIAKiQkVzQCekOswVHrJ;

			private int IkrEhreRxVGUYNrGUTlbSFukAGFk;

			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					return xbRrcEKKIAKiQkVzQCekOswVHrJ;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-614292631 ^ -614292632)
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
					if (IkrEhreRxVGUYNrGUTlbSFukAGFk == 1)
					{
						return new DictionaryEntry(xbRrcEKKIAKiQkVzQCekOswVHrJ.Key, xbRrcEKKIAKiQkVzQCekOswVHrJ.Value);
					}
					return new KeyValuePair<TKey, TValue>(xbRrcEKKIAKiQkVzQCekOswVHrJ.Key, xbRrcEKKIAKiQkVzQCekOswVHrJ.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						while (true)
						{
							int num = -1296669493;
							while (true)
							{
								switch (num ^ -1296669496)
								{
								case 0:
									break;
								case 3:
									goto IL_002a;
								case 2:
									goto end_IL_0008;
								default:
									return new DictionaryEntry(xbRrcEKKIAKiQkVzQCekOswVHrJ.Key, xbRrcEKKIAKiQkVzQCekOswVHrJ.Value);
								}
								break;
								IL_002a:
								int num2;
								if (mFfLSVvRgZulYzYIyEkqCMoEiNXj == LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1)
								{
									num = -1296669494;
									num2 = num;
								}
								else
								{
									num = -1296669495;
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

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (0x2B3EF57F ^ 0x2B3EF57D)
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
					return xbRrcEKKIAKiQkVzQCekOswVHrJ.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (0x2E66EF27 ^ 0x2E66EF26)
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
					return xbRrcEKKIAKiQkVzQCekOswVHrJ.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
				jKkfIpbjIavykANnmWTcMYiQOxz = dictionary.wyCzBtxDiYHWdJxUIaVcrhitjEkf;
				mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
				IkrEhreRxVGUYNrGUTlbSFukAGFk = getEnumeratorRetType;
				xbRrcEKKIAKiQkVzQCekOswVHrJ = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					throw new Exception();
				}
				while (true)
				{
					int num;
					if ((uint)mFfLSVvRgZulYzYIyEkqCMoEiNXj >= (uint)LbwQyRfKuLNxSjFIaAsDJTuLixL._count)
					{
						mFfLSVvRgZulYzYIyEkqCMoEiNXj = LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1;
						num = 2100229019;
						goto IL_001e;
					}
					goto IL_00db;
					IL_001e:
					while (true)
					{
						switch (num ^ 0x7D2EF39F)
						{
						case 0:
							num = 2100229022;
							continue;
						case 2:
							break;
						case 3:
							xbRrcEKKIAKiQkVzQCekOswVHrJ = new KeyValuePair<TKey, TValue>(LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].key, LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].value);
							mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
							return true;
						case 1:
							goto IL_00db;
						default:
							xbRrcEKKIAKiQkVzQCekOswVHrJ = default(KeyValuePair<TKey, TValue>);
							return false;
						}
						break;
					}
					continue;
					IL_00db:
					if (LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].hashCode < 0)
					{
						mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
						num = 2100229021;
					}
					else
					{
						num = 2100229020;
					}
					goto IL_001e;
				}
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					throw new Exception();
				}
				while (true)
				{
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					int num = 202852016;
					while (true)
					{
						switch (num ^ 0xC1746B1)
						{
						case 0:
							goto IL_0019;
						case 2:
							break;
						default:
							xbRrcEKKIAKiQkVzQCekOswVHrJ = default(KeyValuePair<TKey, TValue>);
							return;
						}
						break;
						IL_0019:
						num = 202852019;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private ADictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

				private int mFfLSVvRgZulYzYIyEkqCMoEiNXj;

				private int jKkfIpbjIavykANnmWTcMYiQOxz;

				private TKey xMQAEwybFxHWGsoeWBzXGKqkIuk;

				public TKey Current
				{
					get
					{
						return xMQAEwybFxHWGsoeWBzXGKqkIuk;
					}
				}

				object IEnumerator.Current
				{
					get
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
						{
							if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1)
							{
								goto IL_0048;
							}
							while (true)
							{
								switch (-750568620 ^ -750568619)
								{
								case 0:
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
						return xMQAEwybFxHWGsoeWBzXGKqkIuk;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
					jKkfIpbjIavykANnmWTcMYiQOxz = dictionary.wyCzBtxDiYHWdJxUIaVcrhitjEkf;
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					xMQAEwybFxHWGsoeWBzXGKqkIuk = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
					{
						throw new Exception();
					}
					while (true)
					{
						int num;
						int num2;
						if ((uint)mFfLSVvRgZulYzYIyEkqCMoEiNXj < (uint)LbwQyRfKuLNxSjFIaAsDJTuLixL._count)
						{
							num = 1313002362;
							num2 = num;
						}
						else
						{
							num = 1313002364;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x4E42D37C)
							{
							case 7:
								num = 1313002362;
								continue;
							case 4:
								xMQAEwybFxHWGsoeWBzXGKqkIuk = default(TKey);
								num = 1313002361;
								continue;
							case 2:
								return true;
							case 3:
								xMQAEwybFxHWGsoeWBzXGKqkIuk = LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].key;
								mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
								num = 1313002366;
								continue;
							case 1:
								break;
							case 0:
								mFfLSVvRgZulYzYIyEkqCMoEiNXj = LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1;
								num = 1313002360;
								continue;
							case 6:
								if (LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].hashCode < 0)
								{
									mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
									num = 1313002365;
								}
								else
								{
									num = 1313002367;
								}
								continue;
							default:
								return false;
							}
							break;
						}
					}
				}

				void IEnumerator.Reset()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
					{
						goto IL_0013;
					}
					goto IL_0042;
					IL_0013:
					int num = 966367522;
					goto IL_0018;
					IL_0018:
					switch (num ^ 0x39999921)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						throw new Exception();
					case 1:
						goto IL_0042;
					case 2:
						return;
					}
					goto IL_0013;
					IL_0042:
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					xMQAEwybFxHWGsoeWBzXGKqkIuk = default(TKey);
					num = 966367523;
					goto IL_0018;
				}
			}

			private ADictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

			public int Count
			{
				get
				{
					return LbwQyRfKuLNxSjFIaAsDJTuLixL.Count;
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
					return ((ICollection)LbwQyRfKuLNxSjFIaAsDJTuLixL).SyncRoot;
				}
			}

			public KeyCollection(ADictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(LbwQyRfKuLNxSjFIaAsDJTuLixL);
			}

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					goto IL_0006;
				}
				goto IL_00ca;
				IL_0006:
				int num = -1465436910;
				goto IL_000b;
				IL_000b:
				Entry[] entries = default(Entry[]);
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					switch (num ^ -1465436909)
					{
					case 0:
						break;
					case 10:
						throw new Exception();
					case 2:
						if (entries[num2].hashCode >= 0)
						{
							array[index++] = entries[num2].key;
							num = -1465436901;
							continue;
						}
						goto case 8;
					case 9:
						num = -1465436905;
						continue;
					case 5:
						goto IL_008f;
					case 6:
						goto IL_00a4;
					case 3:
						goto IL_00ca;
					case 1:
						throw new ArgumentNullException("array");
					case 8:
						num2++;
						num = -1465436905;
						continue;
					case 7:
						count = LbwQyRfKuLNxSjFIaAsDJTuLixL._count;
						entries = LbwQyRfKuLNxSjFIaAsDJTuLixL._entries;
						num2 = 0;
						num = -1465436902;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 2;
					}
					break;
					IL_00a4:
					int num3;
					if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
					{
						num = -1465436903;
						num3 = num;
					}
					else
					{
						num = -1465436908;
						num3 = num;
					}
				}
				goto IL_0006;
				IL_008f:
				throw new ArgumentOutOfRangeException("index");
				IL_00ca:
				if (index >= 0)
				{
					int num4;
					if (index <= array.Length)
					{
						num = -1465436907;
						num4 = num;
					}
					else
					{
						num = -1465436906;
						num4 = num;
					}
					goto IL_000b;
				}
				goto IL_008f;
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
				return LbwQyRfKuLNxSjFIaAsDJTuLixL.ContainsKey(item);
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw new Exception();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return new Enumerator(LbwQyRfKuLNxSjFIaAsDJTuLixL);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(LbwQyRfKuLNxSjFIaAsDJTuLixL);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				int count = default(int);
				object[] array2 = default(object[]);
				while (true)
				{
					int num;
					int num2;
					if (array.Rank == 1)
					{
						num = -2067622151;
						num2 = num;
					}
					else
					{
						num = -2067622157;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -2067622152)
						{
						case 0:
							num = -2067622160;
							continue;
						case 8:
							break;
						case 4:
						{
							TKey[] array3 = array as TKey[];
							if (array3 != null)
							{
								CopyTo(array3, index);
								return;
							}
							goto case 10;
						}
						case 7:
						{
							int num6;
							if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
							{
								num = -2067622147;
								num6 = num;
							}
							else
							{
								num = -2067622148;
								num6 = num;
							}
							continue;
						}
						case 9:
							if (index >= 0)
							{
								int num7;
								if (index <= array.Length)
								{
									num = -2067622145;
									num7 = num;
								}
								else
								{
									num = -2067622156;
									num7 = num;
								}
								continue;
							}
							goto case 12;
						case 1:
						{
							int num5;
							if (array.GetLowerBound(0) != 0)
							{
								num = -2067622146;
								num5 = num;
							}
							else
							{
								num = -2067622159;
								num5 = num;
							}
							continue;
						}
						case 3:
							count = LbwQyRfKuLNxSjFIaAsDJTuLixL._count;
							num = -2067622150;
							continue;
						case 10:
							array2 = array as object[];
							if (array2 == null)
							{
								throw new Exception();
							}
							goto case 3;
						case 12:
							throw new Exception();
						case 5:
							throw new Exception();
						case 6:
							throw new Exception();
						case 11:
							throw new Exception();
						default:
						{
							Entry[] entries = LbwQyRfKuLNxSjFIaAsDJTuLixL._entries;
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
											num4 = -2067622152;
											goto IL_017b;
										}
										goto IL_01c9;
										IL_017b:
										while (true)
										{
											switch (num4 ^ -2067622152)
											{
											case 2:
												num4 = -2067622151;
												continue;
											case 1:
												break;
											case 0:
												goto IL_01c9;
											default:
												goto end_IL_0198;
											}
											break;
										}
										continue;
										IL_01c9:
										num3++;
										num4 = -2067622149;
										goto IL_017b;
										continue;
										end_IL_0198:
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
				private ADictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

				private int mFfLSVvRgZulYzYIyEkqCMoEiNXj;

				private int jKkfIpbjIavykANnmWTcMYiQOxz;

				private TValue gQYbKVkDGlhhqclRHXVPDoznkXpu;

				public TValue Current
				{
					get
					{
						return gQYbKVkDGlhhqclRHXVPDoznkXpu;
					}
				}

				object IEnumerator.Current
				{
					get
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
						{
							while (true)
							{
								int num = 664975474;
								while (true)
								{
									switch (num ^ 0x27A2B873)
									{
									case 2:
										break;
									case 1:
										goto IL_002a;
									case 0:
										goto end_IL_0008;
									default:
										return gQYbKVkDGlhhqclRHXVPDoznkXpu;
									}
									break;
									IL_002a:
									int num2;
									if (mFfLSVvRgZulYzYIyEkqCMoEiNXj == LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1)
									{
										num = 664975475;
										num2 = num;
									}
									else
									{
										num = 664975472;
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

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
				{
					LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
					jKkfIpbjIavykANnmWTcMYiQOxz = dictionary.wyCzBtxDiYHWdJxUIaVcrhitjEkf;
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					gQYbKVkDGlhhqclRHXVPDoznkXpu = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
					{
						throw new Exception();
					}
					while (true)
					{
						IL_00a8:
						int num;
						if ((uint)mFfLSVvRgZulYzYIyEkqCMoEiNXj >= (uint)LbwQyRfKuLNxSjFIaAsDJTuLixL._count)
						{
							mFfLSVvRgZulYzYIyEkqCMoEiNXj = LbwQyRfKuLNxSjFIaAsDJTuLixL._count + 1;
							gQYbKVkDGlhhqclRHXVPDoznkXpu = default(TValue);
							num = 295511333;
							goto IL_0021;
						}
						goto IL_0041;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x119D2527)
							{
							case 0:
								num = 295511334;
								continue;
							case 1:
								break;
							case 3:
								goto IL_00a8;
							default:
								return false;
							}
							break;
						}
						goto IL_0041;
						IL_0041:
						if (LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].hashCode >= 0)
						{
							break;
						}
						mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
						num = 295511332;
						goto IL_0021;
					}
					gQYbKVkDGlhhqclRHXVPDoznkXpu = LbwQyRfKuLNxSjFIaAsDJTuLixL._entries[mFfLSVvRgZulYzYIyEkqCMoEiNXj].value;
					mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
					return true;
				}

				void IEnumerator.Reset()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
					{
						throw new Exception();
					}
					while (true)
					{
						mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
						int num = -359426557;
						while (true)
						{
							switch (num ^ -359426559)
							{
							case 0:
								goto IL_0019;
							case 1:
								break;
							default:
								gQYbKVkDGlhhqclRHXVPDoznkXpu = default(TValue);
								return;
							}
							break;
							IL_0019:
							num = -359426560;
						}
					}
				}
			}

			private ADictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

			public int Count
			{
				get
				{
					return LbwQyRfKuLNxSjFIaAsDJTuLixL.Count;
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
					return ((ICollection)LbwQyRfKuLNxSjFIaAsDJTuLixL).SyncRoot;
				}
			}

			public ValueCollection(ADictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(LbwQyRfKuLNxSjFIaAsDJTuLixL);
			}

			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				int count = default(int);
				Entry[] entries = default(Entry[]);
				int num3 = default(int);
				while (index >= 0)
				{
					int num;
					int num2;
					if (index > array.Length)
					{
						num = -1691604265;
						num2 = num;
					}
					else
					{
						num = -1691604263;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1691604272)
						{
						case 0:
							num = -1691604271;
							continue;
						default:
							return;
						case 10:
							count = LbwQyRfKuLNxSjFIaAsDJTuLixL._count;
							num = -1691604267;
							continue;
						case 7:
							break;
						case 2:
							goto IL_0072;
						case 9:
							if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
							{
								throw new Exception();
							}
							goto case 10;
						case 1:
							goto end_IL_0016;
						case 5:
							entries = LbwQyRfKuLNxSjFIaAsDJTuLixL._entries;
							num3 = 0;
							num = -1691604269;
							continue;
						case 4:
							num3++;
							num = -1691604270;
							continue;
						case 3:
							num = -1691604270;
							continue;
						case 6:
							if (entries[num3].hashCode >= 0)
							{
								array[index++] = entries[num3].value;
								num = -1691604268;
								continue;
							}
							goto case 4;
						case 8:
							return;
						}
						goto end_IL_00a9;
						IL_0072:
						int num4;
						if (num3 < count)
						{
							num = -1691604266;
							num4 = num;
						}
						else
						{
							num = -1691604264;
							num4 = num;
						}
						continue;
						end_IL_0016:
						break;
					}
					continue;
					end_IL_00a9:
					break;
				}
				throw new Exception();
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
				return LbwQyRfKuLNxSjFIaAsDJTuLixL.ContainsValue(item);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return new Enumerator(LbwQyRfKuLNxSjFIaAsDJTuLixL);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(LbwQyRfKuLNxSjFIaAsDJTuLixL);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					goto IL_0006;
				}
				goto IL_00fc;
				IL_0006:
				int num = 919521721;
				goto IL_000b;
				IL_000b:
				object[] array2 = default(object[]);
				while (true)
				{
					switch (num ^ 0x36CEC9B1)
					{
					case 0:
						break;
					case 8:
						throw new ArgumentNullException("array");
					case 4:
						throw new Exception();
					case 5:
						array2 = array as object[];
						num = 919521715;
						continue;
					case 6:
						throw new Exception();
					case 11:
						goto IL_0089;
					case 1:
					{
						TValue[] array3 = array as TValue[];
						if (array3 != null)
						{
							CopyTo(array3, index);
							return;
						}
						goto case 5;
					}
					case 7:
						throw new Exception();
					case 3:
						goto IL_00df;
					case 12:
						goto IL_00fc;
					case 2:
						if (array2 == null)
						{
							throw new Exception();
						}
						goto default;
					case 9:
						if (index < 0)
						{
							goto case 7;
						}
						goto IL_012c;
					default:
					{
						int count = LbwQyRfKuLNxSjFIaAsDJTuLixL._count;
						Entry[] entries = LbwQyRfKuLNxSjFIaAsDJTuLixL._entries;
						try
						{
							int num2 = 0;
							while (num2 < count)
							{
								while (true)
								{
									int num3;
									if (entries[num2].hashCode >= 0)
									{
										array2[index++] = entries[num2].value;
										num3 = 919521714;
										goto IL_016b;
									}
									goto IL_01b9;
									IL_016b:
									while (true)
									{
										switch (num3 ^ 0x36CEC9B1)
										{
										case 2:
											num3 = 919521712;
											continue;
										case 1:
											break;
										case 3:
											goto IL_01b9;
										default:
											goto end_IL_0188;
										}
										break;
									}
									continue;
									IL_01b9:
									num2++;
									num3 = 919521713;
									goto IL_016b;
									continue;
									end_IL_0188:
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
					IL_012c:
					int num4;
					if (index <= array.Length)
					{
						num = 919521722;
						num4 = num;
					}
					else
					{
						num = 919521718;
						num4 = num;
					}
					continue;
					IL_0089:
					int num5;
					if (array.Length - index >= LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
					{
						num = 919521712;
						num5 = num;
					}
					else
					{
						num = 919521719;
						num5 = num;
					}
				}
				goto IL_0006;
				IL_00fc:
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				goto IL_00df;
				IL_00df:
				int num6;
				if (array.GetLowerBound(0) == 0)
				{
					num = 919521720;
					num6 = num;
				}
				else
				{
					num = 919521717;
					num6 = num;
				}
				goto IL_000b;
			}
		}

		private const string kwfuRjsZDUXrelJeCGQpYdraGKR = "Version";

		private const string cZkJDgAgRAMCaCazgzUrgASUnVG = "HashSize";

		private const string sVfintwfYdBqVKzMnDycsLznkyja = "KeyValuePairs";

		private const string svkguqveuhynZWfnfAdyfgiKcIiK = "Comparer";

		private int[] qGaMYlHsqJBlIcPeaIimFjKSzAXf;

		internal Entry[] _entries;

		internal int _count;

		private int wyCzBtxDiYHWdJxUIaVcrhitjEkf;

		private int sQrzaytHzEaFnInVPIRQoBDHCYN;

		private int FBDDgkGsBCdENkbsiJNLrgqPpHXC;

		private int XgIAQrGhAxqovdeEirMSGrnEIdiX;

		private IEqualityComparer<TKey> CxlUnKAGjhpBDnbYFDLUbNJKPkw;

		private IEqualityComparer<TValue> ooabukyrafXryRkJUhQNqvEtESQ;

		private KeyCollection PczZmwlKZffAWXLQaVTRvCWjchW;

		private ValueCollection qmzoTsMXQWlxxgxeInzhrPetPQC;

		private readonly object hXfFbNklCHLuuDBVVoEKlNLfPpvH = new object();

		private static readonly bool WGehdtGoYKIGKvRKnNsuQzYujsL = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool qSISkWksASjVDSkFDsXeoPPGop = ReflectionTools.IsValueType(typeof(TValue));

		public int Count
		{
			get
			{
				return _count - XgIAQrGhAxqovdeEirMSGrnEIdiX;
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
				if (PczZmwlKZffAWXLQaVTRvCWjchW == null)
				{
					PczZmwlKZffAWXLQaVTRvCWjchW = new KeyCollection(this);
				}
				return PczZmwlKZffAWXLQaVTRvCWjchW;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (qmzoTsMXQWlxxgxeInzhrPetPQC == null)
				{
					while (true)
					{
						int num = 312078247;
						while (true)
						{
							switch (num ^ 0x1299EFA6)
							{
							case 0:
								break;
							case 1:
								qmzoTsMXQWlxxgxeInzhrPetPQC = new ValueCollection(this);
								num = 312078244;
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
				return qmzoTsMXQWlxxgxeInzhrPetPQC;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return CxlUnKAGjhpBDnbYFDLUbNJKPkw;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				CxlUnKAGjhpBDnbYFDLUbNJKPkw = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return ooabukyrafXryRkJUhQNqvEtESQ;
			}
			set
			{
				if (value == null)
				{
					while (true)
					{
						int num = 2104506973;
						while (true)
						{
							switch (num ^ 0x7D703A5C)
							{
							case 0:
								break;
							case 1:
								value = EqualityComparerNoAlloc<TValue>.Default;
								num = 2104506974;
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
				ooabukyrafXryRkJUhQNqvEtESQ = value;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					while (true)
					{
						switch (0x37EF3EFF ^ 0x37EF3EFE)
						{
						case 0:
							continue;
						case 1:
							throw new KeyNotFoundException(string.Concat("Key \"", key, " does not exist."));
						}
						break;
					}
				}
				return _entries[num].value;
			}
			set
			{
				cstwlfTlxxCXbEfllWofrtFdGPqh(key, value, false);
			}
		}

		public int IndexOfFirst
		{
			get
			{
				int num = 0;
				while (true)
				{
					int num2 = -432961478;
					while (true)
					{
						switch (num2 ^ -432961477)
						{
						case 0:
							break;
						case 1:
							num2 = -432961480;
							continue;
						case 2:
							if (_entries[num].hashCode >= 0)
							{
								return num;
							}
							num++;
							num2 = -432961480;
							continue;
						default:
							if (num >= _count)
							{
								return -1;
							}
							goto case 2;
						}
						break;
					}
				}
			}
		}

		public int IndexOfLast
		{
			get
			{
				int num = _count - 1;
				while (true)
				{
					int num2 = -1392891192;
					while (true)
					{
						switch (num2 ^ -1392891190)
						{
						case 0:
							break;
						case 2:
							num2 = -1392891191;
							continue;
						case 1:
							if (_entries[num].hashCode >= 0)
							{
								return num;
							}
							num--;
							num2 = -1392891191;
							continue;
						default:
							if (num < 0)
							{
								return -1;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				if (PczZmwlKZffAWXLQaVTRvCWjchW == null)
				{
					while (true)
					{
						int num = -106134886;
						while (true)
						{
							switch (num ^ -106134885)
							{
							case 0:
								break;
							case 1:
								PczZmwlKZffAWXLQaVTRvCWjchW = new KeyCollection(this);
								num = -106134887;
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
				return PczZmwlKZffAWXLQaVTRvCWjchW;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (qmzoTsMXQWlxxgxeInzhrPetPQC == null)
				{
					while (true)
					{
						int num = 579050455;
						while (true)
						{
							switch (num ^ 0x22839BD5)
							{
							case 0:
								break;
							case 2:
								qmzoTsMXQWlxxgxeInzhrPetPQC = new ValueCollection(this);
								num = 579050452;
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
				return qmzoTsMXQWlxxgxeInzhrPetPQC;
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
				return hXfFbNklCHLuuDBVVoEKlNLfPpvH;
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
				if (ZZQBFWEnBOntoXDfEnPMEBmVtMI(key))
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
				TpwEapuFMOXMTZQCXRiMjbCLtgY<TValue>(value, "value");
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
				YJaAHaimrHWIfKrgfWxeihnqrcza(capacity);
			}
			CxlUnKAGjhpBDnbYFDLUbNJKPkw = keyComparer ?? EqualityComparerNoAlloc<TKey>.Default;
			ooabukyrafXryRkJUhQNqvEtESQ = valueComparer ?? EqualityComparerNoAlloc<TValue>.Default;
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
			cstwlfTlxxCXbEfllWofrtFdGPqh(key, value, true);
		}

		public void Clear()
		{
			if (_count <= 0)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1696972261;
				while (true)
				{
					switch (num2 ^ -1696972262)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						if (num >= qGaMYlHsqJBlIcPeaIimFjKSzAXf.Length)
						{
							Array.Clear(_entries, 0, _count);
							FBDDgkGsBCdENkbsiJNLrgqPpHXC = -1;
							_count = 0;
							XgIAQrGhAxqovdeEirMSGrnEIdiX = 0;
							wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
							sQrzaytHzEaFnInVPIRQoBDHCYN++;
							num2 = -1696972258;
							continue;
						}
						goto case 0;
					case 0:
						qGaMYlHsqJBlIcPeaIimFjKSzAXf[num] = -1;
						num++;
						num2 = -1696972263;
						continue;
					case 1:
						num2 = -1696972263;
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
			if (!WGehdtGoYKIGKvRKnNsuQzYujsL)
			{
				goto IL_000a;
			}
			goto IL_01b8;
			IL_000a:
			int num = 823625185;
			goto IL_000f;
			IL_000f:
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			int num7 = default(int);
			while (true)
			{
				switch (num ^ 0x311785E5)
				{
				case 3:
					break;
				case 0:
					_entries[num4].next = _entries[num2].next;
					num = 823625187;
					continue;
				case 1:
					goto IL_0078;
				case 4:
					goto IL_00c9;
				case 9:
					goto IL_00eb;
				case 8:
					qGaMYlHsqJBlIcPeaIimFjKSzAXf[num3] = _entries[num2].next;
					num = 823625187;
					continue;
				case 2:
					_entries[num2].next = FBDDgkGsBCdENkbsiJNLrgqPpHXC;
					num = 823625184;
					continue;
				case 5:
					_entries[num2].key = default(TKey);
					_entries[num2].value = default(TValue);
					FBDDgkGsBCdENkbsiJNLrgqPpHXC = num2;
					XgIAQrGhAxqovdeEirMSGrnEIdiX++;
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					return true;
				case 11:
					goto IL_01b8;
				case 10:
					throw new ArgumentNullException("key");
				case 6:
					_entries[num2].hashCode = -1;
					num = 823625191;
					continue;
				default:
					goto IL_0224;
				}
				break;
				IL_00eb:
				int num5;
				if (num2 < 0)
				{
					num = 823625186;
					num5 = num;
				}
				else
				{
					num = 823625188;
					num5 = num;
				}
				continue;
				IL_00c9:
				int num6;
				if (object.ReferenceEquals(key, null))
				{
					num = 823625199;
					num6 = num;
				}
				else
				{
					num = 823625198;
					num6 = num;
				}
				continue;
				IL_0078:
				if (_entries[num2].hashCode == num7 && CxlUnKAGjhpBDnbYFDLUbNJKPkw.Equals(_entries[num2].key, key))
				{
					int num8;
					if (num4 >= 0)
					{
						num = 823625189;
						num8 = num;
					}
					else
					{
						num = 823625197;
						num8 = num;
					}
				}
				else
				{
					num4 = num2;
					num2 = _entries[num2].next;
					num = 823625196;
				}
			}
			goto IL_000a;
			IL_0224:
			return false;
			IL_01b8:
			if (qGaMYlHsqJBlIcPeaIimFjKSzAXf != null)
			{
				num7 = CxlUnKAGjhpBDnbYFDLUbNJKPkw.GetHashCode(key) & 0x7FFFFFFF;
				num3 = num7 % qGaMYlHsqJBlIcPeaIimFjKSzAXf.Length;
				num4 = -1;
				num2 = qGaMYlHsqJBlIcPeaIimFjKSzAXf[num3];
				num = 823625196;
				goto IL_000f;
			}
			goto IL_0224;
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
				goto IL_000c;
			}
			TValue result = default(TValue);
			int num2 = 1472750088;
			goto IL_0011;
			IL_0011:
			switch (num2 ^ 0x57C86209)
			{
			case 0:
				break;
			case 2:
				return _entries[num].value;
			default:
				return result;
			}
			goto IL_000c;
			IL_000c:
			num2 = 1472750091;
			goto IL_0011;
		}

		public int IndexOfKey(TKey key)
		{
			if (!WGehdtGoYKIGKvRKnNsuQzYujsL)
			{
				goto IL_0007;
			}
			goto IL_0040;
			IL_0007:
			int num = 2102754294;
			goto IL_000c;
			IL_000c:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x7D557BF1)
				{
				case 0:
					break;
				case 2:
					goto IL_0040;
				case 8:
					throw new ArgumentNullException("key");
				case 7:
					goto IL_006b;
				case 4:
					goto IL_008a;
				case 3:
					goto IL_00db;
				case 5:
					num3 = qGaMYlHsqJBlIcPeaIimFjKSzAXf[num2 % qGaMYlHsqJBlIcPeaIimFjKSzAXf.Length];
					num = 2102754290;
					continue;
				case 1:
					num2 = CxlUnKAGjhpBDnbYFDLUbNJKPkw.GetHashCode(key) & 0x7FFFFFFF;
					num = 2102754292;
					continue;
				default:
					return -1;
				}
				break;
				IL_00db:
				int num4;
				if (num3 < 0)
				{
					num = 2102754295;
					num4 = num;
				}
				else
				{
					num = 2102754293;
					num4 = num;
				}
				continue;
				IL_008a:
				if (_entries[num3].hashCode == num2 && CxlUnKAGjhpBDnbYFDLUbNJKPkw.Equals(_entries[num3].key, key))
				{
					return num3;
				}
				num3 = _entries[num3].next;
				num = 2102754290;
				continue;
				IL_006b:
				int num5;
				if (object.ReferenceEquals(key, null))
				{
					num = 2102754297;
					num5 = num;
				}
				else
				{
					num = 2102754291;
					num5 = num;
				}
			}
			goto IL_0007;
			IL_0040:
			int num6;
			if (qGaMYlHsqJBlIcPeaIimFjKSzAXf != null)
			{
				num = 2102754288;
				num6 = num;
			}
			else
			{
				num = 2102754295;
				num6 = num;
			}
			goto IL_000c;
		}

		public int IndexOfValue(TValue value)
		{
			Entry[] entries = _entries;
			if (qSISkWksASjVDSkFDsXeoPPGop || value != null)
			{
				goto IL_0085;
			}
			int num = 0;
			goto IL_0095;
			IL_0065:
			if (entries[num].value == null)
			{
				return num;
			}
			goto IL_007a;
			IL_004f:
			int num2;
			if (entries[num].hashCode >= 0)
			{
				num2 = -232489309;
				goto IL_001f;
			}
			goto IL_007a;
			IL_0095:
			if (num >= _count)
			{
				num2 = -232489308;
				goto IL_001f;
			}
			goto IL_004f;
			IL_007a:
			num++;
			num2 = -232489306;
			goto IL_001f;
			IL_001f:
			int num3 = default(int);
			IEqualityComparer<TValue> equalityComparer = default(IEqualityComparer<TValue>);
			while (true)
			{
				switch (num2 ^ -232489307)
				{
				case 2:
					num2 = -232489310;
					continue;
				case 7:
					break;
				case 6:
					goto IL_0065;
				case 5:
					goto IL_0085;
				case 3:
					goto IL_0095;
				case 0:
					goto IL_00a8;
				case 4:
					goto IL_00c5;
				default:
					return -1;
				}
				break;
				IL_00c5:
				if (entries[num3].hashCode >= 0 && equalityComparer.Equals(entries[num3].value, value))
				{
					return num3;
				}
				num3++;
				num2 = -232489307;
				continue;
				IL_00a8:
				int num4;
				if (num3 >= _count)
				{
					num2 = -232489308;
					num4 = num2;
				}
				else
				{
					num2 = -232489311;
					num4 = num2;
				}
			}
			goto IL_004f;
			IL_0085:
			equalityComparer = ooabukyrafXryRkJUhQNqvEtESQ;
			num3 = 0;
			num2 = -232489307;
			goto IL_001f;
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
					num = 1941147958;
					num2 = num;
				}
				else
				{
					num = 1941147956;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x73B39135)
					{
					case 0:
						goto IL_0014;
					case 2:
						break;
					case 3:
						throw new ArgumentException("index points to an invalid entry.");
					default:
						return _entries[index].key;
					}
					break;
					IL_0014:
					num = 1941147959;
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
					num = 1424593079;
					num2 = num;
				}
				else
				{
					num = 1424593078;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x54E990B5)
					{
					case 0:
						goto IL_0014;
					case 1:
						break;
					case 3:
						throw new ArgumentException("index points to an invalid entry.");
					default:
						return new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					}
					break;
					IL_0014:
					num = 1424593076;
				}
			}
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
			if ((uint)index < (uint)_count)
			{
				while (true)
				{
					int num = 782078301;
					while (true)
					{
						switch (num ^ 0x2E9D915C)
						{
						case 2:
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
							num = 782078300;
							continue;
						}
						entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
						return true;
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
			while (true)
			{
				int num = -234929111;
				while (true)
				{
					switch (num ^ -234929112)
					{
					case 2:
						break;
					case 1:
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
						goto IL_0052;
					default:
						return -1;
					}
					break;
					IL_0052:
					num = -234929112;
				}
			}
		}

		public bool GetNextKey(ref int index, out TKey key)
		{
			index++;
			while (true)
			{
				int num = 919140818;
				while (true)
				{
					switch (num ^ 0x36C8F9D1)
					{
					case 2:
						break;
					case 3:
						if ((uint)index >= (uint)_count)
						{
							num = 919140817;
							continue;
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
					case 0:
						key = default(TKey);
						num = 919140816;
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool GetNextValue(ref int index, out TValue value)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				goto IL_0017;
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
			int num = -932065907;
			goto IL_001c;
			IL_0017:
			num = -932065908;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ -932065905)
				{
				case 0:
					break;
				case 3:
					return false;
				case 2:
					goto IL_0081;
				default:
					return false;
				}
				break;
				IL_0081:
				value = default(TValue);
				num = -932065906;
			}
			goto IL_0017;
		}

		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index++;
			while (true)
			{
				int num = 259411864;
				while (true)
				{
					switch (num ^ 0xF764F99)
					{
					case 2:
						break;
					case 1:
						if ((uint)index >= (uint)_count)
						{
							num = 259411866;
							continue;
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
						num = 259411865;
						continue;
					case 4:
						return false;
					case 3:
						entry = default(KeyValuePair<TKey, TValue>);
						num = 259411869;
						continue;
					default:
						entry = default(KeyValuePair<TKey, TValue>);
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
			while (_entries[index].hashCode >= 0)
			{
				Remove(_entries[index].key);
				int num = -193614451;
				while (true)
				{
					switch (num ^ -193614452)
					{
					case 0:
						goto IL_0014;
					case 2:
						break;
					default:
						return true;
					}
					break;
					IL_0014:
					num = -193614450;
				}
			}
			return false;
		}

		private void dltGwNGuOzjStdhAgzeuPOwejmfS(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_011a;
			IL_0006:
			int num = 1867632066;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			Entry[] entries = default(Entry[]);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x6F51CDC1)
				{
				case 9:
					break;
				default:
					return;
				case 10:
					num = 1867632071;
					continue;
				case 2:
					goto IL_0052;
				case 6:
					goto IL_0069;
				case 3:
					throw new ArgumentNullException("array");
				case 11:
					num2++;
					num = 1867632071;
					continue;
				case 5:
					if (entries[num2].hashCode >= 0)
					{
						P_0[P_1++] = new KeyValuePair<TKey, TValue>(entries[num2].key, entries[num2].value);
						num = 1867632074;
						continue;
					}
					goto case 11;
				case 1:
					throw new ArgumentOutOfRangeException("index");
				case 8:
					if (P_0.Length - P_1 < Count)
					{
						throw new Exception();
					}
					goto case 7;
				case 4:
					goto IL_011a;
				case 7:
					count = _count;
					entries = _entries;
					num2 = 0;
					num = 1867632075;
					continue;
				case 0:
					return;
				}
				break;
				IL_0069:
				int num3;
				if (num2 >= count)
				{
					num = 1867632065;
					num3 = num;
				}
				else
				{
					num = 1867632068;
					num3 = num;
				}
				continue;
				IL_0052:
				int num4;
				if (P_1 > P_0.Length)
				{
					num = 1867632064;
					num4 = num;
				}
				else
				{
					num = 1867632073;
					num4 = num;
				}
			}
			goto IL_0006;
			IL_011a:
			int num5;
			if (P_1 < 0)
			{
				num = 1867632064;
				num5 = num;
			}
			else
			{
				num = 1867632067;
				num5 = num;
			}
			goto IL_000b;
		}

		private void YJaAHaimrHWIfKrgfWxeihnqrcza(int P_0)
		{
			int num = SMRrJJCttPTUolTUlqvjjBcJZmy.ngezoiHnXAnMvZYTlmcQTlddhZKD(P_0);
			qGaMYlHsqJBlIcPeaIimFjKSzAXf = new int[num];
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < qGaMYlHsqJBlIcPeaIimFjKSzAXf.Length)
				{
					num3 = 200760983;
					num4 = num3;
				}
				else
				{
					num3 = 200760980;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0xBF75E96)
					{
					case 4:
						num3 = 200760983;
						continue;
					default:
						return;
					case 1:
						qGaMYlHsqJBlIcPeaIimFjKSzAXf[num2] = -1;
						num2++;
						num3 = 200760981;
						continue;
					case 3:
						break;
					case 2:
						_entries = new Entry[num];
						FBDDgkGsBCdENkbsiJNLrgqPpHXC = -1;
						num3 = 200760982;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void cstwlfTlxxCXbEfllWofrtFdGPqh(TKey P_0, TValue P_1, bool P_2)
		{
			if (!WGehdtGoYKIGKvRKnNsuQzYujsL)
			{
				goto IL_000a;
			}
			goto IL_014b;
			IL_000a:
			int num = 1261567426;
			goto IL_000f;
			IL_000f:
			int num4 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x4B31FDC0)
				{
				case 4:
					break;
				case 11:
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					return;
				case 17:
					num = 1261567424;
					continue;
				case 0:
					_entries[num4].hashCode = num3;
					_entries[num4].next = qGaMYlHsqJBlIcPeaIimFjKSzAXf[num5];
					_entries[num4].key = P_0;
					_entries[num4].value = P_1;
					qGaMYlHsqJBlIcPeaIimFjKSzAXf[num5] = num4;
					num = 1261567433;
					continue;
				case 16:
					if (_count == _entries.Length)
					{
						SSgoHVLKmdbMSiSYImMBoZFCtiP();
						num5 = num3 % qGaMYlHsqJBlIcPeaIimFjKSzAXf.Length;
						num = 1261567429;
						continue;
					}
					goto case 5;
				case 13:
					throw new ArgumentNullException("key");
				case 2:
					goto IL_0129;
				case 8:
					goto IL_014b;
				case 1:
					num2 = _entries[num2].next;
					num = 1261567431;
					continue;
				case 7:
					goto IL_0183;
				case 5:
					num4 = _count;
					_count++;
					num = 1261567424;
					continue;
				case 15:
					_entries[num2].value = P_1;
					num = 1261567435;
					continue;
				case 14:
					if (XgIAQrGhAxqovdeEirMSGrnEIdiX > 0)
					{
						num4 = FBDDgkGsBCdENkbsiJNLrgqPpHXC;
						FBDDgkGsBCdENkbsiJNLrgqPpHXC = _entries[num4].next;
						num = 1261567436;
						continue;
					}
					goto case 16;
				case 12:
					XgIAQrGhAxqovdeEirMSGrnEIdiX--;
					num = 1261567441;
					continue;
				case 3:
					if (_entries[num2].hashCode != num3 || !CxlUnKAGjhpBDnbYFDLUbNJKPkw.Equals(_entries[num2].key, P_0))
					{
						goto case 1;
					}
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					goto case 15;
				case 6:
					goto IL_0276;
				case 10:
					num = 1261567431;
					continue;
				default:
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					sQrzaytHzEaFnInVPIRQoBDHCYN++;
					return;
				}
				break;
				IL_0183:
				int num6;
				if (num2 >= 0)
				{
					num = 1261567427;
					num6 = num;
				}
				else
				{
					num = 1261567438;
					num6 = num;
				}
				continue;
				IL_0129:
				int num7;
				if (object.ReferenceEquals(P_0, null))
				{
					num = 1261567437;
					num7 = num;
				}
				else
				{
					num = 1261567432;
					num7 = num;
				}
			}
			goto IL_000a;
			IL_0276:
			num3 = CxlUnKAGjhpBDnbYFDLUbNJKPkw.GetHashCode(P_0) & 0x7FFFFFFF;
			num5 = num3 % qGaMYlHsqJBlIcPeaIimFjKSzAXf.Length;
			num2 = qGaMYlHsqJBlIcPeaIimFjKSzAXf[num5];
			num = 1261567434;
			goto IL_000f;
			IL_014b:
			if (qGaMYlHsqJBlIcPeaIimFjKSzAXf == null)
			{
				YJaAHaimrHWIfKrgfWxeihnqrcza(0);
				num = 1261567430;
				goto IL_000f;
			}
			goto IL_0276;
		}

		private void SSgoHVLKmdbMSiSYImMBoZFCtiP()
		{
			SSgoHVLKmdbMSiSYImMBoZFCtiP(SMRrJJCttPTUolTUlqvjjBcJZmy.DpJaovjEgIJtMJACfnCoETZbuAyD(_count), false);
		}

		private void SSgoHVLKmdbMSiSYImMBoZFCtiP(int P_0, bool P_1)
		{
			int[] array = new int[P_0];
			int num6 = default(int);
			Entry[] array2 = default(Entry[]);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = -1448123987;
				while (true)
				{
					switch (num ^ -1448123988)
					{
					case 2:
						break;
					default:
						return;
					case 11:
					{
						int num7;
						if (num6 < _count)
						{
							num = -1448123996;
							num7 = num;
						}
						else
						{
							num = -1448123997;
							num7 = num;
						}
						continue;
					}
					case 5:
					{
						int num9;
						if (array2[num3].hashCode < 0)
						{
							num = -1448123988;
							num9 = num;
						}
						else
						{
							num = -1448123999;
							num9 = num;
						}
						continue;
					}
					case 12:
						if (P_1)
						{
							num6 = 0;
							num = -1448123993;
							continue;
						}
						goto case 15;
					case 15:
						num3 = 0;
						num = -1448123992;
						continue;
					case 6:
						array2 = new Entry[P_0];
						Array.Copy(_entries, 0, array2, 0, _count);
						num = -1448124000;
						continue;
					case 8:
					{
						int num8;
						if (array2[num6].hashCode == -1)
						{
							num = -1448123994;
							num8 = num;
						}
						else
						{
							num = -1448123998;
							num8 = num;
						}
						continue;
					}
					case 3:
						array[num4] = -1;
						num4++;
						num = -1448123995;
						continue;
					case 4:
						if (num3 >= _count)
						{
							qGaMYlHsqJBlIcPeaIimFjKSzAXf = array;
							_entries = array2;
							num = -1448123989;
							continue;
						}
						goto case 5;
					case 10:
						num6++;
						num = -1448123993;
						continue;
					case 14:
						array2[num6].hashCode = CxlUnKAGjhpBDnbYFDLUbNJKPkw.GetHashCode(array2[num6].key) & 0x7FFFFFFF;
						num = -1448123994;
						continue;
					case 9:
					{
						int num5;
						if (num4 < array.Length)
						{
							num = -1448123985;
							num5 = num;
						}
						else
						{
							num = -1448123990;
							num5 = num;
						}
						continue;
					}
					case 1:
						num4 = 0;
						num = -1448123995;
						continue;
					case 0:
						num3++;
						num = -1448123992;
						continue;
					case 13:
					{
						int num2 = array2[num3].hashCode % P_0;
						array2[num3].next = array[num2];
						array[num2] = num3;
						num = -1448123988;
						continue;
					}
					case 7:
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
			if (num >= 0 && ooabukyrafXryRkJUhQNqvEtESQ.Equals(_entries[num].value, keyValuePair.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = IndexOfKey(keyValuePair.Key);
			while (true)
			{
				int num2 = -2069623502;
				while (true)
				{
					switch (num2 ^ -2069623504)
					{
					case 0:
						break;
					case 2:
						if (num >= 0 && ooabukyrafXryRkJUhQNqvEtESQ.Equals(_entries[num].value, keyValuePair.Value))
						{
							goto IL_0055;
						}
						return false;
					default:
						Remove(keyValuePair.Key);
						return true;
					}
					break;
					IL_0055:
					num2 = -2069623503;
				}
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			dltGwNGuOzjStdhAgzeuPOwejmfS(array, index);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num3 = default(int);
			DictionaryEntry[] array2 = default(DictionaryEntry[]);
			Entry[] entries = default(Entry[]);
			int num5 = default(int);
			Entry[] entries2 = default(Entry[]);
			while (true)
			{
				if (array.Rank == 1)
				{
					while (true)
					{
						if (array.GetLowerBound(0) != 0)
						{
							throw new Exception();
						}
						while (true)
						{
							IL_0110:
							if (index >= 0)
							{
								int num;
								int num2;
								if (index > array.Length)
								{
									num = 1437482219;
									num2 = num;
								}
								else
								{
									num = 1437482213;
									num2 = num;
								}
								while (true)
								{
									switch (num ^ 0x55AE3CE1)
									{
									case 0:
										num = 1437482214;
										continue;
									case 11:
										num3++;
										num = 1437482216;
										continue;
									case 6:
										if (array is DictionaryEntry[])
										{
											array2 = array as DictionaryEntry[];
											entries = _entries;
											num3 = 0;
											num = 1437482216;
											continue;
										}
										goto IL_0199;
									case 8:
										break;
									case 3:
										if (entries[num3].hashCode >= 0)
										{
											array2[index++] = new DictionaryEntry(entries[num3].key, entries[num3].value);
											num = 1437482218;
											continue;
										}
										goto case 11;
									case 2:
									{
										KeyValuePair<TKey, TValue>[] array3 = array as KeyValuePair<TKey, TValue>[];
										if (array3 != null)
										{
											dltGwNGuOzjStdhAgzeuPOwejmfS(array3, index);
											return;
										}
										goto case 6;
									}
									case 5:
										goto IL_0110;
									case 4:
										if (array.Length - index < Count)
										{
											throw new Exception();
										}
										goto case 2;
									case 10:
										goto IL_0151;
									case 7:
										goto end_IL_0083;
									case 9:
										if (num3 >= _count)
										{
											return;
										}
										goto case 3;
									default:
										goto IL_0199;
									}
									break;
								}
								break;
							}
							goto IL_0151;
							IL_0151:
							throw new ArgumentOutOfRangeException("index");
						}
						continue;
						IL_0199:
						object[] array4 = array as object[];
						if (array4 == null)
						{
							throw new Exception();
						}
						try
						{
							int count = _count;
							while (true)
							{
								int num4 = 1437482208;
								while (true)
								{
									switch (num4 ^ 0x55AE3CE1)
									{
									case 4:
										break;
									default:
										return;
									case 0:
									{
										int num6;
										if (num5 < count)
										{
											num4 = 1437482210;
											num6 = num4;
										}
										else
										{
											num4 = 1437482211;
											num6 = num4;
										}
										continue;
									}
									case 5:
										num5++;
										num4 = 1437482209;
										continue;
									case 3:
										if (entries2[num5].hashCode >= 0)
										{
											array4[index++] = new KeyValuePair<TKey, TValue>(entries2[num5].key, entries2[num5].value);
											num4 = 1437482212;
											continue;
										}
										goto case 5;
									case 1:
										entries2 = _entries;
										num5 = 0;
										num4 = 1437482209;
										continue;
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
						continue;
						end_IL_0083:
						break;
					}
					continue;
				}
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
				while (true)
				{
					switch (0x4298080D ^ 0x4298080C)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("key");
					}
					break;
				}
			}
			TpwEapuFMOXMTZQCXRiMjbCLtgY<TValue>(value, "value");
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
			if (ZZQBFWEnBOntoXDfEnPMEBmVtMI(key))
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
			if (ZZQBFWEnBOntoXDfEnPMEBmVtMI(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool ZZQBFWEnBOntoXDfEnPMEBmVtMI(object P_0)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (0x78FB6DE4 ^ 0x78FB6DE5)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("key");
					}
					break;
				}
			}
			return P_0 is TKey;
		}

		private static void TpwEapuFMOXMTZQCXRiMjbCLtgY<T>(object P_0, string P_1)
		{
			if (P_0 != null)
			{
				return;
			}
			T val = default(T);
			while (true)
			{
				switch (-277750906 ^ -277750905)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (val != null)
					{
						throw new ArgumentNullException(P_1);
					}
					return;
				case 2:
					return;
				}
			}
		}
	}
}
