using UnityEngine;

public class StickerData
{
	public RenderTexture dataTexture;

	private Texture2D colorTexture;

	public Sprite sprite;

	private static Material maskPrintMaterial;

	private static Material blitDataMaterial;

	public StickerData()
	{
	}

	public StickerData(SpriteSheetAsset spritesheet, RectInt rect, Texture2D mask = null, PrintEffects printEffects = null)
	{
	}

	public StickerData(byte[] colorData)
	{
	}

	public StickerData(Texture texture)
	{
	}

	public StickerData(Texture texture, RectInt rect)
	{
	}

	public StickerData(StickerData stickerData)
	{
	}

	private void Init(Texture2D texture, Texture2D mask, PrintEffects printEffects)
	{
	}

	private void Init(Texture texture)
	{
	}

	private void Init(Texture texture, RectInt rect)
	{
	}

	public StickerData(params StickerData[] datas)
	{
	}

	public void RefreshSprite(int rotation, int border, int fixedDataHeight = -1)
	{
	}

	public Vector2Int GetFinalSize(int rotation, int border, int fixedDataHeight = -1)
	{
		return default(Vector2Int);
	}

	public RenderTexture GenerateFinalDataTexture(int rotation, int border, int fixedDataHeight = -1)
	{
		return null;
	}

	public void Blit(RenderTexture destination, Vector2Int position)
	{
	}

	public void BlitData(RenderTexture destination, Vector2Int position)
	{
	}

	public void MaskTexture(Texture2D texture, Texture2D mask)
	{
	}

	public byte[] GetColorData()
	{
		return null;
	}

	private void DisposeSprite()
	{
	}

	public void Dispose()
	{
	}
}
