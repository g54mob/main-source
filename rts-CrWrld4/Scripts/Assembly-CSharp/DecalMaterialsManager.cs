using NBT.Tags;
using UnityEngine;

public class DecalMaterialsManager
{
	private byte[][] cachedTextureData;

	public Material[] decalMaterials;

	private Texture decalEmptyTexture;

	public void Finished()
	{
	}

	public bool LoadMaterialCustomTexture(int slot, byte[] data)
	{
		return false;
	}

	public void UpdateMaterialSettings(int slot, int renderQueue, float normalClip)
	{
	}

	public void UpdateTextureSettings(int slot, FilterMode filterMode, TextureWrapMode wrapMode)
	{
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
