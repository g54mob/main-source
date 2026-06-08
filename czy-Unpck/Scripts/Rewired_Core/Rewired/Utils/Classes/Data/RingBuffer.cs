using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class RingBuffer<T> : IEnumerable, IEnumerable<T>, ICollection<T>
	{
		[Serializable]
		public struct fZIPOxHPWQmnOBnJpAQeeNpyvug : IDisposable, IEnumerator, IEnumerator<T>
		{
			private RingBuffer<T> buffer;

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
						if (index != buffer.ierooXELkRVWTXdTXUdETEGRnJZ + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-349611950 ^ -349611949)
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

			internal fZIPOxHPWQmnOBnJpAQeeNpyvug(RingBuffer<T> buffer)
			{
				this.buffer = buffer;
				index = 0;
				version = buffer.yBIrBfrsPGDuPEQynAujInSmPSQ;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.yBIrBfrsPGDuPEQynAujInSmPSQ && (uint)index < (uint)buffer.ierooXELkRVWTXdTXUdETEGRnJZ)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return yvABzeFvWOJtqQWcWLMbrirrrJww();
			}

			private bool yvABzeFvWOJtqQWcWLMbrirrrJww()
			{
				if (version != buffer.yBIrBfrsPGDuPEQynAujInSmPSQ)
				{
					while (true)
					{
						switch (-810372527 ^ -810372525)
						{
						case 0:
							continue;
						case 2:
							throw new InvalidOperationException("RingBuffer was changed.");
						}
						break;
					}
				}
				index = buffer.ierooXELkRVWTXdTXUdETEGRnJZ + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.yBIrBfrsPGDuPEQynAujInSmPSQ)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				while (true)
				{
					index = 0;
					current = default(T);
					int num = 1544341817;
					while (true)
					{
						switch (num ^ 0x5C0CC939)
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
						num = 1544341816;
					}
				}
			}
		}

		private readonly T[] CIKxyjrGfgKEkXTLUGlIceCoGTde;

		private readonly int ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		private int LeXTtwSPAiqEzzeBJvSmCKWwfal;

		private int bFOMkNWfbeGsYnEuitxGnRdnUfb;

		private int ierooXELkRVWTXdTXUdETEGRnJZ;

		private int GufkhYGXyngdUIkfyIBVfcxcIlfa;

		private int yBIrBfrsPGDuPEQynAujInSmPSQ;

		private IEqualityComparer<T> FlXVnkZaRfLVoztinCFFyMxcEJB = EqualityComparerNoAlloc<T>.Default;

		public int Count => ierooXELkRVWTXdTXUdETEGRnJZ;

		public int Capacity => ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		public int OverrunCount => GufkhYGXyngdUIkfyIBVfcxcIlfa;

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

		public T this[int index]
		{
			get
			{
				int num = gVRkhurutTdGjDuHaIVdMHQdAVG(index);
				if (!QeUQkxQowbMhzHLigRRQWNIlhkn(num))
				{
					while (true)
					{
						switch (0x5FB4135D ^ 0x5FB4135C)
						{
						case 0:
							continue;
						case 1:
							throw new IndexOutOfRangeException();
						}
						break;
					}
				}
				return CIKxyjrGfgKEkXTLUGlIceCoGTde[num];
			}
			set
			{
				int num = gVRkhurutTdGjDuHaIVdMHQdAVG(index);
				if (!QeUQkxQowbMhzHLigRRQWNIlhkn(num))
				{
					while (true)
					{
						switch (-1052969968 ^ -1052969967)
						{
						case 0:
							continue;
						case 1:
							throw new IndexOutOfRangeException();
						}
						break;
					}
				}
				CIKxyjrGfgKEkXTLUGlIceCoGTde[num] = value;
			}
		}

		int ICollection<T>.Count => Count;

		bool ICollection<T>.IsReadOnly => false;

		public RingBuffer(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("capacity must be > 0.");
			}
			CIKxyjrGfgKEkXTLUGlIceCoGTde = new T[capacity];
			ToxWVXQQLPxjuaFqOGCzdiVpFIc = capacity;
			Clear();
		}

		public void Enqueue(T item)
		{
			LeXTtwSPAiqEzzeBJvSmCKWwfal = ((LeXTtwSPAiqEzzeBJvSmCKWwfal < ToxWVXQQLPxjuaFqOGCzdiVpFIc - 1) ? (LeXTtwSPAiqEzzeBJvSmCKWwfal + 1) : 0);
			while (true)
			{
				int num = 2079522705;
				while (true)
				{
					switch (num ^ 0x7BF2FF90)
					{
					case 4:
						break;
					default:
						return;
					case 7:
						bFOMkNWfbeGsYnEuitxGnRdnUfb = ((bFOMkNWfbeGsYnEuitxGnRdnUfb < ToxWVXQQLPxjuaFqOGCzdiVpFIc - 1) ? (bFOMkNWfbeGsYnEuitxGnRdnUfb + 1) : 0);
						num = 2079522704;
						continue;
					case 6:
					{
						CIKxyjrGfgKEkXTLUGlIceCoGTde[LeXTtwSPAiqEzzeBJvSmCKWwfal] = item;
						int num4;
						if (ierooXELkRVWTXdTXUdETEGRnJZ < ToxWVXQQLPxjuaFqOGCzdiVpFIc)
						{
							num = 2079522707;
							num4 = num;
						}
						else
						{
							num = 2079522712;
							num4 = num;
						}
						continue;
					}
					case 0:
						GufkhYGXyngdUIkfyIBVfcxcIlfa++;
						num = 2079522710;
						continue;
					case 5:
					{
						int num3;
						if (LeXTtwSPAiqEzzeBJvSmCKWwfal != bFOMkNWfbeGsYnEuitxGnRdnUfb)
						{
							num = 2079522710;
							num3 = num;
						}
						else
						{
							num = 2079522711;
							num3 = num;
						}
						continue;
					}
					case 1:
					{
						int num2;
						if (ierooXELkRVWTXdTXUdETEGRnJZ != 0)
						{
							num = 2079522709;
							num2 = num;
						}
						else
						{
							num = 2079522706;
							num2 = num;
						}
						continue;
					}
					case 3:
						ierooXELkRVWTXdTXUdETEGRnJZ++;
						num = 2079522712;
						continue;
					case 2:
						bFOMkNWfbeGsYnEuitxGnRdnUfb = 0;
						num = 2079522710;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		public bool EnqueueIfUnique(T item)
		{
			if (Contains(item))
			{
				return false;
			}
			Enqueue(item);
			return true;
		}

		public T Dequeue()
		{
			if (ierooXELkRVWTXdTXUdETEGRnJZ == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			while (true)
			{
				T result = CIKxyjrGfgKEkXTLUGlIceCoGTde[bFOMkNWfbeGsYnEuitxGnRdnUfb];
				int num;
				int num2;
				if (bFOMkNWfbeGsYnEuitxGnRdnUfb == LeXTtwSPAiqEzzeBJvSmCKWwfal)
				{
					num = 1139867190;
					num2 = num;
				}
				else
				{
					num = 1139867188;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x43F0FE35)
					{
					case 0:
						num = 1139867191;
						continue;
					case 2:
						break;
					case 3:
						Clear();
						num = 1139867185;
						continue;
					case 1:
						CIKxyjrGfgKEkXTLUGlIceCoGTde[bFOMkNWfbeGsYnEuitxGnRdnUfb] = default(T);
						bFOMkNWfbeGsYnEuitxGnRdnUfb = ((bFOMkNWfbeGsYnEuitxGnRdnUfb < ToxWVXQQLPxjuaFqOGCzdiVpFIc - 1) ? (bFOMkNWfbeGsYnEuitxGnRdnUfb + 1) : 0);
						GufkhYGXyngdUIkfyIBVfcxcIlfa = 0;
						ierooXELkRVWTXdTXUdETEGRnJZ--;
						yBIrBfrsPGDuPEQynAujInSmPSQ++;
						num = 1139867185;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		public T Peek()
		{
			if (LeXTtwSPAiqEzzeBJvSmCKWwfal < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return CIKxyjrGfgKEkXTLUGlIceCoGTde[bFOMkNWfbeGsYnEuitxGnRdnUfb];
		}

		public bool Contains(T item)
		{
			return afeqLlcZqNvkOmtnzqHCjiYuiji(item, FlXVnkZaRfLVoztinCFFyMxcEJB) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return afeqLlcZqNvkOmtnzqHCjiYuiji(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return jylLuwFjibLpgxXDgOnZhVahSuo(afeqLlcZqNvkOmtnzqHCjiYuiji(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			while (Count != 0)
			{
				int num = afeqLlcZqNvkOmtnzqHCjiYuiji(item, comparer);
				int num2 = 818228232;
				while (true)
				{
					switch (num2 ^ 0x30C52C08)
					{
					case 2:
						num2 = 818228235;
						continue;
					case 3:
						break;
					case 0:
						if (num < 0)
						{
							num2 = 818228233;
							continue;
						}
						YRKjIYZqcigfZANwqxZmoRAtcSnE(num);
						return true;
					default:
						return false;
					}
					break;
				}
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			YRKjIYZqcigfZANwqxZmoRAtcSnE(gVRkhurutTdGjDuHaIVdMHQdAVG(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			int num3 = default(int);
			while (true)
			{
				int num = 0;
				int count = Count;
				int num2 = -301950780;
				while (true)
				{
					switch (num2 ^ -301950778)
					{
					case 5:
						num2 = -301950777;
						continue;
					case 7:
						num2 = -301950784;
						continue;
					case 2:
						num3 = count - 1;
						num2 = -301950783;
						continue;
					case 1:
						break;
					case 4:
						num++;
						num2 = -301950779;
						continue;
					case 0:
						if (comparer.Equals(this[num3], item))
						{
							RemoveAt(num3);
							num2 = -301950782;
							continue;
						}
						goto case 3;
					case 3:
						num3--;
						num2 = -301950784;
						continue;
					default:
						if (num3 < 0)
						{
							return num;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public void Clear()
		{
			if (ierooXELkRVWTXdTXUdETEGRnJZ <= 0)
			{
				goto IL_0055;
			}
			if (LeXTtwSPAiqEzzeBJvSmCKWwfal >= bFOMkNWfbeGsYnEuitxGnRdnUfb)
			{
				goto IL_001a;
			}
			goto IL_00a9;
			IL_00a9:
			Array.Clear(CIKxyjrGfgKEkXTLUGlIceCoGTde, 0, LeXTtwSPAiqEzzeBJvSmCKWwfal + 1);
			Array.Clear(CIKxyjrGfgKEkXTLUGlIceCoGTde, bFOMkNWfbeGsYnEuitxGnRdnUfb, ToxWVXQQLPxjuaFqOGCzdiVpFIc - bFOMkNWfbeGsYnEuitxGnRdnUfb);
			int num = 376596460;
			goto IL_001f;
			IL_001a:
			num = 376596458;
			goto IL_001f;
			IL_001f:
			while (true)
			{
				switch (num ^ 0x167267E9)
				{
				case 0:
					break;
				default:
					return;
				case 5:
					ierooXELkRVWTXdTXUdETEGRnJZ = 0;
					num = 376596456;
					continue;
				case 1:
					goto IL_0055;
				case 3:
					Array.Clear(CIKxyjrGfgKEkXTLUGlIceCoGTde, bFOMkNWfbeGsYnEuitxGnRdnUfb, LeXTtwSPAiqEzzeBJvSmCKWwfal - bFOMkNWfbeGsYnEuitxGnRdnUfb + 1);
					num = 376596460;
					continue;
				case 4:
					goto IL_00a9;
				case 2:
					return;
				}
				break;
			}
			goto IL_001a;
			IL_0055:
			LeXTtwSPAiqEzzeBJvSmCKWwfal = -1;
			bFOMkNWfbeGsYnEuitxGnRdnUfb = -1;
			GufkhYGXyngdUIkfyIBVfcxcIlfa = 0;
			yBIrBfrsPGDuPEQynAujInSmPSQ++;
			num = 376596459;
			goto IL_001f;
		}

		private int afeqLlcZqNvkOmtnzqHCjiYuiji(T P_0)
		{
			return afeqLlcZqNvkOmtnzqHCjiYuiji(P_0, FlXVnkZaRfLVoztinCFFyMxcEJB);
		}

		private int afeqLlcZqNvkOmtnzqHCjiYuiji(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				goto IL_0006;
			}
			goto IL_013b;
			IL_0006:
			int num = 1197977328;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x4767AEFF)
				{
				case 7:
					break;
				case 5:
					num2 = bFOMkNWfbeGsYnEuitxGnRdnUfb;
					num = 1197977334;
					continue;
				case 12:
					num4 = 0;
					num = 1197977340;
					continue;
				case 0:
					return num4;
				case 2:
					goto IL_007f;
				case 13:
					return -1;
				case 1:
					goto IL_00c0;
				case 10:
					goto IL_00e5;
				case 6:
					goto IL_0107;
				case 15:
					throw new ArgumentNullException("comparer");
				case 14:
					goto IL_013b;
				case 8:
					num3 = bFOMkNWfbeGsYnEuitxGnRdnUfb;
					num = 1197977341;
					continue;
				case 11:
					return num2;
				case 3:
					goto IL_0171;
				case 9:
					if (num2 > LeXTtwSPAiqEzzeBJvSmCKWwfal)
					{
						num = 1197977339;
						continue;
					}
					goto IL_0107;
				default:
					return -1;
				}
				break;
				IL_0171:
				int num5;
				if (num4 > LeXTtwSPAiqEzzeBJvSmCKWwfal)
				{
					num = 1197977335;
					num5 = num;
				}
				else
				{
					num = 1197977333;
					num5 = num;
				}
				continue;
				IL_007f:
				int num6;
				if (num3 < ToxWVXQQLPxjuaFqOGCzdiVpFIc)
				{
					num = 1197977342;
					num6 = num;
				}
				else
				{
					num = 1197977339;
					num6 = num;
				}
				continue;
				IL_00e5:
				if (!P_1.Equals(CIKxyjrGfgKEkXTLUGlIceCoGTde[num4], P_0))
				{
					num4++;
					num = 1197977340;
				}
				else
				{
					num = 1197977343;
				}
				continue;
				IL_0107:
				if (P_1.Equals(CIKxyjrGfgKEkXTLUGlIceCoGTde[num2], P_0))
				{
					num = 1197977332;
					continue;
				}
				num2++;
				num = 1197977334;
				continue;
				IL_00c0:
				if (P_1.Equals(CIKxyjrGfgKEkXTLUGlIceCoGTde[num3], P_0))
				{
					return num3;
				}
				num3++;
				num = 1197977341;
			}
			goto IL_0006;
			IL_013b:
			if (ierooXELkRVWTXdTXUdETEGRnJZ != 0)
			{
				int num7;
				if (LeXTtwSPAiqEzzeBJvSmCKWwfal < bFOMkNWfbeGsYnEuitxGnRdnUfb)
				{
					num = 1197977331;
					num7 = num;
				}
				else
				{
					num = 1197977338;
					num7 = num;
				}
			}
			else
			{
				num = 1197977330;
			}
			goto IL_000b;
		}

		private void YRKjIYZqcigfZANwqxZmoRAtcSnE(int P_0)
		{
			if (!QeUQkxQowbMhzHLigRRQWNIlhkn(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			while (true)
			{
				int num;
				int num2;
				if (P_0 != bFOMkNWfbeGsYnEuitxGnRdnUfb)
				{
					num = 250771849;
					num2 = num;
				}
				else
				{
					num = 250771848;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0xEF2798B)
					{
					case 0:
						num = 250771852;
						continue;
					case 8:
					{
						int num5;
						if (LeXTtwSPAiqEzzeBJvSmCKWwfal > bFOMkNWfbeGsYnEuitxGnRdnUfb)
						{
							num = 250771841;
							num5 = num;
						}
						else
						{
							num = 250771855;
							num5 = num;
						}
						continue;
					}
					case 9:
						Array.Copy(CIKxyjrGfgKEkXTLUGlIceCoGTde, P_0 + 1, CIKxyjrGfgKEkXTLUGlIceCoGTde, P_0, LeXTtwSPAiqEzzeBJvSmCKWwfal - P_0);
						num = 250771847;
						continue;
					case 2:
					{
						int num4;
						if (P_0 == LeXTtwSPAiqEzzeBJvSmCKWwfal)
						{
							num = 250771840;
							num4 = num;
						}
						else
						{
							num = 250771843;
							num4 = num;
						}
						continue;
					}
					case 10:
						Array.Copy(CIKxyjrGfgKEkXTLUGlIceCoGTde, P_0 + 1, CIKxyjrGfgKEkXTLUGlIceCoGTde, P_0, LeXTtwSPAiqEzzeBJvSmCKWwfal - P_0);
						num = 250771840;
						continue;
					case 12:
						num = 250771840;
						continue;
					case 11:
						CIKxyjrGfgKEkXTLUGlIceCoGTde[LeXTtwSPAiqEzzeBJvSmCKWwfal] = default(T);
						LeXTtwSPAiqEzzeBJvSmCKWwfal = ((LeXTtwSPAiqEzzeBJvSmCKWwfal > 0) ? (LeXTtwSPAiqEzzeBJvSmCKWwfal - 1) : (ToxWVXQQLPxjuaFqOGCzdiVpFIc - 1));
						num = 250771853;
						continue;
					case 3:
						Dequeue();
						return;
					case 4:
					{
						int num3;
						if (P_0 < LeXTtwSPAiqEzzeBJvSmCKWwfal)
						{
							num = 250771842;
							num3 = num;
						}
						else
						{
							num = 250771854;
							num3 = num;
						}
						continue;
					}
					case 5:
						Array.Copy(CIKxyjrGfgKEkXTLUGlIceCoGTde, P_0 + 1, CIKxyjrGfgKEkXTLUGlIceCoGTde, P_0, ToxWVXQQLPxjuaFqOGCzdiVpFIc - P_0 - 1);
						CIKxyjrGfgKEkXTLUGlIceCoGTde[ToxWVXQQLPxjuaFqOGCzdiVpFIc - 1] = CIKxyjrGfgKEkXTLUGlIceCoGTde[0];
						if (LeXTtwSPAiqEzzeBJvSmCKWwfal > 0)
						{
							Array.Copy(CIKxyjrGfgKEkXTLUGlIceCoGTde, 1, CIKxyjrGfgKEkXTLUGlIceCoGTde, 0, LeXTtwSPAiqEzzeBJvSmCKWwfal);
							num = 250771840;
							continue;
						}
						goto case 11;
					case 6:
						yBIrBfrsPGDuPEQynAujInSmPSQ++;
						num = 250771850;
						continue;
					case 7:
						break;
					default:
						ierooXELkRVWTXdTXUdETEGRnJZ--;
						return;
					}
					break;
				}
			}
		}

		private bool QeUQkxQowbMhzHLigRRQWNIlhkn(int P_0)
		{
			if (ierooXELkRVWTXdTXUdETEGRnJZ == 0)
			{
				return false;
			}
			if (LeXTtwSPAiqEzzeBJvSmCKWwfal >= bFOMkNWfbeGsYnEuitxGnRdnUfb)
			{
				if (P_0 >= bFOMkNWfbeGsYnEuitxGnRdnUfb)
				{
					return P_0 <= LeXTtwSPAiqEzzeBJvSmCKWwfal;
				}
				return false;
			}
			if (P_0 < bFOMkNWfbeGsYnEuitxGnRdnUfb)
			{
				return P_0 <= LeXTtwSPAiqEzzeBJvSmCKWwfal;
			}
			return true;
		}

		private int jylLuwFjibLpgxXDgOnZhVahSuo(int P_0)
		{
			if ((uint)P_0 >= (uint)ToxWVXQQLPxjuaFqOGCzdiVpFIc)
			{
				return -1;
			}
			if (!QeUQkxQowbMhzHLigRRQWNIlhkn(P_0))
			{
				return -1;
			}
			if (P_0 >= bFOMkNWfbeGsYnEuitxGnRdnUfb)
			{
				return P_0 - bFOMkNWfbeGsYnEuitxGnRdnUfb;
			}
			return P_0 + ToxWVXQQLPxjuaFqOGCzdiVpFIc - bFOMkNWfbeGsYnEuitxGnRdnUfb;
		}

		private int gVRkhurutTdGjDuHaIVdMHQdAVG(int P_0)
		{
			if ((uint)P_0 >= (uint)ierooXELkRVWTXdTXUdETEGRnJZ)
			{
				return -1;
			}
			P_0 = bFOMkNWfbeGsYnEuitxGnRdnUfb + P_0;
			while (true)
			{
				int num = -2044004816;
				while (true)
				{
					switch (num ^ -2044004815)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (P_0 < ToxWVXQQLPxjuaFqOGCzdiVpFIc)
						{
							num = -2044004813;
							num2 = num;
						}
						else
						{
							num = -2044004814;
							num2 = num;
						}
						continue;
					}
					case 3:
						P_0 -= ToxWVXQQLPxjuaFqOGCzdiVpFIc;
						num = -2044004813;
						continue;
					default:
						return P_0;
					}
					break;
				}
			}
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
				goto IL_0003;
			}
			goto IL_005e;
			IL_0003:
			int num = -671148262;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ -671148264)
				{
				case 5:
					break;
				case 0:
					array[arrayIndex + num2] = this[num2];
					num2++;
					num = -671148263;
					continue;
				case 3:
					goto IL_004c;
				case 6:
					goto IL_005e;
				case 4:
					count = Count;
					num2 = 0;
					num = -671148263;
					continue;
				case 2:
					throw new ArgumentNullException("array");
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0003;
			IL_005e:
			if (arrayIndex >= 0)
			{
				int num3;
				if (arrayIndex + Count <= array.Length)
				{
					num = -671148260;
					num3 = num;
				}
				else
				{
					num = -671148261;
					num3 = num;
				}
				goto IL_0008;
			}
			goto IL_004c;
			IL_004c:
			throw new ArgumentException("array is too small to hold the collection.");
		}

		bool ICollection<T>.Remove(T item)
		{
			return Remove(item);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new fZIPOxHPWQmnOBnJpAQeeNpyvug(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new fZIPOxHPWQmnOBnJpAQeeNpyvug(this);
		}
	}
}
