using System;
using UnityEngine;

namespace ScriptHelpers
{
	public static class VectorExtend
	{
		public const float maxFactor = 2f;

		public static Vector2 Rotate(this Vector2 v, float delta)
		{
			return new Vector2(v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta), v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta));
		}

		public static Vector3 GetRightCorner(this Vector2 point, Vector2 pointDown, Vector2 pointUp, float d, Vector2 limitCorner, Vector2 dir1, Vector2 dir2)
		{
			Vector2 vector = point.RightPointOffset(pointDown, pointUp, d);
			float num = vector.KClampedToCorner(limitCorner - point, dir1, dir2);
			Vector2 vector2 = point + vector * num;
			return new Vector3(vector2.x, vector2.y, num);
		}

		public static Vector3 GetLeftCorner(this Vector2 point, Vector2 pointDown, Vector2 pointUp, float d, Vector2 limitCorner, Vector2 dir1, Vector2 dir2)
		{
			Vector2 vector = point.LeftPointOffset(pointDown, pointUp, d);
			float num = vector.KClampedToCorner(limitCorner - point, dir1, dir2);
			Vector2 vector2 = point + vector * num;
			return new Vector3(vector2.x, vector2.y, num);
		}

		public static Vector2 LeftPointOffset(this Vector2 point, Vector2 pointDown, Vector2 pointUp, float d = 1f)
		{
			return point.RightPointOffset(pointDown, pointUp, 0f - d);
		}

		public static Vector2 RightPointOffset(this Vector2 point, Vector2 pointDown, Vector2 pointUp, float d = 1f)
		{
			Vector2 normalized = (pointUp - point).normalized;
			Vector2 normalized2 = (pointDown - point).normalized;
			float num = MathF.PI / 180f * Vector2.SignedAngle(normalized2, normalized);
			if (num < 0f)
			{
				num += MathF.PI * 2f;
			}
			float num2 = Mathf.Sqrt(1f + Mathf.Pow(Mathf.Tan((MathF.PI - num) / 2f), 2f));
			Vector2 result = (Mathf.Approximately(num, MathF.PI) ? new Vector2(normalized.y, 0f - normalized.x) : (normalized + normalized2).normalized) * num2 * d;
			if (num > MathF.PI)
			{
				result *= -1f;
			}
			return result;
		}

		public static float KToLine(this Vector2 offset, Vector2 start, Vector2 move)
		{
			return (start.x * move.y - start.y * move.x) / (offset.x * move.y - offset.y * move.x);
		}

		public static Vector2 ClampToLine(this Vector2 offset, Vector2 start, Vector2 move)
		{
			float b = offset.KToLine(start, move);
			return offset * Mathf.Min(1f, b);
		}

		public static float KClampedToCorner(this Vector2 offset, Vector2 corner, Vector2 dir1, Vector2 dir2)
		{
			float num = offset.KToLine(corner, dir1);
			float num2 = offset.KToLine(corner, dir2);
			return Mathf.Clamp01(Mathf.Min(1f, (num >= 0f) ? num : 1f, (num2 >= 0f) ? num2 : 1f));
		}

		public static Vector2 ClampToCorner(this Vector2 offset, Vector2 corner, Vector2 dir1, Vector2 dir2)
		{
			return offset * offset.KClampedToCorner(corner, dir1, dir2);
		}

		public static Vector2 RightClamp(this Vector2 point, Vector2 clamp)
		{
			if (!(point.x > clamp.x))
			{
				return point;
			}
			return clamp;
		}

		public static Vector2 LeftClamp(this Vector2 point, Vector2 clamp)
		{
			if (!(point.x < clamp.x))
			{
				return point;
			}
			return clamp;
		}

		public static Vector2 TopClamp(this Vector2 point, Vector2 clamp)
		{
			if (!(point.y > clamp.y))
			{
				return point;
			}
			return clamp;
		}

		public static Vector2 BottomClamp(this Vector2 point, Vector2 clamp)
		{
			if (!(point.y < clamp.y))
			{
				return point;
			}
			return clamp;
		}

		public static Vector2 YX(this Vector2 vec)
		{
			return new Vector2(vec.y, vec.x);
		}
	}
}
