using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public static class AstarMath
	{
		private static Unity.Mathematics.Random GlobalRandom;

		private static object GlobalRandomLock;

		public static float ThreadSafeRandomFloat()
		{
			return 0f;
		}

		public static float2 ThreadSafeRandomFloat2()
		{
			return default(float2);
		}

		public static long SaturatingConvertFloatToLong(float v)
		{
			return 0L;
		}

		public static float MapTo(float startMin, float startMax, float targetMin, float targetMax, float value)
		{
			return 0f;
		}

		private static int Bit(int a, int b)
		{
			return 0;
		}

		public static Color IntToColor(int i, float a)
		{
			return default(Color);
		}

		public static Color HSVToRGB(float h, float s, float v)
		{
			return default(Color);
		}

		public static float DeltaAngle(float angle1, float angle2)
		{
			return 0f;
		}
	}
}
