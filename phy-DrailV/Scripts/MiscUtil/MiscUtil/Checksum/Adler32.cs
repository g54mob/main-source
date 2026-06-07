using System;
using System.IO;

namespace MiscUtil.Checksum
{
	public class Adler32
	{
		private const int Base = 65521;

		private const int NMax = 5552;

		public static int ComputeChecksum(int initial, byte[] data, int start, int length)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			uint num = (uint)(initial & 0xFFFF);
			uint num2 = (uint)((initial >> 16) & 0xFFFF);
			int num3 = start;
			int num4 = length;
			while (num4 > 0)
			{
				int num5 = ((num4 < 5552) ? num4 : 5552);
				num4 -= num5;
				for (int i = 0; i < num5; i++)
				{
					num += data[num3++];
					num2 += num;
				}
				num %= 65521;
				num2 %= 65521;
			}
			return (int)((num2 << 16) | num);
		}

		public static int ComputeChecksum(int initial, byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return ComputeChecksum(initial, data, 0, data.Length);
		}

		public static int ComputeChecksum(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			byte[] array = new byte[8172];
			int num = 1;
			int length;
			while ((length = stream.Read(array, 0, array.Length)) > 0)
			{
				num = ComputeChecksum(num, array, 0, length);
			}
			return num;
		}

		public static int ComputeChecksum(string path)
		{
			using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				return ComputeChecksum(stream);
			}
		}
	}
}
