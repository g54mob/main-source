using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Tree Tile", menuName = "Tiles/Spawn Tree Tile")]
	public class TreeTile : TileBase
	{
		public int prefabIndex;

		public Sprite sprite;

		public override void GetTileData(Vector3Int position, UnityEngine.Tilemaps.ITilemap tilemap, ref TileData tileData)
		{
			base.GetTileData(position, tilemap, ref tileData);
			tileData.flags = TileFlags.LockColor;
			tileData.sprite = sprite;
		}
	}
}
