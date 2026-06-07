using System;

namespace GAudio
{
	public static class GATWavHelper
	{
		public static readonly byte[] riffBytes = new byte[4] { 82, 73, 70, 70 };

		public static readonly byte[] waveBytes = new byte[4] { 87, 65, 86, 69 };

		public static readonly byte[] fmtBytes = new byte[4] { 102, 109, 116, 32 };

		public static readonly byte[] dataBytes = new byte[4] { 100, 97, 116, 97 };

		public static readonly int headerSize = 44;

		public static readonly int floatToInt16RescaleFactor = 32767;

		public static readonly float int16ToFloatRescaleFactor = 3.051851E-05f;

		private static readonly byte[] __canonicalHeader = new byte[44]
		{
			82, 73, 70, 70, 0, 0, 0, 0, 87, 65,
			86, 69, 102, 109, 116, 32, 0, 0, 0, 16,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 100, 97, 116, 97,
			0, 0, 0, 0
		};

		public static byte[] GetHeader(int numChannels, int sampleRate, int numBytes)
		{
			byte[] array = new byte[44];
			Buffer.BlockCopy(__canonicalHeader, 0, array, 0, 44);
			int dstOffset = 4;
			Buffer.BlockCopy(BitConverter.GetBytes(numBytes - 8), 0, array, dstOffset, 4);
			dstOffset = 16;
			Buffer.BlockCopy(BitConverter.GetBytes(16), 0, array, dstOffset, 4);
			dstOffset = 20;
			Buffer.BlockCopy(BitConverter.GetBytes((short)1), 0, array, dstOffset, 2);
			dstOffset = 22;
			Buffer.BlockCopy(BitConverter.GetBytes((short)numChannels), 0, array, dstOffset, 2);
			dstOffset = 24;
			Buffer.BlockCopy(BitConverter.GetBytes(sampleRate), 0, array, dstOffset, 4);
			dstOffset = 28;
			Buffer.BlockCopy(BitConverter.GetBytes(sampleRate * numChannels * 16 / 8), 0, array, dstOffset, 4);
			dstOffset = 32;
			Buffer.BlockCopy(BitConverter.GetBytes((short)(numChannels * 2)), 0, array, dstOffset, 2);
			dstOffset = 34;
			Buffer.BlockCopy(BitConverter.GetBytes((short)16), 0, array, dstOffset, 2);
			dstOffset = 40;
			Buffer.BlockCopy(BitConverter.GetBytes(numBytes - headerSize), 0, array, dstOffset, 4);
			return array;
		}

		public static bool IsEqualTo(this byte[] bytes, byte[] comparand)
		{
			if (bytes.Length != comparand.Length)
			{
				throw new GATException("Lengths don't match!");
			}
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] != comparand[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
