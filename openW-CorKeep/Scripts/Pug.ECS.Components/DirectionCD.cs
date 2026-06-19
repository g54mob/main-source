using System;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct DirectionCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float3 direction;

	public int rotationIconOffset;

	public static int2 GetPrefabTileSize(int2 defaultTileSize, int2 currentDirection)
	{
		if (currentDirection.x != 0)
		{
			return new int2(defaultTileSize.y, defaultTileSize.x);
		}
		return defaultTileSize;
	}

	public int2 GetPrefabTileSize(int2 defaultTileSize)
	{
		return GetPrefabTileSize(defaultTileSize.ToVec2Int()).ToInt2();
	}

	public Vector2Int GetPrefabTileSize(Vector2Int defaultTileSize)
	{
		if (math.abs(direction.x) > 0.5f)
		{
			return new Vector2Int(defaultTileSize.y, defaultTileSize.x);
		}
		return defaultTileSize;
	}

	public static Vector2Int GetPrefabOffset(Vector2Int defaultOffset, float3 currentDirection)
	{
		if (math.abs(currentDirection.x) > 0.5f)
		{
			return new Vector2Int(defaultOffset.y, defaultOffset.x);
		}
		return defaultOffset;
	}

	public int2 GetPrefabOffset(int2 defaultOffset)
	{
		return GetPrefabOffset(defaultOffset.ToVec2Int()).ToInt2();
	}

	public Vector2Int GetPrefabOffset(Vector2Int defaultOffset)
	{
		return defaultOffset;
	}

	public void GetPrefabOffsetAndTileSize(int2 defaultOffset, int2 defaultTileSize, out int2 offset, out int2 size)
	{
		offset = GetPrefabOffset(defaultOffset);
		size = GetPrefabTileSize(defaultTileSize);
	}

	public static void RotateTransform(quaternion currentOrientation, float3 currentTranslation, int rotationIndex, int2 originalPrefabOffset, int2 originalPrefabTileSize, out quaternion newOrientation, out float3 newTranslation)
	{
		float3 float5 = float3.zero;
		switch (rotationIndex)
		{
		case 1:
			float5 = new float3(0f, 0f, (float)originalPrefabTileSize.x - 1f);
			break;
		case 2:
			float5 = new float3((float)originalPrefabTileSize.x - 1f, 0f, (float)originalPrefabTileSize.y - 1f);
			break;
		case 3:
			float5 = new float3((float)originalPrefabTileSize.y - 1f, 0f, 0f);
			break;
		}
		float angle = (float)rotationIndex * MathF.PI / 2f;
		float2 float6 = new float2(originalPrefabOffset.x, originalPrefabOffset.y);
		float4x4 identity = float4x4.identity;
		identity.c3 = new float4(float6.x, 0f, float6.y, 1f);
		float4x4 a = float4x4.RotateY(angle);
		float4x4 b = new float4x4(currentOrientation, currentTranslation);
		float4x4 m = math.mul(identity, math.mul(a, math.mul(math.inverse(identity), b)));
		newOrientation = new quaternion(m);
		newTranslation = new float3(m.c3.x, m.c3.y, m.c3.z) + float5;
	}
}
