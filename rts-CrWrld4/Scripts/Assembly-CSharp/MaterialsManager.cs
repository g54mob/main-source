using NBT.Tags;
using UnityEngine;

public class MaterialsManager
{
	private Material landOverlayMaterial0;

	private Material landOverlayMaterial1;

	private int landOverlayTextureNumber0;

	private int landOverlayTextureNumber1;

	private Texture2D customTexture0;

	private Texture2D customTexture1;

	private byte[] cachedCustomTextureData0;

	private byte[] cachedCustomTextureData1;

	private int stockTextureNumber0;

	private int stockTextureNumber1;

	public Material GetLandOverlayMaterial0()
	{
		return null;
	}

	public Material GetLandOverlayMaterial1()
	{
		return null;
	}

	public Material GetLandOverlayMaterial(int materialNumber)
	{
		return null;
	}

	public void RemoveAnyTexture(int materialNumber)
	{
	}

	public void SetStockMaterialTexture(int materialNumber, int textureNumber)
	{
	}

	public int GetStockTextureNumber(int materialNumber)
	{
		return 0;
	}

	public bool LoadMaterialCustomTexture(int materialNumber, byte[] data)
	{
		return false;
	}

	private void ReleaseCustomTexture(int materialNumber)
	{
	}

	public Texture2D GetCustomTexture(int materialNumber)
	{
		return null;
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}

	private float[] GetFloatsFromColor(Color c)
	{
		return null;
	}

	private Color GetColorFromFloats(float[] a)
	{
		return default(Color);
	}
}
