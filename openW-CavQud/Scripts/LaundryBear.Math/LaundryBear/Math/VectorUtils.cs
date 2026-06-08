using UnityEngine;

namespace LaundryBear.Math
{
	public static class VectorUtils
	{
		public static Vector3 MemberwiseDivide(Vector3 numerator, Vector3 divisor)
		{
			numerator.x /= divisor.x;
			numerator.y /= divisor.y;
			numerator.z /= divisor.z;
			return numerator;
		}

		public static Vector3 MemberwiseDivide(this Vector3 numerator, float divisor)
		{
			numerator.x /= divisor;
			numerator.y /= divisor;
			numerator.z /= divisor;
			return numerator;
		}
	}
}
