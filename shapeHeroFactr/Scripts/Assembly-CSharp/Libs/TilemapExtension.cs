using UnityEngine;
using UnityEngine.Tilemaps;

namespace Libs
{
	public static class TilemapExtension
	{
		public static void SetTiles(this Tilemap tilemap, RectInt grid, TileBase[] tiles)
		{
		}

		public static void FillTiles(this Tilemap tilemap, RectInt grid, TileBase tile)
		{
		}

		public static void ClearTiles(this Tilemap tilemap, RectInt grid)
		{
		}

		public static void ClearTiles(this Tilemap tilemap, Vector3Int[] gridPositions)
		{
		}

		public static Vector3 CellToWorld(this Tilemap tilemap, RectInt gridRect)
		{
			return default(Vector3);
		}
	}
}
