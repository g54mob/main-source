using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class BitTools
	{
		private static byte[] lvdcfuhaWdkhVGjcmCmhruHomExf;

		private static byte[] intToFloatBuffer
		{
			get
			{
				return lvdcfuhaWdkhVGjcmCmhruHomExf ?? (lvdcfuhaWdkhVGjcmCmhruHomExf = new byte[4]);
			}
		}

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
					buffer[1] = (byte)(value >> 8);
					int num = -1359383527;
					while (true)
					{
						switch (num ^ -1359383527)
						{
						case 3:
							num = -1359383525;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_0048;
						case 0:
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
				throw new ArgumentNullException("bytes");
			}
			while (buffer.Length >= 4)
			{
				while (true)
				{
					IL_0048:
					buffer[0] = (byte)value;
					buffer[1] = (byte)(value >> 8);
					buffer[2] = (byte)(value >> 16);
					buffer[3] = (byte)(value >> 24);
					int num = -793166886;
					while (true)
					{
						switch (num ^ -793166885)
						{
						case 0:
							num = -793166888;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							goto IL_0048;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
			throw new Exception("bytes.Length must be >= 4.");
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
					num = 567493722;
					num2 = num;
				}
				else
				{
					num = 567493721;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x21D3445A)
					{
					case 2:
						num = 567493727;
						continue;
					case 7:
						buffer[4] = (byte)(value >> 32);
						buffer[5] = (byte)(value >> 40);
						buffer[6] = (byte)(value >> 48);
						num = 567493723;
						continue;
					case 6:
						buffer[1] = (byte)(value >> 8);
						num = 567493726;
						continue;
					case 5:
						break;
					case 0:
						throw new Exception("bytes.Length must be >= 8.");
					case 4:
						buffer[2] = (byte)(value >> 16);
						buffer[3] = (byte)(value >> 24);
						num = 567493725;
						continue;
					case 3:
						buffer[0] = (byte)value;
						num = 567493724;
						continue;
					default:
						buffer[7] = (byte)(value >> 56);
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
