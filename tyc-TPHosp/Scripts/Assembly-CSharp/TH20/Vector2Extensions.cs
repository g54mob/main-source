using System;
using UnityEngine;

namespace TH20
{
	public static class Vector2Extensions
	{
		public static Vector3 as_xz_v3(this Vector2 vector)
		{
			return new Vector3(vector.x, 0f, vector.y);
		}

		public static Vector3 to_x0y(this Vector2 vector)
		{
			return new Vector3(vector.x, 0f, vector.y);
		}

		public static Vector3 to_xy0(this Vector2 vector)
		{
			return new Vector3(vector.x, vector.y, 0f);
		}

		public static Vector3 to_xy1(this Vector2 vector)
		{
			return new Vector3(vector.x, vector.y, 1f);
		}

		public static Vector2 RotateY(this Vector2 v, float angleDeg)
		{
			float f = (0f - angleDeg) * ((float)Math.PI / 180f);
			float num = Mathf.Sin(f);
			float num2 = Mathf.Cos(f);
			return new Vector2(v.x * num2 - v.y * num, v.x * num + v.y * num2);
		}
	}
}
