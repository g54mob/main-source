using UnityEngine;

namespace Rewired.UI
{
	public struct UIAnchor
	{
		public Vector2 min;

		public Vector2 max;

		public static UIAnchor TopLeft
		{
			get
			{
				return new UIAnchor(0f, 1f, 0f, 1f);
			}
		}

		public static UIAnchor TopCenter
		{
			get
			{
				return new UIAnchor(0.5f, 1f, 0.5f, 1f);
			}
		}

		public static UIAnchor TopRight
		{
			get
			{
				return new UIAnchor(1f, 1f, 1f, 1f);
			}
		}

		public static UIAnchor MiddleLeft
		{
			get
			{
				return new UIAnchor(0f, 0.5f, 0f, 0.5f);
			}
		}

		public static UIAnchor MiddleCenter
		{
			get
			{
				return new UIAnchor(0.5f, 0.5f, 0.5f, 0.5f);
			}
		}

		public static UIAnchor MiddleRight
		{
			get
			{
				return new UIAnchor(1f, 0.5f, 1f, 0.5f);
			}
		}

		public static UIAnchor BottomLeft
		{
			get
			{
				return new UIAnchor(0f, 0f, 0f, 0f);
			}
		}

		public static UIAnchor BottomCenter
		{
			get
			{
				return new UIAnchor(0.5f, 0f, 0.5f, 0f);
			}
		}

		public static UIAnchor BottomRight
		{
			get
			{
				return new UIAnchor(1f, 0f, 1f, 0f);
			}
		}

		public static UIAnchor TopHStretch
		{
			get
			{
				return new UIAnchor(0f, 1f, 1f, 1f);
			}
		}

		public static UIAnchor MiddleHStretch
		{
			get
			{
				return new UIAnchor(0f, 0.5f, 1f, 0.5f);
			}
		}

		public static UIAnchor BottomHStretch
		{
			get
			{
				return new UIAnchor(0f, 0f, 1f, 0f);
			}
		}

		public static UIAnchor LeftVStretch
		{
			get
			{
				return new UIAnchor(0f, 0f, 0f, 1f);
			}
		}

		public static UIAnchor CenterVStretch
		{
			get
			{
				return new UIAnchor(0.5f, 0f, 0.5f, 1f);
			}
		}

		public static UIAnchor RightVStretch
		{
			get
			{
				return new UIAnchor(1f, 0f, 1f, 1f);
			}
		}

		public static UIAnchor Stretch
		{
			get
			{
				return new UIAnchor(0f, 0f, 1f, 1f);
			}
		}

		public UIAnchor(float minX, float minY, float maxX, float maxY)
		{
			if (minX < 0f)
			{
				minX = 0f;
			}
			if (minY < 0f)
			{
				minY = 0f;
			}
			if (maxX < 0f)
			{
				maxX = 0f;
			}
			if (maxY < 0f)
			{
				maxY = 0f;
			}
			min = new Vector2(minX, minY);
			max = new Vector2(maxX, maxY);
		}

		public UIAnchor(Vector2 min, Vector2 max)
		{
			if (min.x < 0f)
			{
				min.x = 0f;
			}
			if (min.y < 0f)
			{
				min.y = 0f;
			}
			if (max.x < 0f)
			{
				max.x = 0f;
			}
			if (max.y < 0f)
			{
				max.y = 0f;
			}
			this.min = min;
			this.max = max;
		}
	}
}
