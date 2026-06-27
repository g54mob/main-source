using System;
using UnityEngine;

namespace Helpers.Utils
{
	public static class MathfUtils
	{
		public static bool InsideBox(Vector3 point, Vector3 center, Vector3 boundSize, Quaternion rotation)
		{
			Vector3 vector = boundSize / 2f;
			point = Matrix4x4.TRS(center, rotation, Vector3.one).inverse.MultiplyPoint3x4(point);
			if (point.x <= vector.x && point.x > 0f - vector.x && point.y <= vector.y && point.y > 0f - vector.y && point.z <= vector.z)
			{
				return point.z > 0f - vector.z;
			}
			return false;
		}

		public static float RoundUp(float value, float multipleOf)
		{
			if (float.IsNaN(value) || float.IsNaN(multipleOf))
			{
				return float.MaxValue;
			}
			if (Mathf.Approximately(multipleOf, 0f))
			{
				multipleOf = 1f;
			}
			return (float)Math.Round(ConvertToDecimal(value) / ConvertToDecimal(multipleOf), MidpointRounding.AwayFromZero) * multipleOf;
		}

		private static decimal ConvertToDecimal(float value)
		{
			if (value >= 7.9228163E+28f)
			{
				return decimal.MaxValue;
			}
			if (value <= -7.9228163E+28f)
			{
				return decimal.MinValue;
			}
			return Convert.ToDecimal(value);
		}

		public static Vector3 FallbackIfNan(Vector3 value, Vector3 fallback)
		{
			if (!IsNan(value))
			{
				return value;
			}
			return fallback;
		}

		public static bool IsNan(Vector3 value)
		{
			if (!float.IsNaN(value.x) && !float.IsNaN(value.y))
			{
				return float.IsNaN(value.z);
			}
			return true;
		}
	}
}
