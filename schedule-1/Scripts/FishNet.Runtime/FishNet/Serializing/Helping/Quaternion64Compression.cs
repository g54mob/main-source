using UnityEngine;

namespace FishNet.Serializing.Helping
{
	public static class Quaternion64Compression
	{
		private const float Maximum = 0.70710653f;

		private const int BitsPerAxis_H = 21;

		private const int BitsPerAxis_L = 20;

		private const int LargestComponentShift = 62;

		private const int AShift = 41;

		private const int BShift = 20;

		private const int IntScale_H = 1048575;

		private const int IntMask_H = 2097151;

		private const int IntScale_L = 524287;

		private const int IntMask_L = 1048575;

		public static ulong Compress(Quaternion quaternion)
		{
			return 0uL;
		}

		private static ulong ScaleToUint_H(float v)
		{
			return 0uL;
		}

		private static ulong ScaleToUint_L(float v)
		{
			return 0uL;
		}

		private static float ScaleToFloat_H(ulong v)
		{
			return 0f;
		}

		private static float ScaleToFloat_L(ulong v)
		{
			return 0f;
		}

		public static Quaternion Decompress(ulong compressed)
		{
			return default(Quaternion);
		}
	}
}
