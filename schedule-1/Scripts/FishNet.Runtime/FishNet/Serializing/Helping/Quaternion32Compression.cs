using UnityEngine;

namespace FishNet.Serializing.Helping
{
	public static class Quaternion32Compression
	{
		private const float Maximum = 0.70710653f;

		private const int BitsPerAxis = 10;

		private const int LargestComponentShift = 30;

		private const int AShift = 20;

		private const int BShift = 10;

		private const int IntScale = 511;

		private const int IntMask = 1023;

		public static uint Compress(Quaternion quaternion)
		{
			return 0u;
		}

		private static uint ScaleToUint(float v)
		{
			return 0u;
		}

		private static float ScaleToFloat(uint v)
		{
			return 0f;
		}

		public static Quaternion Decompress(uint compressed)
		{
			return default(Quaternion);
		}
	}
}
