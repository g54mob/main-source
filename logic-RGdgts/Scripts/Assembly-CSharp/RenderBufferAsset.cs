using System;
using UnityEngine;

public class RenderBufferAsset : Asset
{
	[Serializable]
	public class Serialized : SerializedAsset
	{
		public int width;

		public int height;

		public Serialized()
		{
		}

		public Serialized(RenderBufferAsset renderBuffer)
		{
		}

		public override Asset Instantiate(SerializedAssetMetadata metadata)
		{
			return null;
		}
	}

	private int width;

	private int height;

	public RenderTexture texture;

	public int Width => 0;

	public int Height => 0;

	public int Script_Width => 0;

	public int Script_Height => 0;

	public RenderBufferAsset(string name, int width, int height)
	{
	}

	public void SetSize(int width, int height)
	{
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

	public override SerializedAsset ToSerializedAsset()
	{
		return null;
	}

	public override bool LoadFromFile(string path, Asset[] additionalInitAssets)
	{
		return false;
	}

	public PixelData Script_GetPixelData()
	{
		return null;
	}
}
