using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class NativeTools
	{
		private static byte[] eFVjRjCLzMxqInowLmTRDuAgWEmj;

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
				goto IL_00c4;
			}
			if (source == IntPtr.Zero)
			{
				goto IL_0017;
			}
			goto IL_00e5;
			IL_0144:
			bool result = default(bool);
			try
			{
				int num = bytesToCopy;
				int num6 = default(int);
				int num3 = default(int);
				int num9 = default(int);
				int num7 = default(int);
				int num8 = default(int);
				int num4 = default(int);
				int num5 = default(int);
				while (true)
				{
					IL_0147:
					int num2 = 1860721827;
					while (true)
					{
						switch (num2 ^ 0x6EE85CA1)
						{
						case 15:
							break;
						default:
							goto end_IL_014c;
						case 2:
							if (num >= 8)
							{
								num6 = bytesToCopy / 8 * 8;
								num2 = 1860721833;
								continue;
							}
							goto case 12;
						case 11:
							Marshal.WriteInt64(destination, num3 + destinationStartIndex, Marshal.ReadInt64(source, num3 + sourceStartIndex));
							num3 += 8;
							num2 = 1860721840;
							continue;
						case 6:
							if (num9 >= bytesToCopy)
							{
								result = true;
								num2 = 1860721832;
								continue;
							}
							goto case 13;
						case 10:
							num2 = 1860721840;
							continue;
						case 4:
							if (num7 >= num8)
							{
								num %= 4;
								num2 = 1860721839;
								continue;
							}
							goto case 3;
						case 0:
							Marshal.WriteInt16(destination, num4 + destinationStartIndex, Marshal.ReadInt16(source, num4 + sourceStartIndex));
							num4 += 2;
							num2 = 1860721830;
							continue;
						case 16:
							num7 = bytesToCopy - num;
							num2 = 1860721829;
							continue;
						case 14:
							if (num >= 2)
							{
								num5 = bytesToCopy / 2 * 2;
								num4 = bytesToCopy - num;
								num2 = 1860721828;
								continue;
							}
							goto case 1;
						case 5:
							num2 = 1860721830;
							continue;
						case 17:
							if (num3 >= num6)
							{
								num %= 8;
								num2 = 1860721837;
								continue;
							}
							goto case 11;
						case 7:
							if (num4 >= num5)
							{
								num %= 2;
								num2 = 1860721824;
								continue;
							}
							goto case 0;
						case 1:
							num9 = bytesToCopy - num;
							num2 = 1860721831;
							continue;
						case 3:
							Marshal.WriteInt32(destination, num7 + destinationStartIndex, Marshal.ReadInt32(source, num7 + sourceStartIndex));
							num7 += 4;
							num2 = 1860721829;
							continue;
						case 13:
							Marshal.WriteByte(destination, num9 + destinationStartIndex, Marshal.ReadByte(source, num9 + sourceStartIndex));
							num9++;
							num2 = 1860721831;
							continue;
						case 12:
							if (num >= 4)
							{
								num8 = bytesToCopy / 4 * 4;
								num2 = 1860721841;
								continue;
							}
							goto case 14;
						case 8:
							num3 = 0;
							num2 = 1860721835;
							continue;
						case 9:
							goto end_IL_014c;
						}
						goto IL_0147;
						continue;
						end_IL_014c:
						break;
					}
					break;
				}
			}
			catch
			{
				while (true)
				{
					IL_0311:
					int num10 = 1860721824;
					while (true)
					{
						switch (num10 ^ 0x6EE85CA1)
						{
						case 0:
							break;
						case 1:
						{
							int num11;
							if (throwOnError)
							{
								num10 = 1860721827;
								num11 = num10;
							}
							else
							{
								num10 = 1860721826;
								num11 = num10;
							}
							continue;
						}
						case 2:
							throw;
						default:
							result = false;
							goto end_IL_0316;
						}
						goto IL_0311;
						continue;
						end_IL_0316:
						break;
					}
					break;
				}
			}
			return result;
			IL_0017:
			int num12 = 1860721832;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num12 ^ 0x6EE85CA1)
				{
				case 4:
					break;
				case 3:
					goto IL_0058;
				case 5:
					return false;
				case 10:
					goto IL_0082;
				case 7:
					goto IL_0093;
				case 9:
					throw new ArgumentNullException("source");
				case 1:
					goto IL_00c4;
				case 2:
					goto IL_00e5;
				case 6:
					goto IL_0107;
				case 0:
					goto IL_0121;
				default:
					goto IL_013d;
				}
				break;
				IL_0107:
				if (!(destination == IntPtr.Zero))
				{
					if (sourceStartIndex < 0)
					{
						sourceStartIndex = 0;
						num12 = 1860721835;
						continue;
					}
					goto IL_0082;
				}
				num12 = 1860721828;
				continue;
				IL_0082:
				if (destinationStartIndex < 0)
				{
					destinationStartIndex = 0;
					num12 = 1860721833;
					continue;
				}
				goto IL_013d;
			}
			goto IL_0017;
			IL_00c4:
			int num13;
			if (source == IntPtr.Zero)
			{
				num12 = 1860721828;
				num13 = num12;
			}
			else
			{
				num12 = 1860721831;
				num13 = num12;
			}
			goto IL_001c;
			IL_013d:
			if (bytesToCopy <= 0)
			{
				return false;
			}
			goto IL_0144;
			IL_0121:
			if (destinationStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex");
			}
			goto IL_0058;
			IL_00e5:
			if (destination == IntPtr.Zero)
			{
				throw new ArgumentNullException("destination");
			}
			goto IL_0093;
			IL_0093:
			if (sourceStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex");
			}
			goto IL_0121;
			IL_0058:
			if (bytesToCopy <= 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			goto IL_0144;
		}

		public static bool CopyMemory(byte[] source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (source == null)
				{
					goto IL_000d;
				}
				goto IL_00b2;
			}
			goto IL_00d0;
			IL_00b2:
			int num;
			if (sourceStartIndex >= 0)
			{
				int num2;
				if (sourceStartIndex < source.Length)
				{
					num = 662110068;
					num2 = num;
				}
				else
				{
					num = 662110064;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_00f2;
			IL_000d:
			num = 662110069;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2776FF77)
				{
				case 8:
					break;
				case 5:
					goto IL_004e;
				case 0:
					return false;
				case 4:
					goto IL_0071;
				case 3:
					if (destinationStartIndex < 0)
					{
						throw new ArgumentOutOfRangeException("destinationStartIndex");
					}
					goto IL_0071;
				case 2:
					throw new ArgumentNullException("source");
				case 9:
					goto IL_00b2;
				case 6:
					goto IL_00d0;
				case 10:
					throw new Exception("source.Length + souceStartIndex must be >= bytesToCopy");
				case 7:
					goto IL_00f2;
				default:
					return false;
				}
				break;
				IL_0071:
				if (bytesToCopy > source.Length - sourceStartIndex)
				{
					num = 662110077;
					continue;
				}
				goto IL_0114;
			}
			goto IL_000d;
			IL_00f2:
			throw new ArgumentOutOfRangeException("sourceStartIndex");
			IL_0114:
			bool result = default(bool);
			try
			{
				if (destinationStartIndex != 0)
				{
					goto IL_0145;
				}
				Marshal.Copy(source, sourceStartIndex, destination, bytesToCopy);
				goto IL_015c;
				IL_0145:
				Marshal.Copy(source, sourceStartIndex, OffsetIntPtr(destination, destinationStartIndex), bytesToCopy);
				int num3 = 662110069;
				goto IL_0128;
				IL_015c:
				result = true;
				num3 = 662110070;
				goto IL_0128;
				IL_0128:
				while (true)
				{
					switch (num3 ^ 0x2776FF77)
					{
					case 0:
						num3 = 662110068;
						continue;
					case 3:
						goto IL_0145;
					case 2:
						goto IL_015c;
					case 1:
						break;
					}
					break;
				}
			}
			catch
			{
				if (throwOnError)
				{
					goto IL_016c;
				}
				goto IL_0197;
				IL_016c:
				int num4 = 662110070;
				goto IL_0171;
				IL_0171:
				switch (num4 ^ 0x2776FF77)
				{
				case 3:
					break;
				default:
					goto end_IL_0167;
				case 1:
					throw;
				case 0:
					goto IL_0197;
				case 2:
					goto end_IL_0167;
				}
				goto IL_016c;
				IL_0197:
				result = false;
				num4 = 662110069;
				goto IL_0171;
				end_IL_0167:;
			}
			return result;
			IL_00d0:
			if (source != null)
			{
				if (sourceStartIndex < 0)
				{
					goto IL_004e;
				}
				if (sourceStartIndex < source.Length)
				{
					if (destinationStartIndex >= 0)
					{
						if (bytesToCopy > source.Length - sourceStartIndex)
						{
							return false;
						}
						goto IL_0114;
					}
					num = 662110070;
				}
				else
				{
					num = 662110066;
				}
			}
			else
			{
				num = 662110071;
			}
			goto IL_0012;
			IL_004e:
			return false;
		}

		public static bool CopyMemory(IntPtr source, byte[] destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				goto IL_00ec;
			}
			goto IL_0108;
			IL_0108:
			if (destination == null)
			{
				return false;
			}
			int num;
			if (sourceStartIndex >= 0)
			{
				int num2;
				if (destinationStartIndex >= 0)
				{
					num = 838149070;
					num2 = num;
				}
				else
				{
					num = 838149069;
					num2 = num;
				}
			}
			else
			{
				num = 838149066;
			}
			goto IL_001d;
			IL_00ec:
			if (sourceStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex");
			}
			goto IL_006c;
			IL_006c:
			int num3;
			if (destinationStartIndex < 0)
			{
				num = 838149071;
				num3 = num;
			}
			else
			{
				num = 838149065;
				num3 = num;
			}
			goto IL_001d;
			IL_001d:
			while (true)
			{
				switch (num ^ 0x31F523CA)
				{
				case 6:
					num = 838149067;
					continue;
				case 10:
					break;
				case 2:
					goto end_IL_001d;
				case 3:
					goto IL_0081;
				case 5:
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				case 4:
					goto IL_00ad;
				case 8:
					throw new Exception("destination.Length + destinationStartIndex must be >= bytesToCopy");
				case 0:
					return false;
				case 1:
					goto IL_00ec;
				case 9:
					goto IL_0108;
				default:
					return false;
				}
				if (bytesToCopy > destination.Length - destinationStartIndex)
				{
					num = 838149058;
					continue;
				}
				goto IL_0128;
				IL_00ad:
				if (destinationStartIndex >= destination.Length)
				{
					num = 838149069;
					continue;
				}
				if (bytesToCopy > destination.Length - destinationStartIndex)
				{
					return false;
				}
				goto IL_0128;
				IL_0081:
				int num4;
				if (destinationStartIndex >= destination.Length)
				{
					num = 838149071;
					num4 = num;
				}
				else
				{
					num = 838149056;
					num4 = num;
				}
				continue;
				IL_0128:
				try
				{
					if (sourceStartIndex == 0)
					{
						Marshal.Copy(source, destination, destinationStartIndex, bytesToCopy);
					}
					else
					{
						while (true)
						{
							Marshal.Copy(OffsetIntPtr(source, sourceStartIndex), destination, destinationStartIndex, bytesToCopy);
							int num5 = 838149067;
							while (true)
							{
								switch (num5 ^ 0x31F523CA)
								{
								case 0:
									num5 = 838149064;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0155;
								}
								break;
							}
							continue;
							end_IL_0155:
							break;
						}
					}
					return true;
				}
				catch
				{
					if (throwOnError)
					{
						throw;
					}
					return false;
				}
				continue;
				end_IL_001d:
				break;
			}
			goto IL_006c;
		}

		public static bool FillMemory(IntPtr buffer, int length, byte value, bool throwOnError = true)
		{
			return FillMemory(buffer, 0, length, value, throwOnError);
		}

		public static bool FillMemory(IntPtr buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (buffer == IntPtr.Zero)
				{
					throw new ArgumentNullException("buffer");
				}
				goto IL_007e;
			}
			goto IL_00ba;
			IL_016f:
			int num;
			while (true)
			{
				switch (num ^ 0x435BAA37)
				{
				case 4:
					num = 1130080822;
					continue;
				case 1:
					break;
				case 2:
					goto IL_01a8;
				case 0:
					goto IL_01b6;
				default:
					goto IL_01c7;
				}
				break;
			}
			goto IL_0190;
			IL_007e:
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex");
			}
			goto IL_005d;
			IL_005d:
			if (length <= 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			goto IL_0096;
			IL_0096:
			int num2 = length;
			int num3;
			if (value != 0)
			{
				if (eFVjRjCLzMxqInowLmTRDuAgWEmj == null)
				{
					eFVjRjCLzMxqInowLmTRDuAgWEmj = new byte[8];
					num3 = 1130080817;
					goto IL_0024;
				}
				goto IL_0054;
			}
			goto IL_0518;
			IL_03f2:
			int num4 = length - num2;
			int num5 = 1130080820;
			goto IL_034c;
			IL_03b0:
			int num6 = default(int);
			if (num2 >= 4)
			{
				num6 = length / 4 * 4;
				num5 = 1130080824;
				goto IL_034c;
			}
			goto IL_0401;
			IL_0024:
			while (true)
			{
				switch (num3 ^ 0x435BAA37)
				{
				case 3:
					num3 = 1130080822;
					continue;
				case 6:
					break;
				case 2:
					goto IL_005d;
				case 5:
					goto IL_0073;
				case 1:
					goto IL_007e;
				case 0:
					return false;
				case 4:
					goto IL_00ba;
				default:
					goto IL_00da;
				}
				break;
			}
			goto IL_0054;
			IL_0190:
			int num7 = default(int);
			long val = default(long);
			Marshal.WriteInt64(buffer, num7 + startIndex, val);
			num7 += 8;
			num = 1130080823;
			goto IL_016f;
			IL_034c:
			int num8 = default(int);
			int num9 = default(int);
			int num12 = default(int);
			int num10 = default(int);
			int num11 = default(int);
			while (true)
			{
				switch (num5 ^ 0x435BAA37)
				{
				case 0:
					num5 = 1130080830;
					continue;
				case 14:
					break;
				case 4:
					num8 += 4;
					num5 = 1130080816;
					continue;
				case 19:
					num9 = length / 2 * 2;
					num5 = 1130080817;
					continue;
				case 15:
					num8 = length - num2;
					num5 = 1130080816;
					continue;
				case 8:
					goto IL_03f2;
				case 12:
					goto IL_0401;
				case 16:
					goto IL_0419;
				case 1:
					Marshal.WriteInt16(buffer, num12 + startIndex, 0);
					num12 += 2;
					num5 = 1130080826;
					continue;
				case 11:
					num5 = 1130080818;
					continue;
				case 13:
					if (num12 >= num9)
					{
						num2 %= 2;
						num5 = 1130080831;
						continue;
					}
					goto case 1;
				case 2:
					Marshal.WriteInt32(buffer, num8 + startIndex, 0);
					num5 = 1130080819;
					continue;
				case 17:
					Marshal.WriteByte(buffer, num4 + startIndex, value);
					num4++;
					num5 = 1130080820;
					continue;
				case 6:
					num12 = length - num2;
					num5 = 1130080826;
					continue;
				case 10:
					Marshal.WriteInt64(buffer, num10 + startIndex, 0L);
					num10 += 8;
					num5 = 1130080818;
					continue;
				case 9:
					goto IL_04c4;
				case 20:
					num10 = 0;
					num5 = 1130080828;
					continue;
				case 5:
					if (num10 >= num11)
					{
						num2 %= 8;
						num5 = 1130080825;
						continue;
					}
					goto case 10;
				case 7:
					if (num8 >= num6)
					{
						num2 %= 4;
						num5 = 1130080827;
						continue;
					}
					goto case 2;
				case 18:
					goto IL_0518;
				default:
					if (num4 >= length)
					{
						return true;
					}
					goto case 17;
				}
				break;
			}
			goto IL_03b0;
			IL_00ba:
			if (buffer == IntPtr.Zero)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
				num3 = 1130080818;
				goto IL_0024;
			}
			goto IL_0073;
			IL_0401:
			int num13;
			if (num2 >= 2)
			{
				num5 = 1130080804;
				num13 = num5;
			}
			else
			{
				num5 = 1130080831;
				num13 = num5;
			}
			goto IL_034c;
			IL_0518:
			if (num2 >= 8)
			{
				num11 = length / 8 * 8;
				num5 = 1130080803;
				goto IL_034c;
			}
			goto IL_03b0;
			IL_01a8:
			if (num2 >= 4)
			{
				num = 1130080820;
				goto IL_016f;
			}
			goto IL_029e;
			IL_0073:
			if (length <= 0)
			{
				num3 = 1130080823;
				goto IL_0024;
			}
			goto IL_0096;
			IL_01c7:
			int val2;
			bool flag = default(bool);
			lock (eFVjRjCLzMxqInowLmTRDuAgWEmj)
			{
				if (!flag)
				{
					int num14 = 0;
					while (true)
					{
						IL_0214:
						int num15;
						if (num14 >= 4)
						{
							flag = true;
							num15 = 1130080823;
							goto IL_01e1;
						}
						goto IL_01fe;
						IL_01e1:
						while (true)
						{
							switch (num15 ^ 0x435BAA37)
							{
							case 2:
								num15 = 1130080822;
								continue;
							case 1:
								break;
							case 3:
								goto IL_0214;
							default:
								goto end_IL_0214;
							}
							break;
						}
						goto IL_01fe;
						IL_01fe:
						eFVjRjCLzMxqInowLmTRDuAgWEmj[num14] = value;
						num14++;
						num15 = 1130080820;
						goto IL_01e1;
						continue;
						end_IL_0214:
						break;
					}
				}
				val2 = BitConverter.ToInt32(eFVjRjCLzMxqInowLmTRDuAgWEmj, 0);
			}
			int num16 = length / 4 * 4;
			int num17 = length - num2;
			while (true)
			{
				int num18;
				if (num17 >= num16)
				{
					num2 %= 4;
					num18 = 1130080820;
					goto IL_024c;
				}
				goto IL_028b;
				IL_024c:
				while (true)
				{
					switch (num18 ^ 0x435BAA37)
					{
					case 0:
						num18 = 1130080822;
						continue;
					case 2:
						break;
					case 4:
						num17 += 4;
						num18 = 1130080821;
						continue;
					case 1:
						goto IL_028b;
					default:
						goto end_IL_026d;
					}
					break;
				}
				continue;
				IL_028b:
				Marshal.WriteInt32(buffer, num17 + startIndex, val2);
				num18 = 1130080819;
				goto IL_024c;
				continue;
				end_IL_026d:
				break;
			}
			goto IL_029e;
			IL_0054:
			flag = false;
			num3 = 1130080816;
			goto IL_0024;
			IL_00da:
			if (num2 < 8)
			{
				goto IL_01a8;
			}
			lock (eFVjRjCLzMxqInowLmTRDuAgWEmj)
			{
				int num19 = 0;
				while (true)
				{
					IL_00f0:
					int num20 = 1130080822;
					while (true)
					{
						switch (num20 ^ 0x435BAA37)
						{
						case 0:
							break;
						default:
							goto end_IL_00f5;
						case 3:
							num19++;
							num20 = 1130080818;
							continue;
						case 5:
							if (num19 >= 8)
							{
								flag = true;
								val = BitConverter.ToInt64(eFVjRjCLzMxqInowLmTRDuAgWEmj, 0);
								num20 = 1130080819;
								continue;
							}
							goto case 2;
						case 1:
							num20 = 1130080818;
							continue;
						case 2:
							eFVjRjCLzMxqInowLmTRDuAgWEmj[num19] = value;
							num20 = 1130080820;
							continue;
						case 4:
							goto end_IL_00f5;
						}
						goto IL_00f0;
						continue;
						end_IL_00f5:
						break;
					}
					break;
				}
			}
			int num21 = length / 8 * 8;
			num7 = 0;
			goto IL_01b6;
			IL_04c4:
			int num22 = default(int);
			short val3 = default(short);
			Marshal.WriteInt16(buffer, num22 + startIndex, val3);
			num22 += 2;
			num5 = 1130080807;
			goto IL_034c;
			IL_0419:
			int num23 = default(int);
			if (num22 >= num23)
			{
				num2 %= 2;
				num5 = 1130080831;
				goto IL_034c;
			}
			goto IL_04c4;
			IL_01b6:
			if (num7 >= num21)
			{
				num2 %= 8;
				num = 1130080821;
				goto IL_016f;
			}
			goto IL_0190;
			IL_029e:
			if (num2 < 2)
			{
				goto IL_03f2;
			}
			lock (eFVjRjCLzMxqInowLmTRDuAgWEmj)
			{
				int num24 = default(int);
				if (!flag)
				{
					num24 = 0;
					goto IL_02b8;
				}
				goto IL_02e6;
				IL_02e6:
				val3 = BitConverter.ToInt16(eFVjRjCLzMxqInowLmTRDuAgWEmj, 0);
				int num25 = 1130080819;
				goto IL_02bd;
				IL_02b8:
				num25 = 1130080822;
				goto IL_02bd;
				IL_02bd:
				while (true)
				{
					switch (num25 ^ 0x435BAA37)
					{
					case 0:
						break;
					default:
						goto end_IL_02b2;
					case 3:
						goto IL_02e6;
					case 5:
						eFVjRjCLzMxqInowLmTRDuAgWEmj[num24] = value;
						num25 = 1130080821;
						continue;
					case 2:
						num24++;
						num25 = 1130080817;
						continue;
					case 1:
						num25 = 1130080817;
						continue;
					case 6:
						if (num24 >= 2)
						{
							flag = true;
							num25 = 1130080820;
							continue;
						}
						goto case 5;
					case 4:
						goto end_IL_02b2;
					}
					break;
				}
				goto IL_02b8;
				end_IL_02b2:;
			}
			num23 = length / 2 * 2;
			num22 = length - num2;
			goto IL_0419;
		}

		public static bool FillMemory(byte[] buffer, int length, byte value, bool throwOnError = true)
		{
			return FillMemory(buffer, 0, length, value, throwOnError);
		}

		public static bool FillMemory(byte[] buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (!throwOnError)
			{
				goto IL_004b;
			}
			if (buffer == null)
			{
				goto IL_000a;
			}
			goto IL_008c;
			IL_008c:
			int num;
			if (startIndex >= 0)
			{
				int num2;
				if (startIndex >= buffer.Length)
				{
					num = 217501920;
					num2 = num;
				}
				else
				{
					num = 217501921;
					num2 = num;
				}
				goto IL_000f;
			}
			goto IL_00d4;
			IL_000a:
			num = 217501929;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ 0xCF6D0E8)
				{
				case 10:
					break;
				case 7:
					goto IL_004b;
				case 9:
					goto IL_0065;
				case 6:
					throw new ArgumentOutOfRangeException("length");
				case 2:
					goto IL_008c;
				case 0:
					return false;
				case 4:
					goto IL_00c2;
				case 8:
					goto IL_00d4;
				case 5:
					goto IL_00e9;
				case 1:
					throw new ArgumentNullException("buffer");
				default:
					goto IL_010e;
				}
				break;
				IL_00e9:
				if (startIndex < buffer.Length)
				{
					if (length < 0)
					{
						goto IL_010e;
					}
					if (length + startIndex > buffer.Length)
					{
						num = 217501931;
						continue;
					}
					goto IL_0110;
				}
				num = 217501928;
				continue;
				IL_010e:
				return false;
				IL_00c2:
				if (length + startIndex > buffer.Length)
				{
					num = 217501934;
					continue;
				}
				goto IL_0110;
				IL_0065:
				int num3;
				if (length >= 0)
				{
					num = 217501932;
					num3 = num;
				}
				else
				{
					num = 217501934;
					num3 = num;
				}
				continue;
				IL_0110:
				try
				{
					bool result;
					lock (buffer)
					{
						GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
						result = FillMemory(gCHandle.AddrOfPinnedObject(), startIndex, length, value, throwOnError);
						gCHandle.Free();
					}
					return result;
				}
				catch
				{
					if (throwOnError)
					{
						throw;
					}
					return false;
				}
			}
			goto IL_000a;
			IL_004b:
			if (buffer == null)
			{
				return false;
			}
			int num4;
			if (startIndex < 0)
			{
				num = 217501928;
				num4 = num;
			}
			else
			{
				num = 217501933;
				num4 = num;
			}
			goto IL_000f;
			IL_00d4:
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public static void ZeroFillMemory(IntPtr buffer, int length)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			int num2 = default(int);
			int num3 = default(int);
			int num6 = default(int);
			int num7 = default(int);
			int num9 = default(int);
			int num10 = default(int);
			int num8 = default(int);
			while (length >= 0)
			{
				while (true)
				{
					IL_00ed:
					int num = length;
					int num4;
					if (num >= 8)
					{
						num2 = length / 8 * 8;
						num3 = 0;
						num4 = -1683859234;
						goto IL_0020;
					}
					goto IL_00d4;
					IL_0150:
					int num5;
					if (num >= 2)
					{
						num4 = -1683859250;
						num5 = num4;
					}
					else
					{
						num4 = -1683859249;
						num5 = num4;
					}
					goto IL_0020;
					IL_00d4:
					if (num >= 4)
					{
						num6 = length / 4 * 4;
						num7 = length - num;
						num4 = -1683859252;
						goto IL_0020;
					}
					goto IL_0150;
					IL_0020:
					while (true)
					{
						switch (num4 ^ -1683859234)
						{
						case 5:
							num4 = -1683859245;
							continue;
						default:
							return;
						case 2:
							Marshal.WriteInt16(buffer, num9, 0);
							num9 += 2;
							num4 = -1683859246;
							continue;
						case 10:
							num %= 4;
							num4 = -1683859243;
							continue;
						case 7:
							break;
						case 1:
							Marshal.WriteInt64(buffer, num3, 0L);
							num3 += 8;
							num4 = -1683859234;
							continue;
						case 15:
							goto end_IL_0020;
						case 6:
							goto IL_00ed;
						case 13:
							goto end_IL_00ed;
						case 3:
							Marshal.WriteByte(buffer, num10, 0);
							num10++;
							num4 = -1683859239;
							continue;
						case 18:
							goto IL_0137;
						case 11:
							goto IL_0150;
						case 12:
							goto IL_0168;
						case 8:
							num %= 2;
							num4 = -1683859249;
							continue;
						case 19:
							num %= 8;
							num4 = -1683859247;
							continue;
						case 14:
							num4 = -1683859239;
							continue;
						case 0:
							goto IL_01a8;
						case 4:
							Marshal.WriteInt32(buffer, num7, 0);
							num7 += 4;
							num4 = -1683859252;
							continue;
						case 17:
							num10 = length - num;
							num4 = -1683859248;
							continue;
						case 16:
							num8 = length / 2 * 2;
							num9 = length - num;
							num4 = -1683859246;
							continue;
						case 9:
							return;
						}
						int num11;
						if (num10 >= length)
						{
							num4 = -1683859241;
							num11 = num4;
						}
						else
						{
							num4 = -1683859235;
							num11 = num4;
						}
						continue;
						IL_01a8:
						int num12;
						if (num3 < num2)
						{
							num4 = -1683859233;
							num12 = num4;
						}
						else
						{
							num4 = -1683859251;
							num12 = num4;
						}
						continue;
						IL_0137:
						int num13;
						if (num7 >= num6)
						{
							num4 = -1683859244;
							num13 = num4;
						}
						else
						{
							num4 = -1683859238;
							num13 = num4;
						}
						continue;
						IL_0168:
						int num14;
						if (num9 >= num8)
						{
							num4 = -1683859242;
							num14 = num4;
						}
						else
						{
							num4 = -1683859236;
							num14 = num4;
						}
						continue;
						end_IL_0020:
						break;
					}
					goto IL_00d4;
					continue;
					end_IL_00ed:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("length");
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
				int num2 = default(int);
				while (true)
				{
					int num = 1957513104;
					while (true)
					{
						switch (num ^ 0x74AD4794)
						{
						case 0:
							break;
						case 1:
						{
							int num3;
							if (num2 < length)
							{
								num = 1957513105;
								num3 = num;
							}
							else
							{
								num = 1957513110;
								num3 = num;
							}
							continue;
						}
						case 3:
							num2++;
							num = 1957513109;
							continue;
						case 5:
							stringBuilder.Append(Marshal.ReadByte(buffer, num2).ToString(stringFormat));
							if (num2 < length - 1)
							{
								stringBuilder.Append(", ");
								num = 1957513111;
								continue;
							}
							goto case 3;
						case 4:
							num2 = 0;
							num = 1957513109;
							continue;
						default:
							return stringBuilder.ToString();
						}
						break;
					}
				}
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
