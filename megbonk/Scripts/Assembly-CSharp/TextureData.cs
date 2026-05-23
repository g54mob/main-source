using System;
using UnityEngine;

[CreateAssetMenu]
public class TextureData : UpdatableData
{
	[Serializable]
	public class Layer
	{
		public Texture2D texture;

		public Color tint;

		[Range(0f, 1f)]
		public float tintStrength;

		[Range(0f, 1f)]
		public float startHeight;

		[Range(0f, 1f)]
		public float blendStrength;

		public float textureScale;

		public TerrainType type;
	}

	public enum TerrainType
	{
		Water = 0,
		Sand = 1,
		Grass = 2
	}

	private const int textureSize = 512;

	private const TextureFormat textureFormat = TextureFormat.RGB565;

	public Layer[] layers;

	private float savedMinHeight;

	private float savedMaxHeight;

	public void ApplyToMaterial(Material material)
	{
	}

	public void UpdateMeshHeights(float minHeight, float maxHeight)
	{
	}

	private Texture2DArray GenerateTextureArray(Texture2D[] textures)
	{
		return null;
	}
}
