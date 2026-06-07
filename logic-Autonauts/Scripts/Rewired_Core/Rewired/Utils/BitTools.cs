using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class BitTools
	{
		private static byte[] MlbxatWdSjBMqDHlCCgtCDNaaXux;

		private static byte[] intToFloatBuffer
		{
			get
			{
				return MlbxatWdSjBMqDHlCCgtCDNaaXux ?? (MlbxatWdSjBMqDHlCCgtCDNaaXux = new byte[4]);
			}
		}

		public static void GetBytes(short value, byte[] buffer)
		{
			if (buffer == null)
			{
				while (true)
				{
					switch (0x3E155A4 ^ 0x3E155A5)
					{
					case 3:
						break;
					case 1:
						throw new ArgumentNullException("bytes");
					case 2:
						goto end_IL_0003;
					default:
						goto IL_004f;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			if (buffer.Length < 2)
			{
				throw new Exception("bytes.Length must be >= 2.");
			}
			goto IL_004f;
			IL_004f:
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
		}

		public static void GetBytes(int value, byte[] buffer)
		{
			if (buffer == null)
			{
				goto IL_0003;
			}
			goto IL_006b;
			IL_0003:
			int num = -1122755113;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -1122755115)
				{
				case 0:
					break;
				case 6:
					throw new Exception("bytes.Length must be >= 4.");
				case 5:
					buffer[1] = (byte)(value >> 8);
					buffer[2] = (byte)(value >> 16);
					num = -1122755116;
					continue;
				case 2:
					throw new ArgumentNullException("bytes");
				case 4:
					goto IL_006b;
				case 3:
					buffer[0] = (byte)value;
					num = -1122755120;
					continue;
				default:
					buffer[3] = (byte)(value >> 24);
					return;
				}
				break;
			}
			goto IL_0003;
			IL_006b:
			int num2;
			if (buffer.Length >= 4)
			{
				num = -1122755114;
				num2 = num;
			}
			else
			{
				num = -1122755117;
				num2 = num;
			}
			goto IL_0008;
		}

		public static void GetBytes(long value, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			while (true)
			{
				int num;
				int num2;
				if (buffer.Length >= 8)
				{
					num = -2018381427;
					num2 = num;
				}
				else
				{
					num = -2018381430;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2018381432)
					{
					case 7:
						num = -2018381426;
						continue;
					default:
						return;
					case 3:
						buffer[2] = (byte)(value >> 16);
						buffer[3] = (byte)(value >> 24);
						buffer[4] = (byte)(value >> 32);
						num = -2018381428;
						continue;
					case 2:
						throw new Exception("bytes.Length must be >= 8.");
					case 4:
						buffer[5] = (byte)(value >> 40);
						num = -2018381431;
						continue;
					case 6:
						break;
					case 1:
						buffer[6] = (byte)(value >> 48);
						buffer[7] = (byte)(value >> 56);
						num = -2018381432;
						continue;
					case 5:
						buffer[0] = (byte)value;
						buffer[1] = (byte)(value >> 8);
						num = -2018381429;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public static float IntToFloat(IntPtr pointer, int offset = 0)
		{
			if (pointer == IntPtr.Zero)
			{
				while (true)
				{
					switch (0x31AC778D ^ 0x31AC778C)
					{
					case 0:
						continue;
					case 1:
						throw new Exception("pointer is null");
					}
					break;
				}
			}
			byte[] array = intToFloatBuffer;
			lock (array)
			{
				Marshal.Copy(pointer, array, offset, 4);
				return BitConverter.ToSingle(array, 0);
			}
		}
	}
}
