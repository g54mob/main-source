using System;

namespace Assets.Scripts.Craft.Paint
{
	[Flags]
	public enum PaintTextureMaskNormalizationFlags
	{
		None = 0,
		NormalizeColorMask = 1,
		NormalizePropertyMask = 2
	}
}
