using UnityEngine;

namespace Shapes
{
	public static class RectPivotExtensions
	{
		public static Rect GetRect(this RectPivot pivot, Vector2 size)
		{
			return pivot.GetRect(size.x, size.y);
		}

		public static Rect GetRect(this RectPivot pivot, float w, float h)
		{
			if (pivot != RectPivot.Corner)
			{
				return new Rect((0f - w) / 2f, (0f - h) / 2f, w, h);
			}
			return new Rect(0f, 0f, w, h);
		}
	}
}
