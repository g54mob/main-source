using UnityEngine;

namespace RLD
{
	public static class PlaneMath
	{
		public static bool Raycast2D(Vector2 rayOrigin, Vector2 rayDir, Vector2 planeNormal, Vector2 ptOnPlane, out float t)
		{
			t = 0f;
			float num = Vector2.Dot(rayDir, planeNormal);
			if (Mathf.Abs(num) < 1E-05f)
			{
				return false;
			}
			float num2 = Vector2.Dot(rayOrigin - ptOnPlane, planeNormal);
			t = num2 / (0f - num);
			return t >= 0f;
		}
	}
}
