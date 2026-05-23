using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class RingBuffer<T> : IEnumerable, IEnumerable<T>, ICollection<T>
	{
		[Serializable]
		public struct vLOgAlXExYFHaIHfGajhRGVzaaOK : IDisposable, IEnumerator, IEnumerator<T>
		{
			private RingBuffer<T> buffer;

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
						if (index != buffer.oCjExPQBVRiArAcbiSwTmwqUBqb + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-147676209 ^ -147676210)
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

			internal vLOgAlXExYFHaIHfGajhRGVzaaOK(RingBuffer<T> buffer)
			{
				this.buffer = buffer;
				index = 0;
				version = buffer.wyCzBtxDiYHWdJxUIaVcrhitjEkf;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					while (true)
					{
						int num = -871267137;
						while (true)
						{
							switch (num ^ -871267138)
							{
							case 2:
								break;
							case 1:
								goto IL_0035;
							case 3:
								current = buffer[index];
								index++;
								num = -871267138;
								continue;
							default:
								return true;
							}
							break;
							IL_0035:
							if ((uint)index >= (uint)buffer.oCjExPQBVRiArAcbiSwTmwqUBqb)
							{
								goto end_IL_0013;
							}
							num = -871267139;
						}
						continue;
						end_IL_0013:
						break;
					}
				}
				return qfQPaojlFYFdGHCplpjqNGLqLCW();
			}

			private bool qfQPaojlFYFdGHCplpjqNGLqLCW()
			{
				if (version != buffer.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				while (true)
				{
					index = buffer.oCjExPQBVRiArAcbiSwTmwqUBqb + 1;
					current = default(T);
					int num = 2012804648;
					while (true)
					{
						switch (num ^ 0x77F8F62A)
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
						num = 2012804651;
					}
				}
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.wyCzBtxDiYHWdJxUIaVcrhitjEkf)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				while (true)
				{
					index = 0;
					current = default(T);
					int num = 1422994501;
					while (true)
					{
						switch (num ^ 0x54D12C45)
						{
						case 2:
							goto IL_001e;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_001e:
						num = 1422994500;
					}
				}
			}
		}

		private readonly T[] OPGUsxlGRmeLIOrmlCnDPuPpZwB;

		private readonly int ZQtXcXYFxPSVYxnpniroAAvoIDE;

		private int XdTRdkKEjodcNcozqGfjhByfKiF;

		private int tfEGuXWeUmsImwNARIOROlVwzxT;

		private int oCjExPQBVRiArAcbiSwTmwqUBqb;

		private int CfndLQKZLfKToLgDDWkALQRdHjD;

		private int wyCzBtxDiYHWdJxUIaVcrhitjEkf;

		private IEqualityComparer<T> TlxZdrFpPRDnfquVHbnQJocwbYh = EqualityComparerNoAlloc<T>.Default;

		public int Count
		{
			get
			{
				return oCjExPQBVRiArAcbiSwTmwqUBqb;
			}
		}

		public int Capacity
		{
			get
			{
				return ZQtXcXYFxPSVYxnpniroAAvoIDE;
			}
		}

		public int OverrunCount
		{
			get
			{
				return CfndLQKZLfKToLgDDWkALQRdHjD;
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
					while (true)
					{
						int num = -697203520;
						while (true)
						{
							switch (num ^ -697203518)
							{
							case 0:
								break;
							case 2:
								value = EqualityComparerNoAlloc<T>.Default;
								num = -697203517;
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
				TlxZdrFpPRDnfquVHbnQJocwbYh = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = wFVcLidWOZbqTYylXfRkrAmaiDo(index);
				if (!OAAEipODXfLJVSvQHoqXlUooanN(num))
				{
					while (true)
					{
						switch (-1836960816 ^ -1836960814)
						{
						case 0:
							continue;
						case 2:
							throw new IndexOutOfRangeException();
						}
						break;
					}
				}
				return OPGUsxlGRmeLIOrmlCnDPuPpZwB[num];
			}
			set
			{
				int num = wFVcLidWOZbqTYylXfRkrAmaiDo(index);
				if (!OAAEipODXfLJVSvQHoqXlUooanN(num))
				{
					while (true)
					{
						switch (0x2D71BCDA ^ 0x2D71BCDB)
						{
						case 2:
							continue;
						case 1:
							throw new IndexOutOfRangeException();
						}
						break;
					}
				}
				OPGUsxlGRmeLIOrmlCnDPuPpZwB[num] = value;
			}
		}

		int ICollection<T>.Count
		{
			get
			{
				return Count;
			}
		}

		bool ICollection<T>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public RingBuffer(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("capacity must be > 0.");
			}
			OPGUsxlGRmeLIOrmlCnDPuPpZwB = new T[capacity];
			ZQtXcXYFxPSVYxnpniroAAvoIDE = capacity;
			Clear();
		}

		public void Enqueue(T item)
		{
			XdTRdkKEjodcNcozqGfjhByfKiF = ((XdTRdkKEjodcNcozqGfjhByfKiF < ZQtXcXYFxPSVYxnpniroAAvoIDE - 1) ? (XdTRdkKEjodcNcozqGfjhByfKiF + 1) : 0);
			if (oCjExPQBVRiArAcbiSwTmwqUBqb == 0)
			{
				goto IL_0029;
			}
			goto IL_0090;
			IL_0090:
			int num;
			int num2;
			if (XdTRdkKEjodcNcozqGfjhByfKiF == tfEGuXWeUmsImwNARIOROlVwzxT)
			{
				num = 1206198338;
				num2 = num;
			}
			else
			{
				num = 1206198337;
				num2 = num;
			}
			goto IL_002e;
			IL_002e:
			while (true)
			{
				switch (num ^ 0x47E52041)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					tfEGuXWeUmsImwNARIOROlVwzxT = ((tfEGuXWeUmsImwNARIOROlVwzxT < ZQtXcXYFxPSVYxnpniroAAvoIDE - 1) ? (tfEGuXWeUmsImwNARIOROlVwzxT + 1) : 0);
					CfndLQKZLfKToLgDDWkALQRdHjD++;
					num = 1206198337;
					continue;
				case 4:
					goto IL_0090;
				case 0:
					OPGUsxlGRmeLIOrmlCnDPuPpZwB[XdTRdkKEjodcNcozqGfjhByfKiF] = item;
					num = 1206198343;
					continue;
				case 6:
					if (oCjExPQBVRiArAcbiSwTmwqUBqb < ZQtXcXYFxPSVYxnpniroAAvoIDE)
					{
						oCjExPQBVRiArAcbiSwTmwqUBqb++;
						num = 1206198340;
						continue;
					}
					return;
				case 1:
					tfEGuXWeUmsImwNARIOROlVwzxT = 0;
					num = 1206198337;
					continue;
				case 5:
					return;
				}
				break;
			}
			goto IL_0029;
			IL_0029:
			num = 1206198336;
			goto IL_002e;
		}

		public bool EnqueueIfUnique(T item)
		{
			if (Contains(item))
			{
				goto IL_0009;
			}
			Enqueue(item);
			int num = 77380821;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x49CBCD5)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0009;
			IL_0009:
			num = 77380820;
			goto IL_000e;
		}

		public T Dequeue()
		{
			if (oCjExPQBVRiArAcbiSwTmwqUBqb == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			while (true)
			{
				T result = OPGUsxlGRmeLIOrmlCnDPuPpZwB[tfEGuXWeUmsImwNARIOROlVwzxT];
				int num;
				if (tfEGuXWeUmsImwNARIOROlVwzxT == XdTRdkKEjodcNcozqGfjhByfKiF)
				{
					Clear();
					num = 2086070682;
					goto IL_0018;
				}
				goto IL_0065;
				IL_0018:
				while (true)
				{
					switch (num ^ 0x7C56E999)
					{
					case 2:
						num = 2086070680;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0065;
					default:
						return result;
					}
					break;
				}
				continue;
				IL_0065:
				OPGUsxlGRmeLIOrmlCnDPuPpZwB[tfEGuXWeUmsImwNARIOROlVwzxT] = default(T);
				tfEGuXWeUmsImwNARIOROlVwzxT = ((tfEGuXWeUmsImwNARIOROlVwzxT < ZQtXcXYFxPSVYxnpniroAAvoIDE - 1) ? (tfEGuXWeUmsImwNARIOROlVwzxT + 1) : 0);
				CfndLQKZLfKToLgDDWkALQRdHjD = 0;
				oCjExPQBVRiArAcbiSwTmwqUBqb--;
				wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
				num = 2086070682;
				goto IL_0018;
			}
		}

		public T Peek()
		{
			if (XdTRdkKEjodcNcozqGfjhByfKiF < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return OPGUsxlGRmeLIOrmlCnDPuPpZwB[tfEGuXWeUmsImwNARIOROlVwzxT];
		}

		public bool Contains(T item)
		{
			return cEgiArijJRiBqzUFIvBJGMcndbO(item, TlxZdrFpPRDnfquVHbnQJocwbYh) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return cEgiArijJRiBqzUFIvBJGMcndbO(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, TlxZdrFpPRDnfquVHbnQJocwbYh);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return lNjUxaZBUbYrAuPzLyzOCQhcpOG(cEgiArijJRiBqzUFIvBJGMcndbO(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, TlxZdrFpPRDnfquVHbnQJocwbYh);
		}

		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				goto IL_0003;
			}
			goto IL_0037;
			IL_0003:
			int num = 1911531736;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x71EFA8DB)
			{
			case 0:
				break;
			case 3:
				throw new ArgumentNullException("comparer");
			case 1:
				goto IL_0037;
			default:
				return false;
			}
			goto IL_0003;
			IL_0037:
			if (Count == 0)
			{
				return false;
			}
			int num2 = cEgiArijJRiBqzUFIvBJGMcndbO(item, comparer);
			if (num2 < 0)
			{
				num = 1911531737;
				goto IL_0008;
			}
			WsIuSULGNaERtSyIPdmzZbiuUIX(num2);
			return true;
		}

		public void RemoveAt(int index)
		{
			WsIuSULGNaERtSyIPdmzZbiuUIX(wFVcLidWOZbqTYylXfRkrAmaiDo(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, TlxZdrFpPRDnfquVHbnQJocwbYh);
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				goto IL_0003;
			}
			goto IL_004f;
			IL_0003:
			int num = -1849856727;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1849856724)
				{
				case 2:
					break;
				case 3:
					if (comparer.Equals(this[num2], item))
					{
						RemoveAt(num2);
						num3++;
						num = -1849856723;
						continue;
					}
					goto case 1;
				case 0:
					goto IL_004f;
				case 1:
					num2--;
					num = -1849856728;
					continue;
				case 5:
					throw new ArgumentNullException("comparer");
				default:
					if (num2 < 0)
					{
						return num3;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0003;
			IL_004f:
			num3 = 0;
			int count = Count;
			num2 = count - 1;
			num = -1849856728;
			goto IL_0008;
		}

		public void Clear()
		{
			if (oCjExPQBVRiArAcbiSwTmwqUBqb > 0)
			{
				goto IL_0009;
			}
			goto IL_003a;
			IL_0009:
			int num = 88850384;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x54BBFD1)
				{
				case 0:
					break;
				case 3:
					goto IL_003a;
				case 2:
					num = 88850391;
					continue;
				case 1:
					if (XdTRdkKEjodcNcozqGfjhByfKiF >= tfEGuXWeUmsImwNARIOROlVwzxT)
					{
						Array.Clear(OPGUsxlGRmeLIOrmlCnDPuPpZwB, tfEGuXWeUmsImwNARIOROlVwzxT, XdTRdkKEjodcNcozqGfjhByfKiF - tfEGuXWeUmsImwNARIOROlVwzxT + 1);
						num = 88850387;
						continue;
					}
					goto case 4;
				case 6:
					oCjExPQBVRiArAcbiSwTmwqUBqb = 0;
					num = 88850386;
					continue;
				case 4:
					Array.Clear(OPGUsxlGRmeLIOrmlCnDPuPpZwB, 0, XdTRdkKEjodcNcozqGfjhByfKiF + 1);
					Array.Clear(OPGUsxlGRmeLIOrmlCnDPuPpZwB, tfEGuXWeUmsImwNARIOROlVwzxT, ZQtXcXYFxPSVYxnpniroAAvoIDE - tfEGuXWeUmsImwNARIOROlVwzxT);
					num = 88850391;
					continue;
				default:
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					return;
				}
				break;
			}
			goto IL_0009;
			IL_003a:
			XdTRdkKEjodcNcozqGfjhByfKiF = -1;
			tfEGuXWeUmsImwNARIOROlVwzxT = -1;
			CfndLQKZLfKToLgDDWkALQRdHjD = 0;
			num = 88850388;
			goto IL_000e;
		}

		private int cEgiArijJRiBqzUFIvBJGMcndbO(T P_0)
		{
			return cEgiArijJRiBqzUFIvBJGMcndbO(P_0, TlxZdrFpPRDnfquVHbnQJocwbYh);
		}

		private int cEgiArijJRiBqzUFIvBJGMcndbO(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			int num = default(int);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num2;
				if (oCjExPQBVRiArAcbiSwTmwqUBqb != 0)
				{
					if (XdTRdkKEjodcNcozqGfjhByfKiF < tfEGuXWeUmsImwNARIOROlVwzxT)
					{
						goto IL_0168;
					}
					num = tfEGuXWeUmsImwNARIOROlVwzxT;
					num2 = 1123748730;
				}
				else
				{
					num2 = 1123748728;
				}
				goto IL_0016;
				IL_0016:
				while (true)
				{
					switch (num2 ^ 0x42FB0B7E)
					{
					case 7:
						num2 = 1123748731;
						continue;
					case 13:
						break;
					case 1:
						return num3;
					case 6:
						return -1;
					case 12:
						goto IL_00a9;
					case 2:
						num2 = 1123748723;
						continue;
					case 3:
						return num;
					case 5:
						goto end_IL_0016;
					case 4:
						if (num > XdTRdkKEjodcNcozqGfjhByfKiF)
						{
							num2 = 1123748727;
							continue;
						}
						goto IL_012c;
					case 8:
						goto IL_0107;
					case 11:
						goto IL_012c;
					case 0:
						if (num3 > XdTRdkKEjodcNcozqGfjhByfKiF)
						{
							num4 = tfEGuXWeUmsImwNARIOROlVwzxT;
							num2 = 1123748732;
							continue;
						}
						goto IL_00a9;
					case 10:
						goto IL_0168;
					default:
						return -1;
					}
					int num5;
					if (num4 < ZQtXcXYFxPSVYxnpniroAAvoIDE)
					{
						num2 = 1123748726;
						num5 = num2;
					}
					else
					{
						num2 = 1123748727;
						num5 = num2;
					}
					continue;
					IL_0107:
					if (P_1.Equals(OPGUsxlGRmeLIOrmlCnDPuPpZwB[num4], P_0))
					{
						return num4;
					}
					num4++;
					num2 = 1123748723;
					continue;
					IL_00a9:
					if (!P_1.Equals(OPGUsxlGRmeLIOrmlCnDPuPpZwB[num3], P_0))
					{
						num3++;
						num2 = 1123748734;
					}
					else
					{
						num2 = 1123748735;
					}
					continue;
					IL_012c:
					if (!P_1.Equals(OPGUsxlGRmeLIOrmlCnDPuPpZwB[num], P_0))
					{
						num++;
						num2 = 1123748730;
					}
					else
					{
						num2 = 1123748733;
					}
					continue;
					end_IL_0016:
					break;
				}
				continue;
				IL_0168:
				num3 = 0;
				num2 = 1123748734;
				goto IL_0016;
			}
		}

		private void WsIuSULGNaERtSyIPdmzZbiuUIX(int P_0)
		{
			if (!OAAEipODXfLJVSvQHoqXlUooanN(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			while (P_0 != tfEGuXWeUmsImwNARIOROlVwzxT)
			{
				while (true)
				{
					IL_007b:
					int num;
					if (P_0 != XdTRdkKEjodcNcozqGfjhByfKiF)
					{
						if (XdTRdkKEjodcNcozqGfjhByfKiF > tfEGuXWeUmsImwNARIOROlVwzxT)
						{
							Array.Copy(OPGUsxlGRmeLIOrmlCnDPuPpZwB, P_0 + 1, OPGUsxlGRmeLIOrmlCnDPuPpZwB, P_0, XdTRdkKEjodcNcozqGfjhByfKiF - P_0);
							num = 1624127429;
							goto IL_0017;
						}
						goto IL_004b;
					}
					goto IL_0148;
					IL_00de:
					Array.Copy(OPGUsxlGRmeLIOrmlCnDPuPpZwB, P_0 + 1, OPGUsxlGRmeLIOrmlCnDPuPpZwB, P_0, ZQtXcXYFxPSVYxnpniroAAvoIDE - P_0 - 1);
					OPGUsxlGRmeLIOrmlCnDPuPpZwB[ZQtXcXYFxPSVYxnpniroAAvoIDE - 1] = OPGUsxlGRmeLIOrmlCnDPuPpZwB[0];
					if (XdTRdkKEjodcNcozqGfjhByfKiF > 0)
					{
						Array.Copy(OPGUsxlGRmeLIOrmlCnDPuPpZwB, 1, OPGUsxlGRmeLIOrmlCnDPuPpZwB, 0, XdTRdkKEjodcNcozqGfjhByfKiF);
						num = 1624127425;
						goto IL_0017;
					}
					goto IL_0148;
					IL_0017:
					while (true)
					{
						switch (num ^ 0x60CE37C6)
						{
						case 2:
							num = 1624127427;
							continue;
						default:
							return;
						case 1:
							break;
						case 6:
							goto IL_007b;
						case 3:
							num = 1624127425;
							continue;
						case 0:
							oCjExPQBVRiArAcbiSwTmwqUBqb--;
							num = 1624127426;
							continue;
						case 8:
							goto IL_00de;
						case 7:
							goto IL_0148;
						case 5:
							goto end_IL_007b;
						case 4:
							return;
						}
						break;
					}
					goto IL_004b;
					IL_0148:
					OPGUsxlGRmeLIOrmlCnDPuPpZwB[XdTRdkKEjodcNcozqGfjhByfKiF] = default(T);
					XdTRdkKEjodcNcozqGfjhByfKiF = ((XdTRdkKEjodcNcozqGfjhByfKiF > 0) ? (XdTRdkKEjodcNcozqGfjhByfKiF - 1) : (ZQtXcXYFxPSVYxnpniroAAvoIDE - 1));
					wyCzBtxDiYHWdJxUIaVcrhitjEkf++;
					num = 1624127430;
					goto IL_0017;
					IL_004b:
					if (P_0 < XdTRdkKEjodcNcozqGfjhByfKiF)
					{
						Array.Copy(OPGUsxlGRmeLIOrmlCnDPuPpZwB, P_0 + 1, OPGUsxlGRmeLIOrmlCnDPuPpZwB, P_0, XdTRdkKEjodcNcozqGfjhByfKiF - P_0);
						num = 1624127425;
						goto IL_0017;
					}
					goto IL_00de;
					continue;
					end_IL_007b:
					break;
				}
			}
			Dequeue();
		}

		private bool OAAEipODXfLJVSvQHoqXlUooanN(int P_0)
		{
			if (oCjExPQBVRiArAcbiSwTmwqUBqb == 0)
			{
				return false;
			}
			if (XdTRdkKEjodcNcozqGfjhByfKiF >= tfEGuXWeUmsImwNARIOROlVwzxT)
			{
				if (P_0 < tfEGuXWeUmsImwNARIOROlVwzxT)
				{
					return false;
				}
				goto IL_0021;
			}
			int num;
			if (P_0 < tfEGuXWeUmsImwNARIOROlVwzxT)
			{
				num = -347111986;
				goto IL_0026;
			}
			return true;
			IL_0026:
			switch (num ^ -347111988)
			{
			case 0:
				break;
			case 1:
				return P_0 <= XdTRdkKEjodcNcozqGfjhByfKiF;
			default:
				return P_0 <= XdTRdkKEjodcNcozqGfjhByfKiF;
			}
			goto IL_0021;
			IL_0021:
			num = -347111987;
			goto IL_0026;
		}

		private int lNjUxaZBUbYrAuPzLyzOCQhcpOG(int P_0)
		{
			if ((uint)P_0 >= (uint)ZQtXcXYFxPSVYxnpniroAAvoIDE)
			{
				goto IL_0009;
			}
			if (!OAAEipODXfLJVSvQHoqXlUooanN(P_0))
			{
				return -1;
			}
			int num;
			if (P_0 >= tfEGuXWeUmsImwNARIOROlVwzxT)
			{
				num = 1502884612;
				goto IL_000e;
			}
			return P_0 + ZQtXcXYFxPSVYxnpniroAAvoIDE - tfEGuXWeUmsImwNARIOROlVwzxT;
			IL_000e:
			switch (num ^ 0x59943304)
			{
			case 2:
				break;
			case 1:
				return -1;
			default:
				return P_0 - tfEGuXWeUmsImwNARIOROlVwzxT;
			}
			goto IL_0009;
			IL_0009:
			num = 1502884613;
			goto IL_000e;
		}

		private int wFVcLidWOZbqTYylXfRkrAmaiDo(int P_0)
		{
			if ((uint)P_0 >= (uint)oCjExPQBVRiArAcbiSwTmwqUBqb)
			{
				return -1;
			}
			P_0 = tfEGuXWeUmsImwNARIOROlVwzxT + P_0;
			if (P_0 >= ZQtXcXYFxPSVYxnpniroAAvoIDE)
			{
				P_0 -= ZQtXcXYFxPSVYxnpniroAAvoIDE;
			}
			return P_0;
		}

		void ICollection<T>.Add(T item)
		{
			Enqueue(item);
		}

		void ICollection<T>.Clear()
		{
			Clear();
		}

		bool ICollection<T>.Contains(T item)
		{
			return Contains(item);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int count = default(int);
			int num3 = default(int);
			while (arrayIndex >= 0)
			{
				int num;
				int num2;
				if (arrayIndex + Count <= array.Length)
				{
					num = 1060257729;
					num2 = num;
				}
				else
				{
					num = 1060257728;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x3F323FC1)
					{
					case 3:
						num = 1060257733;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
						goto end_IL_0063;
					case 4:
						goto end_IL_0013;
					case 0:
						count = Count;
						num3 = 0;
						num = 1060257731;
						continue;
					case 5:
						array[arrayIndex + num3] = this[num3];
						num3++;
						num = 1060257731;
						continue;
					case 6:
						return;
					}
					int num4;
					if (num3 >= count)
					{
						num = 1060257735;
						num4 = num;
					}
					else
					{
						num = 1060257732;
						num4 = num;
					}
					continue;
					end_IL_0013:
					break;
				}
				continue;
				end_IL_0063:
				break;
			}
			throw new ArgumentException("array is too small to hold the collection.");
		}

		bool ICollection<T>.Remove(T item)
		{
			return Remove(item);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new vLOgAlXExYFHaIHfGajhRGVzaaOK(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new vLOgAlXExYFHaIHfGajhRGVzaaOK(this);
		}
	}
}
