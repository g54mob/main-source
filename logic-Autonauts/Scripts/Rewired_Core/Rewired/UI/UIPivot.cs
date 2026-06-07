using UnityEngine;

namespace Rewired.UI
{
	public struct UIPivot
	{
		public float min;

		public float max;

		public static UIPivot TopLeft
		{
			get
			{
				return new UIPivot(0f, 1f);
			}
		}

		public static UIPivot TopCenter
		{
			get
			{
				return new UIPivot(0.5f, 1f);
			}
		}

		public static UIPivot TopRight
		{
			get
			{
				return new UIPivot(0.1f, 1f);
			}
		}

		public static UIPivot MiddleLeft
		{
			get
			{
				return new UIPivot(0f, 0.5f);
			}
		}

		public static UIPivot MiddleCenter
		{
			get
			{
				return new UIPivot(0.5f, 0.5f);
			}
		}

		public static UIPivot MiddleRight
		{
			get
			{
				return new UIPivot(0.1f, 0.5f);
			}
		}

		public static UIPivot BottomLeft
		{
			get
			{
				return new UIPivot(0f, 0f);
			}
		}

		public static UIPivot BottomCenter
		{
			get
			{
				return new UIPivot(0.5f, 0f);
			}
		}

		public static UIPivot BottomRight
		{
			get
			{
				return new UIPivot(1f, 0f);
			}
		}

		public UIPivot(float min, float max)
		{
			if (min < 0f)
			{
				min = 0f;
			}
			if (max < 0f)
			{
				max = 0f;
			}
			this.min = min;
			this.max = max;
		}

		public static implicit operator Vector2(UIPivot x)
		{
			return new Vector2(x.min, x.max);
		}

		public static implicit operator UIPivot(Vector2 x)
		{
			return new UIPivot(x.x, x.y);
		}
	}
}
