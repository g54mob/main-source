using System.Numerics;

namespace Coherence.Utils
{
	public static class DiffingExtensions
	{
		internal const float EpsilonFloat = 0.001f;

		internal const double EpsilonDouble = 0.001;

		public static bool DiffersFrom(this string a, string b)
		{
			return false;
		}

		public static bool DiffersFrom(this byte[] a, byte[] b)
		{
			return false;
		}

		public static bool DiffersFrom(this double a, double b)
		{
			return false;
		}

		public static bool DiffersFrom(this float a, float b)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector2 a, Vector2 b)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector3 a, Vector3 b)
		{
			return false;
		}

		public static bool DiffersFrom(this Vector4 a, Vector4 b)
		{
			return false;
		}

		public static bool DiffersFrom(this Quaternion a, Quaternion b)
		{
			return false;
		}
	}
}
