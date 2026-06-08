using UnityEngine;

public class ParallaxWindow : TilingAsciiSprite
{
	public float parallaxScaleX = 1f;

	public int parallaxOffsetX;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, 1f, ColorConstants.white);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		scrollX = Mathf.RoundToInt((float)offsetX * parallaxScaleX) + parallaxOffsetX;
		base.Draw(r, offsetX, offsetY, colorMultiply, tint);
	}
}
