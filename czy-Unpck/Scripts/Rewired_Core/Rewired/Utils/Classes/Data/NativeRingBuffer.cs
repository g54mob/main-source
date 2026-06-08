using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer RFwsiesdvuzfOJtmKvaOhRnxhoq;

		private readonly int ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		private long cjDgXSaVgvEsJeaeCHEESlgAHkbL;

		private long nOJQLxqiEwbmTichjOKXQkHyHOE;

		private int lgetbBrsrOcslesLNFFxbNqFOyi;

		private bool RNrDDmfhZFTUkmrMnyPgpBGleDNi;

		private uint YKvtymfsNJVEiyzWkAkqlcetqAk;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public int Capacity => ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		public int BytesInBuffer => lgetbBrsrOcslesLNFFxbNqFOyi;

		public bool BufferOverrun => RNrDDmfhZFTUkmrMnyPgpBGleDNi;

		public int ReadPosition => (int)nOJQLxqiEwbmTichjOKXQkHyHOE;

		public long WritePosition => cjDgXSaVgvEsJeaeCHEESlgAHkbL;

		public NativeRingBuffer(int capacity)
		{
			ToxWVXQQLPxjuaFqOGCzdiVpFIc = capacity;
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			RFwsiesdvuzfOJtmKvaOhRnxhoq = new NativeBuffer(capacity);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = RFwsiesdvuzfOJtmKvaOhRnxhoq.GetPointer((int)cjDgXSaVgvEsJeaeCHEESlgAHkbL);
			passId = YKvtymfsNJVEiyzWkAkqlcetqAk;
			int num = default(int);
			if (zeroFill)
			{
				num = bufferLength;
				goto IL_0020;
			}
			goto IL_0046;
			IL_0046:
			ZVhJQESqmxEcVHbgpptFYmPOrQph(bufferLength);
			int num2 = -2052075666;
			goto IL_0025;
			IL_0020:
			num2 = -2052075667;
			goto IL_0025;
			IL_0025:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -2052075666)
				{
				case 4:
					break;
				case 1:
					goto IL_0046;
				case 2:
					goto IL_0054;
				case 3:
					num3 = 0;
					RFwsiesdvuzfOJtmKvaOhRnxhoq.TryFill(0, num, (int)cjDgXSaVgvEsJeaeCHEESlgAHkbL);
					num2 = -2052075668;
					continue;
				default:
					return pointer;
				}
				break;
				IL_0054:
				if (num3 == 0)
				{
					return IntPtr.Zero;
				}
				if (num3 < num)
				{
					num3 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryFill(0, num - num3, num3);
					num2 = -2052075665;
					continue;
				}
				goto IL_0046;
			}
			goto IL_0020;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)cjDgXSaVgvEsJeaeCHEESlgAHkbL;
			passId = YKvtymfsNJVEiyzWkAkqlcetqAk;
			int num3 = default(int);
			while (true)
			{
				int num = -1106453257;
				while (true)
				{
					switch (num ^ -1106453258)
					{
					case 3:
						break;
					case 6:
						return 0;
					case 0:
						num3 = RFwsiesdvuzfOJtmKvaOhRnxhoq.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)cjDgXSaVgvEsJeaeCHEESlgAHkbL);
						if (num3 != 0)
						{
							if (num3 < numBytesToWrite)
							{
								num3 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num3, 0, num3);
								num = -1106453262;
								continue;
							}
							goto default;
						}
						num = -1106453264;
						continue;
					case 5:
						return 0;
					case 2:
						if (numBytesToWrite > 0)
						{
							if (numBytesToWrite > bufferLength)
							{
								numBytesToWrite = bufferLength;
								num = -1106453258;
								continue;
							}
							goto case 0;
						}
						num = -1106453261;
						continue;
					case 1:
						if (!(buffer == IntPtr.Zero))
						{
							int num2;
							if (bufferLength > 0)
							{
								num = -1106453260;
								num2 = num;
							}
							else
							{
								num = -1106453261;
								num2 = num;
							}
							continue;
						}
						goto case 5;
					default:
						ZVhJQESqmxEcVHbgpptFYmPOrQph(num3);
						return num3;
					}
					break;
				}
			}
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)cjDgXSaVgvEsJeaeCHEESlgAHkbL;
			passId = YKvtymfsNJVEiyzWkAkqlcetqAk;
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0)
			{
				goto IL_004d;
			}
			if (numBytesToWrite <= 0)
			{
				goto IL_0023;
			}
			int num2;
			if (numBytesToWrite > num)
			{
				numBytesToWrite = num;
				num2 = -199860979;
				goto IL_0028;
			}
			goto IL_005d;
			IL_0028:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -199860977)
				{
				case 4:
					break;
				case 3:
					goto IL_004d;
				case 2:
					goto IL_005d;
				case 5:
					goto IL_007a;
				case 0:
					return 0;
				default:
					goto IL_00a5;
				}
				break;
				IL_007a:
				if (num3 == 0)
				{
					num2 = -199860977;
					continue;
				}
				if (num3 < numBytesToWrite)
				{
					num3 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryWriteBytes(buffer, numBytesToWrite - num3, 0, num3);
					num2 = -199860978;
					continue;
				}
				goto IL_00a5;
				IL_00a5:
				ZVhJQESqmxEcVHbgpptFYmPOrQph(num3);
				return num3;
			}
			goto IL_0023;
			IL_0023:
			num2 = -199860980;
			goto IL_0028;
			IL_005d:
			num3 = RFwsiesdvuzfOJtmKvaOhRnxhoq.TryWriteBytes(buffer, numBytesToWrite, (int)cjDgXSaVgvEsJeaeCHEESlgAHkbL);
			num2 = -199860982;
			goto IL_0028;
			IL_004d:
			return 0;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, bufferLength, numBytesToWrite, out startOffset, out passId);
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, numBytesToWrite, out startOffset, out passId);
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (!(buffer == IntPtr.Zero) && bufferLength > 0)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 2081578578;
					while (true)
					{
						switch (num ^ 0x7C125E57)
						{
						case 8:
							break;
						case 0:
							num2 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, bufferLength, numBytesToRead - num2, 0, num2);
							num = 2081578581;
							continue;
						case 1:
							numBytesToRead = lgetbBrsrOcslesLNFFxbNqFOyi;
							num = 2081578580;
							continue;
						case 7:
							return 0;
						case 6:
							goto end_IL_0011;
						case 3:
							goto IL_009f;
						case 4:
							goto IL_00c4;
						case 5:
							goto IL_00e1;
						default:
							polBZzrTBDcghqlVrmUphJmLEAoe(num2);
							return num2;
						}
						break;
						IL_00e1:
						if (numBytesToRead <= 0)
						{
							goto end_IL_0011;
						}
						if (lgetbBrsrOcslesLNFFxbNqFOyi != 0)
						{
							if (numBytesToRead > bufferLength)
							{
								numBytesToRead = bufferLength;
								num = 2081578579;
								continue;
							}
							goto IL_00c4;
						}
						num = 2081578577;
						continue;
						IL_00c4:
						int num3;
						if (numBytesToRead > lgetbBrsrOcslesLNFFxbNqFOyi)
						{
							num = 2081578582;
							num3 = num;
						}
						else
						{
							num = 2081578580;
							num3 = num;
						}
						continue;
						IL_009f:
						num2 = RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)nOJQLxqiEwbmTichjOKXQkHyHOE);
						if (num2 > 0)
						{
							int num4;
							if (num2 >= numBytesToRead)
							{
								num = 2081578581;
								num4 = num;
							}
							else
							{
								num = 2081578583;
								num4 = num;
							}
						}
						else
						{
							num = 2081578576;
						}
					}
					continue;
					end_IL_0011:
					break;
				}
			}
			return 0;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			int num2;
			if (num > 0 && numBytesToRead > 0)
			{
				if (lgetbBrsrOcslesLNFFxbNqFOyi == 0)
				{
					goto IL_0022;
				}
				int num3;
				if (numBytesToRead > num)
				{
					num2 = -1528463214;
					num3 = num2;
				}
				else
				{
					num2 = -1528463210;
					num3 = num2;
				}
				goto IL_0027;
			}
			goto IL_00c7;
			IL_00c7:
			return 0;
			IL_0027:
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1528463209)
				{
				case 4:
					break;
				case 2:
					goto IL_0057;
				case 1:
					goto IL_0065;
				case 5:
					numBytesToRead = num;
					num2 = -1528463210;
					continue;
				case 7:
					goto IL_0089;
				case 6:
					goto IL_00c7;
				case 0:
					numBytesToRead = lgetbBrsrOcslesLNFFxbNqFOyi;
					num2 = -1528463216;
					continue;
				default:
					return num4;
				}
				break;
				IL_0089:
				num4 = RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, numBytesToRead, (int)nOJQLxqiEwbmTichjOKXQkHyHOE);
				if (num4 <= 0)
				{
					return 0;
				}
				if (num4 < numBytesToRead)
				{
					num4 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, numBytesToRead - num4, 0, num4);
					num2 = -1528463211;
					continue;
				}
				goto IL_0057;
				IL_0057:
				polBZzrTBDcghqlVrmUphJmLEAoe(num4);
				num2 = -1528463212;
				continue;
				IL_0065:
				int num5;
				if (numBytesToRead > lgetbBrsrOcslesLNFFxbNqFOyi)
				{
					num2 = -1528463209;
					num5 = num2;
				}
				else
				{
					num2 = -1528463216;
					num5 = num2;
				}
			}
			goto IL_0022;
			IL_0022:
			num2 = -1528463215;
			goto IL_0027;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || lgetbBrsrOcslesLNFFxbNqFOyi == 0 || readStartIndex < 0)
			{
				goto IL_0052;
			}
			if (readStartIndex >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
			{
				goto IL_002c;
			}
			int num;
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
				num = 851750966;
				goto IL_0031;
			}
			goto IL_0062;
			IL_00b5:
			int num2 = default(int);
			return num2;
			IL_002c:
			num = 851750963;
			goto IL_0031;
			IL_0031:
			switch (num ^ 0x32C4B037)
			{
			case 3:
				break;
			case 4:
				goto IL_0052;
			case 1:
				goto IL_0062;
			case 0:
				goto IL_007a;
			default:
				goto IL_00b5;
			}
			goto IL_002c;
			IL_0062:
			if (numBytesToRead > lgetbBrsrOcslesLNFFxbNqFOyi)
			{
				numBytesToRead = lgetbBrsrOcslesLNFFxbNqFOyi;
				num = 851750967;
				goto IL_0031;
			}
			goto IL_007a;
			IL_007a:
			num2 = RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, bufferLength, numBytesToRead - num2, 0, num2);
				num = 851750965;
				goto IL_0031;
			}
			goto IL_00b5;
			IL_0052:
			return 0;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			int num3 = default(int);
			while (true)
			{
				int num2 = 1601658905;
				while (true)
				{
					switch (num2 ^ 0x5F77601A)
					{
					case 4:
						break;
					case 5:
						num3 += RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, numBytesToRead - num3, 0, num3);
						num2 = 1601658904;
						continue;
					case 7:
					{
						num3 = RFwsiesdvuzfOJtmKvaOhRnxhoq.TryReadBytes(buffer, numBytesToRead, readStartIndex);
						if (num3 <= 0)
						{
							return 0;
						}
						int num5;
						if (num3 >= numBytesToRead)
						{
							num2 = 1601658904;
							num5 = num2;
						}
						else
						{
							num2 = 1601658911;
							num5 = num2;
						}
						continue;
					}
					case 0:
					{
						int num7;
						if (readStartIndex >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
						{
							num2 = 1601658898;
						}
						else if (numBytesToRead > num)
						{
							num2 = 1601658899;
							num7 = num2;
						}
						else
						{
							num2 = 1601658908;
							num7 = num2;
						}
						continue;
					}
					case 9:
						numBytesToRead = num;
						num2 = 1601658908;
						continue;
					case 3:
						if (num > 0 && numBytesToRead > 0 && lgetbBrsrOcslesLNFFxbNqFOyi != 0)
						{
							int num6;
							if (readStartIndex < 0)
							{
								num2 = 1601658898;
								num6 = num2;
							}
							else
							{
								num2 = 1601658906;
								num6 = num2;
							}
							continue;
						}
						goto case 8;
					case 6:
					{
						int num4;
						if (numBytesToRead <= lgetbBrsrOcslesLNFFxbNqFOyi)
						{
							num2 = 1601658909;
							num4 = num2;
						}
						else
						{
							num2 = 1601658907;
							num4 = num2;
						}
						continue;
					}
					case 8:
						return 0;
					case 1:
						numBytesToRead = lgetbBrsrOcslesLNFFxbNqFOyi;
						num2 = 1601658909;
						continue;
					default:
						return num3;
					}
					break;
				}
			}
		}

		public IntPtr GetPointerFromReadPosition(int offset)
		{
			int offsetFromReadPosition = GetOffsetFromReadPosition(offset);
			while (true)
			{
				int num = 1061511063;
				while (true)
				{
					switch (num ^ 0x3F455F96)
					{
					case 0:
						break;
					case 1:
						if (offsetFromReadPosition < 0)
						{
							goto IL_002a;
						}
						return RFwsiesdvuzfOJtmKvaOhRnxhoq.GetPointer(offsetFromReadPosition);
					default:
						return IntPtr.Zero;
					}
					break;
					IL_002a:
					num = 1061511060;
				}
			}
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)nOJQLxqiEwbmTichjOKXQkHyHOE + offset;
			if (num < ToxWVXQQLPxjuaFqOGCzdiVpFIc)
			{
				goto IL_0040;
			}
			num -= ToxWVXQQLPxjuaFqOGCzdiVpFIc;
			goto IL_0054;
			IL_0023:
			int num2;
			while (true)
			{
				switch (num2 ^ 0x25FA56FD)
				{
				case 3:
					num2 = 637163263;
					continue;
				case 2:
					break;
				case 1:
					goto IL_0054;
				default:
					goto IL_0068;
				}
				break;
			}
			goto IL_0040;
			IL_0054:
			if (num >= 0)
			{
				if (num >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
				{
					num2 = 637163261;
					goto IL_0023;
				}
				return num;
			}
			goto IL_0068;
			IL_0040:
			if (num < 0)
			{
				num += ToxWVXQQLPxjuaFqOGCzdiVpFIc;
				num2 = 637163260;
				goto IL_0023;
			}
			goto IL_0054;
			IL_0068:
			return -1;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			int num;
			if (startIndex >= 0)
			{
				if (startIndex >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
				{
					goto IL_000d;
				}
				if (startIndex >= cjDgXSaVgvEsJeaeCHEESlgAHkbL)
				{
					if (startIndex < cjDgXSaVgvEsJeaeCHEESlgAHkbL)
					{
						goto IL_0080;
					}
					num = 746991390;
				}
				else
				{
					num = 746991388;
				}
				goto IL_0012;
			}
			goto IL_006b;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2C862F1C)
				{
				case 3:
					break;
				case 2:
					goto IL_0033;
				case 0:
					goto IL_004f;
				case 1:
					goto IL_006b;
				default:
					return true;
				}
				break;
				IL_004f:
				if (passId == YKvtymfsNJVEiyzWkAkqlcetqAk)
				{
					return true;
				}
				goto IL_0080;
				IL_0033:
				if (YKvtymfsNJVEiyzWkAkqlcetqAk == 0)
				{
					return false;
				}
				if (YKvtymfsNJVEiyzWkAkqlcetqAk - 1 == passId)
				{
					num = 746991384;
					continue;
				}
				goto IL_0080;
			}
			goto IL_000d;
			IL_000d:
			num = 746991389;
			goto IL_0012;
			IL_0080:
			return false;
			IL_006b:
			return false;
		}

		public void CopyFrom(NativeRingBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			while (ToxWVXQQLPxjuaFqOGCzdiVpFIc == other.ToxWVXQQLPxjuaFqOGCzdiVpFIc)
			{
				while (true)
				{
					cjDgXSaVgvEsJeaeCHEESlgAHkbL = other.cjDgXSaVgvEsJeaeCHEESlgAHkbL;
					nOJQLxqiEwbmTichjOKXQkHyHOE = other.nOJQLxqiEwbmTichjOKXQkHyHOE;
					int num = 1137202068;
					while (true)
					{
						switch (num ^ 0x43C85396)
						{
						case 4:
							num = 1137202071;
							continue;
						case 2:
							lgetbBrsrOcslesLNFFxbNqFOyi = other.lgetbBrsrOcslesLNFFxbNqFOyi;
							num = 1137202069;
							continue;
						case 0:
							break;
						case 1:
							goto end_IL_0047;
						default:
							RNrDDmfhZFTUkmrMnyPgpBGleDNi = other.RNrDDmfhZFTUkmrMnyPgpBGleDNi;
							YKvtymfsNJVEiyzWkAkqlcetqAk = other.YKvtymfsNJVEiyzWkAkqlcetqAk;
							RFwsiesdvuzfOJtmKvaOhRnxhoq.CopyFrom(other.RFwsiesdvuzfOJtmKvaOhRnxhoq);
							return;
						}
						break;
					}
					continue;
					end_IL_0047:
					break;
				}
			}
			throw new Exception("Buffer does not have the same capacity. Cannot copy.");
		}

		public void Reset()
		{
			cjDgXSaVgvEsJeaeCHEESlgAHkbL = 0L;
			while (true)
			{
				int num = -849067921;
				while (true)
				{
					switch (num ^ -849067923)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0026;
					case 1:
						return;
					}
					break;
					IL_0026:
					nOJQLxqiEwbmTichjOKXQkHyHOE = 0L;
					lgetbBrsrOcslesLNFFxbNqFOyi = 0;
					RNrDDmfhZFTUkmrMnyPgpBGleDNi = false;
					YKvtymfsNJVEiyzWkAkqlcetqAk = 0u;
					num = -849067924;
				}
			}
		}

		private void ZVhJQESqmxEcVHbgpptFYmPOrQph(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			while (true)
			{
				int num = (int)cjDgXSaVgvEsJeaeCHEESlgAHkbL;
				cjDgXSaVgvEsJeaeCHEESlgAHkbL += P_0;
				bool flag = false;
				int num2;
				int num3;
				if (num < nOJQLxqiEwbmTichjOKXQkHyHOE)
				{
					num2 = -2095085315;
					num3 = num2;
				}
				else
				{
					num2 = -2095085325;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2095085318)
					{
					case 5:
						num2 = -2095085320;
						continue;
					case 1:
						flag = true;
						num2 = -2095085319;
						continue;
					case 7:
					{
						int num4;
						if (cjDgXSaVgvEsJeaeCHEESlgAHkbL > nOJQLxqiEwbmTichjOKXQkHyHOE)
						{
							num2 = -2095085317;
							num4 = num2;
						}
						else
						{
							num2 = -2095085328;
							num4 = num2;
						}
						continue;
					}
					case 8:
						if (cjDgXSaVgvEsJeaeCHEESlgAHkbL >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
						{
							cjDgXSaVgvEsJeaeCHEESlgAHkbL -= ToxWVXQQLPxjuaFqOGCzdiVpFIc;
							num2 = -2095085318;
							continue;
						}
						goto default;
					case 0:
						dEtGFjiveSfGvXiLmKXgFQHIEwhM();
						num2 = -2095085314;
						continue;
					case 6:
						if (lgetbBrsrOcslesLNFFxbNqFOyi > 0)
						{
							flag = true;
							num2 = -2095085328;
							continue;
						}
						goto case 10;
					case 2:
						break;
					case 3:
						num2 = -2095085328;
						continue;
					case 9:
						if (num <= nOJQLxqiEwbmTichjOKXQkHyHOE)
						{
							goto case 6;
						}
						if (cjDgXSaVgvEsJeaeCHEESlgAHkbL - ToxWVXQQLPxjuaFqOGCzdiVpFIc > nOJQLxqiEwbmTichjOKXQkHyHOE)
						{
							flag = true;
							num2 = -2095085328;
							continue;
						}
						goto case 10;
					case 10:
						if (flag)
						{
							RNrDDmfhZFTUkmrMnyPgpBGleDNi = true;
							nOJQLxqiEwbmTichjOKXQkHyHOE = cjDgXSaVgvEsJeaeCHEESlgAHkbL;
							if (nOJQLxqiEwbmTichjOKXQkHyHOE >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
							{
								nOJQLxqiEwbmTichjOKXQkHyHOE -= ToxWVXQQLPxjuaFqOGCzdiVpFIc;
								num2 = -2095085326;
								continue;
							}
						}
						goto case 8;
					default:
						lgetbBrsrOcslesLNFFxbNqFOyi = (int)MathTools.Clamp((long)lgetbBrsrOcslesLNFFxbNqFOyi + (long)P_0, 0L, ToxWVXQQLPxjuaFqOGCzdiVpFIc);
						return;
					}
					break;
				}
			}
		}

		private void polBZzrTBDcghqlVrmUphJmLEAoe(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!RNrDDmfhZFTUkmrMnyPgpBGleDNi)
				{
					num = 1586681879;
					num2 = num;
				}
				else
				{
					num = 1586681878;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5E92D814)
					{
					case 5:
						num = 1586681877;
						continue;
					case 1:
						break;
					case 2:
						RNrDDmfhZFTUkmrMnyPgpBGleDNi = false;
						num = 1586681879;
						continue;
					case 4:
						nOJQLxqiEwbmTichjOKXQkHyHOE -= ToxWVXQQLPxjuaFqOGCzdiVpFIc;
						num = 1586681876;
						continue;
					case 3:
					{
						nOJQLxqiEwbmTichjOKXQkHyHOE += P_0;
						int num4;
						if (nOJQLxqiEwbmTichjOKXQkHyHOE >= ToxWVXQQLPxjuaFqOGCzdiVpFIc)
						{
							num = 1586681872;
							num4 = num;
						}
						else
						{
							num = 1586681876;
							num4 = num;
						}
						continue;
					}
					default:
					{
						long num3 = (long)lgetbBrsrOcslesLNFFxbNqFOyi - (long)P_0;
						lgetbBrsrOcslesLNFFxbNqFOyi = (int)((num3 >= 0) ? num3 : 0);
						return;
					}
					}
					break;
				}
			}
		}

		private void dEtGFjiveSfGvXiLmKXgFQHIEwhM()
		{
			if (YKvtymfsNJVEiyzWkAkqlcetqAk == uint.MaxValue)
			{
				goto IL_0009;
			}
			goto IL_003a;
			IL_0009:
			int num = -1089202161;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1089202163)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				YKvtymfsNJVEiyzWkAkqlcetqAk = 0u;
				return;
			case 1:
				goto IL_003a;
			case 3:
				return;
			}
			goto IL_0009;
			IL_003a:
			YKvtymfsNJVEiyzWkAkqlcetqAk++;
			num = -1089202162;
			goto IL_000e;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~NativeRingBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (disposing && RFwsiesdvuzfOJtmKvaOhRnxhoq != null)
			{
				RFwsiesdvuzfOJtmKvaOhRnxhoq.Dispose();
				int num = -2054957704;
				while (true)
				{
					switch (num ^ -2054957703)
					{
					case 0:
						num = -2054957701;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}
	}
}
