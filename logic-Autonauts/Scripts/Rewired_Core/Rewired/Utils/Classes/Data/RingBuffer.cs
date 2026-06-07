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
		public struct OVUarwropEMaPipcgNnfySNbArJ : IDisposable, IEnumerator, IEnumerator<T>
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
						if (index != buffer.DfhXuMaZHXFIKwxsAEGTRtoUKDe + 1)
						{
							goto IL_0048;
						}
						while (true)
						{
							switch (-1138641228 ^ -1138641227)
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

			internal OVUarwropEMaPipcgNnfySNbArJ(RingBuffer<T> buffer)
			{
				this.buffer = buffer;
				index = 0;
				version = buffer.HCKdygRhwCetItzVwbRsEqktGNve;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.HCKdygRhwCetItzVwbRsEqktGNve && (uint)index < (uint)buffer.DfhXuMaZHXFIKwxsAEGTRtoUKDe)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return XtGSwlBbjQesbfDUZjPcgHsaCGX();
			}

			private bool XtGSwlBbjQesbfDUZjPcgHsaCGX()
			{
				if (version != buffer.HCKdygRhwCetItzVwbRsEqktGNve)
				{
					while (true)
					{
						switch (0x43EBC48E ^ 0x43EBC48C)
						{
						case 0:
							continue;
						case 2:
							throw new InvalidOperationException("RingBuffer was changed.");
						}
						break;
					}
				}
				index = buffer.DfhXuMaZHXFIKwxsAEGTRtoUKDe + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.HCKdygRhwCetItzVwbRsEqktGNve)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] bGENmuXKPeTrJiseBCiPciUrUvO;

		private readonly int qvddhAEohNgcpXDiHojyOjpuJQDJ;

		private int eaZFUxkOtiNXgAkiCFjjWZylAnM;

		private int GEMlbGkpGqsvHYJPffSVdmXwWuI;

		private int DfhXuMaZHXFIKwxsAEGTRtoUKDe;

		private int fvhWEHkXTdewDvpKpgUEcSRncnC;

		private int HCKdygRhwCetItzVwbRsEqktGNve;

		private IEqualityComparer<T> ubrUaedVBLiQYMPUtnVWqcasDXu = EqualityComparerNoAlloc<T>.Default;

		public int Count
		{
			get
			{
				return DfhXuMaZHXFIKwxsAEGTRtoUKDe;
			}
		}

		public int Capacity
		{
			get
			{
				return qvddhAEohNgcpXDiHojyOjpuJQDJ;
			}
		}

		public int OverrunCount
		{
			get
			{
				return fvhWEHkXTdewDvpKpgUEcSRncnC;
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

		public T this[int index]
		{
			get
			{
				int num = JWHAalXBADFVmkygjCbiSomuRSd(index);
				while (true)
				{
					int num2 = -2047025437;
					while (true)
					{
						switch (num2 ^ -2047025440)
						{
						case 0:
							break;
						case 3:
						{
							int num3;
							if (!paGBNwgPPvmcygLBfjgBWVecbxU(num))
							{
								num2 = -2047025439;
								num3 = num2;
							}
							else
							{
								num2 = -2047025438;
								num3 = num2;
							}
							continue;
						}
						case 1:
							throw new IndexOutOfRangeException();
						default:
							return bGENmuXKPeTrJiseBCiPciUrUvO[num];
						}
						break;
					}
				}
			}
			set
			{
				int num = JWHAalXBADFVmkygjCbiSomuRSd(index);
				if (!paGBNwgPPvmcygLBfjgBWVecbxU(num))
				{
					while (true)
					{
						switch (0x5F19FCE0 ^ 0x5F19FCE1)
						{
						case 0:
							continue;
						case 1:
							throw new IndexOutOfRangeException();
						}
						break;
					}
				}
				bGENmuXKPeTrJiseBCiPciUrUvO[num] = value;
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
			bGENmuXKPeTrJiseBCiPciUrUvO = new T[capacity];
			qvddhAEohNgcpXDiHojyOjpuJQDJ = capacity;
			Clear();
		}

		public void Enqueue(T item)
		{
			eaZFUxkOtiNXgAkiCFjjWZylAnM = ((eaZFUxkOtiNXgAkiCFjjWZylAnM < qvddhAEohNgcpXDiHojyOjpuJQDJ - 1) ? (eaZFUxkOtiNXgAkiCFjjWZylAnM + 1) : 0);
			if (DfhXuMaZHXFIKwxsAEGTRtoUKDe != 0)
			{
				goto IL_005b;
			}
			GEMlbGkpGqsvHYJPffSVdmXwWuI = 0;
			goto IL_00b0;
			IL_005b:
			int num;
			int num2;
			if (eaZFUxkOtiNXgAkiCFjjWZylAnM != GEMlbGkpGqsvHYJPffSVdmXwWuI)
			{
				num = -1477233626;
				num2 = num;
			}
			else
			{
				num = -1477233628;
				num2 = num;
			}
			goto IL_0037;
			IL_00b0:
			bGENmuXKPeTrJiseBCiPciUrUvO[eaZFUxkOtiNXgAkiCFjjWZylAnM] = item;
			if (DfhXuMaZHXFIKwxsAEGTRtoUKDe < qvddhAEohNgcpXDiHojyOjpuJQDJ)
			{
				DfhXuMaZHXFIKwxsAEGTRtoUKDe++;
				num = -1477233627;
				goto IL_0037;
			}
			return;
			IL_0037:
			while (true)
			{
				switch (num ^ -1477233628)
				{
				case 3:
					num = -1477233632;
					continue;
				default:
					return;
				case 4:
					break;
				case 0:
					GEMlbGkpGqsvHYJPffSVdmXwWuI = ((GEMlbGkpGqsvHYJPffSVdmXwWuI < qvddhAEohNgcpXDiHojyOjpuJQDJ - 1) ? (GEMlbGkpGqsvHYJPffSVdmXwWuI + 1) : 0);
					fvhWEHkXTdewDvpKpgUEcSRncnC++;
					num = -1477233626;
					continue;
				case 2:
					goto IL_00b0;
				case 1:
					return;
				}
				break;
			}
			goto IL_005b;
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
			if (DfhXuMaZHXFIKwxsAEGTRtoUKDe == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			while (true)
			{
				T result = bGENmuXKPeTrJiseBCiPciUrUvO[GEMlbGkpGqsvHYJPffSVdmXwWuI];
				int num = -431425360;
				while (true)
				{
					switch (num ^ -431425355)
					{
					case 3:
						num = -431425356;
						continue;
					case 7:
						GEMlbGkpGqsvHYJPffSVdmXwWuI = ((GEMlbGkpGqsvHYJPffSVdmXwWuI < qvddhAEohNgcpXDiHojyOjpuJQDJ - 1) ? (GEMlbGkpGqsvHYJPffSVdmXwWuI + 1) : 0);
						fvhWEHkXTdewDvpKpgUEcSRncnC = 0;
						DfhXuMaZHXFIKwxsAEGTRtoUKDe--;
						num = -431425355;
						continue;
					case 2:
						bGENmuXKPeTrJiseBCiPciUrUvO[GEMlbGkpGqsvHYJPffSVdmXwWuI] = default(T);
						num = -431425358;
						continue;
					case 5:
					{
						int num2;
						if (GEMlbGkpGqsvHYJPffSVdmXwWuI == eaZFUxkOtiNXgAkiCFjjWZylAnM)
						{
							num = -431425357;
							num2 = num;
						}
						else
						{
							num = -431425353;
							num2 = num;
						}
						continue;
					}
					case 0:
						HCKdygRhwCetItzVwbRsEqktGNve++;
						num = -431425359;
						continue;
					case 1:
						break;
					case 6:
						Clear();
						num = -431425359;
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
			if (eaZFUxkOtiNXgAkiCFjjWZylAnM < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return bGENmuXKPeTrJiseBCiPciUrUvO[GEMlbGkpGqsvHYJPffSVdmXwWuI];
		}

		public bool Contains(T item)
		{
			return VDoMDuInXHDwNLHEyTFNjqanFyD(item, ubrUaedVBLiQYMPUtnVWqcasDXu) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return VDoMDuInXHDwNLHEyTFNjqanFyD(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return EAveozHhSltSdTMydVtODxxmmVTJ(VDoMDuInXHDwNLHEyTFNjqanFyD(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (Count == 0)
			{
				return false;
			}
			int num = VDoMDuInXHDwNLHEyTFNjqanFyD(item, comparer);
			if (num < 0)
			{
				return false;
			}
			boWjuZbrBkqaQuzLnsMhqfemXEG(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			boWjuZbrBkqaQuzLnsMhqfemXEG(JWHAalXBADFVmkygjCbiSomuRSd(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			while (true)
			{
				int num = 0;
				int count = Count;
				int num2 = count - 1;
				int num3 = 121203672;
				while (true)
				{
					switch (num3 ^ 0x7396BD9)
					{
					case 0:
						num3 = 121203677;
						continue;
					case 4:
						break;
					case 2:
						if (comparer.Equals(this[num2], item))
						{
							RemoveAt(num2);
							num++;
							num3 = 121203674;
							continue;
						}
						goto case 3;
					case 3:
						num2--;
						num3 = 121203672;
						continue;
					default:
						if (num2 < 0)
						{
							return num;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public void Clear()
		{
			if (DfhXuMaZHXFIKwxsAEGTRtoUKDe > 0)
			{
				while (true)
				{
					int num = -975794285;
					while (true)
					{
						switch (num ^ -975794286)
						{
						case 6:
							break;
						case 0:
							DfhXuMaZHXFIKwxsAEGTRtoUKDe = 0;
							num = -975794281;
							continue;
						case 2:
							num = -975794286;
							continue;
						case 4:
							Array.Clear(bGENmuXKPeTrJiseBCiPciUrUvO, GEMlbGkpGqsvHYJPffSVdmXwWuI, qvddhAEohNgcpXDiHojyOjpuJQDJ - GEMlbGkpGqsvHYJPffSVdmXwWuI);
							num = -975794286;
							continue;
						case 1:
							if (eaZFUxkOtiNXgAkiCFjjWZylAnM >= GEMlbGkpGqsvHYJPffSVdmXwWuI)
							{
								Array.Clear(bGENmuXKPeTrJiseBCiPciUrUvO, GEMlbGkpGqsvHYJPffSVdmXwWuI, eaZFUxkOtiNXgAkiCFjjWZylAnM - GEMlbGkpGqsvHYJPffSVdmXwWuI + 1);
								num = -975794288;
								continue;
							}
							goto case 3;
						case 3:
							Array.Clear(bGENmuXKPeTrJiseBCiPciUrUvO, 0, eaZFUxkOtiNXgAkiCFjjWZylAnM + 1);
							num = -975794282;
							continue;
						default:
							goto end_IL_000c;
						}
						break;
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			eaZFUxkOtiNXgAkiCFjjWZylAnM = -1;
			GEMlbGkpGqsvHYJPffSVdmXwWuI = -1;
			fvhWEHkXTdewDvpKpgUEcSRncnC = 0;
			HCKdygRhwCetItzVwbRsEqktGNve++;
		}

		private int VDoMDuInXHDwNLHEyTFNjqanFyD(T P_0)
		{
			return VDoMDuInXHDwNLHEyTFNjqanFyD(P_0, ubrUaedVBLiQYMPUtnVWqcasDXu);
		}

		private int VDoMDuInXHDwNLHEyTFNjqanFyD(T P_0, IEqualityComparer<T> P_1)
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
				IL_012e:
				int num2;
				if (DfhXuMaZHXFIKwxsAEGTRtoUKDe != 0)
				{
					if (eaZFUxkOtiNXgAkiCFjjWZylAnM < GEMlbGkpGqsvHYJPffSVdmXwWuI)
					{
						goto IL_00a1;
					}
					num = GEMlbGkpGqsvHYJPffSVdmXwWuI;
					num2 = -845996721;
				}
				else
				{
					num2 = -845996730;
				}
				goto IL_0016;
				IL_0016:
				while (true)
				{
					switch (num2 ^ -845996729)
					{
					case 11:
						num2 = -845996731;
						continue;
					case 13:
						if (num3 > eaZFUxkOtiNXgAkiCFjjWZylAnM)
						{
							num4 = GEMlbGkpGqsvHYJPffSVdmXwWuI;
							num2 = -845996727;
							continue;
						}
						goto IL_00ff;
					case 9:
						break;
					case 3:
						goto end_IL_0016;
					case 7:
						num2 = -845996726;
						continue;
					case 0:
						num2 = -845996723;
						continue;
					case 8:
						goto IL_00c1;
					case 1:
						return -1;
					case 5:
						goto IL_00ff;
					case 14:
						num2 = -845996725;
						continue;
					case 2:
						goto IL_012e;
					case 6:
						goto IL_0140;
					case 12:
						goto IL_015f;
					case 4:
						return num;
					default:
						return -1;
					}
					if (P_1.Equals(bGENmuXKPeTrJiseBCiPciUrUvO[num4], P_0))
					{
						return num4;
					}
					num4++;
					num2 = -845996725;
					continue;
					IL_015f:
					int num5;
					if (num4 < qvddhAEohNgcpXDiHojyOjpuJQDJ)
					{
						num2 = -845996722;
						num5 = num2;
					}
					else
					{
						num2 = -845996723;
						num5 = num2;
					}
					continue;
					IL_00c1:
					int num6;
					if (num > eaZFUxkOtiNXgAkiCFjjWZylAnM)
					{
						num2 = -845996729;
						num6 = num2;
					}
					else
					{
						num2 = -845996735;
						num6 = num2;
					}
					continue;
					IL_00ff:
					if (P_1.Equals(bGENmuXKPeTrJiseBCiPciUrUvO[num3], P_0))
					{
						return num3;
					}
					num3++;
					num2 = -845996726;
					continue;
					IL_0140:
					if (P_1.Equals(bGENmuXKPeTrJiseBCiPciUrUvO[num], P_0))
					{
						num2 = -845996733;
						continue;
					}
					num++;
					num2 = -845996721;
					continue;
					end_IL_0016:
					break;
				}
				goto IL_00a1;
				IL_00a1:
				num3 = 0;
				num2 = -845996736;
				goto IL_0016;
			}
		}

		private void boWjuZbrBkqaQuzLnsMhqfemXEG(int P_0)
		{
			if (!paGBNwgPPvmcygLBfjgBWVecbxU(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			while (P_0 != GEMlbGkpGqsvHYJPffSVdmXwWuI)
			{
				while (true)
				{
					IL_0080:
					if (P_0 != eaZFUxkOtiNXgAkiCFjjWZylAnM)
					{
						int num;
						int num2;
						if (eaZFUxkOtiNXgAkiCFjjWZylAnM <= GEMlbGkpGqsvHYJPffSVdmXwWuI)
						{
							num = -976560;
							num2 = num;
						}
						else
						{
							num = -976555;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -976554)
							{
							case 2:
								num = -976559;
								continue;
							case 7:
								break;
							case 3:
								Array.Copy(bGENmuXKPeTrJiseBCiPciUrUvO, P_0 + 1, bGENmuXKPeTrJiseBCiPciUrUvO, P_0, eaZFUxkOtiNXgAkiCFjjWZylAnM - P_0);
								num = -976553;
								continue;
							case 4:
								goto IL_0080;
							case 6:
								goto IL_00ae;
							case 0:
								Array.Copy(bGENmuXKPeTrJiseBCiPciUrUvO, P_0 + 1, bGENmuXKPeTrJiseBCiPciUrUvO, P_0, eaZFUxkOtiNXgAkiCFjjWZylAnM - P_0);
								num = -976553;
								continue;
							case 5:
								Array.Copy(bGENmuXKPeTrJiseBCiPciUrUvO, P_0 + 1, bGENmuXKPeTrJiseBCiPciUrUvO, P_0, qvddhAEohNgcpXDiHojyOjpuJQDJ - P_0 - 1);
								bGENmuXKPeTrJiseBCiPciUrUvO[qvddhAEohNgcpXDiHojyOjpuJQDJ - 1] = bGENmuXKPeTrJiseBCiPciUrUvO[0];
								if (eaZFUxkOtiNXgAkiCFjjWZylAnM > 0)
								{
									Array.Copy(bGENmuXKPeTrJiseBCiPciUrUvO, 1, bGENmuXKPeTrJiseBCiPciUrUvO, 0, eaZFUxkOtiNXgAkiCFjjWZylAnM);
									num = -976553;
									continue;
								}
								goto IL_015c;
							default:
								goto IL_015c;
							}
							break;
							IL_00ae:
							int num3;
							if (P_0 >= eaZFUxkOtiNXgAkiCFjjWZylAnM)
							{
								num = -976557;
								num3 = num;
							}
							else
							{
								num = -976554;
								num3 = num;
							}
						}
						break;
					}
					goto IL_015c;
					IL_015c:
					bGENmuXKPeTrJiseBCiPciUrUvO[eaZFUxkOtiNXgAkiCFjjWZylAnM] = default(T);
					eaZFUxkOtiNXgAkiCFjjWZylAnM = ((eaZFUxkOtiNXgAkiCFjjWZylAnM > 0) ? (eaZFUxkOtiNXgAkiCFjjWZylAnM - 1) : (qvddhAEohNgcpXDiHojyOjpuJQDJ - 1));
					HCKdygRhwCetItzVwbRsEqktGNve++;
					DfhXuMaZHXFIKwxsAEGTRtoUKDe--;
					return;
				}
			}
			Dequeue();
		}

		private bool paGBNwgPPvmcygLBfjgBWVecbxU(int P_0)
		{
			if (DfhXuMaZHXFIKwxsAEGTRtoUKDe == 0)
			{
				return false;
			}
			if (eaZFUxkOtiNXgAkiCFjjWZylAnM >= GEMlbGkpGqsvHYJPffSVdmXwWuI)
			{
				if (P_0 >= GEMlbGkpGqsvHYJPffSVdmXwWuI)
				{
					return P_0 <= eaZFUxkOtiNXgAkiCFjjWZylAnM;
				}
				return false;
			}
			if (P_0 < GEMlbGkpGqsvHYJPffSVdmXwWuI)
			{
				return P_0 <= eaZFUxkOtiNXgAkiCFjjWZylAnM;
			}
			return true;
		}

		private int EAveozHhSltSdTMydVtODxxmmVTJ(int P_0)
		{
			if ((uint)P_0 >= (uint)qvddhAEohNgcpXDiHojyOjpuJQDJ)
			{
				return -1;
			}
			if (!paGBNwgPPvmcygLBfjgBWVecbxU(P_0))
			{
				return -1;
			}
			if (P_0 >= GEMlbGkpGqsvHYJPffSVdmXwWuI)
			{
				return P_0 - GEMlbGkpGqsvHYJPffSVdmXwWuI;
			}
			return P_0 + qvddhAEohNgcpXDiHojyOjpuJQDJ - GEMlbGkpGqsvHYJPffSVdmXwWuI;
		}

		private int JWHAalXBADFVmkygjCbiSomuRSd(int P_0)
		{
			if ((uint)P_0 >= (uint)DfhXuMaZHXFIKwxsAEGTRtoUKDe)
			{
				goto IL_0009;
			}
			P_0 = GEMlbGkpGqsvHYJPffSVdmXwWuI + P_0;
			int num;
			int num2;
			if (P_0 < qvddhAEohNgcpXDiHojyOjpuJQDJ)
			{
				num = 644873675;
				num2 = num;
			}
			else
			{
				num = 644873672;
				num2 = num;
			}
			goto IL_000e;
			IL_0009:
			num = 644873674;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x266FFDCB)
				{
				case 2:
					break;
				case 1:
					return -1;
				case 3:
					goto IL_0051;
				default:
					return P_0;
				}
				break;
				IL_0051:
				P_0 -= qvddhAEohNgcpXDiHojyOjpuJQDJ;
				num = 644873675;
			}
			goto IL_0009;
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
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				IL_0080:
				if (arrayIndex >= 0)
				{
					int num;
					int num2;
					if (arrayIndex + Count > array.Length)
					{
						num = 508358599;
						num2 = num;
					}
					else
					{
						num = 508358595;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x1E4CEFC1)
						{
						case 5:
							num = 508358594;
							continue;
						case 0:
							array[arrayIndex + num3] = this[num3];
							num3++;
							num = 508358592;
							continue;
						case 4:
							num3 = 0;
							num = 508358592;
							continue;
						case 2:
							count = Count;
							num = 508358597;
							continue;
						case 6:
							break;
						case 3:
							goto IL_0080;
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
				throw new ArgumentException("array is too small to hold the collection.");
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			return Remove(item);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new OVUarwropEMaPipcgNnfySNbArJ(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new OVUarwropEMaPipcgNnfySNbArJ(this);
		}
	}
}
