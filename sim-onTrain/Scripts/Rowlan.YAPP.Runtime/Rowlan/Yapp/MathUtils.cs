using UnityEngine;

namespace Rowlan.Yapp
{
	public class MathUtils
	{
		public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
		{
			Vector3 vector = b - a;
			return Vector3.Dot(value - a, vector) / Vector3.Dot(vector, vector);
		}
	}
}
