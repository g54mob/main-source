using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpriteSheetAsset : Asset
{
	[Serializable]
	public class Serialized : SerializedAsset
	{
		public int width;

		public int height;

		public uint[] pixels;

		public Vector2Int gridSize;

		public Dictionary<uint, Vector2Int> gridIds;

		public bool isRGB;

		public Color[] paletteColors;

		public Serialized()
		{
		}

		public Serialized(SpriteSheetAsset sprite)
		{
		}

		public override Asset Instantiate(SerializedAssetMetadata metadata)
		{
			return null;
		}
	}

	public static Vector2Int defaultSize;

	private int width;

	private int height;

	public uint[] pixels;

	public Texture2D texture;

	public Vector2Int gridSize;

	public Dictionary<uint, Vector2Int> gridIds;

	public bool isRGB;

	private static Material blitSpritesheetMaterial;

	private static Material blitColorMaterial;

	public int Width => 0;

	public int Height => 0;

	public PaletteAsset paletteAsset { get; private set; }

	public PaletteAsset Script_Palette => null;

	public SpriteSheetAsset()
	{
	}

	public SpriteSheetAsset(string name, int width, int height, uint[] pixels, Color[] paletteColors)
	{
	}

	private void CreatePaletteSubAsset(Color[] paletteColors)
	{
	}

	private void DestroyPaletteSubAsset()
	{
	}

	public void SetSize(int width, int height)
	{
	}

	public void SetSize(Vector2Int size)
	{
	}

	public void LoadTextureRGB(Texture2D texture)
	{
	}

	public void LoadTexture(Texture2D texture)
	{
	}

	public void SetupAsFont(string escapedChars, int charWidth, int charHeight)
	{
	}

	public void SetFontChars(string escapedChars)
	{
	}

	private void SetupGridIds(char[] chars)
	{
	}

	public string GetFontChars()
	{
		return null;
	}

	public void RefreshTexture()
	{
	}

	public override AssetType GetAssetType()
	{
		return default(AssetType);
	}

	public override void Dispose()
	{
	}

	public Texture2D GenerateColorTexture(RectInt? rect = null)
	{
		return null;
	}

	public override SerializedAsset ToSerializedAsset()
	{
		return null;
	}

	private UnityWebRequest LoadImageFromFile(string path)
	{
		return null;
	}

	private Texture2D GetTextureFromRequest(UnityWebRequest request)
	{
		return null;
	}

	public override bool LoadFromFile(string path, Asset[] additionalInitAssets)
	{
		return false;
	}

	public static Vector2Int? ParseGridSizeFromFilename(string path)
	{
		return null;
	}

	public IEnumerator LoadFromFileAsync(string path, bool allowStreaming, Action<bool> onComplete)
	{
		return null;
	}

	private void ResizeTexture(Texture2D tex)
	{
	}

	public override void InitDefaultEditorAsset()
	{
	}

	public void SetMonocromaticSprite(uint index)
	{
	}

	private Color32[] GetColorData(RectInt? rect = null)
	{
		return null;
	}

	public PixelData Script_GetPixelData(int spriteX, int spriteY)
	{
		return null;
	}

	public PixelData Script_GetPixelData()
	{
		return null;
	}
}
