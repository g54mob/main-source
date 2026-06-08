using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class AList<T> : IList, IEnumerable, ICollection, IEnumerable<T>, ICollection<T>, IList<T>
	{
		[Serializable]
		public struct mdNAsTejZcnIycZdmMZQujSthhCH : IDisposable, IEnumerator, IEnumerator<T>
		{
			private AList<T> list;

			private int index;

			private int version;

			private T current;

			public T Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index != 0)
					{
						while (true)
						{
							int num = 933923815;
							while (true)
							{
								switch (num ^ 0x37AA8BE6)
								{
								case 3:
									break;
								case 1:
									goto IL_002a;
								case 0:
									goto end_IL_0008;
								default:
									return Current;
								}
								break;
								IL_002a:
								int num2;
								if (index == list._count + 1)
								{
									num = 933923814;
									num2 = num;
								}
								else
								{
									num = 933923812;
									num2 = num;
								}
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					throw new InvalidOperationException();
				}
			}

			internal mdNAsTejZcnIycZdmMZQujSthhCH(AList<T> list)
			{
				this.list = list;
				index = 0;
				version = list.yBIrBfrsPGDuPEQynAujInSmPSQ;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				AList<T> aList = list;
				if (version == aList.yBIrBfrsPGDuPEQynAujInSmPSQ && (uint)index < (uint)aList._count)
				{
					while (true)
					{
						int num = 1049623886;
						while (true)
						{
							switch (num ^ 0x3E8FFD4C)
							{
							case 0:
								break;
							case 2:
								goto IL_0041;
							default:
								return true;
							}
							break;
							IL_0041:
							current = aList._items[index];
							index++;
							num = 1049623885;
						}
					}
				}
				return yvABzeFvWOJtqQWcWLMbrirrrJww();
			}

			private bool yvABzeFvWOJtqQWcWLMbrirrrJww()
			{
				if (version != list.yBIrBfrsPGDuPEQynAujInSmPSQ)
				{
					throw new InvalidOperationException("List was changed.");
				}
				while (true)
				{
					index = list._count + 1;
					current = default(T);
					int num = -2102539813;
					while (true)
					{
						switch (num ^ -2102539815)
						{
						case 0:
							goto IL_001e;
						case 1:
							break;
						default:
							return false;
						}
						break;
						IL_001e:
						num = -2102539816;
					}
				}
			}

			void IEnumerator.Reset()
			{
				if (version != list.yBIrBfrsPGDuPEQynAujInSmPSQ)
				{
					throw new InvalidOperationException("List was changed.");
				}
				while (true)
				{
					index = 0;
					current = default(T);
					int num = -907702290;
					while (true)
					{
						switch (num ^ -907702292)
						{
						case 0:
							goto IL_001e;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_001e:
						num = -907702291;
					}
				}
			}
		}

		private const int ISzjecOhnSIeVyoduRkSSzPjzJQ = 4;

		private static readonly T[] GJhEqDDjZLohLsjdyHLlwDuisajd = new T[0];

		private IEqualityComparer<T> FlXVnkZaRfLVoztinCFFyMxcEJB = EqualityComparerNoAlloc<T>.Default;

		public T[] _items;

		private int ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		public int _count;

		private int LoLmatDEAzBAZFPqbqHPbAlkFkje;

		private bool CmqDttdTuwPREdggZfqlCVwRGtDj;

		private readonly int YzBKqmdZWWTWaumnveIoWLnuGTGA;

		private readonly bool wAJWiOBgLfzpXpzVHNjtkNFgxRc;

		private int yBIrBfrsPGDuPEQynAujInSmPSQ;

		[NonSerialized]
		private object xDtHAZlziJWMAMdwmzVBgbUwfPN;

		public int Count => _count;

		public int Capacity => ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		public int FreeSpace => YzBKqmdZWWTWaumnveIoWLnuGTGA - _count;

		public bool IsFixedSize => !wAJWiOBgLfzpXpzVHNjtkNFgxRc;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return FlXVnkZaRfLVoztinCFFyMxcEJB;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				FlXVnkZaRfLVoztinCFFyMxcEJB = value;
			}
		}

		public int Version => yBIrBfrsPGDuPEQynAujInSmPSQ;

		public T this[int index]
		{
			get
			{
				if ((uint)index >= (uint)_count)
				{
					throw new IndexOutOfRangeException();
				}
				return _items[index];
			}
			set
			{
				if ((uint)index >= (uint)_count)
				{
					throw new IndexOutOfRangeException();
				}
				_items[index] = value;
				yBIrBfrsPGDuPEQynAujInSmPSQ++;
			}
		}

		bool ICollection<T>.IsReadOnly => false;

		bool IList.IsReadOnly => false;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (!wYFerKyJYFnUBmjZSfIzASeNDbG(value))
				{
					throw new ArgumentException("value is an incompatible type.");
				}
				while (true)
				{
					this[index] = (T)value;
					int num = 572737506;
					while (true)
					{
						switch (num ^ 0x222347E0)
						{
						case 0:
							goto IL_0013;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0013:
						num = 572737505;
					}
				}
			}
		}

		int ICollection.Count => _count;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot
		{
			get
			{
				if (xDtHAZlziJWMAMdwmzVBgbUwfPN == null)
				{
					Interlocked.CompareExchange<object>(ref xDtHAZlziJWMAMdwmzVBgbUwfPN, new object(), (object)null);
				}
				return xDtHAZlziJWMAMdwmzVBgbUwfPN;
			}
		}

		public AList()
			: this(0, 0, 0)
		{
		}

		public AList(int startingCapacity)
			: this(startingCapacity, 0, 0)
		{
		}

		public AList(int startingCapacity, int maxCapacity)
			: this(startingCapacity, maxCapacity, 0)
		{
		}

		public AList(int startingCapacity, int maxCapacity, int expansionIncrement)
		{
			if (startingCapacity < 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity cannot be a negative value.");
			}
			if (expansionIncrement < 0)
			{
				expansionIncrement = 0;
			}
			if (maxCapacity < 0)
			{
				maxCapacity = 0;
			}
			if (startingCapacity > 0 && maxCapacity > 0 && maxCapacity < startingCapacity)
			{
				throw new ArgumentOutOfRangeException("maxCapacity must be >= startingCapacity or zero for unlimited.");
			}
			if (maxCapacity == 0 || maxCapacity > startingCapacity)
			{
				wAJWiOBgLfzpXpzVHNjtkNFgxRc = true;
			}
			if (!wAJWiOBgLfzpXpzVHNjtkNFgxRc && startingCapacity == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (wAJWiOBgLfzpXpzVHNjtkNFgxRc && expansionIncrement == 0)
			{
				CmqDttdTuwPREdggZfqlCVwRGtDj = true;
				expansionIncrement = 1;
			}
			LoLmatDEAzBAZFPqbqHPbAlkFkje = expansionIncrement;
			ToxWVXQQLPxjuaFqOGCzdiVpFIc = startingCapacity;
			YzBKqmdZWWTWaumnveIoWLnuGTGA = ((maxCapacity == 0) ? int.MaxValue : maxCapacity);
			_count = 0;
			if (ToxWVXQQLPxjuaFqOGCzdiVpFIc == 0)
			{
				_items = GJhEqDDjZLohLsjdyHLlwDuisajd;
			}
			else
			{
				_items = new T[startingCapacity];
			}
		}

		public AList(IEnumerable<T> collection)
			: this(collection, 0, 0)
		{
		}

		public AList(IEnumerable<T> collection, int maxCapacity, int expansionIncrement)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (expansionIncrement < 0)
			{
				expansionIncrement = 0;
			}
			if (maxCapacity < 0)
			{
				maxCapacity = 0;
			}
			T[] array = null;
			if (collection is ICollection<T> collection2)
			{
				int count = collection2.Count;
				if (count == 0)
				{
					array = GJhEqDDjZLohLsjdyHLlwDuisajd;
				}
				else
				{
					array = new T[count];
					collection2.CopyTo(array, 0);
				}
			}
			else
			{
				using (IEnumerator<T> enumerator = collection.GetEnumerator())
				{
					List<T> list = new List<T>();
					while (enumerator.MoveNext())
					{
						list.Add(enumerator.Current);
					}
					if (list.Count > 0)
					{
						array = list.ToArray();
					}
				}
			}
			int num = ((array != null) ? array.Length : 0);
			if (num > 0 && maxCapacity > 0 && maxCapacity < num)
			{
				throw new ArgumentOutOfRangeException("maxCapacity must be >= startingCapacity or zero for unlimited.");
			}
			if (maxCapacity == 0 || maxCapacity > num)
			{
				wAJWiOBgLfzpXpzVHNjtkNFgxRc = true;
			}
			if (!wAJWiOBgLfzpXpzVHNjtkNFgxRc && num == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (wAJWiOBgLfzpXpzVHNjtkNFgxRc && expansionIncrement == 0)
			{
				CmqDttdTuwPREdggZfqlCVwRGtDj = true;
				expansionIncrement = 1;
			}
			LoLmatDEAzBAZFPqbqHPbAlkFkje = expansionIncrement;
			ToxWVXQQLPxjuaFqOGCzdiVpFIc = num;
			YzBKqmdZWWTWaumnveIoWLnuGTGA = ((maxCapacity == 0) ? int.MaxValue : maxCapacity);
			_items = ((array != null) ? array : GJhEqDDjZLohLsjdyHLlwDuisajd);
			_count = num;
		}

		public T GetRandom()
		{
			T result = default(T);
			if (_count == 0)
			{
				while (true)
				{
					int num = 1083879194;
					while (true)
					{
						switch (num ^ 0x409AAF18)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							return result;
						}
						break;
						IL_0026:
						result = default(T);
						num = 1083879193;
					}
				}
			}
			return _items[UnityEngine.Random.Range(0, _count)];
		}

		public int Add(T item)
		{
			if (_count == ToxWVXQQLPxjuaFqOGCzdiVpFIc && ITkZfGzVUUHWfFDnQqkrGRQKoye(LoLmatDEAzBAZFPqbqHPbAlkFkje) == 0)
			{
				return -1;
			}
			int count = _count;
			_items[count] = item;
			_count++;
			return count;
		}

		public bool Add(T[] items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			if (items == null)
			{
				goto IL_00df;
			}
			if (items.Length == 0)
			{
				goto IL_000e;
			}
			if ((uint)startIndex >= (uint)items.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			goto IL_00fc;
			IL_00fc:
			if (count + startIndex > items.Length)
			{
				throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the array.");
			}
			goto IL_0119;
			IL_00df:
			return true;
			IL_0119:
			int num;
			int num2;
			if (count <= 0)
			{
				num = -1646524735;
				num2 = num;
			}
			else
			{
				num = -1646524733;
				num2 = num;
			}
			goto IL_0013;
			IL_000e:
			num = -1646524731;
			goto IL_0013;
			IL_0013:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1646524734)
				{
				case 2:
					break;
				case 3:
					count = items.Length - startIndex;
					num = -1646524733;
					continue;
				case 5:
					goto IL_005d;
				case 8:
					_count += count;
					num = -1646524728;
					continue;
				case 1:
					goto IL_0097;
				case 6:
					if (count > num3)
					{
						goto IL_00b8;
					}
					goto case 4;
				case 7:
					goto IL_00df;
				case 9:
					goto IL_00fc;
				case 0:
					goto IL_0119;
				case 4:
					Array.Copy(items, startIndex, _items, _count, count);
					num = -1646524726;
					continue;
				default:
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					return true;
				}
				break;
				IL_00b8:
				int num4 = ITkZfGzVUUHWfFDnQqkrGRQKoye(Math.Max(num3, LoLmatDEAzBAZFPqbqHPbAlkFkje), true);
				if (num4 == 0)
				{
					return false;
				}
				if (num4 < count)
				{
					num = -1646524729;
					continue;
				}
				goto IL_0063;
				IL_0097:
				if (count == 0)
				{
					return true;
				}
				num3 = ToxWVXQQLPxjuaFqOGCzdiVpFIc - _count;
				num = -1646524732;
				continue;
				IL_005d:
				if (!allowPartialAdd)
				{
					return false;
				}
				goto IL_0063;
				IL_0063:
				count = ITkZfGzVUUHWfFDnQqkrGRQKoye(Math.Max(num3, LoLmatDEAzBAZFPqbqHPbAlkFkje));
				num = -1646524730;
			}
			goto IL_000e;
		}

		public bool Add(AList<T> items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			if (items == null)
			{
				goto IL_0048;
			}
			if (items._count == 0)
			{
				goto IL_000b;
			}
			if ((uint)startIndex >= (uint)items._count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			goto IL_0065;
			IL_0108:
			Array.Copy(items._items, startIndex, _items, _count, count);
			int num = -1246325252;
			goto IL_0010;
			IL_0065:
			if (count + startIndex > items._count)
			{
				throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the list.");
			}
			goto IL_00e3;
			IL_00e3:
			if (count <= 0)
			{
				count = items._count - startIndex;
				num = -1246325253;
				goto IL_0010;
			}
			goto IL_00fb;
			IL_000b:
			num = -1246325255;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -1246325252)
				{
				case 3:
					break;
				case 5:
					goto IL_0048;
				case 9:
					goto IL_0065;
				case 0:
					_count += count;
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					num = -1246325256;
					continue;
				case 2:
					return true;
				case 6:
					goto IL_00e3;
				case 7:
					goto IL_00fb;
				case 1:
					goto IL_0108;
				case 8:
					goto IL_012b;
				default:
					return true;
				}
				break;
			}
			goto IL_000b;
			IL_0131:
			int num2 = default(int);
			count = ITkZfGzVUUHWfFDnQqkrGRQKoye(Math.Max(num2, LoLmatDEAzBAZFPqbqHPbAlkFkje));
			num = -1246325251;
			goto IL_0010;
			IL_00fb:
			if (count != 0)
			{
				num2 = ToxWVXQQLPxjuaFqOGCzdiVpFIc - _count;
				if (count <= num2)
				{
					goto IL_0108;
				}
				int num3 = ITkZfGzVUUHWfFDnQqkrGRQKoye(Math.Max(num2, LoLmatDEAzBAZFPqbqHPbAlkFkje), true);
				if (num3 == 0)
				{
					return false;
				}
				if (num3 >= count)
				{
					goto IL_0131;
				}
				num = -1246325260;
			}
			else
			{
				num = -1246325250;
			}
			goto IL_0010;
			IL_0048:
			return true;
			IL_012b:
			if (!allowPartialAdd)
			{
				return false;
			}
			goto IL_0131;
		}

		public int AddIfUnique(T item)
		{
			int num = IndexOf(item);
			if (num >= 0)
			{
				return num;
			}
			return Add(item);
		}

		public int AddToFirstOpenSpace(T item)
		{
			T y = default(T);
			int num2 = default(int);
			while (true)
			{
				int num = 1359380988;
				while (true)
				{
					switch (num ^ 0x510681F8)
					{
					case 5:
						break;
					case 4:
						num2 = 0;
						num = 1359380985;
						continue;
					case 2:
						if (_count < YzBKqmdZWWTWaumnveIoWLnuGTGA)
						{
							num = 1359380984;
							continue;
						}
						return -1;
					case 3:
						if (FlXVnkZaRfLVoztinCFFyMxcEJB.Equals(_items[num2], y))
						{
							_items[num2] = item;
							return num2;
						}
						num2++;
						num = 1359380985;
						continue;
					case 1:
					{
						int num3;
						if (num2 >= _count)
						{
							num = 1359380986;
							num3 = num;
						}
						else
						{
							num = 1359380987;
							num3 = num;
						}
						continue;
					}
					default:
						return Add(item);
					}
					break;
				}
			}
		}

		public int AddToFirstOpenSpace(T item, T openSpaceEquals)
		{
			int num = 0;
			while (true)
			{
				IL_005a:
				int num2;
				if (num >= _count)
				{
					if (_count >= YzBKqmdZWWTWaumnveIoWLnuGTGA)
					{
						break;
					}
					num2 = -43791450;
					goto IL_0009;
				}
				goto IL_0026;
				IL_0026:
				if (FlXVnkZaRfLVoztinCFFyMxcEJB.Equals(_items[num], openSpaceEquals))
				{
					_items[num] = item;
					return num;
				}
				num++;
				num2 = -43791449;
				goto IL_0009;
				IL_0009:
				while (true)
				{
					switch (num2 ^ -43791450)
					{
					case 3:
						num2 = -43791452;
						continue;
					case 2:
						break;
					case 1:
						goto IL_005a;
					default:
						return Add(item);
					}
					break;
				}
				goto IL_0026;
			}
			return -1;
		}

		public bool Insert(int index, T item)
		{
			if (index >= 0)
			{
				if (index > _count)
				{
					goto IL_0010;
				}
				goto IL_0065;
			}
			goto IL_0089;
			IL_0099:
			_items[index] = item;
			_count++;
			yBIrBfrsPGDuPEQynAujInSmPSQ++;
			return true;
			IL_0010:
			int num = 681354430;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x289CA4BF)
			{
			case 3:
				break;
			case 2:
				return false;
			case 0:
				goto IL_0065;
			case 1:
				goto IL_0089;
			default:
				goto IL_0099;
			}
			goto IL_0010;
			IL_0065:
			if (_count != ToxWVXQQLPxjuaFqOGCzdiVpFIc || ITkZfGzVUUHWfFDnQqkrGRQKoye(LoLmatDEAzBAZFPqbqHPbAlkFkje) != 0)
			{
				if (index >= _count)
				{
					goto IL_0099;
				}
				Array.Copy(_items, index, _items, index + 1, _count - index);
				num = 681354427;
			}
			else
			{
				num = 681354429;
			}
			goto IL_0015;
			IL_0089:
			throw new IndexOutOfRangeException();
		}

		public bool Remove(T item)
		{
			int num = IndexOf(item);
			while (true)
			{
				int num2 = 689714051;
				while (true)
				{
					switch (num2 ^ 0x291C3382)
					{
					case 2:
						break;
					case 1:
						if (num < 0)
						{
							goto IL_002a;
						}
						RemoveAt(num);
						return true;
					default:
						return false;
					}
					break;
					IL_002a:
					num2 = 689714050;
				}
			}
		}

		public void RemoveAt(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1835449076;
					while (true)
					{
						switch (num ^ -1835449078)
						{
						case 0:
							break;
						default:
							return;
						case 5:
							Array.Copy(_items, index + 1, _items, index, _count - index);
							num = -1835449080;
							continue;
						case 4:
							goto IL_0059;
						case 1:
							goto end_IL_0004;
						case 6:
							goto IL_0091;
						case 2:
							_items[_count] = default(T);
							yBIrBfrsPGDuPEQynAujInSmPSQ++;
							num = -1835449079;
							continue;
						case 3:
							return;
						}
						break;
						IL_0091:
						int num2;
						if (index < _count)
						{
							num = -1835449074;
							num2 = num;
						}
						else
						{
							num = -1835449077;
							num2 = num;
						}
						continue;
						IL_0059:
						_count--;
						int num3;
						if (index < _count)
						{
							num = -1835449073;
							num3 = num;
						}
						else
						{
							num = -1835449080;
							num3 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}

		public bool Contains(T item)
		{
			return Contains(item, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			while (true)
			{
				int num = 0;
				int num2 = -2053464189;
				while (true)
				{
					switch (num2 ^ -2053464189)
					{
					case 2:
						num2 = -2053464187;
						continue;
					case 6:
						break;
					case 5:
						return true;
					case 1:
					{
						int num3;
						if (num >= _count)
						{
							num2 = -2053464192;
							num3 = num2;
						}
						else
						{
							num2 = -2053464185;
							num3 = num2;
						}
						continue;
					}
					case 0:
						num2 = -2053464190;
						continue;
					case 4:
						if (!comparer.Equals(_items[num], item))
						{
							num++;
							num2 = -2053464190;
						}
						else
						{
							num2 = -2053464186;
						}
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public int IndexOf(T item, int index)
		{
			return IndexOf(item, index, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public int IndexOf(T item, int index, int count)
		{
			return IndexOf(item, index, count, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			while (true)
			{
				int num = 0;
				int num2 = 486779914;
				while (true)
				{
					switch (num2 ^ 0x1D03AC0B)
					{
					case 0:
						num2 = 486779912;
						continue;
					case 3:
						break;
					case 2:
						if (comparer.Equals(_items[num], item))
						{
							return num;
						}
						num++;
						num2 = 486779914;
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

		public int IndexOf(T item, int index, IEqualityComparer<T> comparer)
		{
			if (index >= 0)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 310703263;
					while (true)
					{
						switch (num ^ 0x1284F49E)
						{
						case 0:
							break;
						case 3:
							num2 = index;
							num = 310703258;
							continue;
						case 2:
							goto end_IL_0004;
						case 5:
							goto IL_0049;
						case 1:
							goto IL_006b;
						default:
							if (num2 >= _count)
							{
								return -1;
							}
							goto IL_0049;
						}
						break;
						IL_006b:
						int num3;
						if (index < _count)
						{
							num = 310703261;
							num3 = num;
						}
						else
						{
							num = 310703260;
							num3 = num;
						}
						continue;
						IL_0049:
						if (comparer.Equals(_items[num2], item))
						{
							return num2;
						}
						num2++;
						num = 310703258;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int IndexOf(T item, int index, int count, IEqualityComparer<T> comparer)
		{
			if (index >= 0)
			{
				if (index >= _count)
				{
					goto IL_0013;
				}
				goto IL_0094;
			}
			goto IL_00ad;
			IL_0045:
			if (index + count > _count)
			{
				throw new ArgumentOutOfRangeException();
			}
			goto IL_005d;
			IL_0013:
			int num = 403794835;
			goto IL_0018;
			IL_0018:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x18116B92)
				{
				case 5:
					break;
				case 2:
					goto IL_0045;
				case 3:
					goto IL_005d;
				case 6:
					return num2;
				case 0:
					goto IL_0077;
				case 7:
					goto IL_0094;
				case 1:
					goto IL_00ad;
				default:
					if (num2 >= num3)
					{
						return -1;
					}
					goto IL_0077;
				}
				break;
				IL_0077:
				if (!comparer.Equals(_items[num2], item))
				{
					num2++;
					num = 403794838;
				}
				else
				{
					num = 403794836;
				}
			}
			goto IL_0013;
			IL_00ad:
			throw new ArgumentOutOfRangeException("index");
			IL_005d:
			num3 = index + count;
			num2 = index;
			num = 403794838;
			goto IL_0018;
			IL_0094:
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			goto IL_0045;
		}

		public void Reverse()
		{
			Reverse(0, Count);
		}

		public void Reverse(int index, int count)
		{
			if (index < 0)
			{
				goto IL_0004;
			}
			goto IL_0050;
			IL_0004:
			int num = 950427454;
			goto IL_0009;
			IL_0009:
			switch (num ^ 0x38A65F3F)
			{
			case 5:
				break;
			default:
				return;
			case 0:
				goto IL_002e;
			case 4:
				goto IL_0050;
			case 1:
				throw new ArgumentOutOfRangeException("index");
			case 2:
				goto IL_0078;
			case 3:
				return;
			}
			goto IL_0004;
			IL_002e:
			Array.Reverse((Array)_items, index, count);
			yBIrBfrsPGDuPEQynAujInSmPSQ++;
			num = 950427452;
			goto IL_0009;
			IL_0050:
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			goto IL_0078;
			IL_0078:
			if (_count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			goto IL_002e;
		}

		public void Sort()
		{
			Sort(0, Count, null);
		}

		public void Sort(IComparer<T> comparer)
		{
			Sort(0, Count, comparer);
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
			if (index < 0)
			{
				goto IL_0004;
			}
			goto IL_0060;
			IL_0004:
			int num = 185838202;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0xB13AA7F)
				{
				case 0:
					break;
				case 1:
					goto IL_0032;
				case 2:
					throw new ArgumentOutOfRangeException("count");
				case 4:
					goto IL_0060;
				case 3:
					throw new ArgumentOutOfRangeException();
				case 5:
					throw new ArgumentOutOfRangeException("index");
				default:
					Array.Sort(_items, index, count, comparer);
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					return;
				}
				break;
				IL_0032:
				int num2;
				if (_count - index >= count)
				{
					num = 185838201;
					num2 = num;
				}
				else
				{
					num = 185838204;
					num2 = num;
				}
			}
			goto IL_0004;
			IL_0060:
			int num3;
			if (count < 0)
			{
				num = 185838205;
				num3 = num;
			}
			else
			{
				num = 185838206;
				num3 = num;
			}
			goto IL_0009;
		}

		public List<T> GetRange(int index, int count)
		{
			if (index < 0)
			{
				goto IL_003b;
			}
			if (index >= _count)
			{
				goto IL_000d;
			}
			goto IL_0084;
			IL_0084:
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			goto IL_0068;
			IL_000d:
			int num = -39301167;
			goto IL_0012;
			IL_0012:
			T[] array = default(T[]);
			while (true)
			{
				switch (num ^ -39301165)
				{
				case 0:
					break;
				case 2:
					goto IL_003b;
				case 3:
					array = new T[count];
					num = -39301163;
					continue;
				case 4:
					throw new ArgumentOutOfRangeException();
				case 1:
					goto IL_0068;
				case 5:
					goto IL_0084;
				default:
					Array.Copy(_items, index, array, 0, count);
					return new List<T>(array);
				}
				break;
			}
			goto IL_000d;
			IL_003b:
			throw new ArgumentOutOfRangeException("index");
			IL_0068:
			int num2;
			if (_count - index < count)
			{
				num = -39301161;
				num2 = num;
			}
			else
			{
				num = -39301168;
				num2 = num;
			}
			goto IL_0012;
		}

		public ReadOnlyCollection<T> AsReadOnly()
		{
			return new ReadOnlyCollection<T>(this);
		}

		public bool Exists(Predicate<T> match)
		{
			return FindIndex(match) != -1;
		}

		public T Find(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			while (true)
			{
				int num = 0;
				int num2 = -144252252;
				while (true)
				{
					switch (num2 ^ -144252250)
					{
					case 0:
						num2 = -144252251;
						continue;
					case 3:
						break;
					case 1:
						if (match(_items[num]))
						{
							return _items[num];
						}
						num++;
						num2 = -144252252;
						continue;
					default:
						if (num >= _count)
						{
							return default(T);
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public List<T> FindAll(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			int num2 = default(int);
			while (true)
			{
				List<T> list = new List<T>();
				int num = -1613026934;
				while (true)
				{
					switch (num ^ -1613026932)
					{
					case 3:
						num = -1613026935;
						continue;
					case 2:
						num2++;
						num = -1613026931;
						continue;
					case 6:
						num2 = 0;
						num = -1613026932;
						continue;
					case 0:
						num = -1613026931;
						continue;
					case 4:
						if (match(_items[num2]))
						{
							list.Add(_items[num2]);
							num = -1613026930;
							continue;
						}
						goto case 2;
					case 5:
						break;
					default:
						if (num2 >= _count)
						{
							return list;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public int FindIndex(Predicate<T> match)
		{
			return FindIndex(0, _count, match);
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return FindIndex(startIndex, _count - startIndex, match);
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			if ((uint)startIndex > (uint)_count)
			{
				throw new ArgumentNullException("startIndex");
			}
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (count >= 0)
				{
					num = -1799440303;
					num2 = num;
				}
				else
				{
					num = -1799440298;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1799440299)
					{
					case 2:
						num = -1799440304;
						continue;
					case 6:
					{
						int num7;
						if (match != null)
						{
							num = -1799440302;
							num7 = num;
						}
						else
						{
							num = -1799440300;
							num7 = num;
						}
						continue;
					}
					case 10:
						num = -1799440292;
						continue;
					case 4:
					{
						int num6;
						if (startIndex > _count - count)
						{
							num = -1799440298;
							num6 = num;
						}
						else
						{
							num = -1799440301;
							num6 = num;
						}
						continue;
					}
					case 7:
						num4 = startIndex + count;
						num3 = startIndex;
						num = -1799440289;
						continue;
					case 0:
						if (match(_items[num3]))
						{
							return num3;
						}
						num3++;
						num = -1799440292;
						continue;
					case 1:
						throw new ArgumentNullException("match");
					case 3:
						throw new ArgumentOutOfRangeException();
					case 9:
					{
						int num5;
						if (num3 >= num4)
						{
							num = -1799440291;
							num5 = num;
						}
						else
						{
							num = -1799440299;
							num5 = num;
						}
						continue;
					}
					case 5:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public T FindLast(Predicate<T> match)
		{
			if (match == null)
			{
				goto IL_0003;
			}
			goto IL_0055;
			IL_0003:
			int num = 1922519245;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x729750CC)
				{
				case 3:
					break;
				case 0:
					goto IL_0029;
				case 2:
					goto IL_0055;
				case 1:
					throw new ArgumentNullException("match");
				default:
					if (num2 < 0)
					{
						return default(T);
					}
					goto IL_0029;
				}
				break;
				IL_0029:
				if (match(_items[num2]))
				{
					return _items[num2];
				}
				num2--;
				num = 1922519240;
			}
			goto IL_0003;
			IL_0055:
			num2 = _count - 1;
			num = 1922519240;
			goto IL_0008;
		}

		public int FindLastIndex(Predicate<T> match)
		{
			return FindLastIndex(_count - 1, _count, match);
		}

		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return FindLastIndex(startIndex, startIndex + 1, match);
		}

		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (_count == 0)
				{
					num = 377512165;
					num2 = num;
				}
				else
				{
					num = 377512163;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x168060E1)
					{
					case 8:
						num = 377512160;
						continue;
					case 1:
						break;
					case 6:
						if (match(_items[num3]))
						{
							return num3;
						}
						num3--;
						num = 377512171;
						continue;
					case 9:
						throw new ArgumentOutOfRangeException();
					case 0:
						throw new ArgumentOutOfRangeException("startIndex");
					case 3:
						num4 = startIndex - count;
						num = 377512164;
						continue;
					case 5:
						num3 = startIndex;
						num = 377512171;
						continue;
					case 7:
						if (count >= 0)
						{
							int num6;
							if (startIndex - count + 1 >= 0)
							{
								num = 377512162;
								num6 = num;
							}
							else
							{
								num = 377512168;
								num6 = num;
							}
							continue;
						}
						goto case 9;
					case 2:
						if ((uint)startIndex >= (uint)_count)
						{
							throw new ArgumentOutOfRangeException("startIndex");
						}
						goto case 7;
					case 4:
					{
						int num5;
						if (startIndex == -1)
						{
							num = 377512166;
							num5 = num;
						}
						else
						{
							num = 377512161;
							num5 = num;
						}
						continue;
					}
					default:
						if (num3 <= num4)
						{
							return -1;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		public void ForEach(Action<T> action)
		{
			if (_count == 0)
			{
				return;
			}
			while (action != null)
			{
				while (true)
				{
					IL_00ab:
					int num = yBIrBfrsPGDuPEQynAujInSmPSQ;
					int num2 = 0;
					int num3 = 114816248;
					while (true)
					{
						switch (num3 ^ 0x6D7F4F9)
						{
						case 0:
							num3 = 114816253;
							continue;
						default:
							return;
						case 4:
							break;
						case 3:
							if (num == yBIrBfrsPGDuPEQynAujInSmPSQ)
							{
								action(_items[num2]);
								num2++;
								num3 = 114816248;
								continue;
							}
							goto IL_0079;
						case 2:
							goto IL_0079;
						case 7:
							throw new Exception("List was changed.");
						case 5:
							goto IL_00ab;
						case 1:
							goto IL_00be;
						case 6:
							return;
						}
						break;
						IL_00be:
						int num4;
						if (num2 >= _count)
						{
							num3 = 114816251;
							num4 = num3;
						}
						else
						{
							num3 = 114816250;
							num4 = num3;
						}
						continue;
						IL_0079:
						int num5;
						if (num == yBIrBfrsPGDuPEQynAujInSmPSQ)
						{
							num3 = 114816255;
							num5 = num3;
						}
						else
						{
							num3 = 114816254;
							num5 = num3;
						}
					}
					break;
				}
			}
			throw new ArgumentNullException("action");
		}

		public int LastIndexOf(T item)
		{
			if (_count == 0)
			{
				return -1;
			}
			return LastIndexOf(item, _count - 1, _count);
		}

		public int LastIndexOf(T item, int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1560452926;
					while (true)
					{
						switch (num ^ -1560452928)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						case 3:
							goto end_IL_0004;
						default:
							return LastIndexOf(item, index, index + 1);
						}
						break;
						IL_0026:
						int num2;
						if (index >= _count)
						{
							num = -1560452925;
							num2 = num;
						}
						else
						{
							num = -1560452927;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int LastIndexOf(T item, int index, int count)
		{
			if (_count != 0 && index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			while (true)
			{
				int num;
				if (_count != 0)
				{
					int num2;
					if (count >= 0)
					{
						num = 543809115;
						num2 = num;
					}
					else
					{
						num = 543809114;
						num2 = num;
					}
					goto IL_001c;
				}
				goto IL_00a7;
				IL_00a7:
				if (_count != 0)
				{
					if (index >= _count)
					{
						throw new ArgumentOutOfRangeException("index");
					}
					goto IL_0062;
				}
				num = 543809112;
				goto IL_001c;
				IL_0062:
				if (count <= index + 1)
				{
					break;
				}
				throw new ArgumentOutOfRangeException();
				IL_001c:
				while (true)
				{
					switch (num ^ 0x2069DE5B)
					{
					case 4:
						num = 543809118;
						continue;
					case 5:
						break;
					case 2:
						goto IL_0062;
					case 3:
						return -1;
					case 1:
						throw new ArgumentOutOfRangeException("count");
					case 0:
						goto IL_00a7;
					default:
						goto end_IL_0045;
					}
					break;
				}
				continue;
				end_IL_0045:
				break;
			}
			return Array.LastIndexOf(_items, item, index, count);
		}

		public int RemoveAll(Predicate<T> match)
		{
			if (_count == 0)
			{
				return 0;
			}
			if (match == null)
			{
				goto IL_0010;
			}
			goto IL_00c3;
			IL_00c3:
			int num = 0;
			int num2 = 1583681824;
			goto IL_0015;
			IL_0010:
			num2 = 1583681838;
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			int result = default(int);
			while (true)
			{
				switch (num2 ^ 0x5E651128)
				{
				case 12:
					break;
				case 6:
					throw new ArgumentNullException("match");
				case 4:
					goto IL_006f;
				case 5:
					num2 = 1583681836;
					continue;
				case 3:
					if (num3 < _count)
					{
						_items[num++] = _items[num3++];
						num2 = 1583681836;
						continue;
					}
					goto IL_006f;
				case 7:
					goto IL_00c3;
				case 11:
					num++;
					num2 = 1583681824;
					continue;
				case 9:
					Array.Clear(_items, num, _count - num);
					result = _count - num;
					num2 = 1583681832;
					continue;
				case 1:
					num3++;
					num2 = 1583681826;
					continue;
				case 10:
					if (num3 >= _count)
					{
						goto case 3;
					}
					goto IL_011e;
				case 0:
					_count = num;
					num2 = 1583681829;
					continue;
				case 8:
					goto IL_0157;
				case 2:
					goto IL_0188;
				default:
					yBIrBfrsPGDuPEQynAujInSmPSQ++;
					return result;
				}
				break;
				IL_0157:
				if (num < _count)
				{
					int num4;
					if (match(_items[num]))
					{
						num2 = 1583681834;
						num4 = num2;
					}
					else
					{
						num2 = 1583681827;
						num4 = num2;
					}
					continue;
				}
				goto IL_0188;
				IL_006f:
				int num5;
				if (num3 < _count)
				{
					num2 = 1583681826;
					num5 = num2;
				}
				else
				{
					num2 = 1583681825;
					num5 = num2;
				}
				continue;
				IL_011e:
				int num6;
				if (!match(_items[num3]))
				{
					num2 = 1583681835;
					num6 = num2;
				}
				else
				{
					num2 = 1583681833;
					num6 = num2;
				}
				continue;
				IL_0188:
				if (num >= _count)
				{
					return 0;
				}
				num3 = num + 1;
				num2 = 1583681837;
			}
			goto IL_0010;
		}

		public bool TrueForAll(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			while (true)
			{
				int num = 0;
				int num2 = -830908536;
				while (true)
				{
					switch (num2 ^ -830908532)
					{
					case 3:
						num2 = -830908531;
						continue;
					case 2:
						return false;
					case 0:
						if (match(_items[num]))
						{
							num++;
							num2 = -830908536;
						}
						else
						{
							num2 = -830908530;
						}
						continue;
					case 1:
						break;
					default:
						if (num >= _count)
						{
							return true;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public T[] ToArray()
		{
			T[] array = new T[_count];
			Array.Copy(_items, 0, array, 0, _count);
			return array;
		}

		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			if (_count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			while (true)
			{
				Array.Copy(_items, index, array, arrayIndex, count);
				int num = 485191571;
				while (true)
				{
					switch (num ^ 0x1CEB6F91)
					{
					case 0:
						goto IL_0012;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0012:
					num = 485191568;
				}
			}
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(_items, 0, array, arrayIndex, _count);
		}

		public void Clear()
		{
			Array.Clear(_items, 0, _count);
			_count = 0;
			yBIrBfrsPGDuPEQynAujInSmPSQ++;
		}

		public void TrimExcess()
		{
			if (wAJWiOBgLfzpXpzVHNjtkNFgxRc && _count != ToxWVXQQLPxjuaFqOGCzdiVpFIc)
			{
				ApmnsHLLLtsLslDynvvWTzQJcBz(_count);
				yBIrBfrsPGDuPEQynAujInSmPSQ++;
			}
		}

		private int ITkZfGzVUUHWfFDnQqkrGRQKoye(int P_0, bool P_1 = false)
		{
			if (!wAJWiOBgLfzpXpzVHNjtkNFgxRc)
			{
				return 0;
			}
			if (ToxWVXQQLPxjuaFqOGCzdiVpFIc >= YzBKqmdZWWTWaumnveIoWLnuGTGA)
			{
				return 0;
			}
			if (CmqDttdTuwPREdggZfqlCVwRGtDj)
			{
				goto IL_0022;
			}
			goto IL_005a;
			IL_005a:
			P_0 = Math.Min(P_0, YzBKqmdZWWTWaumnveIoWLnuGTGA - ToxWVXQQLPxjuaFqOGCzdiVpFIc);
			if (P_0 <= 0)
			{
				return 0;
			}
			int num;
			if (!ApmnsHLLLtsLslDynvvWTzQJcBz(ToxWVXQQLPxjuaFqOGCzdiVpFIc + P_0))
			{
				num = -1888433882;
				goto IL_0027;
			}
			return P_0;
			IL_0027:
			while (true)
			{
				switch (num ^ -1888433884)
				{
				case 0:
					break;
				case 1:
					P_0 = SUhFYQbjYszifwDkhokMXQDMvNeH(ToxWVXQQLPxjuaFqOGCzdiVpFIc, P_0);
					num = -1888433881;
					continue;
				case 3:
					goto IL_005a;
				default:
					return 0;
				}
				break;
			}
			goto IL_0022;
			IL_0022:
			num = -1888433883;
			goto IL_0027;
		}

		private int SUhFYQbjYszifwDkhokMXQDMvNeH(int P_0, int P_1)
		{
			int num = P_0 + P_1;
			if (num < 4)
			{
				num = 4;
				goto IL_000a;
			}
			goto IL_0028;
			IL_0044:
			uint num2 = default(uint);
			return (int)num2 - P_0;
			IL_000a:
			int num3 = -905930918;
			goto IL_000f;
			IL_000f:
			switch (num3 ^ -905930920)
			{
			case 0:
				break;
			case 2:
				goto IL_0028;
			default:
				goto IL_0044;
			}
			goto IL_000a;
			IL_0028:
			num2 = MathTools.RoundUpToPowerOf2((uint)num);
			if (num2 > int.MaxValue)
			{
				num2 = 2147483647u;
				num3 = -905930919;
				goto IL_000f;
			}
			goto IL_0044;
		}

		private bool ApmnsHLLLtsLslDynvvWTzQJcBz(int P_0, bool P_1 = false)
		{
			if (P_0 < 0)
			{
				goto IL_0004;
			}
			goto IL_0064;
			IL_0004:
			int num = -439075216;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ -439075215)
				{
				case 2:
					break;
				case 1:
					P_0 = 0;
					num = -439075212;
					continue;
				case 0:
					goto IL_0038;
				case 3:
					goto IL_0046;
				case 5:
					goto IL_0064;
				default:
					return true;
				}
				break;
			}
			goto IL_0004;
			IL_0038:
			T[] array = default(T[]);
			_items = array;
			num = -439075211;
			goto IL_0009;
			IL_0064:
			if (P_0 > YzBKqmdZWWTWaumnveIoWLnuGTGA)
			{
				return false;
			}
			if (P_0 == ToxWVXQQLPxjuaFqOGCzdiVpFIc)
			{
				return true;
			}
			if (P_1)
			{
				return true;
			}
			array = new T[P_0];
			if (P_0 != 0)
			{
				Array.Copy(_items, array, Math.Min(P_0, ToxWVXQQLPxjuaFqOGCzdiVpFIc));
				num = -439075214;
				goto IL_0009;
			}
			goto IL_0046;
			IL_0046:
			ToxWVXQQLPxjuaFqOGCzdiVpFIc = P_0;
			if (_count > P_0)
			{
				_count = P_0;
				num = -439075215;
				goto IL_0009;
			}
			goto IL_0038;
		}

		void IList<T>.Insert(int index, T item)
		{
			Insert(index, item);
		}

		void ICollection<T>.Add(T item)
		{
			if (Add(item) < 0)
			{
				throw new Exception("List has no more space. Cannot add item.");
			}
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			if (array != null && array.Rank != 1)
			{
				goto IL_000c;
			}
			goto IL_0040;
			IL_0040:
			Array.Copy(_items, 0, array, arrayIndex, _count);
			int num = 283097223;
			goto IL_0011;
			IL_000c:
			num = 283097221;
			goto IL_0011;
			IL_0011:
			switch (num ^ 0x10DFB884)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				throw new ArgumentException("Multi-dimensional arrays are not supported.");
			case 0:
				goto IL_0040;
			case 3:
				return;
			}
			goto IL_000c;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array != null && array.Rank != 1)
			{
				throw new ArgumentException("Multi-dimensional arrays are not supported.");
			}
			try
			{
				Array.Copy(_items, 0, array, index, _count);
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException("Invalid array type.");
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new mdNAsTejZcnIycZdmMZQujSthhCH(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new mdNAsTejZcnIycZdmMZQujSthhCH(this);
		}

		int IList.Add(object value)
		{
			if (!wYFerKyJYFnUBmjZSfIzASeNDbG(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return Add((T)value);
		}

		bool IList.Contains(object value)
		{
			if (!wYFerKyJYFnUBmjZSfIzASeNDbG(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return Contains((T)value);
		}

		int IList.IndexOf(object value)
		{
			if (!wYFerKyJYFnUBmjZSfIzASeNDbG(value))
			{
				while (true)
				{
					switch (-1950221606 ^ -1950221605)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentException("value is an incompatible type.");
					}
					break;
				}
			}
			return IndexOf((T)value);
		}

		void IList.Insert(int index, object value)
		{
			if (!wYFerKyJYFnUBmjZSfIzASeNDbG(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			Insert(index, (T)value);
		}

		void IList.Remove(object value)
		{
			if (!wYFerKyJYFnUBmjZSfIzASeNDbG(value))
			{
				while (true)
				{
					switch (0x1D9E5AE3 ^ 0x1D9E5AE1)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentException("value is an incompatible type.");
					}
					break;
				}
			}
			Remove((T)value);
		}

		public static AList<T> CreateFixedLengthList(int capacity)
		{
			return new AList<T>(capacity, capacity, 0);
		}

		private static bool wYFerKyJYFnUBmjZSfIzASeNDbG(object P_0)
		{
			if (!(P_0 is T))
			{
				T val = default(T);
				if (P_0 == null)
				{
					while (true)
					{
						int num = 492365460;
						while (true)
						{
							switch (num ^ 0x1D58E695)
							{
							case 2:
								break;
							case 1:
								goto IL_0029;
							default:
								return val == null;
							}
							break;
							IL_0029:
							val = default(T);
							num = 492365461;
						}
					}
				}
				return false;
			}
			return true;
		}
	}
}
