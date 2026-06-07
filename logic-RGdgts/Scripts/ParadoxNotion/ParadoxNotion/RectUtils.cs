using UnityEngine;

namespace ParadoxNotion
{
	public static class RectUtils
	{
		public static Rect GetBoundRect(params Rect[] rects)
		{
			return default(Rect);
		}

		public static Rect GetBoundRect(params Vector2[] positions)
		{
			return default(Rect);
		}

		public static bool Encapsulates(this Rect a, Rect b)
		{
			return false;
		}

		public static Rect ExpandBy(this Rect rect, float margin)
		{
			return default(Rect);
		}

		public static Rect ExpandBy(this Rect rect, float xMargin, float yMargin)
		{
			return default(Rect);
		}

		public static Rect ExpandBy(this Rect rect, float left, float top, float right, float bottom)
		{
			return default(Rect);
		}

		public static Rect TransformSpace(this Rect rect, Rect oldContainer, Rect newContainer)
		{
			return default(Rect);
		}

		public static Vector2 TransformSpace(this Vector2 vector, Rect oldContainer, Rect newContainer)
		{
			return default(Vector2);
		}
	}
}
