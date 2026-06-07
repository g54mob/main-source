using System;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhaserTilemap : PhaserGameObject
{
	public Tilemap _layer;

	public PhaserTilemapBoundingBoxes _boundingBoxes;

	private SuperMap _map;

	[NonSerialized]
	public PhaserTile[] _phaserTiles;

	[NonSerialized]
	public BoundsInt _bounds;

	[NonSerialized]
	public float4 _worldBounds;

	[NonSerialized]
	public float4 _parentBounds;

	[NonSerialized]
	public int _parentSetID;

	private BoundsInt[] _loadedBounds;

	private bool _isInverse;

	[NonSerialized]
	public float4[] precachedBounds;

	public TilemapDataCache data;

	public override bool isParent => false;

	public override bool isTilemap => false;

	private void Awake()
	{
	}

	public void RefreshData()
	{
	}

	public void RemoveTileAt(int tileX, int tileY)
	{
	}

	public void UpdatePrecachedData()
	{
	}

	public void UpdateTilemapBounds(Bounds parentBounds)
	{
	}

	public int GetTilesInBounds(BoundsInt targetBounds, PhaserTile[] tileCache)
	{
		return 0;
	}

	public bool IsTileAtPosition(float2 position)
	{
		return false;
	}

	public bool IsTileAtPositionWrapped(float2 position)
	{
		return false;
	}

	public PhaserTile GetTileAtCellPosition(int2 cellPos)
	{
		return null;
	}
}
