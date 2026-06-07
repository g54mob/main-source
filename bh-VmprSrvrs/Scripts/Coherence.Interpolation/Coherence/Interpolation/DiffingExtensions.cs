using UnityEngine;

namespace Coherence.Interpolation
{
	internal static class DiffingExtensions
	{
		public static double EpsilonDouble;

		public static float EpsilonFloat;

		public static bool DiffersFrom(this double a, double b, double epsilonDouble)
		{
			return false;
		}

		public static bool DiffersFrom(this float a, float b, float epsilonFloat)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector2 a, Vector2 b, float epsilonFloat)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector2 a, Vector2 b)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector3 a, Vector3 b, float epsilonFloat)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector3 a, Vector3 b)
		{
			return false;
		}

		public static bool DiffersFrom(this Quaternion a, Quaternion b, float epsilonFloat)
		{
			return false;
		}

		public static bool DiffersFrom(this Quaternion a, Quaternion b)
		{
			return false;
		}
	}
}
