using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class AList<T> : IList, IEnumerable, ICollection, IEnumerable<T>, ICollection<T>, IList<T>
	{
		[Serializable]
		public struct gAJClBheeuqAESMTRycXWpealIw : IDisposable, IEnumerator, IEnumerator<T>
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
							switch (0x256320DE ^ 0x256320DC)
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
					throw new InvalidOperationException();
					IL_0048:
					return Current;
				}
			}

			internal gAJClBheeuqAESMTRycXWpealIw(AList<T> list)
			{
				this.list = list;
				index = 0;
				version = list.wyCzBtxDiYHWdJxUIaVcrhitjEkf;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				AList<T> aList = list;
				if (version == aList.wyCzBtxDiYHWdJxUIaVcrhitjEkf && (uint)index < (uint)aList._count)
				{
					current = aList._items[index];
					index++;
					return true;
				}
				return qfQPaojlFYFdGHCplpjqNGLqLCW();
			}

			private bool qfQPaojlFYFdGHCplpjqNGLqLCW()
			{
				if (version != list.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					goto IL_0013;
				}
				goto IL_0047;
				IL_0013:
				int num = -2062953289;
				goto IL_0018;
				IL_0018:
				switch (num ^ -2062953291)
				{
				case 0:
					break;
				case 2:
					throw new InvalidOperationException("List was changed.");
				case 1:
					goto IL_0047;
				default:
					return false;
				}
				goto IL_0013;
				IL_0047:
				index = list._count + 1;
				current = default(T);
				num = -2062953290;
				goto IL_0018;
			}

			void IEnumerator.Reset()
			{
				if (version != list.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					goto IL_0013;
				}
				goto IL_0047;
				IL_0013:
				int num = -2074532960;
				goto IL_0018;
				IL_0018:
				switch (num ^ -2074532957)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					throw new InvalidOperationException("List was changed.");
				case 1:
					goto IL_0047;
				case 2:
					return;
				}
				goto IL_0013;
				IL_0047:
				index = 0;
				current = default(T);
				num = -2074532959;
				goto IL_0018;
			}
		}

		private const int OvvzDaSnSYZsfnTXXikHnQlgdUs = 4;

		private static readonly T[] IthCCRhsnHXHdaTkPqrssOkvoDL = new T[0];

		private IEqualityComparer<T> TlxZdrFpPRDnfquVHbnQJocwbYh = EqualityComparerNoAlloc<T>.Default;

		public T[] _items;

		private int ZQtXcXYFxPSVYxnpniroAAvoIDE;

		public int _count;

		private int DkLIRtVljhkIdWrKYmmEzzPAotV;

		private bool UZyNItdYDijdcqeGsgFmlDGQPdp;

		private readonly int GZHaUyzxjQVgKnQHKqrxfgJnPDy;

		private readonly bool yiNGsSPmOzBjQufduObiVfnlZkU;

		private int wyCzBtxDiYHWdJxUIaVcrhitjEkf;

		[NonSerialized]
		private object hXfFbNklCHLuuDBVVoEKlNLfPpvH;

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
				return ZQtXcXYFxPSVYxnpniroAAvoIDE;
			}
		}

		public int FreeSpace
		{
			get
			{
				return GZHaUyzxjQVgKnQHKqrxfgJnPDy - _count;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return !yiNGsSPmOzBjQufduObiVfnlZkU;
			}
		}

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return TlxZdrFpPRDnfquVHbnQJocwbYh;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				TlxZdrFpPRDnfquVHbnQJocwbYh = value;
			}
		}

		public int Version
		{
			get
			{
				return wyCzBtxDiYHWdJxUIaVcrhitjEkf;
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
				_items[index] = value;
				wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
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
				if (!ioRSOGmOmZQLbrcHvdUuCjsSYByk(value))
				{
					while (true)
					{
						switch (0x5237FA78 ^ 0x5237FA79)
						{
						case 2:
							continue;
						case 1:
							throw new ArgumentException("value is an incompatible type.");
						}
						break;
					}
				}
				this[index] = (T)value;
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
				if (hXfFbNklCHLuuDBVVoEKlNLfPpvH == null)
				{
					Interlocked.CompareExchange<object>(ref hXfFbNklCHLuuDBVVoEKlNLfPpvH, new object(), (object)null);
				}
				return hXfFbNklCHLuuDBVVoEKlNLfPpvH;
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
				yiNGsSPmOzBjQufduObiVfnlZkU = true;
			}
			if (!yiNGsSPmOzBjQufduObiVfnlZkU && startingCapacity == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (yiNGsSPmOzBjQufduObiVfnlZkU && expansionIncrement == 0)
			{
				UZyNItdYDijdcqeGsgFmlDGQPdp = true;
				expansionIncrement = 1;
			}
			DkLIRtVljhkIdWrKYmmEzzPAotV = expansionIncrement;
			ZQtXcXYFxPSVYxnpniroAAvoIDE = startingCapacity;
			GZHaUyzxjQVgKnQHKqrxfgJnPDy = ((maxCapacity == 0) ? int.MaxValue : maxCapacity);
			_count = 0;
			if (ZQtXcXYFxPSVYxnpniroAAvoIDE == 0)
			{
				_items = IthCCRhsnHXHdaTkPqrssOkvoDL;
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
					array = IthCCRhsnHXHdaTkPqrssOkvoDL;
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
				yiNGsSPmOzBjQufduObiVfnlZkU = true;
			}
			if (!yiNGsSPmOzBjQufduObiVfnlZkU && num == 0)
			{
				throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
			}
			if (yiNGsSPmOzBjQufduObiVfnlZkU && expansionIncrement == 0)
			{
				UZyNItdYDijdcqeGsgFmlDGQPdp = true;
				expansionIncrement = 1;
			}
			DkLIRtVljhkIdWrKYmmEzzPAotV = expansionIncrement;
			ZQtXcXYFxPSVYxnpniroAAvoIDE = num;
			GZHaUyzxjQVgKnQHKqrxfgJnPDy = ((maxCapacity == 0) ? int.MaxValue : maxCapacity);
			_items = ((array != null) ? array : IthCCRhsnHXHdaTkPqrssOkvoDL);
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
			if (_count == ZQtXcXYFxPSVYxnpniroAAvoIDE && SniZSVpzAYoPXCBrNHmVlaTrkAj(DkLIRtVljhkIdWrKYmmEzzPAotV) == 0)
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
			if (items != null)
			{
				int num3 = default(int);
				while (true)
				{
					int num = -1445973950;
					while (true)
					{
						switch (num ^ -1445973948)
						{
						case 0:
							break;
						case 5:
							throw new ArgumentOutOfRangeException("startIndex");
						case 8:
							goto IL_0059;
						case 4:
							goto IL_0064;
						case 1:
							goto IL_007f;
						case 7:
							return false;
						case 6:
							goto IL_00de;
						case 3:
							goto end_IL_0006;
						case 2:
							if (count + startIndex > items.Length)
							{
								throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the array.");
							}
							goto case 10;
						case 10:
							if (count <= 0)
							{
								count = items.Length - startIndex;
								num = -1445973947;
								continue;
							}
							goto IL_007f;
						default:
							_count += count;
							wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
							return true;
						}
						break;
						IL_00de:
						int num2;
						if (items.Length == 0)
						{
							num = -1445973945;
						}
						else if ((uint)startIndex < (uint)items.Length)
						{
							num = -1445973946;
							num2 = num;
						}
						else
						{
							num = -1445973951;
							num2 = num;
						}
						continue;
						IL_007f:
						if (count == 0)
						{
							return true;
						}
						num3 = ZQtXcXYFxPSVYxnpniroAAvoIDE - _count;
						if (count <= num3)
						{
							goto IL_0064;
						}
						int num4 = SniZSVpzAYoPXCBrNHmVlaTrkAj(Math.Max(num3, DkLIRtVljhkIdWrKYmmEzzPAotV), true);
						if (num4 == 0)
						{
							return false;
						}
						if (num4 < count)
						{
							num = -1445973940;
							continue;
						}
						goto IL_00bf;
						IL_0064:
						Array.Copy(items, startIndex, _items, _count, count);
						num = -1445973939;
						continue;
						IL_0059:
						if (!allowPartialAdd)
						{
							num = -1445973949;
							continue;
						}
						goto IL_00bf;
						IL_00bf:
						count = SniZSVpzAYoPXCBrNHmVlaTrkAj(Math.Max(num3, DkLIRtVljhkIdWrKYmmEzzPAotV));
						num = -1445973952;
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
			int num;
			if (items != null)
			{
				if (items._count == 0)
				{
					goto IL_000b;
				}
				int num2;
				if ((uint)startIndex < (uint)items._count)
				{
					num = -793884745;
					num2 = num;
				}
				else
				{
					num = -793884742;
					num2 = num;
				}
				goto IL_0010;
			}
			goto IL_007e;
			IL_0010:
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ -793884739)
				{
				case 2:
					break;
				case 10:
					if (count + startIndex > items._count)
					{
						throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the list.");
					}
					goto IL_0069;
				case 8:
					goto IL_0069;
				case 4:
					goto IL_007e;
				case 7:
					throw new ArgumentOutOfRangeException("startIndex");
				case 3:
					goto IL_00b2;
				case 9:
					goto IL_00bf;
				case 5:
					return false;
				case 1:
					goto IL_0129;
				case 6:
					count = items._count - startIndex;
					num = -793884740;
					continue;
				default:
					return true;
				}
				break;
				IL_0129:
				if (count == 0)
				{
					return true;
				}
				num3 = ZQtXcXYFxPSVYxnpniroAAvoIDE - _count;
				if (count > num3)
				{
					num4 = SniZSVpzAYoPXCBrNHmVlaTrkAj(Math.Max(num3, DkLIRtVljhkIdWrKYmmEzzPAotV), true);
					num = -793884738;
					continue;
				}
				goto IL_00bf;
				IL_00bf:
				Array.Copy(items._items, startIndex, _items, _count, count);
				_count += count;
				wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
				num = -793884739;
				continue;
				IL_00b2:
				if (num4 == 0)
				{
					num = -793884744;
					continue;
				}
				if (num4 < count && !allowPartialAdd)
				{
					return false;
				}
				count = SniZSVpzAYoPXCBrNHmVlaTrkAj(Math.Max(num3, DkLIRtVljhkIdWrKYmmEzzPAotV));
				num = -793884748;
				continue;
				IL_0069:
				int num5;
				if (count > 0)
				{
					num = -793884740;
					num5 = num;
				}
				else
				{
					num = -793884741;
					num5 = num;
				}
			}
			goto IL_000b;
			IL_000b:
			num = -793884743;
			goto IL_0010;
			IL_007e:
			return true;
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
				int num = 148791203;
				while (true)
				{
					switch (num ^ 0x8DE5FA1)
					{
					case 0:
						break;
					case 1:
						if (TlxZdrFpPRDnfquVHbnQJocwbYh.Equals(_items[num2], y))
						{
							_items[num2] = item;
							return num2;
						}
						num2++;
						num = 148791204;
						continue;
					case 4:
						num = 148791204;
						continue;
					case 2:
						num2 = 0;
						num = 148791205;
						continue;
					case 5:
						if (num2 >= _count)
						{
							if (_count < GZHaUyzxjQVgKnQHKqrxfgJnPDy)
							{
								num = 148791202;
								continue;
							}
							return -1;
						}
						goto case 1;
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
			while (num < _count)
			{
				while (true)
				{
					if (TlxZdrFpPRDnfquVHbnQJocwbYh.Equals(_items[num], openSpaceEquals))
					{
						_items[num] = item;
						return num;
					}
					num++;
					int num2 = -1325187308;
					while (true)
					{
						switch (num2 ^ -1325187308)
						{
						case 2:
							num2 = -1325187307;
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
			if (_count < GZHaUyzxjQVgKnQHKqrxfgJnPDy)
			{
				return Add(item);
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
				goto IL_006d;
			}
			goto IL_0091;
			IL_003d:
			_items[index] = item;
			_count++;
			wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
			int num = -1049093740;
			goto IL_0015;
			IL_0010:
			num = -1049093737;
			goto IL_0015;
			IL_0015:
			switch (num ^ -1049093738)
			{
			case 3:
				break;
			case 0:
				goto IL_003d;
			case 4:
				goto IL_006d;
			case 1:
				goto IL_0091;
			case 5:
				return false;
			default:
				return true;
			}
			goto IL_0010;
			IL_0091:
			throw new IndexOutOfRangeException();
			IL_006d:
			if (_count == ZQtXcXYFxPSVYxnpniroAAvoIDE && SniZSVpzAYoPXCBrNHmVlaTrkAj(DkLIRtVljhkIdWrKYmmEzzPAotV) == 0)
			{
				num = -1049093741;
			}
			else
			{
				if (index >= _count)
				{
					goto IL_003d;
				}
				Array.Copy(_items, index, _items, index + 1, _count - index);
				num = -1049093738;
			}
			goto IL_0015;
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
				goto IL_0033;
			}
			if (index >= _count)
			{
				goto IL_000d;
			}
			goto IL_006f;
			IL_0040:
			_items[_count] = default(T);
			wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
			int num = -1649404269;
			goto IL_0012;
			IL_000d:
			num = -1649404272;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1649404271)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0033;
			case 0:
				goto IL_0040;
			case 4:
				goto IL_006f;
			case 2:
				return;
			}
			goto IL_000d;
			IL_0033:
			throw new IndexOutOfRangeException();
			IL_006f:
			_count--;
			if (index < _count)
			{
				Array.Copy(_items, index + 1, _items, index, _count - index);
				num = -1649404271;
				goto IL_0012;
			}
			goto IL_0040;
		}

		public bool Contains(T item)
		{
			return Contains(item, TlxZdrFpPRDnfquVHbnQJocwbYh);
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
				int num2 = 776360383;
				while (true)
				{
					switch (num2 ^ 0x2E4651BE)
					{
					case 0:
						num2 = 776360381;
						continue;
					case 3:
						break;
					case 2:
						if (comparer.Equals(_items[num], item))
						{
							return true;
						}
						num++;
						num2 = 776360383;
						continue;
					default:
						if (num >= _count)
						{
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, TlxZdrFpPRDnfquVHbnQJocwbYh);
		}

		public int IndexOf(T item, int index)
		{
			return IndexOf(item, index, TlxZdrFpPRDnfquVHbnQJocwbYh);
		}

		public int IndexOf(T item, int index, int count)
		{
			return IndexOf(item, index, count, TlxZdrFpPRDnfquVHbnQJocwbYh);
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
				int num2 = -1780019843;
				while (true)
				{
					switch (num2 ^ -1780019848)
					{
					case 2:
						num2 = -1780019844;
						continue;
					case 3:
						return num;
					case 0:
						if (!comparer.Equals(_items[num], item))
						{
							num++;
							num2 = -1780019843;
						}
						else
						{
							num2 = -1780019845;
						}
						continue;
					case 5:
					{
						int num3;
						if (num < _count)
						{
							num2 = -1780019848;
							num3 = num2;
						}
						else
						{
							num2 = -1780019847;
							num3 = num2;
						}
						continue;
					}
					case 4:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int IndexOf(T item, int index, IEqualityComparer<T> comparer)
		{
			if (index < 0)
			{
				goto IL_0033;
			}
			if (index >= _count)
			{
				goto IL_000d;
			}
			goto IL_0067;
			IL_0033:
			throw new ArgumentOutOfRangeException("index");
			IL_000d:
			int num = -1489609727;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1489609725)
				{
				case 0:
					break;
				case 2:
					goto IL_0033;
				case 4:
					goto IL_0045;
				case 1:
					goto IL_0067;
				default:
					if (num2 >= _count)
					{
						return -1;
					}
					goto IL_0045;
				}
				break;
				IL_0045:
				if (comparer.Equals(_items[num2], item))
				{
					return num2;
				}
				num2++;
				num = -1489609728;
			}
			goto IL_000d;
			IL_0067:
			num2 = index;
			num = -1489609728;
			goto IL_0012;
		}

		public int IndexOf(T item, int index, int count, IEqualityComparer<T> comparer)
		{
			if (index >= 0)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 432881221;
					while (true)
					{
						switch (num ^ 0x19CD3E41)
						{
						case 7:
							break;
						case 6:
							num = 432881225;
							continue;
						case 3:
							num3 = index + count;
							num = 432881217;
							continue;
						case 4:
							goto IL_0056;
						case 2:
							if (index + count > _count)
							{
								throw new ArgumentOutOfRangeException();
							}
							goto case 3;
						case 1:
							goto end_IL_0007;
						case 0:
							num2 = index;
							num = 432881223;
							continue;
						case 9:
							goto IL_00a9;
						case 5:
							if (count < 0)
							{
								throw new ArgumentOutOfRangeException("count");
							}
							goto case 2;
						default:
							if (num2 >= num3)
							{
								return -1;
							}
							goto IL_00a9;
						}
						break;
						IL_00a9:
						if (comparer.Equals(_items[num2], item))
						{
							return num2;
						}
						num2++;
						num = 432881225;
						continue;
						IL_0056:
						int num4;
						if (index < _count)
						{
							num = 432881220;
							num4 = num;
						}
						else
						{
							num = 432881216;
							num4 = num;
						}
					}
					continue;
					end_IL_0007:
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
			goto IL_006d;
			IL_0004:
			int num = 1810087482;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x6BE3BE39)
				{
				case 6:
					break;
				case 3:
					throw new ArgumentOutOfRangeException("index");
				case 2:
					goto IL_0044;
				case 4:
					throw new ArgumentOutOfRangeException();
				case 1:
					goto IL_006d;
				case 5:
					Array.Reverse(_items, index, count);
					num = 1810087481;
					continue;
				default:
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					return;
				}
				break;
			}
			goto IL_0004;
			IL_006d:
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			goto IL_0044;
			IL_0044:
			int num2;
			if (_count - index < count)
			{
				num = 1810087485;
				num2 = num;
			}
			else
			{
				num = 1810087484;
				num2 = num;
			}
			goto IL_0009;
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
					IL_006e:
					if (_count - index >= count)
					{
						while (true)
						{
							IL_004b:
							Array.Sort(_items, index, count, comparer);
							wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
							int num = -2051717852;
							while (true)
							{
								switch (num ^ -2051717850)
								{
								case 3:
									num = -2051717849;
									continue;
								default:
									return;
								case 1:
									break;
								case 4:
									goto IL_004b;
								case 0:
									goto IL_006e;
								case 2:
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
					int num = 222245561;
					while (true)
					{
						switch (num ^ 0xD3F32B8)
						{
						case 2:
							break;
						case 1:
							goto IL_003c;
						case 3:
							array = new T[count];
							num = 222245566;
							continue;
						case 0:
							throw new ArgumentOutOfRangeException("count");
						case 7:
							if (_count - index < count)
							{
								throw new ArgumentOutOfRangeException();
							}
							goto case 3;
						case 4:
							goto IL_0091;
						case 5:
							goto end_IL_0007;
						default:
							Array.Copy(_items, index, array, 0, count);
							return new List<T>(array);
						}
						break;
						IL_0091:
						int num2;
						if (count < 0)
						{
							num = 222245560;
							num2 = num;
						}
						else
						{
							num = 222245567;
							num2 = num;
						}
						continue;
						IL_003c:
						int num3;
						if (index >= _count)
						{
							num = 222245565;
							num3 = num;
						}
						else
						{
							num = 222245564;
							num3 = num;
						}
					}
					continue;
					end_IL_0007:
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
				throw new ArgumentNullException("match");
			}
			while (true)
			{
				int num = 0;
				int num2 = -1650082696;
				while (true)
				{
					switch (num2 ^ -1650082695)
					{
					case 0:
						num2 = -1650082693;
						continue;
					case 4:
						if (match(_items[num]))
						{
							return _items[num];
						}
						num++;
						num2 = -1650082694;
						continue;
					case 1:
						num2 = -1650082694;
						continue;
					case 2:
						break;
					default:
						if (num >= _count)
						{
							return default(T);
						}
						goto case 4;
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
			while (true)
			{
				List<T> list = new List<T>();
				int num = 0;
				int num2 = -232121599;
				while (true)
				{
					switch (num2 ^ -232121597)
					{
					case 0:
						num2 = -232121593;
						continue;
					case 1:
						num++;
						num2 = -232121599;
						continue;
					case 2:
					{
						int num3;
						if (num >= _count)
						{
							num2 = -232121594;
							num3 = num2;
						}
						else
						{
							num2 = -232121600;
							num3 = num2;
						}
						continue;
					}
					case 4:
						break;
					case 3:
						if (match(_items[num]))
						{
							list.Add(_items[num]);
							num2 = -232121598;
							continue;
						}
						goto case 1;
					default:
						return list;
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
				goto IL_000c;
			}
			goto IL_00a6;
			IL_000c:
			int num = 580661082;
			goto IL_0011;
			IL_0011:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x229C2F5B)
				{
				case 7:
					break;
				case 6:
					if (match == null)
					{
						throw new ArgumentNullException("match");
					}
					goto case 3;
				case 5:
					goto IL_0056;
				case 0:
					goto IL_0063;
				case 3:
					num3 = startIndex + count;
					num2 = startIndex;
					num = 580661087;
					continue;
				case 1:
					throw new ArgumentNullException("startIndex");
				case 2:
					goto IL_00a6;
				default:
					if (num2 >= num3)
					{
						return -1;
					}
					goto IL_0063;
				}
				break;
				IL_0063:
				if (match(_items[num2]))
				{
					return num2;
				}
				num2++;
				num = 580661087;
			}
			goto IL_000c;
			IL_0056:
			throw new ArgumentOutOfRangeException();
			IL_00a6:
			if (count >= 0)
			{
				int num4;
				if (startIndex > _count - count)
				{
					num = 580661086;
					num4 = num;
				}
				else
				{
					num = 580661085;
					num4 = num;
				}
				goto IL_0011;
			}
			goto IL_0056;
		}

		public T FindLast(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			while (true)
			{
				int num = _count - 1;
				int num2 = -906269023;
				while (true)
				{
					switch (num2 ^ -906269021)
					{
					case 0:
						num2 = -906269024;
						continue;
					case 3:
						break;
					case 1:
						if (match(_items[num]))
						{
							return _items[num];
						}
						num--;
						num2 = -906269023;
						continue;
					default:
						if (num < 0)
						{
							return default(T);
						}
						goto case 1;
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
				throw new ArgumentNullException("match");
			}
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				IL_00e9:
				int num;
				if (_count == 0)
				{
					int num2;
					if (startIndex != -1)
					{
						num = -793868481;
						num2 = num;
					}
					else
					{
						num = -793868493;
						num2 = num;
					}
					goto IL_0016;
				}
				goto IL_0052;
				IL_0016:
				while (true)
				{
					switch (num ^ -793868487)
					{
					case 7:
						num = -793868486;
						continue;
					case 9:
						break;
					case 10:
						if (count >= 0)
						{
							goto IL_0070;
						}
						goto case 4;
					case 5:
						num4 = startIndex - count;
						num = -793868488;
						continue;
					case 8:
						throw new ArgumentOutOfRangeException("startIndex");
					case 4:
						throw new ArgumentOutOfRangeException();
					case 2:
						goto IL_00b9;
					case 1:
						num3 = startIndex;
						num = -793868487;
						continue;
					case 3:
						goto IL_00e9;
					case 6:
						throw new ArgumentOutOfRangeException("startIndex");
					default:
						if (num3 <= num4)
						{
							return -1;
						}
						goto IL_00b9;
					}
					break;
					IL_00b9:
					if (match(_items[num3]))
					{
						return num3;
					}
					num3--;
					num = -793868487;
					continue;
					IL_0070:
					int num5;
					if (startIndex - count + 1 >= 0)
					{
						num = -793868484;
						num5 = num;
					}
					else
					{
						num = -793868483;
						num5 = num;
					}
				}
				goto IL_0052;
				IL_0052:
				int num6;
				if ((uint)startIndex >= (uint)_count)
				{
					num = -793868495;
					num6 = num;
				}
				else
				{
					num = -793868493;
					num6 = num;
				}
				goto IL_0016;
			}
		}

		public void ForEach(Action<T> action)
		{
			if (_count == 0)
			{
				goto IL_0008;
			}
			goto IL_0051;
			IL_0008:
			int num = -1896986458;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1896986462)
				{
				case 5:
					break;
				default:
					return;
				case 4:
					return;
				case 7:
					goto IL_0051;
				case 8:
					num2++;
					num = -1896986460;
					continue;
				case 6:
					goto IL_0071;
				case 3:
					goto IL_008b;
				case 2:
					throw new Exception("List was changed.");
				case 10:
					goto IL_00b1;
				case 0:
					if (num3 == wyCzBtxDiYHWdJxUIaVcrhitjEkf)
					{
						action(_items[num2]);
						num = -1896986454;
						continue;
					}
					goto IL_00b1;
				case 9:
					num2 = 0;
					num = -1896986460;
					continue;
				case 1:
					return;
				}
				break;
				IL_00b1:
				int num4;
				if (num3 == wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					num = -1896986461;
					num4 = num;
				}
				else
				{
					num = -1896986464;
					num4 = num;
				}
				continue;
				IL_0071:
				int num5;
				if (num2 < _count)
				{
					num = -1896986462;
					num5 = num;
				}
				else
				{
					num = -1896986456;
					num5 = num;
				}
			}
			goto IL_0008;
			IL_0051:
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			goto IL_008b;
			IL_008b:
			num3 = wyCzBtxDiYHWdJxUIaVcrhitjEkf;
			num = -1896986453;
			goto IL_000d;
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
					int num = -751587195;
					while (true)
					{
						switch (num ^ -751587194)
						{
						case 0:
							break;
						case 3:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							return LastIndexOf(item, index, index + 1);
						}
						break;
						IL_0026:
						int num2;
						if (index < _count)
						{
							num = -751587193;
							num2 = num;
						}
						else
						{
							num = -751587196;
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
			if (_count != 0)
			{
				goto IL_0008;
			}
			goto IL_0069;
			IL_0008:
			int num = -1055267544;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1055267543)
				{
				case 0:
					break;
				case 1:
					goto IL_003d;
				case 4:
					goto IL_0052;
				case 2:
					goto IL_0069;
				case 7:
					throw new ArgumentOutOfRangeException("index");
				case 6:
					goto IL_009c;
				case 5:
					throw new ArgumentOutOfRangeException();
				default:
					return Array.LastIndexOf(_items, item, index, count);
				}
				break;
				IL_003d:
				int num2;
				if (index < 0)
				{
					num = -1055267538;
					num2 = num;
				}
				else
				{
					num = -1055267541;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_009c:
			if (_count == 0)
			{
				return -1;
			}
			if (index >= _count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			goto IL_0052;
			IL_0052:
			int num3;
			if (count > index + 1)
			{
				num = -1055267540;
				num3 = num;
			}
			else
			{
				num = -1055267542;
				num3 = num;
			}
			goto IL_000d;
			IL_0069:
			if (_count != 0 && count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			goto IL_009c;
		}

		public int RemoveAll(Predicate<T> match)
		{
			if (_count == 0)
			{
				return 0;
			}
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			int result = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 0;
				int num2 = -1931802497;
				while (true)
				{
					switch (num2 ^ -1931802506)
					{
					case 11:
						num2 = -1931802512;
						continue;
					case 12:
						if (num < _count)
						{
							int num6;
							if (match(_items[num]))
							{
								num2 = -1931802498;
								num6 = num2;
							}
							else
							{
								num2 = -1931802501;
								num6 = num2;
							}
							continue;
						}
						goto case 8;
					case 9:
						num2 = -1931802502;
						continue;
					case 13:
						num++;
						num2 = -1931802502;
						continue;
					case 1:
						Array.Clear(_items, num, _count - num);
						result = _count - num;
						_count = num;
						num2 = -1931802507;
						continue;
					case 7:
						num2 = -1931802509;
						continue;
					case 0:
					{
						int num7;
						if (num3 >= _count)
						{
							num2 = -1931802510;
							num7 = num2;
						}
						else
						{
							num2 = -1931802508;
							num7 = num2;
						}
						continue;
					}
					case 2:
					{
						int num5;
						if (!match(_items[num3]))
						{
							num2 = -1931802510;
							num5 = num2;
						}
						else
						{
							num2 = -1931802500;
							num5 = num2;
						}
						continue;
					}
					case 10:
						num3++;
						num2 = -1931802506;
						continue;
					case 5:
					{
						int num4;
						if (num3 >= _count)
						{
							num2 = -1931802505;
							num4 = num2;
						}
						else
						{
							num2 = -1931802506;
							num4 = num2;
						}
						continue;
					}
					case 6:
						break;
					case 8:
						if (num >= _count)
						{
							return 0;
						}
						num3 = num + 1;
						num2 = -1931802511;
						continue;
					case 4:
						if (num3 < _count)
						{
							_items[num++] = _items[num3++];
							num2 = -1931802509;
							continue;
						}
						goto case 5;
					default:
						wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
						return result;
					}
					break;
				}
			}
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
				int num2 = 1252332658;
				while (true)
				{
					switch (num2 ^ 0x4AA51472)
					{
					case 3:
						num2 = 1252332662;
						continue;
					case 0:
					{
						int num3;
						if (num >= _count)
						{
							num2 = 1252332656;
							num3 = num2;
						}
						else
						{
							num2 = 1252332659;
							num3 = num2;
						}
						continue;
					}
					case 1:
						if (!match(_items[num]))
						{
							return false;
						}
						num++;
						num2 = 1252332658;
						continue;
					case 4:
						break;
					default:
						return true;
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
				while (true)
				{
					switch (0x36130C01 ^ 0x36130C00)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentOutOfRangeException();
					}
					break;
				}
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
			while (true)
			{
				int num = -1133822831;
				while (true)
				{
					switch (num ^ -1133822829)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0030;
					case 1:
						return;
					}
					break;
					IL_0030:
					_count = 0;
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					num = -1133822830;
				}
			}
		}

		public void TrimExcess()
		{
			if (!yiNGsSPmOzBjQufduObiVfnlZkU)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (_count != ZQtXcXYFxPSVYxnpniroAAvoIDE)
				{
					num = 1765585038;
					num2 = num;
				}
				else
				{
					num = 1765585037;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x693CB08D)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					case 0:
						return;
					default:
						SSgoHVLKmdbMSiSYImMBoZFCtiP(_count);
						wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
						return;
					}
					break;
					IL_0009:
					num = 1765585036;
				}
			}
		}

		private int SniZSVpzAYoPXCBrNHmVlaTrkAj(int P_0, bool P_1 = false)
		{
			if (!yiNGsSPmOzBjQufduObiVfnlZkU)
			{
				return 0;
			}
			if (ZQtXcXYFxPSVYxnpniroAAvoIDE >= GZHaUyzxjQVgKnQHKqrxfgJnPDy)
			{
				return 0;
			}
			if (UZyNItdYDijdcqeGsgFmlDGQPdp)
			{
				P_0 = KQpoEMvtfaSVAMYrKZZjfhmDHIm(ZQtXcXYFxPSVYxnpniroAAvoIDE, P_0);
				goto IL_0031;
			}
			goto IL_004f;
			IL_004f:
			P_0 = Math.Min(P_0, GZHaUyzxjQVgKnQHKqrxfgJnPDy - ZQtXcXYFxPSVYxnpniroAAvoIDE);
			int num = -1204729038;
			goto IL_0036;
			IL_006b:
			if (P_0 <= 0)
			{
				return 0;
			}
			if (!SSgoHVLKmdbMSiSYImMBoZFCtiP(ZQtXcXYFxPSVYxnpniroAAvoIDE + P_0))
			{
				return 0;
			}
			return P_0;
			IL_0036:
			switch (num ^ -1204729037)
			{
			case 0:
				break;
			case 2:
				goto IL_004f;
			default:
				goto IL_006b;
			}
			goto IL_0031;
			IL_0031:
			num = -1204729039;
			goto IL_0036;
		}

		private int KQpoEMvtfaSVAMYrKZZjfhmDHIm(int P_0, int P_1)
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
				num3 = -1991537594;
				num4 = num3;
			}
			else
			{
				num3 = -1991537596;
				num4 = num3;
			}
			goto IL_000f;
			IL_000a:
			num3 = -1991537595;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num3 ^ -1991537593)
				{
				case 0:
					break;
				case 2:
					goto IL_002c;
				case 1:
					num2 = 2147483647u;
					num3 = -1991537596;
					continue;
				default:
					return (int)num2 - P_0;
				}
				break;
			}
			goto IL_000a;
		}

		private bool SSgoHVLKmdbMSiSYImMBoZFCtiP(int P_0, bool P_1 = false)
		{
			if (P_0 < 0)
			{
				goto IL_0007;
			}
			goto IL_008c;
			IL_0007:
			int num = 337274671;
			goto IL_000c;
			IL_000c:
			T[] array = default(T[]);
			while (true)
			{
				switch (num ^ 0x141A672B)
				{
				case 6:
					break;
				case 4:
					P_0 = 0;
					num = 337274665;
					continue;
				case 0:
					return false;
				case 1:
					if (P_0 != 0)
					{
						Array.Copy(_items, array, Math.Min(P_0, ZQtXcXYFxPSVYxnpniroAAvoIDE));
						num = 337274664;
						continue;
					}
					goto IL_00b0;
				case 2:
					goto IL_008c;
				case 7:
					_items = array;
					num = 337274659;
					continue;
				case 3:
					goto IL_00b0;
				case 5:
					_count = P_0;
					num = 337274668;
					continue;
				default:
					return true;
				}
				break;
				IL_00b0:
				ZQtXcXYFxPSVYxnpniroAAvoIDE = P_0;
				int num2;
				if (_count <= P_0)
				{
					num = 337274668;
					num2 = num;
				}
				else
				{
					num = 337274670;
					num2 = num;
				}
			}
			goto IL_0007;
			IL_008c:
			if (P_0 <= GZHaUyzxjQVgKnQHKqrxfgJnPDy)
			{
				if (P_0 == ZQtXcXYFxPSVYxnpniroAAvoIDE)
				{
					return true;
				}
				if (P_1)
				{
					return true;
				}
				array = new T[P_0];
				num = 337274666;
			}
			else
			{
				num = 337274667;
			}
			goto IL_000c;
		}

		void IList<T>.Insert(int index, T item)
		{
			Insert(index, item);
		}

		void ICollection<T>.Add(T item)
		{
			if (Add(item) >= 0)
			{
				return;
			}
			while (true)
			{
				switch (-1840940627 ^ -1840940625)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					throw new Exception("List has no more space. Cannot add item.");
				case 1:
					return;
				}
			}
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			if (array != null && array.Rank != 1)
			{
				while (true)
				{
					switch (-1155361337 ^ -1155361338)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentException("Multi-dimensional arrays are not supported.");
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
			return new gAJClBheeuqAESMTRycXWpealIw(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new gAJClBheeuqAESMTRycXWpealIw(this);
		}

		int IList.Add(object value)
		{
			if (!ioRSOGmOmZQLbrcHvdUuCjsSYByk(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return Add((T)value);
		}

		bool IList.Contains(object value)
		{
			if (!ioRSOGmOmZQLbrcHvdUuCjsSYByk(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return Contains((T)value);
		}

		int IList.IndexOf(object value)
		{
			if (!ioRSOGmOmZQLbrcHvdUuCjsSYByk(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			return IndexOf((T)value);
		}

		void IList.Insert(int index, object value)
		{
			if (!ioRSOGmOmZQLbrcHvdUuCjsSYByk(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			while (true)
			{
				Insert(index, (T)value);
				int num = -1920609663;
				while (true)
				{
					switch (num ^ -1920609661)
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
					num = -1920609662;
				}
			}
		}

		void IList.Remove(object value)
		{
			if (!ioRSOGmOmZQLbrcHvdUuCjsSYByk(value))
			{
				while (true)
				{
					switch (0x395C42C1 ^ 0x395C42C0)
					{
					case 0:
						continue;
					case 1:
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

		private static bool ioRSOGmOmZQLbrcHvdUuCjsSYByk(object P_0)
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
