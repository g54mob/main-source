using Unity.Mathematics;

namespace Drawing
{
	public struct LabelAlignment
	{
		public float2 relativePivot;

		public float2 pixelOffset;

		public static readonly LabelAlignment TopLeft;

		public static readonly LabelAlignment MiddleLeft;

		public static readonly LabelAlignment BottomLeft;

		public static readonly LabelAlignment BottomCenter;

		public static readonly LabelAlignment BottomRight;

		public static readonly LabelAlignment MiddleRight;

		public static readonly LabelAlignment TopRight;

		public static readonly LabelAlignment TopCenter;

		public static readonly LabelAlignment Center;

		public LabelAlignment withPixelOffset(float x, float y)
		{
			return default(LabelAlignment);
		}
	}
}
