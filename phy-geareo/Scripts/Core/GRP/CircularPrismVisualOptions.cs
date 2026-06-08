using System;

namespace GRP
{
	[Serializable]
	public struct CircularPrismVisualOptions
	{
		public int segments;

		public float topRadius;

		public float bottomRadius;

		public float height;

		public static CircularPrismVisualOptions FromPart(CylinderPart part)
		{
			return default(CircularPrismVisualOptions);
		}
	}
}
