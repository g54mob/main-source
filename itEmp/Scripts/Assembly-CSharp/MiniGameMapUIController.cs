using UnityEngine;
using UnityEngine.Tilemaps;

public class MiniGameMapUIController : MonoBehaviour
{
	public MiniGamePlayerController MiniGamePlayerController;

	public RectTransform AdapterPositionUIPrefab;

	public RectTransform AdapterPositionUIParent;

	public MiniGameTileBase[] TileBase;

	public Vector3Int offset;

	public Vector3Int offset2;

	public Tilemap tilemapGame;

	public MiniGameTileBase[,] map;

	public MiniGameInventoryAdapter nowSelectInventor;

	public MiniGameInventoryAdapter[] SlotsInventor;

	[ContextMenu("UI Map Generator")]
	private void UIMapGenerator()
	{
	}

	[ContextMenu("Map Generator")]
	public void MapGenerator()
	{
	}

	public MiniGameTileBase GetTileById(int id)
	{
		return null;
	}
}
