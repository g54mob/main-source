using System;
using System.IO;

public static class XxHash64
{
	private const ulong Prime1 = 11400714785074694791uL;

	private const ulong Prime2 = 14029467366897019727uL;

	private const ulong Prime3 = 1609587929392839161uL;

	private const ulong Prime4 = 9650029242287828579uL;

	private const ulong Prime5 = 2870177450012600261uL;

	public static ulong ComputeHash(string path, ulong seed = 0uL)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1048576, FileOptions.SequentialScan);
			return ComputeHash(fileStream, seed);
		}
		finally
		{
			if (fileStream != null)
			{
				fileStream.Dispose();
			}
		}
	}

	public static string ComputeHashHex(string path, ulong seed = 0uL)
	{
		return ComputeHash(path, seed).ToString("x16");
	}

	public static ulong ComputeHash(Stream stream, ulong seed = 0uL, int bufferSize = 1048576)
	{
		if (bufferSize < 32)
		{
			bufferSize = 32;
		}
		ulong num = (ulong)((long)seed + -7046029288634856825L + -4417276706812531889L);
		ulong num2 = seed + 14029467366897019727uL;
		ulong num3 = seed;
		ulong num4 = seed - 11400714785074694791uL;
		byte[] array = new byte[bufferSize + 31];
		int num5 = 0;
		ulong num6 = 0uL;
		int num7;
		while ((num7 = stream.Read(array, num5, bufferSize)) > 0)
		{
			int num8 = num5 + num7;
			num6 += (ulong)num7;
			int num9 = 0;
			if (num8 >= 32)
			{
				int num10 = num8 - 32;
				do
				{
					num = Round(num, ReadUInt64LE(array, num9));
					num9 += 8;
					num2 = Round(num2, ReadUInt64LE(array, num9));
					num9 += 8;
					num3 = Round(num3, ReadUInt64LE(array, num9));
					num9 += 8;
					num4 = Round(num4, ReadUInt64LE(array, num9));
					num9 += 8;
				}
				while (num9 <= num10);
			}
			num5 = num8 - num9;
			if (num5 > 0)
			{
				Buffer.BlockCopy(array, num9, array, 0, num5);
			}
		}
		ulong num11 = ((num6 >= 32) ? (RotateLeft(num, 1) + RotateLeft(num2, 7) + RotateLeft(num3, 12) + RotateLeft(num4, 18)) : (seed + 2870177450012600261L));
		num11 += num6;
		int i;
		for (i = 0; i + 8 <= num5; i += 8)
		{
			ulong num12 = Round(0uL, ReadUInt64LE(array, i));
			num11 ^= num12;
			num11 = (ulong)((long)RotateLeft(num11, 27) * -7046029288634856825L + -8796714831421723037L);
		}
		for (; i + 4 <= num5; i += 4)
		{
			num11 ^= (ulong)(ReadUInt32LE(array, i) * -7046029288634856825L);
			num11 = (ulong)((long)RotateLeft(num11, 23) * -4417276706812531889L + 1609587929392839161L);
		}
		for (; i < num5; i++)
		{
			num11 ^= (ulong)(array[i] * 2870177450012600261L);
			num11 = RotateLeft(num11, 11) * 11400714785074694791uL;
		}
		return Avalanche(num11);
	}

	private static ulong Round(ulong acc, ulong input)
	{
		acc += (ulong)((long)input * -4417276706812531889L);
		acc = RotateLeft(acc, 31);
		acc *= 11400714785074694791uL;
		return acc;
	}

	private static ulong Avalanche(ulong h64)
	{
		h64 ^= h64 >> 33;
		h64 *= 14029467366897019727uL;
		h64 ^= h64 >> 29;
		h64 *= 1609587929392839161L;
		h64 ^= h64 >> 32;
		return h64;
	}

	private static ulong RotateLeft(ulong v, int c)
	{
		return (v << c) | (v >> 64 - c);
	}

	private static ulong ReadUInt64LE(byte[] buf, int offset)
	{
		uint num = (uint)(buf[offset] | (buf[offset + 1] << 8) | (buf[offset + 2] << 16) | (buf[offset + 3] << 24));
		return ((ulong)(uint)(buf[offset + 4] | (buf[offset + 5] << 8) | (buf[offset + 6] << 16) | (buf[offset + 7] << 24)) << 32) | num;
	}

	private static uint ReadUInt32LE(byte[] buf, int offset)
	{
		return (uint)(buf[offset] | (buf[offset + 1] << 8) | (buf[offset + 2] << 16) | (buf[offset + 3] << 24));
	}
}
