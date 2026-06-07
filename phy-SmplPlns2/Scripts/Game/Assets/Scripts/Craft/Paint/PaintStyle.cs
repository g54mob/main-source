using Jundroo.Common.Attributes;

namespace Assets.Scripts.Craft.Paint
{
	public enum PaintStyle
	{
		[DisplayName("Solid Color")]
		SolidColor = 0,
		[DisplayName("Flat Texture")]
		SinglePlaneTextureColorMask = 1,
		[DisplayName("Wrapped Texture")]
		TriPlaneTextureColorMask = 2,
		[UiVisibility(UiVisibility.Hidden)]
		AlbedoTexture = 3,
		[UiVisibility(UiVisibility.Hidden)]
		AlbedoTextureSupersampledWithMipmapBias = 4
	}
}
