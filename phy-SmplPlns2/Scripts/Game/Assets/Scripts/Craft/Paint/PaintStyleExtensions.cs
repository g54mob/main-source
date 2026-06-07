namespace Assets.Scripts.Craft.Paint
{
	public static class PaintStyleExtensions
	{
		public static bool UsesColorMask(this PaintStyle value)
		{
			if (value != PaintStyle.SinglePlaneTextureColorMask)
			{
				return value == PaintStyle.TriPlaneTextureColorMask;
			}
			return true;
		}

		public static bool UsesTextureAtlas(this PaintStyle value)
		{
			if (value != PaintStyle.SinglePlaneTextureColorMask)
			{
				return value == PaintStyle.TriPlaneTextureColorMask;
			}
			return true;
		}
	}
}
