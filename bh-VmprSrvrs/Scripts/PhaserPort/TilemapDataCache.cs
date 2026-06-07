using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public struct TilemapDataCache
{
	public float2 worldpos;

	public float2 size;

	public BoundsInt worldBounds;

	public TilemapDataCache(Tilemap layer)
	{
		worldpos = default(float2);
		size = default(float2);
		worldBounds = default(BoundsInt);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float2 CellToWorld(float2 pos)
	{
		return default(float2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float2 CellToWorld(int2 pos)
	{
		return default(float2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
	public int2 WorldToCell(float2 pos)
	{
		return default(int2);
	}

	public TilemapDataCache(PhaserTilemap tilemap)
	{
		worldpos = default(float2);
		size = default(float2);
		worldBounds = default(BoundsInt);
	}
}
