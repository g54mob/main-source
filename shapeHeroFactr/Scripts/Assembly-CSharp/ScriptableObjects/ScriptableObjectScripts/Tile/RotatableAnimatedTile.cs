using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	public class RotatableAnimatedTile : AnimatedTile
	{
		public float rotateZOffset;

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}
	}
}
