using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Density Tile", menuName = "Tiles/Spawn Density Tile")]
	public class DensityTile : TileBase
	{
		public Sprite sprite;

		public Color color;

		public DensityGroup group;

		public override void GetTileData(Vector3Int position, UnityEngine.Tilemaps.ITilemap tilemap, ref TileData tileData)
		{
			base.GetTileData(position, tilemap, ref tileData);
			tileData.flags = TileFlags.LockColor;
			tileData.sprite = sprite;
			tileData.color = color;
		}
	}
}
