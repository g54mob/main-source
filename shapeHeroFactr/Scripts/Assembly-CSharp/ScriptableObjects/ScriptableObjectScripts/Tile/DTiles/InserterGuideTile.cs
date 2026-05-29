using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile.DTiles
{
	public class InserterGuideTile : DTileBase2
	{
		public float rotateZOffset;

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}
	}
}
