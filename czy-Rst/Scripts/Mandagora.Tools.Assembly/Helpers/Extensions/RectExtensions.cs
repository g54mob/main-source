using UnityEngine;

namespace Helpers.Extensions
{
	public static class RectExtensions
	{
		public static Vector2 ProjectPointToEdge(this Rect rect, Vector2 point)
		{
			Vector2 vector = point - rect.center;
			Vector2 vector2 = rect.size / 2f;
			float num = vector.y / vector.x;
			if (vector.y < 0f)
			{
				vector.x = (0f - vector2.y) / num;
				vector.y = 0f - vector2.y;
			}
			else if (vector.y > 0f)
			{
				vector.x = vector2.y / num;
				vector.y = vector2.y;
			}
			if (vector.x < 0f - vector2.x)
			{
				vector.x = 0f - vector2.x;
				vector.y = (0f - vector2.x) * num;
			}
			else if (vector.x > vector2.x)
			{
				vector.x = vector2.x;
				vector.y = vector2.x * num;
			}
			return rect.center + vector;
		}

		public static Rect Transform(this Rect r, Transform transform)
		{
			return new Rect
			{
				min = transform.TransformPoint(r.min),
				max = transform.TransformPoint(r.max)
			};
		}

		public static Rect InverseTransform(this Rect r, Transform transform)
		{
			return new Rect
			{
				min = transform.InverseTransformPoint(r.min),
				max = transform.InverseTransformPoint(r.max)
			};
		}
	}
}
