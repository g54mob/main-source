using System;

namespace GRP
{
	[Serializable]
	public struct RingVisualOptions
	{
		public int segments;

		public float topRadius;

		public float bottomRadius;

		public float topThickness;

		public float bottomThickness;

		public float arc;

		public float arcOffset;

		public float height;

		public float colliderPadding;

		public static RingVisualOptions FromPart(RingPart part)
		{
			return default(RingVisualOptions);
		}
	}
}
