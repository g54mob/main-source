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
		public struct XwZBaYTidkJBpkWVpuaBdmWkyln : IDisposable, IEnumerator, IEnumerator<T>
		{
			private AList<T> list;

			private int index;

			private int version;

			private T current;

			public T Current
			{
				get
				{
					return current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if (index != 0)
					{
						if (index != list._count + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-119681819 ^ -119681820)
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
					throw new InvalidOperationException();
					IL_0048:
					return Current;
				}
			}

			internal XwZBaYTidkJBpkWVpuaBdmWkyln(AList<T> list)
			{
				this.list = list;
				index = 0;
				version = list.HCKdygRhwCetItzVwbRsEqktGNve;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				AList<T> aList = list;
				if (version == aList.HCKdygRhwCetItzVwbRsEqktGNve && (uint)index < (uint)aList._count)
				{
					current = aList._items[index];
					while (true)
					{
						int num = -323396456;
						while (true)
						{
							switch (num ^ -323396455)
							{
							case 2:
								break;
							case 1:
								goto IL_0058;
							default:
								return true;
							}
							break;
							IL_0058:
							index++;
							num = -323396455;
						}
					}
				}
				return XtGSwlBbjQesbfDUZjPcgHsaCGX();
			}

			private bool XtGSwlBbjQesbfDUZjPcgHsaCGX()
			{
				if (version != list.HCKdygRhwCetItzVwbRsEqktGNve)
				{
					while (true)
					{
						switch (0xDFA6EE7 ^ 0xDFA6EE5)
						{
						case 0:
							continue;
						case 2:
							throw new InvalidOperationException("List was changed.");
						}
						break;
					}
				}
				index = list._count + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != list.HCKdygRhwCetItzVwbRsEqktGNve)
				{
					throw new InvalidOperationException("List was changed.");
				}
				while (true)
				{
					index = 0;
					current = default(T);
					int num = -729073875;
					while (true)
					{
						switch (num ^ -729073876)
						{
						case 0:
							goto IL_001e;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_001e:
						num = -729073874;
					}
				}
			}
		}

		private const int lUfEYxieWMLFOaRYfycFLMnakwxd = 4;

		private static readonly T[] phhXnMXdcVoWSQnIvuteLWInrpI = new T[0];

		private IEqualityComparer<T> ubrUaedVBLiQYMPUtnVWqcasDXu = EqualityComparerNoAlloc<T>.Default;

		public T[] _items;

		private int qvddhAEohNgcpXDiHojyOjpuJQDJ;

		public int _count;

		private int apJJqyhYppNdWcLPmwUWCSHCzQQ;

		private bool niyKXeZbRmSJZYKJKVmsGWIGuso;

		private readonly int laVHllDIrWhFhNcWsTnrGRRlPSt;

		private readonly bool RVtDHVbopyuIGGoAyKkAktvkKBL;

		private int HCKdygRhwCetItzVwbRsEqktGNve;

		[NonSerialized]
		private object QKvyaEXPQDXBJnyOvUMQktZhEwo;

		public int Count
		{
			get
			{
				return _count;
			}
		}

		public int Capacity
		{
			get
			{
				return qvddhAEohNgcpXDiHojyOjpuJQDJ;
			}
		}

		public int FreeSpace
		{
			get
			{
				return laVHllDIrWhFhNcWsTnrGRRlPSt - _count;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return !RVtDHVbopyuIGGoAyKkAktvkKBL;
			}
		}

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return ubrUaedVBLiQYMPUtnVWqcasDXu;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				ubrUaedVBLiQYMPUtnVWqcasDXu = value;
			}
		}

		public int Version
		{
			get
			{
				return HCKdygRhwCetItzVwbRsEqktGNve;
			}
		}

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
				while (true)
				{
					_items[index] = value;
					int num = -219968113;
					while (true)
					{
						switch (num ^ -219968113)
						{
						case 3:
							num = -219968114;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							HCKdygRhwCetItzVwbRsEqktGNve++;
							num = -219968115;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		bool ICollection<T>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		bool IList.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (!DbDCLLFEuRPoYFBILoUoAKgGCIlw(value))
				{
					throw new ArgumentException("value is an incompatible type.");
				}
				while (true)
				{
					this[index] = (T)value;
					int num = 395677999;
					while (true)
					{
						switch (num ^ 0x1795912E)
						{
						case 0:
							goto IL_0013;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0013:
						num = 395677996;
					}
				}
			}
		}

		int ICollection.Count
		{
			get
			{
				return _count;
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
				if (QKvyaEXPQDXBJnyOvUMQktZhEwo == null)
				{
					Interlocked.CompareExchange<object>(ref QKvyaEXPQDXBJnyOvUMQktZhEwo, new object(), (object)null);
				}
				return QKvyaEXPQDXBJnyOvUMQktZhEwo;
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
				RVtDHVbopyuIGGoAyKkAktvkKBL = true;
			}
			if (!RVtDHVbopyuIGGoAyKkAktvkKBL && startingCapacity == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (RVtDHVbopyuIGGoAyKkAktvkKBL && expansionIncrement == 0)
			{
				niyKXeZbRmSJZYKJKVmsGWIGuso = true;
				expansionIncrement = 1;
			}
			apJJqyhYppNdWcLPmwUWCSHCzQQ = expansionIncrement;
			qvddhAEohNgcpXDiHojyOjpuJQDJ = startingCapacity;
			laVHllDIrWhFhNcWsTnrGRRlPSt = ((maxCapacity == 0) ? int.MaxValue : maxCapacity);
			_count = 0;
			if (qvddhAEohNgcpXDiHojyOjpuJQDJ == 0)
			{
				_items = phhXnMXdcVoWSQnIvuteLWInrpI;
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
			ICollection<T> collection2 = collection as ICollection<T>;
			if (collection2 != null)
			{
				int count = collection2.Count;
				if (count == 0)
				{
					array = phhXnMXdcVoWSQnIvuteLWInrpI;
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
				RVtDHVbopyuIGGoAyKkAktvkKBL = true;
			}
			if (!RVtDHVbopyuIGGoAyKkAktvkKBL && num == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (RVtDHVbopyuIGGoAyKkAktvkKBL && expansionIncrement == 0)
			{
				niyKXeZbRmSJZYKJKVmsGWIGuso = true;
				expansionIncrement = 1;
			}
			apJJqyhYppNdWcLPmwUWCSHCzQQ = expansionIncrement;
			qvddhAEohNgcpXDiHojyOjpuJQDJ = num;
			laVHllDIrWhFhNcWsTnrGRRlPSt = ((maxCapacity == 0) ? int.MaxValue : maxCapacity);
			_items = ((array != null) ? array : phhXnMXdcVoWSQnIvuteLWInrpI);
			_count = num;
		}

		public T GetRandom()
		{
			if (_count == 0)
			{
				return default(T);
			}
			return _items[UnityEngine.Random.Range(0, _count)];
		}

		public int Add(T item)
		{
			if (_count == qvddhAEohNgcpXDiHojyOjpuJQDJ && hMkCoDBlpOZUgiEpRZueWuTFxnD(apJJqyhYppNdWcLPmwUWCSHCzQQ) == 0)
			{
				goto IL_001d;
			}
			int count = _count;
			_items[count] = item;
			int num = -1641697106;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ -1641697106)
				{
				case 3:
					break;
				case 1:
					return -1;
				case 0:
					goto IL_005c;
				default:
					return count;
				}
				break;
				IL_005c:
				_count++;
				num = -1641697108;
			}
			goto IL_001d;
			IL_001d:
			num = -1641697105;
			goto IL_0022;
		}

		public bool Add(T[] items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			if (items != null)
			{
				while (true)
				{
					int num = -771726506;
					while (true)
					{
						switch (num ^ -771726512)
						{
						case 0:
							break;
						case 2:
							goto IL_0043;
						case 1:
							return true;
						case 6:
							goto IL_00b4;
						case 8:
							_count += count;
							num = -771726507;
							continue;
						case 7:
							goto IL_00db;
						case 4:
							goto IL_00e8;
						case 9:
							goto IL_00fd;
						case 3:
							goto end_IL_0006;
						default:
							HCKdygRhwCetItzVwbRsEqktGNve++;
							return true;
						}
						break;
						IL_00b4:
						if (items.Length == 0)
						{
							num = -771726509;
							continue;
						}
						if ((uint)startIndex >= (uint)items.Length)
						{
							throw new ArgumentOutOfRangeException("startIndex");
						}
						goto IL_00fd;
						IL_00db:
						if (count != 0)
						{
							int num2 = qvddhAEohNgcpXDiHojyOjpuJQDJ - _count;
							if (count > num2)
							{
								int num3 = hMkCoDBlpOZUgiEpRZueWuTFxnD(Math.Max(num2, apJJqyhYppNdWcLPmwUWCSHCzQQ), true);
								if (num3 == 0)
								{
									return false;
								}
								if (num3 < count && !allowPartialAdd)
								{
									return false;
								}
								count = hMkCoDBlpOZUgiEpRZueWuTFxnD(Math.Max(num2, apJJqyhYppNdWcLPmwUWCSHCzQQ));
								num = -771726510;
								continue;
							}
							goto IL_0043;
						}
						num = -771726511;
						continue;
						IL_00e8:
						if (count <= 0)
						{
							count = items.Length - startIndex;
							num = -771726505;
							continue;
						}
						goto IL_00db;
						IL_0043:
						Array.Copy(items, startIndex, _items, _count, count);
						num = -771726504;
						continue;
						IL_00fd:
						if (count + startIndex > items.Length)
						{
							throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the array.");
						}
						goto IL_00e8;
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			return true;
		}

		public bool Add(AList<T> items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			if (items != null)
			{
				if (items._count == 0)
				{
					goto IL_0011;
				}
				if ((uint)startIndex >= (uint)items._count)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				goto IL_0115;
			}
			goto IL_0135;
			IL_0115:
			if (count + startIndex > items._count)
			{
				throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the list.");
			}
			goto IL_00be;
			IL_00be:
			int num;
			if (count <= 0)
			{
				count = items._count - startIndex;
				num = 1763822045;
				goto IL_0016;
			}
			goto IL_004a;
			IL_0135:
			return true;
			IL_0011:
			num = 1763822042;
			goto IL_0016;
			IL_0016:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x6921C9DC)
				{
				case 0:
					break;
				case 1:
					goto IL_004a;
				case 8:
					goto IL_0072;
				case 4:
					num2 = hMkCoDBlpOZUgiEpRZueWuTFxnD(Math.Max(num3, apJJqyhYppNdWcLPmwUWCSHCzQQ), true);
					num = 1763822036;
					continue;
				case 5:
					goto IL_00be;
				case 2:
					Array.Copy(items._items, startIndex, _items, _count, count);
					_count += count;
					HCKdygRhwCetItzVwbRsEqktGNve++;
					num = 1763822043;
					continue;
				case 3:
					goto IL_0115;
				case 6:
					goto IL_0135;
				default:
					return true;
				}
				break;
				IL_0072:
				if (num2 == 0)
				{
					return false;
				}
				if (num2 < count && !allowPartialAdd)
				{
					return false;
				}
				count = hMkCoDBlpOZUgiEpRZueWuTFxnD(Math.Max(num3, apJJqyhYppNdWcLPmwUWCSHCzQQ));
				num = 1763822046;
			}
			goto IL_0011;
			IL_004a:
			if (count == 0)
			{
				return true;
			}
			num3 = qvddhAEohNgcpXDiHojyOjpuJQDJ - _count;
			int num4;
			if (count > num3)
			{
				num = 1763822040;
				num4 = num;
			}
			else
			{
				num = 1763822046;
				num4 = num;
			}
			goto IL_0016;
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
			int num = 0;
			while (true)
			{
				IL_006d:
				int num2;
				if (num >= _count)
				{
					if (_count >= laVHllDIrWhFhNcWsTnrGRRlPSt)
					{
						break;
					}
					num2 = -1366269499;
					goto IL_0011;
				}
				goto IL_0032;
				IL_0032:
				if (ubrUaedVBLiQYMPUtnVWqcasDXu.Equals(_items[num], y))
				{
					_items[num] = item;
					num2 = -1366269501;
				}
				else
				{
					num++;
					num2 = -1366269502;
				}
				goto IL_0011;
				IL_0011:
				while (true)
				{
					switch (num2 ^ -1366269503)
					{
					case 0:
						num2 = -1366269504;
						continue;
					case 1:
						break;
					case 2:
						return num;
					case 3:
						goto IL_006d;
					default:
						return Add(item);
					}
					break;
				}
				goto IL_0032;
			}
			return -1;
		}

		public int AddToFirstOpenSpace(T item, T openSpaceEquals)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < _count)
				{
					num2 = 867172622;
					num3 = num2;
				}
				else
				{
					num2 = 867172616;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x33B0010C)
					{
					case 0:
						num2 = 867172622;
						continue;
					case 2:
						if (ubrUaedVBLiQYMPUtnVWqcasDXu.Equals(_items[num], openSpaceEquals))
						{
							_items[num] = item;
							return num;
						}
						num++;
						num2 = 867172621;
						continue;
					case 4:
						if (_count < laVHllDIrWhFhNcWsTnrGRRlPSt)
						{
							num2 = 867172623;
							continue;
						}
						return -1;
					case 1:
						break;
					default:
						return Add(item);
					}
					break;
				}
			}
		}

		public bool Insert(int index, T item)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -682957940;
					while (true)
					{
						switch (num ^ -682957944)
						{
						case 3:
							break;
						case 4:
							goto IL_0031;
						case 1:
							goto IL_004b;
						case 0:
							goto end_IL_0004;
						case 5:
							goto IL_006c;
						default:
							_count++;
							HCKdygRhwCetItzVwbRsEqktGNve++;
							return true;
						}
						break;
						IL_006c:
						if (_count == qvddhAEohNgcpXDiHojyOjpuJQDJ && hMkCoDBlpOZUgiEpRZueWuTFxnD(apJJqyhYppNdWcLPmwUWCSHCzQQ) == 0)
						{
							return false;
						}
						if (index < _count)
						{
							Array.Copy(_items, index, _items, index + 1, _count - index);
							num = -682957943;
							continue;
						}
						goto IL_004b;
						IL_0031:
						int num2;
						if (index > _count)
						{
							num = -682957944;
							num2 = num;
						}
						else
						{
							num = -682957939;
							num2 = num;
						}
						continue;
						IL_004b:
						_items[index] = item;
						num = -682957942;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}

		public bool Remove(T item)
		{
			int num = IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			RemoveAt(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			if (index < 0)
			{
				goto IL_0070;
			}
			if (index >= _count)
			{
				goto IL_000d;
			}
			goto IL_007d;
			IL_007d:
			_count--;
			int num;
			if (index < _count)
			{
				Array.Copy(_items, index + 1, _items, index, _count - index);
				num = 6653789;
				goto IL_0012;
			}
			goto IL_003a;
			IL_000d:
			num = 6653787;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x65875F)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_003a;
				case 1:
					HCKdygRhwCetItzVwbRsEqktGNve++;
					num = 6653788;
					continue;
				case 4:
					goto IL_0070;
				case 5:
					goto IL_007d;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_003a:
			_items[_count] = default(T);
			num = 6653790;
			goto IL_0012;
			IL_0070:
			throw new IndexOutOfRangeException();
		}

		public bool Contains(T item)
		{
			return Contains(item, ubrUaedVBLiQYMPUtnVWqcasDXu);
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
				int num2 = -976614109;
				while (true)
				{
					switch (num2 ^ -976614106)
					{
					case 0:
						num2 = -976614110;
						continue;
					case 4:
						break;
					case 2:
						if (comparer.Equals(_items[num], item))
						{
							num2 = -976614105;
							continue;
						}
						num++;
						num2 = -976614109;
						continue;
					case 5:
					{
						int num3;
						if (num >= _count)
						{
							num2 = -976614107;
							num3 = num2;
						}
						else
						{
							num2 = -976614108;
							num3 = num2;
						}
						continue;
					}
					case 1:
						return true;
					default:
						return false;
					}
					break;
				}
			}
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		public int IndexOf(T item, int index)
		{
			return IndexOf(item, index, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		public int IndexOf(T item, int index, int count)
		{
			return IndexOf(item, index, count, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				goto IL_0003;
			}
			goto IL_0073;
			IL_0003:
			int num = 301561165;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x11F97548)
				{
				case 3:
					break;
				case 5:
					throw new ArgumentNullException("comparer");
				case 0:
					num = 301561162;
					continue;
				case 6:
					return num2;
				case 4:
					goto IL_0057;
				case 1:
					goto IL_0073;
				default:
					if (num2 >= _count)
					{
						return -1;
					}
					goto IL_0057;
				}
				break;
				IL_0057:
				if (!comparer.Equals(_items[num2], item))
				{
					num2++;
					num = 301561162;
				}
				else
				{
					num = 301561166;
				}
			}
			goto IL_0003;
			IL_0073:
			num2 = 0;
			num = 301561160;
			goto IL_0008;
		}

		public int IndexOf(T item, int index, IEqualityComparer<T> comparer)
		{
			if (index < 0)
			{
				goto IL_0037;
			}
			if (index >= _count)
			{
				goto IL_000d;
			}
			goto IL_0072;
			IL_0072:
			int num = index;
			int num2 = 1647723370;
			goto IL_0012;
			IL_000d:
			num2 = 1647723371;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ 0x62364369)
				{
				case 0:
					break;
				case 2:
					goto IL_0037;
				case 5:
					goto IL_0049;
				case 3:
					num2 = 1647723368;
					continue;
				case 4:
					goto IL_0072;
				default:
					if (num >= _count)
					{
						return -1;
					}
					goto IL_0049;
				}
				break;
				IL_0049:
				if (comparer.Equals(_items[num], item))
				{
					return num;
				}
				num++;
				num2 = 1647723368;
			}
			goto IL_000d;
			IL_0037:
			throw new ArgumentOutOfRangeException("index");
		}

		public int IndexOf(T item, int index, int count, IEqualityComparer<T> comparer)
		{
			if (index >= 0)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -963465504;
					while (true)
					{
						switch (num ^ -963465502)
						{
						case 3:
							break;
						case 6:
							if (count < 0)
							{
								throw new ArgumentOutOfRangeException("count");
							}
							goto case 7;
						case 4:
							goto end_IL_0004;
						case 0:
							goto IL_0061;
						case 5:
							num3 = index + count;
							num2 = index;
							num = -963465501;
							continue;
						case 7:
							if (index + count > _count)
							{
								throw new ArgumentOutOfRangeException();
							}
							goto case 5;
						case 2:
							goto IL_00af;
						default:
							if (num2 >= num3)
							{
								return -1;
							}
							goto IL_0061;
						}
						break;
						IL_00af:
						int num4;
						if (index < _count)
						{
							num = -963465500;
							num4 = num;
						}
						else
						{
							num = -963465498;
							num4 = num;
						}
						continue;
						IL_0061:
						if (comparer.Equals(_items[num2], item))
						{
							return num2;
						}
						num2++;
						num = -963465501;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
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
			goto IL_0046;
			IL_0004:
			int num = 776902697;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x2E4E9828)
				{
				case 6:
					break;
				default:
					return;
				case 5:
					goto IL_0032;
				case 4:
					goto IL_0046;
				case 1:
					throw new ArgumentOutOfRangeException("index");
				case 0:
					goto IL_006e;
				case 3:
					HCKdygRhwCetItzVwbRsEqktGNve++;
					num = 776902698;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_0004;
			IL_006e:
			if (_count - index < count)
			{
				throw new ArgumentOutOfRangeException();
			}
			goto IL_0032;
			IL_0032:
			Array.Reverse((Array)_items, index, count);
			num = 776902699;
			goto IL_0009;
			IL_0046:
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			goto IL_006e;
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
				throw new ArgumentOutOfRangeException("index");
			}
			while (count >= 0)
			{
				while (true)
				{
					IL_0060:
					if (_count - index >= count)
					{
						while (true)
						{
							IL_004b:
							Array.Sort(_items, index, count, comparer);
							int num = -1925821408;
							while (true)
							{
								switch (num ^ -1925821405)
								{
								case 0:
									num = -1925821401;
									continue;
								case 4:
									break;
								case 2:
									goto IL_004b;
								case 1:
									goto IL_0060;
								default:
									HCKdygRhwCetItzVwbRsEqktGNve++;
									return;
								}
								break;
							}
							break;
						}
						break;
					}
					throw new ArgumentOutOfRangeException();
				}
			}
			throw new ArgumentOutOfRangeException("count");
		}

		public List<T> GetRange(int index, int count)
		{
			if (index >= 0)
			{
				T[] array = default(T[]);
				while (true)
				{
					int num = -1783252767;
					while (true)
					{
						switch (num ^ -1783252761)
						{
						case 5:
							break;
						case 6:
							goto IL_0032;
						case 3:
							goto end_IL_0004;
						case 4:
							if (count < 0)
							{
								throw new ArgumentOutOfRangeException("count");
							}
							goto case 2;
						case 0:
							array = new T[count];
							Array.Copy(_items, index, array, 0, count);
							num = -1783252762;
							continue;
						case 2:
							if (_count - index < count)
							{
								throw new ArgumentOutOfRangeException();
							}
							goto case 0;
						default:
							return new List<T>(array);
						}
						break;
						IL_0032:
						int num2;
						if (index >= _count)
						{
							num = -1783252764;
							num2 = num;
						}
						else
						{
							num = -1783252765;
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
				goto IL_0006;
			}
			goto IL_008f;
			IL_0006:
			int num = 163595770;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x9C045F9)
				{
				case 0:
					break;
				case 3:
					throw new ArgumentNullException("match");
				case 6:
					goto IL_0046;
				case 4:
					goto IL_0060;
				case 5:
					goto IL_008f;
				case 2:
					num = 163595775;
					continue;
				default:
					return default(T);
				}
				break;
				IL_0060:
				if (match(_items[num2]))
				{
					return _items[num2];
				}
				num2++;
				num = 163595775;
				continue;
				IL_0046:
				int num3;
				if (num2 >= _count)
				{
					num = 163595768;
					num3 = num;
				}
				else
				{
					num = 163595773;
					num3 = num;
				}
			}
			goto IL_0006;
			IL_008f:
			num2 = 0;
			num = 163595771;
			goto IL_000b;
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
				int num = -197795854;
				while (true)
				{
					switch (num ^ -197795856)
					{
					case 4:
						num = -197795855;
						continue;
					case 0:
						if (match(_items[num2]))
						{
							list.Add(_items[num2]);
							num = -197795851;
							continue;
						}
						goto case 5;
					case 5:
						num2++;
						num = -197795853;
						continue;
					case 1:
						break;
					case 2:
						num2 = 0;
						num = -197795853;
						continue;
					default:
						if (num2 >= _count)
						{
							return list;
						}
						goto case 0;
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
					num = 902107854;
					num2 = num;
				}
				else
				{
					num = 902107855;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x35C512CD)
					{
					case 5:
						num = 902107852;
						continue;
					case 9:
						num = 902107851;
						continue;
					case 6:
					{
						int num7;
						if (num4 >= num3)
						{
							num = 902107850;
							num7 = num;
						}
						else
						{
							num = 902107853;
							num7 = num;
						}
						continue;
					}
					case 3:
					{
						int num6;
						if (startIndex > _count - count)
						{
							num = 902107855;
							num6 = num;
						}
						else
						{
							num = 902107849;
							num6 = num;
						}
						continue;
					}
					case 0:
						if (match(_items[num4]))
						{
							return num4;
						}
						num4++;
						num = 902107851;
						continue;
					case 4:
					{
						int num5;
						if (match == null)
						{
							num = 902107847;
							num5 = num;
						}
						else
						{
							num = 902107845;
							num5 = num;
						}
						continue;
					}
					case 2:
						throw new ArgumentOutOfRangeException();
					case 10:
						throw new ArgumentNullException("match");
					case 1:
						break;
					case 8:
						num3 = startIndex + count;
						num4 = startIndex;
						num = 902107844;
						continue;
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
				throw new ArgumentNullException("match");
			}
			T result = default(T);
			while (true)
			{
				int num = _count - 1;
				int num2 = -485333877;
				while (true)
				{
					switch (num2 ^ -485333880)
					{
					case 5:
						num2 = -485333879;
						continue;
					case 1:
						break;
					case 4:
						result = default(T);
						num2 = -485333880;
						continue;
					case 3:
					{
						int num3;
						if (num < 0)
						{
							num2 = -485333876;
							num3 = num2;
						}
						else
						{
							num2 = -485333878;
							num3 = num2;
						}
						continue;
					}
					case 2:
						if (match(_items[num]))
						{
							return _items[num];
						}
						num--;
						num2 = -485333877;
						continue;
					default:
						return result;
					}
					break;
				}
			}
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
				goto IL_0003;
			}
			goto IL_005d;
			IL_0003:
			int num = -682560355;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -682560358)
				{
				case 9:
					break;
				case 5:
					goto IL_0040;
				case 2:
					goto IL_005d;
				case 4:
					throw new ArgumentOutOfRangeException("startIndex");
				case 7:
					throw new ArgumentNullException("match");
				case 3:
					goto IL_00a5;
				case 8:
					goto IL_00b5;
				case 0:
					goto IL_00d2;
				case 1:
					num3 = startIndex - count;
					num2 = startIndex;
					num = -682560356;
					continue;
				default:
					if (num2 <= num3)
					{
						return -1;
					}
					goto IL_00d2;
				}
				break;
				IL_00d2:
				if (match(_items[num2]))
				{
					return num2;
				}
				num2--;
				num = -682560356;
			}
			goto IL_0003;
			IL_00b5:
			int num4;
			if ((uint)startIndex >= (uint)_count)
			{
				num = -682560354;
				num4 = num;
			}
			else
			{
				num = -682560353;
				num4 = num;
			}
			goto IL_0008;
			IL_005d:
			if (_count == 0)
			{
				if (startIndex != -1)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				goto IL_0040;
			}
			goto IL_00b5;
			IL_00a5:
			throw new ArgumentOutOfRangeException();
			IL_0040:
			if (count >= 0)
			{
				int num5;
				if (startIndex - count + 1 >= 0)
				{
					num = -682560357;
					num5 = num;
				}
				else
				{
					num = -682560359;
					num5 = num;
				}
				goto IL_0008;
			}
			goto IL_00a5;
		}

		public void ForEach(Action<T> action)
		{
			if (_count == 0)
			{
				goto IL_000b;
			}
			goto IL_009c;
			IL_000b:
			int num = 564488818;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			int hCKdygRhwCetItzVwbRsEqktGNve = default(int);
			while (true)
			{
				switch (num ^ 0x21A56A7A)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					goto IL_0048;
				case 7:
					action(_items[num2]);
					num2++;
					num = 564488825;
					continue;
				case 9:
					goto IL_007f;
				case 5:
					goto IL_009c;
				case 0:
					goto IL_00b4;
				case 2:
					throw new Exception("List was changed.");
				case 3:
					goto IL_00dc;
				case 8:
					return;
				case 6:
					return;
				}
				break;
				IL_00dc:
				int num3;
				if (num2 < _count)
				{
					num = 564488819;
					num3 = num;
				}
				else
				{
					num = 564488827;
					num3 = num;
				}
				continue;
				IL_007f:
				int num4;
				if (hCKdygRhwCetItzVwbRsEqktGNve == HCKdygRhwCetItzVwbRsEqktGNve)
				{
					num = 564488829;
					num4 = num;
				}
				else
				{
					num = 564488827;
					num4 = num;
				}
				continue;
				IL_0048:
				int num5;
				if (hCKdygRhwCetItzVwbRsEqktGNve != HCKdygRhwCetItzVwbRsEqktGNve)
				{
					num = 564488824;
					num5 = num;
				}
				else
				{
					num = 564488828;
					num5 = num;
				}
			}
			goto IL_000b;
			IL_00b4:
			hCKdygRhwCetItzVwbRsEqktGNve = HCKdygRhwCetItzVwbRsEqktGNve;
			num2 = 0;
			num = 564488825;
			goto IL_0010;
			IL_009c:
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			goto IL_00b4;
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
				if (index < _count)
				{
					goto IL_003d;
				}
				while (true)
				{
					switch (-460756819 ^ -460756820)
					{
					case 0:
						break;
					case 1:
						goto end_IL_000d;
					default:
						goto IL_003d;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_003d:
			return LastIndexOf(item, index, index + 1);
		}

		public int LastIndexOf(T item, int index, int count)
		{
			if (_count != 0 && index < 0)
			{
				goto IL_000c;
			}
			goto IL_0078;
			IL_0078:
			int num;
			int num2;
			if (_count != 0)
			{
				num = -1171072051;
				num2 = num;
			}
			else
			{
				num = -1171072052;
				num2 = num;
			}
			goto IL_0011;
			IL_000c:
			num = -1171072054;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ -1171072055)
				{
				case 6:
					break;
				case 0:
					goto IL_0045;
				case 8:
					return -1;
				case 2:
					goto IL_0078;
				case 3:
					throw new ArgumentOutOfRangeException("index");
				case 4:
					goto IL_00a6;
				case 5:
					goto IL_00be;
				case 1:
					throw new ArgumentOutOfRangeException("count");
				default:
					goto IL_00e5;
				}
				break;
				IL_00be:
				if (_count != 0)
				{
					if (index >= _count)
					{
						throw new ArgumentOutOfRangeException("index");
					}
					goto IL_0045;
				}
				num = -1171072063;
				continue;
				IL_00a6:
				int num3;
				if (count < 0)
				{
					num = -1171072056;
					num3 = num;
				}
				else
				{
					num = -1171072052;
					num3 = num;
				}
				continue;
				IL_0045:
				if (count > index + 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				goto IL_00e5;
				IL_00e5:
				return Array.LastIndexOf(_items, item, index, count);
			}
			goto IL_000c;
		}

		public int RemoveAll(Predicate<T> match)
		{
			if (_count == 0)
			{
				goto IL_0008;
			}
			int num;
			int num2;
			if (match == null)
			{
				num = 1890046167;
				num2 = num;
			}
			else
			{
				num = 1890046165;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = 1890046162;
			goto IL_000d;
			IL_000d:
			int num5 = default(int);
			int num3 = default(int);
			int result = default(int);
			while (true)
			{
				switch (num ^ 0x70A7D0D1)
				{
				case 11:
					break;
				case 3:
					return 0;
				case 5:
					num5++;
					num = 1890046175;
					continue;
				case 2:
					if (num5 < _count)
					{
						_items[num3++] = _items[num5++];
						num = 1890046166;
						continue;
					}
					goto case 7;
				case 0:
					if (num3 >= _count)
					{
						num = 1890046160;
						continue;
					}
					num5 = num3 + 1;
					num = 1890046166;
					continue;
				case 12:
				{
					int num7;
					if (match(_items[num5]))
					{
						num = 1890046164;
						num7 = num;
					}
					else
					{
						num = 1890046163;
						num7 = num;
					}
					continue;
				}
				case 14:
				{
					int num6;
					if (num5 < _count)
					{
						num = 1890046173;
						num6 = num;
					}
					else
					{
						num = 1890046163;
						num6 = num;
					}
					continue;
				}
				case 8:
					if (num3 < _count)
					{
						int num4;
						if (match(_items[num3]))
						{
							num = 1890046161;
							num4 = num;
						}
						else
						{
							num = 1890046171;
							num4 = num;
						}
						continue;
					}
					goto case 0;
				case 4:
					num3 = 0;
					num = 1890046169;
					continue;
				case 6:
					throw new ArgumentNullException("match");
				case 1:
					return 0;
				case 7:
					if (num5 >= _count)
					{
						Array.Clear(_items, num3, _count - num3);
						result = _count - num3;
						num = 1890046172;
						continue;
					}
					goto case 14;
				case 10:
					num3++;
					num = 1890046169;
					continue;
				case 13:
					_count = num3;
					HCKdygRhwCetItzVwbRsEqktGNve++;
					num = 1890046168;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_0008;
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
				int num2 = 135939461;
				while (true)
				{
					switch (num2 ^ 0x81A4585)
					{
					case 4:
						num2 = 135939460;
						continue;
					case 1:
						break;
					case 0:
						num2 = 135939462;
						continue;
					case 2:
						if (!match(_items[num]))
						{
							return false;
						}
						num++;
						num2 = 135939462;
						continue;
					default:
						if (num >= _count)
						{
							return true;
						}
						goto case 2;
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
			Array.Copy(_items, index, array, arrayIndex, count);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(_items, 0, array, arrayIndex, _count);
		}

		public void Clear()
		{
			Array.Clear(_items, 0, _count);
			_count = 0;
			HCKdygRhwCetItzVwbRsEqktGNve++;
		}

		public void TrimExcess()
		{
			if (!RVtDHVbopyuIGGoAyKkAktvkKBL)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (_count != qvddhAEohNgcpXDiHojyOjpuJQDJ)
				{
					num = 1240222119;
					num2 = num;
				}
				else
				{
					num = 1240222118;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x49EC49A7)
					{
					case 3:
						goto IL_0009;
					case 2:
						break;
					case 1:
						return;
					default:
						rSmjMCfoajtRhMbXgbITDWHCQjC(_count);
						HCKdygRhwCetItzVwbRsEqktGNve++;
						return;
					}
					break;
					IL_0009:
					num = 1240222117;
				}
			}
		}

		private int hMkCoDBlpOZUgiEpRZueWuTFxnD(int P_0, bool P_1 = false)
		{
			if (!RVtDHVbopyuIGGoAyKkAktvkKBL)
			{
				goto IL_0008;
			}
			if (qvddhAEohNgcpXDiHojyOjpuJQDJ >= laVHllDIrWhFhNcWsTnrGRRlPSt)
			{
				return 0;
			}
			int num;
			if (niyKXeZbRmSJZYKJKVmsGWIGuso)
			{
				P_0 = vNvdKJHBvedrguoVkZEBUBjLdYJ(qvddhAEohNgcpXDiHojyOjpuJQDJ, P_0);
				num = 1629922237;
				goto IL_000d;
			}
			goto IL_005a;
			IL_0008:
			num = 1629922236;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x6126A3BE)
			{
			case 0:
				break;
			case 2:
				return 0;
			case 3:
				goto IL_005a;
			default:
				return 0;
			}
			goto IL_0008;
			IL_005a:
			P_0 = Math.Min(P_0, laVHllDIrWhFhNcWsTnrGRRlPSt - qvddhAEohNgcpXDiHojyOjpuJQDJ);
			if (P_0 <= 0)
			{
				num = 1629922239;
				goto IL_000d;
			}
			if (!rSmjMCfoajtRhMbXgbITDWHCQjC(qvddhAEohNgcpXDiHojyOjpuJQDJ + P_0))
			{
				return 0;
			}
			return P_0;
		}

		private int vNvdKJHBvedrguoVkZEBUBjLdYJ(int P_0, int P_1)
		{
			int num = P_0 + P_1;
			if (num < 4)
			{
				num = 4;
				goto IL_000a;
			}
			goto IL_002c;
			IL_002c:
			uint num2 = MathTools.RoundUpToPowerOf2((uint)num);
			int num3;
			int num4;
			if (num2 > int.MaxValue)
			{
				num3 = -402160581;
				num4 = num3;
			}
			else
			{
				num3 = -402160582;
				num4 = num3;
			}
			goto IL_000f;
			IL_000a:
			num3 = -402160584;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num3 ^ -402160583)
				{
				case 0:
					break;
				case 1:
					goto IL_002c;
				case 2:
					num2 = 2147483647u;
					num3 = -402160582;
					continue;
				default:
					return (int)num2 - P_0;
				}
				break;
			}
			goto IL_000a;
		}

		private bool rSmjMCfoajtRhMbXgbITDWHCQjC(int P_0, bool P_1 = false)
		{
			if (P_0 < 0)
			{
				P_0 = 0;
				goto IL_000a;
			}
			goto IL_00a2;
			IL_00a2:
			int num;
			T[] array = default(T[]);
			if (P_0 <= laVHllDIrWhFhNcWsTnrGRRlPSt)
			{
				if (P_0 == qvddhAEohNgcpXDiHojyOjpuJQDJ)
				{
					return true;
				}
				if (P_1)
				{
					num = 990506850;
				}
				else
				{
					array = new T[P_0];
					if (P_0 == 0)
					{
						goto IL_004f;
					}
					Array.Copy(_items, array, Math.Min(P_0, qvddhAEohNgcpXDiHojyOjpuJQDJ));
					num = 990506854;
				}
			}
			else
			{
				num = 990506849;
			}
			goto IL_000f;
			IL_000a:
			num = 990506855;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ 0x3B09EF62)
				{
				case 2:
					break;
				case 1:
					if (_count > P_0)
					{
						_count = P_0;
						num = 990506852;
						continue;
					}
					goto default;
				case 4:
					goto IL_004f;
				case 3:
					return false;
				case 0:
					return true;
				case 5:
					goto IL_00a2;
				default:
					_items = array;
					return true;
				}
				break;
			}
			goto IL_000a;
			IL_004f:
			qvddhAEohNgcpXDiHojyOjpuJQDJ = P_0;
			num = 990506851;
			goto IL_000f;
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
			if (array != null)
			{
				while (true)
				{
					switch (0x5C9371DD ^ 0x5C9371DC)
					{
					case 2:
						continue;
					case 1:
						if (array.Rank != 1)
						{
							throw new ArgumentException("Multi-dimensional arrays are not supported.");
						}
						break;
					}
					break;
				}
			}
			Array.Copy(_items, 0, array, arrayIndex, _count);
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
			return new XwZBaYTidkJBpkWVpuaBdmWkyln(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new XwZBaYTidkJBpkWVpuaBdmWkyln(this);
		}

		int IList.Add(object value)
		{
			if (!DbDCLLFEuRPoYFBILoUoAKgGCIlw(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return Add((T)value);
		}

		bool IList.Contains(object value)
		{
			if (!DbDCLLFEuRPoYFBILoUoAKgGCIlw(value))
			{
				while (true)
				{
					switch (-1460782520 ^ -1460782519)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentException("value is an incompatible type.");
					}
					break;
				}
			}
			return Contains((T)value);
		}

		int IList.IndexOf(object value)
		{
			if (!DbDCLLFEuRPoYFBILoUoAKgGCIlw(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return IndexOf((T)value);
		}

		void IList.Insert(int index, object value)
		{
			if (!DbDCLLFEuRPoYFBILoUoAKgGCIlw(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			while (true)
			{
				Insert(index, (T)value);
				int num = 876356330;
				while (true)
				{
					switch (num ^ 0x343C22EA)
					{
					case 2:
						goto IL_0013;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0013:
					num = 876356331;
				}
			}
		}

		void IList.Remove(object value)
		{
			if (!DbDCLLFEuRPoYFBILoUoAKgGCIlw(value))
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = -1961572828;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1961572826)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				throw new ArgumentException("value is an incompatible type.");
			case 1:
				goto IL_003c;
			case 3:
				return;
			}
			goto IL_0008;
			IL_003c:
			Remove((T)value);
			num = -1961572827;
			goto IL_000d;
		}

		public static AList<T> CreateFixedLengthList(int capacity)
		{
			return new AList<T>(capacity, capacity, 0);
		}

		private static bool DbDCLLFEuRPoYFBILoUoAKgGCIlw(object P_0)
		{
			if (!(P_0 is T))
			{
				if (P_0 == null)
				{
					return default(T) == null;
				}
				return false;
			}
			return true;
		}
	}
}
