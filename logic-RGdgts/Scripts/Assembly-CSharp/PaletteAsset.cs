using System;
using UnityEngine;

public class PaletteAsset : Asset
{
	[Serializable]
	public class Serialized : SerializedAsset
	{
		public Color[] colors;

		public Serialized()
		{
		}

		public Serialized(PaletteAsset source)
		{
		}

		public override Asset Instantiate(SerializedAssetMetadata metadata)
		{
			return null;
		}
	}

	private static Color[] _defaultColors;

	public Color[] colors;

	public Texture2D texture;

	public static Color[] defaultColors => null;

	public static int defaultColorsCount => 0;

	public PaletteAsset()
	{
	}

	public PaletteAsset(string name)
	{
	}

	public override AssetType GetAssetType()
	{
		return default(AssetType);
	}

	public void LoadTexture(Texture2D texture, int fixedColorsCount)
	{
	}

	public void RefreshTexture()
	{
	}

	public override void Dispose()
	{
	}

	public override SerializedAsset ToSerializedAsset()
	{
		return null;
	}

	public override bool LoadFromFile(string path, Asset[] additionalInitAssets)
	{
		return false;
	}

	public uint GetNearestColor(Color color)
	{
		return 0u;
	}
}
