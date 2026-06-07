using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class Vector3Extensions
	{
		public static Vector3 FlattenX(this Vector3 vector)
		{
			vector.x = 0f;
			return vector;
		}

		public static Vector3 FlattenY(this Vector3 vector)
		{
			vector.y = 0f;
			return vector;
		}

		public static Vector3 FlattenZ(this Vector3 vector)
		{
			vector.z = 0f;
			return vector;
		}

		public static Vector3 NegateX(this Vector3 vector)
		{
			vector.x = 0f - vector.x;
			return vector;
		}

		public static Vector3 NegateY(this Vector3 vector)
		{
			vector.y = 0f - vector.y;
			return vector;
		}

		public static Vector3 NegateZ(this Vector3 vector)
		{
			vector.z = 0f - vector.z;
			return vector;
		}

		public static Vector3 SetX(this Vector3 vector, float xValue)
		{
			vector.x = xValue;
			return vector;
		}

		public static Vector3 SetY(this Vector3 vector, float yValue)
		{
			vector.y = yValue;
			return vector;
		}

		public static Vector3 SetZ(this Vector3 vector, float zValue)
		{
			vector.z = zValue;
			return vector;
		}

		public static Vector2 ToHorizontal2D(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.z);
		}

		public static Vector3Int RoundToInt(this Vector3 vector)
		{
			return new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
		}

		public static Vector3 ToScreenPoint(this Vector3 vector)
		{
			return new Vector3(vector.x, vector.y, 1f);
		}

		public static Vector3 Mul(this Vector3 vector, Vector3 multiplier)
		{
			return new Vector3(vector.x * multiplier.x, vector.y * multiplier.y, vector.z * multiplier.z);
		}

		public static Vector3 MulX(this Vector3 vector, float multiplier)
		{
			return new Vector3(vector.x * multiplier, vector.y, vector.z);
		}

		public static Vector3 MulY(this Vector3 vector, float multiplier)
		{
			return new Vector3(vector.x, vector.y * multiplier, vector.z);
		}

		public static Vector3 MulZ(this Vector3 vector, float multiplier)
		{
			return new Vector3(vector.x, vector.y, vector.z * multiplier);
		}

		public static Vector3 Div(this Vector3 vector, Vector3 multiplier)
		{
			return new Vector3(vector.x / multiplier.x, vector.y / multiplier.y, vector.z / multiplier.z);
		}

		public static Vector3 KeepX(this Vector3 vector)
		{
			vector.y = 0f;
			vector.z = 0f;
			return vector;
		}

		public static Vector3 KeepY(this Vector3 vector)
		{
			vector.x = 0f;
			vector.z = 0f;
			return vector;
		}

		public static Vector3 KeepZ(this Vector3 vector)
		{
			vector.x = 0f;
			vector.y = 0f;
			return vector;
		}

		public static Vector3 NormalizeFromSqrMagnitude(this Vector3 vector, float sqrMagnitude)
		{
			sqrMagnitude = Mathf.Sqrt(sqrMagnitude);
			if (!((double)sqrMagnitude > 9.999999747378752E-06))
			{
				return Vector3.zero;
			}
			return vector / sqrMagnitude;
		}

		public static Vector3 NormalizeFromMagnitude(this Vector3 vector, float magnitude)
		{
			if (!((double)magnitude > 9.999999747378752E-06))
			{
				return Vector3.zero;
			}
			return vector / magnitude;
		}
	}
}
