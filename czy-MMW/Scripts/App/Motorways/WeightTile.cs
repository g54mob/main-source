using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Weight Tile", menuName = "Tiles/Spawn Weight Tile")]
	public class WeightTile : TileBase
	{
		public float tileWeight;

		public Sprite sprite;

		public Color color;

		public bool isCircle;

		public bool overrideWeightColor = true;

		public override void GetTileData(Vector3Int position, UnityEngine.Tilemaps.ITilemap tilemap, ref TileData tileData)
		{
			base.GetTileData(position, tilemap, ref tileData);
			tileData.flags = TileFlags.LockColor;
			tileData.sprite = sprite;
			Color color = this.color;
			if (overrideWeightColor)
			{
				color.a = tileWeight;
			}
			tileData.color = color;
		}
	}
}
