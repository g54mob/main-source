using UnityEngine;
using UnityEngine.Tilemaps;

namespace SuperTiled2Unity
{
	public class SuperBadTile : SuperTile
	{
		public Color m_Color;

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}
	}
}
