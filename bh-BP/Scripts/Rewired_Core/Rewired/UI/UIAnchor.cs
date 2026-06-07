using UnityEngine;

namespace Rewired.UI
{
	public struct UIAnchor
	{
		public Vector2 min;

		public Vector2 max;

		public static UIAnchor TopLeft => default(UIAnchor);

		public static UIAnchor TopCenter => default(UIAnchor);

		public static UIAnchor TopRight => default(UIAnchor);

		public static UIAnchor MiddleLeft => default(UIAnchor);

		public static UIAnchor MiddleCenter => default(UIAnchor);

		public static UIAnchor MiddleRight => default(UIAnchor);

		public static UIAnchor BottomLeft => default(UIAnchor);

		public static UIAnchor BottomCenter => default(UIAnchor);

		public static UIAnchor BottomRight => default(UIAnchor);

		public static UIAnchor TopHStretch => default(UIAnchor);

		public static UIAnchor MiddleHStretch => default(UIAnchor);

		public static UIAnchor BottomHStretch => default(UIAnchor);

		public static UIAnchor LeftVStretch => default(UIAnchor);

		public static UIAnchor CenterVStretch => default(UIAnchor);

		public static UIAnchor RightVStretch => default(UIAnchor);

		public static UIAnchor Stretch => default(UIAnchor);

		public UIAnchor(float P_0, float P_1, float P_2, float P_3)
		{
			min = default(Vector2);
			max = default(Vector2);
		}

		public UIAnchor(Vector2 P_0, Vector2 P_1)
		{
			min = default(Vector2);
			max = default(Vector2);
		}
	}
}
