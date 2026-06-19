using System;
using UnityEngine;

namespace TH20
{
	public static class Vector3Extensions
	{
		public static Vector2 Xy(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.y);
		}

		public static Vector2 Xz(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.z);
		}

		public static Vector2 Yz(this Vector3 vector)
		{
			return new Vector2(vector.y, vector.z);
		}

		public static Vector2 Yx(this Vector3 vector)
		{
			return new Vector2(vector.y, vector.x);
		}

		public static Vector2 Zx(this Vector3 vector)
		{
			return new Vector2(vector.z, vector.x);
		}

		public static Vector2 Zy(this Vector3 vector)
		{
			return new Vector2(vector.z, vector.y);
		}

		public static void SetX(this Vector3 v, float x)
		{
			v.x = x;
		}

		public static void SetY(this Vector3 v, float y)
		{
			v.y = y;
		}

		public static void SetZ(this Vector3 v, float z)
		{
			v.z = z;
		}

		public static void SetXz(this Vector3 v, float x, float z)
		{
			v.x = x;
			v.z = z;
		}

		public static Vector3 SnapTo(this Vector3 vector, float cellSize)
		{
			float x = (float)(int)((vector.x + cellSize * Mathf.Sign(vector.x) * 0.5f) / cellSize) * cellSize;
			float y = (float)(int)((vector.y + cellSize * Mathf.Sign(vector.y) * 0.5f) / cellSize) * cellSize;
			float z = (float)(int)((vector.z + cellSize * Mathf.Sign(vector.z) * 0.5f) / cellSize) * cellSize;
			return new Vector3(x, y, z);
		}

		public static Vector3 CellFraction(this Vector3 vector, float cellSize)
		{
			float num = (vector.x - cellSize * 0.5f) % cellSize;
			float num2 = (vector.z - cellSize * 0.5f) % cellSize;
			if (vector.x - cellSize * 0.5f < 0f)
			{
				num += cellSize;
			}
			if (vector.z - cellSize * 0.5f < 0f)
			{
				num2 += cellSize;
			}
			return new Vector3(num, 0f, num2);
		}

		public static float SquareDistance2D(this Vector3 vector, Vector3 vectorOther)
		{
			float num = vector.x - vectorOther.x;
			float num2 = vector.z - vectorOther.z;
			return num * num + num2 * num2;
		}

		public static Vector3 RotateY(this Vector3 v, float angleDeg)
		{
			float f = (0f - angleDeg) * ((float)Math.PI / 180f);
			float num = Mathf.Sin(f);
			float num2 = Mathf.Cos(f);
			return new Vector3(v.x * num2 - v.z * num, v.y, v.x * num + v.z * num2);
		}
	}
}
