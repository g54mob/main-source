using System.Collections.Generic;
using Cainos.LucidEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Cainos.PixelArtTopDown_Village
{
	[CreateAssetMenu]
	public class RandomDecorationTile : TileBase
	{
		[FoldoutGroup("Params")]
		public float decorationRate;

		[FoldoutGroup("Params")]
		public int seed;

		[FoldoutGroup("Sprites")]
		public List<Sprite> basic;

		[FoldoutGroup("Sprites")]
		public List<Sprite> decoration;

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}
	}
}
