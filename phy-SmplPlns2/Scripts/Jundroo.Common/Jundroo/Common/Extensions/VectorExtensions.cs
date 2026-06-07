using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class VectorExtensions
	{
		public static Vector2 Clamp(this Vector2 v, float minValue, float maxValue)
		{
			return new Vector2(Mathf.Clamp(v.x, minValue, maxValue), Mathf.Clamp(v.y, minValue, maxValue));
		}

		public static Vector2d Clamp(this Vector2d v, double minValue, double maxValue)
		{
			return new Vector2d(System.Math.Clamp(v.x, minValue, maxValue), System.Math.Clamp(v.y, minValue, maxValue));
		}

		public static Vector2i Clamp(this Vector2i v, int minValue, int maxValue)
		{
			return new Vector2i(System.Math.Clamp(v.x, minValue, maxValue), System.Math.Clamp(v.y, minValue, maxValue));
		}

		public static Vector2 Clamp(this Vector2 v, Vector2 minValues, Vector2 maxValues)
		{
			return new Vector2(Mathf.Clamp(v.x, minValues.x, maxValues.x), Mathf.Clamp(v.y, minValues.y, maxValues.y));
		}

		public static Vector2d Clamp(this Vector2d v, Vector2d minValues, Vector2d maxValues)
		{
			return new Vector2d(System.Math.Clamp(v.x, minValues.x, maxValues.x), System.Math.Clamp(v.y, minValues.y, maxValues.y));
		}

		public static Vector2i Clamp(this Vector2i v, Vector2i minValues, Vector2i maxValues)
		{
			return new Vector2i(System.Math.Clamp(v.x, minValues.x, maxValues.x), System.Math.Clamp(v.y, minValues.y, maxValues.y));
		}

		public static Vector3 Clamp(this Vector3 v, float minValue, float maxValue)
		{
			return new Vector3(Mathf.Clamp(v.x, minValue, maxValue), Mathf.Clamp(v.y, minValue, maxValue), Mathf.Clamp(v.z, minValue, maxValue));
		}

		public static Vector3d Clamp(this Vector3d v, double minValue, double maxValue)
		{
			return new Vector3d(System.Math.Clamp(v.x, minValue, maxValue), System.Math.Clamp(v.y, minValue, maxValue), System.Math.Clamp(v.z, minValue, maxValue));
		}

		public static Vector3i Clamp(this Vector3i v, int minValue, int maxValue)
		{
			return new Vector3i(System.Math.Clamp(v.x, minValue, maxValue), System.Math.Clamp(v.y, minValue, maxValue), System.Math.Clamp(v.z, minValue, maxValue));
		}

		public static Vector3 Clamp(this Vector3 v, Vector3 minValues, Vector3 maxValues)
		{
			return new Vector3(Mathf.Clamp(v.x, minValues.x, maxValues.x), Mathf.Clamp(v.y, minValues.y, maxValues.y), Mathf.Clamp(v.z, minValues.z, maxValues.z));
		}

		public static Vector3d Clamp(this Vector3 v, Vector3d minValues, Vector3d maxValues)
		{
			return new Vector3d(System.Math.Clamp(v.x, minValues.x, maxValues.x), System.Math.Clamp(v.y, minValues.y, maxValues.y), System.Math.Clamp(v.z, minValues.z, maxValues.z));
		}

		public static Vector3i Clamp(this Vector3i v, Vector3i minValues, Vector3i maxValues)
		{
			return new Vector3i(System.Math.Clamp(v.x, minValues.x, maxValues.x), System.Math.Clamp(v.y, minValues.y, maxValues.y), System.Math.Clamp(v.z, minValues.z, maxValues.z));
		}

		public static Vector2 Copy(this Vector2 v, float? x = null, float? y = null)
		{
			return new Vector2(x ?? v.x, y ?? v.y);
		}

		public static Vector2d Copy(this Vector2d v, double? x = null, double? y = null)
		{
			return new Vector2d(x ?? v.x, y ?? v.y);
		}

		public static Vector2i Copy(this Vector2i v, int? x = null, int? y = null)
		{
			return new Vector2i(x ?? v.x, y ?? v.y);
		}

		public static Vector3 Copy(this Vector3 v, float? x = null, float? y = null, float? z = null)
		{
			return new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
		}

		public static Vector3d Copy(this Vector3d v, double? x = null, double? y = null, double? z = null)
		{
			return new Vector3d(x ?? v.x, y ?? v.y, z ?? v.z);
		}

		public static Vector3i Copy(this Vector3i v, int? x = null, int? y = null, int? z = null)
		{
			return new Vector3i(x ?? v.x, y ?? v.y, z ?? v.z);
		}

		public static Vector4 Copy(this Vector4 v, float? x = null, float? y = null, float? z = null, float? w = null)
		{
			return new Vector4(x ?? v.x, y ?? v.y, z ?? v.z, w ?? v.w);
		}

		public static Vector4d Copy(this Vector4d v, double? x = null, double? y = null, double? z = null, double? w = null)
		{
			return new Vector4d(x ?? v.x, y ?? v.y, z ?? v.z, w ?? v.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (Vector3 Normalized, float Magnitude) GetNormalizedAndMagnitude(this Vector3 v)
		{
			float magnitude = v.magnitude;
			return (Normalized: (magnitude > 1E-05f) ? (v / magnitude) : Vector3.zero, Magnitude: magnitude);
		}

		public static float MagnitudeXY(this Vector3 v)
		{
			return (float)System.Math.Sqrt(v.x * v.x + v.y * v.y);
		}

		public static float MagnitudeXYSquared(this Vector3 v)
		{
			return v.x * v.x + v.y * v.y;
		}

		public static float MagnitudeXZ(this Vector3 v)
		{
			return (float)System.Math.Sqrt(v.x * v.x + v.z * v.z);
		}

		public static float MagnitudeXZSquared(this Vector3 v)
		{
			return v.x * v.x + v.z * v.z;
		}

		public static float MagnitudeYZ(this Vector3 v)
		{
			return (float)System.Math.Sqrt(v.y * v.y + v.z * v.z);
		}

		public static float MagnitudeYZSquared(this Vector3 v)
		{
			return v.y * v.y + v.z * v.z;
		}
	}
}
