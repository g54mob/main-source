using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class Vector3Extensions
	{
		public static Vector3 Clamp(this Vector3 v, float minValue, float maxValue)
		{
			return new Vector3(Mathf.Clamp(v.x, minValue, maxValue), Mathf.Clamp(v.y, minValue, maxValue), Mathf.Clamp(v.z, minValue, maxValue));
		}

		public static Vector3 Clamp(this Vector3 v, Vector3 minValues, Vector3 maxValues)
		{
			return new Vector3(Mathf.Clamp(v.x, minValues.x, maxValues.x), Mathf.Clamp(v.y, minValues.y, maxValues.y), Mathf.Clamp(v.z, minValues.z, maxValues.z));
		}

		public static Vector3 SetX(this Vector3 v, float x)
		{
			v.x = x;
			return v;
		}

		public static Vector3 SetY(this Vector3 v, float y)
		{
			v.y = y;
			return v;
		}

		public static Vector3 SetZ(this Vector3 v, float z)
		{
			v.z = z;
			return v;
		}

		public static Vector4 ToVector4(this Vector3 v, float w)
		{
			return new Vector4(v.x, v.y, v.z, w);
		}

		public static Vector2 XY(this Vector3 v)
		{
			return new Vector2(v.x, v.y);
		}

		public static Vector2 XZ(this Vector3 v)
		{
			return new Vector2(v.x, v.z);
		}

		public static Vector3 XZY(this Vector3 v)
		{
			return new Vector3(v.x, v.z, v.y);
		}

		public static Vector2 YX(this Vector3 v)
		{
			return new Vector2(v.y, v.x);
		}

		public static Vector3 YXZ(this Vector3 v)
		{
			return new Vector3(v.y, v.x, v.z);
		}

		public static Vector2 YZ(this Vector3 v)
		{
			return new Vector2(v.y, v.z);
		}

		public static Vector3 YZX(this Vector3 v)
		{
			return new Vector3(v.y, v.z, v.x);
		}

		public static Vector2 ZX(this Vector3 v)
		{
			return new Vector2(v.z, v.x);
		}

		public static Vector3 ZXY(this Vector3 v)
		{
			return new Vector3(v.z, v.x, v.y);
		}

		public static Vector2 ZY(this Vector3 v)
		{
			return new Vector2(v.z, v.y);
		}

		public static Vector3 ZYX(this Vector3 v)
		{
			return new Vector3(v.z, v.y, v.x);
		}
	}
}
