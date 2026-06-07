using UnityEngine;

namespace RLD
{
	public static class RTSystemValues
	{
		public static Color XAxisColor => ColorEx.FromByteValues(219, 62, 29, byte.MaxValue);

		public static Color YAxisColor => ColorEx.FromByteValues(154, 243, 72, byte.MaxValue);

		public static Color ZAxisColor => ColorEx.FromByteValues(58, 122, 248, byte.MaxValue);

		public static Color GridLineColor => ColorEx.FromByteValues(128, 128, 128, 102);

		public static Color HoveredAxisColor => ColorEx.FromByteValues(246, 242, 50, byte.MaxValue);

		public static Color CenterAxisColor => ColorEx.FromByteValues(204, 204, 204, byte.MaxValue);

		public static float AxisAlpha => 0.3f;

		public static Color CameraBkGradientFirstColor => ColorEx.FromByteValues(71, 71, 71, byte.MaxValue);

		public static Color CameraBkGradientSecondColor => Color.black;

		public static Color GuideFillColor => new Color(0.5f, 0.5f, 0.5f, 0.1f);

		public static Color GuideBorderColor => new Color(0.8f, 0.8f, 0.8f, 0.8f);
	}
}
