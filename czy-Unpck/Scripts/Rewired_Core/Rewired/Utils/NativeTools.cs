using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class NativeTools
	{
		private static byte[] LYVqpmdjUAdjRDLJGeQYwGqbJDB;

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
				goto IL_0106;
			}
			if (source == IntPtr.Zero)
			{
				goto IL_0017;
			}
			goto IL_016c;
			IL_016c:
			int num;
			int num2;
			if (destination == IntPtr.Zero)
			{
				num = -1129434563;
				num2 = num;
			}
			else
			{
				num = -1129434576;
				num2 = num;
			}
			goto IL_001c;
			IL_0017:
			num = -1129434571;
			goto IL_001c;
			IL_001c:
			int num12 = default(int);
			int num5 = default(int);
			int num14 = default(int);
			int num9 = default(int);
			int num6 = default(int);
			int num8 = default(int);
			int num7 = default(int);
			while (true)
			{
				switch (num ^ -1129434569)
				{
				case 8:
					break;
				case 9:
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				case 6:
					goto IL_007e;
				case 14:
					throw new ArgumentOutOfRangeException("length");
				case 3:
					goto IL_00a2;
				case 1:
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				case 2:
					throw new ArgumentNullException("source");
				case 4:
					return false;
				case 5:
					destinationStartIndex = 0;
					num = -1129434569;
					continue;
				case 12:
					goto IL_0106;
				case 15:
					goto IL_0127;
				case 10:
					throw new ArgumentNullException("destination");
				case 7:
					goto IL_0154;
				case 11:
					goto IL_016c;
				case 13:
					goto IL_018d;
				default:
					goto IL_01a5;
				}
				break;
				IL_01a5:
				if (bytesToCopy <= 0)
				{
					return false;
				}
				goto IL_01ac;
				IL_01ac:
				bool result;
				try
				{
					int num3 = bytesToCopy;
					while (true)
					{
						IL_01af:
						int num4 = -1129434570;
						while (true)
						{
							switch (num4 ^ -1129434569)
							{
							case 9:
								break;
							case 12:
								num3 %= 2;
								num4 = -1129434589;
								continue;
							case 2:
								if (num12 >= num5)
								{
									num3 %= 8;
									num4 = -1129434561;
									continue;
								}
								goto case 18;
							case 11:
							{
								int num15;
								if (num14 < bytesToCopy)
								{
									num4 = -1129434575;
									num15 = num4;
								}
								else
								{
									num4 = -1129434586;
									num15 = num4;
								}
								continue;
							}
							case 10:
								num9 = bytesToCopy / 2 * 2;
								num4 = -1129434590;
								continue;
							case 16:
							{
								int num10;
								if (num6 >= num9)
								{
									num4 = -1129434565;
									num10 = num4;
								}
								else
								{
									num4 = -1129434573;
									num10 = num4;
								}
								continue;
							}
							case 20:
								num14 = bytesToCopy - num3;
								num4 = -1129434564;
								continue;
							case 21:
								num6 = bytesToCopy - num3;
								num4 = -1129434585;
								continue;
							case 15:
								num12 += 8;
								num4 = -1129434571;
								continue;
							case 14:
								num12 = 0;
								num4 = -1129434571;
								continue;
							case 19:
								Marshal.WriteInt32(destination, num8 + destinationStartIndex, Marshal.ReadInt32(source, num8 + sourceStartIndex));
								num4 = -1129434569;
								continue;
							case 6:
								Marshal.WriteByte(destination, num14 + destinationStartIndex, Marshal.ReadByte(source, num14 + sourceStartIndex));
								num14++;
								num4 = -1129434564;
								continue;
							case 13:
							{
								int num13;
								if (num3 < 2)
								{
									num4 = -1129434589;
									num13 = num4;
								}
								else
								{
									num4 = -1129434563;
									num13 = num4;
								}
								continue;
							}
							case 18:
								Marshal.WriteInt64(destination, num12 + destinationStartIndex, Marshal.ReadInt64(source, num12 + sourceStartIndex));
								num4 = -1129434568;
								continue;
							case 5:
								num6 += 2;
								num4 = -1129434585;
								continue;
							case 0:
								num8 += 4;
								num4 = -1129434576;
								continue;
							case 7:
								if (num8 >= num7)
								{
									num3 %= 4;
									num4 = -1129434566;
									continue;
								}
								goto case 19;
							case 1:
							{
								int num11;
								if (num3 < 8)
								{
									num4 = -1129434561;
									num11 = num4;
								}
								else
								{
									num4 = -1129434572;
									num11 = num4;
								}
								continue;
							}
							case 8:
								if (num3 >= 4)
								{
									num7 = bytesToCopy / 4 * 4;
									num8 = bytesToCopy - num3;
									num4 = -1129434576;
									continue;
								}
								goto case 13;
							case 4:
								Marshal.WriteInt16(destination, num6 + destinationStartIndex, Marshal.ReadInt16(source, num6 + sourceStartIndex));
								num4 = -1129434574;
								continue;
							case 3:
								num5 = bytesToCopy / 8 * 8;
								num4 = -1129434567;
								continue;
							default:
								result = true;
								goto end_IL_01b4;
							}
							goto IL_01af;
							continue;
							end_IL_01b4:
							break;
						}
						break;
					}
				}
				catch
				{
					if (throwOnError)
					{
						throw;
					}
					while (true)
					{
						IL_03f7:
						result = false;
						int num16 = -1129434569;
						while (true)
						{
							switch (num16 ^ -1129434569)
							{
							case 2:
								goto IL_03d9;
							default:
								goto end_IL_03de;
							case 1:
								break;
							case 0:
								goto end_IL_03de;
							}
							goto IL_03f7;
							IL_03d9:
							num16 = -1129434570;
							continue;
							end_IL_03de:
							break;
						}
						break;
					}
				}
				return result;
				IL_0154:
				int num17;
				if (sourceStartIndex >= 0)
				{
					num = -1129434568;
					num17 = num;
				}
				else
				{
					num = -1129434562;
					num17 = num;
				}
				continue;
				IL_00a2:
				if (destination == IntPtr.Zero)
				{
					num = -1129434573;
					continue;
				}
				if (sourceStartIndex < 0)
				{
					sourceStartIndex = 0;
					num = -1129434566;
					continue;
				}
				goto IL_018d;
				IL_018d:
				int num18;
				if (destinationStartIndex >= 0)
				{
					num = -1129434569;
					num18 = num;
				}
				else
				{
					num = -1129434574;
					num18 = num;
				}
				continue;
				IL_0127:
				int num19;
				if (destinationStartIndex >= 0)
				{
					num = -1129434575;
					num19 = num;
				}
				else
				{
					num = -1129434570;
					num19 = num;
				}
				continue;
				IL_007e:
				if (bytesToCopy <= 0)
				{
					num = -1129434567;
					continue;
				}
				goto IL_01ac;
			}
			goto IL_0017;
			IL_0106:
			int num20;
			if (!(source == IntPtr.Zero))
			{
				num = -1129434572;
				num20 = num;
			}
			else
			{
				num = -1129434573;
				num20 = num;
			}
			goto IL_001c;
		}

		public static bool CopyMemory(byte[] source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				goto IL_0004;
			}
			goto IL_003d;
			IL_0004:
			int num = 687448655;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x28F9A24E)
				{
				case 0:
					break;
				case 5:
					goto IL_003d;
				case 6:
					if (sourceStartIndex >= 0)
					{
						goto IL_0057;
					}
					goto case 7;
				case 4:
					if (destinationStartIndex < 0)
					{
						throw new ArgumentOutOfRangeException("destinationStartIndex");
					}
					goto IL_00a9;
				case 7:
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				case 8:
					goto IL_0099;
				case 2:
					goto IL_00a9;
				case 1:
					if (source == null)
					{
						throw new ArgumentNullException("source");
					}
					goto case 6;
				default:
					return false;
				}
				break;
				IL_0057:
				int num2;
				if (sourceStartIndex < source.Length)
				{
					num = 687448650;
					num2 = num;
				}
				else
				{
					num = 687448649;
					num2 = num;
				}
			}
			goto IL_0004;
			IL_0099:
			return false;
			IL_00ec:
			bool result = default(bool);
			try
			{
				if (destinationStartIndex != 0)
				{
					goto IL_011d;
				}
				Marshal.Copy(source, sourceStartIndex, destination, bytesToCopy);
				goto IL_0134;
				IL_011d:
				Marshal.Copy(source, sourceStartIndex, OffsetIntPtr(destination, destinationStartIndex), bytesToCopy);
				int num3 = 687448654;
				goto IL_0100;
				IL_0134:
				result = true;
				num3 = 687448652;
				goto IL_0100;
				IL_0100:
				while (true)
				{
					switch (num3 ^ 0x28F9A24E)
					{
					case 3:
						num3 = 687448655;
						continue;
					case 1:
						goto IL_011d;
					case 0:
						goto IL_0134;
					case 2:
						break;
					}
					break;
				}
			}
			catch
			{
				if (throwOnError)
				{
					goto IL_0144;
				}
				goto IL_016f;
				IL_0144:
				int num4 = 687448655;
				goto IL_0149;
				IL_0149:
				switch (num4 ^ 0x28F9A24E)
				{
				case 2:
					break;
				default:
					goto end_IL_013f;
				case 1:
					throw;
				case 3:
					goto IL_016f;
				case 0:
					goto end_IL_013f;
				}
				goto IL_0144;
				IL_016f:
				result = false;
				num4 = 687448654;
				goto IL_0149;
				end_IL_013f:;
			}
			return result;
			IL_003d:
			if (source == null)
			{
				return false;
			}
			if (sourceStartIndex >= 0)
			{
				if (sourceStartIndex >= source.Length)
				{
					num = 687448646;
				}
				else
				{
					if (destinationStartIndex >= 0)
					{
						if (bytesToCopy > source.Length - sourceStartIndex)
						{
							return false;
						}
						goto IL_00ec;
					}
					num = 687448653;
				}
				goto IL_0009;
			}
			goto IL_0099;
			IL_00a9:
			if (bytesToCopy > source.Length - sourceStartIndex)
			{
				throw new Exception("source.Length + souceStartIndex must be >= bytesToCopy");
			}
			goto IL_00ec;
		}

		public static bool CopyMemory(IntPtr source, byte[] destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				goto IL_0007;
			}
			goto IL_00ca;
			IL_0007:
			int num = -216308623;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -216308624)
				{
				case 9:
					break;
				case 4:
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				case 7:
					if (sourceStartIndex < 0)
					{
						throw new ArgumentOutOfRangeException("sourceStartIndex");
					}
					goto case 2;
				case 0:
					throw new Exception("destination.Length + destinationStartIndex must be >= bytesToCopy");
				case 1:
					goto IL_0082;
				case 2:
					if (destinationStartIndex < 0)
					{
						goto case 4;
					}
					goto IL_009d;
				case 10:
					goto IL_00b7;
				case 8:
					goto IL_00ca;
				case 6:
					return false;
				case 5:
					throw new ArgumentNullException("destination");
				default:
					goto IL_0108;
				}
				break;
				IL_00b7:
				if (bytesToCopy > destination.Length - destinationStartIndex)
				{
					num = -216308624;
					continue;
				}
				goto IL_0115;
				IL_009d:
				int num2;
				if (destinationStartIndex < destination.Length)
				{
					num = -216308614;
					num2 = num;
				}
				else
				{
					num = -216308620;
					num2 = num;
				}
				continue;
				IL_0082:
				int num3;
				if (destination == null)
				{
					num = -216308619;
					num3 = num;
				}
				else
				{
					num = -216308617;
					num3 = num;
				}
			}
			goto IL_0007;
			IL_00ca:
			if (destination == null)
			{
				return false;
			}
			if (sourceStartIndex < 0)
			{
				num = -216308618;
			}
			else
			{
				if (destinationStartIndex < 0)
				{
					goto IL_0108;
				}
				if (destinationStartIndex < destination.Length)
				{
					if (bytesToCopy > destination.Length - destinationStartIndex)
					{
						return false;
					}
					goto IL_0115;
				}
				num = -216308621;
			}
			goto IL_000c;
			IL_0108:
			return false;
			IL_0115:
			bool result = default(bool);
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
						int num4 = -216308623;
						while (true)
						{
							switch (num4 ^ -216308624)
							{
							case 0:
								num4 = -216308622;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0142;
							}
							break;
						}
						continue;
						end_IL_0142:
						break;
					}
				}
				result = true;
			}
			catch
			{
				if (throwOnError)
				{
					goto IL_0162;
				}
				goto IL_018d;
				IL_0162:
				int num5 = -216308623;
				goto IL_0167;
				IL_0167:
				switch (num5 ^ -216308624)
				{
				case 3:
					break;
				default:
					goto end_IL_015d;
				case 1:
					throw;
				case 0:
					goto IL_018d;
				case 2:
					goto end_IL_015d;
				}
				goto IL_0162;
				IL_018d:
				result = false;
				num5 = -216308622;
				goto IL_0167;
				end_IL_015d:;
			}
			return result;
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
			goto IL_004d;
			IL_0004:
			int num = 115794570;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x6E6E28D)
				{
				case 12:
					break;
				case 1:
					goto IL_004d;
				case 9:
					goto IL_006a;
				case 4:
					goto IL_007f;
				case 8:
					throw new ArgumentNullException("buffer");
				case 5:
					LYVqpmdjUAdjRDLJGeQYwGqbJDB = new byte[8];
					num = 115794571;
					continue;
				case 0:
					goto IL_00b7;
				case 3:
					throw new ArgumentOutOfRangeException("length");
				case 2:
					goto IL_00da;
				case 11:
					return false;
				case 10:
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				case 7:
					goto IL_011e;
				default:
					goto IL_013f;
				}
				break;
				IL_011e:
				int num2;
				if (buffer == IntPtr.Zero)
				{
					num = 115794565;
					num2 = num;
				}
				else
				{
					num = 115794564;
					num2 = num;
				}
				continue;
				IL_00b7:
				if (length <= 0)
				{
					num = 115794574;
					continue;
				}
				goto IL_00f7;
				IL_006a:
				int num3;
				if (startIndex >= 0)
				{
					num = 115794573;
					num3 = num;
				}
				else
				{
					num = 115794567;
					num3 = num;
				}
				continue;
				IL_00da:
				int num4;
				if (LYVqpmdjUAdjRDLJGeQYwGqbJDB == null)
				{
					num = 115794568;
					num4 = num;
				}
				else
				{
					num = 115794571;
					num4 = num;
				}
			}
			goto IL_0004;
			IL_0390:
			int num5;
			int num7 = default(int);
			int num12 = default(int);
			int num13 = default(int);
			int num6 = default(int);
			int num11 = default(int);
			int num10 = default(int);
			int num9 = default(int);
			int num8 = default(int);
			int num14 = default(int);
			while (true)
			{
				switch (num5 ^ 0x6E6E28D)
				{
				case 16:
					num5 = 115794562;
					continue;
				case 4:
					num7 %= 2;
					num5 = 115794568;
					continue;
				case 2:
					if (num12 >= num13)
					{
						num7 %= 8;
						num5 = 115794588;
						continue;
					}
					goto case 1;
				case 5:
					break;
				case 1:
					Marshal.WriteInt64(buffer, num12 + startIndex, 0L);
					num12 += 8;
					num5 = 115794575;
					continue;
				case 9:
					Marshal.WriteByte(buffer, num6 + startIndex, value);
					num6++;
					num5 = 115794590;
					continue;
				case 3:
					goto IL_0456;
				case 0:
					goto IL_046a;
				case 17:
					goto IL_0482;
				case 15:
					goto IL_049c;
				case 11:
					num5 = 115794567;
					continue;
				case 18:
					Marshal.WriteInt32(buffer, num11 + startIndex, 0);
					num11 += 4;
					num5 = 115794567;
					continue;
				case 8:
					Marshal.WriteInt16(buffer, num10 + startIndex, 0);
					num10 += 2;
					num5 = 115794570;
					continue;
				case 6:
					goto IL_04f2;
				case 12:
					num5 = 115794590;
					continue;
				case 20:
					num9 = length / 2 * 2;
					num10 = length - num7;
					num5 = 115794570;
					continue;
				case 7:
					goto IL_052a;
				case 10:
					goto IL_0544;
				case 14:
					num7 %= 4;
					num5 = 115794571;
					continue;
				case 13:
					num8 += 2;
					num5 = 115794574;
					continue;
				default:
					if (num6 >= length)
					{
						return true;
					}
					goto case 9;
				}
				break;
				IL_0544:
				int num15;
				if (num11 >= num14)
				{
					num5 = 115794563;
					num15 = num5;
				}
				else
				{
					num5 = 115794591;
					num15 = num5;
				}
				continue;
				IL_052a:
				int num16;
				if (num10 >= num9)
				{
					num5 = 115794569;
					num16 = num5;
				}
				else
				{
					num5 = 115794565;
					num16 = num5;
				}
			}
			goto IL_0410;
			IL_013f:
			bool flag = false;
			if (num7 >= 8)
			{
				long val;
				lock (LYVqpmdjUAdjRDLJGeQYwGqbJDB)
				{
					int num17 = 0;
					while (true)
					{
						IL_0157:
						int num18 = 115794572;
						while (true)
						{
							switch (num18 ^ 0x6E6E28D)
							{
							case 4:
								break;
							case 1:
								num18 = 115794574;
								continue;
							case 2:
								num17++;
								num18 = 115794574;
								continue;
							case 3:
								if (num17 >= 8)
								{
									flag = true;
									num18 = 115794573;
									continue;
								}
								goto case 5;
							case 5:
								LYVqpmdjUAdjRDLJGeQYwGqbJDB[num17] = value;
								num18 = 115794575;
								continue;
							default:
								val = BitConverter.ToInt64(LYVqpmdjUAdjRDLJGeQYwGqbJDB, 0);
								goto end_IL_015c;
							}
							goto IL_0157;
							continue;
							end_IL_015c:
							break;
						}
						break;
					}
				}
				int num19 = length / 8 * 8;
				int num20 = 0;
				while (true)
				{
					int num21 = 115794569;
					while (true)
					{
						switch (num21 ^ 0x6E6E28D)
						{
						case 2:
							break;
						case 4:
							num21 = 115794572;
							continue;
						case 1:
							if (num20 >= num19)
							{
								num7 %= 8;
								num21 = 115794574;
								continue;
							}
							goto case 0;
						case 0:
							Marshal.WriteInt64(buffer, num20 + startIndex, val);
							num20 += 8;
							num21 = 115794572;
							continue;
						default:
							goto end_IL_01cf;
						}
						break;
					}
					continue;
					end_IL_01cf:
					break;
				}
			}
			if (num7 >= 4)
			{
				int val2;
				lock (LYVqpmdjUAdjRDLJGeQYwGqbJDB)
				{
					if (!flag)
					{
						int num23 = default(int);
						while (true)
						{
							int num22 = 115794572;
							while (true)
							{
								switch (num22 ^ 0x6E6E28D)
								{
								case 0:
									break;
								case 1:
									num23 = 0;
									num22 = 115794569;
									continue;
								case 4:
									if (num23 >= 4)
									{
										flag = true;
										num22 = 115794574;
										continue;
									}
									goto case 2;
								case 2:
									LYVqpmdjUAdjRDLJGeQYwGqbJDB[num23] = value;
									num23++;
									num22 = 115794569;
									continue;
								default:
									goto end_IL_023c;
								}
								break;
							}
							continue;
							end_IL_023c:
							break;
						}
					}
					val2 = BitConverter.ToInt32(LYVqpmdjUAdjRDLJGeQYwGqbJDB, 0);
				}
				int num24 = length / 4 * 4;
				int num25 = length - num7;
				while (true)
				{
					IL_02f0:
					int num26;
					if (num25 >= num24)
					{
						num7 %= 4;
						num26 = 115794573;
						goto IL_02ba;
					}
					goto IL_02d7;
					IL_02ba:
					while (true)
					{
						switch (num26 ^ 0x6E6E28D)
						{
						case 3:
							num26 = 115794572;
							continue;
						case 1:
							break;
						case 2:
							goto IL_02f0;
						default:
							goto end_IL_02f0;
						}
						break;
					}
					goto IL_02d7;
					IL_02d7:
					Marshal.WriteInt32(buffer, num25 + startIndex, val2);
					num25 += 4;
					num26 = 115794575;
					goto IL_02ba;
					continue;
					end_IL_02f0:
					break;
				}
			}
			if (num7 < 2)
			{
				goto IL_0410;
			}
			short val3 = default(short);
			lock (LYVqpmdjUAdjRDLJGeQYwGqbJDB)
			{
				if (!flag)
				{
					int num27 = 0;
					while (true)
					{
						IL_0355:
						int num28;
						if (num27 >= 2)
						{
							flag = true;
							num28 = 115794572;
							goto IL_0322;
						}
						goto IL_033f;
						IL_0322:
						while (true)
						{
							switch (num28 ^ 0x6E6E28D)
							{
							case 0:
								num28 = 115794574;
								continue;
							case 3:
								break;
							case 2:
								goto IL_0355;
							default:
								goto end_IL_0355;
							}
							break;
						}
						goto IL_033f;
						IL_033f:
						LYVqpmdjUAdjRDLJGeQYwGqbJDB[num27] = value;
						num27++;
						num28 = 115794575;
						goto IL_0322;
						continue;
						end_IL_0355:
						break;
					}
				}
				val3 = BitConverter.ToInt16(LYVqpmdjUAdjRDLJGeQYwGqbJDB, 0);
			}
			int num29 = length / 2 * 2;
			num8 = length - num7;
			goto IL_0456;
			IL_004d:
			if (buffer == IntPtr.Zero)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
				num = 115794569;
				goto IL_0009;
			}
			goto IL_007f;
			IL_049c:
			Marshal.WriteInt16(buffer, num8 + startIndex, val3);
			num5 = 115794560;
			goto IL_0390;
			IL_046a:
			if (num7 >= 8)
			{
				num13 = length / 8 * 8;
				num12 = 0;
				num5 = 115794575;
				goto IL_0390;
			}
			goto IL_0482;
			IL_00f7:
			num7 = length;
			if (value != 0)
			{
				num = 115794575;
				goto IL_0009;
			}
			goto IL_046a;
			IL_0482:
			if (num7 >= 4)
			{
				num14 = length / 4 * 4;
				num11 = length - num7;
				num5 = 115794566;
				goto IL_0390;
			}
			goto IL_04f2;
			IL_0410:
			num6 = length - num7;
			num5 = 115794561;
			goto IL_0390;
			IL_04f2:
			int num30;
			if (num7 >= 2)
			{
				num5 = 115794585;
				num30 = num5;
			}
			else
			{
				num5 = 115794568;
				num30 = num5;
			}
			goto IL_0390;
			IL_0456:
			if (num8 >= num29)
			{
				num7 %= 2;
				num5 = 115794568;
				goto IL_0390;
			}
			goto IL_049c;
			IL_007f:
			if (length <= 0)
			{
				num = 115794566;
				goto IL_0009;
			}
			goto IL_00f7;
		}

		public static bool FillMemory(byte[] buffer, int length, byte value, bool throwOnError = true)
		{
			return FillMemory(buffer, 0, length, value, throwOnError);
		}

		public static bool FillMemory(byte[] buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (!throwOnError)
			{
				goto IL_0047;
			}
			if (buffer == null)
			{
				goto IL_000a;
			}
			goto IL_0095;
			IL_0047:
			if (buffer == null)
			{
				return false;
			}
			int num;
			int num2;
			if (startIndex >= 0)
			{
				num = 466702777;
				num2 = num;
			}
			else
			{
				num = 466702775;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 466702776;
			goto IL_000f;
			IL_000f:
			bool result = default(bool);
			while (true)
			{
				switch (num ^ 0x1BD151BF)
				{
				case 3:
					break;
				case 5:
					goto IL_0047;
				case 6:
					goto IL_0061;
				case 4:
					goto IL_006e;
				case 1:
					throw new ArgumentOutOfRangeException("length");
				case 0:
					goto IL_0095;
				case 8:
					return false;
				case 2:
					if (length < 0)
					{
						goto case 1;
					}
					goto IL_00cf;
				case 7:
					throw new ArgumentNullException("buffer");
				default:
					goto IL_00f6;
				}
				break;
				IL_00cf:
				if (length + startIndex > buffer.Length)
				{
					num = 466702782;
					continue;
				}
				goto IL_00f8;
				IL_00f6:
				return false;
				IL_0061:
				if (startIndex >= buffer.Length)
				{
					num = 466702775;
					continue;
				}
				if (length < 0)
				{
					goto IL_00f6;
				}
				if (length + startIndex > buffer.Length)
				{
					num = 466702774;
					continue;
				}
				goto IL_00f8;
				IL_00f8:
				try
				{
					lock (buffer)
					{
						GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
						while (true)
						{
							IL_0108:
							int num3 = 466702782;
							while (true)
							{
								switch (num3 ^ 0x1BD151BF)
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
								result = FillMemory(gCHandle.AddrOfPinnedObject(), startIndex, length, value, throwOnError);
								gCHandle.Free();
								num3 = 466702781;
								continue;
								end_IL_010d:
								break;
							}
							break;
						}
					}
					return result;
				}
				catch
				{
					while (true)
					{
						switch (0x1BD151BE ^ 0x1BD151BF)
						{
						case 0:
							continue;
						case 1:
							if (throwOnError)
							{
								throw;
							}
							break;
						}
						break;
					}
					return false;
				}
			}
			goto IL_000a;
			IL_0095:
			if (startIndex >= 0)
			{
				int num4;
				if (startIndex >= buffer.Length)
				{
					num = 466702779;
					num4 = num;
				}
				else
				{
					num = 466702781;
					num4 = num;
				}
				goto IL_000f;
			}
			goto IL_006e;
			IL_006e:
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public static void ZeroFillMemory(IntPtr buffer, int length)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			int num5 = default(int);
			int num3 = default(int);
			int num10 = default(int);
			int num9 = default(int);
			int num8 = default(int);
			int num4 = default(int);
			int num7 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (length < 0)
				{
					num = -638662921;
					num2 = num;
				}
				else
				{
					num = -638662914;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -638662928)
					{
					case 17:
						num = -638662913;
						continue;
					case 14:
					{
						num5 = length;
						int num13;
						if (num5 < 8)
						{
							num = -638662928;
							num13 = num;
						}
						else
						{
							num = -638662919;
							num13 = num;
						}
						continue;
					}
					case 13:
						num3 = length - num5;
						num = -638662917;
						continue;
					case 9:
						num10 = length / 8 * 8;
						num = -638662925;
						continue;
					case 18:
						num9 = length / 4 * 4;
						num8 = length - num5;
						num = -638662922;
						continue;
					case 3:
						num4 = 0;
						num = -638662926;
						continue;
					case 0:
					{
						int num12;
						if (num5 < 4)
						{
							num = -638662923;
							num12 = num;
						}
						else
						{
							num = -638662942;
							num12 = num;
						}
						continue;
					}
					case 7:
						throw new ArgumentOutOfRangeException("length");
					case 1:
						if (num7 >= num6)
						{
							num5 %= 2;
							num = -638662915;
							continue;
						}
						goto case 4;
					case 12:
						Marshal.WriteInt32(buffer, num8, 0);
						num8 += 4;
						num = -638662922;
						continue;
					case 4:
						Marshal.WriteInt16(buffer, num7, 0);
						num7 += 2;
						num = -638662927;
						continue;
					case 10:
						Marshal.WriteByte(buffer, num3, 0);
						num3++;
						num = -638662917;
						continue;
					case 2:
					{
						int num11;
						if (num4 >= num10)
						{
							num = -638662944;
							num11 = num;
						}
						else
						{
							num = -638662920;
							num11 = num;
						}
						continue;
					}
					case 6:
						if (num8 >= num9)
						{
							num5 %= 4;
							num = -638662923;
							continue;
						}
						goto case 12;
					case 15:
						break;
					case 16:
						num5 %= 8;
						num = -638662928;
						continue;
					case 5:
						if (num5 >= 2)
						{
							num6 = length / 2 * 2;
							num7 = length - num5;
							num = -638662927;
							continue;
						}
						goto case 13;
					case 8:
						Marshal.WriteInt64(buffer, num4, 0L);
						num4 += 8;
						num = -638662926;
						continue;
					default:
						if (num3 >= length)
						{
							return;
						}
						goto case 10;
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
			string result = default(string);
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				while (num < length)
				{
					while (true)
					{
						stringBuilder.Append(Marshal.ReadByte(buffer, num).ToString(stringFormat));
						int num2 = -687487217;
						while (true)
						{
							switch (num2 ^ -687487221)
							{
							case 2:
								num2 = -687487222;
								continue;
							case 1:
								break;
							case 3:
								num++;
								num2 = -687487221;
								continue;
							case 4:
								if (num < length - 1)
								{
									stringBuilder.Append(", ");
									num2 = -687487224;
									continue;
								}
								goto case 3;
							default:
								goto end_IL_0043;
							}
							break;
						}
						continue;
						end_IL_0043:
						break;
					}
				}
				result = stringBuilder.ToString();
			}
			catch
			{
				while (true)
				{
					IL_0093:
					int num3 = -687487223;
					while (true)
					{
						switch (num3 ^ -687487221)
						{
						case 0:
							break;
						default:
							goto end_IL_0098;
						case 2:
							goto IL_00b1;
						case 1:
							goto end_IL_0098;
						}
						goto IL_0093;
						IL_00b1:
						result = "Exception!";
						num3 = -687487222;
						continue;
						end_IL_0098:
						break;
					}
					break;
				}
			}
			return result;
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
