using Unity.Mathematics;
using UnityEngine;

public struct SpriteCachedData
{
	public const float PPU = 100f;

	public const float OneDivPPU = 0.01f;

	public float2 sizeInUnits;

	public float2 pivotInUnits;

	private float2 originalSize;

	public void Set(Sprite t)
	{
	}

	public void Set(Sprite t, float2 originalSize)
	{
	}

	public void SetUsingSpritePPU(Sprite t)
	{
	}
}
