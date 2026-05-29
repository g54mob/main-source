using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile.DTiles
{
	public class PipeTile : DTileBase2
	{
		public eLuggage ink;

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}
	}
}
