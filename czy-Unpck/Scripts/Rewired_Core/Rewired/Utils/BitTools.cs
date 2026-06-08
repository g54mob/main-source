using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class BitTools
	{
		private static byte[] xepPgbovypDlSgEYJVucRnEpAaR;

		private static byte[] intToFloatBuffer => xepPgbovypDlSgEYJVucRnEpAaR ?? (xepPgbovypDlSgEYJVucRnEpAaR = new byte[4]);

		public static void GetBytes(short value, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			while (buffer.Length >= 2)
			{
				while (true)
				{
					IL_0048:
					buffer[0] = (byte)value;
					int num = -1015509473;
					while (true)
					{
						switch (num ^ -1015509475)
						{
						case 3:
							num = -1015509476;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0048;
						default:
							buffer[1] = (byte)(value >> 8);
							return;
						}
						break;
					}
					break;
				}
			}
			throw new Exception("bytes.Length must be >= 2.");
		}

		public static void GetBytes(int value, byte[] buffer)
		{
			if (buffer == null)
			{
				while (true)
				{
					switch (0x64D8C412 ^ 0x64D8C413)
					{
					case 0:
						break;
					case 1:
						throw new ArgumentNullException("bytes");
					case 3:
						goto end_IL_0003;
					default:
						goto IL_004f;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			if (buffer.Length < 4)
			{
				throw new Exception("bytes.Length must be >= 4.");
			}
			goto IL_004f;
			IL_004f:
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
			buffer[2] = (byte)(value >> 16);
			buffer[3] = (byte)(value >> 24);
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
				if (buffer.Length < 8)
				{
					num = 612340347;
					num2 = num;
				}
				else
				{
					num = 612340345;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x247F9278)
					{
					case 0:
						num = 612340348;
						continue;
					default:
						return;
					case 4:
						break;
					case 1:
						buffer[0] = (byte)value;
						buffer[1] = (byte)(value >> 8);
						buffer[2] = (byte)(value >> 16);
						buffer[3] = (byte)(value >> 24);
						buffer[4] = (byte)(value >> 32);
						buffer[5] = (byte)(value >> 40);
						buffer[6] = (byte)(value >> 48);
						buffer[7] = (byte)(value >> 56);
						num = 612340346;
						continue;
					case 3:
						throw new Exception("bytes.Length must be >= 8.");
					case 2:
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
				throw new Exception("pointer is null");
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
