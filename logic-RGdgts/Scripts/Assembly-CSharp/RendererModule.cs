using UnityEngine;

public class RendererModule : Module
{
	protected RenderTexture bufferRenderTexture;

	private int width;

	private int height;

	private static Material renderPointMaterial;

	private static Material renderPointGridMaterial;

	private static Material renderLineMaterial;

	private static Material renderCircleMaterial;

	private static Material fillCircleMaterial;

	private static Material drawRGBMaterial;

	private static Material drawPaletteMaterial;

	private static Material rasterRGBMaterial;

	private static Material rasterPaletteMaterial;

	private static Material fillColorMaterial;

	public override void AllocResources()
	{
	}

	protected void SetRenderTarget(RenderTexture renderTexture)
	{
	}

	public override void OnTurnOff()
	{
	}

	private void _DrawSprite(Vector2Int position, SpriteSheetAsset spriteSheet, RectInt spriteRect, Color tintColor, Color backgroundColor)
	{
	}

	public void _RasterSprite(Vector2Int position1, Vector2Int position2, Vector2Int position3, Vector2Int position4, SpriteSheetAsset spriteSheet, RectInt spriteRect, Color tintColor, Color backgroundColor)
	{
	}

	private void _DrawRenderBuffer(Vector2Int position, RenderBufferAsset renderBuffer, RectInt sourceRect, int width, int height)
	{
	}

	public void _RasterRenderBuffer(Vector2Int position1, Vector2Int position2, Vector2Int position3, Vector2Int position4, RenderBufferAsset renderBuffer, RectInt sourceRect)
	{
	}

	public void Script_Clear(Color color)
	{
	}

	public void Script_SetPixel(Vector2Int position, Color color)
	{
	}

	public void Script_DrawPointGrid(Vector2Int gridOffset, int dotsDistance, Color color)
	{
	}

	public void Script_DrawLine(Vector2Int start, Vector2Int end, Color color)
	{
	}

	public void Script_DrawCircle(Vector2Int position, int radius, Color color)
	{
	}

	public void Script_FillCircle(Vector2Int position, int radius, Color color)
	{
	}

	public void Script_DrawRect(Vector2Int position1, Vector2Int position2, Color color)
	{
	}

	public void Script_FillRect(Vector2Int position1, Vector2Int position2, Color color)
	{
	}

	public void Script_DrawTriangle(Vector2Int position1, Vector2Int position2, Vector2Int position3, Color color)
	{
	}

	public void Script_FillTriangle(Vector2Int position1, Vector2Int position2, Vector2Int position3, Color color)
	{
	}

	public void Script_DrawSprite(Vector2Int position, SpriteSheetAsset spriteSheet, int spriteX, int spriteY, Color tintColor, Color backgroundColor)
	{
	}

	public void Script_DrawCustomSprite(Vector2Int position, SpriteSheetAsset spriteSheet, Vector2Int spriteOffset, Vector2Int spriteSize, Color tintColor, Color backgroundColor)
	{
	}

	public void Script_DrawText(Vector2Int position, SpriteSheetAsset fontSprite, string text, Color textColor, Color backgroundColor)
	{
	}

	public void Script_RasterSprite(Vector2Int position1, Vector2Int position2, Vector2Int position3, Vector2Int position4, SpriteSheetAsset spriteSheet, int spriteX, int spriteY, Color tintColor, Color backgroundColor)
	{
	}

	public void Script_RasterCustomSprite(Vector2Int position1, Vector2Int position2, Vector2Int position3, Vector2Int position4, SpriteSheetAsset spriteSheet, Vector2Int spriteOffset, Vector2Int spriteSize, Color tintColor, Color backgroundColor)
	{
	}

	public void Script_DrawRenderBuffer(Vector2Int position, RenderBufferAsset renderBuffer, int width, int height)
	{
	}

	public void Script_RasterRenderBuffer(Vector2Int position1, Vector2Int position2, Vector2Int position3, Vector2Int position4, RenderBufferAsset renderBuffer)
	{
	}

	public void Script_SetPixelData(LuaPixelData pixelData)
	{
	}

	public void Script_BlitPixelData(Vector2Int position, LuaPixelData pixelData)
	{
	}
}
