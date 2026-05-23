using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class NativeTools
	{
		private static byte[] FeBZMqxddUuJxIOljkVJZmWaOLb;

		public static IntPtr OffsetIntPtr(IntPtr intPtr, int offset)
		{
			if (offset == 0)
			{
				return intPtr;
			}
			if (SystemInfo.is64Bit)
			{
				return new IntPtr(intPtr.ToInt64() + offset);
			}
			return new IntPtr(intPtr.ToInt32() + offset);
		}

		public static bool CopyMemory(IntPtr source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (!throwOnError)
			{
				goto IL_0116;
			}
			if (source == IntPtr.Zero)
			{
				throw new ArgumentNullException("source");
			}
			goto IL_0140;
			IL_0116:
			int num;
			if (!(source == IntPtr.Zero))
			{
				if (!(destination == IntPtr.Zero))
				{
					if (sourceStartIndex >= 0)
					{
						goto IL_007b;
					}
					sourceStartIndex = 0;
					num = 1396426640;
				}
				else
				{
					num = 1396426654;
				}
				goto IL_0027;
			}
			goto IL_006b;
			IL_0140:
			if (destination == IntPtr.Zero)
			{
				throw new ArgumentNullException("destination");
			}
			goto IL_00e1;
			IL_00e1:
			if (sourceStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex");
			}
			goto IL_0090;
			IL_0090:
			int num2;
			if (destinationStartIndex < 0)
			{
				num = 1396426652;
				num2 = num;
			}
			else
			{
				num = 1396426648;
				num2 = num;
			}
			goto IL_0027;
			IL_007b:
			int num3;
			if (destinationStartIndex < 0)
			{
				num = 1396426642;
				num3 = num;
			}
			else
			{
				num = 1396426653;
				num3 = num;
			}
			goto IL_0027;
			IL_006b:
			return false;
			IL_0027:
			int num5 = default(int);
			int num6 = default(int);
			int num7 = default(int);
			int num8 = default(int);
			int num10 = default(int);
			int num11 = default(int);
			int num12 = default(int);
			while (true)
			{
				switch (num ^ 0x533BC794)
				{
				case 11:
					num = 1396426647;
					continue;
				case 10:
					break;
				case 4:
					goto IL_007b;
				case 2:
					goto IL_0090;
				case 7:
					throw new ArgumentOutOfRangeException("length");
				case 12:
					goto IL_00ba;
				case 8:
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				case 1:
					goto IL_00e1;
				case 9:
					goto IL_00fa;
				case 6:
					destinationStartIndex = 0;
					num = 1396426653;
					continue;
				case 5:
					goto IL_0116;
				case 3:
					goto IL_0140;
				default:
					return false;
				}
				break;
				IL_00fa:
				if (bytesToCopy <= 0)
				{
					num = 1396426644;
					continue;
				}
				goto IL_0164;
				IL_0164:
				try
				{
					int num4 = bytesToCopy;
					if (num4 >= 8)
					{
						num5 = bytesToCopy / 8 * 8;
						num6 = 0;
						goto IL_0177;
					}
					goto IL_0282;
					IL_0282:
					int num9;
					if (num4 >= 4)
					{
						num7 = bytesToCopy / 4 * 4;
						num8 = bytesToCopy - num4;
						num9 = 1396426640;
						goto IL_017c;
					}
					goto IL_02d5;
					IL_0177:
					num9 = 1396426654;
					goto IL_017c;
					IL_017c:
					while (true)
					{
						switch (num9 ^ 0x533BC794)
						{
						case 11:
							break;
						case 12:
							num10 = bytesToCopy - num4;
							num9 = 1396426650;
							continue;
						case 13:
							if (num11 >= num12)
							{
								num4 %= 2;
								num9 = 1396426648;
								continue;
							}
							goto case 0;
						case 7:
							num6 += 8;
							num9 = 1396426653;
							continue;
						case 4:
							goto IL_0200;
						case 1:
							num12 = bytesToCopy / 2 * 2;
							num11 = bytesToCopy - num4;
							num9 = 1396426649;
							continue;
						case 10:
							num9 = 1396426653;
							continue;
						case 17:
							num4 %= 4;
							num9 = 1396426641;
							continue;
						case 9:
							if (num6 >= num5)
							{
								num4 %= 8;
								num9 = 1396426651;
								continue;
							}
							goto case 8;
						case 0:
							Marshal.WriteInt16(destination, num11 + destinationStartIndex, Marshal.ReadInt16(source, num11 + sourceStartIndex));
							num11 += 2;
							num9 = 1396426649;
							continue;
						case 15:
							goto IL_0282;
						case 14:
							num9 = 1396426646;
							continue;
						case 6:
							Marshal.WriteByte(destination, num10 + destinationStartIndex, Marshal.ReadByte(source, num10 + sourceStartIndex));
							num9 = 1396426647;
							continue;
						case 3:
							num10++;
							num9 = 1396426646;
							continue;
						case 5:
							goto IL_02d5;
						case 8:
							Marshal.WriteInt64(destination, num6 + destinationStartIndex, Marshal.ReadInt64(source, num6 + sourceStartIndex));
							num9 = 1396426643;
							continue;
						case 16:
							Marshal.WriteInt32(destination, num8 + destinationStartIndex, Marshal.ReadInt32(source, num8 + sourceStartIndex));
							num8 += 4;
							num9 = 1396426640;
							continue;
						default:
							if (num10 >= bytesToCopy)
							{
								return true;
							}
							goto case 6;
						}
						break;
						IL_0200:
						int num13;
						if (num8 < num7)
						{
							num9 = 1396426628;
							num13 = num9;
						}
						else
						{
							num9 = 1396426629;
							num13 = num9;
						}
					}
					goto IL_0177;
					IL_02d5:
					int num14;
					if (num4 < 2)
					{
						num9 = 1396426648;
						num14 = num9;
					}
					else
					{
						num9 = 1396426645;
						num14 = num9;
					}
					goto IL_017c;
				}
				catch
				{
					if (throwOnError)
					{
						throw;
					}
					return false;
				}
				IL_00ba:
				if (bytesToCopy <= 0)
				{
					num = 1396426643;
					continue;
				}
				goto IL_0164;
			}
			goto IL_006b;
		}

		public static bool CopyMemory(byte[] source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				goto IL_009c;
			}
			goto IL_00ba;
			IL_00dc:
			return false;
			IL_009c:
			int num;
			if (sourceStartIndex >= 0)
			{
				int num2;
				if (sourceStartIndex >= source.Length)
				{
					num = -603821694;
					num2 = num;
				}
				else
				{
					num = -603821685;
					num2 = num;
				}
				goto IL_001d;
			}
			goto IL_00c7;
			IL_00ba:
			if (source != null)
			{
				if (sourceStartIndex < 0)
				{
					goto IL_00dc;
				}
				if (sourceStartIndex < source.Length)
				{
					if (destinationStartIndex < 0)
					{
						return false;
					}
					if (bytesToCopy > source.Length - sourceStartIndex)
					{
						return false;
					}
					goto IL_00ef;
				}
				num = -603821683;
			}
			else
			{
				num = -603821684;
			}
			goto IL_001d;
			IL_00c7:
			throw new ArgumentOutOfRangeException("sourceStartIndex");
			IL_00ef:
			try
			{
				if (destinationStartIndex == 0)
				{
					goto IL_00f2;
				}
				goto IL_0125;
				IL_00f2:
				int num3 = -603821687;
				goto IL_00f7;
				IL_00f7:
				while (true)
				{
					switch (num3 ^ -603821686)
					{
					case 0:
						break;
					case 3:
						Marshal.Copy(source, sourceStartIndex, destination, bytesToCopy);
						num3 = -603821685;
						continue;
					case 2:
						goto IL_0125;
					default:
						return true;
					}
					break;
				}
				goto IL_00f2;
				IL_0125:
				Marshal.Copy(source, sourceStartIndex, OffsetIntPtr(destination, destinationStartIndex), bytesToCopy);
				num3 = -603821685;
				goto IL_00f7;
			}
			catch
			{
				while (true)
				{
					int num4 = -603821685;
					while (true)
					{
						switch (num4 ^ -603821686)
						{
						case 3:
							break;
						case 1:
						{
							int num5;
							if (throwOnError)
							{
								num4 = -603821688;
								num5 = num4;
							}
							else
							{
								num4 = -603821686;
								num5 = num4;
							}
							continue;
						}
						case 2:
							throw;
						default:
							return false;
						}
						break;
					}
				}
			}
			IL_001d:
			while (true)
			{
				switch (num ^ -603821686)
				{
				case 0:
					num = -603821687;
					continue;
				case 4:
					throw new Exception("source.Length + souceStartIndex must be >= bytesToCopy");
				case 1:
					if (destinationStartIndex < 0)
					{
						throw new ArgumentOutOfRangeException("destinationStartIndex");
					}
					break;
				case 6:
					return false;
				case 2:
					break;
				case 3:
					goto end_IL_001d;
				case 5:
					goto IL_00ba;
				case 8:
					goto IL_00c7;
				default:
					goto IL_00dc;
				}
				if (bytesToCopy > source.Length - sourceStartIndex)
				{
					num = -603821682;
					continue;
				}
				goto IL_00ef;
				continue;
				end_IL_001d:
				break;
			}
			goto IL_009c;
		}

		public static bool CopyMemory(IntPtr source, byte[] destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (!throwOnError)
			{
				goto IL_0060;
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			goto IL_00a3;
			IL_00f9:
			bool result;
			try
			{
				if (sourceStartIndex == 0)
				{
					goto IL_00fc;
				}
				goto IL_012f;
				IL_00fc:
				int num = -1833969855;
				goto IL_0101;
				IL_0101:
				while (true)
				{
					switch (num ^ -1833969854)
					{
					case 0:
						break;
					case 3:
						Marshal.Copy(source, destination, destinationStartIndex, bytesToCopy);
						num = -1833969856;
						continue;
					case 1:
						goto IL_012f;
					default:
						result = true;
						goto end_IL_00f9;
					}
					break;
				}
				goto IL_00fc;
				IL_012f:
				Marshal.Copy(OffsetIntPtr(source, sourceStartIndex), destination, destinationStartIndex, bytesToCopy);
				num = -1833969856;
				goto IL_0101;
				end_IL_00f9:;
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
				while (true)
				{
					IL_016f:
					result = false;
					int num2 = -1833969853;
					while (true)
					{
						switch (num2 ^ -1833969854)
						{
						case 0:
							goto IL_0151;
						default:
							goto end_IL_0156;
						case 2:
							break;
						case 1:
							goto end_IL_0156;
						}
						goto IL_016f;
						IL_0151:
						num2 = -1833969856;
						continue;
						end_IL_0156:
						break;
					}
					break;
				}
			}
			return result;
			IL_00a3:
			int num3;
			int num4;
			if (sourceStartIndex >= 0)
			{
				num3 = -1833969853;
				num4 = num3;
			}
			else
			{
				num3 = -1833969851;
				num4 = num3;
			}
			goto IL_001a;
			IL_008e:
			return false;
			IL_00d9:
			if (bytesToCopy > destination.Length - destinationStartIndex)
			{
				throw new Exception("destination.Length + destinationStartIndex must be >= bytesToCopy");
			}
			goto IL_00f9;
			IL_001a:
			while (true)
			{
				switch (num3 ^ -1833969854)
				{
				case 6:
					num3 = -1833969856;
					continue;
				case 8:
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				case 0:
					break;
				case 7:
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				case 3:
					goto IL_008e;
				case 2:
					goto IL_00a3;
				case 1:
					if (destinationStartIndex < 0)
					{
						goto case 8;
					}
					goto IL_00bf;
				case 4:
					goto IL_00d9;
				default:
					return false;
				}
				break;
				IL_00bf:
				int num5;
				if (destinationStartIndex >= destination.Length)
				{
					num3 = -1833969846;
					num5 = num3;
				}
				else
				{
					num3 = -1833969850;
					num5 = num3;
				}
			}
			goto IL_0060;
			IL_0060:
			if (destination == null)
			{
				return false;
			}
			if (sourceStartIndex < 0)
			{
				return false;
			}
			if (destinationStartIndex >= 0)
			{
				if (destinationStartIndex >= destination.Length)
				{
					num3 = -1833969855;
				}
				else
				{
					if (bytesToCopy <= destination.Length - destinationStartIndex)
					{
						goto IL_00f9;
					}
					num3 = -1833969849;
				}
				goto IL_001a;
			}
			goto IL_008e;
		}

		public static bool FillMemory(IntPtr buffer, int length, byte value, bool throwOnError = true)
		{
			return FillMemory(buffer, 0, length, value, throwOnError);
		}

		public static bool FillMemory(IntPtr buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (throwOnError)
			{
				goto IL_0004;
			}
			goto IL_005f;
			IL_0004:
			int num = 643631201;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x265D0869)
				{
				case 5:
					break;
				case 0:
					return false;
				case 2:
					goto IL_005f;
				case 6:
					FeBZMqxddUuJxIOljkVJZmWaOLb = new byte[8];
					num = 643631208;
					continue;
				case 7:
					if (startIndex < 0)
					{
						throw new ArgumentOutOfRangeException("sourceStartIndex");
					}
					goto IL_00b8;
				case 4:
					goto IL_00aa;
				case 3:
					goto IL_00b8;
				case 8:
					if (buffer == IntPtr.Zero)
					{
						throw new ArgumentNullException("buffer");
					}
					goto case 7;
				default:
					goto IL_00f3;
				}
				break;
			}
			goto IL_0004;
			IL_04a6:
			int num2 = default(int);
			short val = default(short);
			Marshal.WriteInt16(buffer, num2 + startIndex, val);
			num2 += 2;
			int num3 = 643631205;
			goto IL_0351;
			IL_005f:
			if (buffer == IntPtr.Zero)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
				num = 643631213;
				goto IL_0009;
			}
			goto IL_00aa;
			IL_00f3:
			bool flag = false;
			int num4 = default(int);
			long val2 = default(long);
			int num7 = default(int);
			if (num4 >= 8)
			{
				lock (FeBZMqxddUuJxIOljkVJZmWaOLb)
				{
					int num5 = 0;
					while (true)
					{
						IL_0142:
						int num6;
						if (num5 >= 8)
						{
							flag = true;
							val2 = BitConverter.ToInt64(FeBZMqxddUuJxIOljkVJZmWaOLb, 0);
							num6 = 643631213;
							goto IL_0112;
						}
						goto IL_0133;
						IL_0112:
						while (true)
						{
							switch (num6 ^ 0x265D0869)
							{
							case 2:
								num6 = 643631210;
								continue;
							case 3:
								goto IL_0133;
							case 1:
								goto IL_0142;
							case 0:
								num5++;
								num6 = 643631208;
								continue;
							case 4:
								break;
							}
							break;
						}
						break;
						IL_0133:
						FeBZMqxddUuJxIOljkVJZmWaOLb[num5] = value;
						num6 = 643631209;
						goto IL_0112;
					}
				}
				num7 = length / 8 * 8;
				goto IL_0177;
			}
			goto IL_01a1;
			IL_0448:
			int num8 = default(int);
			if (num4 >= 8)
			{
				num8 = length / 8 * 8;
				num3 = 643631202;
				goto IL_0351;
			}
			goto IL_03d0;
			IL_0434:
			int num9 = default(int);
			if (num2 >= num9)
			{
				num4 %= 2;
				num3 = 643631226;
				goto IL_0351;
			}
			goto IL_04a6;
			IL_00aa:
			if (length <= 0)
			{
				num = 643631209;
				goto IL_0009;
			}
			goto IL_003f;
			IL_03d0:
			int num10 = default(int);
			if (num4 >= 4)
			{
				num10 = length / 4 * 4;
				num3 = 643631204;
				goto IL_0351;
			}
			goto IL_0467;
			IL_02b7:
			if (num4 < 2)
			{
				goto IL_03bd;
			}
			lock (FeBZMqxddUuJxIOljkVJZmWaOLb)
			{
				if (!flag)
				{
					int num11 = 0;
					while (true)
					{
						IL_0309:
						int num12;
						if (num11 >= 2)
						{
							flag = true;
							num12 = 643631213;
							goto IL_02d8;
						}
						goto IL_02f9;
						IL_02d8:
						while (true)
						{
							switch (num12 ^ 0x265D0869)
							{
							case 0:
								num12 = 643631208;
								continue;
							case 1:
								break;
							case 3:
								goto IL_0309;
							case 2:
								num11++;
								num12 = 643631210;
								continue;
							default:
								goto end_IL_0309;
							}
							break;
						}
						goto IL_02f9;
						IL_02f9:
						FeBZMqxddUuJxIOljkVJZmWaOLb[num11] = value;
						num12 = 643631211;
						goto IL_02d8;
						continue;
						end_IL_0309:
						break;
					}
				}
				val = BitConverter.ToInt16(FeBZMqxddUuJxIOljkVJZmWaOLb, 0);
			}
			num9 = length / 2 * 2;
			num2 = length - num4;
			goto IL_0434;
			IL_03bd:
			int num13 = length - num4;
			num3 = 643631203;
			goto IL_0351;
			IL_0351:
			int num14 = default(int);
			int num15 = default(int);
			int num16 = default(int);
			int num17 = default(int);
			while (true)
			{
				switch (num3 ^ 0x265D0869)
				{
				case 5:
					num3 = 643631214;
					continue;
				case 20:
					break;
				case 3:
					num3 = 643631209;
					continue;
				case 2:
					goto IL_03d0;
				case 11:
					num14 = 0;
					num3 = 643631228;
					continue;
				case 9:
					Marshal.WriteInt64(buffer, num14 + startIndex, 0L);
					num14 += 8;
					num3 = 643631208;
					continue;
				case 13:
					num15 = length - num4;
					num3 = 643631224;
					continue;
				case 1:
					if (num14 >= num8)
					{
						num4 %= 8;
						num3 = 643631211;
						continue;
					}
					goto case 9;
				case 12:
					goto IL_0434;
				case 8:
					goto IL_0448;
				case 19:
					num3 = 643631229;
					continue;
				case 6:
					goto IL_0467;
				case 18:
					num4 %= 2;
					num3 = 643631229;
					continue;
				case 21:
					num3 = 643631208;
					continue;
				case 10:
					num3 = 643631213;
					continue;
				case 7:
					goto IL_04a6;
				case 15:
					Marshal.WriteByte(buffer, num13 + startIndex, value);
					num3 = 643631225;
					continue;
				case 22:
					Marshal.WriteInt16(buffer, num16 + startIndex, 0);
					num16 += 2;
					num3 = 643631209;
					continue;
				case 0:
					goto IL_04f2;
				case 14:
					Marshal.WriteInt32(buffer, num15 + startIndex, 0);
					num15 += 4;
					num3 = 643631224;
					continue;
				case 16:
					num13++;
					num3 = 643631213;
					continue;
				case 17:
					if (num15 >= num10)
					{
						num4 %= 4;
						num3 = 643631215;
						continue;
					}
					goto case 14;
				default:
					if (num13 >= length)
					{
						return true;
					}
					goto case 15;
				}
				break;
				IL_04f2:
				int num18;
				if (num16 < num17)
				{
					num3 = 643631231;
					num18 = num3;
				}
				else
				{
					num3 = 643631227;
					num18 = num3;
				}
			}
			goto IL_03bd;
			IL_00b8:
			if (length <= 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			goto IL_003f;
			IL_003f:
			num4 = length;
			if (value != 0)
			{
				int num19;
				if (FeBZMqxddUuJxIOljkVJZmWaOLb == null)
				{
					num = 643631215;
					num19 = num;
				}
				else
				{
					num = 643631208;
					num19 = num;
				}
				goto IL_0009;
			}
			goto IL_0448;
			IL_0177:
			int num20 = 643631213;
			goto IL_017c;
			IL_01a1:
			if (num4 >= 4)
			{
				num20 = 643631211;
				goto IL_017c;
			}
			goto IL_02b7;
			IL_017c:
			int num21 = default(int);
			while (true)
			{
				switch (num20 ^ 0x265D0869)
				{
				case 3:
					break;
				case 1:
					goto IL_01a1;
				case 0:
					Marshal.WriteInt64(buffer, num21 + startIndex, val2);
					num21 += 8;
					num20 = 643631212;
					continue;
				case 5:
					if (num21 >= num7)
					{
						num4 %= 8;
						num20 = 643631208;
						continue;
					}
					goto case 0;
				case 4:
					num21 = 0;
					num20 = 643631212;
					continue;
				default:
					goto IL_01e2;
				}
				break;
			}
			goto IL_0177;
			IL_0467:
			if (num4 >= 2)
			{
				num17 = length / 2 * 2;
				num16 = length - num4;
				num3 = 643631210;
				goto IL_0351;
			}
			goto IL_03bd;
			IL_01e2:
			int val3;
			lock (FeBZMqxddUuJxIOljkVJZmWaOLb)
			{
				if (!flag)
				{
					int num22 = 0;
					while (true)
					{
						IL_022f:
						int num23;
						if (num22 >= 4)
						{
							flag = true;
							num23 = 643631209;
							goto IL_01fc;
						}
						goto IL_0219;
						IL_01fc:
						while (true)
						{
							switch (num23 ^ 0x265D0869)
							{
							case 2:
								num23 = 643631208;
								continue;
							case 1:
								break;
							case 3:
								goto IL_022f;
							default:
								goto end_IL_022f;
							}
							break;
						}
						goto IL_0219;
						IL_0219:
						FeBZMqxddUuJxIOljkVJZmWaOLb[num22] = value;
						num22++;
						num23 = 643631210;
						goto IL_01fc;
						continue;
						end_IL_022f:
						break;
					}
				}
				val3 = BitConverter.ToInt32(FeBZMqxddUuJxIOljkVJZmWaOLb, 0);
			}
			int num24 = length / 4 * 4;
			int num26 = default(int);
			while (true)
			{
				int num25 = 643631208;
				while (true)
				{
					switch (num25 ^ 0x265D0869)
					{
					case 3:
						break;
					case 2:
						if (num26 >= num24)
						{
							num4 %= 4;
							num25 = 643631213;
							continue;
						}
						goto case 0;
					case 0:
						Marshal.WriteInt32(buffer, num26 + startIndex, val3);
						num26 += 4;
						num25 = 643631211;
						continue;
					case 1:
						num26 = length - num4;
						num25 = 643631211;
						continue;
					default:
						goto end_IL_025b;
					}
					break;
				}
				continue;
				end_IL_025b:
				break;
			}
			goto IL_02b7;
		}

		public static bool FillMemory(byte[] buffer, int length, byte value, bool throwOnError = true)
		{
			return FillMemory(buffer, 0, length, value, throwOnError);
		}

		public static bool FillMemory(byte[] buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				goto IL_0052;
			}
			goto IL_00d3;
			IL_00d3:
			int num;
			if (buffer != null)
			{
				int num2;
				if (startIndex >= 0)
				{
					num = 1781592322;
					num2 = num;
				}
				else
				{
					num = 1781592333;
					num2 = num;
				}
			}
			else
			{
				num = 1781592329;
			}
			goto IL_001a;
			IL_0052:
			if (startIndex >= 0)
			{
				int num3;
				if (startIndex >= buffer.Length)
				{
					num = 1781592334;
					num3 = num;
				}
				else
				{
					num = 1781592330;
					num3 = num;
				}
				goto IL_001a;
			}
			goto IL_0099;
			IL_001a:
			bool flag = default(bool);
			bool result = default(bool);
			while (true)
			{
				switch (num ^ 0x6A30F10B)
				{
				case 4:
					num = 1781592328;
					continue;
				case 3:
					break;
				case 2:
					return false;
				case 6:
					return false;
				case 5:
					goto IL_0099;
				case 0:
					throw new ArgumentOutOfRangeException("length");
				case 9:
					goto IL_00c3;
				case 8:
					goto IL_00d3;
				case 1:
					if (length < 0)
					{
						goto case 0;
					}
					goto IL_00e4;
				default:
					goto IL_00f6;
				}
				break;
				IL_00e4:
				if (length + startIndex > buffer.Length)
				{
					num = 1781592331;
					continue;
				}
				goto IL_00f8;
				IL_00f6:
				return false;
				IL_00c3:
				if (startIndex < buffer.Length)
				{
					if (length < 0)
					{
						goto IL_00f6;
					}
					if (length + startIndex > buffer.Length)
					{
						num = 1781592332;
						continue;
					}
					goto IL_00f8;
				}
				num = 1781592333;
				continue;
				IL_00f8:
				try
				{
					lock (buffer)
					{
						GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
						while (true)
						{
							IL_0108:
							int num4 = 1781592330;
							while (true)
							{
								switch (num4 ^ 0x6A30F10B)
								{
								case 0:
									break;
								default:
									goto end_IL_010d;
								case 1:
									goto IL_0126;
								case 2:
									goto end_IL_010d;
								}
								goto IL_0108;
								IL_0126:
								flag = FillMemory(gCHandle.AddrOfPinnedObject(), startIndex, length, value, throwOnError);
								gCHandle.Free();
								num4 = 1781592329;
								continue;
								end_IL_010d:
								break;
							}
							break;
						}
					}
					result = flag;
				}
				catch
				{
					if (throwOnError)
					{
						goto IL_0158;
					}
					goto IL_0183;
					IL_0158:
					int num5 = 1781592330;
					goto IL_015d;
					IL_015d:
					switch (num5 ^ 0x6A30F10B)
					{
					case 0:
						break;
					default:
						goto end_IL_0153;
					case 1:
						throw;
					case 2:
						goto IL_0183;
					case 3:
						goto end_IL_0153;
					}
					goto IL_0158;
					IL_0183:
					result = false;
					num5 = 1781592328;
					goto IL_015d;
					end_IL_0153:;
				}
				return result;
			}
			goto IL_0052;
			IL_0099:
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public static void ZeroFillMemory(IntPtr buffer, int length)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			int num3 = default(int);
			int num9 = default(int);
			int num8 = default(int);
			int num11 = default(int);
			int num4 = default(int);
			int num5 = default(int);
			int num7 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (length >= 0)
				{
					num = 1207081251;
					num2 = num;
				}
				else
				{
					num = 1207081254;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x47F2992B)
					{
					case 7:
						num = 1207081262;
						continue;
					default:
						return;
					case 12:
						num3 %= 2;
						num = 1207081259;
						continue;
					case 13:
						throw new ArgumentOutOfRangeException("length");
					case 14:
						if (num3 >= 2)
						{
							num9 = length / 2 * 2;
							num8 = length - num3;
							num = 1207081278;
							continue;
						}
						goto case 0;
					case 18:
						Marshal.WriteByte(buffer, num11, 0);
						num11++;
						num = 1207081257;
						continue;
					case 1:
						Marshal.WriteInt16(buffer, num8, 0);
						num = 1207081279;
						continue;
					case 6:
						num = 1207081263;
						continue;
					case 11:
					{
						int num13;
						if (num3 >= 4)
						{
							num = 1207081252;
							num13 = num;
						}
						else
						{
							num = 1207081253;
							num13 = num;
						}
						continue;
					}
					case 2:
					{
						int num12;
						if (num11 >= length)
						{
							num = 1207081275;
							num12 = num;
						}
						else
						{
							num = 1207081273;
							num12 = num;
						}
						continue;
					}
					case 19:
					{
						int num10;
						if (num8 < num9)
						{
							num = 1207081258;
							num10 = num;
						}
						else
						{
							num = 1207081255;
							num10 = num;
						}
						continue;
					}
					case 20:
						num8 += 2;
						num = 1207081272;
						continue;
					case 17:
						Marshal.WriteInt64(buffer, num4, 0L);
						num4 += 8;
						num = 1207081256;
						continue;
					case 10:
						if (num3 >= 8)
						{
							num5 = length / 8 * 8;
							num4 = 0;
							num = 1207081256;
							continue;
						}
						goto case 11;
					case 15:
						num7 = length / 4 * 4;
						num6 = length - num3;
						num = 1207081261;
						continue;
					case 4:
						if (num6 >= num7)
						{
							num3 %= 4;
							num = 1207081253;
							continue;
						}
						goto case 9;
					case 9:
						Marshal.WriteInt32(buffer, num6, 0);
						num6 += 4;
						num = 1207081263;
						continue;
					case 3:
						if (num4 >= num5)
						{
							num3 %= 8;
							num = 1207081248;
							continue;
						}
						goto case 17;
					case 0:
						num11 = length - num3;
						num = 1207081257;
						continue;
					case 21:
						num = 1207081272;
						continue;
					case 5:
						break;
					case 8:
						num3 = length;
						num = 1207081249;
						continue;
					case 16:
						return;
					}
					break;
				}
			}
		}

		public static string DumpToString(IntPtr buffer, int length, string stringFormat = "x2")
		{
			if (buffer == IntPtr.Zero)
			{
				return "Invalid buffer!";
			}
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				while (num < length)
				{
					while (true)
					{
						stringBuilder.Append(Marshal.ReadByte(buffer, num).ToString(stringFormat));
						int num2;
						if (num < length - 1)
						{
							stringBuilder.Append(", ");
							num2 = 1943533845;
							goto IL_0022;
						}
						goto IL_006f;
						IL_0022:
						while (true)
						{
							switch (num2 ^ 0x73D7F916)
							{
							case 0:
								num2 = 1943533847;
								continue;
							case 1:
								break;
							case 3:
								goto IL_006f;
							default:
								goto end_IL_003f;
							}
							break;
						}
						continue;
						IL_006f:
						num++;
						num2 = 1943533844;
						goto IL_0022;
						continue;
						end_IL_003f:
						break;
					}
				}
				return stringBuilder.ToString();
			}
			catch
			{
				return "Exception!";
			}
		}

		public static void FreeHGlobalSafe(ref IntPtr pointer)
		{
			if (!(pointer == IntPtr.Zero))
			{
				try
				{
					Marshal.FreeHGlobal(pointer);
				}
				catch
				{
				}
				pointer = IntPtr.Zero;
			}
		}
	}
}
