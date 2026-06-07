using UnityEngine;

namespace Rewired.UI
{
	public struct UIPivot
	{
		public float min;

		public float max;

		public static UIPivot TopLeft => default(UIPivot);

		public static UIPivot TopCenter => default(UIPivot);

		public static UIPivot TopRight => default(UIPivot);

		public static UIPivot MiddleLeft => default(UIPivot);

		public static UIPivot MiddleCenter => default(UIPivot);

		public static UIPivot MiddleRight => default(UIPivot);

		public static UIPivot BottomLeft => default(UIPivot);

		public static UIPivot BottomCenter => default(UIPivot);

		public static UIPivot BottomRight => default(UIPivot);

		public UIPivot(float min, float max)
		{
			this.min = 0f;
			this.max = 0f;
		}

		public static implicit operator Vector2(UIPivot x)
		{
			return default(Vector2);
		}

		public static implicit operator UIPivot(Vector2 x)
		{
			return default(UIPivot);
		}
	}
}
