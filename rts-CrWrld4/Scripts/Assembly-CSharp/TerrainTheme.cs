using NBT.Tags;
using UnityEngine;

public class TerrainTheme
{
	public string notes;

	public short[] textures;

	public float[] textureScales;

	public float[] textureStochastic;

	public Color[] textureColors;

	public float[] textureColorBoost;

	public short[] normals;

	public float[] normalIntensity;

	public float[] normalScale;

	public short cliffTexture;

	public float cliffScale;

	public Color cliffColor;

	public float cliffColorBoost;

	public short cliffNormalTexture;

	public float cliffNormalIntensity;

	public float cliffNormalScale;

	public Texture2D[] customTextures;

	public Texture2D[] customNormalTextures;

	public bool customTexturesNeedApplying;

	public bool customNormalTexturesNeedApplying;

	public bool[] overlayEnabled;

	public float[] overlayScaleX;

	public float[] overlayScaleY;

	public float[] overlayOffsetX;

	public float[] overlayOffsetY;

	public bool[] overlayCliffcutoff;

	public bool[] overlayPointFilter;

	public Color[] overlayColor;

	public Texture2D[] overlayTextures;

	private Vector4[] specialColors;

	private float[] specialDetile;

	public TerrainTheme()
	{
	}

	public TerrainTheme(TerrainTheme tt)
	{
	}

	public void CopyTheme(TerrainTheme tt)
	{
	}

	public void ApplyToMaterial()
	{
	}

	public void DestroyTheme()
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}

	private Vector4[] ColorsToArray(Color[] colors)
	{
		return null;
	}

	private Color[] ColorsFromArray(Vector4[] vectors)
	{
		return null;
	}
}
