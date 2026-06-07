using UnityEngine;

namespace Mirror
{
	public static class Compression
	{
		private const float QuaternionMinRange = -0.707107f;

		private const float QuaternionMaxRange = 0.707107f;

		private const ushort TenBitsMax = 1023;

		public static int LargestAbsoluteComponentIndex(Vector4 value, out float largest, out Vector3 withoutLargest)
		{
			largest = default(float);
			withoutLargest = default(Vector3);
			return 0;
		}

		public static ushort ScaleFloatToUShort(float value, float minValue, float maxValue, ushort minTarget, ushort maxTarget)
		{
			return 0;
		}

		public static float ScaleUShortToFloat(ushort value, ushort minValue, ushort maxValue, float minTarget, float maxTarget)
		{
			return 0f;
		}

		private static float QuaternionElement(Quaternion q, int element)
		{
			return 0f;
		}

		public static uint CompressQuaternion(Quaternion q)
		{
			return 0u;
		}

		private static Quaternion QuaternionNormalizeSafe(Quaternion value)
		{
			return default(Quaternion);
		}

		public static Quaternion DecompressQuaternion(uint data)
		{
			return default(Quaternion);
		}
	}
}
