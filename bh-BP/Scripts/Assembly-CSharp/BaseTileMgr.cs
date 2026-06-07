using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseTileMgr : TileMgr
{
	public static BaseTileMgr I;

	public Tilemap OuterTilemapDetails;

	public TileBase TileGroundInner;

	public TileBase TileGroundDetailsInner;

	public TileBase TileGroundOuter;

	public TileBase TileGroundDetailsOuter;

	public TileBase TileStoneRoad;

	public Sprite SprBlankTile;

	public SpriteAnimClip[] BirdAnims;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void InitTiles()
	{
	}

	public void SetGroundTile(int x, int y, BaseTileType type)
	{
	}

	public TileBase GetTile(BaseTileType type)
	{
		return null;
	}

	private void FillOuterDetails(int chunkX, int chunkY)
	{
	}
}
