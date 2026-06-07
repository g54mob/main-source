using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct McxTweaVquCebucWDaQJMtfANgY
		{
			public TKey VoQbUhcEgfKVubpnlLEXkujSnBHc;

			public TValue JHgsNLxiAQVnmyfVeWejfTJocIu;

			public McxTweaVquCebucWDaQJMtfANgY(TKey key, TValue value)
			{
				VoQbUhcEgfKVubpnlLEXkujSnBHc = key;
				JHgsNLxiAQVnmyfVeWejfTJocIu = value;
			}

			public KeyValuePair<TKey, TValue> RHkKAifgUfCmCOaYXqRPqnplHOn()
			{
				return new KeyValuePair<TKey, TValue>(VoQbUhcEgfKVubpnlLEXkujSnBHc, JHgsNLxiAQVnmyfVeWejfTJocIu);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

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
						while (true)
						{
							int num = -428578061;
							while (true)
							{
								switch (num ^ -428578064)
								{
								case 0:
									break;
								case 3:
									goto IL_002e;
								case 2:
									goto IL_0059;
								case 4:
									goto end_IL_0008;
								default:
									return new DictionaryEntry(xbRrcEKKIAKiQkVzQCekOswVHrJ.Key, xbRrcEKKIAKiQkVzQCekOswVHrJ.Value);
								}
								break;
								IL_0059:
								if (IkrEhreRxVGUYNrGUTlbSFukAGFk == 1)
								{
									num = -428578063;
									continue;
								}
								return new KeyValuePair<TKey, TValue>(xbRrcEKKIAKiQkVzQCekOswVHrJ.Key, xbRrcEKKIAKiQkVzQCekOswVHrJ.Value);
								IL_002e:
								int num2;
								if (mFfLSVvRgZulYzYIyEkqCMoEiNXj == LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1)
								{
									num = -428578060;
									num2 = num;
								}
								else
								{
									num = -428578062;
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

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (-588210311 ^ -588210309)
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
					return new DictionaryEntry(xbRrcEKKIAKiQkVzQCekOswVHrJ.Key, xbRrcEKKIAKiQkVzQCekOswVHrJ.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x4815A8CA ^ 0x4815A8CB)
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
					return xbRrcEKKIAKiQkVzQCekOswVHrJ.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != 0)
					{
						if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1)
						{
							goto IL_004d;
						}
						while (true)
						{
							switch (0x3F56F338 ^ 0x3F56F339)
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
					return xbRrcEKKIAKiQkVzQCekOswVHrJ.Value;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
				jKkfIpbjIavykANnmWTcMYiQOxz = dictionary.WHeApkgLGAZTtUIEfvfXHvQYCck.Version;
				mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
				IkrEhreRxVGUYNrGUTlbSFukAGFk = getEnumeratorRetType;
				xbRrcEKKIAKiQkVzQCekOswVHrJ = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck.Version)
				{
					goto IL_0018;
				}
				goto IL_006e;
				IL_0018:
				int num = -1963998435;
				goto IL_001d;
				IL_001d:
				switch (num ^ -1963998434)
				{
				case 0:
					break;
				case 4:
					return true;
				case 1:
					goto IL_006e;
				case 3:
					throw new Exception();
				default:
					return false;
				}
				goto IL_0018;
				IL_006e:
				if ((uint)mFfLSVvRgZulYzYIyEkqCMoEiNXj >= (uint)LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count)
				{
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1;
					xbRrcEKKIAKiQkVzQCekOswVHrJ = default(KeyValuePair<TKey, TValue>);
					num = -1963998436;
				}
				else
				{
					xbRrcEKKIAKiQkVzQCekOswVHrJ = new KeyValuePair<TKey, TValue>(LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items[mFfLSVvRgZulYzYIyEkqCMoEiNXj].VoQbUhcEgfKVubpnlLEXkujSnBHc, LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items[mFfLSVvRgZulYzYIyEkqCMoEiNXj].JHgsNLxiAQVnmyfVeWejfTJocIu);
					mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
					num = -1963998438;
				}
				goto IL_001d;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck.Version)
				{
					throw new Exception();
				}
				mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
				xbRrcEKKIAKiQkVzQCekOswVHrJ = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private IndexedDictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

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
							while (true)
							{
								int num = -1211949564;
								while (true)
								{
									switch (num ^ -1211949562)
									{
									case 0:
										break;
									case 2:
										goto IL_002a;
									case 3:
										goto end_IL_0008;
									default:
										return xMQAEwybFxHWGsoeWBzXGKqkIuk;
									}
									break;
									IL_002a:
									int num2;
									if (mFfLSVvRgZulYzYIyEkqCMoEiNXj == LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1)
									{
										num = -1211949563;
										num2 = num;
									}
									else
									{
										num = -1211949561;
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

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
					jKkfIpbjIavykANnmWTcMYiQOxz = dictionary.WHeApkgLGAZTtUIEfvfXHvQYCck.Version;
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					xMQAEwybFxHWGsoeWBzXGKqkIuk = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck.Version)
					{
						throw new Exception();
					}
					if ((uint)mFfLSVvRgZulYzYIyEkqCMoEiNXj < (uint)LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count)
					{
						xMQAEwybFxHWGsoeWBzXGKqkIuk = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items[mFfLSVvRgZulYzYIyEkqCMoEiNXj].VoQbUhcEgfKVubpnlLEXkujSnBHc;
						mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
						return true;
					}
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1;
					xMQAEwybFxHWGsoeWBzXGKqkIuk = default(TKey);
					return false;
				}

				void IEnumerator.Reset()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck.Version)
					{
						throw new Exception();
					}
					while (true)
					{
						mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
						int num = 1807717773;
						while (true)
						{
							switch (num ^ 0x6BBF958F)
							{
							case 0:
								goto IL_001e;
							case 1:
								break;
							default:
								xMQAEwybFxHWGsoeWBzXGKqkIuk = default(TKey);
								return;
							}
							break;
							IL_001e:
							num = 1807717774;
						}
					}
				}
			}

			private IndexedDictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

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

			public KeyCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
				while (true)
				{
					switch (0x4C2747E9 ^ 0x4C2747E8)
					{
					case 0:
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
					throw new ArgumentNullException("array");
				}
				int count = default(int);
				McxTweaVquCebucWDaQJMtfANgY[] items = default(McxTweaVquCebucWDaQJMtfANgY[]);
				int num3 = default(int);
				while (true)
				{
					int num;
					int num2;
					if (index >= 0)
					{
						num = -1040663593;
						num2 = num;
					}
					else
					{
						num = -1040663587;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1040663596)
						{
						case 4:
							num = -1040663595;
							continue;
						case 9:
							throw new ArgumentOutOfRangeException("index");
						case 5:
							count = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count;
							num = -1040663594;
							continue;
						case 2:
							items = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items;
							num = -1040663598;
							continue;
						case 7:
							if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
							{
								throw new Exception();
							}
							goto case 5;
						case 3:
						{
							int num4;
							if (index > array.Length)
							{
								num = -1040663587;
								num4 = num;
							}
							else
							{
								num = -1040663597;
								num4 = num;
							}
							continue;
						}
						case 1:
							break;
						case 8:
							num = -1040663586;
							continue;
						case 0:
							array[index++] = items[num3].VoQbUhcEgfKVubpnlLEXkujSnBHc;
							num3++;
							num = -1040663586;
							continue;
						case 6:
							num3 = 0;
							num = -1040663588;
							continue;
						default:
							if (num3 >= count)
							{
								return;
							}
							goto case 0;
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
				TKey[] array2 = default(TKey[]);
				object[] array3 = default(object[]);
				while (array.Rank == 1)
				{
					while (true)
					{
						if (array.GetLowerBound(0) != 0)
						{
							throw new Exception();
						}
						while (true)
						{
							IL_00eb:
							if (index >= 0)
							{
								int num;
								int num2;
								if (index > array.Length)
								{
									num = 1583494835;
									num2 = num;
								}
								else
								{
									num = 1583494837;
									num2 = num;
								}
								while (true)
								{
									switch (num ^ 0x5E6236B5)
									{
									case 5:
										num = 1583494833;
										continue;
									case 8:
										return;
									case 10:
										CopyTo(array2, index);
										num = 1583494845;
										continue;
									case 6:
										break;
									case 2:
										goto end_IL_00eb;
									case 11:
										array3 = array as object[];
										if (array3 == null)
										{
											throw new Exception();
										}
										goto default;
									case 0:
										if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
										{
											throw new Exception();
										}
										goto case 3;
									case 4:
										goto end_IL_007a;
									case 1:
										goto IL_00eb;
									case 3:
										array2 = array as TKey[];
										num = 1583494844;
										continue;
									case 9:
										goto IL_0120;
									default:
									{
										int count = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count;
										McxTweaVquCebucWDaQJMtfANgY[] items = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items;
										try
										{
											int num3 = 0;
											while (num3 < count)
											{
												while (true)
												{
													array3[index++] = items[num3].VoQbUhcEgfKVubpnlLEXkujSnBHc;
													num3++;
													int num4 = 1583494839;
													while (true)
													{
														switch (num4 ^ 0x5E6236B5)
														{
														case 0:
															num4 = 1583494836;
															continue;
														case 1:
															break;
														default:
															goto end_IL_017c;
														}
														break;
													}
													continue;
													end_IL_017c:
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
									IL_0120:
									int num5;
									if (array2 != null)
									{
										num = 1583494847;
										num5 = num;
									}
									else
									{
										num = 1583494846;
										num5 = num;
									}
								}
							}
							throw new Exception();
							continue;
							end_IL_00eb:
							break;
						}
						continue;
						end_IL_007a:
						break;
					}
				}
				throw new Exception();
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
				private IndexedDictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

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
							if (mFfLSVvRgZulYzYIyEkqCMoEiNXj != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1)
							{
								goto IL_004d;
							}
							while (true)
							{
								switch (-1936515240 ^ -1936515239)
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
						return gQYbKVkDGlhhqclRHXVPDoznkXpu;
					}
				}

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					LbwQyRfKuLNxSjFIaAsDJTuLixL = dictionary;
					jKkfIpbjIavykANnmWTcMYiQOxz = dictionary.WHeApkgLGAZTtUIEfvfXHvQYCck.Version;
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					gQYbKVkDGlhhqclRHXVPDoznkXpu = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck.Version)
					{
						throw new Exception();
					}
					while (true)
					{
						int num;
						if ((uint)mFfLSVvRgZulYzYIyEkqCMoEiNXj < (uint)LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count)
						{
							gQYbKVkDGlhhqclRHXVPDoznkXpu = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items[mFfLSVvRgZulYzYIyEkqCMoEiNXj].JHgsNLxiAQVnmyfVeWejfTJocIu;
							num = -354058365;
						}
						else
						{
							mFfLSVvRgZulYzYIyEkqCMoEiNXj = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count + 1;
							num = -354058367;
						}
						while (true)
						{
							switch (num ^ -354058365)
							{
							case 3:
								goto IL_001e;
							case 1:
								break;
							case 0:
								mFfLSVvRgZulYzYIyEkqCMoEiNXj++;
								return true;
							default:
								gQYbKVkDGlhhqclRHXVPDoznkXpu = default(TValue);
								return false;
							}
							break;
							IL_001e:
							num = -354058366;
						}
					}
				}

				void IEnumerator.Reset()
				{
					if (jKkfIpbjIavykANnmWTcMYiQOxz != LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck.Version)
					{
						while (true)
						{
							switch (-1796257392 ^ -1796257391)
							{
							case 2:
								continue;
							case 1:
								throw new Exception();
							}
							break;
						}
					}
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = 0;
					gQYbKVkDGlhhqclRHXVPDoznkXpu = default(TValue);
				}
			}

			private IndexedDictionary<TKey, TValue> LbwQyRfKuLNxSjFIaAsDJTuLixL;

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

			public ValueCollection(IndexedDictionary<TKey, TValue> dictionary)
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
					goto IL_0006;
				}
				goto IL_00df;
				IL_0006:
				int num = 691123727;
				goto IL_000b;
				IL_000b:
				McxTweaVquCebucWDaQJMtfANgY[] items = default(McxTweaVquCebucWDaQJMtfANgY[]);
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					switch (num ^ 0x2931B60B)
					{
					case 3:
						break;
					default:
						return;
					case 4:
						throw new ArgumentNullException("array");
					case 2:
						if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
						{
							throw new Exception();
						}
						goto case 8;
					case 7:
						goto IL_0077;
					case 5:
						throw new Exception();
					case 0:
						array[index++] = items[num2].JHgsNLxiAQVnmyfVeWejfTJocIu;
						num2++;
						num = 691123724;
						continue;
					case 6:
						goto IL_00c5;
					case 1:
						goto IL_00df;
					case 8:
						count = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count;
						items = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items;
						num2 = 0;
						num = 691123724;
						continue;
					case 9:
						return;
					}
					break;
					IL_00c5:
					int num3;
					if (index > array.Length)
					{
						num = 691123726;
						num3 = num;
					}
					else
					{
						num = 691123721;
						num3 = num;
					}
					continue;
					IL_0077:
					int num4;
					if (num2 >= count)
					{
						num = 691123714;
						num4 = num;
					}
					else
					{
						num = 691123723;
						num4 = num;
					}
				}
				goto IL_0006;
				IL_00df:
				int num5;
				if (index >= 0)
				{
					num = 691123725;
					num5 = num;
				}
				else
				{
					num = 691123726;
					num5 = num;
				}
				goto IL_000b;
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
					throw new ArgumentNullException("array");
				}
				int count = default(int);
				object[] array2 = default(object[]);
				while (array.Rank == 1)
				{
					while (true)
					{
						IL_0114:
						int num;
						int num2;
						if (array.GetLowerBound(0) != 0)
						{
							num = -639884453;
							num2 = num;
						}
						else
						{
							num = -639884452;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -639884451)
							{
							case 5:
								num = -639884457;
								continue;
							case 8:
								break;
							case 11:
								throw new Exception();
							case 4:
								count = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._count;
								num = -639884460;
								continue;
							case 10:
								goto end_IL_0016;
							case 3:
								throw new Exception();
							case 7:
								if (array.Length - index < LbwQyRfKuLNxSjFIaAsDJTuLixL.Count)
								{
									throw new Exception();
								}
								goto case 0;
							case 6:
								throw new Exception();
							case 0:
							{
								TValue[] array3 = array as TValue[];
								if (array3 != null)
								{
									CopyTo(array3, index);
									return;
								}
								break;
							}
							case 2:
								goto IL_0114;
							case 1:
								if (index < 0)
								{
									goto case 3;
								}
								goto IL_0138;
							default:
							{
								McxTweaVquCebucWDaQJMtfANgY[] items = LbwQyRfKuLNxSjFIaAsDJTuLixL.WHeApkgLGAZTtUIEfvfXHvQYCck._items;
								try
								{
									int num3 = 0;
									while (true)
									{
										int num4;
										int num5;
										if (num3 < count)
										{
											num4 = -639884450;
											num5 = num4;
										}
										else
										{
											num4 = -639884452;
											num5 = num4;
										}
										while (true)
										{
											switch (num4 ^ -639884451)
											{
											case 0:
												num4 = -639884450;
												continue;
											default:
												return;
											case 3:
												array2[index++] = items[num3].JHgsNLxiAQVnmyfVeWejfTJocIu;
												num3++;
												num4 = -639884449;
												continue;
											case 2:
												break;
											case 1:
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
							array2 = array as object[];
							int num6;
							if (array2 == null)
							{
								num = -639884458;
								num6 = num;
							}
							else
							{
								num = -639884455;
								num6 = num;
							}
							continue;
							IL_0138:
							int num7;
							if (index > array.Length)
							{
								num = -639884450;
								num7 = num;
							}
							else
							{
								num = -639884454;
								num7 = num;
							}
							continue;
							end_IL_0016:
							break;
						}
						break;
					}
				}
				throw new Exception();
			}
		}

		private static readonly bool WGehdtGoYKIGKvRKnNsuQzYujsL = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool qSISkWksASjVDSkFDsXeoPPGop = ReflectionTools.IsValueType(typeof(TValue));

		private IEqualityComparer<TKey> CxlUnKAGjhpBDnbYFDLUbNJKPkw = EqualityComparerNoAlloc<TKey>.Default;

		private IEqualityComparer<TValue> ooabukyrafXryRkJUhQNqvEtESQ = EqualityComparerNoAlloc<TValue>.Default;

		private readonly AList<McxTweaVquCebucWDaQJMtfANgY> WHeApkgLGAZTtUIEfvfXHvQYCck;

		private readonly ADictionary<TKey, int> uzoCjuXoZVchOYeMrSOjQzqivJq;

		private bool RFPmXuvhneQjezsggqClUZiTGte;

		public int Count
		{
			get
			{
				return WHeApkgLGAZTtUIEfvfXHvQYCck._count;
			}
		}

		public bool ContainsDuplicateKeys
		{
			get
			{
				if (!RFPmXuvhneQjezsggqClUZiTGte)
				{
					return false;
				}
				return uzoCjuXoZVchOYeMrSOjQzqivJq._count < WHeApkgLGAZTtUIEfvfXHvQYCck._count;
			}
		}

		public bool AllowDuplicateKeys
		{
			get
			{
				return RFPmXuvhneQjezsggqClUZiTGte;
			}
			set
			{
				if (RFPmXuvhneQjezsggqClUZiTGte != value)
				{
					RFPmXuvhneQjezsggqClUZiTGte = value;
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
				if ((uint)index >= (uint)WHeApkgLGAZTtUIEfvfXHvQYCck._count)
				{
					while (true)
					{
						switch (-64516894 ^ -64516893)
						{
						case 0:
							continue;
						case 1:
							throw new ArgumentOutOfRangeException("index");
						}
						break;
					}
				}
				return WHeApkgLGAZTtUIEfvfXHvQYCck._items[index].JHgsNLxiAQVnmyfVeWejfTJocIu;
			}
			set
			{
				if ((uint)index >= (uint)WHeApkgLGAZTtUIEfvfXHvQYCck._count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				while (true)
				{
					WHeApkgLGAZTtUIEfvfXHvQYCck._items[index].JHgsNLxiAQVnmyfVeWejfTJocIu = value;
					int num = 207169960;
					while (true)
					{
						switch (num ^ 0xC5929A9)
						{
						case 0:
							goto IL_0019;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0019:
						num = 207169963;
					}
				}
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
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				ooabukyrafXryRkJUhQNqvEtESQ = value;
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
				while (true)
				{
					int num2 = 1272123839;
					while (true)
					{
						switch (num2 ^ 0x4BD311BE)
						{
						case 3:
							break;
						case 1:
						{
							int num3;
							if (num < 0)
							{
								num2 = 1272123838;
								num3 = num2;
							}
							else
							{
								num2 = 1272123836;
								num3 = num2;
							}
							continue;
						}
						case 0:
							throw new KeyNotFoundException(string.Concat("Key \"", key, "\" does not exist."));
						default:
							return WHeApkgLGAZTtUIEfvfXHvQYCck._items[num].JHgsNLxiAQVnmyfVeWejfTJocIu;
						}
						break;
					}
				}
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
				return ((ICollection)WHeApkgLGAZTtUIEfvfXHvQYCck).IsSynchronized;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return ((ICollection)WHeApkgLGAZTtUIEfvfXHvQYCck).SyncRoot;
			}
		}

		TValue IReadOnlyList<TValue>.this[int P_0]
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
			RFPmXuvhneQjezsggqClUZiTGte = allowDuplicateKeys;
			WHeApkgLGAZTtUIEfvfXHvQYCck = new AList<McxTweaVquCebucWDaQJMtfANgY>(capacity);
			uzoCjuXoZVchOYeMrSOjQzqivJq = new ADictionary<TKey, int>(capacity);
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
				for (int i = 0; i < indexedDictionary.WHeApkgLGAZTtUIEfvfXHvQYCck._count; i++)
				{
					Add(indexedDictionary.WHeApkgLGAZTtUIEfvfXHvQYCck._items[i].VoQbUhcEgfKVubpnlLEXkujSnBHc, indexedDictionary.WHeApkgLGAZTtUIEfvfXHvQYCck._items[i].JHgsNLxiAQVnmyfVeWejfTJocIu);
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
			return WHeApkgLGAZTtUIEfvfXHvQYCck._items[uzoCjuXoZVchOYeMrSOjQzqivJq[key]].JHgsNLxiAQVnmyfVeWejfTJocIu;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int value2;
			if (!uzoCjuXoZVchOYeMrSOjQzqivJq.TryGetValue(key, out value2))
			{
				while (true)
				{
					int num = 2061539820;
					while (true)
					{
						switch (num ^ 0x7AE099ED)
						{
						case 0:
							break;
						case 1:
							goto IL_002e;
						default:
							return false;
						}
						break;
						IL_002e:
						value = default(TValue);
						num = 2061539823;
					}
				}
			}
			value = WHeApkgLGAZTtUIEfvfXHvQYCck._items[value2].JHgsNLxiAQVnmyfVeWejfTJocIu;
			return true;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)WHeApkgLGAZTtUIEfvfXHvQYCck._count)
			{
				while (true)
				{
					switch (-205462452 ^ -205462451)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentOutOfRangeException("index");
					}
					break;
				}
			}
			return WHeApkgLGAZTtUIEfvfXHvQYCck[index].VoQbUhcEgfKVubpnlLEXkujSnBHc;
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return WHeApkgLGAZTtUIEfvfXHvQYCck[uzoCjuXoZVchOYeMrSOjQzqivJq[key]].RHkKAifgUfCmCOaYXqRPqnplHOn();
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)WHeApkgLGAZTtUIEfvfXHvQYCck._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			while (true)
			{
				McxTweaVquCebucWDaQJMtfANgY mcxTweaVquCebucWDaQJMtfANgY = WHeApkgLGAZTtUIEfvfXHvQYCck[index];
				int num = -564863288;
				while (true)
				{
					switch (num ^ -564863287)
					{
					case 0:
						goto IL_0019;
					case 2:
						break;
					default:
						return mcxTweaVquCebucWDaQJMtfANgY.RHkKAifgUfCmCOaYXqRPqnplHOn();
					}
					break;
					IL_0019:
					num = -564863285;
				}
			}
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			int value;
			if (!uzoCjuXoZVchOYeMrSOjQzqivJq.TryGetValue(key, out value))
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = WHeApkgLGAZTtUIEfvfXHvQYCck[value].RHkKAifgUfCmCOaYXqRPqnplHOn();
			return true;
		}

		public void Add(TKey key, TValue value)
		{
			bool flag = uzoCjuXoZVchOYeMrSOjQzqivJq.ContainsKey(key);
			int value2 = default(int);
			while (true)
			{
				int num = -1203550841;
				while (true)
				{
					switch (num ^ -1203550847)
					{
					case 7:
						break;
					case 6:
					{
						int num2;
						if (flag)
						{
							num = -1203550845;
							num2 = num;
						}
						else
						{
							num = -1203550847;
							num2 = num;
						}
						continue;
					}
					case 4:
						throw new ArgumentException(string.Concat("Key \"", key, "\" is already in use."));
					case 2:
					{
						int num3;
						if (!RFPmXuvhneQjezsggqClUZiTGte)
						{
							num = -1203550843;
							num3 = num;
						}
						else
						{
							num = -1203550847;
							num3 = num;
						}
						continue;
					}
					case 3:
						if (flag)
						{
							uzoCjuXoZVchOYeMrSOjQzqivJq[key] = value2;
							num = -1203550848;
							continue;
						}
						goto default;
					case 0:
						value2 = WHeApkgLGAZTtUIEfvfXHvQYCck.Add(new McxTweaVquCebucWDaQJMtfANgY(key, value));
						num = -1203550846;
						continue;
					case 1:
						return;
					default:
						uzoCjuXoZVchOYeMrSOjQzqivJq.Add(key, value2);
						return;
					}
					break;
				}
			}
		}

		public void SetValue(TKey key, TValue value)
		{
			int value2;
			if (uzoCjuXoZVchOYeMrSOjQzqivJq.TryGetValue(key, out value2))
			{
				WHeApkgLGAZTtUIEfvfXHvQYCck._items[value2].JHgsNLxiAQVnmyfVeWejfTJocIu = value;
				uzoCjuXoZVchOYeMrSOjQzqivJq[key] = value2;
				return;
			}
			while (true)
			{
				Add(key, value);
				int num = -1585087406;
				while (true)
				{
					switch (num ^ -1585087408)
					{
					case 0:
						goto IL_0035;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0035:
					num = -1585087407;
				}
			}
		}

		public bool Remove(TKey key)
		{
			uzoCjuXoZVchOYeMrSOjQzqivJq.Remove(key);
			if (RFPmXuvhneQjezsggqClUZiTGte)
			{
				goto IL_0015;
			}
			int num = IndexOfKey(key);
			int num2 = -914531903;
			goto IL_001a;
			IL_001a:
			int num3 = default(int);
			bool result = default(bool);
			while (true)
			{
				switch (num2 ^ -914531901)
				{
				case 0:
					break;
				case 3:
					if (CxlUnKAGjhpBDnbYFDLUbNJKPkw.Equals(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num3].VoQbUhcEgfKVubpnlLEXkujSnBHc, key))
					{
						WHeApkgLGAZTtUIEfvfXHvQYCck.RemoveAt(num3);
						result = true;
						num2 = -914531898;
						continue;
					}
					goto case 5;
				case 5:
					num3--;
					num2 = -914531897;
					continue;
				case 4:
					if (num3 < 0)
					{
						return result;
					}
					goto case 3;
				case 6:
					num2 = -914531897;
					continue;
				case 1:
					result = false;
					num3 = WHeApkgLGAZTtUIEfvfXHvQYCck._count - 1;
					num2 = -914531899;
					continue;
				default:
					if (num < 0)
					{
						return false;
					}
					RemoveAt(num);
					return true;
				}
				break;
			}
			goto IL_0015;
			IL_0015:
			num2 = -914531902;
			goto IL_001a;
		}

		public void RemoveAt(int index)
		{
			if ((uint)index >= (uint)WHeApkgLGAZTtUIEfvfXHvQYCck._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			TKey voQbUhcEgfKVubpnlLEXkujSnBHc = WHeApkgLGAZTtUIEfvfXHvQYCck._items[index].VoQbUhcEgfKVubpnlLEXkujSnBHc;
			WHeApkgLGAZTtUIEfvfXHvQYCck.RemoveAt(index);
			uzoCjuXoZVchOYeMrSOjQzqivJq.Remove(voQbUhcEgfKVubpnlLEXkujSnBHc);
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
				TKey voQbUhcEgfKVubpnlLEXkujSnBHc = WHeApkgLGAZTtUIEfvfXHvQYCck._items[num].VoQbUhcEgfKVubpnlLEXkujSnBHc;
				RemoveAt(num);
				uzoCjuXoZVchOYeMrSOjQzqivJq.Remove(voQbUhcEgfKVubpnlLEXkujSnBHc);
				int num2 = 1981640241;
				while (true)
				{
					switch (num2 ^ 0x761D6E31)
					{
					case 2:
						goto IL_000d;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000d:
					num2 = 1981640240;
				}
			}
		}

		public int RemoveAll(TValue value)
		{
			int num = 0;
			int count = WHeApkgLGAZTtUIEfvfXHvQYCck._count;
			int num2 = count - 1;
			TKey voQbUhcEgfKVubpnlLEXkujSnBHc = default(TKey);
			while (true)
			{
				int num3 = -1494778013;
				while (true)
				{
					switch (num3 ^ -1494778015)
					{
					case 3:
						break;
					case 2:
						num3 = -1494778011;
						continue;
					case 6:
						voQbUhcEgfKVubpnlLEXkujSnBHc = WHeApkgLGAZTtUIEfvfXHvQYCck._items[num2].VoQbUhcEgfKVubpnlLEXkujSnBHc;
						if (ooabukyrafXryRkJUhQNqvEtESQ.Equals(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num2].JHgsNLxiAQVnmyfVeWejfTJocIu, value))
						{
							RemoveAt(num2);
							num3 = -1494778015;
							continue;
						}
						goto case 1;
					case 1:
						num2--;
						num3 = -1494778011;
						continue;
					case 0:
						uzoCjuXoZVchOYeMrSOjQzqivJq.Remove(voQbUhcEgfKVubpnlLEXkujSnBHc);
						num3 = -1494778012;
						continue;
					case 5:
						num++;
						num3 = -1494778016;
						continue;
					default:
						if (num2 < 0)
						{
							return num;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		public int IndexOfKey(TKey key)
		{
			if (!WGehdtGoYKIGKvRKnNsuQzYujsL && key == null)
			{
				throw new ArgumentNullException("key");
			}
			int num2 = default(int);
			while (true)
			{
				int count = WHeApkgLGAZTtUIEfvfXHvQYCck._count;
				int num = -1330165508;
				while (true)
				{
					switch (num ^ -1330165512)
					{
					case 0:
						num = -1330165509;
						continue;
					case 1:
						if (CxlUnKAGjhpBDnbYFDLUbNJKPkw.Equals(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num2].VoQbUhcEgfKVubpnlLEXkujSnBHc, key))
						{
							num = -1330165507;
							continue;
						}
						num2++;
						num = -1330165510;
						continue;
					case 5:
						return num2;
					case 3:
						break;
					case 4:
						num2 = 0;
						num = -1330165510;
						continue;
					default:
						if (num2 >= count)
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
			int count = WHeApkgLGAZTtUIEfvfXHvQYCck._count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (ooabukyrafXryRkJUhQNqvEtESQ.Equals(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num].JHgsNLxiAQVnmyfVeWejfTJocIu, value))
					{
						return num;
					}
					num++;
					int num2 = 127360749;
					while (true)
					{
						switch (num2 ^ 0x7975EEC)
						{
						case 0:
							num2 = 127360750;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return -1;
		}

		public bool ContainsKey(TKey key)
		{
			return uzoCjuXoZVchOYeMrSOjQzqivJq.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public void Clear()
		{
			WHeApkgLGAZTtUIEfvfXHvQYCck.Clear();
			uzoCjuXoZVchOYeMrSOjQzqivJq.Clear();
		}

		public void TrimExcess()
		{
			WHeApkgLGAZTtUIEfvfXHvQYCck.TrimExcess();
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
				return false;
			}
			McxTweaVquCebucWDaQJMtfANgY mcxTweaVquCebucWDaQJMtfANgY = WHeApkgLGAZTtUIEfvfXHvQYCck._items[num];
			return ooabukyrafXryRkJUhQNqvEtESQ.Equals(item.Value, mcxTweaVquCebucWDaQJMtfANgY.JHgsNLxiAQVnmyfVeWejfTJocIu);
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
				int num;
				int num2;
				if (index < 0)
				{
					num = 1345260891;
					num2 = num;
				}
				else
				{
					num = 1345260880;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x502F0D53)
					{
					case 5:
						num = 1345260885;
						continue;
					case 8:
						throw new ArgumentOutOfRangeException("index");
					case 3:
					{
						int num4;
						if (index > array.Length)
						{
							num = 1345260891;
							num4 = num;
						}
						else
						{
							num = 1345260887;
							num4 = num;
						}
						continue;
					}
					case 2:
						array[index++] = new KeyValuePair<TKey, TValue>(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num3].VoQbUhcEgfKVubpnlLEXkujSnBHc, WHeApkgLGAZTtUIEfvfXHvQYCck._items[num3].JHgsNLxiAQVnmyfVeWejfTJocIu);
						num = 1345260883;
						continue;
					case 9:
						num3 = 0;
						num = 1345260882;
						continue;
					case 4:
						if (array.Length - index < Count)
						{
							throw new Exception();
						}
						goto case 7;
					case 7:
						count = WHeApkgLGAZTtUIEfvfXHvQYCck._count;
						num = 1345260890;
						continue;
					case 6:
						break;
					case 0:
						num3++;
						num = 1345260882;
						continue;
					default:
						if (num3 >= count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			bool result = default(bool);
			if (RFPmXuvhneQjezsggqClUZiTGte)
			{
				result = false;
				goto IL_000a;
			}
			int num = IndexOfKey(item.Key);
			if (num < 0)
			{
				return false;
			}
			McxTweaVquCebucWDaQJMtfANgY mcxTweaVquCebucWDaQJMtfANgY = WHeApkgLGAZTtUIEfvfXHvQYCck._items[num];
			if (!ooabukyrafXryRkJUhQNqvEtESQ.Equals(item.Value, mcxTweaVquCebucWDaQJMtfANgY.JHgsNLxiAQVnmyfVeWejfTJocIu))
			{
				return false;
			}
			RemoveAt(num);
			int num2 = 1530836053;
			goto IL_000f;
			IL_000a:
			num2 = 1530836050;
			goto IL_000f;
			IL_000f:
			McxTweaVquCebucWDaQJMtfANgY mcxTweaVquCebucWDaQJMtfANgY2 = default(McxTweaVquCebucWDaQJMtfANgY);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x5B3EB453)
				{
				case 0:
					break;
				case 4:
					if (ooabukyrafXryRkJUhQNqvEtESQ.Equals(item.Value, mcxTweaVquCebucWDaQJMtfANgY2.JHgsNLxiAQVnmyfVeWejfTJocIu))
					{
						WHeApkgLGAZTtUIEfvfXHvQYCck.RemoveAt(num3);
						result = true;
						num2 = 1530836054;
						continue;
					}
					goto case 5;
				case 3:
					if (num3 < 0)
					{
						return result;
					}
					goto case 2;
				case 1:
					num3 = WHeApkgLGAZTtUIEfvfXHvQYCck._count - 1;
					num2 = 1530836048;
					continue;
				case 5:
					num3--;
					num2 = 1530836048;
					continue;
				case 2:
					mcxTweaVquCebucWDaQJMtfANgY2 = WHeApkgLGAZTtUIEfvfXHvQYCck._items[num3];
					num2 = 1530836055;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_000a;
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
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				int num;
				int num2;
				if (index >= 0)
				{
					num = 977829617;
					num2 = num;
				}
				else
				{
					num = 977829625;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x3A487EF1)
					{
					case 6:
						num = 977829616;
						continue;
					default:
						return;
					case 3:
						num = 977829622;
						continue;
					case 0:
					{
						int num4;
						if (index <= array.Length)
						{
							num = 977829624;
							num4 = num;
						}
						else
						{
							num = 977829625;
							num4 = num;
						}
						continue;
					}
					case 7:
					{
						int num5;
						if (num3 >= count)
						{
							num = 977829621;
							num5 = num;
						}
						else
						{
							num = 977829619;
							num5 = num;
						}
						continue;
					}
					case 5:
						count = WHeApkgLGAZTtUIEfvfXHvQYCck._count;
						num3 = 0;
						num = 977829618;
						continue;
					case 9:
						if (array.Length - index < Count)
						{
							throw new Exception();
						}
						goto case 5;
					case 8:
						throw new ArgumentOutOfRangeException("index");
					case 1:
						break;
					case 2:
						array.SetValue(new KeyValuePair<TKey, TValue>(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num3].VoQbUhcEgfKVubpnlLEXkujSnBHc, WHeApkgLGAZTtUIEfvfXHvQYCck._items[num3].JHgsNLxiAQVnmyfVeWejfTJocIu), index++);
						num3++;
						num = 977829622;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		int IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			return IndexOfValue(P_0);
		}

		bool IReadOnlyList<TValue>.Contains(TValue P_0)
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
